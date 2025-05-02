using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO.Ports;
using System.IO;
using System.Management;

namespace HematoxinandEosin
{
    public partial class Enginering_Mode : Form
    {
        //string FilePath = Path.Combine(@"G:\projects\mukesh\CalibLog\Eng", DateTime.Today.ToString("dd/MM/yyyy") + ".csv");
        // string data = File.ReadAllText(FilePath);
        // string withHeader = "Parametername, Status, Time," ;
        //string Constr = "Data Source=SYSPSENG006;User ID=sa;Password=sree@pns2013;Initial Catalog=PNSHE;Pooling=false;Max Pool Size=400;workstation id =SYSPSENG006";
        string Constr = "";//"Data Source=" + Environment.MachineName.ToString() + ";User ID=sa;Password=sree@pns2013;Initial Catalog=PNSHE;Pooling=false;Max Pool Size=400;workstation id = " + Environment.MachineName.ToString();  //Stand alone machine - ID
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        // DataTable table = new DataTable("table");
        SqlDataAdapter sda = new SqlDataAdapter();
        string status;
        string sqlstr;
        public Enginering_Mode()
        {
            InitializeComponent();
        }

        private void Enginering_Mode_Load(object sender, EventArgs e)
        {
            Constr = RequiredVariables.DBConnStr;
            loadPositiondetails();
        }

       private void btn_close_Click(object sender, EventArgs e)
        {
            RequiredVariables.EngineeringMode_Started = false;
            if (con.State == ConnectionState.Open)
                con.Close();            
            if (mport.IsOpen)
                mport.Close();
            tmr_portstatus.Enabled = false;
            tmr_portstatus.Stop();
            this.Close();
        }

        private void rdn_robArm2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tg_Heater_Click(object sender, EventArgs e)
        {
            string onoffval = "0";
            Communication.RA_No = 0;
            intialize_all_loadingflags();
            if (tg_Heater.CapText == "OFF")
            {
                tg_Heater.CapText = "ON";
                tg_Heater.Checked = true;
                CommandName = "HEATER ON";                
                htr_on = true;
                htr_off = false;
                onoffval = "1";
            }
            else if (tg_Heater.CapText == "ON")
            {
                tg_Heater.CapText = "OFF";
                tg_Heater.Checked = false;
                CommandName = "HEATER OFF";
                htr_on = false;
                htr_off = true;
                onoffval = "0";
            }
            enggparameter = CommandName;
            snd_rcvCmd(Communication.HTR_CTRL, onoffval);
        }
        private void tg_HeaterFan_Click(object sender, EventArgs e)
        {
            string s = "Heater Fan";
            sqlstr = "";
            sqlstr = "Insert into EngineeringMode(EngModeParameterName,CalibratedBy,TestedOn,Status,ChangedTime,Month) values('";
            sqlstr = sqlstr + s + "','" + RequiredVariables.UserName + "','";
            //String s = DateTime.Now.ToString("dd-MM-yyyy");
            string s2 = DateTime.Now.ToString("dd-MM-yyyy");
            sqlstr = sqlstr + s2 + "','";
            // sqlstr= sqlstr + "'" + s + "','";
            // status = "";

            //if (tg_HeaterFan.Checked == true)
            //{
            //    tg_HeaterFan.CapText = "OFF";
            //    tg_HeaterFan.Checked = false;
            //    sqlstr = sqlstr + "OFF',";
            //    //status = "OFF";
            //    //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            //    //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
            //    //byte[] bdata = Encoding.Default.GetBytes("\n  Heaterfan,OFF," + s1);
            //    //fileStream.Write(bdata, 0, bdata.Length);
            //    //fileStream.Close();
            //}
            //else
            //{
            //    tg_HeaterFan.CapText = "ON";
            //    tg_HeaterFan.Checked = true;
            //    sqlstr = sqlstr + "ON',";
            //    //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            //    //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
            //    //byte[] bdata = Encoding.Default.GetBytes("\n  Heaterfan,ON," + s1);
            //    //fileStream.Write(bdata, 0, bdata.Length);
            //    //fileStream.Close();
            //}
            String s1 = DateTime.Now.ToString("HH:mm:ss");
            String m1 = DateTime.Now.ToString("MMMM");
            sqlstr = sqlstr + "'" + s1 + "','" + m1 + "')";
            cmd = new SqlCommand(sqlstr, con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();
        }
        private void tg_Inlet_pump_Click(object sender, EventArgs e)
        {
            string onoffval = "0";
            Communication.RA_No = 0;
            intialize_all_loadingflags();
            if (tg_Inlet_pump.CapText == "OFF")
            {
                tg_Inlet_pump.CapText = "ON";
                tg_Inlet_pump.Checked = true;
                CommandName = "WATER VALVE-1 CONTROL ON";
                valonflg = true;
                valoffflg = false;
                onoffval = "1,1";
            }
            else if (tg_Inlet_pump.CapText == "ON")
            {
                tg_Inlet_pump.CapText = "OFF";
                tg_Inlet_pump.Checked = false;
                CommandName = "WATER VALVE-1 CONTROL OFF";
                valonflg = false;
                valoffflg = true;
                onoffval = "1,0";
            }
            enggparameter = CommandName;
            snd_rcvCmd(Communication.VALVE_CTRL, onoffval);
        }
        private void tg_OutletPump_Click(object sender, EventArgs e)
        {
            string op = "Outlet Valve Pump";
            sqlstr = "";
            sqlstr = "Insert into EngineeringMode(EngModeParameterName,CalibratedBy,TestedOn,Status,ChangedTime,Month) values('";
            sqlstr = sqlstr + op + "','" + RequiredVariables.UserName + "','";
            String s = DateTime.Now.ToString("dd-MM-yyyy");
            sqlstr = sqlstr + s + "','";
            // sqlstr= sqlstr + "'" + s + "','";
            // status = "";
            //if (tg_OutletPump.Checked == true)
            //{
            //    tg_OutletPump.CapText = "OFF";
            //    tg_OutletPump.Checked = false;
            //    sqlstr = sqlstr + "OFF',";
            //    //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            //    //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
            //    //byte[] bdata = Encoding.Default.GetBytes("\n  Outlet Pump,OFF," + s1);
            //    //fileStream.Write(bdata, 0, bdata.Length);
            //    //fileStream.Close();
            //    lbl_MotorStatus.Text = "Motor Status : Outlet Pump is OFF";
            //}
            //else
            //{
            //    tg_OutletPump.CapText = "ON";
            //    tg_OutletPump.Checked = true;
            //    sqlstr = sqlstr + "ON',";
            //    //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            //    //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
            //    //byte[] bdata = Encoding.Default.GetBytes("\n  Outlet Pump,ON," + s1);
            //    //fileStream.Write(bdata, 0, bdata.Length);
            //    //fileStream.Close();
            //    lbl_MotorStatus.Text = "Motor Status : Outlet Pump is ON";
            //}

            String s1 = DateTime.Now.ToString("HH:mm:ss");
            String m1 = DateTime.Now.ToString("MMMM");
            sqlstr = sqlstr + "'" + s1 + "','" + m1 + "')";
            cmd = new SqlCommand(sqlstr, con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();
        }
        private void tg_HesitationMotor_Click(object sender, EventArgs e)
        {            
            try
            {
                string onoffval = "0";
                Communication.RA_No = 0;
                intialize_all_loadingflags();
                if (tg_HesitationMotor.CapText == "STOP")
                {
                    tg_HesitationMotor.CapText = "START";
                    tg_HesitationMotor.Checked = true;
                    CommandName = "START AGITATION";
                    StartHesitateflg = true;
                    StopHesitateflg = false;
                    onoffval = "1";
                }
                else if (tg_HesitationMotor.CapText == "START")
                {
                    tg_HesitationMotor.CapText = "STOP";
                    tg_HesitationMotor.Checked = false;
                    CommandName = "STOP AGITATION";
                    StartHesitateflg = false;
                    StopHesitateflg = true;
                    onoffval = "0";
                }
                enggparameter = CommandName;
                snd_rcvCmd(Communication.AGITATION, onoffval);
            }
            catch (Exception d3)
            {

            }
        }
        private void tg_HeaterDoor_Click(object sender, EventArgs e)
        {
            string hd = "Heater Door";
            sqlstr = "";
            sqlstr = "Insert into EngineeringMode(EngModeParameterName,CalibratedBy,TestedOn,Status,ChangedTime,Month) values('";
            sqlstr = sqlstr + hd + "','" + RequiredVariables.UserName + "','";
            String s = DateTime.Now.ToString("dd-MM-yyyy");
            sqlstr = sqlstr + s + "','";
            // sqlstr= sqlstr + "'" + s + "','";
            // status = "";
            if (tg_HeaterDoor.Checked == true)
            {
                tg_HeaterDoor.CapText = "CLOSE";
                tg_HeaterDoor.Checked = false;
                sqlstr = sqlstr + "CLOSE',";
                //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                //byte[] bdata = Encoding.Default.GetBytes("\n  HeaterDoor,Close," + s1);
                //fileStream.Write(bdata, 0, bdata.Length);
                //fileStream.Close();
                lbl_DoorStatus.Text = "Door Status : Heater Door is Closed";
            }
            else
            {
                tg_HeaterDoor.CapText = "OPEN";
                tg_HeaterDoor.Checked = true;
                sqlstr = sqlstr + "OPEN',";
                //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                //byte[] bdata = Encoding.Default.GetBytes("\n  HeaterDoor,Open," + s1);
                //fileStream.Write(bdata, 0, bdata.Length);
                //fileStream.Close();
                lbl_DoorStatus.Text = "Door Status : Heater Door is Opened";
            }

            String s1 = DateTime.Now.ToString("HH:mm:ss");
            String m1 = DateTime.Now.ToString("MMMM");
            sqlstr = sqlstr + "'" + s1 + "','" + m1 + "')";
            cmd = new SqlCommand(sqlstr, con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();

        }
        private void tg_JarDoor_Click(object sender, EventArgs e)
        {
            string jd = "Jar Door";
            sqlstr = "";
            sqlstr = "Insert into EngineeringMode(EngModeParameterName,CalibratedBy,TestedOn,Status,ChangedTime,Month) values('";
            sqlstr = sqlstr + jd + "','" + RequiredVariables.UserName + "','";
            String s = DateTime.Now.ToString("dd-MM-yyyy");
            sqlstr = sqlstr + s + "','";
            // sqlstr= sqlstr + "'" + s + "','";
            // status = "";
            if (tg_JarDoor.Checked == true)
            {
                tg_JarDoor.CapText = "CLOSE";
                tg_JarDoor.Checked = false;
                sqlstr = sqlstr + "CLOSE',";
                //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                //byte[] bdata = Encoding.Default.GetBytes("\n  JarDoor,Close," + s1);
                //fileStream.Write(bdata, 0, bdata.Length);
                //fileStream.Close();
                lbl_DoorStatus.Text = "Door Status : Jar Door is Closed";
            }
            else
            {
                tg_JarDoor.CapText = "OPEN";
                tg_JarDoor.Checked = true;
                sqlstr = sqlstr + "OPEN',";
                //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                //byte[] bdata = Encoding.Default.GetBytes("\n  JarDoor,Open," + s1);
                //fileStream.Write(bdata, 0, bdata.Length);
                //fileStream.Close();
                lbl_DoorStatus.Text = "Door Status : Jar Door is Opened";
            }

            String s1 = DateTime.Now.ToString("HH:mm:ss");
            String m1 = DateTime.Now.ToString("MMMM");
            sqlstr = sqlstr + "'" + s1 + "','" + m1 + "')";
            cmd = new SqlCommand(sqlstr, con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();
        }
        private void tg_MachineDoor_Click(object sender, EventArgs e)
        {
            string md = "Machine Door";
            sqlstr = "";
            sqlstr = "Insert into EngineeringMode(EngModeParameterName,CalibratedBy,TestedOn,Status,ChangedTime,Month) values('";
            sqlstr = sqlstr + md + "','" + RequiredVariables.UserName + "','";
            String s = DateTime.Now.ToString("dd-MM-yyyy");
            sqlstr = sqlstr + s + "','";
            // sqlstr= sqlstr + "'" + s + "','";
            // status = "";
            if (tg_MachineDoor.Checked == true)
            {
                tg_MachineDoor.CapText = "CLOSE";
                tg_MachineDoor.Checked = false;
                sqlstr = sqlstr + "CLOSE',";
                //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                //byte[] bdata = Encoding.Default.GetBytes("\n  MachineDoor,Close," + s1);
                //fileStream.Write(bdata, 0, bdata.Length);
                //fileStream.Close();
                lbl_DoorStatus.Text = "Door Status : Machine Door is Closed";
            }
            else
            {
                tg_MachineDoor.CapText = "OPEN";
                tg_MachineDoor.Checked = true;
                sqlstr = sqlstr + "OPEN',";
                //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                //byte[] bdata = Encoding.Default.GetBytes("\n  MachineDoor,Open," + s1);
                //fileStream.Write(bdata, 0, bdata.Length);
                //fileStream.Close();
                lbl_DoorStatus.Text = "Door Status : Machine Door is Opened";
            }

            String s1 = DateTime.Now.ToString("HH:mm:ss");
            String m1 = DateTime.Now.ToString("MMMM");
            sqlstr = sqlstr + "'" + s1 + "','" + m1 + "')";
            cmd = new SqlCommand(sqlstr, con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();
        }
        private void btn_close_Click_1(object sender, EventArgs e)
        {
            Form_MainMenu f1 = new Form_MainMenu();
            f1.btnBackground();
            this.Close();
            RequiredVariables.btnCalib = true;

        }
        private void tg_HeaterDoor_Load(object sender, EventArgs e)
        {

        }
        private void label28_Click(object sender, EventArgs e)
        {

        }
        private void panel_water_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Enginering_Mode_Load_1(object sender, EventArgs e)
        {
            Constr = RequiredVariables.DBConnStr;
            lst_resp.Items.Clear();
            loadPositiondetails();
            cmbTemp();
            con.ConnectionString = Constr;
            if (con.State == ConnectionState.Closed)
                con.Open();            
            opt_move.Checked = true;
            opt_close.Enabled = true;
            opt_htropen.Enabled = true;
            //Check the Port Available or not Available
            //// getavailableportnames();  //-- Commented on 13-12-2023 
            init_port();
            tmr_portstatus.Enabled = true;
            tmr_portstatus.Interval = 5000;
            System.Threading.Thread.Sleep(5000);
            doorstatusclicked = false;
            RequiredVariables.EngineeringMode_Started = true;
            getdoorstatus();
        }
        private void btn_Set_Click(object sender, EventArgs e)
        {
            CommandName = "SET TEMPERATURE";
            enggparameter = CommandName + " with value " + cmb_setTemperature.Text;
            Communication.RA_No = 0;
            snd_rcvCmd(Communication.SET_TEMP, cmb_setTemperature.Text);
        }
        private void btn_Read_Click(object sender, EventArgs e)
        {
            CommandName = "GET TEMPERATURE";
            enggparameter = CommandName;
            Communication.RA_No = 0;
            snd_rcvCmd(Communication.GET_TEMP, "");
        }
        private void roboticArmMovement()
        {

            if (opt_RA1.Checked == true)
            {
                String ra1 = "Robotic Arm-1";
                sqlstr = "";
                sqlstr = "Insert into EngineeringMode(EngModeParameterName,CalibratedBy,TestedOn,Status,ChangedTime,Month) values('";
                sqlstr = sqlstr + ra1 + "','" + RequiredVariables.UserName + "','";
                String s = DateTime.Now.ToString("dd-MM-yyyy");
                sqlstr = sqlstr + s + "','";
                // sqlstr= sqlstr + "'" + s + "','";
                // status = "";
                //////if (rdn_allaxis.Checked == true)
                //////{
                //////    sqlstr = sqlstr + "All-Home',";
                //////    lbl_raStatus.Text = "RA Status : Robotic Arm1 - All Axis";
                //////    //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                //////    //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                //////    //byte[] bdata = Encoding.Default.GetBytes("\n  RA1,All," + s1);
                //////    //fileStream.Write(bdata, 0, bdata.Length);
                //////    //fileStream.Close();
                //////}
                //////if (rdn_xaxis.Checked == true)
                //////{
                //////    sqlstr = sqlstr + "X-Home',";
                //////    lbl_raStatus.Text = "RA Status : Robotic Arm1 - X Axis";
                //////    //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                //////    //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                //////    //byte[] bdata = Encoding.Default.GetBytes("\n  RA1,X," + s1);
                //////    //fileStream.Write(bdata, 0, bdata.Length);
                //////    //fileStream.Close();
                //////}
                //////if (rdn_yaxis.Checked == true)
                //////{
                //////    sqlstr = sqlstr + "Y-Home',";
                //////    lbl_raStatus.Text = "RA Status : Robotic Arm1 - Y Axis";
                //////    //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                //////    //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                //////    //byte[] bdata = Encoding.Default.GetBytes("\n  RA1,Y," + s1);
                //////    //fileStream.Write(bdata, 0, bdata.Length);
                //////    //fileStream.Close();
                //////}
                //////if (rdn_zaxis.Checked == true)
                //////{
                //////    sqlstr = sqlstr + "Z-Home',";
                //////    lbl_raStatus.Text = "RA Status : Robotic Arm1 - Z Axis";
                //////    //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                //////    //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                //////    //byte[] bdata = Encoding.Default.GetBytes("\n  RA1,Z," + s1);
                //////    //fileStream.Write(bdata, 0, bdata.Length);
                //////    //fileStream.Close();
                //////}
                //////if (rdn_xyaxis.Checked == true)
                //////{
                //////    sqlstr = sqlstr + "X and Y-Home',";
                //////    lbl_raStatus.Text = "RA Status : Robotic Arm1 - X and Y Axis";
                //////    //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                //////    //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                //////    //byte[] bdata = Encoding.Default.GetBytes("\n  RA1,X and Y," + s1);
                //////    //fileStream.Write(bdata, 0, bdata.Length);
                //////    //fileStream.Close();
                //////}
                //////if (rdn_xzaxis.Checked == true)
                //////{
                //////    sqlstr = sqlstr + "X and Z-Home',";
                //////    lbl_raStatus.Text = "RA Status : Robotic Arm1 - X and Z Axis";
                //////    //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                //////    //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                //////    //byte[] bdata = Encoding.Default.GetBytes("\n  RA1,X and Z," + s1);
                //////    //fileStream.Write(bdata, 0, bdata.Length);
                //////    //fileStream.Close();
                //////}
                //////if (rdn_yzaxis.Checked == true)
                {
                    sqlstr = sqlstr + "Y and Z-Home',";
                    lbl_raStatus.Text = "RA Status : Robotic Arm1 - Y and Z Axis";
                    //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                    //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                    //byte[] bdata = Encoding.Default.GetBytes("\n  RA1,Y and Z," + s1);
                    //fileStream.Write(bdata, 0, bdata.Length);
                    //fileStream.Close();
                }
                //if (rdn_HesitateArm.Checked == true)
                //{
                //    //sqlstr = sqlstr + "Hesitate Arm',";
                //    //lbl_raStatus.Text = "RA Status : Robotic Arm1 - Hesitate Arm";
                //    ////FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                //    ////String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                //    ////byte[] bdata = Encoding.Default.GetBytes("\n  RA1,Hesitate Arm," + s1);
                //    ////fileStream.Write(bdata, 0, bdata.Length);
                //    ////fileStream.Close();
                //}
                String s1 = DateTime.Now.ToString("HH:mm:ss");
                String m1 = DateTime.Now.ToString("MMMM");
                sqlstr = sqlstr + "'" + s1 + "','" + m1 + "')";
                cmd = new SqlCommand(sqlstr, con);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                cmd.ExecuteNonQuery();
            }
            if (opt_ra2.Checked == true)
            {
                String ra2 = "Robotic Arm-2";
                sqlstr = "";
                sqlstr = "Insert into EngineeringMode(EngModeParameterName,CalibratedBy,TestedOn,Status,ChangedTime,Month) values('";
                sqlstr = sqlstr + ra2 + "','" + RequiredVariables.UserName + "','";
                String s = DateTime.Now.ToString("dd-MM-yyyy");
                sqlstr = sqlstr + s + "','";
                //////if (rdn_allaxis.Checked == true)
                //////{
                //////    sqlstr = sqlstr + "All-Home',";
                //////    lbl_raStatus.Text = "RA Status : Robotic Arm2 - All Axis";
                //////    //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                //////    //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                //////    //byte[] bdata = Encoding.Default.GetBytes("\n  RA2,All," + s1);
                //////    //fileStream.Write(bdata, 0, bdata.Length);
                //////    //fileStream.Close();
                //////}
                //////if (rdn_xaxis.Checked == true)

                //////{
                //////    sqlstr = sqlstr + "X-Home',";
                //////    lbl_raStatus.Text = "RA Status : Robotic Arm2 - X Axis";
                //////    //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                //////    //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                //////    //byte[] bdata = Encoding.Default.GetBytes("\n  RA2,X," + s1);
                //////    //fileStream.Write(bdata, 0, bdata.Length);
                //////    //fileStream.Close();
                //////}
                //////if (rdn_yaxis.Checked == true)
                //////{
                //////    sqlstr = sqlstr + "Y-Home',";
                //////    lbl_raStatus.Text = "RA Status : Robotic Arm2 - Y Axis";
                //////    //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                //////    //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                //////    //byte[] bdata = Encoding.Default.GetBytes("\n  RA2,Y," + s1);
                //////    //fileStream.Write(bdata, 0, bdata.Length);
                //////    //fileStream.Close();
                //////}
                //////if (rdn_zaxis.Checked == true)
                //////{
                //////    sqlstr = sqlstr + "Z-Home',";
                //////    lbl_raStatus.Text = "RA Status : Robotic Arm2 - Z Axis";
                //////    //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                //////    //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                //////    //byte[] bdata = Encoding.Default.GetBytes("\n  RA2,Z," + s1);
                //////    //fileStream.Write(bdata, 0, bdata.Length);
                //////    //fileStream.Close();
                //////}
                //////if (rdn_xyaxis.Checked == true)
                //////{
                //////    sqlstr = sqlstr + "X and Y',";
                //////    lbl_raStatus.Text = "RA Status : Robotic Arm2 - X and Y Axis";
                //////    //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                //////    //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                //////    //byte[] bdata = Encoding.Default.GetBytes("\n  RA2,X and Y," + s1);
                //////    //fileStream.Write(bdata, 0, bdata.Length);
                //////    //fileStream.Close();
                //////}
                //////if (rdn_xzaxis.Checked == true)
                //////{
                //////    sqlstr = sqlstr + "X and Z-Home',";
                //////    lbl_raStatus.Text = "RA Status : Robotic Arm2 - X and Z Axis";
                //////    //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                //////    //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                //////    //byte[] bdata = Encoding.Default.GetBytes("\n  RA2,X and Z," + s1);
                //////    //fileStream.Write(bdata, 0, bdata.Length);
                //////    //fileStream.Close();
                //////}
                //////if (rdn_yzaxis.Checked == true)
                {
                    sqlstr = sqlstr + "Y and Z-Home',";
                    lbl_raStatus.Text = "RA Status : Robotic Arm2 - Y and Z Axis";
                    //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                    //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                    //byte[] bdata = Encoding.Default.GetBytes("\n  RA2,Y and Z," + s1);
                    //fileStream.Write(bdata, 0, bdata.Length);
                    //fileStream.Close();
                }
                //if (rdn_HesitateArm.Checked == true)
                //{
                //    sqlstr = sqlstr + "Hesitate Arm',";
                //    lbl_raStatus.Text = "RA Status : Robotic Arm2 - Hesitate Arm";
                //    //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                //    //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                //    //byte[] bdata = Encoding.Default.GetBytes("\n  RA2,Hesitate Arm," + s1);
                //    //fileStream.Write(bdata, 0, bdata.Length);
                //    //fileStream.Close();
                //}
                String s1 = DateTime.Now.ToString("HH:mm:ss");
                String m1 = DateTime.Now.ToString("MMMM");
                sqlstr = sqlstr + "'" + s1 + "','" + m1 + "')";
                cmd = new SqlCommand(sqlstr, con);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                cmd.ExecuteNonQuery();
            }

        }
        string enggparameter = " ", paramstatus=" ";
        private void engparametersupdation(string engparam,string paramstatus)
        {
            try
            {               
                sqlstr = "";
                sqlstr = "Insert into EngineeringMode(EngModeParameterName,CalibratedBy,TestedOn,Status,ChangedTime,Month) values('";
                sqlstr = sqlstr + engparam + "','" + RequiredVariables.UserName + "','";
                String s = DateTime.Now.ToString("dd-MM-yyyy");
                sqlstr = sqlstr + s + "','";
                sqlstr = sqlstr + paramstatus + "',";
                String s1 = DateTime.Now.ToString("HH:mm:ss");
                String m1 = DateTime.Now.ToString("MMMM");
                sqlstr = sqlstr + "'" + s1 + "','" + m1 + "')";
                cmd = new SqlCommand(sqlstr, con);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                cmd.ExecuteNonQuery();

                SetText_Listupdate(engparam + " - " + paramstatus);

            }
            catch(Exception d3)
            {
                RequiredVariables.writeerrorlogfile("While updating engineering mode parameters of " + engparam, "In Engineering Mode from in engparametersupdation");
            }            
        }
        private void btn_MoveRA_Click(object sender, EventArgs e)
        {
            //roboticArmMovement();
            try
            {
                if (opt_RA1.Checked == true)
                    Communication.RA_No = 1;
                else if (opt_ra2.Checked == true)
                    Communication.RA_No = 2;
                CommandName = "";
                if (opt_pick.Checked == true)
                {
                    functioncode = Communication.RA_PICK;
                    CommandName = "Rack Picked from " + JarName + "Using RA " + Communication.RA_No.ToString();
                }
                else if (opt_place.Checked == true)
                {
                    functioncode = Communication.RA_PLACE;
                    CommandName = "Rack Placed in " + JarName + "Using RA " + Communication.RA_No.ToString();
                }
                else if (opt_move.Checked == true)
                {
                    functioncode = Communication.RA_MOVE;
                    CommandName = "RA " + Communication.RA_No.ToString() + " Movement to " + JarName;
                }
                else if (opt_Diprack.Checked == true)
                {
                    functioncode = Communication.RA_DIP;
                    CommandName = "Rack Dipped Using RA " + Communication.RA_No.ToString();
                }
                else if(opt_check_Level.Checked==true)
                {
                    Communication.RA_No = 0;
                    functioncode = Communication.LEVEL_SENSE;
                    CommandName = "LEVEL SENSING OF -" + JarName + "- Using RA " + Communication.RA_No.ToString();
                }

                sndcmdstr = "";

                if (opt_move.Checked == true)
                {
                    sndcmdstr = txt_XVal.Text + "," + txt_YVal.Text + "," + txt_Z1Val.Text;
                }
                else if ((opt_pick.Checked == true) || (opt_place.Checked == true)||(opt_check_Level.Checked==true))
                {
                    if ((JarName == "H1") || (JarName == "H2") || (JarName == "H3"))
                    {
                        sndcmdstr = txt_XVal.Text + "," + txt_YVal.Text + "," + txt_Z1Val.Text + ",1";
                    }
                    else
                    {
                        sndcmdstr = txt_XVal.Text + "," + txt_YVal.Text + "," + txt_Z1Val.Text + ",0";
                    }
                }
                else if (opt_Diprack.Checked == true)
                {
                    sndcmdstr = txt_XVal.Text + "," + txt_YVal.Text + "," + cbo_Dips.Text + "," + cbo_dipdelay.Text + "," + cbo_drydelay.Text;
                }

                //sndcmdstr = txt_XVal.Text + "," + txt_YVal.Text + ",0";
                repeatval = 0;
                if (repeatval == 0)
                {
                    Communication.framed_cmd = "";
                }
                enggparameter = "";
                enggparameter = CommandName;
                snd_rcvCmd(functioncode, sndcmdstr);

            }
            catch (Exception d3)
            {

            }
        }
        private void btn_checkLiquidLevel_Click(object sender, EventArgs e)
        {
            String ll = "Liquid Level";
            sqlstr = "";
            sqlstr = "Insert into EngineeringMode(EngModeParameterName,CalibratedBy,TestedOn,Status,ChangedTime,Month) values('";
            sqlstr = sqlstr + ll + "','" + RequiredVariables.UserName + "','";
            String s = DateTime.Now.ToString("dd-MM-yyyy");
            sqlstr = sqlstr + s + "','";
            // sqlstr= sqlstr + "'" + s + "','";
            // status = "";

            sqlstr = sqlstr + txt_liquidLevel.Text + "%',";

            // sqlstr = sqlstr + "ON',";

            String s1 = DateTime.Now.ToString("HH:mm:ss");
            String m1 = DateTime.Now.ToString("MMMM");
            sqlstr = sqlstr + "'" + s1 + "','" + m1 + "')";
            cmd = new SqlCommand(sqlstr, con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();
            lbl_LevelStatus.Text = "Level Status : " + txt_liquidLevel.Text + "%";
            //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
            //byte[] bdata = Encoding.Default.GetBytes("\n  Liquid Level,"+ txt_liquidLevel.Text+"%," + s1);
            //fileStream.Write(bdata, 0, bdata.Length);
            //fileStream.Close();
        }
        private void btn_CheckRack_Click(object sender, EventArgs e)
        {
            String r = "Rack";
            sqlstr = "";
            sqlstr = "Insert into EngineeringMode(EngModeParameterName,CalibratedBy,TestedOn,Status,ChangedTime,Month) values('";
            sqlstr = sqlstr + r + "','" + RequiredVariables.UserName + "','";
            String s = DateTime.Now.ToString("dd-MM-yyyy");
            sqlstr = sqlstr + s + "','";
            // sqlstr= sqlstr + "'" + s + "','";
            // status = "";
            String ch = "Checked";
            sqlstr = sqlstr + ch + "',";

            // sqlstr = sqlstr + "ON',";

            String s1 = DateTime.Now.ToString("HH:mm:ss");
            String m1 = DateTime.Now.ToString("MMMM");
            sqlstr = sqlstr + "'" + s1 + "','" + m1 + "')";
            cmd = new SqlCommand(sqlstr, con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();

            //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
            //byte[] bdata = Encoding.Default.GetBytes("\n  Rack,checked," + s1);
            //fileStream.Write(bdata, 0, bdata.Length);
            //fileStream.Close();
        }
        private void btn_CheckJar_Click(object sender, EventArgs e)
        {
            String j = "Jar";
            sqlstr = "";
            sqlstr = "Insert into EngineeringMode(EngModeParameterName,CalibratedBy,TestedOn,Status,ChangedTime,Month) values('";
            sqlstr = sqlstr + j + "','" + RequiredVariables.UserName + "','";
            String s = DateTime.Now.ToString("dd-MM-yyyy");
            sqlstr = sqlstr + s + "','";
            // sqlstr= sqlstr + "'" + s + "','";
            // status = "";
            String ch = "Checked";
            sqlstr = sqlstr + ch + "',";

            // sqlstr = sqlstr + "ON',";

            String s1 = DateTime.Now.ToString("HH:mm:ss");
            String m1 = DateTime.Now.ToString("MMMM");
            sqlstr = sqlstr + "'" + s1 + "','" + m1 + "')";
            cmd = new SqlCommand(sqlstr, con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();
            //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
            //byte[] bdata = Encoding.Default.GetBytes("\n  Jar,checked," + s1);
            //fileStream.Write(bdata, 0, bdata.Length);
            //fileStream.Close();
        }
        private void cmb_setTemperature_Click(object sender, EventArgs e)
        {
            //pnl_Numbers.Visible = true;
        }
         public void cmbTemp()
         {
            for(int i = 1; i <= 100; i++)
            {
                cmb_setTemperature.Items.Add(i);               
            }
         }
        private void validateTemp()
        {
            string s = cmb_setTemperature.Text;
            if (cmb_setTemperature.Text != "")
            {
                RequiredVariables.pages = Convert.ToInt32(s);

                if (RequiredVariables.pages > 100)
                {
                    cmb_setTemperature.Text = cmb_setTemperature.Text.Substring(0, cmb_setTemperature.Text.Length - 1);
                }
            }
        }
        private void button_1_Click(object sender, EventArgs e)
        {
            SendKeys.Send("1");
            //if (cmb_setTemperature.Text.Length <= 2)
            //{
                cmb_setTemperature.Text = cmb_setTemperature.Text + button_1.Text.Trim();
            //    validateTemp();
            //}
            
            //else
            //{
            //    cmb_setTemperature.Text = cmb_setTemperature.Text + "";
            //}
           
        }
        private void button_2_Click(object sender, EventArgs e)
        {
            //SendKeys.Send("2");
            //if (cmb_setTemperature.Text.Length <= 2)
            //{
                cmb_setTemperature.Text = cmb_setTemperature.Text + button_2.Text.Trim();
            //    validateTemp();
            //}
            //else
            //{
            //    cmb_setTemperature.Text = cmb_setTemperature.Text + "";
            //}
        }
        private void button_3_Click(object sender, EventArgs e)
        {
            SendKeys.Send("3");
            //if (cmb_setTemperature.Text.Length <= 2)
            //{
                cmb_setTemperature.Text = cmb_setTemperature.Text + button_3.Text.Trim();
                //validateTemp();
            //}
            //else
            //{
            //    cmb_setTemperature.Text = cmb_setTemperature.Text + "";
            //}
        }
        private void button_4_Click(object sender, EventArgs e)
        {
            
            SendKeys.Send("4");
            //if (cmb_setTemperature.Text.Length <= 2)
            //{
                cmb_setTemperature.Text = cmb_setTemperature.Text + button_4.Text.Trim();
            //    validateTemp();
            //}
            //else
            //{
            //    cmb_setTemperature.Text = cmb_setTemperature.Text + "";
            //}
        }
        private void button_5_Click(object sender, EventArgs e)
        {
            
            SendKeys.Send("5");
            //if (cmb_setTemperature.Text.Length <= 2)
            //{
                cmb_setTemperature.Text = cmb_setTemperature.Text + button_5.Text.Trim();
            //    validateTemp();
            //}
            //else
            //{
            //    cmb_setTemperature.Text = cmb_setTemperature.Text + "";
            //}
        }
        private void button_6_Click(object sender, EventArgs e)
        {
            
            SendKeys.Send("6");
            //if (cmb_setTemperature.Text.Length <= 2)
            //{
                cmb_setTemperature.Text = cmb_setTemperature.Text + button_6.Text.Trim();
            //    validateTemp();
            //}
            //else
            //{
            //    cmb_setTemperature.Text = cmb_setTemperature.Text + "";
            //}
        }
        private void button_7_Click(object sender, EventArgs e)
        {
            
            SendKeys.Send("7");
            //if (cmb_setTemperature.Text.Length <= 2)
            //{
                cmb_setTemperature.Text = cmb_setTemperature.Text + button_7.Text.Trim();
            //    validateTemp();

            //}
            //else
            //{
            //    cmb_setTemperature.Text = cmb_setTemperature.Text + "";
            //}
        }
        private void button_8_Click(object sender, EventArgs e)
        {
           
            SendKeys.Send("8");
            //if (cmb_setTemperature.Text.Length <= 2)
            //{
                cmb_setTemperature.Text = cmb_setTemperature.Text + button_8.Text.Trim();
            //    validateTemp();

            //}
            //else
            //{
            //    cmb_setTemperature.Text = cmb_setTemperature.Text + "";
            //}
        }
        private void button_9_Click(object sender, EventArgs e)
        {
            
            SendKeys.Send("9");
            //if (cmb_setTemperature.Text.Length <= 2)
            //{
                cmb_setTemperature.Text = cmb_setTemperature.Text + button_9.Text.Trim();
            //    validateTemp();

            //}
            //else
            //{
            //    cmb_setTemperature.Text = cmb_setTemperature.Text + "";
            //}
        }
        private void button_0_Click(object sender, EventArgs e)
        {
            SendKeys.Send("0");
            if (cmb_setTemperature.Text != "")
            {
                //if (cmb_setTemperature.Text.Length <= 2)
                //{
                    cmb_setTemperature.Text = cmb_setTemperature.Text + button_0.Text.Trim();
                //    validateTemp();
                //}
                //else
                //{
                //    cmb_setTemperature.Text = cmb_setTemperature.Text + "";
                //}
            }
        }
        private void button_bs_Click(object sender, EventArgs e)
        {
            //SendKeys.Send("{BACKSPACE}");
            if ((String.Compare(cmb_setTemperature.Text, " ") < 0))
            {
                cmb_setTemperature.Text = cmb_setTemperature.Text.Substring(0, cmb_setTemperature.Text.Length - 1+1);
            }
            else
            {
                cmb_setTemperature.Text = cmb_setTemperature.Text.Substring(0, cmb_setTemperature.Text.Length - 1);
            }
        }
        private void button_dot_Click(object sender, EventArgs e)
        {
            //SendKeys.Send(".");
            //cmb_setTemperature.Text = cmb_setTemperature.Text + button_dot.Text.Trim();
            cmb_setTemperature.Text = cmb_setTemperature.Text + "";
        }
        private void button1_Click(object sender, EventArgs e)
        {

            string s = cmb_setTemperature.Text;
            if (cmb_setTemperature.Text != "")
            {
                RequiredVariables.pages = Convert.ToInt32(s);

                if (RequiredVariables.pages > 100)
                {
                    MessageBox.Show("Temperature should not exceed 100", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmb_setTemperature.Text = cmb_setTemperature.Text.Substring(0, cmb_setTemperature.Text.Length -cmb_setTemperature.Text.Length);
                }
            }
                pnl_Numbers.Visible = false;
        }

        #region Communication 
        string framed_Data = "";
        Boolean all_Axis = false, x_Axis = false, y_Axis = false, z_Axis = false;
        private bool portreintiated = false;
        private bool m_ProcessStarted = false;
        private int functioncode;
        private string sndcmdstr;
        int toSlno = 0, fromSlno = 0, inxSlno = 0, incubtime, cmdsnt = 0;

        DataTable JPos = new DataTable("JarPositions");
        string x1Pos, y1Pos, z1Pos, z2Pos, x1_Pos, y1_Pos, z1_Pos, z2_Pos;
        Boolean pickedflg = false, placedflg = false, topickupflg = false, toplaceflg = false, StartHesitateflg = false, StopHesitateflg = false;
        int retrycnt = 0, sent_func_code = 0, repeatval = 0;
        Boolean port_avail = false, pGotByteFlag = false, rareached = false, polled = false, pCancelFlag = false;

        private void opt_move_CheckedChanged(object sender, EventArgs e)
        {
            btn_MoveRA.Text = "Move RA";
            btn_MoveRA.ForeColor = Color.White;
            btn_MoveRA.BackColor = opt_move.ForeColor;
        }
        private void opt_pick_CheckedChanged(object sender, EventArgs e)
        {
            btn_MoveRA.Text = "Pick Rack";
            btn_MoveRA.ForeColor = Color.White;
            btn_MoveRA.BackColor = opt_pick.ForeColor;
        }
        private void opt_place_CheckedChanged(object sender, EventArgs e)
        {
            btn_MoveRA.Text = "Place Rack";
            btn_MoveRA.ForeColor = Color.White;
            btn_MoveRA.BackColor = opt_place.ForeColor;
        }
        private void btn_Intialize_Click(object sender, EventArgs e)
        {
            try
            {
                Communication.RA_No = 0;

                functioncode = Communication.RA_HOME;
                sndcmdstr = "";

                if (chk_Allaxis.Checked == true)
                    sndcmdstr = "11111111";
                else
                {
                    if (chk_Agitation.Checked == true)
                        sndcmdstr = sndcmdstr + "1";
                    else
                        sndcmdstr = sndcmdstr + "0";

                    if (chk_Htr.Checked == true)
                        sndcmdstr = sndcmdstr + "1";
                    else
                        sndcmdstr = sndcmdstr + "0";

                    if (chk_RA2Zaxis.Checked == true)
                        sndcmdstr = sndcmdstr + "1";
                    else
                        sndcmdstr = sndcmdstr + "0";

                    if (chk_RA2Yaxis.Checked == true)
                        sndcmdstr = sndcmdstr + "1";
                    else
                        sndcmdstr = sndcmdstr + "0";

                    if (chk_RA2Xaxis.Checked == true)
                        sndcmdstr = sndcmdstr + "1";
                    else
                        sndcmdstr = sndcmdstr + "0";

                    if (chk_RA1Zaxis.Checked == true)
                        sndcmdstr = sndcmdstr + "1";
                    else
                        sndcmdstr = sndcmdstr + "0";

                    if (chk_RA1Yaxis.Checked == true)
                        sndcmdstr = sndcmdstr + "1";
                    else
                        sndcmdstr = sndcmdstr + "0";

                    if (chk_RA1Xaxis.Checked == true)
                        sndcmdstr = sndcmdstr + "1";
                    else
                        sndcmdstr = sndcmdstr + "0";
                }

                repeatval = 0;
                if (repeatval == 0)
                {
                    Communication.framed_cmd = "";
                }
                CommandName = "Home Command";
                snd_rcvCmd(functioncode, sndcmdstr);

            }
            catch (Exception d3)
            {

            }
        }
        private void btn_getstat_Click(object sender, EventArgs e)
        {
            CommandName = "GET HOME STATUS";
            enggparameter = CommandName;
            Communication.RA_No = 0;
            snd_rcvCmd(Communication.HOME_STATUS, "");
        }
        Boolean doorstatusclicked = false;
        private void btn_doorstatus_Click(object sender, EventArgs e)
        {
            doorstatusclicked = true;
            getdoorstatus();
        }
        private void getdoorstatus()
        {
            CommandName = "DOOR STATUS";
            enggparameter = CommandName;
            Communication.RA_No = 0;
            snd_rcvCmd(Communication.DOOR_STATUS, "");
        }
        private void btn_valvestatus_Click(object sender, EventArgs e)
        {
            CommandName = "VALVE STATUS";
            enggparameter = CommandName;
            Communication.RA_No = 0;
            snd_rcvCmd(Communication.VALVE_STATUS, "");
        }
        private void tg_HeaterDoor_Click_1(object sender, EventArgs e)
        {
            try
            {
                string onoffval = "0";
                Communication.RA_No = 0;
                intialize_all_loadingflags();
                if (tg_HeaterDoor.CapText == "CLOSE")
                {
                    tg_HeaterDoor.CapText = "OPEN";
                    tg_HeaterDoor.Checked = true;
                    htr_door_open = true;
                    htr_door_close = false;
                    CommandName = "OPEN HEATER DOOR";
                    onoffval = "1,1";
                }
                else if (tg_HeaterDoor.CapText == "OPEN")
                {
                    tg_HeaterDoor.CapText = "CLOSE";
                    tg_HeaterDoor.Checked = false;
                    htr_door_open = false;
                    htr_door_close = true;
                    CommandName = "CLOSE HEATER DOOR";
                    onoffval = "1,0";
                }
                enggparameter = CommandName;
                snd_rcvCmd(Communication.DOOR_CTRL, onoffval);
            }
            catch(Exception de)
            {

            }            
        }
        private void tg_Valve2_Click(object sender, EventArgs e)
        {
            try
            {
                string onoffval = "0";
                Communication.RA_No = 0;
                intialize_all_loadingflags();
                if (tg_Valve2.CapText == "OFF")
                {
                    tg_Valve2.CapText = "ON";
                    tg_Valve2.Checked = true;
                    CommandName = "WATER VALVE-2 CONTROL ON";
                    valonflg = true;
                    valoffflg = false;
                    onoffval = "2,1";
                }
                else if (tg_Valve2.CapText == "ON")
                {
                    tg_Valve2.CapText = "OFF";
                    tg_Valve2.Checked = false;
                    CommandName = "WATER VALVE-2 CONTROL OFF";
                    valonflg = false;
                    valoffflg = true;
                    onoffval = "2,0";
                }
                enggparameter = CommandName;
                snd_rcvCmd(Communication.VALVE_CTRL, onoffval);
            }
            catch(Exception d3)
            {

            }            
        }
        private void tg_Valve3_Click(object sender, EventArgs e)
        {
            try
            {
                string onoffval = "0";
                Communication.RA_No = 0;
                intialize_all_loadingflags();
                if (tg_Valve3.CapText == "OFF")
                {
                    tg_Valve3.CapText = "ON";
                    tg_Valve3.Checked = true;
                    CommandName = "WATER VALVE-3 CONTROL ON";
                    valonflg = true;
                    valoffflg = false;
                    onoffval = "3,1";
                }
                else if (tg_Valve3.CapText == "ON")
                {
                    tg_Valve3.CapText = "OFF";
                    tg_Valve3.Checked = false;
                    CommandName = "WATER VALVE-3 CONTROL OFF";
                    valonflg = false;
                    valoffflg = true;
                    onoffval = "3,0";
                }
                enggparameter = CommandName;
                snd_rcvCmd(Communication.VALVE_CTRL, onoffval);
            }
            catch (Exception d3)
            {

            }
        }
        private void tg_Valve4_Click(object sender, EventArgs e)
        {
            try
            {
                string onoffval = "0";
                Communication.RA_No = 0;
                intialize_all_loadingflags();
                if (tg_Valve4.CapText == "OFF")
                {
                    tg_Valve4.CapText = "ON";
                    tg_Valve4.Checked = true;
                    CommandName = "WATER VALVE-4 CONTROL ON";
                    valonflg = true;
                    valoffflg = false;
                    onoffval = "4,1";
                }
                else if (tg_Valve4.CapText == "ON")
                {
                    tg_Valve4.CapText = "OFF";
                    tg_Valve4.Checked = false;
                    CommandName = "WATER VALVE-4 CONTROL OFF";
                    valonflg = false;
                    valoffflg = true;
                    onoffval = "4,0";
                }
                enggparameter = CommandName;
                snd_rcvCmd(Communication.VALVE_CTRL, onoffval);
            }
            catch (Exception d3)
            {

            }
        }
        private void tg_Valve5_Click(object sender, EventArgs e)
        {
            try
            {
                string onoffval = "0";
                Communication.RA_No = 0;
                intialize_all_loadingflags();
                if (tg_Valve5.CapText == "OFF")
                {
                    tg_Valve5.CapText = "ON";
                    tg_Valve5.Checked = true;
                    CommandName = "WATER VALVE-5 CONTROL ON";
                    valonflg = true;
                    valoffflg = false;
                    onoffval = "5,1";
                }
                else if (tg_Valve5.CapText == "ON")
                {
                    tg_Valve5.CapText = "OFF";
                    tg_Valve5.Checked = false;
                    CommandName = "WATER VALVE-5 CONTROL OFF";
                    valonflg = false;
                    valoffflg = true;
                    onoffval = "5,0";
                }
                enggparameter = CommandName;
                snd_rcvCmd(Communication.VALVE_CTRL, onoffval);
            }
            catch (Exception d3)
            {

            }
        }
        private void tg_Valve6_Click(object sender, EventArgs e)
        {
            try
            {
                string onoffval = "0";
                Communication.RA_No = 0;
                intialize_all_loadingflags();
                if (tg_Valve6.CapText == "OFF")
                {
                    tg_Valve6.CapText = "ON";
                    tg_Valve6.Checked = true;
                    CommandName = "WATER VALVE-6 CONTROL ON";
                    valonflg = true;
                    valoffflg = false;
                    onoffval = "6,1";
                }
                else if (tg_Valve6.CapText == "ON")
                {
                    tg_Valve6.CapText = "OFF";
                    tg_Valve6.Checked = false;
                    CommandName = "WATER VALVE-6 CONTROL OFF";
                    valonflg = false;
                    valoffflg = true;
                    onoffval = "6,0";
                }
                enggparameter = CommandName;
                snd_rcvCmd(Communication.VALVE_CTRL, onoffval);
            }
            catch (Exception d3)
            {

            }
        }
        private void opt_check_Level_CheckedChanged(object sender, EventArgs e)
        {
            btn_MoveRA.Text = "Check Liquid Level";
            btn_MoveRA.ForeColor = Color.White;
            btn_MoveRA.BackColor = opt_check_Level.ForeColor;
        }
        private void btn_poll_Click(object sender, EventArgs e)
        {
            CommandName = "POLL COMMAND ";
            Communication.RA_No = 0;
            snd_rcvCmd(Communication.POLL_VER, "");
        }
        private void chk_Allaxis_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Allaxis.Checked == true)
            {
                chk_Agitation.Checked = true;
                chk_Htr.Checked = true;
                chk_RA1Xaxis.Checked = true;
                chk_RA1Yaxis.Checked = true;
                chk_RA1Zaxis.Checked = true;
                chk_RA2Xaxis.Checked = true;
                chk_RA2Yaxis.Checked = true;
                chk_RA2Zaxis.Checked = true;
            }
            else if (chk_Allaxis.Checked == false)
            {
                chk_Agitation.Checked = false;
                chk_Htr.Checked = false;
                chk_RA1Xaxis.Checked = false;
                chk_RA1Yaxis.Checked = false;
                chk_RA1Zaxis.Checked = false;
                chk_RA2Xaxis.Checked = false;
                chk_RA2Yaxis.Checked = false;
                chk_RA2Zaxis.Checked = false;
            }
        }
        private void chk_Agitation_CheckedChanged(object sender, EventArgs e)
        {
            chk_Allaxis.Checked = false;
        }
        private void chk_Htr_CheckedChanged(object sender, EventArgs e)
        {
            chk_Allaxis.Checked = false;
        }
        private void chk_RA1Xaxis_CheckedChanged(object sender, EventArgs e)
        {
            chk_Allaxis.Checked = false;
        }
        private void chk_RA1Yaxis_CheckedChanged(object sender, EventArgs e)
        {
            chk_Allaxis.Checked = false;
        }
        private void chk_RA1Zaxis_CheckedChanged(object sender, EventArgs e)
        {
            chk_Allaxis.Checked = false;
        }
        private void chk_RA2Xaxis_CheckedChanged(object sender, EventArgs e)
        {
            chk_Allaxis.Checked = false;
        }
        private void chk_RA2Yaxis_CheckedChanged(object sender, EventArgs e)
        {
            chk_Allaxis.Checked = false;
        }

        private void chk_RA2Zaxis_CheckedChanged(object sender, EventArgs e)
        {
            chk_Allaxis.Checked = false;
        }

        private void opt_Diprack_CheckedChanged(object sender, EventArgs e)
        {
            btn_MoveRA.Text = "Dip Rack";
            btn_MoveRA.ForeColor = Color.White;
            btn_MoveRA.BackColor = opt_Diprack.ForeColor;
        }
        private void cbo_Jars_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string st1 = "";

                if (cbo_Jars.Text == "Select")
                    return;
                DataRow[] resut = JPos.Select("JarNo ='" + cbo_Jars.Text + "'");
                if (resut.Length > 0)
                {
                    fromSlno = Convert.ToInt32(resut[0]["SlNo"].ToString());
                    JarName = resut[0]["JarNo"].ToString();
                    txt_XVal.Text = resut[0]["X-Axis"].ToString();
                    txt_YVal.Text = resut[0]["Y-Axis"].ToString();
                    txt_Z1Val.Text = resut[0]["Z1-Axis"].ToString();
                    txt_Z2Val.Text = resut[0]["Z2-Axis"].ToString();
                }
                inxSlno = 0;
            }
            catch(Exception d3)
            {

            }
        }
        private void opt_htropen_Click(object sender, EventArgs e)
        {
            string onoffval = "0";
            opt_close.Enabled = true;
            opt_htropen.Enabled = false;
            Communication.RA_No = 0;
            intialize_all_loadingflags();
            htr_door_open = true;
            htr_door_close = false;
            CommandName = "OPEN HEATER DOOR";
            onoffval = "1,1";
            enggparameter = CommandName;
            snd_rcvCmd(Communication.DOOR_CTRL, onoffval);
        }
        private void opt_close_Click(object sender, EventArgs e)
        {
            string onoffval = "0";
            Communication.RA_No = 0;
            intialize_all_loadingflags();
            opt_close.Enabled = false;
            opt_htropen.Enabled = true;
            htr_door_open = false;
            htr_door_close = true;
            CommandName = "CLOSE HEATER DOOR";
            onoffval = "1,0";
            enggparameter = CommandName;
            snd_rcvCmd(Communication.DOOR_CTRL, onoffval);
        }
        private void loadPositiondetails()
        {
            try
            {
                string filename = "";
                filename = Application.StartupPath + "\\Configuration\\JarsPos.cfg";
                string jarposvalstring = string.Empty;
                string[] jarposval;
                int cnt = 0;
                if (File.Exists(filename))
                {
                    JPos = new DataTable("JarPositions");
                    JPos.Columns.Add("SlNo", Type.GetType("System.Int32"));
                    JPos.Columns.Add("JarNo", Type.GetType("System.String"));
                    JPos.Columns.Add("X-Axis", Type.GetType("System.String"));
                    JPos.Columns.Add("Y-Axis", Type.GetType("System.String"));
                    JPos.Columns.Add("Z1-Axis", Type.GetType("System.String"));
                    JPos.Columns.Add("Z2-Axis", Type.GetType("System.String"));

                    using (System.IO.StreamReader file = new System.IO.StreamReader(filename))
                    {
                        cnt = 0;
                        cbo_Jars.Items.Clear();
                        cbo_Jars.Items.Add("Select");
                        while ((jarposvalstring = file.ReadLine()) != null)
                        {
                            JPos.Rows.Add();
                            cnt = JPos.Rows.Count - 1;
                            jarposval = jarposvalstring.Split(',');
                            JPos.Rows[cnt]["SlNo"] = (cnt + 1);  //Arm - X axis for Left/Right  
                            JPos.Rows[cnt]["JarNo"] = jarposval[0].ToString();  //Arm - X axis for Left/Right  
                            JPos.Rows[cnt]["X-Axis"] = jarposval[1].ToString();  //Arm - X axis for Left/Right  
                            JPos.Rows[cnt]["Y-Axis"] = jarposval[2].ToString();  //Arm - Y axis for Forward/Backward
                            JPos.Rows[cnt]["Z1-Axis"] = jarposval[3].ToString();  //Arm - Z axis for Up/Down to Move RA Punch                             
                            JPos.Rows[cnt]["Z2-Axis"] = jarposval[4].ToString();  //Arm - Z axis for Up/Down to Move RA Punch                             
                            cbo_Jars.Items.Add(jarposval[0].ToString());
                        }
                    }
                    cbo_Jars.SelectedIndex = 0;
                }
            }
            catch (Exception d3)
            {
                MessageBox.Show(d3.ToString(), "Load position details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btn_Rackhold_Click(object sender, EventArgs e)
        {
            CommandName = "RACK HOLDING STATUS";
            enggparameter = CommandName;
            Communication.RA_No = 0; //0
            snd_rcvCmd(Communication.RACK_HOLD, "");
        }

        private void tmr_portstatus_Tick(object sender, EventArgs e)
        {
            if(Communication.portopened==false)
            {
                if (mport.IsOpen)
                    mport.Close();
            }
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        string JarName = "";

        Boolean m_ProcessStoped = false, swpause = false, swresume = false, hwresume = false, hwpause = false, cmdprocesscmp = true;
        DateTime device_resp_Check_time; int prev_Snt_func_code; string prev_Snt_m_CmdData = "";
        private void tmr_RespFail_Tick(object sender, EventArgs e)
        {
            DateTime d1 = System.DateTime.Now;            
            if (d1 >= device_resp_Check_time)
            {
                tmr_RespFail.Enabled = false;
                if (repeatval <= 3)
                {
                    //repeatval = 0;
                    Communication.SequnceNo--;
                    snd_rcvCmd(prev_Snt_func_code, prev_Snt_m_CmdData);
                    repeatval++;
                    device_resp_Check_time = System.DateTime.Now.AddSeconds(20);
                    tmr_RespFail.Enabled = true;
                    tmr_RespFail.Interval = 1000;
                }
                else
                {
                    tmr_RespFail.Enabled = false; retrycnt = 0;
                    MessageBox.Show("Please the communication cable & device once and restart the application", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if ((Communication.isComandInProgress == false)) //if ((pGotByteFlag == true) || (cmd_Exec_Comp==true))
                {
                    tmr_RespFail.Enabled = false;
                }
            }
        }

        string displayScrData = "";
        string CommandName = "", mslave_Id = "", valno = "";
       
        Boolean valonflg = false, valoffflg = false;
        Boolean htr_door_open = false, htr_door_close = false, htr_on = false, htr_off = false;
        SerialPort mport = new SerialPort();

        string targetDeviceDescription = "Silicon Labs CP210x USB to UART Bridge";
        private string GetPortByDescription(string deviceDescription)
        {
            string portName = "";
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption LIKE '%(COM%'"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    string caption = obj["Caption"].ToString();  // e.g., "Silicon Labs CP210x USB to UART Bridge (COM3)"

                    if (caption.Contains(deviceDescription))  // Match device description
                    {
                        int startIndex = caption.LastIndexOf("(COM") + 1;
                        int endIndex = caption.LastIndexOf(")");
                        portName = caption.Substring(startIndex, endIndex - startIndex);  // Extract the COM port name, e.g., "COM3"
                        break;
                    }
                }
            }

            return portName;
        }
        private void getavailableportnames()
        {
            string targetPort = GetPortByDescription(targetDeviceDescription);

            if (!string.IsNullOrEmpty(targetPort))
            {
                Communication.portname = targetPort;  // Use the correct port
                Communication.baudrate = "115200";  // Default baud rate
                if (mport != null)
                {
                    if (mport.IsOpen)
                        mport.Close();
                }
                init_port();

                if (port_avail)
                {
                    ReestablishCommunication();
                }
                else
                {
                    lbl_disp.Text = "Failed to open the communication port.";
                    lbl_disp.BackColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lbl_disp.Text = "Device not found.";
                lbl_disp.BackColor = System.Drawing.Color.Red;
            }
        }
        private void ReestablishCommunication()
        {
            if (!mport.IsOpen)
                mport.Open();

            lbl_disp.Text = "Re-establishing communication with the device. Please be patient...";
            lbl_disp.BackColor = System.Drawing.Color.Navy;
            this.Cursor = Cursors.WaitCursor;

            pGotByteFlag = false;
            lbl_disp.Text = "";
            System.Threading.Thread.Sleep(2000);  // Time delay in milliseconds

            lbl_disp.Text = Communication.portname + " : Opened for communication";
            lbl_disp.BackColor = System.Drawing.Color.Green;
            lbl_disp.ForeColor = System.Drawing.Color.White;           
            Communication.portopened = true;
            this.Cursor = Cursors.Default;
        }

        private void getavailableportnames_Working()
        {
            string[] portnames = SerialPort.GetPortNames(); //load all names of  com ports to string            
            if (portnames.Length > 0)
            {
                foreach (string s in portnames)                 //add this names to comboboxPort items
                {
                    Communication.portname = s;
                    Communication.baudrate = "115200";          //Assigning default baud rate as 9600
                    init_port();
                    if (port_avail == true)
                    {                       
                        if (mport.IsOpen == false)
                            mport.Open();
                        lbl_disp.Text = "Checking Communication Ports and Re-establsihing Communication with device Please be patiance..";
                        lbl_disp.BackColor = Color.Navy;
                        lbl_disp.ForeColor = Color.White;

                        this.Cursor = Cursors.WaitCursor;

                        Communication.devid = 1;
                        pGotByteFlag = false;
                        Communication.resultvalue = "";

                        lbl_disp.Text = "";
                        ////Making machine to wait for 30 seconds for RA to reach home as port reintiated in PC side or in machine
                        System.Threading.Thread.Sleep(13000);  ////Taken time delay in milli seconds
                                                               ////Sending RA home command to device.
                        lbl_disp.Text = Communication.portname + " : Opened for communication";
                        lbl_disp.BackColor = Color.White;
                        lbl_disp.ForeColor = Color.Black;
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            else
            {
                return;
            }
        }
        void init_port()
        {
            try
            {
                port_avail = false;
                mport = new SerialPort();
                mport.PortName = Communication.portname;
                mport.Parity = Parity.None;
                mport.StopBits = StopBits.One;
                mport.DataBits = 8;
                mport.Handshake = Handshake.None;
                mport.BaudRate = int.Parse(Communication.baudrate);
                mport.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                if (!mport.IsOpen)
                    mport.Open();
                port_avail = true;
                Communication.portopened = true;
            }
            catch (Exception ex)
            {
                port_avail = false;
                Communication.portopened = false;
            }
        }
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {

                byte[] receivebuff, resp_bytedata; // this variable is used for to receive the infrmation from device
                Boolean retnval = false;  //this variable is used for to return the value for crc checking
                int func_code = 0, cmdlen = 0, lncrc = 0;
                int dl = 0, receivecount = 0;
                string resp_data = "", st1 = "", st2 = "";

                pGotByteFlag = true;

                #region DataResponce
                ////if (pGotByteFlag == true)
                ////{
                func_code = sent_func_code;
                try
                {
                    System.Threading.Thread.Sleep(100);  //Waiting for 100 ms to get the data from the device
                    if (mport.ReadBufferSize > 0)
                    {
                        receivebuff = new byte[mport.ReadBufferSize];
                        retnval = false;
                        if (Communication.connectionMode == false)
                        {
                            receivecount = mport.Read(receivebuff, 0, mport.ReadBufferSize);
                            if (receivecount <= 0)
                            {
                                repeatval++;
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
                                string btntst = "";
                                pGotByteFlag = true;
                                Array.Copy(receivebuff, 0, rcvpkt, 0, receivecount);

                                btntst = Encoding.Default.GetString(rcvpkt);
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

                                            ////if (btntst.Contains("crc not ok"))
                                            ////{
                                            ////    repeatval += 1;
                                            ////    snd_rcvCmd(func_code, framed_Data);
                                            ////}
                                            ////else
                                            ////{
                                            rcvpkt = Encoding.Default.GetBytes(btntst);
                                            crc = Communication.CRC_Calculation(rcvpkt, 2);
                                            if (crc == 1)
                                            {
                                                repeatval += 1;
                                                snd_rcvCmd(func_code, framed_Data);
                                            }
                                            else
                                            {                                                
                                                Communication.writeCommunicationCommands("Response  - " + btntst);                                                
                                                checkandupdatedatatoscreen(btntst);
                                            }
                                            ////}
                                        }
                                    }
                                    if (cnt == cmdresp.Length)
                                        return;
                                }
                            }
                        }
                    }
                    else  //Didnit received the data from device
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
        private void snd_rcvCmd_Working(int func_code, string m_CmdData)
        {
            try
            {
                Application.DoEvents();
                byte[] cmdpkt = new byte[255];
                string resp_data = "", m_Cmdstr = "";

                //Response Variables
                byte[] receivebuff, resp_bytedata; // this variable is used for to receive the infrmation from device
                Boolean retnval = false;  //this variable is used for to return the value for crc checking
                int cmdlen = 0, lncrc = 0;
                int dl = 0, receivecount = 0;
                string st1 = "", st2 = "";
                //Response Variables

                if (mport.IsOpen==false)
                    init_port(); //Intializing the port

                ////if (!mport.IsOpen)
                ////    mport.Open();

                m_Cmdstr = "";
                m_Cmdstr = mport.ReadExisting();

                pGotByteFlag = false;
                if (repeatval == 0)
                {
                    //Calling frame command function
                    Communication.frame_command(func_code, m_CmdData, Communication.RA_No, m_Cmdstr);
                    m_Cmdstr = Communication.framed_cmd;
                    framed_Data = m_CmdData;
                    sent_func_code = func_code;
                }
                else if (repeatval > 0)
                {
                    m_Cmdstr = Communication.framed_cmd;
                }

                cmdpkt = new byte[m_Cmdstr.Length];
                cmdpkt = Encoding.Default.GetBytes(m_Cmdstr);
                SetText(CommandName + " - " + m_Cmdstr);
                Communication.writeCommunicationCommands("Command * " + CommandName + " - " + m_Cmdstr);
                #region
                if (repeatval >= 3)
                {
                    Communication.writeCommunicationErrorlog("Communication Failed Occured for " + resp_data);
                    MessageBox.Show("Communication Failed with device check the cable connected to the device...", "Tissue Micro Array V0 & R0", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (mport.IsOpen)
                        mport.Close();
                    Communication.datastartreceivingflag = false;
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
                    mport.Write(cmdpkt, 0, cmdpkt.Length);  //Sending command to the unit through communication port

                    //Updating Sequence Number
                    Communication.SequnceNo++;

                    DateTime dltime = System.DateTime.Now;
                    dltime = dltime.AddSeconds(5);  // Adding 5 seconds delay 
                    delay(dltime);
                }
                #endregion

                return;
            }
            catch (Exception d3)
            {
                return;
            }
        }
        private void snd_rcvCmd(int func_code, string m_CmdData)
        {
            //if (Communication.isComandInProgress || Communication.commandQueue.Count == 0)
            if (Communication.isComandInProgress)
                return;
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
                m_Cmdstr = "";
                m_Cmdstr = mport.ReadExisting();

                pGotByteFlag = false;
                if (repeatval == 0)
                {
                    //Calling frame command function
                    Communication.frame_command(func_code, m_CmdData, Communication.RA_No, m_Cmdstr);
                    m_Cmdstr = Communication.framed_cmd;
                    framed_Data = m_CmdData;
                    sent_func_code = func_code;  prev_Snt_func_code = func_code;  prev_Snt_m_CmdData = m_CmdData;
                }
                else if (repeatval > 0)
                {
                    m_Cmdstr = Communication.framed_cmd;
                }

                cmdpkt = new byte[m_Cmdstr.Length];
                cmdpkt = Encoding.Default.GetBytes(m_Cmdstr);
                SetText(CommandName + " - " + m_Cmdstr);

                Communication.writeCommunicationCommands("Command * " + CommandName + " - " + m_Cmdstr);
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
                    mport.Write(cmdpkt, 0, cmdpkt.Length);  //Sending command to the unit through communication port
                    Communication.isComandInProgress = true;// Set flag to avoid overlap
                    //Updating Sequence Number
                    Communication.SequnceNo++;
                    DateTime dltime = System.DateTime.Now;
                    dltime = dltime.AddSeconds(5);  // Adding 5 seconds delay 
                    delay(dltime);
                }
                #endregion

                return;
            }
            catch (Exception d3)
            {
                return;
            }
        }
        private void delay(DateTime DelayTime)
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

        //Checking port is opened or closed

        /*Working Fine commented on 29112023 1457*/
        protected override void WndProc(ref Message m)
        {
            const int WM_DEVICECHANGE = 0x0219;
            //const int DBT_DEVICEARRIVAL = 0x8000;
            //const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
            //const int DBT_DEVTYP_PORT = 0x00000003;
            try
            {
                switch (m.Msg)
                {
                    case WM_DEVICECHANGE:
                        BeginInvoke((MethodInvoker)delegate
                        {
                            try
                            {
                                if (mport != null)
                                {
                                    if (mport.IsOpen == true)
                                        mport.Close();
                                    lbl_disp.Text = Communication.portname + " : Closed for communication with device.... Trying to Re-establish Communication with Device Please be Patiance....";
                                    lbl_disp.BackColor = Color.Red;
                                    lbl_disp.ForeColor = Color.White;
                                    getavailableportnames();
                                }
                                else
                                {
                                    lbl_disp.Text = Communication.portname + " : is in Use by Application";
                                    lbl_disp.BackColor = Color.Red;
                                    lbl_disp.ForeColor = Color.White;
                                }
                            }
                            catch (Exception ex)
                            {
                                lbl_disp.Text = "Communication Failed With device.........";
                                lbl_disp.BackColor = Color.Red;
                                lbl_disp.ForeColor = Color.White;
                            }
                        });
                        break;
                    default:
                        break;
                }
            }
            catch (ObjectDisposedException)
            {

            }
            catch
            {

            }
            finally
            {
                base.WndProc(ref m);
            }
        }

        /*  Working one
        ////protected override void WndProc(ref Message m)
        ////{
        ////    try
        ////    {
        ////        const int WM_DEVICECHANGE = 0x0219;
        ////        //const int DBT_DEVICEARRIVAL = 0x8000;
        ////        //const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
        ////        //const int DBT_DEVTYP_PORT = 0x00000003;
        ////        switch (m.Msg)
        ////        {
        ////            case WM_DEVICECHANGE:
        ////                {
        ////                    //Checkvcpcom();
        ////                    if (mport.IsOpen == true)
        ////                        mport.Close();
        ////                    lbl_disp.Text = Communication.portname + " : Closed for communication with device.... Trying to Re-establish Communication with Device Please be Patiance....";
        ////                    lbl_disp.BackColor = Color.Red;
        ////                    lbl_disp.ForeColor = Color.White;

        ////                    getavailableportnames();
        ////                    break;
        ////                }
        ////            default:
        ////                break;
        ////        }
        ////        base.WndProc(ref m);
        ////    }
        ////    catch (ObjectDisposedException)
        ////    {

        ////    }
        ////    catch
        ////    {

        ////    }
        ////}
        previously working good */

        private void checkandupdatedatatoscreen(string extractedstr)
        {
            try
            {
                string btntst = "", st1 = "", resp_data = "", cmdres = "";
                //btntst = Encoding.Default.GetString(rcvpkt);
                btntst = extractedstr;
                int funccode = 0;
                string[] Jarr = btntst.Split(',');
                string rtype = "", respval = "", msgdisp = "", tmpval = "";
                funccode = Convert.ToInt32(Jarr[1].ToString());

                #region
                ////if (Jarr[1] == func_code.ToString())
                ////{
                resp_data = null;
                resp_data = extractedstr;
                st1 = "";
                st1 = Jarr[2];
                rtype = st1.Substring(0, 1);
                if (Jarr.Length > 3)
                {
                    respval = st1.Substring(1);
                }
                else
                {
                    respval = st1.Substring(1, 3);
                }

                switch (respval)
                {
                    case "000":
                        {
                            msgdisp = "Command Executed Successfully";
                            break;
                        }
                    case "001":
                        {
                            if ((rtype == "F") || (rtype == "I"))
                                msgdisp = "Command Accepted execution Pending";
                            else if (rtype == "N")
                                msgdisp = "Device Reboot Event";
                            break;
                        }
                    case "002":
                        {
                            if ((rtype == "F") || (rtype == "I"))
                                msgdisp = "Unknown Command";
                            else if (rtype == "N")
                                msgdisp = "Loading / Unloading Door Opened/Closed";
                            break;
                        }
                    case "003":
                        {
                            msgdisp = "Insufficient Arguments";
                            break;
                        }
                    case "004":
                        {
                            msgdisp = "Invalid Arguments";
                            break;
                        }
                    case "005":
                        {
                            msgdisp = "Robo ARM is busy";
                            break;
                        }
                    case "006":
                        {
                            msgdisp = "Path may cause collision of ARMS";
                            break;
                        }
                    case "007":
                        {
                            msgdisp = "Command Under Development";
                            break;
                        }
                    case "008":
                        {
                            msgdisp = "Fatal Error";
                            break;
                        }
                    case "009":
                        {
                            msgdisp = "Motor is Busy";
                            break;
                        }
                    case "010":
                        {
                            msgdisp = "Motor Not Rotating";
                            break;
                        }
                    case "011":
                        {
                            msgdisp = "Heater Already Off";
                            break;
                        }
                    case "012":
                        {
                            msgdisp = "Heater Alreay On";
                            break;
                        }
                }
                if (rtype == "F") Communication.isComandInProgress = false;
                switch (funccode)
                {
                    case 1:  //RA Movement
                        {
                            displayScrData = "";
                            string[] lvl = Jarr[3].Split('*');
                            if ((respval == "000") && (rtype == "F"))
                            {
                                
                                displayScrData = "RA-" + lvl[0].ToString() + " Moved to " + JarName; ;
                            }
                            else
                            {
                                displayScrData = "RA-" + lvl[0].ToString() + " Movement " + msgdisp;
                            }
                                
                            SetText(displayScrData);
                            m_ProcessStoped = false;
                            swpause = false;
                            swresume = false;
                            hwresume = false;
                            hwpause = false;
                            rareached = true;
                            cmdprocesscmp = true;

                            //Updating data to database
                            engparametersupdation(enggparameter, displayScrData);

                            break;
                        }
                    case 2:  //RA Picked
                        {
                            displayScrData = "";
                            //displayScrData = "RA-" + Jarr[3] + " Rack Pick " + msgdisp;
                            string[] lvl = Jarr[3].Split('*');
                            if ((respval == "000") && (rtype == "F"))
                            {

                                displayScrData = "RA-" + lvl[0].ToString() + " Rack Pick " + JarName; ;
                            }
                            else
                            {
                                displayScrData = "RA-" + lvl[0].ToString() + " Rack Pick " + msgdisp;
                            }
                            SetText(displayScrData);
                            m_ProcessStoped = false;
                            swpause = false;
                            swresume = false;
                            hwresume = false;
                            hwpause = false;
                            rareached = true;
                            cmdprocesscmp = true;
                            engparametersupdation(enggparameter, displayScrData);
                            break;
                        }
                    case 3:  //RA Placed
                        {

                            displayScrData = "";
                            displayScrData = "RA-" + Jarr[3] + " Rack Placed " + msgdisp;
                            string[] lvl = Jarr[3].Split('*');
                            if ((respval == "000") && (rtype == "F"))
                            {

                                displayScrData = "RA-" + lvl[0].ToString() + " Rack Placed in " + JarName; ;
                            }
                            else
                            {
                                displayScrData = "RA-" + lvl[0].ToString() + " Rack Placed in " + msgdisp;
                            }
                            SetText(displayScrData);
                            m_ProcessStoped = false;
                            swpause = false;
                            swresume = false;
                            hwresume = false;
                            hwpause = false;
                            rareached = true;
                            cmdprocesscmp = true;
                            engparametersupdation(enggparameter, displayScrData);
                            break;
                        }
                    case 4: //Level Sensing With RA
                        {
                            displayScrData = "";
                            if ((respval == "000") && (rtype == "F"))
                            {
                                string[] lvl = Jarr[3].Split('*');
                                displayScrData = "Level Sense Value : " + lvl[0].ToString();
                                checkrackval((float)(Convert.ToSingle(lvl[0].ToString())));
                            }
                            else
                            {
                                displayScrData = "Level Sense Value  : " + msgdisp;
                            }
                            SetText(displayScrData);
                            engparametersupdation(enggparameter, displayScrData);
                            break;
                        }
                    case 5: //Home Command
                        {
                            displayScrData = "";
                            if ((respval == "000") && (rtype == "F"))
                            {                                
                                 displayScrData = "All axis Moved to Home";                               
                            }
                            else
                            {
                                displayScrData = "Home Status " + msgdisp;
                            }
                            SetText(displayScrData);
                            engparametersupdation(enggparameter, displayScrData);
                            break;
                        }
                    case 6: //Get Home Status
                        {

                            displayScrData = "";
                            if ((respval == "000") && (rtype == "F"))
                            {
                                if (Jarr[3].Substring(0, 8) == "11111111")
                                    displayScrData = "All axis are in Home";
                                else {
                                    string st11 = Jarr[3].Substring(0, 8);
                                    for(int k=0; k<st11.Length;k++)
                                    {
                                        if(st11.Substring(k,1)=="1")
                                        {
                                            if(k==0)
                                            {
                                                displayScrData = "Heater Door Opened";
                                            }
                                            else if(k==1)
                                            {
                                                displayScrData = displayScrData + "Agitation gone to Home";
                                            }
                                            else if (k == 2)
                                            {
                                                displayScrData = displayScrData + "RA-2 Z in Home";
                                            }
                                            else if (k == 3)
                                            {
                                                displayScrData = displayScrData + "RA-2 Y in Home";
                                            }
                                            else if (k == 4)
                                            {
                                                displayScrData = displayScrData + "RA-2 X in Home";
                                            }
                                            else if (k == 5)
                                            {
                                                displayScrData = displayScrData + "RA-1 Z in Home";
                                            }
                                            else if (k == 6)
                                            {
                                                displayScrData = displayScrData + "RA-1 Y in Home";
                                            }
                                            else if (k == 7)
                                            {
                                                displayScrData = displayScrData + "RA-1 X in Home";
                                            }
                                        }
                                    }                                    
                                }                                
                            }
                            else
                            {
                                displayScrData = "Home Status " + msgdisp;
                            }
                            SetText(displayScrData);
                            engparametersupdation(enggparameter, displayScrData);
                            break;
                        }
                    case 7: //Rack Holding Status
                        {
                            displayScrData = "";
                            if ((respval == "000") && (rtype == "F"))
                            {
                                displayScrData = "Rack Status - " + Jarr[3].ToString().Substring(0, 2);
                            }
                            else
                            {
                                displayScrData = "Rack Status " + msgdisp;
                            }
                            SetText(displayScrData);
                            engparametersupdation(enggparameter, displayScrData);
                            break;
                        }
                    case 8: //Door Control
                        {
                            displayScrData = "";
                            if ((respval == "000") && (rtype == "F"))
                            {
                                displayScrData = "Heater Door ";
                                if (htr_door_open == true)
                                    displayScrData = displayScrData + "Opened Sucessfully";
                                else if (htr_door_close == true)
                                    displayScrData = displayScrData + "Closed Sucessfully";
                            }
                            else
                            {
                                displayScrData = "Doors Status : " + msgdisp;
                            }
                            SetText(displayScrData);
                            engparametersupdation(enggparameter, displayScrData);
                            break;
                        }
                    case 9: //Door Status
                        {
                            displayScrData = "";
                            if ((respval == "000") && (rtype == "F"))
                            {
                                string[] lvl = Jarr[3].Split('*');
                                if (lvl[0].Substring(0, 1) == "1")
                                    displayScrData = "Heater Door : ";
                                else if (lvl[0].Substring(0, 1) == "0")
                                    displayScrData = "Loading/Unloading Door : ";

                                if (lvl[0].Substring(1, 1) == "1")
                                    displayScrData = displayScrData + "Opened";
                                else if (lvl[0].Substring(1, 1) == "0")
                                    displayScrData = displayScrData + "Closed";

                                //displayScrData = "Doors Status" + Jarr[3].ToString();
                                //New code added on 11112023 1223
                                if (doorstatusclicked == false)
                                {
                                    opt_close.Enabled = true;
                                    opt_htropen.Enabled = true;
                                    ////if (lvl[0].ToString() == "11")
                                    ////{
                                    ////    opt_close.Enabled = true;
                                    ////    opt_htropen.Enabled = false;
                                    ////}
                                    ////else if (lvl[0].ToString() == "01")
                                    ////{
                                    ////    opt_close.Enabled = false;
                                    ////    opt_htropen.Enabled = true;
                                    ////}
                                }
                                else if (doorstatusclicked == true)
                                {
                                    doorstatusclicked = false;
                                }
                            }
                            else
                            {
                                displayScrData = "Doors Status " + msgdisp;
                            }
                            SetText(displayScrData);
                            engparametersupdation(enggparameter, displayScrData);
                            break;
                        }
                    case 10: // Set Temperature
                        {
                            displayScrData = "";
                            if ((respval == "000") && (rtype == "F"))
                            {
                                displayScrData = " Given Temperature Value Successfully Set to Device";
                            }
                            else
                            {
                                displayScrData = "Temperature Value Not Set " + msgdisp;
                            }
                            SetText(displayScrData);
                            engparametersupdation(enggparameter, displayScrData);
                            break;
                        }
                    case 11: //Get Temperature
                        {
                            displayScrData = "";
                            if ((respval == "000") && (rtype == "F"))
                            {
                                string[] lvl = Jarr[3].Split('*');
                                displayScrData = "Temperature : " + lvl[0].ToString() + "°C";
                                tmpval = lvl[0].ToString();
                                //txt_readTemperature.Text = lvl[0].ToString();
                                SetText_Temperature(tmpval);
                            }
                            else
                            {
                                displayScrData = "Temperature  : " + msgdisp;
                                tmpval = "--";
                            }
                            SetText(displayScrData);
                            engparametersupdation(enggparameter, displayScrData);
                            //SetText(tmpval);
                            break;
                        }
                    case 12: //Heater Control
                        {
                            displayScrData = "";
                            if ((respval == "000") && (rtype == "F"))
                            {
                                if (htr_on == true)
                                {
                                    displayScrData = "Heater Switched On ";
                                }
                                else if (htr_off == true)
                                {
                                    displayScrData = "Heater Switched Off ";
                                }
                            }
                            else
                            {
                                if (htr_on == true)
                                {
                                    displayScrData = "Unable to Switch On Heater";
                                }
                                else if (htr_off == true)
                                {
                                    displayScrData = "Unable to Switch Off Heater";
                                }
                            }
                            SetText(displayScrData);
                            engparametersupdation(enggparameter, displayScrData);
                            break;
                        }
                    case 13: //Water Valve Control
                        {
                            displayScrData = "";
                            if ((respval == "000") && (rtype == "F"))
                            {
                                if (valonflg == true)
                                {
                                    valonflg = false;
                                    displayScrData = "Water Valve : " + valno + " is On";
                                }
                                else if (valoffflg == true)
                                {
                                    valoffflg = false;
                                    displayScrData = "Water Valve : " + valno + " is Off";
                                }
                            }
                            else
                            {
                                displayScrData = "Water Valve Status " + msgdisp;
                            }
                            SetText(displayScrData);
                            engparametersupdation(enggparameter, displayScrData);
                            break;
                        }
                    case 14: //Water Valve Status
                        {
                            displayScrData = "";
                            if ((respval == "000") && (rtype == "F"))
                            {
                                string[] lvl = Jarr[3].Split('*');
                                if (lvl[0].ToString() == "000000")
                                {
                                    displayScrData = "All Valves Closed ";
                                }
                                else if (lvl[0].ToString() == "111111")
                                {
                                    displayScrData = "All Valves Opened ";
                                }
                                else
                                {
                                    for (int i = lvl[0].ToString().Length; i >= 0; i--)
                                    {
                                        if (i == 5)
                                        {
                                            if (lvl[0].Substring(i, 1) == "1")
                                                displayScrData = displayScrData + "V1 Opened ";
                                            else
                                                displayScrData = displayScrData + "V1 Closed ";
                                        }
                                        else if (i == 4)
                                        {
                                            if (lvl[0].Substring(i, 1) == "1")
                                                displayScrData = displayScrData + "V2 Opened ";
                                            else
                                                displayScrData = displayScrData + "V2 Closed ";
                                        }
                                        else if (i == 3)
                                        {
                                            if (lvl[0].Substring(i, 1) == "1")
                                                displayScrData = displayScrData + "V3 Opened ";
                                            else
                                                displayScrData = displayScrData + "V3 Closed ";
                                        }
                                        else if (i == 2)
                                        {
                                            if (lvl[0].Substring(i, 1) == "1")
                                                displayScrData = displayScrData + "V4 Opened ";
                                            else
                                                displayScrData = displayScrData + "V4 Closed ";
                                        }
                                        else if (i == 1)
                                        {
                                            if (lvl[0].Substring(i, 1) == "1")
                                                displayScrData = displayScrData + "V5 Opened ";
                                            else
                                                displayScrData = displayScrData + "V5 Closed ";
                                        }
                                        else if (i == 0)
                                        {
                                            if (lvl[0].Substring(i, 1) == "1")
                                                displayScrData = displayScrData + "V6 Opened ";
                                            else
                                                displayScrData = displayScrData + "V6 Closed ";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                displayScrData = "Valve Status " + msgdisp;
                            }
                            SetText(displayScrData);
                            engparametersupdation(enggparameter, displayScrData);
                            break;

                        }
                    case 15: //Poll/Version
                        {
                            displayScrData = "";
                            if ((respval == "000") && (rtype == "F"))
                            {
                                string[] lvl = Jarr[3].Split('*');
                                displayScrData = "Poll/Version " + lvl[0].ToString();
                            }
                            else
                            {
                                displayScrData = "Poll/Version " + msgdisp;
                            }
                            SetText(displayScrData);
                            engparametersupdation(enggparameter, displayScrData);
                            break;
                        }
                    case 16: //Agitation Control
                        {
                            displayScrData = "";
                            if ((respval == "000") && (rtype == "F"))
                            {
                                if (StartHesitateflg == true)
                                    displayScrData = "Agitation Started ";
                                else if (StopHesitateflg == true)
                                    displayScrData = "Agitation Stoped ";
                            }
                            else
                            {
                                displayScrData = "Agitation Control " + msgdisp;
                            }
                            SetText(displayScrData);
                            engparametersupdation(enggparameter, displayScrData);
                            break;
                        }
                    case 17:  //RA Dip
                        {
                            displayScrData = "";
                            if ((respval == "000") && (rtype == "F"))
                            {
                                string[] lvl = Jarr[3].Split('*');
                                displayScrData = "Rack Dipped Successfully With RA : " + lvl[0];
                            }
                            else
                            {
                                displayScrData = "RA Dip " + msgdisp;
                            }
                            SetText(displayScrData);
                            engparametersupdation(enggparameter, displayScrData);
                            break;
                        }
                }

                #endregion
                return;
            }
            catch (Exception d3)
            {

            }
        }

        private void checkrackval(float lvlsnsval)
        {
            float[] minval = new float[20]; float[] maxval = new float[20];
            minval[0] = 190;    //Rack Min
            minval[1] = 792;    //300 ml
            minval[2] = 910;    //290 ml
            minval[3] = 1026;   //260 ml
            minval[4] = 1100;   //250 ml
            minval[5] = 1170;   //230 ml
            minval[6] = 1270;   //200 ml
            minval[7] = 1385;   //180 ml
            minval[8] = 1401;   //170 ml
            minval[9] = 1509;   //150 ml
            minval[10] = 1731;  //100 ml
            minval[11] = 1946;  //50 ml
            minval[12] = 2117;  //0 ml
            minval[13] = 3016;  // No-Jar
            minval[14] = 1860;  // New Rack Values

            maxval[14] = 2100;    //Nex Rack Max
            maxval[0] = 220;    //Rack Max
            maxval[1] = 900;    //300 ml
            maxval[2] = 1025;    //290 ml
            maxval[3] = 1099;    //260 ml
            maxval[4] = 1168;   //250 ml
            maxval[5] = 1265;    //230 ml
            maxval[6] = 1384;   //200 ml
            maxval[7] = 1400;    //180 ml
            maxval[8] = 1508;    //170 ml
            maxval[9] = 1556;   //150 ml
            maxval[10] = 1945;  //100 ml
            maxval[11] = 2116;  //50 ml
            maxval[12] = 2229;  //0 ml
            maxval[13] = 3138;  // No-jar75*3

            if ((lvlsnsval >= minval[0]) && (lvlsnsval <= maxval[0]))   // Only Rack
            {
                SetText_lvlsense("Rack is Holding By RA");
            }
            else if ((lvlsnsval > maxval[1]) && (lvlsnsval < minval[14]))  //Between Rack & 300 ml
            {
                SetText_lvlsense("Sensing Area is above 300ml & Below Rack");
            }
            else if ((lvlsnsval > minval[14]) && (lvlsnsval < maxval[14]))  //Between Rack & 300 ml
            {
                SetText_lvlsense("Sensing Area is above 300ml & Below Rack");
            }
            else if ((lvlsnsval > maxval[0]) && (lvlsnsval < minval[1]))  //Between Rack & 300 ml
            {
                SetText_lvlsense("Sensing Area is above 300ml & Below Rack");
            }
            else if ((lvlsnsval >= minval[1]) && (lvlsnsval <= maxval[1]))  //Only 300 ml
            {
                SetText_lvlsense(JarName + " Contains 300ml of Reagent in it");
            }
            else if ((lvlsnsval > maxval[1]) && (lvlsnsval < minval[2])) //Between 250ml & 300 ml
            {
                SetText_lvlsense(JarName + " Contains Reagent of between 250ml to 300ml in it");
            }
            else if ((lvlsnsval >= minval[2]) && (lvlsnsval <= maxval[2])) //Only 250 ml
            {
                SetText(JarName + " Contains 250ml of Reagent in it");
            }
            else if ((lvlsnsval > maxval[2]) && (lvlsnsval < minval[3])) //Between 250ml & 200 ml
            {
                SetText_lvlsense(JarName + " Contains Reagent of between 200ml to 250ml in it");
            }
            else if ((lvlsnsval >= minval[3]) && (lvlsnsval <= maxval[3]))  //Only 200 ml
            {
                SetText_lvlsense(JarName + " Contains 200ml of Reagent in it");
            }
            else if ((lvlsnsval > maxval[3]) && (lvlsnsval < minval[4])) //Between 150ml & 200 ml
            {
                SetText_lvlsense(JarName + " Contains Reagent of between 150ml to 200ml in it");
            }
            else if ((lvlsnsval >= minval[4]) && (lvlsnsval <= maxval[4]))  //Only 150 ml
            {
                SetText_lvlsense(JarName + " Contains 150ml of Reagent in it");
            }
            else if ((lvlsnsval > maxval[4]) && (lvlsnsval < minval[5])) //Between 100ml & 150 ml
            {
                SetText_lvlsense(JarName + " Contains Reagent of between 100ml to 150ml in it");
            }
            else if ((lvlsnsval >= minval[5]) && (lvlsnsval <= maxval[5]))  //Only 100 ml
            {
                SetText_lvlsense(JarName + " Contains 100ml of Reagent in it");
            }
            else if ((lvlsnsval > maxval[5]) && (lvlsnsval < minval[6])) //Between 50ml & 100ml
            {
                SetText_lvlsense(JarName + " Contains Reagent of between 50ml to 100ml in it");
            }
            else if ((lvlsnsval >= minval[6]) && (lvlsnsval <= maxval[6])) //Only 50 ml
            {
                SetText_lvlsense(JarName + " Contains 50ml of Reagent in it");
            }
            else if ((lvlsnsval > maxval[6]) && (lvlsnsval < minval[7])) //Between 0ml & 50ml
            {
                SetText_lvlsense(JarName + " Contains Reagent of between 0ml to 50ml in it");
            }
            else if ((lvlsnsval >= minval[7]) && (lvlsnsval <= maxval[7]))  //Only 0 ml
            {
                SetText_lvlsense("No Reagent in " + JarName + "Please fill reagent to run the test");
            }
            else if ((lvlsnsval > maxval[7]) && (lvlsnsval < minval[8])) //Between 0ml  & No Jar
            {
                SetText_lvlsense(" No Jar in Machine Please check  Without Jar process cann't be done");
            }
            else if ((lvlsnsval >= minval[8]) && (lvlsnsval <= maxval[8])) //Only No Jar
            {
                SetText_lvlsense(" No Jar in Machine Please check  Without Jar process cann't be done");
            }
            else if ((lvlsnsval > maxval[8])) //No Jar Value
            {
                SetText_lvlsense(" No Jar in Machine Please check  Without Jar process cann't be done");
            }
        }

        private void intialize_all_loadingflags()
        {
            StartHesitateflg = false;
            StopHesitateflg = false;

            //Valves On / Off
            valonflg = false;
            valoffflg = false;
            //Heater door , heaters & fans 
            htr_door_open = false; htr_door_close = false; htr_on = false; htr_off = false;


        }

        #endregion
        #region Display Text
        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            try
            {
                Application.DoEvents();
                // InvokeRequired required compares the thread ID of the
                // calling thread to the thread ID of the creating thread.
                // If these threads are different, it returns true.
                if (this.lbl_disp.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    // this.TBx.Text = "";
                    this.lbl_disp.Text = text;
                }
            }
            catch (Exception d3)
            {
                MessageBox.Show(d3.ToString() + "While updating the text file", "Test Communication", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        delegate void SetTextCallback_lvlsense(string text);
        private void SetText_lvlsense(string text)
        {
            try
            {
                Application.DoEvents();
                // InvokeRequired required compares the thread ID of the
                // calling thread to the thread ID of the creating thread.
                // If these threads are different, it returns true.
                if (this.lbl_disp.InvokeRequired)
                {
                    SetTextCallback_lvlsense d = new SetTextCallback_lvlsense(SetText_lvlsense);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    // this.TBx.Text = "";
                    this.lbl_disp.Text = text;
                }
            }
            catch (Exception d3)
            {
                MessageBox.Show(d3.ToString() + "While updating the text file", "Test Communication", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        delegate void SetTextCallback_Temperature(string text);
        private void SetText_Temperature(string text)
        {
            try
            {
                Application.DoEvents();
                // InvokeRequired required compares the thread ID of the
                // calling thread to the thread ID of the creating thread.
                // If these threads are different, it returns true.
                if (this.txt_readTemperature.InvokeRequired)
                {
                    SetTextCallback_Temperature d = new SetTextCallback_Temperature(SetText_Temperature);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    // this.TBx.Text = "";
                    this.txt_readTemperature.Text = text;
                }
            }
            catch (Exception d3)
            {
                MessageBox.Show(d3.ToString() + "While updating the text file", "Test Communication", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        delegate void SetTextCallback_Listval(string text);
        private void SetText_Listupdate(string text)
        {
            try
            {
                Application.DoEvents();
                // InvokeRequired required compares the thread ID of the
                // calling thread to the thread ID of the creating thread.
                // If these threads are different, it returns true.
                if (this.lst_resp.InvokeRequired)
                {
                    SetTextCallback_Listval d = new SetTextCallback_Listval(SetText_Listupdate);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    // this.TBx.Text = "";
                    this.lst_resp.Items.Add(text);
                }
            }
            catch (Exception d3)
            {
                MessageBox.Show(d3.ToString() + "While updating the text to listbox", "Test Communication", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }


        public bool Process_Started { get; private set; }
        #endregion


    }
}
