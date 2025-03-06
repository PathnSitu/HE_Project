using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.IO.Ports;
using System.Management;

namespace HematoxinandEosin
{
    public partial class Form_MainMenu : Form
    {
        // string FilePath = @"G:\projects\mukesh\Login\UsrDetails.txt";
        string Constr = "";//"Data Source=SYSPSENG005;User ID=sa;Password=sree@pns2013;Initial Catalog=PNSHE;Pooling=false;Max Pool Size=400;workstation id =SYSPSENG006";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        // DataTable table = new DataTable("table");
        SqlDataAdapter sda = new SqlDataAdapter();
        string sqlstr;
        //string FilePath = Path.Combine(@"G:\projects\mukesh\Login", DateTime.Today.ToString("dd/MM/yyyy") + ".txt");
        // string FilePath =Path.Combine(@"G:\projects\mukesh\Login", DateTime.Today.ToString("LoginDetails_dd/MM/yyyy") + ".csv");

        //Form2 f2 = new Form2();
        clsResize form_resize;
        string CommandName = "";
        int retrycnt = 0, sent_func_code = 0, repeatval = 0, functioncode = 0;
        public Form_MainMenu()
        {
            InitializeComponent();
            //form_resize = new clsResize(this);
            //this.Load += _Load;
            //this.Resize += _Resize;
            //rzform();
            //var screen = Screen.PrimaryScreen;
            //var width = screen.Bounds.Width;
            //var height = screen.Bounds.Height;

            //// Set the form's size to match the screen resolution
            //this.ClientSize = new System.Drawing.Size(width, height);
            ////StartPosition = FormStartPosition.Manual;
            ////Rectangle screen = Screen.FromPoint(Cursor.Position).WorkingArea;
            ////int w = Width >= screen.Width ? screen.Width : (screen.Width + Width) / 2;
            ////int h = Height >= screen.Height ? screen.Height : (screen.Height + Height) / 2;
            ////Location = new Point(screen.Left + (screen.Width - w) / 2, screen.Top + (screen.Height - h) / 2);
            ////Size = new Size(w, h);

            //ResizeForm();
            //int h = Screen.PrimaryScreen.WorkingArea.Height;
            //int w = Screen.PrimaryScreen.WorkingArea.Width;
            //this.ClientSize = new Size(w, h);
        }

        private void rzform()
        {
            // Get the current screen resolution
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // Calculate the new size of the form
            int newWidth = (int)(screenWidth * 1);
            int newHeight = (int)(screenHeight * 1);

            // Set the new size of the form
            this.Size = new Size(newWidth, newHeight);

        }

        private void ResizeForm()
        {
            // Get the screen size
            var screen = Screen.PrimaryScreen.WorkingArea;

            // Set the form's size to be 80% of the screen size
            this.Size = new Size((int)(screen.Width * 1), (int)(screen.Height * 1));
            

            // Center the form on the screen
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void _Load(object sender, EventArgs e)
        {
            form_resize._get_initial_size();
        }

        private void _Resize(object sender, EventArgs e)
        {
            form_resize._resize();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Constr = RequiredVariables.DBConnStr;
            lbl_Timedate.Text = "";
            con.ConnectionString = Constr;
            if (con.State == ConnectionState.Closed)
                con.Open();
            UserType();
            adminPositions();
            userPositions();
            lbl_HE.Text = RequiredVariables.VerNoRevNo;
            ////OpenChildForm(new Form_RunProto());
            getavailableportnames();


            System.Threading.Thread.Sleep(1000);
            if (portopendflg == true)
            {
                if (mport.IsOpen == true)
                    mport.Close();
                OpenChildForm(new Form_RunProto());
                //OpenChildForm(new Enginering_Mode());
            }

        }
        public void adminPositions()
        {
            if (RequiredVariables.Usertype == "Admin")
            {
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                     //btn_Reports.Location = new Point(139, -3);
                    //  btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(139, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Reports.Location = new Point(139, -3);
                    //  btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(280, -3);
                }

                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Calibration.Location = new Point(-2, -3);
                    //  btn_Reports.Location = new Point(280, -3);
                    //  btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(139, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Calibration.Location = new Point(-2, -3);
                    //  btn_Reports.Location = new Point(280, -3);
                    //  btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(139, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Calibration.Location = new Point(-2, -3);
                    //  btn_Reports.Location = new Point(280, -3);
                    //  btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(139, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_RunProtocol.Location = new Point(-2, -3);
                    //  btn_Reports.Location = new Point(280, -3);
                    //  btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(139, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Reports.Location = new Point(-2, -3);
                    //  btn_Reports.Location = new Point(280, -3);
                    //  btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(139, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_User.Location = new Point(-2, -3);
                    //  btn_Reports.Location = new Point(280, -3);
                    //  btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(139, -3);
                }



                if (RequiredVariables.Configuration=="0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    btn_Calibration.Location = new Point(-2, -3);
                    btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    btn_Calibration.Location = new Point(-2, -3);
                    btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    btn_Calibration.Location = new Point(-2, -3);
                    btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(562, -3);
                }

                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Calibration.Location = new Point(-2, -3);
                   // btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(139, -3);
                    btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Calibration.Location = new Point(-2, -3);
                    // btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(139, -3);
                    btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Calibration.Location = new Point(-2, -3);
                    // btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(139, -3);
                    btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }


                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    //btn_Calibration.Location = new Point(-2, -3);
                    btn_RunProtocol.Location = new Point(-2, -3);
                    btn_Reports.Location = new Point(139, -3);
                    btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    //btn_Calibration.Location = new Point(-2, -3);
                    btn_RunProtocol.Location = new Point(-2, -3);
                    //btn_Reports.Location = new Point(139, -3);
                    btn_User.Location = new Point(139, -3);
                    btn_Exit.Location = new Point(280, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    //btn_Calibration.Location = new Point(-2, -3);
                    btn_RunProtocol.Location = new Point(-2, -3);
                    btn_Reports.Location = new Point(139, -3);
                   // btn_User.Location = new Point(139, -3);
                    btn_Exit.Location = new Point(280, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    //btn_Calibration.Location = new Point(-2, -3);
                   // btn_RunProtocol.Location = new Point(-2, -3);
                    btn_Reports.Location = new Point(-2, -3);
                     btn_User.Location = new Point(139, -3);
                    btn_Exit.Location = new Point(280, -3);
                }


                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Calibration.Location = new Point(-2, -3);
                    // btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(139, -3);
                    btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Calibration.Location = new Point(-2, -3);
                    // btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(139, -3);
                    btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }

                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Calibration.Location = new Point(-2, -3);
                    // btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(139, -3);
                    btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }

                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Calibration.Location = new Point(-2, -3);
                  //  btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(139, -3);
                    btn_Exit.Location = new Point(280, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Calibration.Location = new Point(-2, -3);
                    //  btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(139, -3);
                    btn_Exit.Location = new Point(280, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Calibration.Location = new Point(-2, -3);
                    //  btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(139, -3);
                    btn_Exit.Location = new Point(280, -3);
                }

                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    btn_Calibration.Location = new Point(-2, -3);
                     btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    btn_Calibration.Location = new Point(-2, -3);
                    btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    btn_Calibration.Location = new Point(-2, -3);
                    btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }

                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Calibration.Location = new Point(-2, -3);
                    btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    //btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Calibration.Location = new Point(-2, -3);
                    btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    //btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Calibration.Location = new Point(-2, -3);
                    btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    //btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }

                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Calibration.Location = new Point(-2, -3);
                    btn_RunProtocol.Location = new Point(139, -3);
                   // btn_Reports.Location = new Point(280, -3);
                    //btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(280, -3);
                }

                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Calibration.Location = new Point(-2, -3);
                    btn_RunProtocol.Location = new Point(139, -3);
                    // btn_Reports.Location = new Point(280, -3);
                    //btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(280, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Calibration.Location = new Point(-2, -3);
                    btn_RunProtocol.Location = new Point(139, -3);
                    // btn_Reports.Location = new Point(280, -3);
                    //btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(280, -3);
                }

                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Calibration.Location = new Point(-2, -3);
                     btn_Reports.Location = new Point(139, -3);
                    //btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(280, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Calibration.Location = new Point(-2, -3);
                    // btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(139, -3);
                    //btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(280, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Calibration.Location = new Point(-2, -3);
                    // btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(139, -3);
                    //btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(280, -3);
                }

                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    //btn_Calibration.Location = new Point(-2, -3);
                     btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    //btn_Calibration.Location = new Point(-2, -3);
                    btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    //btn_Calibration.Location = new Point(-2, -3);
                    btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    //btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    //btn_Calibration.Location = new Point(-2, -3);
                   // btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(139, -3);
                    btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }

                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    //btn_Calibration.Location = new Point(-2, -3);
                    btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(280, -3);
                   // btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(280, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    //btn_Calibration.Location = new Point(-2, -3);
                    //btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(280, -3);
                     btn_User.Location = new Point(139, -3);
                    btn_Exit.Location = new Point(280, -3);
                }

                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(562, -3);
                }

                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    //btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    //btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    //btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(421, -3);
                }

                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(280 -3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(280 - 3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(280 - 3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    //btn_User.Location = new Point(280 - 3);
                    btn_Exit.Location = new Point(280, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    //btn_User.Location = new Point(280 - 3);
                    btn_Exit.Location = new Point(280, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    //btn_User.Location = new Point(280 - 3);
                    btn_Exit.Location = new Point(280, -3);
                }

                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421 - 3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421 - 3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421 - 3);
                    btn_Exit.Location = new Point(562, -3);
                }

                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    //btn_Reports.Location = new Point(280, -3);
                   // btn_User.Location = new Point(421 - 3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    // btn_User.Location = new Point(421 - 3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    // btn_User.Location = new Point(421 - 3);
                    btn_Exit.Location = new Point(421, -3);
                }

                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    btn_Reports.Location = new Point(421, -3);
                    // btn_User.Location = new Point(421 - 3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    btn_Reports.Location = new Point(421, -3);
                    // btn_User.Location = new Point(421 - 3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    btn_Reports.Location = new Point(421, -3);
                    // btn_User.Location = new Point(421 - 3);
                    btn_Exit.Location = new Point(562, -3);
                }
            }
        }
        public void userPositions()
        {
            if (RequiredVariables.Usertype == "User")
            {
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    
                    btn_Reports.Location = new Point(139, -3);
                    //  btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(280, -3);
                }

                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    //btn_Reports.Location = new Point(139, -3);
                    //  btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(139, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Reports.Location = new Point(139, -3);
                    //  btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(280, -3);
                }

                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //  btn_Reports.Location = new Point(280, -3);
                    //  btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(280 -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //  btn_Reports.Location = new Point(280, -3);
                    //  btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(280, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //  btn_Reports.Location = new Point(280, -3);
                    //  btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(280, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_RunProtocol.Location = new Point(139, -3);
                    //  btn_Reports.Location = new Point(280, -3);
                    //  btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(280, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Reports.Location = new Point(139, -3);
                    //  btn_Reports.Location = new Point(280, -3);
                    //  btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(280, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_User.Location = new Point(139, -3);

                    //  btn_Reports.Location = new Point(280, -3);
                    //  btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(280, -3);
                }



                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    btn_Reports.Location = new Point(421, -3);
                    btn_User.Location = new Point(562, -3);
                    btn_Exit.Location = new Point(703, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    btn_Reports.Location = new Point(421, -3);
                    btn_User.Location = new Point(562, -3);
                    btn_Exit.Location = new Point(703, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    btn_Reports.Location = new Point(421, -3);
                    btn_User.Location = new Point(562, -3);
                    btn_Exit.Location = new Point(703, -3);
                }

                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")

                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    // btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    // btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    // btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(562, -3);
                }


                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    //btn_Calibration.Location = new Point(-2, -3);
                    btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    //btn_Calibration.Location = new Point(-2, -3);
                    btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(139, -3);
                    btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    //btn_Calibration.Location = new Point(-2, -3);
                    btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    // btn_User.Location = new Point(139, -3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    //btn_Calibration.Location = new Point(-2, -3);
                    // btn_RunProtocol.Location = new Point(-2, -3);
                    btn_Reports.Location = new Point(139, -3);
                    btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }





                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    // btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    // btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    // btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(562, -3);
                }

                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //  btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //  btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //  btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }

                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(562, -3);
                }

                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    btn_Reports.Location = new Point(421, -3);
                    //btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    btn_Reports.Location = new Point(421, -3);
                    //btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    btn_Reports.Location = new Point(421, -3);
                    //btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(562, -3);
                }

                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    // btn_Reports.Location = new Point(280, -3);
                    //btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }

                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    // btn_Reports.Location = new Point(280, -3);
                    //btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    // btn_Reports.Location = new Point(280, -3);
                    //btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }

                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    // btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    //btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    // btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    //btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "0" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    // btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    //btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }

                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    //btn_Calibration.Location = new Point(-2, -3);
                    btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    //btn_Calibration.Location = new Point(-2, -3);
                    btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    //btn_Calibration.Location = new Point(-2, -3);
                    btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    //btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    //btn_Calibration.Location = new Point(-2, -3);
                    // btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(139, -3);
                    btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }

                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    //btn_Calibration.Location = new Point(-2, -3);
                    btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    // btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(280, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    //btn_Calibration.Location = new Point(-2, -3);
                    //btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(139, -3);
                    btn_Exit.Location = new Point(280, -3);
                }

                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(562, -3);
                }

                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    //btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    //btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //btn_RunProtocol.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    //btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(421, -3);
                }

                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(280 - 3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(280 - 3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(280 - 3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    //btn_User.Location = new Point(280 - 3);
                    btn_Exit.Location = new Point(280, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    //btn_User.Location = new Point(280 - 3);
                    btn_Exit.Location = new Point(280, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    //btn_RunProtocol.Location = new Point(139, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    //btn_User.Location = new Point(280 - 3);
                    btn_Exit.Location = new Point(280, -3);
                }

                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421 - 3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421 - 3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421 - 3);
                    btn_Exit.Location = new Point(562, -3);
                }

                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    // btn_User.Location = new Point(421 - 3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    // btn_User.Location = new Point(421 - 3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    //btn_Reports.Location = new Point(280, -3);
                    // btn_User.Location = new Point(421 - 3);
                    btn_Exit.Location = new Point(421, -3);
                }

                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    btn_Reports.Location = new Point(421, -3);
                    // btn_User.Location = new Point(421 - 3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    btn_Reports.Location = new Point(421, -3);
                    // btn_User.Location = new Point(421 - 3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Configuration == "1" && RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Configuration.Location = new Point(-2, -3);
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    btn_Reports.Location = new Point(421, -3);
                    // btn_User.Location = new Point(421 - 3);
                    btn_Exit.Location = new Point(562, -3);
                }
            }
        }
        public void UserType()
        {
            if (RequiredVariables.Usertype == "User")
            {
                lbl_UsrType.Text = "User";
                //lbl_ChangePwd.Visible = true;
                //btn_User.Enabled = false;
                //btn_User.Visible = false;
                // btn_Exit.Location.X.ToString(563); = 563,-3;
                // btn_Exit.Location.563.- 3;
                userIcons();
                //btn_Exit.Location = new Point(562, -3);

                //btn_Calibration.Enabled = true;
                //btn_Configuration.Visible = true;
                //changePasswordToolStripMenuItem.Visible = true;
            }
            else if ((RequiredVariables.Usertype == "Admin") || (RequiredVariables.Usertype == "Service"))
            {
                lbl_UsrType.Text = "Admin";
                //lbl_ChangePwd.Visible = false;
                //btn_User.Visible = true;
                //btn_Calibration.Visible = true;
                //btn_Configuration.Visible = true;
                //btn_Reports.Visible = true;
                //btn_RunProtocol.Visible=true;
                changePasswordToolStripMenuItem.Visible = false;
                settingsMenuStrip.Size = new Size(180, 100);
                if (RequiredVariables.JarPositionCalibration == "1")
                    jarPositionsToolStripMenuItem.Enabled = true;
                else if (RequiredVariables.JarPositionCalibration == "0")
                    jarPositionsToolStripMenuItem.Enabled = false;

                if (RequiredVariables.EngParameters == "1")
                    engineeringModeToolStripMenuItem.Enabled = true;
                else if (RequiredVariables.EngParameters == "0")
                    engineeringModeToolStripMenuItem.Enabled = false;

                if (RequiredVariables.Configuration == "1")
                {
                    btn_Configuration.Visible = true;
                    //protocolToolStripMenuItem.Enabled = true;
                }
                else if (RequiredVariables.Configuration == "0")
                    btn_Configuration.Visible = false;
                //protocolToolStripMenuItem.Enabled = false;

                if (RequiredVariables.Runproto == "1")
                {
                    btn_RunProtocol.Visible = true;
                    //reagentsToolStripMenuItem.Enabled = true;
                    //catalogToolStripMenuItem.Enabled = true;
                }
                else if (RequiredVariables.Runproto == "0")
                {
                    btn_RunProtocol.Visible = false;
                    //reagentsToolStripMenuItem.Enabled = false;
                    // catalogToolStripMenuItem.Enabled = false;
                }
                if (RequiredVariables.Viewproto == "1")
                    btn_Reports.Visible = true;
                else if (RequiredVariables.Viewproto == "0")
                    btn_Reports.Visible = false;

                if (RequiredVariables.UsrManage == "1")
                    btn_User.Visible = true;
                else if (RequiredVariables.UsrManage == "0")
                    btn_User.Visible = false;
                // btn_User.Visible = false;
                //btn_Exit.Location = new Point(562, -3);

            }
            lbl_UserName.Text = RequiredVariables.UserName;
        }
        public void btnBackground()
        {
            btn_Configuration.BackColor = Color.FromArgb(30, 80, 150);
            btn_Calibration.BackColor = Color.FromArgb(30, 80, 150);
            btn_RunProtocol.BackColor = Color.FromArgb(30, 80, 150);
            btn_Reports.BackColor = Color.FromArgb(30, 80, 150);
            btn_User.BackColor = Color.FromArgb(30, 80, 150);
            //btn_Reports.BackColor; 
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
        private void Configurationcontextmenu()
        {
            //settingsMenuStrip.ForeColor = Color.White;


            settingsMenuStrip.Show(panel1, 0, panel1.Height); ;
        }
        private void Calibrationcontextmenu()
        {
            if (btn_Calibration.Location == new Point(-2, -3))
            {
                calibrationMenuStrip.Show(panel1, 1, panel1.Height); ;
            }
            if (btn_Calibration.Location == new Point(139, -3))
            {
                calibrationMenuStrip.Show(panel1, 142, panel1.Height); ;
            }
            //calibrationMenuStrip.ForeColor = Color.White;
            
        }
        private void Reportscontextmenu()
        {
            if (RequiredVariables.Usertype == "Admin")
            {
                if (btn_Reports.Location == new Point(-2, -3))
                {
                    ReportMenuStrip.Show(panel1, 1, panel1.Height); ;
                    engmodeToolStripMenuItem.Visible = true;
                    jarpositionToolStripMenuItem.Visible = true;
                    userLogToolStripMenuItem.Visible = true;
                    protorunToolStripMenuItem.Visible = true;
                    viewprotoToolStripMenuItem.Visible = true;
                }
                if (btn_Reports.Location == new Point(139, -3))
                {
                    ReportMenuStrip.Show(panel1, 142, panel1.Height); ;
                    engmodeToolStripMenuItem.Visible = true;
                    jarpositionToolStripMenuItem.Visible = true;
                    userLogToolStripMenuItem.Visible = true;
                    protorunToolStripMenuItem.Visible = true;
                    viewprotoToolStripMenuItem.Visible = true;
                }
                if (btn_Reports.Location == new Point(280, -3))
                {
                    ReportMenuStrip.Show(panel1, 283, panel1.Height); ;
                    engmodeToolStripMenuItem.Visible = true;
                    jarpositionToolStripMenuItem.Visible = true;
                    userLogToolStripMenuItem.Visible = true;
                    protorunToolStripMenuItem.Visible = true;
                    viewprotoToolStripMenuItem.Visible = true;
                }
                if (btn_Reports.Location == new Point(421, -3))
                {
                    ReportMenuStrip.Show(panel1, 424, panel1.Height); ;
                    engmodeToolStripMenuItem.Visible = true;
                    jarpositionToolStripMenuItem.Visible = true;
                    userLogToolStripMenuItem.Visible = true;
                    protorunToolStripMenuItem.Visible = true;
                    viewprotoToolStripMenuItem.Visible = true;
                }
            }
           else if (RequiredVariables.Usertype == "User")
            {
                if (btn_Reports.Location == new Point(-2, -3))
                {
                    ReportMenuStrip.Show(panel1, 1, panel1.Height); ;
                    ReportMenuStrip.Size = new Size(130,30);
                    engmodeToolStripMenuItem.Visible = false;
                    jarpositionToolStripMenuItem.Visible = false;
                    userLogToolStripMenuItem.Visible = false;
                    protorunToolStripMenuItem.Visible = true;
                    viewprotoToolStripMenuItem.Visible = false;
                }
                if (btn_Reports.Location == new Point(139, -3))
                {
                    ReportMenuStrip.Show(panel1, 142, panel1.Height); ;
                    ReportMenuStrip.Size = new Size(130, 30);
                    engmodeToolStripMenuItem.Visible = false;
                    jarpositionToolStripMenuItem.Visible = false;
                    userLogToolStripMenuItem.Visible = false;
                    protorunToolStripMenuItem.Visible = true;
                    viewprotoToolStripMenuItem.Visible = false;
                }
                if (btn_Reports.Location == new Point(280, -3))
                {
                    ReportMenuStrip.Show(panel1, 283, panel1.Height); ;
                    ReportMenuStrip.Size = new Size(130, 30);
                    engmodeToolStripMenuItem.Visible = false;
                    jarpositionToolStripMenuItem.Visible = false;
                    userLogToolStripMenuItem.Visible = false;
                    protorunToolStripMenuItem.Visible = true;
                    viewprotoToolStripMenuItem.Visible = false;
                }
                if (btn_Reports.Location == new Point(421, -3))
                {
                    ReportMenuStrip.Show(panel1, 424, panel1.Height); ;
                    ReportMenuStrip.Size = new Size(130, 30);
                    engmodeToolStripMenuItem.Visible = false;
                    jarpositionToolStripMenuItem.Visible = false;
                    userLogToolStripMenuItem.Visible = false;
                    protorunToolStripMenuItem.Visible = true;
                    viewprotoToolStripMenuItem.Visible = false;
                }
            }
        }
        //private void pictureBox7_Click(object sender, EventArgs e)
        //{



        //}
        private void label7_Click(object sender, EventArgs e)
        {
            Configurationcontextmenu();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Calibrationcontextmenu();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pic_Exit_Click(object sender, EventArgs e)
        {

        }
        Form activeForm;
        private void OpenChildForm(Form Childform)
        {
            if (activeForm != null)

                activeForm.Close();

            activeForm = Childform;
            Childform.TopLevel = false;
            Childform.FormBorderStyle = FormBorderStyle.None;
            Childform.Dock = DockStyle.Fill;
            panel3.Controls.Add(Childform);
            panel3.Tag = Childform;
            Childform.BringToFront();
            Childform.Show();

            //btn_Refresh.Visible = true;


        }

        private void protocolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((RequiredVariables.RunProto_Started == true) || (RequiredVariables.EngineeringMode_Started == true))
            {
                Form_ProtocolConfig frm = new Form_ProtocolConfig();
                frm.Show();
            }
            else if ((RequiredVariables.RunProto_Started == false) && (RequiredVariables.EngineeringMode_Started == false))
            {
                //OpenChildForm(new Form2());
                OpenChildForm(new Form_ProtocolConfig());
                //OpenChildForm(new Form5());
            }
        }

        private void reagentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((RequiredVariables.RunProto_Started == true) || (RequiredVariables.EngineeringMode_Started == true))
            {
                Reagent_Configuration frm = new Reagent_Configuration();
                frm.Show();
            }
            else if ((RequiredVariables.RunProto_Started == false) && (RequiredVariables.EngineeringMode_Started == false))
            {
                OpenChildForm(new Reagent_Configuration());
            }            
        }

        private void btn_Configuration_Click(object sender, EventArgs e)
        {
            //JarPositions jp = new JarPositions();
            // btn_Configuration.Size=
            //  Hide(JarPositions);
            //  jp.Hide();
            btn_Configuration.BackColor = Color.FromArgb(25, 70, 130);
            btn_Calibration.BackColor = Color.FromArgb(30, 80, 150);
            btn_RunProtocol.BackColor = Color.FromArgb(30, 80, 150);
            btn_Reports.BackColor = Color.FromArgb(30, 80, 150);
            btn_User.BackColor = Color.FromArgb(30, 80, 150);
            Configurationcontextmenu();
        }
        private void btn_Calibration_Click(object sender, EventArgs e)
        {
            //btn_Calibration.FlatStyle = FlatStyle.Flat;
            btn_Configuration.BackColor = Color.FromArgb(30, 80, 150);
            btn_Calibration.BackColor = Color.FromArgb(25, 70, 130);
            btn_RunProtocol.BackColor = Color.FromArgb(30, 80, 150);
            btn_Reports.BackColor = Color.FromArgb(30, 80, 150);
            btn_User.BackColor = Color.FromArgb(30, 80, 150);
            Calibrationcontextmenu();
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            // btnBackground();
            closeapp();
        }
        private void closeapp()
        {
            if (MessageBox.Show("Are you sure to close the Application", RequiredVariables.Msgtext, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                sqlstr = "";
                sqlstr = "Insert into UserDetails(UserName,Status,Loggedon,LoggedTime,Month) values('";
                sqlstr = sqlstr + RequiredVariables.UserName + "','";
                String s1 = DateTime.Now.ToString("dd-MM-yyyy");
                String s2 = DateTime.Now.ToString("HH:mm:ss");
                string s3 = "sign out";
                String s4 = DateTime.Now.ToString("MMMM");
                sqlstr = sqlstr + s3 + "','" + s1 + "','" + s2 + "','" + s4 + "')";
                cmd = new SqlCommand(sqlstr, con);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                cmd.ExecuteNonQuery();
                if (mport.IsOpen)
                    mport.Close();
                timer1.Enabled = false;
                timer1.Stop();
                //Application.Exit();
                Environment.Exit(0);
            }
            ////else
            ////{
            ////    return;
            ////}
        }
        private void btn_Reports_Click(object sender, EventArgs e)
        {
            btn_Configuration.BackColor = Color.FromArgb(30, 80, 150);
            btn_Calibration.BackColor = Color.FromArgb(30, 80, 150);
            btn_RunProtocol.BackColor = Color.FromArgb(30, 80, 150);
            btn_Reports.BackColor = Color.FromArgb(25, 70, 130);
            btn_User.BackColor = Color.FromArgb(30, 80, 150);
            Reportscontextmenu();
        }
        private void engineeringModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // OpenChildForm(new Enginering_Mode());
            // OpenChildForm(new Form8());
        }
        private void contextMenuStrip1_MouseEnter(object sender, EventArgs e)
        {


        }
        private void protocolToolStripMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            // protocolToolStripMenuItem.BackColor = Color.Green;
        }
        private void catalogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((RequiredVariables.RunProto_Started == true) || (RequiredVariables.EngineeringMode_Started == true))
            {
                Form_CatalogConfig frm = new Form_CatalogConfig();
                frm.Show();
            }
            else if ((RequiredVariables.RunProto_Started == false) && (RequiredVariables.EngineeringMode_Started == false))
            {
                //this.Hide();
                OpenChildForm(new Form_CatalogConfig());
            }            
        }
        private void labDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((RequiredVariables.RunProto_Started == true) || (RequiredVariables.EngineeringMode_Started == true))
            {
                LabDetails_Configuration frm = new LabDetails_Configuration();
                frm.Show();
            }
            else if ((RequiredVariables.RunProto_Started == false) && (RequiredVariables.EngineeringMode_Started == false))
            {
                OpenChildForm(new LabDetails_Configuration());
            }            
        }
        private void pB_signout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to signout of the existing user", RequiredVariables.Msgtext, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)

            {
                this.Hide();
            sqlstr = "";
            sqlstr = "Insert into UserDetails(UserName,Status,Loggedon,LoggedTime,Month) values('";
            sqlstr = sqlstr + RequiredVariables.UserName + "','";
            String s1 = DateTime.Now.ToString("dd-MM-yyyy");
            String s2 = DateTime.Now.ToString("HH:mm:ss");
            string s3 = "sign out";
            String s4 = DateTime.Now.ToString("MMMM");
            sqlstr = sqlstr + s3 + "','" + s1 + "','" + s2 + "','" + s4 + "')";
            cmd = new SqlCommand(sqlstr, con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();
            //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            //String s1 = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss:fff");
            //byte[] bdata = Encoding.Default.GetBytes("\n" + lbl_UserName.Text + ",sign out," + s1);
            //// byte[] bdata = Encoding.Default.GetBytes("\n  RA1,J01," + txt_Xvalue.Text + "," + txt_Yvalue.Text + "," + txt_Zvalue.Text + "," + s1);
            //fileStream.Write(bdata, 0, bdata.Length);
            //fileStream.Close();

            LoginScreen ls = new LoginScreen();
                ls.Show();
            }
            else
            {
                return;
            }
        }
        private void lbl_ChangePassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            RequiredVariables.ChangePassword = true;
            RequiredVariables.ForgotPassword = false;
            ForgotPassword frm = new ForgotPassword();
            frm.Show();
        }
        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new UserManagement());
        }
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ForgotPassword fp = new ForgotPassword();
            //fp.ChangePassword();
            fp.Show();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_Timedate.Text = System.DateTime.Now.ToString("dd-MM-yyyy  HH:mm:ss");
            if (Communication.portopened == true)
            {
                lbl_disp.Text = Communication.portname + " : Opened for communication";
                lbl_disp.BackColor = Color.Green;
                lbl_disp.ForeColor = Color.White;
            }
            else if (Communication.portopened==false)
            {
                lbl_disp.Text = "Communication failed With device please check Cable";
                lbl_disp.BackColor = Color.Red;
                lbl_disp.ForeColor = Color.White;
            }              
            

            if ((RequiredVariables.RunProto_Started==true) ||(RequiredVariables.EngineeringMode_Started==true))
            {
                btn_Calibration.Enabled = false;
                btn_RunProtocol.Enabled = false;
                btn_User.Enabled = false;
            }
            else if ((RequiredVariables.RunProto_Started == false) && (RequiredVariables.EngineeringMode_Started == false))
            {
                btn_Calibration.Enabled = true;
                btn_RunProtocol.Enabled = true;
                btn_User.Enabled = true;
            }

            if ((RequiredVariables.btnConf == true) || (RequiredVariables.btnCalib == true) || (RequiredVariables.btnReports == true) || (RequiredVariables.btnRunProto == true) || (RequiredVariables.btnUser == true))
            {
                btnBackground();
                if (RequiredVariables.btnConf == true)
                {

                    RequiredVariables.btnConf = false;
                }

                if (RequiredVariables.btnCalib == true)
                {

                    RequiredVariables.btnCalib = false;
                }

                if (RequiredVariables.btnReports == true)
                {

                    RequiredVariables.btnReports = false;
                }

                if (RequiredVariables.btnRunProto == true)
                {

                    RequiredVariables.btnRunProto = false;
                }

                if (RequiredVariables.btnUser == true)
                {

                    RequiredVariables.btnUser = false;

                }


            }

            //lbl_time.Text = System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        }
        public void userIcons()
        {

            //if ((RequiredVariables.btnConf == true) || (RequiredVariables.btnCalib == true) || (RequiredVariables.btnReports == true) || (RequiredVariables.btnRunProto == true) || (RequiredVariables.btnUser == true))
            //{
            if (RequiredVariables.Usertype=="Admin" && RequiredVariables.Configuration == "1")
            {
                //btn_Configuration.Enabled = true;
                btn_Configuration.Visible = true;
                protocolToolStripMenuItem.Visible = true;
                catalogToolStripMenuItem.Visible = true;
                reagentsToolStripMenuItem.Visible = true;
                labDetailsToolStripMenuItem.Visible = true;
                changePasswordToolStripMenuItem.Visible = false;
                settingsMenuStrip.Size = new Size(180, 100);
            }
            if (RequiredVariables.Usertype == "User" && RequiredVariables.Configuration == "1")
            {
                //btn_Configuration.Enabled = true;
                btn_Configuration.Visible = true;
                protocolToolStripMenuItem.Visible = true;
                catalogToolStripMenuItem.Visible = true;
                reagentsToolStripMenuItem.Visible = true;
                labDetailsToolStripMenuItem.Visible = true;
                changePasswordToolStripMenuItem.Visible = true;
                settingsMenuStrip.Size = new Size(180, 120);
            }
            else if (RequiredVariables.Configuration == "0")
            {
                //  btn_Configuration.Enabled = false;
                btn_Configuration.Visible = true;
                protocolToolStripMenuItem.Visible = false;
                catalogToolStripMenuItem.Visible = false;
                reagentsToolStripMenuItem.Visible = false;
                labDetailsToolStripMenuItem.Visible = false;
                changePasswordToolStripMenuItem.Visible = true;
                settingsMenuStrip.Size = new Size(180, 30);
                // settingsMenuStrip.

            }
            if (RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters=="0")
            {
                //    btn_Calibration.Enabled = true;
                //engineeringModeToolStripMenuItem.Enabled = false;
                //jarPositionsToolStripMenuItem.Enabled = true;

                btn_Calibration.Visible = true;
                engineeringModeToolStripMenuItem.Visible = false;
                jarPositionsToolStripMenuItem.Visible = true;

            }
            //   else if (RequiredVariables.JarPositionCalibration == "0")
            //   {
            //    btn_Calibration.Enabled = false;
            //    engineeringModeToolStripMenuItem.Enabled = false;
            //    jarPositionsToolStripMenuItem.Enabled = false;
            //}
            if (RequiredVariables.EngParameters == "1" && RequiredVariables.JarPositionCalibration=="0")
            {
                //btn_Calibration.Enabled = true;
                //engineeringModeToolStripMenuItem.Enabled = true;
                //jarPositionsToolStripMenuItem.Enabled = false;

                btn_Calibration.Visible = true;
                engineeringModeToolStripMenuItem.Visible = true;
                jarPositionsToolStripMenuItem.Visible = false;


            }
            if (RequiredVariables.EngParameters == "1" && RequiredVariables.JarPositionCalibration == "1")
            {

                //btn_Calibration.Enabled = false;
                //engineeringModeToolStripMenuItem.Enabled = false;
                //jarPositionsToolStripMenuItem.Enabled = false;

                btn_Calibration.Visible = true;

                engineeringModeToolStripMenuItem.Visible = true;
                jarPositionsToolStripMenuItem.Visible = true;

            }
            if (RequiredVariables.EngParameters == "0" && RequiredVariables.JarPositionCalibration == "0")
            {

                //btn_Calibration.Enabled = false;
                //engineeringModeToolStripMenuItem.Enabled = false;
                //jarPositionsToolStripMenuItem.Enabled = false;

                btn_Calibration.Visible = false;

                engineeringModeToolStripMenuItem.Visible = false;
                jarPositionsToolStripMenuItem.Visible = false;

            }
            if (RequiredVariables.Viewproto == "1")
            {
                //btn_Reports.Enabled = true;
                btn_Reports.Visible = true;

                // btn_Reports
            }
            if ( RequiredVariables.Viewproto == "0")
            {
                //btn_Reports.Enabled= false;
                btn_Reports.Visible = false;

            }
            if (RequiredVariables.Runproto == "1")
            {
                // btn_RunProtocol.Enabled = true;
                btn_RunProtocol.Visible = true;

            }
            else if (RequiredVariables.Runproto == "0")
            {
                //btn_RunProtocol.Enabled = false;
                btn_RunProtocol.Visible = false;

                // btn_Reports.RightToLeft = 141;
            }
            if (RequiredVariables.UsrManage == "1")
            {
                // btn_User.Enabled = false;

                btn_User.Visible = true;

            }
            else if (RequiredVariables.UsrManage == "0")
            {
                // btn_User.Enabled = false;
                btn_User.Visible = false;
            }
            // }
        }
        public void reportFalse()
        {
            if (RequiredVariables.JarPositionCalibration == "1" || RequiredVariables.EngParameters == "1" && RequiredVariables.Runproto == "1")
            {
                //{
                if (RequiredVariables.Viewproto == "0" && RequiredVariables.UsrManage == "0")
                {

                    btn_Exit.Location = new Point(421, -3);

                }
                if (RequiredVariables.Viewproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(562, -3);

                }
            }
            // }
        }
        public void reportTrue()
        {
            //if (RequiredVariables.Viewproto == "1")
            if (RequiredVariables.JarPositionCalibration == "1" || RequiredVariables.EngParameters == "1" && RequiredVariables.Runproto == "1")
            {
                //{
                if (RequiredVariables.Viewproto == "1" && RequiredVariables.UsrManage == "0")
                {

                    btn_Exit.Location = new Point(562, -3);

                }
            }
            //  }
        }
        public void userFalse()
        {
            if (RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
            {
                btn_Exit.Location = new Point(139, -3);
            }
        }
        public void runprotoFalse()
        {
            if (RequiredVariables.JarPositionCalibration == "1" || RequiredVariables.EngParameters == "1")
            {
                //if (RequiredVariables.Runproto == "0")
                //{
                if (RequiredVariables.Runproto == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Reports.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);

                }
                if (RequiredVariables.Runproto == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421, -3);



                }
                if (RequiredVariables.Runproto == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    //btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);

                }
                if (RequiredVariables.JarPositionCalibration == "1" || RequiredVariables.EngParameters == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Exit.Location = new Point(280, -3);
                }
            }
            //}
        }
        public void runprotoTrue()
        {
            if (RequiredVariables.JarPositionCalibration == "1" || RequiredVariables.EngParameters == "1")
            {
                //if (RequiredVariables.Runproto == "1")
                //{
                if (RequiredVariables.Runproto == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Reports.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(562, -3);

                }

                if (RequiredVariables.Runproto == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    //btn_Reports.Location = new Point(280, -3);

                    btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(562, -3);

                }
                if (RequiredVariables.Runproto == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Exit.Location = new Point(421, -3);
                }
            }
            //}
        }
        public void calibfalse()
        {
            //if (RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.JarPositionCalibration == "0")
            //{
            if(RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
            {
                btn_RunProtocol.Location = new Point(139, -3);
                btn_Reports.Location = new Point(280, -3);
                btn_User.Location = new Point(421, -3);
                btn_Exit.Location = new Point(562, -3);
            }
            if(RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
            {
                btn_RunProtocol.Location = new Point(139, -3);
                btn_User.Location = new Point(280, -3);
                btn_Exit.Location = new Point(421, -3);
            }
            if(RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
            {
                btn_RunProtocol.Location = new Point(139, -3);
                btn_Reports.Location = new Point(280, -3);
                btn_Exit.Location = new Point(421, -3);
            }
            if(RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
            {

                btn_Reports.Location = new Point(139, -3);
                btn_User.Location = new Point(280, -3);
                btn_Exit.Location = new Point(421, -3);
            }
            if(RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
            {

                btn_Reports.Location = new Point(139, -3);
                // btn_User.Location = new Point(421, -3);
                btn_Exit.Location = new Point(280, -3);
            }
            if(RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
            {

                btn_User.Location = new Point(139, -3);
                btn_Exit.Location = new Point(280, -3);
            }
            if(RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
            {

                //  btn_Reports.Location = new Point(280, -3);
                //  btn_User.Location = new Point(280, -3);
                btn_Exit.Location = new Point(139, -3);
            }

            //}
        }
        public void alltrue()
        {

            if (RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
            {
                btn_Calibration.Location = new Point(139, -3);
                btn_RunProtocol.Location = new Point(280, -3);
                btn_Reports.Location = new Point(421, -3);
                btn_User.Location = new Point(562, -3);
                btn_Exit.Location = new Point(703, -3);
            }
            if (RequiredVariables.JarPositionCalibration == "1" && RequiredVariables.EngParameters == "0" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
            {
                btn_Calibration.Location = new Point(139, -3);
                btn_RunProtocol.Location = new Point(280, -3);
                btn_Reports.Location = new Point(421, -3);
                btn_User.Location = new Point(562, -3);
                btn_Exit.Location = new Point(703, -3);
            }
            if (RequiredVariables.JarPositionCalibration == "0" && RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
            {
                btn_Calibration.Location = new Point(139, -3);
                btn_RunProtocol.Location = new Point(280, -3);
                btn_Reports.Location = new Point(421, -3);
                btn_User.Location = new Point(562, -3);
                btn_Exit.Location = new Point(703, -3);
            }
        }
        public void calibTrue()
        {
            if (RequiredVariables.JarPositionCalibration == "1" || RequiredVariables.EngParameters == "1")
            {  //{i
                if (RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    btn_Reports.Location = new Point(421, -3);
                    btn_User.Location = new Point(562, -3);
                    btn_Exit.Location = new Point(703, -3);
                }
                if (RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
                {
                    btn_Calibration.Location = new Point(139, -3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
                {
                    btn_Calibration.Location = new Point(139,-3);
                    btn_RunProtocol.Location = new Point(280, -3);
                    btn_Reports.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Calibration.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(562, -3);
                }
                if (RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Calibration.Location = new Point(139, -3);
                    btn_Reports.Location = new Point(280, -3);
                    // btn_User.Location = new Point(421, -3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
                {
                    btn_Calibration.Location = new Point(139, -3);
                    btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(421, -3);
                }
                if (RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
                {
                    btn_Calibration.Location = new Point(139, -3);
                    //  btn_Reports.Location = new Point(280, -3);
                    //  btn_User.Location = new Point(280, -3);
                    btn_Exit.Location = new Point(280, -3);
                }
             
            }
            //if (RequiredVariables.JarPositionCalibration == "1" || RequiredVariables.JarPositionCalibration == "1")
            //{i

            //if (RequiredVariables.JarPositionCalibration == "1" || RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "1")
            //    {
            //        btn_RunProtocol.Location = new Point(280, -3);
            //        btn_User.Location = new Point(421, -3);
            //        btn_Exit.Location = new Point(562, -3);
            //    }
            //    if (RequiredVariables.JarPositionCalibration == "1" || RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "1" && RequiredVariables.UsrManage == "0")
            //    {
            //        btn_RunProtocol.Location = new Point(280, -3);
            //        btn_Reports.Location = new Point(421, -3);
            //        btn_Exit.Location = new Point(562, -3);
            //    }
            //    if (RequiredVariables.JarPositionCalibration == "1" || RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
            //    {

            //        btn_Reports.Location = new Point(280, -3);
            //        btn_User.Location = new Point(421, -3);
            //        btn_Exit.Location = new Point(562, -3);
            //    }
            //    if (RequiredVariables.JarPositionCalibration == "1" || RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "1" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
            //    {

            //        btn_Reports.Location = new Point(280, -3);
            //        // btn_User.Location = new Point(421, -3);
            //        btn_Exit.Location = new Point(421, -3);
            //    }
            //    if (RequiredVariables.JarPositionCalibration == "1" || RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "1")
            //    {

            //        //  btn_Reports.Location = new Point(280, -3);
            //        btn_User.Location = new Point(280, -3);
            //        btn_Exit.Location = new Point(421, -3);
            //    }
            //    if (RequiredVariables.JarPositionCalibration == "1" || RequiredVariables.EngParameters == "1" && RequiredVariables.Viewproto == "0" && RequiredVariables.Runproto == "0" && RequiredVariables.UsrManage == "0")
            //    {


        }
        private void btn_RunProtocol_Click(object sender, EventArgs e)
        {
            
            btn_Configuration.BackColor = Color.FromArgb(30, 80, 150);
            btn_Calibration.BackColor = Color.FromArgb(30,80,150);
            btn_RunProtocol.BackColor = Color.FromArgb(25, 70, 130);
            btn_Reports.BackColor = Color.FromArgb(30, 80, 150);
            btn_User.BackColor = Color.FromArgb(30, 80, 150);
            OpenChildForm(new Form_RunProto());
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {

        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            //btnBackground();
        }
        
        private void heaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new frm_Heater());
        }

        private void doorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //OpenChildForm(new Form_Door());
        }

        private void waterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new Form_Water());
        }

        private void roboticArmsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // OpenChildForm(new Form_RoboticArms());
        }

        private void jarPositionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mport.IsOpen == true)
                mport.Close();
           OpenChildForm(new Frm_JarPositionCalib());
           // OpenChildForm(new Form10());
        }

        private void engineeringModeToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {

        }

        private void btn_User_Click_1(object sender, EventArgs e)
        {
            btn_Configuration.BackColor = Color.FromArgb(30, 80, 150);
            btn_Calibration.BackColor = Color.FromArgb(30, 80, 150);
            btn_RunProtocol.BackColor = Color.FromArgb(30, 80, 150);
            btn_Reports.BackColor = Color.FromArgb(30,80,150);
            btn_User.BackColor = Color.FromArgb(25, 70, 130);
            OpenChildForm(new UserManagement());
            UserManagement us = new UserManagement();
            us.closeUser();
            //us.closeSign
           
        }

        private void calibrationMenuStrip_Opening(object sender, CancelEventArgs e)
        {

        }

        private void lbl_Timedate_Click(object sender, EventArgs e)
        {

        }

        private void dailyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((RequiredVariables.RunProto_Started == true) || (RequiredVariables.EngineeringMode_Started == true))
            {
                Form_engReports frm = new Form_engReports();
                frm.Show();
            }
            else if ((RequiredVariables.RunProto_Started == false) && (RequiredVariables.EngineeringMode_Started == false))
            {
                OpenChildForm(new Form_engReports());
            }
            
        }

        private void weeklyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((RequiredVariables.RunProto_Started == true) || (RequiredVariables.EngineeringMode_Started == true))
            {
                Form_JarpositionReports frm = new Form_JarpositionReports();
                frm.Show();
            }
            else if ((RequiredVariables.RunProto_Started == false) && (RequiredVariables.EngineeringMode_Started == false))
            {
                OpenChildForm(new Form_JarpositionReports());
            }            
        }

        private void monthlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((RequiredVariables.RunProto_Started == true) || (RequiredVariables.EngineeringMode_Started == true))
            {
                Form_UserInDetailedReports frm = new Form_UserInDetailedReports();
                frm.Show();
            }
            else if ((RequiredVariables.RunProto_Started == false) && (RequiredVariables.EngineeringMode_Started == false))
            {
                OpenChildForm(new Form_UserInDetailedReports());
            }            
        }

        private void protorunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((RequiredVariables.RunProto_Started == true) || (RequiredVariables.EngineeringMode_Started == true))
            {
                Form_Reports frm = new Form_Reports();
                frm.Show();
            }
            else if ((RequiredVariables.RunProto_Started == false) && (RequiredVariables.EngineeringMode_Started == false))
            {
                OpenChildForm(new Form_Reports());
            }
            
        }

        private void viewprotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((RequiredVariables.RunProto_Started == true) || (RequiredVariables.EngineeringMode_Started == true))
            {
                Form_ProtocolMaster frm = new Form_ProtocolMaster();
                frm.Show();
            }
            else if ((RequiredVariables.RunProto_Started == false) && (RequiredVariables.EngineeringMode_Started == false))
            {
                OpenChildForm(new Form_ProtocolMaster());
            }
            
        }

        private void engineeringModeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {            
            if(mport.IsOpen==true)
            {
                mport.Close();
            }
            OpenChildForm(new Enginering_Mode());
        }

        private void lbl_UsrType_Click(object sender, EventArgs e)
        {
            
        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    lbl.Text = System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        //}
        #region comfail checking

        internal static class NativeMethods
        {
            public const int WM_DEVICECHANGE = 0x0219;
            public const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
            public const int DBT_DEVICEARRIVAL = 0x8000;

            [StructLayout(LayoutKind.Sequential)]
            public struct DEV_BROADCAST_VOLUME
            {
                public int dbcv_size;
                public int dbcv_devicetype;
                public int dbcv_reserved;
                public int dbcv_unitmask;
            }
        }
        SerialPort mport = new SerialPort();
        Boolean portopendflg = false, pGotByteFlag = false, port_avail = false;
        ////protected override void WndProc(ref Message m)
        ////{
        ////    try
        ////    {

        ////        base.WndProc(ref m);

        ////        if (m.Msg == NativeMethods.WM_DEVICECHANGE)
        ////        {
        ////            if (mport.IsOpen == true)
        ////                mport.Close();
        ////            else if (mport.IsOpen == false)
        ////                portopendflg = false;
        ////            lbl_disp.Text = Communication.portname + " : Closed for communication with device.... Trying to Re-establish Communication with Device Please be Patiance....";
        ////            lbl_disp.BackColor = Color.Red;
        ////            lbl_disp.ForeColor = Color.White;
        ////            Communication.portopened = false;
        ////            int cnt = 0;
        ////            System.Threading.Thread.Sleep(5000);

        ////            while (cnt < 3)
        ////            {
        ////                if (portopendflg == false)
        ////                {
        ////                    getavailableportnames();
        ////                    System.Threading.Thread.Sleep(1000);
        ////                    cnt++;
        ////                }
        ////                else
        ////                {
        ////                    Communication.portopened = true;
        ////                    mport.Close();
        ////                    break;
        ////                }
        ////            }


        ////        }
        ////    }
        ////    catch (ObjectDisposedException)
        ////    {

        ////    }
        ////    catch
        ////    {

        ////    }
        ////}
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
        string targetDeviceDescription = "Silicon Labs CP210x USB to UART Bridge";
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
                    ////System.Threading.Thread.Sleep(2000);
                    ////movezaxishome();  //New function added on 01-11-2024 1507
                }
                else
                {
                    lbl_disp.Text = "Failed to open the Communication port.";
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
                if (mport.IsOpen == false)
                    mport.Open();
                lbl_disp.Text = "Checking Communication Ports and Re-establsihing Communication with device Please be patiance..";
                lbl_disp.BackColor = Color.Navy;
                this.Cursor = Cursors.WaitCursor;
                Communication.devid = 1;
                pGotByteFlag = false;
                Communication.resultvalue = "";
                lbl_disp.Text = "";
                ////Making machine to wait for 30 seconds for RA to reach home as port reintiated in PC side or in machine
                System.Threading.Thread.Sleep(5000);  ////Taken time delay in milli seconds
                                                      ////Sending RA home command to device.
                lbl_disp.Text = Communication.portname + " : Opened for communication";
                lbl_disp.BackColor = Color.Green;
                this.Cursor = Cursors.Default;
                portopendflg = true;
                Communication.portopened = true;
        }

        private void getavailableportnames_Working()
        {
            string[] portnames = SerialPort.GetPortNames(); //load all names of  com ports to string            
            if (portnames.Length > 0)
            {
                foreach (string s in portnames)                 //add this names to comboboxPort items
                {
                    Communication.portname = s;
                    //Communication.baudrate = "9600";          //Assigning default baud rate as 9600
                    Communication.baudrate = "115200";
                    init_port();
                    if (port_avail == true)
                    {
                        if (mport.IsOpen == false)
                            mport.Open();
                        lbl_disp.Text = "Checking Communication Ports and Re-establsihing Communication with device Please be patiance..";
                        lbl_disp.BackColor = Color.Navy;
                        this.Cursor = Cursors.WaitCursor;
                        Communication.devid = 1;
                        pGotByteFlag = false;
                        Communication.resultvalue = "";
                        lbl_disp.Text = "";
                        ////Making machine to wait for 30 seconds for RA to reach home as port reintiated in PC side or in machine
                        System.Threading.Thread.Sleep(5000);  ////Taken time delay in milli seconds
                                                              ////Sending RA home command to device.
                        lbl_disp.Text = Communication.portname + " : Opened for communication";
                        lbl_disp.BackColor = Color.Green;
                        this.Cursor = Cursors.Default;
                        portopendflg = true;
                        Communication.portopened = true;
                    }                    
                }
            }
            else
            {
                lbl_disp.Text = "Communication Failed With Device.... Please check the cable";
                lbl_disp.BackColor = Color.Red;
                portopendflg = false;
                Communication.portopened = false;
                MessageBox.Show("ER-1008 Communication Failure With Device", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                RequiredVariables.writeerrorlogfile("ER-1008 Communication Failure With Device While intializing & opening communication port", "In getavailableportnames functio in mainmenu form");
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
                mport.PinChanged += new SerialPinChangedEventHandler(ComportStatusChanged);
                if (!mport.IsOpen)
                    mport.Open();
                port_avail = true;
                Communication.portopened = true;
            }
            catch (Exception ex)
            {
                port_avail = false;
                Communication.portopened = false;
                RequiredVariables.writeerrorlogfile("ER-1008 Communication Failure With Device While intializing & opening communication port \n" + ex.ToString(), "In init_port functio in mainmenu form");
            }
        }

        private void ComportStatusChanged(object sender, SerialPinChangedEventArgs e)
        {
            throw new NotImplementedException();
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
                    MessageBox.Show(e3.ToString());
                    return;
                }
                #endregion

            }
            catch (Exception d3)
            {

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
                    case 5: //Home Command
                    {
                        string displayScrData = "";
                        if ((respval == "000") && (rtype == "F"))
                        {
                            displayScrData = "All axis Moved to Home";
                        }
                        else
                        {
                            displayScrData = "Home Status " + msgdisp;
                        }                            
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

        private void Form_MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeapp();
        }

        private void Form_MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            //closeapp();
        }

        private string GetDeviceName(IntPtr lParam)
        {
            // Helper method to extract the device name from the lParam
            NativeMethods.DEV_BROADCAST_VOLUME vol;
            vol = (NativeMethods.DEV_BROADCAST_VOLUME)Marshal.PtrToStructure(lParam, typeof(NativeMethods.DEV_BROADCAST_VOLUME));
            return $"{vol.dbcv_unitmask.ToString("X")}:"; // Assumes that the device is a drive (e.g., COM1:)
        }
        #endregion

        #region Commands Sendings
        string framed_Data = "";

        private void movezaxishome()
        {
            ////Communication.RA_No = 0; //commented on 17-02-2024
            functioncode = Communication.RA_HOME;
            string sndcmdstr = "";
            sndcmdstr = "00100100";
            repeatval = 0;
            if (repeatval == 0)
            {
                Communication.framed_cmd = "";
            }
            CommandName = "Home Command";
            snd_rcvCmd(functioncode, sndcmdstr);
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
                }
            }
            catch (Exception e3)
            {

            }
        }
        #endregion

    }
}
