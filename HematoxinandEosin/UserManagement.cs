using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HematoxinandEosin
{
    public partial class UserManagement : Form
    {
        public UserManagement()
        {
            InitializeComponent();
        }

        DataTable table = new DataTable("table");
        Boolean addflg = false, modflg = false, delflg = false;
        string directoryName = "";


        private void btn_password_Click(object sender, EventArgs e)
        {

           
        }
        private void refresh()
        {
            cmb_UserName.Text = "";
            txt_password.Text = "";
            txt_ConfirmPassword.Text = "";
            rdnAdmin.Checked = false;
            rdnuser.Checked = false;
            chk_Calibration.Checked = false;
            chk_Configuration.Checked = false;
            chk_Eng.Checked = false;
            chk_Reports.Checked = false;
            chk_RunProtocol.Checked = false;
            chk_UserManagement.Checked = false;

           // dg_UserDetails.Update;
        }
        private void refreshCheckBoxes()
        {
            chk_Calibration.Checked = false;
            chk_Configuration.Checked = false;
            chk_Eng.Checked = false;
            chk_Reports.Checked = false;
            chk_RunProtocol.Checked = false;
            chk_UserManagement.Checked = false;
        }
        private void btn_confirmpassword_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_password_MouseLeave(object sender, EventArgs e)
        {
           

        }

        private void btn_confirmpassword_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void btn_confirmpassword_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void btn_password_MouseUp(object sender, MouseEventArgs e)
        {
         
        }

        private void btn_password_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("Oskeyboard"))
            {
                process.Kill();
            }
            RequiredVariables.btnUser = true;
            //closetoLogin();
        }

        private void closetoLogin() 
        {
            this.Hide();
            LoginScreen ls = new LoginScreen();
            ls.Show();
        }
        private void pb_password_MouseUp(object sender, MouseEventArgs e)
        {
            txt_password.UseSystemPasswordChar = true;  
        }

        private void pb_password_MouseDown(object sender, MouseEventArgs e)
        {

            txt_password.UseSystemPasswordChar = false;
        }

        private void pb_confirmPassword_MouseUp(object sender, MouseEventArgs e)
        {
            txt_ConfirmPassword.UseSystemPasswordChar = true;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            addflg = true;
            modflg = false;
            delflg = false;
            btn_Save.Text = "Save";
            cmb_UserName.Text = "";
            refresh();
            txt_ConfirmPassword.Enabled = true;
            txt_password.Enabled = true;
            cmb_UserName.Focus();
            btn_Add.Enabled = false;
            btn_Delete.Enabled = false;
            btn_Modify.Enabled = false;
            btn_Save.Enabled = true;
        }

        private void btn_Modify_Click(object sender, EventArgs e)
        {
            addflg = false;
            modflg = true;
            delflg = false;
            btn_Save.Text = "Update";
            //Write code to load user details
            txt_ConfirmPassword.Enabled = false;
            txt_password.Enabled = false;
            //cmb_UserName.Text = "";
            //cmb_UserName.SelectedIndex = 0; //for not selecting from the grid
            cmb_UserName.Focus();
            btn_Add.Enabled = false;
            btn_Delete.Enabled = false;
            btn_Modify.Enabled = false;
            btn_Save.Enabled = true;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            addflg = false;
            modflg = false;
            delflg = true;
            btn_Save.Text = "Remove";
            //Write code to load user details
            txt_ConfirmPassword.Enabled = false;
            txt_password.Enabled = false;
            //cmb_UserName.Text = "";
           // cmb_UserName.SelectedIndex = 0;
            cmb_UserName.Focus();
            btn_Add.Enabled = false;
            btn_Delete.Enabled = false;
            btn_Modify.Enabled = false;
            btn_Save.Enabled = true;
            //refresh();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                string destination = "";
                string strFileName = null;
                if ((addflg == true) || (modflg == true))
                {
                    if ((string.IsNullOrEmpty(cmb_UserName.Text)))
                    {
                        MessageBox.Show("User Name. should not be Blank!...... Please Enter User Name. ", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmb_UserName.Text = "";
                        cmb_UserName.Focus();
                        return;
                    }

                    if ((string.IsNullOrEmpty(txt_password.Text)))
                    {
                        MessageBox.Show("Password. should not be Blank!...... Please Enter Password. ", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                       txt_password.Text = "";
                        txt_password.Focus();
                        return;
                    }

                    if ((string.IsNullOrEmpty(txt_ConfirmPassword.Text)))
                    {
                        MessageBox.Show("Confirm Password. should not be Blank!...... Please Enter Confirm Password. ", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                       txt_ConfirmPassword.Text = "";
                        txt_ConfirmPassword.Focus();
                        return;
                    }

                    if (txt_password.Text != txt_ConfirmPassword.Text)
                    {
                        MessageBox.Show("Entered Password Mismatched..... Please Enter again ", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_password.Text = "";
                       txt_ConfirmPassword.Text = "";
                        txt_password.Focus();
                        return;
                    }
                    
                    destination = Application.StartupPath + "\\Users\\" + cmb_UserName.Text;
                    if (Directory.Exists(destination))
                    {

                    }
                    else
                    {
                        Directory.CreateDirectory(destination);
                    }

                    strFileName = destination + "\\Configuration";
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
                    string encryptpassword = CryptorEngine.Encrypt(txt_ConfirmPassword.Text.Trim(), true);
                    string encryptuser = CryptorEngine.Encrypt(cmb_UserName.Text.Trim(), true);
                    //usrdata = txt_UsrName.Text.Trim() + "," + encryptpassword + "," + cbo_HintQusetion.Text + "," + txt_HintAnswer.Text;
                    usrdata = encryptuser + "," + encryptpassword + ",";
                   
                    if (rdnAdmin.Checked == true)
                    {
                        usrdata = usrdata + "Admin,";
                        
                    }
                    else if (rdnuser.Checked == true)
                    {
                        usrdata = usrdata + "User,";
                    }
                    if (chk_Configuration.Checked == false && chk_Calibration.Checked == false && chk_Eng.Checked == false && chk_UserManagement.Checked == false && chk_RunProtocol.Checked == false && chk_Reports.Checked == false)
                    {
                        //btn_Save.Enabled = false;
                        usrdata = usrdata + "0,0,0,0,0,1,";

                        //RequiredVariables.Configuration = "0";
                        //RequiredVariables.JarPositionCalibration = "0";
                        //RequiredVariables.EngParameters = "0";
                        //RequiredVariables.UsrManage = "0";
                        //RequiredVariables.Runproto = "0";
                        //RequiredVariables.Viewproto = "1";

                        // chk_Calibration.Checked = true;
                       
                        RequiredVariables.Viewproto = "1";
                        chk_Reports.Checked = true;
                        MessageBox.Show("This user will be saved, But user need to Have atleast user permissions, Please create a user again", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        chk_Calibration.Checked = false;
                        chk_Reports.Checked = true;
                        // RequiredVariables.JarPositionCalibration = "1";
                        refresh();
                            addflg = false;
                        
                    }
                        if (chk_Configuration.Checked == true)
                    {
                        usrdata = usrdata + "1,";
                        RequiredVariables.Configuration = "1";
                    }
                    else if (chk_Configuration.Checked == false)
                    {
                        usrdata = usrdata + "0,";
                        RequiredVariables.Configuration = "0";
                    }

                    if (chk_Calibration.Checked == true)
                    {
                        usrdata = usrdata + "1,";
                        RequiredVariables.JarPositionCalibration = "1";
                    }
                    else if (chk_Calibration.Checked == false)
                    {
                        usrdata = usrdata + "0,";
                        RequiredVariables.JarPositionCalibration = "0";
                    }

                    if (chk_Eng.Checked == true)
                    {
                        usrdata = usrdata + "1,";
                        RequiredVariables.EngParameters = "1";
                    }
                    else if (chk_Eng.Checked == false)
                    {
                        usrdata = usrdata + "0,";
                        RequiredVariables.EngParameters = "0";
                    }

                    if (chk_UserManagement.Checked == true)
                    {
                        usrdata = usrdata + "1,";
                        RequiredVariables.UsrManage = "1";
                    }
                    else if (chk_UserManagement.Checked == false)
                    {
                        usrdata = usrdata + "0,";
                        RequiredVariables.UsrManage = "0";
                    }

                    if (chk_RunProtocol.Checked == true)
                    {
                        usrdata = usrdata + "1,";
                        RequiredVariables.Runproto = "1";
                    }
                    else if (chk_RunProtocol.Checked == false)
                    {
                        usrdata = usrdata + "0,";
                        RequiredVariables.Runproto = "0";
                    }

                    if (chk_Reports.Checked == true)
                    {
                        usrdata = usrdata + "1,";
                        RequiredVariables.Viewproto = "1";
                    }
                    else if (chk_Reports.Checked == false)
                    {
                        usrdata = usrdata + "0,";
                        RequiredVariables.Viewproto = "0";
                    }

                    //if (chk_UsrCreate.Checked == true)
                    //{
                    //    usrdata = usrdata + "1,";
                    //    RequiredVariables.UsrCreate = "1";
                    //}
                    //else if (chk_UsrCreate.Checked == false)
                    //{
                    //    usrdata = usrdata + "0,";
                    //    RequiredVariables.UsrCreate = "0";
                    //}

                    //if (chk_SensorChk.Checked == true)
                    //{
                    //    usrdata = usrdata + "1,";
                    //    RequiredVariables.SensorChk = "1";
                    //}
                    //else if (chk_SensorChk.Checked == false)
                    //{
                    //    usrdata = usrdata + "0,";
                    //    RequiredVariables.SensorChk = "0";
                    //}

                    //if (chk_EngParameters.Checked == true)
                    //{
                    //    usrdata = usrdata + "1";
                    //    RequiredVariables.EngParameters = "1";
                    //}
                    //else if (chk_EngParameters.Checked == false)
                    //{
                    //    usrdata = usrdata + "0";
                    //    RequiredVariables.EngParameters = "0";
                    //}
                    //if (chk_Configuration.Checked == false && chk_Calibration.Checked == false && chk_Eng.Checked == false && chk_UserManagement.Checked == false && chk_RunProtocol.Checked == false && chk_Reports.Checked == false)
                    //{
                    //    //btn_Save.Enabled = false;
                    //    usrdata = usrdata+ "0,0,0,0,0,1";

                    //    //RequiredVariables.Configuration = "0";
                    //    //RequiredVariables.JarPositionCalibration = "0";
                    //    //RequiredVariables.EngParameters = "0";
                    //    //RequiredVariables.UsrManage = "0";
                    //    //RequiredVariables.Runproto = "0";
                    //    //RequiredVariables.Viewproto = "1";

                    //    // chk_Calibration.Checked = true;

                    //    if(MessageBox.Show("This user will be saved, But user need to Have atleast user permissions, Please create a user again", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information)==DialogResult.OK);
                    //    {
                    //        RequiredVariables.Viewproto = "1";
                    //        // RequiredVariables.JarPositionCalibration = "1";
                    //        refresh();
                    //        addflg = false;
                    //    }
                  //  }
                    sw.WriteLine(usrdata);
                    sw.Close();
                    fs.Close();
                    
                    if (addflg == true)
                    {
                       
                        MessageBox.Show("New User Information Saved to Database Sucessfully", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refresh();
                        
                    }
                    else if (modflg == true)
                    {
                        MessageBox.Show("User Information Modified and Updated to database Sucessfully", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refresh();
                    }
                }
                else if (delflg == true)
                {
                    if (MessageBox.Show("Are you Sure to delete the Selected User Information", RequiredVariables.Msgtext, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (MessageBox.Show("The deleted user details cann't be restored back \r\n Confirm to delete the Selected User Information from database ", RequiredVariables.Msgtext, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            destination = "";
                            destination = Application.StartupPath + "\\Users\\" + cmb_UserName.Text;
                            if (Directory.Exists(destination))
                            {
                                strFileName = destination + "\\Configuration";
                                if (File.Exists(strFileName))
                                {
                                    File.Delete(strFileName);
                                }
                                Directory.Delete(destination);
                                refresh();
                            }
                            MessageBox.Show("Selected User Information deleted from database Sucessfully", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            //return;
                            refresh();
                    }
                    else 
                    //if(MessageBox.Show("Are you Sure to delete the Selected User Information", RequiredVariables.Msgtext, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    {
                        //return;
                        refresh();
                    }
                }

                load_availableusers();

                btn_Save.Text = "Save";
                btn_Save.Enabled = false;
                btn_Delete.Enabled = true;
                btn_Add.Enabled = true;
                btn_Modify.Enabled = true;

                destination = Application.StartupPath + "\\Users\\Guest";
                if (Directory.Exists(destination))
                {
                    strFileName = destination + "\\Configuration";
                    if (File.Exists(strFileName))
                    {
                        File.Delete(strFileName);
                    }
                    Directory.Delete(destination);
                }


                //this.Close();
            }
            catch (Exception d3)
            {
                MessageBox.Show(d3.ToString(), RequiredVariables.Msgtext, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                //Communication.writeCommunicationlog("While Saving User details " + d3.ToString(), "In btn_SignUp function");
            }
            
        }

        private void cmb_UserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_UserName.Text == "Select")
                {
                    MessageBox.Show("Please select the Valid User Name from Drop Down Box", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    directoryName = cmb_UserName.Text;
                    load_selected_user_details();
                }
            }
            catch (Exception d3)
            {

            }
        }

        private void dg_UserDetails_DoubleClick(object sender, EventArgs e)
        {
            int inx = 0;
            inx = dg_UserDetails.CurrentRow.Index;
            directoryName = "";
            directoryName = dg_UserDetails.Rows[inx].Cells["UsrName"].Value.ToString();
            load_selected_user_details();
        }

        private void cmb_UserName_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_UserName.Text == "Select")
                {
                    MessageBox.Show("Please select the Valid User Name from Drop Down Box", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    directoryName = cmb_UserName.Text;
                    load_selected_user_details();
                }
            }
            catch (Exception d3)
            {

            }
        }

        private void rdnuser_CheckedChanged(object sender, EventArgs e)
        {
            pnl_permissions.Visible = true;
            //chk_Calibration.Enabled = false;
            //chk_Eng.Enabled = false;
            // chk_UserManagement.Enabled = false;
            //chk_Configuration.Enabled = false;
            //chk_SensorChk.Enabled = false;
            //chk_SWUpdate.Enabled = false;
            //chk_UsrCreate.Enabled = false;
            refreshCheckBoxes();
            chk_RunProtocol.Checked = true;
            chk_Reports.Checked = true;
            btn_Save.Focus();
            //UserPermissions();
        }

        private void rdnAdmin_CheckedChanged(object sender, EventArgs e)
        {
            pnl_permissions.Visible = true;
            //chk_CalibJarpos.Enabled = true;
            //chk_EngParameters.Enabled = true;
            //chk_Prepproto.Enabled = true;
            //chk_PrepReagent.Enabled = true;
            //chk_SensorChk.Enabled = true;
            //chk_SWUpdate.Enabled = true;
            //chk_UsrCreate.Enabled = true;
            chk_Calibration.Checked = true;
            chk_Eng.Checked = true;
            chk_UserManagement.Checked = true;
            chk_Configuration.Checked = true;
            //chk_SensorChk.Enabled = false;
            //chk_SWUpdate.Enabled = false;
            //chk_UsrCreate.Enabled = false;
            chk_RunProtocol.Checked = true;
            chk_Reports.Checked = true;
           // UserPermissions();

            

        }

        private void load_availableusers()
        {
            try
            {
                string path = Application.StartupPath + "\\Users";
                cmb_UserName.Items.Clear();
                cmb_UserName.Items.Add("Select");
                dg_UserDetails.Rows.Clear(); //Clearing the details
                dg_UserDetails.ReadOnly = true;
                foreach (string dir in Directory.GetDirectories(path))
                {
                    directoryName = string.Empty;
                    directoryName = dir.Replace(Application.StartupPath + "\\Users\\", "");
                    if (directoryName == "AdminService@PnS")
                    {
                        //Not Loading details for Service Engineer
                    }
                    else
                    {
                        cmb_UserName.Items.Add(directoryName);
                        //Updating Details to Grid
                        //Showing Password  
                        string strFileName = null;
                        //strFileName = Application.StartupPath + "\\Users\\" + cbo_users.Text + "\\Configuration";
                        strFileName = Application.StartupPath + "\\Users\\" + directoryName + "\\Configuration";
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

                            string[] pwsr;
                            pwsr = pswrd.Split(',');

                            usr1 = pwsr[0]; //User Name
                            pswrd1 = pwsr[1]; //Password
                            decryppswd = CryptorEngine.Decrypt(pswrd1, true);
                            decryptuser = CryptorEngine.Decrypt(usr1, true);

                            //Updating details to Grid to display Available User's to Administrator
                            dg_UserDetails.Rows.Add();
                            int cnt = dg_UserDetails.Rows.Count;
                            cnt = cnt - 1;
                            dg_UserDetails.Rows[cnt - 1].Cells["UsrName"].Value = decryptuser;
                            dg_UserDetails.Rows[cnt - 1].Cells["UsrType"].Value = pwsr[2].ToString();
                            if (pwsr[3].ToString() == "1")
                                dg_UserDetails.Rows[cnt - 1].Cells["conf"].Value = true;
                            else if (pwsr[3].ToString() == "0")
                                dg_UserDetails.Rows[cnt - 1].Cells["conf"].Value = false;

                            if (pwsr[4].ToString() == "1")
                                dg_UserDetails.Rows[cnt - 1].Cells["jarpositionCalib"].Value = true;
                            else if (pwsr[4].ToString() == "0")
                                dg_UserDetails.Rows[cnt - 1].Cells["jarpositionCalib"].Value = false;

                            if (pwsr[5].ToString() == "1")
                                dg_UserDetails.Rows[cnt - 1].Cells["engParameters"].Value = true;
                            else if (pwsr[5].ToString() == "0")
                                dg_UserDetails.Rows[cnt - 1].Cells["engParameters"].Value = false;

                            if (pwsr[6].ToString() == "1")
                                dg_UserDetails.Rows[cnt - 1].Cells["userManage"].Value = true;
                            else if (pwsr[6].ToString() == "0")
                                dg_UserDetails.Rows[cnt - 1].Cells["userManage"].Value = false;

                            if (pwsr[7].ToString() == "1")
                                dg_UserDetails.Rows[cnt - 1].Cells["runProtocol"].Value = true;
                            else if (pwsr[7].ToString() == "0")
                                dg_UserDetails.Rows[cnt - 1].Cells["runProtocol"].Value = false;

                            if (pwsr[8].ToString() == "1")
                                dg_UserDetails.Rows[cnt - 1].Cells["viewPrint"].Value = true;
                            else if (pwsr[8].ToString() == "0")
                                dg_UserDetails.Rows[cnt - 1].Cells["viewPrint"].Value = false;

                            //if (pwsr[5].ToString() == "1")
                            //    dg_UserDetails.Rows[cnt - 1].Cells["PrepProto"].Value = true;
                            //else if (pwsr[5].ToString() == "0")
                            //    dg_UserDetails.Rows[cnt - 1].Cells["PrepProto"].Value = false;

                            //if (pwsr[8].ToString() == "1")
                            //    dg_UserDetails.Rows[cnt - 1].Cells["prepReagent"].Value = true;
                            //else if (pwsr[8].ToString() == "0")
                            //    dg_UserDetails.Rows[cnt - 1].Cells["prepReagent"].Value = false;

                            //if (pwsr[11].ToString() == "1")
                            //    dg_UserDetails.Rows[cnt - 1].Cells["EngParam"].Value = true;
                            //else if (pwsr[11].ToString() == "0")
                            //    dg_UserDetails.Rows[cnt - 1].Cells["EngParam"].Value = false;



                        }
                    }
                }

            }
            catch (Exception d3)
            {

            }
        }
        private void load_selected_user_details()
        {
            try
            {
                string strFileName = null;
                //strFileName = Application.StartupPath + "\\Users\\" + cbo_users.Text + "\\Configuration";
                strFileName = Application.StartupPath + "\\Users\\" + directoryName + "\\Configuration";
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

                    string[] pwsr;
                    pwsr = pswrd.Split(',');

                    usr1 = pwsr[0]; //User Name
                    pswrd1 = pwsr[1]; //Password
                    decryppswd = CryptorEngine.Decrypt(pswrd1, true);
                    decryptuser = CryptorEngine.Decrypt(usr1, true);

                    cmb_UserName.Text = decryptuser;
                    txt_ConfirmPassword.Enabled = false;
                    txt_ConfirmPassword.Text = decryppswd;
                    txt_password.Enabled = false;
                    txt_password.Text = decryppswd;
                    //Updating details to Grid to display Available User's to Administrator

                    if (pwsr[2].ToString() == "Admin")
                        rdnAdmin.Checked = true;
                    else if (pwsr[2].ToString() == "User")
                        rdnuser.Checked = true;

                    if (pwsr[3].ToString() == "1")
                        chk_Configuration.Checked = true;
                    else if (pwsr[3].ToString() == "0")
                        chk_Configuration.Checked = false;

                    if (pwsr[4].ToString() == "1")
                       chk_Calibration.Checked = true;
                    else if (pwsr[4].ToString() == "0")
                        chk_Calibration.Checked = false;

                    if (pwsr[5].ToString() == "1")
                       chk_Eng.Checked = true;
                    else if (pwsr[5].ToString() == "0")
                        chk_Eng.Checked = false;

                    if (pwsr[6].ToString() == "1")
                        chk_UserManagement.Checked = true;
                    else if (pwsr[6].ToString() == "0")
                        chk_UserManagement.Checked = false;

                    if (pwsr[7].ToString() == "1")
                        chk_RunProtocol.Checked = true;
                    else if (pwsr[7].ToString() == "0")
                        chk_RunProtocol.Checked = false;

                    if (pwsr[8].ToString() == "1")
                        chk_Reports.Checked = true;
                    else if (pwsr[8].ToString() == "0")
                        chk_Reports.Checked = false;

                    //if (pwsr[5].ToString() == "1")
                    //    chk_Prepproto.Checked = true;
                    //else if (pwsr[5].ToString() == "0")
                    //    chk_Prepproto.Checked = false;

                    //if (pwsr[8].ToString() == "1")
                    //    chk_PrepReagent.Checked = true;
                    //else if (pwsr[8].ToString() == "0")
                    //    chk_PrepReagent.Checked = false;

                    //if (pwsr[11].ToString() == "1")
                    //    chk_EngParameters.Checked = true;
                    //else if (pwsr[11].ToString() == "0")
                    //    chk_EngParameters.Checked = false;
                }
            }
            catch (Exception d3)
            {

            }

        }
        public void UserPermissions()
        {
            //if ((RequiredVariables.btnConf == true) || (RequiredVariables.btnCalib == true) || (RequiredVariables.btnReports == true) || (RequiredVariables.btnRunProto == true) || (RequiredVariables.btnUser == true))
            //{
                if (chk_Calibration.Checked == true)
                {
                    RequiredVariables.btnCalib = true;
                }
                else if (chk_Calibration.Checked == false)
                {
                    RequiredVariables.btnCalib = false;
                }
                if (chk_Configuration.Checked == true)
                {
                    RequiredVariables.btnConf = true;
                }
                else if (chk_Configuration.Checked == false)
                {
                    RequiredVariables.btnConf = false;
                }
                if (chk_Eng.Checked == true)
                {
                    RequiredVariables.btnEng = true;
                }
                else if (chk_Eng.Checked == false)
                {
                    RequiredVariables.btnEng = false;
                }
                if (chk_Reports.Checked == true)
                {
                    RequiredVariables.btnReports = true;
                }
                else if (chk_Reports.Checked == false)
                {
                    RequiredVariables.btnReports = false;
                }
                if (chk_RunProtocol.Checked == true)
                {
                    RequiredVariables.btnRunProto = true;
                }
                else if (chk_RunProtocol.Checked == false)
                {
                    RequiredVariables.btnRunProto = false;
                }
                if (chk_UserManagement.Checked == true)
                {
                    RequiredVariables.btnCalib = true;
                }
                else if (chk_UserManagement.Checked == false)
                {
                    RequiredVariables.btnCalib = false;
                }
            //}
        }
        private void dg_UserDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_CloseSignup_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginScreen ls = new LoginScreen();
            ls.Show();
        }
        public void closeSignup()
        {
            btn_Close.Visible = false;
            btn_CloseSignup.Visible = true;
           
            btn_CloseSignup.Location = new Point(691,384);
           
        }
        public void closeUser()
        {
            btn_Close.Visible = true;
            btn_Close.Location = new Point(691, 384);
        }

        private void chk_Configuration_CheckedChanged(object sender, EventArgs e)
        {
            //if (chk_Configuration.Checked == true)
            //{
            //    RequiredVariables.btnConf = true;
            //}
            //else if (chk_Configuration.Checked == false)
            //{
            //    RequiredVariables.btnConf = false;
            //}
        }

        private void chk_Calibration_CheckedChanged(object sender, EventArgs e)
        {
            //if (chk_Calibration.Checked == true)
            //{
            //    RequiredVariables.btnCalib = true;
            //}
            //else if (chk_Calibration.Checked == false)
            //{
            //    RequiredVariables.btnCalib = false;
            //}
        }

        private void chk_Eng_CheckedChanged(object sender, EventArgs e)
        {
            //if (chk_Eng.Checked == true)
            //{
            //    RequiredVariables.btnEng = true;
            //}
            //else if (chk_Eng.Checked == false)
            //{
            //    RequiredVariables.btnEng = false;
            //}
        }

        private void chk_Reports_CheckedChanged(object sender, EventArgs e)
        {
            //if (chk_Reports.Checked == true)
            //{
            //    RequiredVariables.btnReports = true;
            //}
            //else if (chk_Reports.Checked == false)
            //{
            //    RequiredVariables.btnReports = false;
                   
            //}
        }

        private void chk_RunProtocol_CheckedChanged(object sender, EventArgs e)
        {
        //    if (chk_RunProtocol.Checked == true)
        //    {
        //        RequiredVariables.btnRunProto = true;
        //    }
        //    else if (chk_RunProtocol.Checked == false)
        //    {
        //        RequiredVariables.btnRunProto = false;
        //    }
        }

        private void chk_UserManagement_CheckedChanged(object sender, EventArgs e)
        {
            //if (chk_UserManagement.Checked == true)
            //{
            //    RequiredVariables.btnCalib = true;
            //}
            //else if (chk_UserManagement.Checked == false)
            //{
            //    RequiredVariables.btnCalib = false;
            //}
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            btn_Add.Enabled = true;
            btn_Modify.Enabled = true;
            btn_Delete.Enabled = true;
            btn_Save.Enabled = true;
            refresh();
        }

        private void chk_vk_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_vk.Checked == true)
            {
                //OpenChildForm(new Form_keyboard());
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

        private void UserManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("Oskeyboard"))
            {
                process.Kill();
            }
        }

        private void pb_confirmPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txt_ConfirmPassword.UseSystemPasswordChar = false;
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            load_availableusers();

        }
    }
}
