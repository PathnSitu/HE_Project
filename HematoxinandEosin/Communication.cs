using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Collections;
using System.Collections.Concurrent;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace HematoxinandEosin
{
    public class Communication
    {        
        //Communication Ports Details
        public static string portname = null;
        public static string baudrate = null;
        public static Boolean portopened = false;
        public static Boolean connectionMode = false;

        public static Boolean RA_Reached = false;

        public static Boolean RA_HomeCmdIssued = false;
        public static Boolean RA_MoveCmdIssued = false;
        public static Boolean RA_CutCmdIssued = false;
        public static Boolean RA_EjectCmdIssued = false;

        //Required variables
        private static int receivecount = 0;
        private string btntst = null;
        private Boolean ackok = false;
        public static string responsedata = "";
        public static int[] dev_id = new int[256];
        public static string resultvalue = "";

        //Added on 21-12-2020 1754
        public static string Command_Name = string.Empty;
        public static string Communicate_Mode = string.Empty;

        //Arraning the commands the with sequence manner 

        public static int RA_MOVE = 1;
        public static int RA_PICK = 2;
        public static int RA_PLACE = 3;
        public static int LEVEL_SENSE = 4;
        public static int RA_HOME = 5;
        public static int HOME_STATUS = 6;

        public static int RACK_HOLD = 7;
        public static int DOOR_CTRL = 8;
        public static int DOOR_STATUS = 9;
        public static int SET_TEMP = 10;
        public static int GET_TEMP = 11;
        public static int HTR_CTRL = 12;
        public static int VALVE_CTRL = 13;
        public static int VALVE_STATUS = 14;
        public static int POLL_VER = 15;
        public static int AGITATION = 16;
        public static int RA_DIP = 17;

        //COMMAND CHARACTERS
        public const uint ST = 35;
        public const uint ED = 33;

        //SERIAL PORT DECLARATION
        public static SerialPort mport = new SerialPort();

        //SEQNO
        public static int SequnceNo = 0;

        //DEVICE ID
        int device_id = 0;
        public static int devid = 1;
        public static int RA_No = 0;  //Previously 1
        //Data related flags
        public static Boolean pGotByteFlag, pCancelFlag, datastartreceivingflag = true;
        public static byte[] Device_Data = new byte[8];
        public static byte[] Device_Errdata = new byte[2];
        public static byte[] Device_Ack = new byte[1];
        public static byte[] Device_Exectionflag = new byte[1];

        public static Boolean Continue_Process = false;  //Added on 05-05-2022
        public static Boolean Img_Uploading = false;  //Added on 13-05-2022

        //Power mode
        public static int pwrmode;

        public static string compotnumber;
        public static int repeatval = 0;
        public static string framed_cmd = "", framed_Pollcmd = "", framed_Data = "";
        private static int sent_func_code = 0;
        public static void frame_command(int func_code, string cmdData, int RANo, string cmdstr)
        {
            string cmd_sep = ",", pktdata = "", str1 = "", crcstr = "", st = "";
            int ln = 0, ln1 = 0, frm_len1 = 0, frm_len2 = 0, crval = 0;
            byte[] cmdpkt = new byte[100];

            //Framing the command
            if (SequnceNo > 255)
                SequnceNo = 0;

            cmdstr = "";
            if (string.IsNullOrEmpty(cmdData))
            {
                cmdstr = SequnceNo.ToString() + cmd_sep + func_code.ToString();
            }
            else
            {
                ////if (RANo == 0)
                ////{
                ////    cmdstr = SequnceNo.ToString() + cmd_sep + func_code.ToString() + cmd_sep + cmdData;
                ////}
                ////else if ((RANo == 1) || (RANo == 2))
                ////{
                ////    cmdstr = SequnceNo.ToString() + cmd_sep + func_code.ToString() + cmd_sep + RANo.ToString() + cmd_sep + cmdData;
                ////}
                if ((func_code == 1) || (func_code == 2) || (func_code == 3) || (func_code == 17) || (func_code == 20))
                {
                    cmdstr = SequnceNo.ToString() + cmd_sep + func_code.ToString() + cmd_sep + RANo.ToString() + cmd_sep + cmdData;
                }
                else
                {
                    cmdstr = SequnceNo.ToString() + cmd_sep + func_code.ToString() + cmd_sep + cmdData;
                }
            }

            str1 = "";
            str1 = cmdstr;
            cmdstr = cmdstr + "  ";
            cmdpkt = new byte[cmdstr.Length];
            cmdpkt = Encoding.Default.GetBytes(cmdstr);
            int l = Communication.CRC_Calculation(cmdpkt, 1);
            if (l == 0)
            {
                pktdata = "";
                pktdata = Encoding.Default.GetString(cmdpkt);

                cmdstr = "";
                cmdstr = pktdata.Substring(0, pktdata.Length - 2);
                cmdstr = cmdstr + "*";

                //MSB Bit
                crcstr = "";
                crval = 0;
                crval = cmdpkt[cmdpkt.Length - 2];
                st = "";
                st = crval.ToString("X");
                if (st.Length < 2)
                    st = "0" + st;
                crcstr = crcstr + st;

                //LSB Bit
                crval = 0;
                crval = cmdpkt[cmdpkt.Length - 1];
                st = "";
                st = crval.ToString("X");
                if (st.Length < 2)
                    st = "0" + st;
                crcstr = crcstr + st;

                crcstr = crcstr.Replace("A", "a");
                crcstr = crcstr.Replace("B", "b");
                crcstr = crcstr.Replace("C", "c");
                crcstr = crcstr.Replace("D", "d");
                crcstr = crcstr.Replace("E", "e");
                crcstr = crcstr.Replace("F", "f");

                cmdstr = "#" + cmdstr + crcstr + "\n";
                ////commandQueue.Enqueue(cmdstr); //Added for testing on 18-11-2024 1247
            }
            else
            {
                MessageBox.Show("CRC Mismatched", "CRC Calculation Command Frameing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            framed_cmd = cmdstr;

        }
        public static Queue<string> commandQueue = new Queue<string>();//to hold commands
        public static Boolean isComandInProgress = false;
        public static int CRC_Calculation(byte[] RX_TX_BUFFER, int type)
        {
            /**********************************************************************************************/
            /* CRC Calculation is made on data from Slave Address to Last Byte of Data Excluding CRC Bytes*/
            /* Initiall Fill CRC Register with 0xFFFF						      */
            /* EXOR hte received data with this Register. Check LSB					      */
            /* If LSB is Zero Right Shift Data by One Bit and Continue For Eight Bits		      */
            /* If LSB is One, EXOR the Right Shifted Data With 0xA001				      */
            /* Continue This For remaing Bits 							      */
            /* Continue above procedure for all data bytes.						      */
            /**********************************************************************************************/
            uint CRC_Reg;
            int val = 0;
            //unsigned int RX_TX_INDEX;
            uint mod_count1;
            uint Mod_Temp, mod_count;
            //double mod_count;
            //unsigned char RX_TX_BUFFER[200];
            byte[] rsppkt = new byte[255];
            int i, j, ln;
            CRC_Reg = 0xFFFF;
            if (type == 1)
                ln = RX_TX_BUFFER.Length - 2;
            else if (type == 2)
                ln = RX_TX_BUFFER.Length - 5;
            if (type == 1)
            {
                for (mod_count1 = 0; mod_count1 < RX_TX_BUFFER.Length - 2; mod_count1++)
                {
                    CRC_Reg ^= RX_TX_BUFFER[mod_count1];
                    for (mod_count = 0; mod_count < 8; mod_count++)
                    {
                        Mod_Temp = CRC_Reg & 0x0001;
                        CRC_Reg = CRC_Reg >> 1;
                        if (Mod_Temp == 0)
                            continue;
                        else
                            CRC_Reg ^= 0xA001;
                    }
                }
            }
            else if (type == 2)
            {
                for (mod_count1 = 0; mod_count1 < RX_TX_BUFFER.Length - 5; mod_count1++)
                {
                    CRC_Reg ^= RX_TX_BUFFER[mod_count1];
                    for (mod_count = 0; mod_count < 8; mod_count++)
                    {
                        Mod_Temp = CRC_Reg & 0x0001;
                        CRC_Reg = CRC_Reg >> 1;
                        if (Mod_Temp == 0)
                            continue;
                        else
                            CRC_Reg ^= 0xA001;
                    }
                }
            }


            Mod_Temp = CRC_Reg & 0xFF;
            mod_count = (CRC_Reg & 0xFF00) >> 8;

            if (type == 1)
            {
                RX_TX_BUFFER[RX_TX_BUFFER.Length - 2] = (byte)mod_count;
                RX_TX_BUFFER[RX_TX_BUFFER.Length - 1] = (byte)Mod_Temp;
                val = 0;
            }
            else if (type == 2)
            {
                //MSB Bit
                string crcstr = "";
                int crval = 0;
                crval = (byte)mod_count;
                string st = "";
                st = crval.ToString("X");
                if (st.Length < 2)
                    st = "0" + st;
                crcstr = crcstr + st;

                //LSB Bit
                crval = 0;
                crval = (byte)Mod_Temp;
                st = "";
                st = crval.ToString("X");
                if (st.Length < 2)
                    st = "0" + st;
                crcstr = crcstr + st;

                crcstr = crcstr.Replace("A", "a");
                crcstr = crcstr.Replace("B", "b");
                crcstr = crcstr.Replace("C", "c");
                crcstr = crcstr.Replace("D", "d");
                crcstr = crcstr.Replace("E", "e");
                crcstr = crcstr.Replace("F", "f");

                rsppkt = new byte[crcstr.Length];
                rsppkt = Encoding.Default.GetBytes(crcstr);


                if ((RX_TX_BUFFER[RX_TX_BUFFER.Length - 4] == rsppkt[0]) && (RX_TX_BUFFER[RX_TX_BUFFER.Length - 3] == rsppkt[1]) && (RX_TX_BUFFER[RX_TX_BUFFER.Length - 2] == rsppkt[2]) && (RX_TX_BUFFER[RX_TX_BUFFER.Length - 1] == rsppkt[3]))
                    val = 0;
                else
                    val = 1;

            }
            return val;
        }

        //Delay function writtng
        public static void delay(DateTime DelayTime)
        {
            try
            {
                DateTime dltime = System.DateTime.Now;
                while (dltime < DelayTime)
                {
                    dltime = System.DateTime.Now;
                    if (pGotByteFlag == true)
                        break;
                    if (pCancelFlag == true)
                        break;
                }
            }
            catch (Exception e3)
            {

            }
        }
        /*
         * If Engineering mode parameters are setting then the name in communicationmode will be "CHE_ENG"  ENG menas engineering parameters
         * If Calibration mode parameters are setting then the name in communicationmode will be "CHE_CAL"  ÇAL means calibration parameters
         * If protocol test is running then the name in communicationmode will be "CHE_PTR" PTR means protocol test run 
         */

        public static void writeCommunicationCommands(string communicationmode)
        {
            try
            {
                string source = Application.StartupPath + "\\Data\\Communication", filename = string.Empty;
                //source = source + "\\" + communicationmode;  //Commented On 27-05-2022 12:25
                //Creating directory                
                if (Directory.Exists(source))
                {

                }
                else
                {
                    Directory.CreateDirectory(source);
                }

                string dt = "";
                dt = DateTime.Now.Day.ToString().Length < 2 ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString();
                filename = "CmdLog_" + dt;
                dt = DateTime.Now.Month.ToString().Length < 2 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString();
                filename = filename + dt + DateTime.Now.Year.ToString() + ".Log";

                //source = string.Empty;
                //source = Application.StartupPath + "\\Logfile\\Commlog_" + filename;
                //source = source + "\\Logfile\\" + communicationmode + "\\" + filename;  /* this line commented on 23-12-2020 1049 */
                source = source + "\\" + filename;
                System.IO.FileStream fs = default(System.IO.FileStream);
                if (File.Exists(source))
                {
                    fs = new System.IO.FileStream(source, System.IO.FileMode.Append, System.IO.FileAccess.Write);
                }
                else
                {
                    fs = new System.IO.FileStream(source, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                }
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);
                //sw.WriteLine("--------------------------------------------------------------------------");
                //sw.WriteLine(exceptionstring + "," + System.DateTime.Now);                
                sw.WriteLine(communicationmode + " * " + System.DateTime.Now.ToString() + "." + System.DateTime.Now.Millisecond.ToString());
                //sw.WriteLine("--------------------------------------------------------------------------");
                sw.Flush();
                sw.Close();
            }
            catch (Exception d3)
            {

            }           
        }

        /* New function written on 18-12-2023 1127 to update the protorundata to datafile */
        public static void writeprotorundata(string protoname, string prefby, string prefon, string jname, string rname, string rackno, string arrv, string month, string status, float tempval, int runid)
        {
            try
            {
                string source = Application.StartupPath + "\\Data\\protorun", filename = string.Empty;                
                //Creating directory                
                if (Directory.Exists(source))
                {

                }
                else
                {
                    Directory.CreateDirectory(source);
                }

                string dt = "";
                dt = DateTime.Now.Day.ToString().Length < 2 ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString();
                filename = "RunLog_" + dt;
                dt = DateTime.Now.Month.ToString().Length < 2 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString();
                filename = filename + dt + DateTime.Now.Year.ToString() + ".log";

                //source = string.Empty;
                //source = Application.StartupPath + "\\Logfile\\Commlog_" + filename;
                //source = source + "\\Logfile\\" + communicationmode + "\\" + filename;  /* this line commented on 23-12-2020 1049 */
                source = source + "\\" + filename;
                System.IO.FileStream fs = default(System.IO.FileStream);
                if (File.Exists(source))
                {
                    fs = new System.IO.FileStream(source, System.IO.FileMode.Append, System.IO.FileAccess.Write);
                }
                else
                {
                    fs = new System.IO.FileStream(source, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                }
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);
                string strdata = "";
                strdata = protoname + "," + prefby + "," + prefon + "," + jname + "," + rname + "," + rackno + "," + tempval + "," + arrv + "," + month + "," + status + "," + runid.ToString();
                sw.WriteLine(strdata);
                sw.Flush();
                sw.Close();
            }
            catch (Exception d3)
            {
                RequiredVariables.writeerrorlogfile("While updating protorundata to file", "In function writeprotorundata of communication module");
            }
        }
        /* New function written on 18-12-2023 1127 to update the protorundata to datafile */
        public static void writeCommunicationlog(string exceptionstring, string communicationmode)
        {
            try
            {
                string source = Application.StartupPath + "\\Data\\Communication", filename = string.Empty;
                //source = source + "\\" + communicationmode;  //Commented On 27-05-2022 12:25
                //Creating directory                
                if (Directory.Exists(source))
                {

                }
                else
                {
                    Directory.CreateDirectory(source);
                }

                string dt = "";
                dt = DateTime.Now.Day.ToString().Length < 2 ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString();
                filename = "" + dt;
                dt = DateTime.Now.Month.ToString().Length < 2 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString();
                filename = filename + dt + DateTime.Now.Year.ToString() + ".Log";

                //source = string.Empty;
                //source = Application.StartupPath + "\\Logfile\\Commlog_" + filename;
                //source = source + "\\Logfile\\" + communicationmode + "\\" + filename;  /* this line commented on 23-12-2020 1049 */
                source = source + "\\" + filename;
                System.IO.FileStream fs = default(System.IO.FileStream);
                if (File.Exists(source))
                {
                    fs = new System.IO.FileStream(source, System.IO.FileMode.Append, System.IO.FileAccess.Write);
                }
                else
                {
                    fs = new System.IO.FileStream(source, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                }
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);
                //sw.WriteLine("--------------------------------------------------------------------------");
                //sw.WriteLine(exceptionstring + "," + System.DateTime.Now);
                sw.WriteLine(communicationmode + "," + System.DateTime.Now.ToString() + "." + System.DateTime.Now.Millisecond.ToString());
                //sw.WriteLine("--------------------------------------------------------------------------");
                sw.Flush();
                sw.Close();
            }
            catch (Exception d3)
            {

            }
        }

        public static void writeCommunicationErrorlog(string exceptionstring)
        {
            string source = Application.StartupPath + "\\Logfile\\Communication", filename = string.Empty;

            //Creating directory                
            if (Directory.Exists(source))
            {

            }
            else
            {
                Directory.CreateDirectory(source);
            }

            string dt = "";
            dt = DateTime.Now.Day.ToString().Length < 2 ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString();
            filename = "" + dt;
            dt = DateTime.Now.Month.ToString().Length < 2 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString();
            filename = filename + dt + DateTime.Now.Year.ToString() + ".Log";
            source = string.Empty;
            source = Application.StartupPath + "\\Logfile\\Communication\\CommErrorlog_" + filename;

            System.IO.FileStream fs = default(System.IO.FileStream);
            if (File.Exists(source))
            {
                fs = new System.IO.FileStream(source, System.IO.FileMode.Append, System.IO.FileAccess.Write);
            }
            else
            {
                fs = new System.IO.FileStream(source, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            }
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);
            sw.WriteLine("--------------------------------------------------------------------------");
            sw.WriteLine(exceptionstring + "," + System.DateTime.Now);
            sw.WriteLine("--------------------------------------------------------------------------");
            sw.Flush();
            sw.Close();
        }

        public static int convertdatastr(string actualstring, ref string convertedstring, ref byte b1, ref byte b2)
        {
            double dd1 = 0.0, dd2 = 0.0;

            int bd1 = 0, bd2 = 0, pos;

            string datastr = "";

            datastr = "";
            pos = (actualstring).IndexOf(".");
            if (pos > 0)
            {
                datastr = (actualstring).Substring(0, pos);
                dd1 = Convert.ToDouble(datastr);
                datastr = "";
                datastr = (actualstring).Substring(pos + 1, 2);
                dd2 = Convert.ToDouble(datastr);
                if (dd2 >= 50.0)
                {
                    dd1 += 1;
                }
            }
            else
            {
                dd1 = Convert.ToDouble(actualstring);
            }

            pos = (int)dd1;
            datastr = pos.ToString("X");

            for (int h = datastr.Length; h < 4; h++)
                datastr = "0" + datastr;

            if ((datastr.Length > 4) && (datastr.Length == 8))
                convertedstring = datastr.Substring(4, 4);
            else
                convertedstring = datastr;

            bd1 = Convert.ToInt32((convertedstring.Substring(0, 2).ToString().Trim()), 16);
            bd2 = Convert.ToInt32((convertedstring.Substring(2, 2).ToString().Trim()), 16);

            b1 = (byte)bd1;
            b2 = (byte)bd2;

            return 0;

        }

       

    }
}
