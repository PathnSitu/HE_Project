using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
using System.IO;
using System.Data.SqlClient;
using System.IO.Ports;

namespace HematoxinandEosin
{
    public partial class Frm_JarPositionCalib : Form
    {
        string Constr = "";//"Data Source=SYSPSENG006;User ID=sa;Password=sree@pns2013;Initial Catalog=PNSHE;Pooling=false;Max Pool Size=400;workstation id =SYSPSENG006";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        // DataTable table = new DataTable("table");
        SqlDataAdapter sda = new SqlDataAdapter();
        //Data Tabels Declaration
        DataTable JPos = new DataTable("JarPositions");
        DataTable JPos_DB = new DataTable("JarPositions");
        string sqlstr;

        #region ZoomParameters
        //Zoom Panel Variables
        string processName = "";
        string elaspedtime = "";
        Color Rackcolor = Color.Transparent;
        string Racknumber = "";
        string ReagentName = "";
        bool JarRack = false;
        Color BckGroundColor = Color.White;
        Color BckColor = Color.White;
        Color TxtColor = Color.White;
        bool OnlyJar = true;
        bool OnlyRack = false;
        string TaskCompletionTime = "";
        string TaskProcess = "";
        Color BdrColor = Color.Navy;

        //Position and size details variables
        int PF_X = 0, PF_Y = 0, ZF_X = 0, ZF_Y = 0, CP_X = 0, CP_Y = 0;
        int ZF_W = 0, ZF_H = 0, PF_W = 0, PF_H = 0;
        #endregion

        //string FilePath = Path.Combine(@"G:\projects\mukesh\CalibLog\Jp", DateTime.Today.ToString("dd/MM/yyyy") + ".csv");
        public Frm_JarPositionCalib()
        {
            InitializeComponent();
        }

        private void Jars()
        {
            H1.OnlyJar = true;
            H1.BorderSize =3;
            H2.OnlyJar = true;
            H2.BorderSize =3;
            H3.OnlyJar = true;
            H3.BorderSize =3;
            J1.OnlyJar = true;
            J1.BorderSize =3;
            //jar1.Refresh();
            J2.OnlyJar = true;
            J2.BorderSize =3;
            J3.OnlyJar = true;
            J3.BorderSize =3;
            J4.OnlyJar = true;
            J4.BorderSize =3;
            J5.OnlyJar = true;
            J5.BorderSize =3;
            J6.OnlyJar = true;
            J6.BorderSize =3;
            J7.OnlyJar = true;
            J7.BorderSize =3;
            J8.OnlyJar = true;
            J8.BorderSize =3;
            J9.OnlyJar = true;
            J9.BorderSize =3;
            W1.OnlyJar = true;
            W1.BorderSize =3;
            W2.OnlyJar = true;
            W2.BorderSize =3;
            W3.OnlyJar = true;
            W3.BorderSize =3;
            J10.OnlyJar = true;
            J10.BorderSize =3;
            J11.OnlyJar = true;
            J11.BorderSize =3;
            J12.OnlyJar = true;
            J12.BorderSize =3;
            J13.OnlyJar = true;
            J13.BorderSize =3;
            J14.OnlyJar = true;
            J14.BorderSize =3;
            J15.OnlyJar = true;
            J15.BorderSize =3;
            J16.OnlyJar = true;
            J16.BorderSize =3;
            J17.OnlyJar = true;
            J17.BorderSize =3;
            W4.OnlyJar = true;
            W4.BorderSize =3;
            W5.OnlyJar = true;
            W5.BorderSize =3;
            W6.OnlyJar = true;
            W6.BorderSize =3;
            J18.OnlyJar = true;
            J18.BorderSize =3;
            J19.OnlyJar = true;
            J19.BorderSize =3;
            J20.OnlyJar = true;
            J20.BorderSize =3;
            J21.OnlyJar = true;
            J21.BorderSize =3;
            J22.OnlyJar = true;
            J22.BorderSize =3;
            J23.OnlyJar = true;
            J23.BorderSize =3;
            J24.OnlyJar = true;
            J24.BorderSize =3;
            J25.OnlyJar = true;
            J25.BorderSize =3;
            J26.OnlyJar = true;
            J26.BorderSize =3;
            L3.OnlyJar = true;
            L3.BorderSize =3;
            L2.OnlyJar = true;
            L2.BorderSize =3;
            L1.OnlyJar = true;
            L1.BorderSize =3;
            J33.OnlyJar = true;
            J33.BorderSize =3;
            J32.OnlyJar = true;
            J32.BorderSize =3;
            J31.OnlyJar = true;
            J31.BorderSize =3;
            J30.OnlyJar = true;
            J30.BorderSize =3;
            J29.OnlyJar = true;
            J29.BorderSize =3;
            J28.OnlyJar = true;
            J28.BorderSize =3;
            J27.OnlyJar = true;
            J27.BorderSize =3;
            U6.OnlyJar = true;
            U6.BorderSize =3;
            U5.OnlyJar = true;
            U5.BorderSize =3;
            U4.OnlyJar = true;
            U4.BorderSize =3;
            U3.OnlyJar = true;
            U3.BorderSize =3;
            U2.OnlyJar = true;
            U2.BorderSize =3;
            U1.OnlyJar = true;
            U1.BorderSize =3;
        }

        public void jarsbgColors()
        {
            // jar1.BackColor.Fill = new SolidColorBrush(Color.FromArgb(dlg.Color.A, dlg.Color.R, dlg.Color.G, dlg.Color.B));
            J1.BackColor = Color.FromArgb(216, 217, 207);
            J1.BackgroundColor = Color.FromArgb(216, 217, 207);

            J2.BackColor = Color.FromArgb(216, 217, 207);
            J2.BackgroundColor = Color.FromArgb(216, 217, 207);
            J3.BackColor = Color.FromArgb(216, 217, 207);
            J3.BackgroundColor = Color.FromArgb(216, 217, 207);
            J4.BackColor = Color.FromArgb(216, 217, 207);
            J4.BackgroundColor = Color.FromArgb(216, 217, 207);
            J5.BackColor = Color.FromArgb(216, 217, 207);
            J5.BackgroundColor = Color.FromArgb(216, 217, 207);
            J6.BackColor = Color.FromArgb(216, 217, 207);
            J6.BackgroundColor = Color.FromArgb(216, 217, 207);
            J7.BackColor = Color.FromArgb(216, 217, 207);
            J7.BackgroundColor = Color.FromArgb(216, 217, 207);
            J8.BackColor = Color.FromArgb(216, 217, 207);
            J8.BackgroundColor = Color.FromArgb(216, 217, 207);
            J9.BackColor = Color.FromArgb(216, 217, 207);
            J9.BackgroundColor = Color.FromArgb(216, 217, 207);
            W1.BackColor = Color.FromArgb(185, 224, 255);
            W1.BackgroundColor = Color.FromArgb(185, 224, 255);
            W2.BackColor = Color.FromArgb(185, 224, 255);
            W2.BackgroundColor = Color.FromArgb(185, 224, 255);
            W3.BackColor = Color.FromArgb(185, 224, 255);
            W3.BackgroundColor = Color.FromArgb(185, 224, 255);
            J10.BackColor = Color.FromArgb(216, 217, 207);
            J10.BackgroundColor = Color.FromArgb(216, 217, 207);
            J11.BackColor = Color.FromArgb(216, 217, 207);
            J11.BackgroundColor = Color.FromArgb(216, 217, 207);
            J12.BackColor = Color.FromArgb(216, 217, 207);
            J12.BackgroundColor = Color.FromArgb(216, 217, 207);
            J13.BackColor = Color.FromArgb(216, 217, 207);
            J13.BackgroundColor = Color.FromArgb(216, 217, 207);
            J14.BackColor = Color.FromArgb(216, 217, 207);
            J14.BackgroundColor = Color.FromArgb(216, 217, 207);
            J15.BackColor = Color.FromArgb(216, 217, 207);
            J15.BackgroundColor = Color.FromArgb(216, 217, 207);
            J16.BackColor = Color.FromArgb(216, 217, 207);
            J16.BackgroundColor = Color.FromArgb(216, 217, 207);
            J17.BackColor = Color.FromArgb(216, 217, 207);
            J17.BackgroundColor = Color.FromArgb(216, 217, 207);
            W4.BackColor = Color.FromArgb(185, 224, 255);
            W4.BackgroundColor = Color.FromArgb(185, 224, 255);
            W5.BackColor = Color.FromArgb(185, 224, 255);
            W5.BackgroundColor = Color.FromArgb(185, 224, 255);
            W6.BackColor = Color.FromArgb(185, 224, 255);
            W6.BackgroundColor = Color.FromArgb(185, 224, 255);
            J18.BackColor = Color.FromArgb(216, 217, 207);
            J18.BackgroundColor = Color.FromArgb(216, 217, 207);
            J19.BackColor = Color.FromArgb(216, 217, 207);
            J19.BackgroundColor = Color.FromArgb(216, 217, 207);
            J20.BackColor = Color.FromArgb(216, 217, 207);
            J20.BackgroundColor = Color.FromArgb(216, 217, 207);
            J21.BackColor = Color.FromArgb(216, 217, 207);
            J21.BackgroundColor = Color.FromArgb(216, 217, 207);
            J22.BackColor = Color.FromArgb(216, 217, 207);
            J22.BackgroundColor = Color.FromArgb(216, 217, 207);
            J23.BackColor = Color.FromArgb(216, 217, 207);
            J23.BackgroundColor = Color.FromArgb(216, 217, 207);
            J24.BackColor = Color.FromArgb(216, 217, 207);
            J24.BackgroundColor = Color.FromArgb(216, 217, 207);
            J25.BackColor = Color.FromArgb(216, 217, 207);
            J25.BackgroundColor = Color.FromArgb(216, 217, 207);
            J26.BackColor = Color.FromArgb(216, 217, 207);
            J26.BackgroundColor = Color.FromArgb(216, 217, 207);
            L3.BackColor = Color.FromArgb(164, 190, 123);
            L3.BackgroundColor = Color.FromArgb(164, 190, 123);
            L2.BackColor = Color.FromArgb(164, 190, 123);
            L2.BackgroundColor = Color.FromArgb(164, 190, 123);
            L1.BackColor = Color.FromArgb(164, 190, 123);
            L1.BackgroundColor = Color.FromArgb(164, 190, 123);
            J33.BackColor = Color.FromArgb(216, 217, 207);
            J33.BackgroundColor = Color.FromArgb(216, 217, 207);
            J32.BackColor = Color.FromArgb(216, 217, 207);
            J32.BackgroundColor = Color.FromArgb(216, 217, 207);
            J31.BackColor = Color.FromArgb(216, 217, 207);
            J31.BackgroundColor = Color.FromArgb(216, 217, 207);
            J30.BackColor = Color.FromArgb(216, 217, 207);
            J30.BackgroundColor = Color.FromArgb(216, 217, 207);
            J29.BackColor = Color.FromArgb(216, 217, 207);
            J29.BackgroundColor = Color.FromArgb(216, 217, 207);
            J28.BackColor = Color.FromArgb(216, 217, 207);
            J28.BackgroundColor = Color.FromArgb(216, 217, 207);
            J27.BackColor = Color.FromArgb(216, 217, 207);
            J27.BackgroundColor = Color.FromArgb(216, 217, 207);
            U6.BackColor = Color.FromArgb(174, 189, 202);
            U6.BackgroundColor = Color.FromArgb(174, 189, 202);
            U5.BackColor = Color.FromArgb(174, 189, 202);
            U5.BackgroundColor = Color.FromArgb(174, 189, 202);
            U4.BackColor = Color.FromArgb(174, 189, 202);
            U4.BackgroundColor = Color.FromArgb(174, 189, 202);
            U3.BackColor = Color.FromArgb(174, 189, 202);
            U3.BackgroundColor = Color.FromArgb(174, 189, 202);
            U2.BackColor = Color.FromArgb(174, 189, 202);
            U2.BackgroundColor = Color.FromArgb(174, 189, 202);
            U1.BackColor = Color.FromArgb(174, 189, 202);
            U1.BackgroundColor = Color.FromArgb(174, 189, 202);
            H1.BackColor = Color.FromArgb(220, 0, 0);
            H1.BackgroundColor = Color.FromArgb(220, 0, 0);
            H2.BackColor = Color.FromArgb(220, 0, 0);
            H2.BackgroundColor = Color.FromArgb(220, 0, 0);
            H3.BackColor = Color.FromArgb(220, 0, 0);
            H3.BackgroundColor = Color.FromArgb(220, 0, 0);


        }
        private void Frm_tst_Load(object sender, EventArgs e)
        {
            Jars();
            Constr = RequiredVariables.DBConnStr;
            con.ConnectionString = Constr;
            if (con.State == ConnectionState.Closed)
                con.Open();

            loadPositiondetails_db();
            ////getavailableportnames();
            init_port(); 
            System.Threading.Thread.Sleep(5000);
            RequiredVariables.EngineeringMode_Started = true;
            movetohome();
        }
        private void jarpositions()
        {

            if (rdn_roboticarm1.Checked == false && rdn_roboticarm2.Checked == false && cmbJarnumber.Text == "")
            {
                //reader.SpeakAsync("Please select the jar number and robotic arm");
                MessageBox.Show("Please select the jar number and robotic arm", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (rdn_roboticarm1.Checked == false && rdn_roboticarm2.Checked == false && cmbJarnumber.Text != "")
            {
                //reader.SpeakAsync("Please select which robotic arm to operate with");
                MessageBox.Show("Please select which robotic arm to operate with", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (rdn_roboticarm1.Checked == true && rdn_roboticarm2.Checked == false && cmbJarnumber.Text == "")
            {
                //reader.SpeakAsync("Please select the jar number");
                MessageBox.Show("Please select the jar number", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (rdn_roboticarm1.Checked == false && rdn_roboticarm2.Checked == true && cmbJarnumber.Text == "")
            {
                //reader.SpeakAsync("Please select the jar number");
                MessageBox.Show("Please select the jar number", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //string selectedItem = cmbJarnumber.Items[cmbJarnumber.SelectedIndex].ToString();

        private void loadPositiondetails_db()
        {
            try
            {
                string sqlstr = "";
                sqlstr = "select * from JarPosDeatils order by sno";
                SqlDataAdapter sda = new SqlDataAdapter(sqlstr, con);
                JPos_DB = new DataTable();
                sda.Fill(JPos_DB);
                if (JPos_DB.Rows.Count > 0)
                {
                    cmbJarnumber.Items.Clear();
                    cmbJarnumber.Items.Add("Select");
                    for (int i = 0; i < JPos_DB.Rows.Count; i++)
                    {
                        cmbJarnumber.Items.Add(JPos_DB.Rows[i]["JarName"].ToString());
                        refresh_UI(JPos_DB.Rows[i]["JarName"].ToString(), "");
                    }
                    cmbJarnumber.SelectedIndex = 0;
                }
            }
            catch (Exception d3)
            {
                MessageBox.Show(d3.ToString(), "Load position details from database", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
                        cmbJarnumber.Items.Clear();
                        cmbJarnumber.Items.Add("Select");
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
                            cmbJarnumber.Items.Add(jarposval[0].ToString());
                            refresh_UI(jarposval[0].ToString(), "");
                        }
                    }
                    cmbJarnumber.SelectedIndex = 0;
                }
            }
            catch (Exception d3)
            {
                MessageBox.Show(d3.ToString(), "Load position details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        SpeechSynthesizer reader = new SpeechSynthesizer();
        int functioncode = 0;
        private void btn_RA_Click(object sender, EventArgs e)
        {
            try
            {
                string sndcmdstr = "";
                if (rdn_roboticarm1.Checked == true)
                    Communication.RA_No = 1;
                else if (rdn_roboticarm2.Checked == true)
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

                sndcmdstr = "";

                if (opt_move.Checked == true)
                {
                    sndcmdstr = txt_Xvalue.Text + "," + txt_Yvalue.Text + "," + txt_Zvalue.Text;
                }
                else if ((opt_pick.Checked == true) || (opt_place.Checked == true))
                {
                    if ((JarName == "H1") || (JarName == "H2") || (JarName == "H3"))
                    {
                        sndcmdstr = txt_Xvalue.Text + "," + txt_Yvalue.Text + "," + txt_Zvalue.Text + ",1";
                    }
                    else
                    {
                        sndcmdstr = txt_Xvalue.Text + "," + txt_Yvalue.Text + "," + txt_Zvalue.Text + ",0";
                    }
                }
                else if (opt_Diprack.Checked == true)
                {
                    sndcmdstr = txt_Xvalue.Text + "," + txt_Yvalue.Text + ",2,1,1";
                }
                repeatval = 0;
                if (repeatval == 0)
                {
                    Communication.framed_cmd = "";
                }

                snd_rcvCmd(functioncode, sndcmdstr);
            }
            catch (Exception d3)
            {

            }

           
        }

        private void cmbJarnumber_KeyPress(object sender, KeyPressEventArgs e)
        {
             
        }       
        private void cmbJarnumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            load_jarposdetails_db();
        }
        int slnval = 0, inxSlno=0;
        string JarName = "";
        private void load_jarposdetails_file_db()
        {
            try
            {
                string st1 = "";

                if (cmbJarnumber.Text == "Select")
                    return;
                DataRow[] resut = JPos.Select("JarNo ='" + cmbJarnumber.Text + "'");
                if (resut.Length > 0)
                {
                    slnval = Convert.ToInt32(resut[0]["SlNo"].ToString());
                    JarName = resut[0]["JarNo"].ToString();
                    txt_Xvalue.Text = resut[0]["X-Axis"].ToString();
                    txt_Yvalue.Text = resut[0]["Y-Axis"].ToString();
                    txt_Zvalue.Text = resut[0]["Z1-Axis"].ToString();
                    //txt_Z2Val.Text = resut[0]["Z2-Axis"].ToString();
                }
                inxSlno = 0;
            }
            catch (Exception d3)
            {

            }
        }

        private void load_jarposdetails_db()
        {
            try
            {
                string st1 = "";

                if (cmbJarnumber.Text == "Select")
                    return;
                DataRow[] resut = JPos_DB.Select("JarName ='" + cmbJarnumber.Text + "'");
                if (resut.Length > 0)
                {
                    slnval = Convert.ToInt32(resut[0]["Sno"].ToString());
                    JarName = resut[0]["JarName"].ToString();
                    txt_Xvalue.Text = resut[0]["XPos"].ToString();
                    txt_Yvalue.Text = resut[0]["YPos"].ToString();
                    txt_Zvalue.Text = resut[0]["Z1Pos"].ToString();
                    //txt_Z2Val.Text = resut[0]["Z2-Axis"].ToString();
                }
                inxSlno = 0;
            }
            catch (Exception d3)
            {

            }
        }

        private void cmbJarnumber_SelectedValueChanged(object sender, EventArgs e)
        {
            //     jarxyzvalues();
        }

        private void rdn_roboticarm2_CheckedChanged(object sender, EventArgs e)
        {
            Communication.RA_No = 2;          
        }

        private void rdn_roboticarm1_CheckedChanged(object sender, EventArgs e)
        {
            Communication.RA_No = 1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            RequiredVariables.EngineeringMode_Started = false;
            if (mport.IsOpen == true)
                mport.Close();
            //Closing comport
            this.Close();
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
           pnl_Jars.Visible = false;
        }

        private void heater1_Load(object sender, EventArgs e)
        {

        }

        private void heater1_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(220, 0, 0);
            jar_Large.BackgroundColor = Color.FromArgb(220, 0, 0);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "";
            jar_Large.RackNumber = "H1";
            jar_Large.TaskProcess = "70°C";
            jar_Large.ForeColor = Color.White;
            if (H1.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void heater2_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(220, 0, 0);
            jar_Large.BackgroundColor = Color.FromArgb(220, 0, 0);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "";
            jar_Large.RackNumber = "H2";
            jar_Large.TaskProcess = "70°C";
            jar_Large.ForeColor = Color.White;
            if (H2.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void heater3_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(220, 0, 0);
            jar_Large.BackgroundColor = Color.FromArgb(220, 0, 0);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "";
            jar_Large.RackNumber = "H3";
            jar_Large.TaskProcess = "70°C";
            jar_Large.ForeColor = Color.White;
            if (H3.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar1_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "XYLENE-1";
            jar_Large.RackNumber = "J01";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J1.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar2_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "XYLENE-2";
            jar_Large.RackNumber = "J02";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J2.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar3_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "XYLENE-3";
            jar_Large.RackNumber = "J03";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J3.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar4_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "100% Alcohol";
            jar_Large.RackNumber = "J04";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J4.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar5_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "70% Alcohol";
            jar_Large.RackNumber = "J05";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J5.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar6_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "50% Alcohol";
            jar_Large.RackNumber = "J06";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J6.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar7_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "DI water";
            jar_Large.RackNumber = "J07";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J7.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar8_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "DI water";
            jar_Large.RackNumber = "J08";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J8.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar9_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "H&E";
            jar_Large.RackNumber = "J09";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J9.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar24_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "1% Acid Alcohol";
            jar_Large.RackNumber = "J24";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J18.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar25_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "LI2CO3";
            jar_Large.RackNumber = "J25";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J19.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar26_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "Eosin";
            jar_Large.RackNumber = "J26";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J20.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar27_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "95% Alcohol";
            jar_Large.RackNumber = "J27";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J21.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar28_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "100% Alcohol";
            jar_Large.RackNumber = "J28";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J22.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar29_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "100% Alcohol";
            jar_Large.RackNumber = "J29";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J23.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar30_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "XYLENE-1";
            jar_Large.RackNumber = "J30";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J24.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar31_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "XYLENE-2";
            jar_Large.RackNumber = "J31";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J25.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar32_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "XYLENE-3";
            jar_Large.RackNumber = "J32";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J26.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar36_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "RNJ";
            jar_Large.RackNumber = "J36";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J33.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar37_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "RNJ";
            jar_Large.RackNumber = "J37";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J32.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar38_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "RNJ";
            jar_Large.RackNumber = "J38";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J31.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar39_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "PAP";
            jar_Large.ReagentName = "XYLENE 2'";
            jar_Large.RackNumber = "J39";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J30.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar40_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "PAP";
            jar_Large.ReagentName = "XYLENE 2'";
            jar_Large.RackNumber = "J40";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J29.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar41_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "PAP";
            jar_Large.ReagentName = "100% Ethanol 1'";
            jar_Large.RackNumber = "J41";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J28.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar42_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "PAP";
            jar_Large.ReagentName = "95% Ethanol";
            jar_Large.RackNumber = "J42";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J27.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar33_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(164, 190, 123);
            jar_Large.BackgroundColor = Color.FromArgb(164, 190, 123);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "I/P";
            jar_Large.RackNumber = "J33";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (L3.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar34_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(164, 190, 123);
            jar_Large.BackgroundColor = Color.FromArgb(164, 190, 123);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "I/P";
            jar_Large.RackNumber = "J34";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (L2.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar35_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(164, 190, 123);
            jar_Large.BackgroundColor = Color.FromArgb(164, 190, 123);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "I/P";
            jar_Large.RackNumber = "J35";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (L1.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar10_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(185, 224, 255);
            jar_Large.BackgroundColor = Color.FromArgb(185, 224, 255);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "H2O";
            jar_Large.RackNumber = "J10";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (W1.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar11_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(185, 224, 255);
            jar_Large.BackgroundColor = Color.FromArgb(185, 224, 255);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "H2O";
            jar_Large.RackNumber = "J11";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (W2.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar12_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(185, 224, 255);
            jar_Large.BackgroundColor = Color.FromArgb(185, 224, 255);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "H2O";
            jar_Large.RackNumber = "J12";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (W3.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar23_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(185, 224, 255);
            jar_Large.BackgroundColor = Color.FromArgb(185, 224, 255);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "H2O";
            jar_Large.RackNumber = "J23";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (W6.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar22_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(185, 224, 255);
            jar_Large.BackgroundColor = Color.FromArgb(185, 224, 255);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "H2O";
            jar_Large.RackNumber = "J22";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (W5.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar21_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(185, 224, 255);
            jar_Large.BackgroundColor = Color.FromArgb(185, 224, 255);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "H2O";
            jar_Large.RackNumber = "J21";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (W4.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar43_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(174, 189, 202);
            jar_Large.BackgroundColor = Color.FromArgb(174, 189, 202);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "O/P";
            jar_Large.RackNumber = "J43";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (U6.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar44_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(174, 189, 202);
            jar_Large.BackgroundColor = Color.FromArgb(174, 189, 202);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "O/P";
            jar_Large.RackNumber = "J44";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (U5.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar45_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(174, 189, 202);
            jar_Large.BackgroundColor = Color.FromArgb(174, 189, 202);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "O/P";
            jar_Large.RackNumber = "J45";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (U4.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar46_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(174, 189, 202);
            jar_Large.BackgroundColor = Color.FromArgb(174, 189, 202);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "O/P";
            jar_Large.RackNumber = "J46";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (U3.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar47_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(174, 189, 202);
            jar_Large.BackgroundColor = Color.FromArgb(174, 189, 202);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "O/P";
            jar_Large.RackNumber = "J47";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (U2.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar48_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(174, 189, 202);
            jar_Large.BackgroundColor = Color.FromArgb(174, 189, 202);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "HE1";
            jar_Large.ReagentName = "O/P";
            jar_Large.RackNumber = "J48";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (U1.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar17_Load(object sender, EventArgs e)
        {

        }

        private void jar17_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "PAP";
            jar_Large.ReagentName = "OG_6 Stain";
            jar_Large.RackNumber = "J17";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J14.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar18_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "PAP";
            jar_Large.ReagentName = "Ethanol95%";
            jar_Large.RackNumber = "J18";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J15.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar19_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "PAP";
            jar_Large.ReagentName = "EA-65 Stain";
            jar_Large.RackNumber = "J19";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J16.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar20_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "PAP";
            jar_Large.ReagentName = "95% Ethanol";
            jar_Large.RackNumber = "J20";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J17.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar13_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "PAP";
            jar_Large.ReagentName = "Hematoxylin8'";
            jar_Large.RackNumber = "J13";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J10.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar14_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "PAP";
            jar_Large.ReagentName = "Acid Alcohol 1% 30'";
            jar_Large.RackNumber = "J14";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J11.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar15_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "PAP";
            jar_Large.ReagentName = "LI2CO3";
            jar_Large.RackNumber = "J15";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);
            if (J12.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void jar16_Click(object sender, EventArgs e)
        {
            pnl_Jars.Visible = true;
            jar_Large.BackColor = Color.FromArgb(216, 217, 207);
            jar_Large.BackgroundColor = Color.FromArgb(216, 217, 207);
            jar_Large.BorderSize =3;
            jar_Large.OnlyJar = true;
            jar_Large.ProcessName = "PAP";
            jar_Large.ReagentName = "Ethanol95%";
            jar_Large.RackNumber = "J16";
            jar_Large.TaskProcess = "0%";
            jar_Large.ForeColor = Color.FromArgb(30, 80, 150);  
            if (J13.JarRack == true)
            {
                jar_Large.JarRack = true;
            }
        }

        private void opt_move_CheckedChanged(object sender, EventArgs e)
        {
            btn_RA.Text = "Move RA";
            btn_RA.ForeColor = Color.White;
            btn_RA.BackColor = opt_move.ForeColor;
        }

        private void opt_pick_CheckedChanged(object sender, EventArgs e)
        {
            btn_RA.Text = "Pick Rack";
            btn_RA.ForeColor = Color.White;
            btn_RA.BackColor = opt_pick.ForeColor;
        }

        private void opt_place_CheckedChanged(object sender, EventArgs e)
        {
            btn_RA.Text = "Place Rack";
            btn_RA.ForeColor = Color.White;
            btn_RA.BackColor = opt_place.ForeColor;
        }

        private void opt_Diprack_CheckedChanged(object sender, EventArgs e)
        {
            btn_RA.Text = "Dip Rack";
            btn_RA.ForeColor = Color.White;
            btn_RA.BackColor = opt_Diprack.ForeColor;
        }

        //Updating the position details and inserting the calibrated person details
        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                String arm1 = "";
                //Updating the Position details to databae
                try
                {
                    sqlstr = "";
                    sqlstr = "Update JarPosDeatils set XPos = " + Convert.ToInt32(txt_Xvalue.Text) + ",YPos = " + Convert.ToInt32(txt_Xvalue.Text);
                    sqlstr = sqlstr + ",Z1Pos = " + Convert.ToInt32(txt_Zvalue.Text) + " where JarName = '" + cmbJarnumber.Text + "' and Sno = " + slnval;
                    cmd = new SqlCommand(sqlstr, con);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch(Exception gh)
                {

                }
                //Inserting the details of calibrated by
                try
                {
                    if (rdn_roboticarm1.Checked == true)
                        arm1 = "RA-1";
                    else if (rdn_roboticarm2.Checked == true)
                        arm1 = "RA-2";

                    sqlstr = "";
                    sqlstr = "Insert into JarpositionCalibration(RoboticArm,JarParameterName,Xaxis,Yaxis,Zaxis,Calibratedby,Calibratedon,CalibratedTime,Month) values('";
                    sqlstr = sqlstr + arm1 + "','" + cmbJarnumber.Text + "','" + txt_Xvalue.Text + "','" + txt_Yvalue.Text + "','" + txt_Zvalue.Text + "','";
                    // + RequiredVariables.UserName + "','";
                    //String s = DateTime.Now.ToString("dd-MM-yyyy");

                    // reader.SpeakAsync("Robotic Arm 1");
                    //reader.SpeakAsync(cmbJarnumber.Text);
                    String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                    string s2 = DateTime.Now.ToString("dd-MM-yyyy");
                    String m1 = DateTime.Now.ToString("MMMM");
                    sqlstr = sqlstr + RequiredVariables.UserName + "','" + s2 + "','" + s1 + "','" + m1 + "')";
                    cmd = new SqlCommand(sqlstr, con);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    //lbl_Status.Text = "Status : Moving Robotic Arm 1 " + cmbJarnumber.Text;
                }
                catch(Exception gh)
                {

                }

            }
            catch(Exception de)
            {

            }

        }

        private void btn_rahome_Click(object sender, EventArgs e)
        {
            movetohome();
        }
        private void movetohome()
        {
            ////Communication.RA_No = 0; //commented on 17-02-2024
            CommandName = "Home Command";
            repeatval = 0;
            if (repeatval == 0)
            {
                Communication.framed_cmd = "";
            }
            CommandName = "Home Command";
            functioncode = Communication.RA_HOME;
            snd_rcvCmd(Communication.RA_HOME, "11111111");
        }

        #region Communication
        Boolean pGotByteFlag = false, port_avail=false, rareached=false, pCancelFlag=false;
        Boolean m_ProcessStoped = false, swpause = false, swresume = false, hwresume = false, hwpause = false, cmdprocesscmp = true;

        string displayScrData = "";
        string CommandName = "", mslave_Id = "", valno = "";
        string framed_Data = "";
        Boolean valonflg = false, valoffflg = false;
        Boolean htr_door_open = false, htr_door_close = false, htr_on = false, htr_off = false;
        SerialPort mport = new SerialPort();
        int sent_func_code = 0, repeatval=0;
        private void getavailableportnames()
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
                        lbl_Status.Text = "Checking Communication Ports and Re-establsihing Communication with device Please be patiance..";
                        lbl_Status.BackColor = Color.Navy;
                        this.Cursor = Cursors.WaitCursor;
                        Communication.devid = 1;
                        pGotByteFlag = false;
                        Communication.resultvalue = "";
                        lbl_Status.Text = "";
                        ////Making machine to wait for 30 seconds for RA to reach home as port reintiated in PC side or in machine
                        System.Threading.Thread.Sleep(13000);  ////Taken time delay in milli seconds
                                                               ////Sending RA home command to device.
                        lbl_Status.Text = Communication.portname + " : Opened for communication";
                        lbl_Status.BackColor = Color.Green;
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
        private void snd_rcvCmd(int func_code, string m_CmdData)
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

                if (mport.IsOpen == false)
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
        protected override void WndProc(ref Message m)
        {
            try
            {
                const int WM_DEVICECHANGE = 0x0219;
                //const int DBT_DEVICEARRIVAL = 0x8000;
                //const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
                //const int DBT_DEVTYP_PORT = 0x00000003;
                switch (m.Msg)
                {
                    case WM_DEVICECHANGE:
                        {
                            //Checkvcpcom();
                            if (mport.IsOpen == true)
                                mport.Close();
                            lbl_Status.Text = Communication.portname + " : Closed for communication with device.... Trying to Re-establish Communication with Device Please be Patiance....";
                            lbl_Status.BackColor = Color.Red;
                            lbl_Status.ForeColor = Color.White;

                            getavailableportnames();
                            break;
                        }
                    default:
                        break;
                }
                base.WndProc(ref m);
            }
            catch (ObjectDisposedException)
            {

            }
            catch
            {

            }
        }

        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            try
            {
                Application.DoEvents();
                // InvokeRequired required compares the thread ID of the
                // calling thread to the thread ID of the creating thread.
                // If these threads are different, it returns true.
                if (this.lbl_Status.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {                    
                    this.lbl_Status.Text = text;
                }
            }
            catch (Exception d3)
            {
                MessageBox.Show(d3.ToString() + "While updating the text to display ", RequiredVariables.Msgtext, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }
        private void refresh_UI(string refjarname, string regName)
        {
            string prtname = " ";
            switch (refjarname)
            {
                case "J1":
                    {
                        J1.ProcessName = prtname;
                        J1.ReagentName = regName;
                        J1.OnlyJar = true;
                        J1.BorderSize = 3;
                        break;
                    }
                case "J2":
                    {
                        J2.ProcessName = prtname;
                        J2.ReagentName = regName;
                        J2.OnlyJar = true;
                        J2.BorderSize = 3;
                        break;
                    }
                case "J3":
                    {
                        J3.ProcessName = prtname;
                        J3.ReagentName = regName;
                        J3.OnlyJar = true;
                        J3.BorderSize = 3;
                        break;
                    }
                case "J4":
                    {
                        J4.ProcessName = prtname;
                        J4.ReagentName = regName;
                        J4.BorderSize = 3;
                        J4.OnlyJar = true;
                        break;
                    }
                case "J5":
                    {
                        J5.ProcessName = prtname;
                        J5.ReagentName = regName;
                        J5.OnlyJar = true;
                        J5.BorderSize = 3;
                        break;
                    }
                case "J6":
                    {
                        J6.ProcessName = prtname;
                        J6.ReagentName = regName;
                        J6.OnlyJar = true;
                        J6.BorderSize = 3;
                        break;
                    }
                case "J7":
                    {
                        J7.ProcessName = prtname;
                        J7.ReagentName = regName;
                        J7.OnlyJar = true; J7.BorderSize = 3;
                        break;
                    }
                case "J8":
                    {
                        J8.ProcessName = prtname;
                        J8.ReagentName = regName;
                        J8.OnlyJar = true; J8.BorderSize = 3;
                        break;
                    }
                case "J9":
                    {
                        J9.ProcessName = prtname;
                        J9.ReagentName = regName;
                        J9.OnlyJar = true; J9.BorderSize = 3;
                        break;
                    }
                case "J10":
                    {
                        J10.ProcessName = prtname;
                        J10.ReagentName = regName;
                        J10.OnlyJar = true; J10.BorderSize = 3;
                        break;
                    }
                case "J11":
                    {
                        J11.ProcessName = prtname;
                        J11.ReagentName = regName;
                        J11.OnlyJar = true; J11.BorderSize = 3;
                        break;
                    }
                case "J12":
                    {
                        J12.ProcessName = prtname;
                        J12.ReagentName = regName;
                        J12.OnlyJar = true; J12.BorderSize = 3;
                        break;
                    }
                case "J13":
                    {
                        J13.ProcessName = prtname;
                        J13.ReagentName = regName;
                        J13.OnlyJar = true; J13.BorderSize = 3;
                        break;
                    }
                case "J14":
                    {
                        J14.ProcessName = prtname;
                        J14.ReagentName = regName;
                        J14.OnlyJar = true; J14.BorderSize = 3;
                        break;
                    }
                case "J15":
                    {
                        J15.ProcessName = prtname;
                        J15.ReagentName = regName;
                        J15.OnlyJar = true; J15.BorderSize = 3;
                        break;
                    }
                case "J16":
                    {
                        J16.ProcessName = prtname;
                        J16.ReagentName = regName;
                        J16.OnlyJar = true; J16.BorderSize = 3;
                        break;
                    }
                case "J17":
                    {
                        J17.ProcessName = prtname;
                        J17.ReagentName = regName;
                        J17.OnlyJar = true; J17.BorderSize = 3;
                        break;
                    }
                case "J18":
                    {
                        J18.ProcessName = prtname;
                        J18.ReagentName = regName;
                        J18.OnlyJar = true; J18.BorderSize = 3;
                        break;
                    }
                case "J19":
                    {
                        J19.ProcessName = prtname;
                        J19.ReagentName = regName;
                        J19.OnlyJar = true; J19.BorderSize = 3;
                        break;
                    }
                case "J20":
                    {
                        J20.ProcessName = prtname;
                        J20.ReagentName = regName;
                        J20.OnlyJar = true; J20.BorderSize = 3;
                        break;
                    }
                case "J21":
                    {
                        J21.ProcessName = prtname;
                        J21.ReagentName = regName;
                        J21.OnlyJar = true; J21.BorderSize = 3;
                        break;
                    }
                case "J22":
                    {
                        J22.ProcessName = prtname;
                        J22.ReagentName = regName;
                        J22.OnlyJar = true; J22.BorderSize = 3;
                        break;
                    }
                case "J23":
                    {
                        J23.ProcessName = prtname;
                        J23.ReagentName = regName;
                        J23.OnlyJar = true; J23.BorderSize = 3;
                        break;
                    }
                case "J24":
                    {
                        J24.ProcessName = prtname;
                        J24.ReagentName = regName;
                        J24.OnlyJar = true; J24.BorderSize = 3;
                        break;
                    }
                case "J25":
                    {
                        J25.ProcessName = prtname;
                        J25.ReagentName = regName;
                        J25.OnlyJar = true; J25.BorderSize = 3;
                        break;
                    }
                case "J26":
                    {
                        J26.ProcessName = prtname;
                        J26.ReagentName = regName;
                        J26.OnlyJar = true; J26.BorderSize = 3;
                        break;
                    }
                case "J27":
                    {
                        J27.ProcessName = prtname;
                        J27.ReagentName = regName;
                        J27.OnlyJar = true; J27.BorderSize = 3;
                        break;
                    }
                case "J28":
                    {
                        J28.ProcessName = prtname;
                        J28.ReagentName = regName;
                        J28.OnlyJar = true; J28.BorderSize = 3;
                        break;
                    }
                case "J29":
                    {
                        J29.ProcessName = prtname;
                        J29.ReagentName = regName;
                        J29.OnlyJar = true; J29.BorderSize = 3;
                        break;
                    }
                case "J30":
                    {
                        J30.ProcessName = prtname;
                        J30.ReagentName = regName;
                        J30.OnlyJar = true; J30.BorderSize = 3;
                        break;
                    }
                case "J31":
                    {
                        J31.ProcessName = prtname;
                        J31.ReagentName = regName;
                        J31.OnlyJar = true; J31.BorderSize = 3;
                        break;
                    }
                case "J32":
                    {
                        J32.ProcessName = prtname;
                        J32.ReagentName = regName;
                        J32.OnlyJar = true; J32.BorderSize = 3;
                        break;
                    }
                case "J33":
                    {
                        J33.ProcessName = prtname;
                        J33.ReagentName = regName;
                        J33.OnlyJar = true; J33.BorderSize = 3;
                        break;
                    }
                case "W1":
                    {
                        W1.ProcessName = prtname;
                        W1.ReagentName = regName;
                        W1.OnlyJar = true; W1.BorderSize = 3;
                        break;
                    }
                case "W2":
                    {
                        W2.ProcessName = prtname;
                        W2.ReagentName = regName;
                        W2.OnlyJar = true; W2.BorderSize = 3;
                        break;
                    }
                case "W3":
                    {
                        W3.ProcessName = prtname;
                        W3.ReagentName = regName;
                        W3.OnlyJar = true; W3.BorderSize = 3;
                        break;
                    }
                case "W4":
                    {
                        W4.ProcessName = prtname;
                        W4.ReagentName = regName;
                        W4.OnlyJar = true; W4.BorderSize = 3;
                        break;
                    }
                case "W5":
                    {
                        W5.ProcessName = prtname;
                        W5.ReagentName = regName;
                        W5.OnlyJar = true; W5.BorderSize = 3;
                        break;
                    }
                case "W6":
                    {
                        W6.ProcessName = prtname;
                        W6.ReagentName = regName;
                        W6.OnlyJar = true; W6.BorderSize = 3;
                        break;
                    }
                case "U1":
                    {
                        U1.ProcessName = prtname;
                        U1.ReagentName = regName;
                        U1.OnlyJar = true; U1.BorderSize = 3;
                        break;
                    }
                case "U2":
                    {
                        U2.ProcessName = prtname;
                        U2.ReagentName = regName;
                        U2.OnlyJar = true; U2.BorderSize = 3;
                        break;
                    }
                case "U3":
                    {
                        U3.ProcessName = prtname;
                        U3.ReagentName = regName;
                        U3.OnlyJar = true; U3.BorderSize = 3;
                        break;
                    }
                case "U4":
                    {
                        U4.ProcessName = prtname;
                        U4.ReagentName = regName;
                        U4.OnlyJar = true; U4.BorderSize = 3;
                        break;
                    }
                case "U5":
                    {
                        U5.ProcessName = prtname;
                        U5.ReagentName = regName;
                        U5.OnlyJar = true; U5.BorderSize = 3;
                        break;
                    }
                case "U6":
                    {
                        U6.ProcessName = prtname;
                        U6.ReagentName = regName;
                        U6.OnlyJar = true; U6.BorderSize = 3;
                        break;
                    }
                case "L1":
                    {
                        L1.ReagentName = regName;
                        L1.OnlyJar = true; L1.BorderSize = 3;
                        break;
                    }
                case "L2":
                    {
                        L2.ReagentName = regName;
                        L2.OnlyJar = true; L2.BorderSize = 3;
                        break;
                    }
                case "L3":
                    {
                        L3.ReagentName = regName;
                        L3.OnlyJar = true; L3.BorderSize = 3;
                        break;
                    }
                case "H1":
                    {
                        H1.ReagentName = regName;
                        H1.OnlyJar = true; H1.BorderSize = 3;
                        break;
                    }
                case "H2":
                    {
                        H2.ReagentName = regName;
                        H2.OnlyJar = true; H2.BorderSize = 3;
                        break;
                    }
                case "H3":
                    {
                        H3.ReagentName = regName;
                        H3.OnlyJar = true; H3.BorderSize = 3;
                        break;
                    }
            }
        }
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
                            
                            break;
                        }
                    case 4: //Level Sensing With RA
                        {
                            displayScrData = "";
                            if ((respval == "000") && (rtype == "F"))
                            {
                                string[] lvl = Jarr[3].Split('*');
                                displayScrData = "Level Sense Value : " + lvl[0].ToString();                                
                            }
                            else
                            {
                                displayScrData = "Level Sense Value  : " + msgdisp;
                            }
                            SetText(displayScrData);
                            
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
                            break;
                        }
                    case 6: //Get Home Status
                        {

                            displayScrData = "";
                            if ((respval == "000") && (rtype == "F"))
                            {
                                if (Jarr[3].Substring(0, 8) == "11111111")
                                    displayScrData = "All axis are in Home";
                                else
                                {
                                    string st11 = Jarr[3].Substring(0, 8);
                                    for (int k = 0; k < st11.Length; k++)
                                    {
                                        if (st11.Substring(k, 1) == "1")
                                        {
                                            if (k == 0)
                                            {
                                                displayScrData = "Heater Door Opened";
                                            }
                                            else if (k == 1)
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
                            }
                            else
                            {
                                displayScrData = "Doors Status " + msgdisp;
                            }
                            SetText(displayScrData);                           
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
                                
                            }
                            else
                            {
                                displayScrData = "Temperature  : " + msgdisp;
                                tmpval = "--";
                            }
                            SetText(displayScrData);  
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
                            break;
                        }
                    case 16: //Agitation Control
                        {
                            displayScrData = "";
                            if ((respval == "000") && (rtype == "F"))
                            {                                
                                  displayScrData = "Agitation Started / Stopped ";
                            }
                            else
                            {
                                displayScrData = "Agitation Control " + msgdisp;
                            }
                            SetText(displayScrData);                           
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
        #endregion
    }
}
