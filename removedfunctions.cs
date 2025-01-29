  private string get_R1_positiondetails()
        {
            //Taking detail protocol table
            string JName = "", sndcmdstr = "";
            #region prev & next rack
            //New code added on 12-12-2023 to get the previous & next jar name to ON & OFF the water pump
            if (r1inx == 0)
            {
                Prev_JarName_R1 = "";
                DataRow[] prs1 = R1Protorun.Select("SlNo =" + (r1inx + 2));
                if (prs1.Length > 0)
                {
                    Next_JarName_R1 = prs1[0]["JarNo"].ToString();
                }
                else
                    Next_JarName_R1 = "";
            }
            else if (r1inx > 0)
            {
                DataRow[] prs2 = R1Protorun.Select("SlNo =" + (r1inx));
                if (prs2.Length > 0)
                {
                    Prev_JarName_R1 = prs2[0]["JarNo"].ToString();
                }
                else
                    Prev_JarName_R1 = "";

                if ((r1inx + 2) <= R1Protorun.Rows.Count)
                {
                    DataRow[] prs3 = R1Protorun.Select("SlNo =" + (r1inx + 2));
                    if (prs3.Length > 0)
                    {
                        Next_JarName_R1 = prs3[0]["JarNo"].ToString();
                    }
                    else
                        Next_JarName_R1 = "";
                }
            }
            //New code added on 12-12-2023 to get the values of water pump/ valve
            #endregion
            DataRow[] protoresult = R1Protorun.Select("SlNo =" + (r1inx + 1));
            if (protoresult.Length > 0)
            {
                JName = protoresult[0]["JarNo"].ToString();
                RegName_R1 = protoresult[0]["RegName"].ToString();
                ShortRegName_R1 = protoresult[0]["RegName"].ToString();
                incubtime_R1 = Convert.ToInt32(protoresult[0]["Incubtime"].ToString());
                noofdips_R1 = Convert.ToInt32(protoresult[0]["Dips"].ToString());
                if (noofdips_R1 > 0)
                {
                    R1_dipdelay = 1;
                    R1_drydelay = 1;
                }
                //Priority code added on 15-11-2023 to reduce the time delay for next rack or to stop colliding
                if(JName.Contains("U"))
                    r1priority = 0;
                else
                {
                    if (((incubtime_R1 > 0) && (incubtime_R1 < 30)) || (noofdips_R1 > 0))
                    {
                        r1priority = 1;
                    }
                    else
                    {
                        r1priority = 0;
                    }
                }
               
            }
            else
            {
                MessageBox.Show("Please select the Valid Protocol to perform the task", "H & E Communication Test App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return sndcmdstr;
            }
            DataRow[] resut = JPos.Select("JarNo ='" + JName + "'");
            if (resut.Length > 0)
            {
                //x1Pos, y1Pos, z1Pos, z2Pos
                JarName = resut[0]["JarNo"].ToString();
                x1Pos = resut[0]["X-Axis"].ToString();
                y1Pos = resut[0]["Y-Axis"].ToString();
                z1Pos = resut[0]["Z1-Axis"].ToString();
                z2Pos = resut[0]["Z2-Axis"].ToString();
                sndcmdstr = "";
                //sndcmdstr = x1Pos + "," + y1Pos + "," + z1Pos + "," + z2Pos + "," + pickplace.ToString();
                sndcmdstr = x1Pos + "," + y1Pos + ",0";
            }

            //New code updated on 26072024 1530 as suggested by kamal sir
            /* Has to check with machine after implementing the washjar and code in device*/
            if ((JarName == "W1") || (JarName == "W2") || (JarName == "W3") || (JarName == "W4") || (JarName == "W5") || (JarName == "W6"))
            {
                string rkname = "";
                //rkname = getwashdetails(JarName);
                rkname = JarName;
                DataRow[] rslt = JPos.Select("JarNo = '" + rkname + "'");
                if (rslt.Length > 0)
                {
                    //x1Pos, y1Pos, z1Pos, z2Pos
                    JarName = rslt[0]["JarNo"].ToString();
                    x1Pos = resut[0]["X-Axis"].ToString();
                    y1Pos = resut[0]["Y-Axis"].ToString();
                    z1Pos = resut[0]["Z1-Axis"].ToString();
                    z2Pos = resut[0]["Z2-Axis"].ToString();
                    sndcmdstr = "";
                    //sndcmdstr = x1Pos + "," + y1Pos + "," + z1Pos + "," + z2Pos + "," + pickplace.ToString();
                    //sndcmdstr = x1Pos + "," + y1Pos + ",0";
                    sndcmdstr = x1Pos + "," + y1Pos + "," + z1Pos;
                }
            }
            //New code updated on 26072024 1530 as suggested by kamal sir


            R1_xPos = x1Pos; R1_yPos = y1Pos; R1_z1Pos = z1Pos; R1_z2Pos = z2Pos;
            JarName_R1 = JarName;
            //Updating Water Jar details
            if (JarName.Contains("W"))
            {
                r1_incub_WOn_flg = false;
                r1_incub_Woff_flg = false;
            }            
            //New code written on 13122023 1443 to start the water pump
            if((incubtime_R1 < 18) && (Next_JarName_R1.Contains("W")))
            {
                r1_incub_WOn_flg = true;
                watervalveonpff(Next_JarName_R1, 1);
                System.Threading.Thread.Sleep(500);
            }
            return sndcmdstr;
        }
 
 private string get_R2_positiondetails()
        {
            string JName = "", sndcmdstr = "";
            try
            {
                #region prev & next rack
                //New code added on 12-12-2023 to get the previous & next jar name to ON & OFF the water pump
                if (r2inx == 0)
                {
                    Prev_JarName_R2 = "";
                    DataRow[] prs1 = R2Protorun.Select("SlNo =" + (r2inx + 2));
                    if (prs1.Length > 0)
                    {
                        Next_JarName_R2 = prs1[0]["JarNo"].ToString();
                    }
                    else
                        Next_JarName_R2 = "";
                }
                else if (r2inx > 0)
                {
                    DataRow[] prs2 = R2Protorun.Select("SlNo =" + (r1inx));
                    if (prs2.Length > 0)
                    {
                        Prev_JarName_R2 = prs2[0]["JarNo"].ToString();
                    }
                    else
                        Prev_JarName_R2 = "";

                    if ((r2inx + 2) <= R2Protorun.Rows.Count)
                    {
                        DataRow[] prs3 = R1Protorun.Select("SlNo =" + (r2inx + 2));
                        if (prs3.Length > 0)
                        {
                            Next_JarName_R2 = prs3[0]["JarNo"].ToString();
                        }
                        else
                            Next_JarName_R2 = "";
                    }
                }
                //New code added on 12-12-2023 to get the values of water pump/ valve
                #endregion


                //Taking detail protocol table  
                DataRow[] protoresult = R2Protorun.Select("SlNo =" + (r2inx + 1));
                if (protoresult.Length > 0)
                {
                    JName = protoresult[0]["JarNo"].ToString();
                    RegName_R2 = protoresult[0]["RegName"].ToString();
                    ShortRegName_R2 = protoresult[0]["RegName"].ToString();
                    incubtime_R2 = Convert.ToInt32(protoresult[0]["Incubtime"].ToString());
                    noofdips_R2 = Convert.ToInt32(protoresult[0]["Dips"].ToString());
                    if (noofdips_R2 > 0)
                    {
                        R2_dipdelay = 1;
                        R2_drydelay = 1;
                    }
                    //Priority code added on 15-11-2023 to reduce the time delay for next rack or to stop colliding
                    if (JName.Contains("U"))
                        r2priority = 0;
                    else
                    {
                        if (((incubtime_R2 > 0) && (incubtime_R2 < 30)) || (noofdips_R2 > 0))
                        {
                            r2priority = 1;
                        }
                        else
                        {
                            r2priority = 0;
                        }
                    }
                        
                }
                else
                {
                    MessageBox.Show("Please select the Valid Protocol to perform the task", "H & E Communication Test App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return sndcmdstr;
                }
                DataRow[] resut = JPos.Select("JarNo ='" + JName + "'");
                if (resut.Length > 0)
                {
                    //x1Pos, y1Pos, z1Pos, z2Pos
                    JarName = resut[0]["JarNo"].ToString();
                    x1Pos = resut[0]["X-Axis"].ToString();
                    y1Pos = resut[0]["Y-Axis"].ToString();
                    z1Pos = resut[0]["Z1-Axis"].ToString();
                    z2Pos = resut[0]["Z2-Axis"].ToString();
                    sndcmdstr = "";
                    //sndcmdstr = x1Pos + "," + y1Pos + "," + z1Pos + "," + z2Pos + "," + pickplace.ToString();
                    sndcmdstr = x1Pos + "," + y1Pos + ",0";
                }

                //New code updated on 26072024 1530 as suggested by kamal sir
                /* Has to check with machine after implementing the washjar and code in device*/
                if ((JarName == "W1") || (JarName == "W2") || (JarName == "W3") || (JarName == "W4") || (JarName == "W5") || (JarName == "W6"))
                {
                    string rkname = "";
                    //rkname = getwashdetails(JarName);
                    rkname = JarName;
                    DataRow[] rslt = JPos.Select("JarNo = '" + rkname + "'");
                    if (rslt.Length > 0)
                    {
                        //x1Pos, y1Pos, z1Pos, z2Pos
                        JarName = rslt[0]["JarNo"].ToString();
                        x1Pos = resut[0]["X-Axis"].ToString();
                        y1Pos = resut[0]["Y-Axis"].ToString();
                        z1Pos = resut[0]["Z1-Axis"].ToString();
                        z2Pos = resut[0]["Z2-Axis"].ToString();
                        sndcmdstr = "";
                        //sndcmdstr = x1Pos + "," + y1Pos + "," + z1Pos + "," + z2Pos + "," + pickplace.ToString();
                        //sndcmdstr = x1Pos + "," + y1Pos + ",0";
                        sndcmdstr = x1Pos + "," + y1Pos + "," + z1Pos;
                    }
                }
                //New code updated on 26072024 1530 as suggested by kamal sir

                R2_xPos = x1Pos; R2_yPos = y1Pos; R2_z1Pos = z1Pos; R2_z2Pos = z2Pos;
                JarName_R2 = JarName;
                //Updating Water Jar details
                if (JarName.Contains("W"))
                {
                    r2_incub_WOn_flg = false;
                    r2_incub_Woff_flg = false;
                }
                //New code written on 13122023 1443 to start the water pump
                if ((incubtime_R2 < 18) && (Next_JarName_R2.Contains("W")))
                {
                    r2_incub_WOn_flg = true;
                    watervalveonpff(Next_JarName_R2, 1);
                    System.Threading.Thread.Sleep(500);
                }
                return sndcmdstr;
            }
            catch (Exception d3)
            {
                return sndcmdstr;
            }
        }
	
	private string get_R3_positiondetails()
        {

            #region prev & next rack
            //New code added on 12-12-2023 to get the previous & next jar name to ON & OFF the water pump
            if (r3inx == 0)
            {
                Prev_JarName_R3 = "";
                DataRow[] prs1 = R3Protorun.Select("SlNo =" + (r3inx + 2));
                if (prs1.Length > 0)
                {
                    Next_JarName_R3 = prs1[0]["JarNo"].ToString();
                }
                else
                    Next_JarName_R3 = "";
            }
            else if (r3inx > 0)
            {
                DataRow[] prs2 = R3Protorun.Select("SlNo =" + (r3inx));
                if (prs2.Length > 0)
                {
                    Prev_JarName_R3 = prs2[0]["JarNo"].ToString();
                }
                else
                    Prev_JarName_R3 = "";

                if ((r3inx + 2) <= R3Protorun.Rows.Count)
                {
                    DataRow[] prs3 = R3Protorun.Select("SlNo =" + (r3inx + 2));
                    if (prs3.Length > 0)
                    {
                        Next_JarName_R3 = prs3[0]["JarNo"].ToString();
                    }
                    else
                        Next_JarName_R3 = "";
                }
            }
            //New code added on 12-12-2023 to get the values of water pump/ valve
            #endregion

            //Taking detail protocol table
            string JName = "", sndcmdstr = "";
            DataRow[] protoresult = R3Protorun.Select("SlNo =" + (r3inx + 1));
            if (protoresult.Length > 0)
            {
                JName = protoresult[0]["JarNo"].ToString();
                RegName_R3 = protoresult[0]["RegName"].ToString();
                ShortRegName_R3 = protoresult[0]["RegName"].ToString();
                incubtime_R3 = Convert.ToInt32(protoresult[0]["Incubtime"].ToString());
                noofdips_R3 = Convert.ToInt32(protoresult[0]["Dips"].ToString());
                if (noofdips_R3 > 0)
                {
                    R3_dipdelay = 1;
                    R3_drydelay = 1;
                }
                //Priority code added on 15-11-2023 to reduce the time delay for next rack or to stop colliding
                if (JName.Contains("U"))
                    r3priority = 0;
                else
                {
                    if (((incubtime_R3 > 0) && (incubtime_R3 < 30)) || (noofdips_R3 > 0))
                    {
                        r3priority = 1;
                    }
                    else
                    {
                        r3priority = 0;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select the Valid Protocol to perform the task", "H & E Communication Test App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return sndcmdstr;
            }
            DataRow[] resut = JPos.Select("JarNo ='" + JName + "'");
            if (resut.Length > 0)
            {
                //x1Pos, y1Pos, z1Pos, z2Pos
                JarName = resut[0]["JarNo"].ToString();
                x1Pos = resut[0]["X-Axis"].ToString();
                y1Pos = resut[0]["Y-Axis"].ToString();
                z1Pos = resut[0]["Z1-Axis"].ToString();
                z2Pos = resut[0]["Z2-Axis"].ToString();
                sndcmdstr = "";
                //sndcmdstr = x1Pos + "," + y1Pos + "," + z1Pos + "," + z2Pos + "," + pickplace.ToString();
                sndcmdstr = x1Pos + "," + y1Pos + ",0";
            }

            //New code updated on 26072024 1530 as suggested by kamal sir
            /* Has to check with machine after implementing the washjar and code in device*/
            if ((JarName == "W1") || (JarName == "W2") || (JarName == "W3") || (JarName == "W4") || (JarName == "W5") || (JarName == "W6"))
            {
                string rkname = "";
                rkname = JarName;
                DataRow[] rslt = JPos.Select("JarNo = '" + rkname + "'");
                if (rslt.Length > 0)
                {
                    //x1Pos, y1Pos, z1Pos, z2Pos
                    JarName = rslt[0]["JarNo"].ToString();
                    x1Pos = resut[0]["X-Axis"].ToString();
                    y1Pos = resut[0]["Y-Axis"].ToString();
                    z1Pos = resut[0]["Z1-Axis"].ToString();
                    z2Pos = resut[0]["Z2-Axis"].ToString();
                    sndcmdstr = "";
                    //sndcmdstr = x1Pos + "," + y1Pos + "," + z1Pos + "," + z2Pos + "," + pickplace.ToString();
                    //sndcmdstr = x1Pos + "," + y1Pos + ",0";
                    sndcmdstr = x1Pos + "," + y1Pos + "," + z1Pos;
                }
            }
            //New code updated on 26072024 1530 as suggested by kamal sir

            R3_xPos = x1Pos; R3_yPos = y1Pos; R3_z1Pos = z1Pos; R3_z2Pos = z2Pos;
            JarName_R3 = JarName;

            //Updating Water Jar details
            if (JarName.Contains("W"))
            {
                r3_incub_WOn_flg = false;
                r3_incub_Woff_flg = false;
            }
            //New code written on 13122023 1443 to start the water pump
            if ((incubtime_R3 < 18) && (Next_JarName_R3.Contains("W")))
            {
                r3_incub_WOn_flg = true;
                watervalveonpff(Next_JarName_R3, 1);
                System.Threading.Thread.Sleep(500);
            }

            return sndcmdstr;
        }
		
		private void move_ra_tolocation(int rackno)
        {
            string sndstr = "";
            CommandName = "";
            Communication.RA_No = 1;
            CommandName = "RA Movement for Rack - ";
            if (rackno == 1)
            {
                sndstr = R1_xPos + ","+ R1_yPos + "," + R1_z1Pos;
                R1_pickcmdissue = true;
                CommandName = CommandName + R1_cnt.ToString() + " to " + JarName_R1;
            }
            else if (rackno == 2)
            {
                sndstr = R2_xPos + "," + R2_yPos + "," + R2_z1Pos;
                R2_pickcmdissue = true;
                CommandName = CommandName + R2_cnt.ToString() + " to " + JarName_R2;
            }
            else if (rackno == 3)
            {
                sndstr = R3_xPos + "," + R3_yPos + "," + R3_z1Pos;
                R3_pickcmdissue = true;
                CommandName = CommandName + R3_cnt.ToString() + " to " + JarName_R3;
            }
            else if (rackno == 4)
            {
                sndstr = R4_xPos + "," + R4_yPos + "," + R4_z1Pos;
                R4_pickcmdissue = true;
                CommandName = CommandName + R4_cnt.ToString() + " to " + JarName_R4;
            }
            else if (rackno == 5)
            {
                sndstr = R5_xPos + "," + R5_yPos + "," + R5_z1Pos;
                R5_pickcmdissue = true;
                CommandName = CommandName + R5_cnt.ToString() + " to " + JarName_R5;
            }
            else if (rackno == 6)
            {
                sndstr = R6_xPos + "," + R6_yPos + "," + R6_z1Pos;
                R6_pickcmdissue = true;
                CommandName = CommandName + R6_cnt.ToString() + " to " + JarName_R6;
            }

            rareached = false;
            RA_Move_Intiate = true;
            //sending move command to RA
            snd_rcvCmd(Communication.RA_MOVE, sndstr);
            if (rackno == 1)
            {
                r1_WaitCnt = 0;
            }
            else if (rackno == 2)
            {
                r2_WaitCnt = 0;
            }
            else if (rackno == 3)
            {
                r3_WaitCnt = 0;
            }
            else if (rackno == 4)
            {
                r4_WaitCnt = 0;
            }
            else if (rackno == 5)
            {
                r5_WaitCnt = 0;
            }
            else if (rackno == 6)
            {
                r6_WaitCnt = 0;
            }
            tmr_Cut.Enabled = true;
            tmr_Cut.Interval = 500;
        }