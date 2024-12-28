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

namespace HematoxinandEosin
{
    public partial class Reagent_Configuration : Form
    {
        public Reagent_Configuration()
        {
            InitializeComponent();
        }
        string Constr = "";//"Data Source=SYSPSENG006;User ID=sa;Password=sree@pns2013;Initial Catalog=PNSHE;Pooling=false;Max Pool Size=400;workstation id =SYSPSENG006";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataTable table = new DataTable("table");
        SqlDataAdapter sda = new SqlDataAdapter();
        Boolean addflg = false, modflg = false, delflg = false, gridsel = false;
        string sqlstr = "";
        ColorDialog colorDialog = new ColorDialog();


        private void clear()
        {
            cmb_CatalogNo.Text = String.Empty;
            cmb_Reagentname.Text = String.Empty;
            txt_ReagentColor.BackColor = Color.White;
            txt_shortReagentName.Text = String.Empty;
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("Oskeyboard"))
            {
                process.Kill();
            }
            RequiredVariables.btnConf = true;
        }

        private void btn_ReagentColor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            txt_ReagentColor.BackColor = colorDialog.Color;
        }

        private void btn_Modify_Click(object sender, EventArgs e)
        {
            addflg = false;
            modflg = true;
            delflg = false;
            btn_Save.Text = "Update";
            cmb_Reagentname.Focus();
            if (gridsel == false)
                cmb_Reagentname.SelectedIndex = 0;
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
            btn_Save.Text = "remove";
            cmb_Reagentname.Focus();
            cmb_Reagentname.SelectedIndex = 0;
            btn_Add.Enabled = false;
            btn_Delete.Enabled = false;
            btn_Modify.Enabled = false;
            btn_Save.Enabled = true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean availflg = false, availcatflg = false;
                btn_Save.Enabled = false;

                if ((string.IsNullOrEmpty(cmb_Reagentname.Text)))
                {
                    MessageBox.Show("Reagent Name should not be Blank!...... Please Enter User Name. ", RequiredVariables.Msgtext, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    cmb_Reagentname.Text = "";
                    cmb_Reagentname.Focus();
                    btn_Save.Enabled = true;
                    return;
                }

                if ((string.IsNullOrEmpty(txt_shortReagentName.Text)))
                {
                    MessageBox.Show("Reagent Short Name should not be Blank!...... Please Enter Password. ", RequiredVariables.Msgtext, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    txt_shortReagentName.Text = "";
                    txt_shortReagentName.Focus();
                    btn_Save.Enabled = true;
                    return;
                }

                if ((string.IsNullOrEmpty(cmb_CatalogNo.Text)))
                {
                    MessageBox.Show("Catalog Number should not be Blank!...... Please Enter User Name. ", RequiredVariables.Msgtext, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    cmb_CatalogNo.Text = "";
                    cmb_CatalogNo.Focus();
                    btn_Save.Enabled = true;
                    return;
                }

                sqlstr = "";
                if (con.State == ConnectionState.Closed)
                    con.Open();

                //Check Reagent Available or not if available display the prompt
                sqlstr = "Select * from CatalogNo where CatalogNo = '" + cmb_CatalogNo.Text + "'";
                sda = new SqlDataAdapter(sqlstr, con);
                table = new DataTable();
                sda.Fill(table);
                if (table.Rows.Count > 0)
                    availcatflg = true;
                else
                    availcatflg = false;
                if (availcatflg == false)
                {
                    sqlstr = "";
                    sqlstr = "Insert into CatalogNo(CatalogNo) values('" + cmb_CatalogNo.Text + "')";
                    cmd = new SqlCommand(sqlstr, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Catalog No details saved sucessfully to Database", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                //Check Reagent Available or not if available display the prompt
                sqlstr = "Select * from ReagentMaster where ReagentName = '" + cmb_Reagentname.Text + "'";
                sda = new SqlDataAdapter(sqlstr, con);
                table = new DataTable();
                sda.Fill(table);
                if (table.Rows.Count > 0)
                    availflg = true;
                else
                    availflg = false;

                if (gridsel == true)
                    gridsel = false;

                if (addflg == true)
                {
                    if (availflg == true)
                    {
                        MessageBox.Show(cmb_Reagentname.Text + " Reagent Details already Available in Database Please Enter another Name & other details and click on Save Button", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        btn_Save.Enabled = true;
                        return;
                    }
                    else if (availflg == false)
                    {
                        sqlstr = "";
                        sqlstr = "Insert into ReagentMaster(ReagentName,ShortName,ColorVal,CatalogNo) values('" + cmb_Reagentname.Text + "','" + txt_shortReagentName.Text + "'," + txt_ReagentColor.BackColor.ToArgb() + ",'" + cmb_CatalogNo.Text + "')";
                        cmd = new SqlCommand(sqlstr, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Reagent details saved sucessfully to Database", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (modflg == true)
                {
                    sqlstr = "";
                    sqlstr = "Update ReagentMaster set ShortName = '" + txt_shortReagentName.Text + "',ColorVal = " + txt_ReagentColor.BackColor.ToArgb();
                    sqlstr = sqlstr + ",CatalogNo = '" + cmb_CatalogNo.Text + "' where ReagentName = '" +cmb_Reagentname.Text + "'";
                    cmd = new SqlCommand(sqlstr, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Reagent details Modified Sucessfully and Updated to Database", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (delflg == true)
                {
                    if (MessageBox.Show("Are you Sure to delete the Selected Reagent Details", RequiredVariables.Msgtext, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (MessageBox.Show("The deleted Reagent details cann't be restored back \r\n Confirm to delete the Selected Reagent Information from database ", RequiredVariables.Msgtext, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            sqlstr = "";
                            sqlstr = "Delete from ReagentMaster where ReagentName = '" + cmb_Reagentname.Text + "'";
                            cmd = new SqlCommand(sqlstr, con);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Selected Reagent" + cmb_Reagentname.Text + "Sucessfully deleted from Database", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                load_reagents_catalogs_information();
                dg_reagents.ReadOnly = true;
                btn_Add.Enabled = true;
                btn_Delete.Enabled = true;
                btn_Modify.Enabled = true;
                btn_Save.Enabled = false;
                btn_Save.Text = "Save";
            }
            catch (Exception d3)
            {

            }
        }

        private void dg_reagents_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int inx = dg_reagents.CurrentRow.Index;
                btn_Add.Enabled = false;
                btn_Delete.Enabled = true;
                btn_Modify.Enabled = true;
                gridsel = true;
                loadregdetails(dg_reagents.Rows[inx].Cells["ReagName"].Value.ToString());
            }
            catch (Exception d3)
            {
            }
        }
        private void loadregdetails(string regname)
        {
            try
            {
                Color bkcolor;
                sqlstr = "";
                sqlstr = "Select * from ReagentMaster where ReagentName = '" + regname + "'";
                SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    cmb_Reagentname.Text = dt.Rows[0]["ReagentName"].ToString();
                    txt_shortReagentName.Text = dt.Rows[0]["ShortName"].ToString();
                    cmb_CatalogNo.Text = dt.Rows[0]["CatalogNo"].ToString();
                    bkcolor = Color.FromArgb(Convert.ToInt32(dt.Rows[0]["ColorVal"].ToString()));
                    txt_ReagentColor.BackColor = Color.FromArgb(Convert.ToInt32(dt.Rows[0]["ColorVal"].ToString()));
                }
                da.Dispose();
                dt.Dispose();
            }
            catch (Exception dx)
            {
            }
        }

        private void cmb_Reagentname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Reagentname.Text == "Select")
                return;
            else
            {
                loadregdetails(cmb_Reagentname.Text);
            }
        }

        private void Reagent_Configuration_Load(object sender, EventArgs e)
        {
            Constr = "";
            Constr = RequiredVariables.DBConnStr;
            //if (RequiredVariables.Usertype == "Service")
            //{
            //    bt_USBUpload.Visible = true;
            //}
            //else
            //{
            //    bt_USBUpload.Visible = false;
            //}

            // con = new SqlConnection();
            con.ConnectionString = Constr;
            if (con.State == ConnectionState.Closed)
                con.Open();
            //Loading the reagents details and catalog details
            load_reagents_catalogs_information();
            btn_Save.Enabled = false;
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

        private void Reagent_Configuration_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("Oskeyboard"))
            {
                process.Kill();
            }
        }

        private void load_reagents_catalogs_information()
        {
            string sqlstr = "";
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            int cnt = 0;
            //Reagents Loading to the combobox
            try
            {
                sqlstr = "select * from ReagentMaster order by Slno";
                da = new SqlDataAdapter(sqlstr, con);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    cmb_Reagentname.Items.Clear();
                    cmb_Reagentname.Items.Add("Select");
                    dg_reagents.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cmb_Reagentname.Items.Add(dt.Rows[i]["ReagentName"].ToString());
                        //Updating to grid
                        dg_reagents.Rows.Add();
                        cnt = dg_reagents.Rows.Count;
                        cnt = cnt - 2;
                        dg_reagents.Rows[cnt].Cells["Slno"].Value = dt.Rows[i]["Slno"].ToString();
                        dg_reagents.Rows[cnt].Cells["ReagName"].Value = dt.Rows[i]["ReagentName"].ToString();
                        dg_reagents.Rows[cnt].Cells["ReagShrtName"].Value = dt.Rows[i]["ShortName"].ToString();
                        dg_reagents.Rows[cnt].Cells["RegColor"].Style.BackColor = Color.FromArgb(Convert.ToInt32(dt.Rows[i]["ColorVal"].ToString()));
                        dg_reagents.Rows[cnt].Cells["RegColor"].Style.ForeColor = Color.FromArgb(Convert.ToInt32(dt.Rows[i]["ColorVal"].ToString()));
                        //Color.FromArgb(Convert.ToInt32(dt.Rows[0]["ColorVal"].ToString()));
                        //row.Cells["Decade1Hours"].Style.BackColor = Color.LightSalmon;
                        dg_reagents.Rows[cnt].Cells["CatlogNo"].Value = dt.Rows[i]["CatalogNo"].ToString();
                    }
                    cmb_Reagentname.SelectedIndex = 0;
                }
            }
            catch (Exception d3)
            {

            }
            //Catalogs Loading to the combobox
            try
            {
                sqlstr = "select * from CatalogNo order by Slno";
                da = new SqlDataAdapter(sqlstr, con);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    cmb_CatalogNo.Items.Clear();
                    cmb_CatalogNo.Items.Add("Select");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cmb_CatalogNo.Items.Add(dt.Rows[i]["CatalogNo"].ToString());
                    }
                    cmb_CatalogNo.SelectedIndex = 0;
                }
            }
            catch (Exception d3)
            {

            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            clear();
            addflg = true;
            modflg = false;
            delflg = false;
            btn_Save.Text = "Save";
           
            cmb_Reagentname.Focus();
            btn_Add.Enabled = false;
            btn_Delete.Enabled = false;
            btn_Modify.Enabled = false;
            btn_Save.Enabled = true;
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            clear();
            btn_Add.Enabled = true;
            btn_Modify.Enabled = true;
            btn_Delete.Enabled = true;
            btn_Save.Enabled = false;
            btn_Save.Text = "Save";
            btn_Refresh.Enabled = true;
            btn_Add.Focus();
        }
    }
}
