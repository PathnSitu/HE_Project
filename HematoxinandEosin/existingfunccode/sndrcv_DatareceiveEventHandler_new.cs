private static readonly Queue<(int funcCode, string cmdData)> commandQueue = new Queue<(int, string)>();
private static TaskCompletionSource<bool> responseTcs = null;

private async Task snd_rcvCmd(int func_code, string m_CmdData)
{
    // Enqueue the command
    commandQueue.Enqueue((func_code, m_CmdData));

    // Process commands sequentially
    while (commandQueue.Count > 0)
    {
        await _semaphore.WaitAsync();
        try
        {
            var (currentFuncCode, currentCmdData) = commandQueue.Dequeue();
            await SendCommandAsync(currentFuncCode, currentCmdData);
        }
        finally
        {
            _semaphore.Release();
        }
    }
}

private async Task SendCommandAsync(int func_code, string m_CmdData)
{
    try
    {
        // Set expected responses based on func_code
        if (func_code is 1 or 2 or 3 or 4 or 5 or 8 or 17 || (func_code == 16 && m_CmdData == "0"))
            expectedResponses = 2;
        else if (func_code is 6 or 7 or 9 or 10 or 11 or 12 or 13 or 14 or 15 || (func_code == 16 && m_CmdData == "1"))
            expectedResponses = 1;
        else
            expectedResponses = 1; // Default

        // Initialize port if not open
        if (!mport.IsOpen)
        {
            init_port();
            if (!mport.IsOpen)
            {
                Communication.writeCommunicationErrorlog($"Failed to open port for func_code: {func_code}");
                Communication.portopened = false;
                return;
            }
        }
        Communication.portopened = true;

        // Reset flags for specific commands
        if (func_code is 2 or 3)
        {
            RA_pickedflg = false;
            RA_placedflg = false;
            RA_movedflg = false;
        }

        string m_Cmdstr = "";
        int retryCount = repeatval; // Use repeatval for retries
        const int maxRetries = 3;

        while (retryCount < maxRetries)
        {
            try
            {
                // Frame the command
                if (retryCount == 0)
                {
                    int raNo = RA_Move_cmd_issued ? Communication.Movement_RA_No : Communication.RA_No;
                    Communication.frame_command(func_code, m_CmdData, raNo, "");
                    m_Cmdstr = Communication.framed_cmd;
                    framed_Data = m_CmdData;
                    sent_func_code = func_code;
                    prev_Snt_func_code = func_code;
                    prev_Snt_m_CmdData = m_CmdData;
                }
                else
                {
                    m_Cmdstr = Communication.framed_cmd; // Reuse for retries
                }

                byte[] cmdpkt = Encoding.Default.GetBytes(m_Cmdstr);

                // Prepare for response
                pGotByteFlag = false;
                cmd_Exec_Comp = false;
                responseTcs = new TaskCompletionSource<bool>();

                // Clear buffers
                mport.DiscardInBuffer();
                mport.DiscardOutBuffer();

                // Log command
                string logCmd = m_Cmdstr.Replace("\n", " ");
                Communication.writeCommunicationCommands($"Command Sent (SeqNo: {Communication.SequnceNo}, Retry: {retryCount}) {CommandName} - {logCmd}");
                SetText($"{CommandName} - {m_Cmdstr}");

                // Send command
                mport.Write(cmdpkt, 0, cmdpkt.Length);

                // Increment sequence number for new commands (not retries)
                if (retryCount == 0)
                    Communication.SequnceNo++;

                // Await response with timeout
                using var cts = new CancellationTokenSource(20000); // 20s timeout
                var completedTask = await Task.WhenAny(responseTcs.Task, Task.Delay(20000, cts.Token));
                if (completedTask == responseTcs.Task && await responseTcs.Task)
                {
                    // Response received successfully
                    repeatval = 0; // Reset retry counter
                    tmr_RespFail.Enabled = false;
                    break; // Exit retry loop
                }
                else
                {
                    // Timeout or no valid response
                    retryCount++;
                    repeatval = retryCount;
                    Communication.writeCommunicationCommands($"No response for func_code: {func_code}, SeqNo: {Communication.SequnceNo}, Retry: {retryCount}");
                    tmr_RespFail.Enabled = true;
                    tmr_RespFail.Interval = 1000;
                }
            }
            catch (Exception ex)
            {
                retryCount++;
                repeatval = retryCount;
                Communication.writeCommunicationCommands($"Error sending func_code: {func_code}, SeqNo: {Communication.SequnceNo}, Retry: {retryCount}, Error: {ex.Message}");
            }
        }

        if (retryCount >= maxRetries)
        {
            Communication.writeCommunicationErrorlog($"Communication Failed for func_code: {func_code}, SeqNo: {Communication.SequnceNo}");
            MessageBox.Show("Communication Failed with device. Check the cable.", RequiredVariables.Msgtext, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (mport.IsOpen)
                mport.Close();
            Communication.datastartreceivingflag = false;
        }
    }
    catch (Exception ex)
    {
        Communication.writeCommunicationErrorlog($"Fatal error in snd_rcvCmd, func_code: {func_code}: {ex.Message}");
        MessageBox.Show("ER-1027 Command Sending Failed. Check cable.", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        RequiredVariables.writeerrorlogfile($"ER-1027 Command Sending Failed: {ex}", "In snd_rcvCmd()");
    }
}


private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
{
    try
    {
        byte[] receivebuff;
        bool retnval = false;
        int func_code = sent_func_code;
        int receivecount = 0;

        // Buffer to accumulate data across multiple events
        static StringBuilder responseBuffer = new StringBuilder();
        // Track processed sequence numbers to detect duplicates
        static HashSet<int> processedSequenceNos = new HashSet<int>();
        // Track last response for logging (optional)
        static string lastResponse = "";

        #region DataResponse
        try
        {
            // Wait briefly to allow data to accumulate
            System.Threading.Thread.Sleep(100);

            if (mport.BytesToRead > 0)
            {
                // Read all available data
                receivebuff = new byte[mport.BytesToRead];
                receivecount = mport.Read(receivebuff, 0, mport.BytesToRead);

                if (receivecount <= 0)
                {
                    repeatval++;
                    tmr_RespFail.Enabled = false;
                    snd_rcvCmd(func_code, framed_Data);
                    return;
                }

                // Convert to string and append to buffer
                string newData = Encoding.Default.GetString(receivebuff, 0, receivecount);
                responseBuffer.Append(newData);

                // Check for complete response (assuming \n delimiter)
                if (!newData.Contains("\n"))
                {
                    // Wait for more data
                    return;
                }

                // Process complete responses
                string btntst = responseBuffer.ToString();
                responseBuffer.Clear(); // Clear buffer after processing

                // Check for duplicate response by sequence number
                if (processedSequenceNos.Contains(Communication.SequnceNo))
                {
                    Communication.writeCommunicationCommands($"Duplicate Response Ignored (SeqNo: {Communication.SequnceNo}): {btntst}");
                    return; // Ignore duplicate
                }

                // Mark this sequence number as processed
                processedSequenceNos.Add(Communication.SequnceNo);
                // Optional: Limit history to prevent memory growth
                if (processedSequenceNos.Count > 100)
                {
                    processedSequenceNos.Remove(processedSequenceNos.First());
                }

                // Log response for debugging
                if (btntst != lastResponse)
                {
                    Communication.writeCommunicationCommands($"Raw Resp (SeqNo: {Communication.SequnceNo}) - {btntst}");
                    lastResponse = btntst;
                }

                // Set flag for valid data
                pGotByteFlag = true;
                if (btntst.Contains("I001"))
                {
                    pGotByteFlag = false;
                }

                // Split and process response lines
                string[] cmdresp = btntst.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                for (int cnt = 0; cnt < cmdresp.Length; cnt++)
                {
                    string line = cmdresp[cnt].Trim();
                    if (string.IsNullOrEmpty(line) || line.Contains("Enter string"))
                    {
                        continue;
                    }

                    // Clean response
                    string cleanedLine = line.Replace("\r", "").Replace("#", "").Replace("!", "");
                    byte[] rcvpkt = Encoding.Default.GetBytes(cleanedLine);

                    // Perform CRC check
                    int crc = Communication.CRC_Calculation(rcvpkt, 2);
                    if (crc == 1)
                    {
                        repeatval++;
                        tmr_RespFail.Enabled = false;
                        processedSequenceNos.Remove(Communication.SequnceNo); // Allow retry
                        snd_rcvCmd(func_code, framed_Data);
                        return;
                    }

                    // Log valid response
                    Communication.writeCommunicationCommands($"CRC-Response (SeqNo: {Communication.SequnceNo}) - {cleanedLine}");

                    // Parse response
                    string[] Jarr = cleanedLine.Split(',');
                    if (Jarr.Length > 2)
                    {
                        string st1 = Jarr[2];
                        string rtype = st1.Substring(0, 1);
                        string respval = st1.Substring(1, 3);

                        if (st1.Substring(0, 4) == "I001" || st1.Substring(0, 4) == "F001")
                        {
                            SetText("Command Execution Under Progress");
                        }

                        if (rtype == "F" && (respval == "003" || respval == "004" || respval == "005" || respval == "006"))
                        {
                            if (respval == "005")
                            {
                                Thread.Sleep(5000); // Wait before retry
                            }
                            else if (respval == "006")
                            {
                                Communication.RA_No = (Communication.RA_No == 1) ? 2 : 1;
                            }
                            tmr_RespFail.Enabled = false;
                            repeatval = 0;
                            processedSequenceNos.Remove(Communication.SequnceNo); // Allow retry
                            Communication.SequnceNo--;
                            snd_rcvCmd(prev_Snt_func_code, prev_Snt_m_CmdData);
                            return;
                        }
                        else if (rtype == "F")
                        {
                            cmd_Exec_Comp = true;
                            tmr_RespFail.Enabled = false;
                            break; // Exit loop after processing valid response
                        }
                    }
                }
            }
            else // No data received
            {
                if (func_code == 15) // Poll command
                {
                    if (Communication.devid < 255)
                    {
                        Communication.devid++;
                        snd_rcvCmd(func_code, framed_Data);
                    }
                    else
                    {
                        MessageBox.Show("Communication Failed with device check the cable connected to the device...", "H & E Communication", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (mport.IsOpen)
                            mport.Close();
                    }
                }
            }
        }
        catch (Exception e3)
        {
            Communication.writeCommunicationCommands($"Error receiving data (SeqNo: {Communication.SequnceNo}): {e3.Message}");
            return;
        }
        #endregion
    }
    catch (Exception d3)
    {
        Communication.writeCommunicationCommands($"General error: {d3.Message}");
    }
}

//For Queues add below code
private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
{
    try
    {
        // Existing code until response validation
        // ...

        // Inside the response parsing loop, after validating CRC and response
        if (rtype == "F")
        {
            cmd_Exec_Comp = true;
            tmr_RespFail.Enabled = false;
            if (snd_rcvCmd.responseTcs != null)
            {
                snd_rcvCmd.responseTcs.TrySetResult(true); // Signal response received
            }
            break;
        }
    }
    catch (Exception ex)
    {
        Communication.writeCommunicationCommands($"Error in DataReceivedHandler: {ex.Message}");
        if (snd_rcvCmd.responseTcs != null)
        {
            snd_rcvCmd.responseTcs.TrySetResult(false); // Signal failure
        }
    }
}


