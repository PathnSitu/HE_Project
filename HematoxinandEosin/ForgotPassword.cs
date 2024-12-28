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

namespace HematoxinandEosin
{
    public partial class ForgotPassword : Form
    {
        string[] pwsr;
        public ForgotPassword()
        {
            InitializeComponent();
        }



        //
        //;
        

        public void forgotPassword()
        {
            lbl_ChangePassword.Visible = false;
            lbl_CurrentPassword.Visible = false;
            txt_CurrentPassword.Visible = false;
          //btn_currentpassword.Visible = false;
        }
        public void ChangePassword()
        {
            lbl_ForgotPassword.Visible = false;

        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginScreen ls = new LoginScreen();
            ls.Show();
        }

        private void pB_Currentpassword_MouseDown(object sender, MouseEventArgs e)
        {
            txt_CurrentPassword.UseSystemPasswordChar = false;
        }

        private void pB_Currentpassword_MouseUp(object sender, MouseEventArgs e)
        {
            txt_CurrentPassword.UseSystemPasswordChar = true;
        }

        private void btn_Newpassword_MouseDown(object sender, MouseEventArgs e)
        {
            txt_NewPassword.UseSystemPasswordChar = false;
        }

        private void btn_Newpassword_MouseUp(object sender, MouseEventArgs e)
        {
            txt_NewPassword.UseSystemPasswordChar = true;
        }

        private void btn_reenternewpassword_MouseDown(object sender, MouseEventArgs e)
        {
            txt_Reenterpassword.UseSystemPasswordChar = false;
        }

        private void btn_reenternewpassword_MouseUp(object sender, MouseEventArgs e)
        {
            txt_Reenterpassword.UseSystemPasswordChar = true;
        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {
            if (RequiredVariables.ChangePassword == true)
            {
                lbl_ForgotPassword.Text = "Change Password";
                this.Text = "Change Password";
                lbl_CurrentPassword.Visible = true;
                txt_CurrentPassword.Visible = true;
                pB_Currentpassword.Visible = true;
                //lbl_UserName.Visible = false;
            }
            else if (RequiredVariables.ForgotPassword == true)
            {
                //lbl_UserName.Visible = true;
               // lbl_UserName.Text = "User Name : " + RequiredVariables.UserName;
                lbl_ForgotPassword.Text = "Reset Your Password";
                this.Text = "Reset Your Password";
                lbl_CurrentPassword.Visible = false;
                txt_CurrentPassword.Visible = false;
                pB_Currentpassword.Visible = false;
                txt_NewPassword.Focus();
            }
            load_logged_user_details();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                //string chgString = "";
                btn_Save.Enabled = false;
                if (RequiredVariables.ChangePassword == true)
                {
                    if ((string.IsNullOrEmpty(txt_CurrentPassword.Text)))
                    {
                        MessageBox.Show("Old Password. should not be Blank!...... Please Enter Password. ", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_CurrentPassword.Text = "";
                        txt_CurrentPassword.Focus();
                        return;
                    }
                }

                if ((string.IsNullOrEmpty(txt_NewPassword.Text)))
                {
                    MessageBox.Show("Password. should not be Blank!...... Please Enter Password. ", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_NewPassword.Text = "";
                    txt_NewPassword.Focus();
                    return;
                }

                if ((string.IsNullOrEmpty(txt_Reenterpassword.Text)))
                {
                    MessageBox.Show("Confirm Password. should not be Blank!...... Please Enter Confirm Password. ", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_Reenterpassword.Text = "";
                    txt_Reenterpassword.Focus();
                    return;
                }

                if (txt_NewPassword.Text != txt_Reenterpassword.Text)
                {
                    MessageBox.Show("Entered Password's are Mismatched..... Please Enter again ", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_NewPassword.Text = "";
                   txt_Reenterpassword.Text = "";
                    txt_NewPassword.Focus();
                    return;
                }

                if (txt_NewPassword.Text ==txt_Reenterpassword.Text)
                {
                    string strFileName = Application.StartupPath + "\\Users\\" + RequiredVariables.UserName + "\\Configuration";
                    System.IO.FileStream fs = default(System.IO.FileStream);
                    if (File.Exists(strFileName))
                    {
                        fs = new System.IO.FileStream(strFileName, System.IO.FileMode.Truncate, System.IO.FileAccess.Write);
                    }
                    else
                    {
                        fs = new System.IO.FileStream(strFileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                    }
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);

                    string usrdata = null;
                    string encryptpassword = CryptorEngine.Encrypt(txt_Reenterpassword.Text.Trim(), true);

                    pwsr[1] = encryptpassword;
                    for (int i = 0; i < pwsr.Length; i++)
                    {
                        if (i <= pwsr.Length - 2)
                            usrdata = usrdata + pwsr[i].ToString() + ",";
                        else
                            usrdata = usrdata + pwsr[i].ToString();
                    }

                    sw.WriteLine(usrdata);
                    sw.Close();
                    fs.Close();
                    if (RequiredVariables.ChangePassword == true)
                    {
                        MessageBox.Show("Password Modified Sucessfully as requested by User", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (RequiredVariables.ForgotPassword == true)
                    {
                        MessageBox.Show("New Password Generated Sucessfully as requested by User", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                this.Close();
            }
            catch (Exception d3)
            {
                if (RequiredVariables.ChangePassword == true)
                {
                    MessageBox.Show("Unable to Change Password as requested by User", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (RequiredVariables.ForgotPassword == true)
                {
                    MessageBox.Show("Unable to Generated New Password as requested by User", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
        }
        private void load_logged_user_details()
        {
            try
            {
                string strFileName = null;
                //strFileName = Application.StartupPath + "\\Users\\" + cbo_users.Text + "\\Configuration";
                strFileName = Application.StartupPath + "\\Users\\" + RequiredVariables.UserName + "\\Configuration";
                System.IO.FileStream fs = default(System.IO.FileStream);
                if (System.IO.File.Exists(strFileName))
                {
                    fs = new System.IO.FileStream(strFileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                    System.IO.StreamReader sw = new System.IO.StreamReader(fs);
                    string pswrd = null, pswrd1 = null, usr1 = null, decryppswd = null, decryptuser = null;
                    pswrd = sw.ReadToEnd();
                    pswrd = pswrd.Replace("\r\n", "");

                    sw.Close();
                    fs.Close();


                    pwsr = pswrd.Split(',');

                    usr1 = pwsr[0]; //User Name
                    pswrd1 = pwsr[1]; //Password
                    decryppswd = CryptorEngine.Decrypt(pswrd1, true);
                    decryptuser = CryptorEngine.Decrypt(usr1, true);
                }
            }
            catch (Exception d3)
            {

            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
