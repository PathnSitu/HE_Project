using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using System.Data.SqlClient;
using System.Windows.Navigation;
//using System.Diagnostics;

namespace HematoxinandEosin
{
    public partial class LoginScreen : Form
    {
        //Environment.MachineName.ToString();
        ////string Constr = "Data Source=SYSPSENG006;User ID=sa;Password=sree@pns2013;Initial Catalog=PNSHE;Pooling=false;Max Pool Size=400;workstation id =SYSPSENG006";
        string Constr = "Data Source="+ Environment.MachineName.ToString() + ";User ID=sa;Password=sree@pns2013;Integrated Security=True; Initial Catalog=PNSHE;Pooling=false;Max Pool Size=400;workstation id = " + Environment.MachineName.ToString();  //Stand alone machine - ID
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        // DataTable table = new DataTable("table");
        SqlDataAdapter sda = new SqlDataAdapter();
        string sqlstr;
        
        public LoginScreen()
        {
            InitializeComponent();
            txt_Username.Focus();
        }
        [DllImport("user32.dll")]
        private static extern
            bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern
            bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
       
        private static extern
            bool IsIconic(IntPtr hWnd);

        private const int SW_HIDE = 0;
        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;
        private const int SW_SHOWNOACTIVATE = 4;
        private const int SW_RESTORE = 9;
        private const int SW_SHOWDEFAULT = 10;
        private bool passwordvalidate;
        private bool uservalidate;
        private int pwdcnt;


        public void signin()
        {
            //if ((txt_Username.Text == "AdminService@PnS") && (txt_Password.Text == "admin@pns"))
            //{
            //    RequiredVariables.UserName = "Mukesh Chava";
            //    RequiredVariables.Usertype = "Admin";
            //    Require++dVariables.Configuration = "1";
            //    RequiredVariables.JarPositionCalibration = "1";
            //    RequiredVariables.Viewproto = "1";
            //    RequiredVariables.UsrManage = "1";
            //    RequiredVariables.EngParameters = "1";
            //    RequiredVariables.Runproto = "1";
            //    //RequiredVariables.Usertype = "User";
            //    this.Close();
            //    Form_MainMenu frm = new Form_MainMenu();
            //    frm.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Entered UserName or Password are Incorrect", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txt_Username.Text = "";
            //    txt_Password.Text = "";
            //    txt_Username.Focus();
            //}
        }
        private void check_useravailable()
        {
            System.IO.FileStream fs = default(System.IO.FileStream);
            try
            {
                //Default Normal User Creation
                string destination = Application.StartupPath + "\\Users";
                string strFileName = null;
                string usrdata = null, encryptpassword = null, encryptuser = null;
                destination = Application.StartupPath + "\\Users";
                if (Directory.Exists(destination))
                {

                    string strnew = null;
                    strnew = Application.StartupPath + "\\Users";
                    string fstr = null;
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(strnew);
                    int count = dir.GetDirectories().Length;
                    if (count >= 2)
                    {
                        destination = Application.StartupPath + "\\Users\\Guest";
                        strFileName = destination + "\\Configuration";
                        if (File.Exists(strFileName))
                        {
                            File.Delete(strFileName);
                            Directory.Delete(destination);
                        }
                    }
                }
                else
                {
                    destination = Application.StartupPath + "\\Users\\Guest";
                    Directory.CreateDirectory(destination);

                    strFileName = destination + "\\Configuration";

                    if (File.Exists(strFileName))
                    {
                        fs = new System.IO.FileStream(strFileName, System.IO.FileMode.Truncate, System.IO.FileAccess.Write);
                    }
                    else
                    {
                        fs = new System.IO.FileStream(strFileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                    }

                    usrdata = null;
                    encryptpassword = CryptorEngine.Encrypt("guest", true);

                    encryptuser = CryptorEngine.Encrypt("Guest", true);
                    //usrdata = encryptuser + "," + encryptpassword + "," + "In what city were you born?,HYD,0";
                    usrdata = encryptuser + "," + encryptpassword + "," + "User,0,0,0,0,0,0,0,0,0";
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);
                    sw.WriteLine(usrdata);
                    sw.Close();
                    fs.Close();

                    txt_Username.Text = "Guest";
                    txt_Password.Text = "guest";

                    //Default Field User Creation
                    destination = Application.StartupPath + "\\Users\\AdminService@PnS";
                    if (Directory.Exists(destination))
                    {

                    }
                    else
                    {
                        Directory.CreateDirectory(destination);
                    }

                    strFileName = null;
                    strFileName = destination + "\\Configuration";
                    fs = default(System.IO.FileStream);
                    if (File.Exists(strFileName))
                    {
                        fs = new System.IO.FileStream(strFileName, System.IO.FileMode.Truncate, System.IO.FileAccess.Write);
                    }
                    else
                    {
                        fs = new System.IO.FileStream(strFileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                    }
                    System.IO.StreamWriter sw1 = new System.IO.StreamWriter(fs);
                    sw1 = new System.IO.StreamWriter(fs);
                    usrdata = null;
                    encryptpassword = CryptorEngine.Encrypt("admin@pns", true);
                    encryptuser = CryptorEngine.Encrypt("AdminService@PnS", true);
                    usrdata = encryptuser + "," + encryptpassword + "," + "Admin,1,1,1,1,1,1,1,1,1";
                    sw1.WriteLine(usrdata);
                    sw1.Close();
                    fs.Close();
                }
            }
            catch (Exception d3)
            {
                fs.Close();
            }
        }
        private void check_application_running()
        {
            try
            {
                string apprun = "";
                Process[] Proc;
                apprun = System.IO.Path.GetFileNameWithoutExtension(Application.StartupPath + "\\HematoxinandEosin");

                Proc = Process.GetProcessesByName(apprun);

                if (Proc.Length > 1)
                {
                    MessageBox.Show("Already This Application is Running....\r\n Please Check once", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process Proc1 = Process.GetCurrentProcess();
                    int n = 0;

                    if (Proc[0].Id == Proc1.Id)
                    {
                        n = 1;
                    }

                    IntPtr hWnd = Proc[n].MainWindowHandle;
                    // if iconic, we need to restore the window
                    if (IsIconic(hWnd))
                    {
                        ShowWindowAsync(hWnd, SW_RESTORE);
                    }
                    // bring it to the foreground
                    SetForegroundWindow(hWnd);
                    // exit our process
                    //this.Close();
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void checkpwddata()
        {
            try
            {
                if ((string.IsNullOrEmpty(txt_Password.Text)))
                {
                    MessageBox.Show("Enter Valid  User Password", RequiredVariables.Msgtext, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    //txt_User.Text = null;
                    txt_Password.Text = null;
                    txt_Password.Focus();
                    passwordvalidate = false;
                }


                if (string.IsNullOrEmpty(txt_Username.Text))
                {
                    MessageBox.Show("Enter Valid  User Name", "Passenger Information System", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    txt_Username.Text = null;
                    txt_Username.Focus();
                    passwordvalidate = false;
                }

                if (txt_Username.Text != "" & txt_Password.Text != "")
                {
                    passwordvalidate = true;
                }

            }
            catch (Exception ex)
            {
                RequiredVariables.writeerrorlogfile("While Checking User Name and Password \r\n" + ex.ToString(), "In Frm_Login form in checkpwdata");
            }
        }

        private void validate_users()
        {
            try
            {
                string strnew = null;
                strnew = Application.StartupPath + "\\Users";
                string fstr = null;
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(strnew);
                int count = dir.GetDirectories().Length;
                if (count == 0)
                {
                    MessageBox.Show("Users Details not Available", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {

                    //Showing Password  
                    string strFileName = null;
                    //strFileName = Application.StartupPath + "\\Users\\" + cbo_users.Text + "\\Configuration";
                    strFileName = Application.StartupPath + "\\Users\\" + txt_Username.Text + "\\Configuration";
                    System.IO.FileStream fs = default(System.IO.FileStream);
                    if (System.IO.File.Exists(strFileName))
                    {
                        if (txt_Username.Text == "Guest")
                        {
                            MessageBox.Show("Please Sign Up as new user for performing the requied Tasks...", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        fs = new System.IO.FileStream(strFileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        System.IO.StreamReader sw = new System.IO.StreamReader(fs);
                        string pswrd = null, pswrd1 = null, usr1 = null, decryppswd = null, decryptuser = null;
                        pswrd = sw.ReadToEnd();
                        pswrd = pswrd.Replace("\r\n", "");

                        string[] pwsr;
                        pwsr = pswrd.Split(',');

                        usr1 = pwsr[0]; //User Name
                        pswrd1 = pwsr[1]; //Password                       
                        RequiredVariables.Usertype = pwsr[2].ToString();
                        RequiredVariables.Configuration = pwsr[3].ToString();
                        RequiredVariables.JarPositionCalibration = pwsr[4].ToString();
                        RequiredVariables.EngParameters = pwsr[5].ToString();
                        RequiredVariables.UsrManage = pwsr[6].ToString();
                        RequiredVariables.Runproto = pwsr[7].ToString();
                        RequiredVariables.Viewproto = pwsr[8].ToString();
                       // RequiredVariables.UsrCreate = pwsr[9].ToString();
                       // RequiredVariables.SensorChk = pwsr[10].ToString();
                        //RequiredVariables.EngParameters = pwsr[11].ToString();
                        sw.Close();
                        fs.Close();

                        decryppswd = CryptorEngine.Decrypt(pswrd1, true);
                        decryptuser = CryptorEngine.Decrypt(usr1, true);

                        RequiredVariables.decryptpassword = decryppswd;                        

                        if (decryptuser == txt_Username.Text)
                        {
                            uservalidate = true;
                            //return;
                        }
                        else
                        {
                            MessageBox.Show("Wrong User Name Entered, Please Check!!...", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            uservalidate = false;
                            txt_Username.Text = "";
                            txt_Username.Focus();
                            return;
                        }

                        if (decryppswd == txt_Password.Text)
                        {
                            passwordvalidate = true;
                            //return;
                        }
                        else
                        {
                            if (pwdcnt >= 3)
                            {
                                MessageBox.Show("User Details Not Available Please contact the Administrator", RequiredVariables.Msgtext, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                Application.Exit();
                            }
                            else
                            {
                                MessageBox.Show("Wrong Password Entered, Please Check!!...", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                passwordvalidate = false;
                                pwdcnt++;
                                txt_Password.Text = "";
                                txt_Password.Focus();
                                return;
                            }
                        }

                        if ((uservalidate == true) && (passwordvalidate == true))
                        {
                            if (txt_Username.Text == "AdminService@PnS")  // Checking for service user or other user
                            {
                                RequiredVariables.ServiceUser = true;
                            }
                            else
                            {
                                RequiredVariables.ServiceUser = false;
                            }
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("User Does Not Exist, Please Check!!.....", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        passwordvalidate = false;
                        txt_Password.Text = "";
                        txt_Username.Text = "";
                        txt_Username.Focus();
                        return;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("User Does Not Exist, Please Check!!.....\r\n Create New User", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                passwordvalidate = false;
                txt_Password.Text = "";
                txt_Username.Text = "";
                txt_Username.Focus();
                RequiredVariables.writeerrorlogfile("While validating Available users \r\n" + ex.ToString(), "In Frm_Login form in validate users");
            }
        }

        private void showmainform()
        {
            try
            {
                validate_users();
                if ((passwordvalidate == true) && (uservalidate == true))
                {
                    if (txt_Username.Text == "AdminService@PnS")
                    {
                        RequiredVariables.UserName = "Service Engineer";
                        RequiredVariables.Usertype = "Service";
                    }
                    else
                        RequiredVariables.UserName = txt_Username.Text;
                    //if (!File.Exists(FilePath))
                    //{
                    //    FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                    //    String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                    //    byte[] bdata = Encoding.Default.GetBytes("\nLogin UserName : " + txt_Username.Text + ",Login Time : " + s1);
                    //    // byte[] bdata = Encoding.Default.GetBytes("\n  RA1,J01," + txt_Xvalue.Text + "," + txt_Yvalue.Text + "," + txt_Zvalue.Text + "," + s1);
                    //    fileStream.Write(bdata, 0, bdata.Length);
                    //    fileStream.Close();
                    //}
                    this.Hide();
                    Form_MainMenu frm = new Form_MainMenu();
                    //Enginering_Mode frm = new Enginering_Mode();
                    //Frm_Main_Loading_BoderlessButtons frm = new Frm_Main_Loading_BoderlessButtons();
                    frm.Show();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void lbl_showPassword_Click(object sender, EventArgs e)
        {
            //lbl_showPassword.Visible = false;
             
            //lbl_hidepassword.Visible = true;
            txt_Password.UseSystemPasswordChar = false;
        }

        private void lbl_hidepassword_Click(object sender, EventArgs e)
        {
           // lbl_showPassword.Visible = true;
            //lbl_hidepassword.Visible = false;
            txt_Password.UseSystemPasswordChar = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_forgortpass_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(txt_Username.Text)))
            {
                MessageBox.Show("User Name should not be Blank!...... Please Enter User Name. ", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_Username.Text = "";
                txt_Username.Focus();
                return;
            }

            RequiredVariables.ForgotPassword = true;
            RequiredVariables.ChangePassword = false;
            RequiredVariables.UserName = txt_Username.Text;
            ForgotPassword fp = new ForgotPassword();
            fp.Show();
            //if (txt_Username.Text != string.Empty)
            //{
            //    this.Hide();
            //    ForgotPassword fp = new ForgotPassword();
            //    fp.forgotPassword();
            //    fp.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Please Enter Username ..!!", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txt_Username.Focus();
            //}
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_signout_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserManagement user = new UserManagement();
            user.Show();
            user.closeSignup();
         
        }

        private void label6_Click(object sender, EventArgs e) 
        {

        }
        //public NotifyKeyPress(KeyPressEventArgs e)
        //{
        //    OnKeyPress(e);
        //}
        private void btn_SignIn_Click(object sender, EventArgs e)
        {
            try
            {

                //if (txt_Username.Text == "AdminService@PnS")
                //{
                    signin();
                //}
                //else
                //{
                    checkpwddata();
                    validate_users();
                //}

                
                foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("Oskeyboard"))
                {
                    process.Kill();
                }
                if (passwordvalidate == true)
                {
                    showmainform();
                    sqlstr = "";
                    sqlstr = "Insert into UserDetails(UserName,Status,Loggedon,LoggedTime,Month) values('";
                    sqlstr = sqlstr + txt_Username.Text + "','";
                    string s1 = DateTime.Now.ToString("dd-MM-yyyy");
                    string s2 = DateTime.Now.ToString("HH:mm:ss");
                    string s4 = DateTime.Now.ToString("MMMM");
                    string s3 = "sign in";
                    sqlstr = sqlstr + s3 + "','" + s1 + "','" + s2 + "','" + s4 + "')";
                    cmd = new SqlCommand(sqlstr, con);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.ExecuteNonQuery();
                    //sqlstr = "Insert into UserInDetailed(UserName,SigninTme,SignoutTme,Date,Duration) values('";
                    //sqlstr = sqlstr + txt_Username.Text + "','";
                    //String s1 = DateTime.Now.ToString("dd-MM-yyyy");
                    //String s2 = DateTime.Now.ToString("HH:mm:ss:fff");
                    //string s3 = "sign in";
                    //String s4 = "hello";
                    //sqlstr = sqlstr + s3 + "','" + s1 + "','" + s2 + "','" + s4 + "')";
                    //cmd = new SqlCommand(sqlstr, con);
                    //if (con.State == ConnectionState.Closed)
                    //    con.Open();
                    //cmd.ExecuteNonQuery();

                    //if (!File.Exists(FilePath))
                    //{
                    //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                    //String s1 = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss:fff");
                    //byte[] bdata = Encoding.Default.GetBytes("\n" + txt_Username.Text + ",sign in," + s1);
                    //// byte[] bdata = Encoding.Default.GetBytes("\n  RA1,J01," + txt_Xvalue.Text + "," + txt_Yvalue.Text + "," + txt_Zvalue.Text + "," + s1);
                    //fileStream.Write(bdata, 0, bdata.Length);
                    //fileStream.Close();
                    // }
                }
            }
            catch (Exception ex)
            {
                RequiredVariables.writeerrorlogfile("While Signing Up the User " + ex.ToString(), "In Frm_Login form while clicking on SignUp Button");
            }
        }

        private void txt_Password_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void btn_password_Click(object sender, EventArgs e)
        {
            txt_Password.UseSystemPasswordChar = false;
        }

        private void btn_password_MouseLeave(object sender, EventArgs e)
        {
            txt_Password.UseSystemPasswordChar = true;
        }

        private void pb_Exit_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure to close the Application", RequiredVariables.Msgtext, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)

            {
                Application.Exit();
           
                foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("Oskeyboard"))
                {
                    process.Kill();
                }
            }
            else
            {
                return;
            }
        }

        private void pB_passwordBox_MouseDown(object sender, MouseEventArgs e)
        {
            txt_Password.UseSystemPasswordChar = false;
        }

        private void pB_passwordBox_MouseUp(object sender, MouseEventArgs e)
        {
            txt_Password.UseSystemPasswordChar = true;
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {
            txt_Username.Focus();
            check_useravailable();
            check_application_running();
            con.ConnectionString = Constr;
            RequiredVariables.DBConnStr = Constr;
            if (con.State == ConnectionState.Closed)
                con.Open();
            //if (!File.Exists(FilePath))
            //{
            //    FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            //    //String s1 = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss:fff");
            //    // byte[] bdata = Encoding.Default.GetBytes("\n" + txt_Username.Text + ",sign in," + s1);
            //    byte[] bdata = Encoding.Default.GetBytes("User,Status,Time\n");
            //    fileStream.Write(bdata, 0, bdata.Length);
            //    fileStream.Close();
            //}
        }

        private void txt_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(13)))
            {
                signin();
                foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("Oskeyboard"))
                {
                    process.Kill();
                }
                showmainform();
                sqlstr = "";
                sqlstr = "Insert into UserDetails(UserName,Status,Loggedon,LoggedTime,Month) values('";
                sqlstr = sqlstr + txt_Username.Text + "','";
                string s1 = DateTime.Now.ToString("dd-MM-yyyy");
                string s2 = DateTime.Now.ToString("HH:mm:ss");
                string s3 = "sign in";
                string s4 = DateTime.Now.ToString("MMMM");
                sqlstr = sqlstr + s3 + "','" + s1 + "','" + s2 + "','" + s4 + "')";
                cmd = new SqlCommand(sqlstr, con);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                cmd.ExecuteNonQuery();
                //if (!File.Exists(FilePath))
                //{
                //    FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                //    String s1 = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss:fff");
                //   // byte[] bdata = Encoding.Default.GetBytes("\n" + txt_Username.Text + ",sign in," + s1);
                //byte[] bdata = Encoding.Default.GetBytes("\n" + txt_Username.Text + ",sign in," + s1 );
                //   fileStreamZ.Write(bdata, 0, bdata.Length);
                //    fileStream.Close();
                // }
            }
        }
       
       
            private void chk_vk_CheckedChanged(object sender, EventArgs e)
            {
             Form_keyboardvirtual Fvk = new Form_keyboardvirtual();
             
                 if (chk_vk.Checked == true)
                 {
                     txt_Username.Focus();
                     //Fvk.Show();
                   System.Diagnostics.Process.Start("Oskeyboard.exe");
                   
                 }
                 else
                 {
                      foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("Oskeyboard"))
                      {
                         process.Kill();
                      }
                      //Fvk.Close();
                 }
               
            
            }

        
        private void txt_Username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Username.Select();
                txt_Username.BackColor = Color.SkyBlue;
                //textBox1.BackColor = Color.Empty;
            }
        }

        private void txt_Username_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void LoginScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void pB_passwordBox_Click(object sender, EventArgs e)
        {

        }
    }
}
