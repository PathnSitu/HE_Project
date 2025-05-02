// Send & Receive Data Working function
int prev_Snt_func_code;string prev_Snt_m_CmdData = "";
int expectedResponses = 1;
private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
private async void snd_rcvCmd(int func_code, string m_CmdData)
        {
            ////if (Communication.isComandInProgress)
            ////    return;
            await _semaphore.WaitAsync();
            try
            {
                Application.DoEvents();
                byte[] cmdpkt = new byte[255];
                string resp_data = "", m_Cmdstr = "";

                //Response Variables
                byte[] receivebuff, resp_bytedata; // this variable is used for to receive the information from device
                Boolean retnval = false;  //this variable is used for to return the value for crc checking
                int cmdlen = 0, lncrc = 0;
                int dl = 0, receivecount = 0;
                string st1 = "", st2 = "";
                //Response Variables
                if ((func_code == 1) || (func_code == 2)||(func_code == 3)||(func_code == 4)||(func_code == 5)||(func_code == 8) || (func_code == 17) || ((func_code == 16)&&(m_CmdData=="0")))
                    expectedResponses = 2;
                else if ((func_code == 6) || (func_code == 7) || (func_code == 9) || (func_code == 10) || (func_code == 11) || (func_code == 12) || (func_code == 13) || (func_code == 14) || (func_code == 15) || ((func_code == 16) && (m_CmdData == "1")))
                    expectedResponses = 1;

                ////if (Communication.commandQueue.Count > 0)
                ////    m_Cmdstr = Communication.commandQueue.Dequeue();// Get the next command

                if (!mport.IsOpen)
                    init_port(); //Intializing the port

                //if (mport.IsOpen)
                //    mport.Open();

                if (mport.IsOpen)
                    Communication.portopened = true;
                else
                    Communication.portopened = false;

                //if((func_code==2)|| (func_code == 3))
                //{
                RA_pickedflg = false;RA_placedflg = false;RA_movedflg = false;
                //}

                pGotByteFlag = false;
                if (repeatval == 0)
                {
                    //Calling frame command function
                    if(RA_Move_cmd_issued==true)
                        Communication.frame_command(func_code, m_CmdData, Communication.Movement_RA_No, m_Cmdstr);
                    else
                        Communication.frame_command(func_code, m_CmdData, Communication.RA_No, m_Cmdstr);
                    m_Cmdstr = Communication.framed_cmd;
                    framed_Data = m_CmdData;
                    sent_func_code = func_code;
                    prev_Snt_func_code = func_code;
                    prev_Snt_m_CmdData = m_CmdData;
                }
                else if (repeatval > 0)
                {
                    m_Cmdstr = Communication.framed_cmd;
                }

                cmdpkt = new byte[m_Cmdstr.Length];
                cmdpkt = Encoding.Default.GetBytes(m_Cmdstr);
               
                #region
                if (repeatval >= 3)
                {
                    Communication.writeCommunicationErrorlog("Communication Failed Occured for " + resp_data);
                    MessageBox.Show("Communication Failed with device check the cable connected to the device...", RequiredVariables.Msgtext, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (mport.IsOpen)
                        mport.Close();
                    Communication.datastartreceivingflag = false;
                    Communication.isComandInProgress = false;
                    return;
                }
                else
                {
                    //checking the commuication port is open or not 
                    if (mport.IsOpen == false)
                    {
                        mport.Open();  //if comminication port got closed then opening the port.
                    }
                    //////mport.Write(cmdpkt, 0, cmdpkt.Length);  //Sending command to the unit through communication port
                    pGotByteFlag = false;
                    mport.DiscardInBuffer();
                    mport.DiscardOutBuffer();
                    System.Threading.Thread.Sleep(100);
                    ////while (cmd_Exec_Comp == true)
                    ////{
                        SetText(CommandName + " - " + m_Cmdstr);
                        string strcmddata = ""; strcmddata = m_Cmdstr; strcmddata = strcmddata.Replace('\n', ' ');
                        Communication.writeCommunicationCommands("Command Sent " + CommandName + " - " + strcmddata); //m_Cmdstr);
                        cmd_Exec_Comp = false;
                        mport.Write(cmdpkt, 0, cmdpkt.Length);  //Sending command to the unit through communication port
                        /////*.. Above line blocked for testing and working fine ..*/
                        //////mport.Write(m_Cmdstr);  //Sending direct command to string
                        //////Communication.isComandInProgress = true;// Set flag to avoid overlap
                        //Updating Sequence Number
                        Communication.SequnceNo++;
                        DateTime dltime = System.DateTime.Now;
                        dltime = dltime.AddSeconds(5);  // Adding 5 seconds delay 
                        delay(dltime);
                    ////    break;
                    ////}

                    ////////Below code added on 06-11-2024 as per suggestion of satayanarayana
                    tmr_RespFail.Enabled = true;
                    tmr_RespFail.Interval = 1000;
                    device_resp_Check_time = System.DateTime.Now.AddSeconds(20);
                    //////Above code added on 06-11-2024 as per suggestion of satayanarayana

                    //////Code modified and added on 11-01-2025 in order to avoid collison and stopage of application
                    ////while(cmd_Exec_Comp==true)
                    ////{
                    ////    tmr_RespFail.Enabled = false;
                    ////    checkandupdatedatatoscreen(btntst); cmd_Exec_Comp = false;
                    ////}
                }
                #endregion

                return;
            }
            catch (Exception d3)
            {
                MessageBox.Show("ER-1027 Command Sending to Device Failed Check Communication cable with device", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                RequiredVariables.writeerrorlogfile("ER-1027 Command Sending to Device Failed Check Communication cable with device \n" + d3.ToString(), "In snd_rcvCmd() function in Form_Live form");
                return;
            }
            finally
            {
                _semaphore.Release();
            }
        }
		
//Data Event Handler Event working functions implemented in H&E dual arm working project
 private StringBuilder _dataBuffer = new StringBuilder();
        private void DataReceivedHandler_Nw(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int func_code = sent_func_code;
                System.Threading.Thread.Sleep(200);
                // Read available data
                string data = mport.ReadExisting();
                _dataBuffer.Append(data);

                // Assuming responses are delimited by newline (\n) or any specific terminator
                string[] responses = _dataBuffer.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                //if (responses.Length >= expectedResponses)
                //{
                    pGotByteFlag = true;
                for (int i = 0; i < responses.Length; i++)
                {
                    string btntst = "";
                    btntst = responses[i];

                    if (!string.IsNullOrEmpty(btntst))
                    {
                        if (btntst.Contains('\r'))
                            btntst = btntst.Replace("\r", "");

                        btntst = btntst.Replace("#", "");
                        btntst = btntst.Replace("!", "");

                        byte[] rcvpkt = Encoding.Default.GetBytes(btntst);
                        if ((Communication.CRC_Calculation(rcvpkt, 2)) == 1)
                        {
                            repeatval += 1;
                            snd_rcvCmd(func_code, framed_Data);
                        }
                        else
                        {
                            Communication.writeCommunicationCommands("CRC-Response  - " + btntst);
                            string[] Jarr = btntst.Split(',');
                            string rtype = "", respval = "";
                            rtype = Jarr[2].Substring(0, 1);
                            if (Jarr.Length > 3)
                            {
                                respval = Jarr[2].Substring(1);
                            }
                            else
                            {
                                respval = Jarr[2].Substring(1, 3);
                            }
                            if (Jarr[2].ToString() == "F000") cmd_Exec_Comp = true;
                            if (((rtype == "F") || (rtype == "I")) && ((respval == "003") || (respval == "004")))
                            {  //resending the command for invalid argument passed
                                repeatval = 0;
                                snd_rcvCmd(prev_Snt_func_code, prev_Snt_m_CmdData);
                            }
                            else
                            {
                                if (((rtype == "F") || (rtype == "I")) && ((respval == "000") || (respval == "001")))
                                {
                                    checkandupdatedatatoscreen(btntst);
                                }
                            }
                        }
                    }
                }
                // Clear processed responses, retain incomplete data if any
                _dataBuffer.Clear();
                ////}
            }
            catch (Exception d3)
            {

            }

        }
        string btntst = "";
        private void DataReceivedHandler_oldworking(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                byte[] receivebuff, resp_bytedata; // this variable is used for to receive the infrmation from device
                Boolean retnval = false;  //this variable is used for to return the value for crc checking
                int func_code = 0, cmdlen = 0, lncrc = 0;
                int dl = 0, receivecount = 0;
                string resp_data = "", st1 = "", st2 = "";

                #region DataResponse
                ////if (pGotByteFlag == true)
                ////{
                func_code = sent_func_code;
                try
                {
                    System.Threading.Thread.Sleep(100);  //Waiting for 100 ms to get the data from the device
                    //if (mport.ReadBufferSize > 0)
                    if (mport.BytesToRead > 0)
                    {
                        pGotByteFlag = true;
                        receivebuff = new byte[mport.ReadBufferSize];
                        retnval = false;                        
                            receivecount = mport.Read(receivebuff, 0, mport.ReadBufferSize);
                            if (receivecount <= 0)
                            {
                                repeatval++;
                                tmr_RespFail.Enabled = false;
                                snd_rcvCmd(func_code, framed_Data);                                
                                return;
                            }
                            byte[] rcvpkt = new byte[receivecount];
                            byte[] buff1 = new byte[receivecount];
                            byte[] buff2 = new byte[receivecount];
                            int crc = 0;
                            rcvpkt = new byte[receivecount];
                            func_code = sent_func_code;
                            if (receivecount > 0)
                            {                                
                                pGotByteFlag = true;   // Modified on 30-08-2024 1225 prviously this flag is above if statement(if (receivecount > 0)) 
                                Array.Copy(receivebuff, 0, rcvpkt, 0, receivecount);
                                btntst = Encoding.Default.GetString(rcvpkt);
                                if (btntst.Contains("I001")) pGotByteFlag = false;
                                Communication.writeCommunicationCommands("Raw Resp -" + btntst);
                                string[] cmdresp = btntst.Split('\n');
                                if (cmdresp.Length > 0)
                                {
                                    int cnt = 0;
                                    for (cnt = 0; cnt < cmdresp.Length; cnt++)
                                    {
                                        btntst = "";
                                        btntst = cmdresp[cnt];
                                        if (btntst.Contains("Enter string"))
                                            cnt++;
                                        btntst = "";
                                        btntst = cmdresp[cnt];

                                        if (!string.IsNullOrEmpty(btntst))
                                        {
                                            if (btntst.Contains('\r'))
                                                btntst = btntst.Replace("\r", "");

                                            btntst = btntst.Replace("#", "");
                                            btntst = btntst.Replace("!", "");
                                            rcvpkt = Encoding.Default.GetBytes(btntst);
                                            crc = Communication.CRC_Calculation(rcvpkt, 2);
                                            if (crc == 1)
                                            {
                                                repeatval += 1;
                                                tmr_RespFail.Enabled = false;
                                                snd_rcvCmd(func_code, framed_Data);                                                
                                            }
                                            else
                                            {                                                
                                                Communication.writeCommunicationCommands("CRC-Response  - " + btntst);
                                                string[] Jarr = btntst.Split(',');
                                                string rtype = "", respval = "";
                                                st1 = "";
                                                st1 = Jarr[2];
                                                rtype = st1.Substring(0, 1); 
                                                respval = st1.Substring(1,3);
                                                if ((st1.Substring(0, 4) == "I001") || (st1.Substring(0, 4) == "F001")) SetText("Command Execution Under Progress");
                                                if ((rtype == "F") && ((respval == "003") || (respval == "004") || (respval == "005") || (respval == "006")))
                                                {  //resending the command for invalid argument passed
                                                    if (respval == "005")  //if ((rtype == "F") && (respval == "005"))
                                                    {
                                                        Thread.Sleep(5000); //Waiting for 5 seconds and sending the command                                                        
                                                    }
                                                    else if (respval == "006")  //Robotic arm collison
                                                    {                                                        
                                                        if (Communication.RA_No == 1) Communication.RA_No = 2; else Communication.RA_No = 1;                                                        
                                                    }
                                                    tmr_RespFail.Enabled = false; repeatval = 0; Communication.SequnceNo--;
                                                    snd_rcvCmd(prev_Snt_func_code, prev_Snt_m_CmdData);
                                                }
                                                else
                                                {
                                                ////if (((rtype == "F") || (rtype == "I")) && ((respval == "000") || (respval == "001")))
                                                ////{                                                                                                              
                                                        if (rtype == "F") { cmd_Exec_Comp = true; tmr_RespFail.Enabled = false;break; }
                                                        ////checkandupdatedatatoscreen(btntst);
                                                        //if ((rtype == "F") && (respval == "000"))
                                                        //{   tmr_RespFail.Enabled = false;
                                                        //    switch (Convert.ToInt32(Jarr[1].ToString()))
                                                        //    {
                                                        //        case 1:  //RA Movement
                                                        //            {
                                                        //                rareached = true;
                                                        //                RA_movedflg = true;
                                                        //                if (RA_Move_issued == true)
                                                        //                {
                                                        //                    RA_Move_issued = false;
                                                        //                    if (tmr_Cut.Enabled == true) tmr_Cut.Enabled = false;
                                                        //                }
                                                        //                break;
                                                        //            }
                                                        //        case 2:  //RA Picked
                                                        //            {
                                                        //                RA_Protorun_intiated = false;
                                                        //                rareached = true;
                                                        //                RA_pickedflg = true;
                                                        //                break;
                                                        //            }
                                                        //        case 3:  //RA Placed
                                                        //            {
                                                        //                RA_Protorun_intiated = false;
                                                        //                rareached = true;
                                                        //                RA_placedflg = true;
                                                        //                break;
                                                        //            }
                                                        //        case 4: //Level Sensing With RA
                                                        //            {
                                                        //                sensed = true;
                                                        //                rareached = true;
                                                        //                break;
                                                        //            }
                                                        //        case 5: //Home Command
                                                        //            {
                                                        //                RA_Protorun_intiated = false; // Added on 22-08-2023
                                                        //                Homecmdissued = true;
                                                        //            break;
                                                        //            }
                                                        //        case 17:  //RA Dip
                                                        //            {
                                                        //                rack_dip = true;
                                                        //                rareached = true;
                                                        //                break;
                                                        //            }
                                                        //    }
                                                        //    Communication.isComandInProgress = false;// Set flag to avoid overlap
                                                        //}
                                                    ////}   
                                                }                                                
                                            }
                                            ////}
                                        }
                                    }
                                    if (cnt == cmdresp.Length)
                                        return;
                                }
                            }
                        
                    }
                    else  //Didn't received the data from device
                    {
                        if (func_code == 15)  //Poll command                                              
                        {
                            if (Communication.devid < 255)
                            {
                                Communication.devid++;
                                snd_rcvCmd(func_code, framed_Data);     //Sending the same command for another time to machine
                            }
                            else
                            {
                                //writeCommunicationErrorlog("Communication Failed Occured for - " + Command_Name);
                                MessageBox.Show("Communication Failed with device check the cable connected to the device...", "H & E Communication", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if (mport.IsOpen)
                                    mport.Close();
                                return;
                            }
                        }
                    }
                }
                catch (Exception e3)
                {
                    //writeCommunicationErrorlog("Error recived while receiving data from device for command " + Command_Name + " function code - " + func_code + " and command : " + resp_data + "\r\nError String :" + e3.ToString());
                    return;
                }
                #endregion

            }
            catch (Exception d3)
            {

            }

        }
        // Use a static variable to track the last processed response to detect duplicates
        static string lastResponse = "";
        static int lastSequenceNo = -1;
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                byte[] receivebuff;
                bool retnval = false;
                int func_code = sent_func_code;
                int receivecount = 0;
                string resp_data = "";
                #region DataResponse
                try
                {
                    System.Threading.Thread.Sleep(100); // Wait for data to stabilize

                    if (mport.BytesToRead > 0)
                    {
                        pGotByteFlag = true;
                        receivebuff = new byte[mport.BytesToRead]; // Use BytesToRead instead of ReadBufferSize
                        receivecount = mport.Read(receivebuff, 0, mport.BytesToRead);

                        if (receivecount <= 0)
                        {
                            repeatval++;
                            tmr_RespFail.Enabled = false;
                            snd_rcvCmd(func_code, framed_Data);
                            return;
                        }

                        // Convert received bytes to string for processing
                        byte[] rcvpkt = new byte[receivecount];
                        Array.Copy(receivebuff, 0, rcvpkt, 0, receivecount);
                        string btntst = Encoding.Default.GetString(rcvpkt);

                        // Check for duplicate response
                        if (btntst == lastResponse && Communication.SequnceNo == lastSequenceNo)
                        {
                            Communication.writeCommunicationCommands("Duplicate Response Ignored: " + btntst);
                            return; // Ignore duplicate
                        }

                        // Update last response and sequence number
                        lastResponse = btntst;
                        lastSequenceNo = Communication.SequnceNo;

                        // Log raw response
                        Communication.writeCommunicationCommands("Raw Resp - " + btntst);

                        // Reset flag for specific cases
                        if (btntst.Contains("I001")) pGotByteFlag = false;

                        // Split response by newline
                        string[] cmdresp = btntst.Split('\n');
                        for (int cnt = 0; cnt < cmdresp.Length; cnt++)
                        {
                            btntst = cmdresp[cnt];
                            if (btntst.Contains("Enter string"))
                                continue;

                            if (!string.IsNullOrEmpty(btntst))
                            {
                                // Clean response
                                btntst = btntst.Replace("\r", "").Replace("#", "").Replace("!", "");
                                rcvpkt = Encoding.Default.GetBytes(btntst);

                                // Perform CRC check
                                int crc = Communication.CRC_Calculation(rcvpkt, 2);
                                if (crc == 1)
                                {
                                    repeatval++;
                                    tmr_RespFail.Enabled = false;
                                    snd_rcvCmd(func_code, framed_Data);
                                    return;
                                }

                                // Log valid CRC response
                                Communication.writeCommunicationCommands("CRC-Response - " + btntst);

                                // Parse response
                                string[] Jarr = btntst.Split(',');
                                string rtype = "", respval = "";
                                if (Jarr.Length > 2)
                                {
                                    string st1 = Jarr[2];
                                    rtype = st1.Substring(0, 1);
                                    respval = st1.Substring(1, 3);

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
                                        Communication.SequnceNo--;
                                        snd_rcvCmd(prev_Snt_func_code, prev_Snt_m_CmdData);
                                    }
                                    else
                                    {
                                        if (rtype == "F")
                                        {
                                            checkandupdatedatatoscreen(btntst);
                                            cmd_Exec_Comp = true;
                                            tmr_RespFail.Enabled = false;
                                            break;
                                        }
                                    }
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
                    Communication.writeCommunicationCommands("Error receiving data: " + e3.Message);
                    return;
                }
                #endregion
            }
            catch (Exception d3)
            {
                Communication.writeCommunicationCommands("General error: " + d3.Message);
            }
        }
		
