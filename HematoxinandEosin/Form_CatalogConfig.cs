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
    public partial class Form_CatalogConfig : Form
    {
        public Form_CatalogConfig()
        {
            InitializeComponent();
        }
        string Constr = "Data Source=SYSPSENG006;User ID=sa;Password=sree@pns2013;Initial Catalog=PNSHE;Pooling=false;Max Pool Size=400;workstation id =SYSPSENG006";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataTable table = new DataTable("table");
        SqlDataAdapter sda = new SqlDataAdapter();
        Boolean addflg = false, modflg = false, delflg = false, gridsel = false;
        string sqlstr = "";
        DataGridViewRow row;
        int index;
        string tabName = string.Empty;

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnSave.Text = "&Save";
            cmb_CatalogNo.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addflg = true;
            delflg = false;
            btnSave.Text = "Save";
            cmb_CatalogNo.Text = "";
            cmb_CatalogNo.Focus();
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            addflg = false;
            delflg = true;
            btnSave.Text = "Remove";
            if (gridsel == false)
            {
                cmb_CatalogNo.Text = "";
                cmb_CatalogNo.Focus();
            }
            else
            {
                cmb_CatalogNo.Focus();
            }
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean availflg = false;
                btnSave.Enabled = false;
                if ((string.IsNullOrEmpty(cmb_CatalogNo.Text)))
                {
                    MessageBox.Show("Catalog Number should not be Blank!...... Please Enter User Name. ", RequiredVariables.Msgtext, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    cmb_CatalogNo.Text = "";
                    cmb_CatalogNo.Focus();
                    btnSave.Enabled = true;
                    return;
                }

                sqlstr = "";
                if (con.State == ConnectionState.Closed)
                    con.Open();

                if (gridsel == true)
                    gridsel = false;

                //Check Reagent Available or not if available display the prompt
                sqlstr = "Select * from CatalogNo where CatalogNo = '" + cmb_CatalogNo.Text + "'";
                sda = new SqlDataAdapter(sqlstr, con);
                table = new DataTable();
                sda.Fill(table);
                if (table.Rows.Count > 0)
                    availflg = true;
                else
                    availflg = false;



                if (addflg == true)
                {
                    if (availflg == true)
                    {
                        MessageBox.Show(cmb_CatalogNo.Text + " Reagent Details already Available in Database Please Enter another Name & other details and click on Save Button", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmb_CatalogNo.Text = "";
                        cmb_CatalogNo.Focus();
                        btnSave.Enabled = true;
                        btnAdd.Enabled = false;
                        return;
                    }
                    else if (availflg == false)
                    {
                        sqlstr = "";
                        sqlstr = "Insert into CatalogNo(CatalogNo) values('" + cmb_CatalogNo.Text + "')";
                        cmd = new SqlCommand(sqlstr, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Catalog details saved sucessfully to Database", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (delflg == true)
                {
                    if (MessageBox.Show("Are you Sure to delete the Selected Catalog Details", RequiredVariables.Msgtext, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (MessageBox.Show("The deleted Catalog details cann't be restored back \r\n Confirm to delete the Selected Catalog Information from database ", RequiredVariables.Msgtext, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            sqlstr = "";
                            sqlstr = "Delete from CatalogNo where CatalogNo = '" + cmb_CatalogNo.Text + "'";
                            cmd = new SqlCommand(sqlstr, con);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Selected Catalog " + cmb_CatalogNo.Text + " Sucessfully deleted from Database", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                load_catalogs_information();
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = false;
                btnSave.Text = "Save";
            }
            catch (Exception d3)
            {

            }
        }

        private void dg_Catalogno_DoubleClick(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
            btnDelete.Focus();
            gridsel = true;
            load_specific_Catalog(dg_Catalogno.Rows[dg_Catalogno.CurrentRow.Index].Cells["CatlogNo"].Value.ToString());

        }

        private void cmbReagent_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            //try
            //{
                load_specific_Catalog(cmb_CatalogNo.Text);
           // load_catalogs_information();
                //Loading details to Grid
            //    sqlstr = "";
            //    sqlstr = "Select * from " + tabName + " where ProtocolName = '" + cmb_CatalogNo.Text + "' order by Slno";
            //    sda = new SqlDataAdapter(sqlstr, con);
            //    table = new DataTable();
            //    sda.Fill(table);
            //    if (table.Rows.Count > 0)
            //    {
            //        dg_Catalogno.Rows.Clear();
            //        for (int i = 0; i < table.Rows.Count; i++)
            //        {
            //            //    if (i == 0)
            //            //    {
            //            //        Jarinx = 0;
            //            //        //if (table.Rows[i]["JarNo"].ToString() == "Heater")
            //            //        //{


            //            //        //    chkHeat.Checked = true;

            //            //        //    cmbTempature.Text = table.Rows[i]["Temp_Reagent"].ToString();
            //            //        //    string[] st = table.Rows[i]["IncubationTime"].ToString().Split(':');
            //            //        //    //WashIncubatio.Value = DateTime.Now.AddMinutes(Convert.ToInt32(st[0]));
            //            //        //    //WashIncubatio.Value = DateTime.Now.AddSeconds(Convert.ToInt32(st[1]));                               
            //            //        //    d2 = "01-01-2000 00:" + st[0] + ":" + st[1];
            //            //        //    DateTime d1 = Convert.ToDateTime(d2);
            //            //        //    dt_Heatingtime.Value = d1;
            //            //        //}
            //            //        else
            //            //        {
            //            //            chkHeat.Checked = false;
            //            //        }
            //            //    }
            //            //if ((table.Rows[i]["JarNo"].ToString() == "W1") || (table.Rows[i]["JarNo"].ToString() == "W2") || (table.Rows[i]["JarNo"].ToString() == "W3") || (table.Rows[i]["JarNo"].ToString() == "W4") || (table.Rows[i]["JarNo"].ToString() == "W5") || (table.Rows[i]["JarNo"].ToString() == "W6") || (table.Rows[i]["JarNo"].ToString() == "Heater"))
            //            //{

            //            //}
            //            //else
            //            //{
            //            //    Jarinx++;
            //            //}

            //            dg_Catalogno.Rows.Add();
            //            dg_Catalogno.Rows[i].Cells["Slno"].Value = table.Rows[i]["Slno"].ToString();
            //            dg_Catalogno.Rows[i].Cells["CatlogNo"].Value = cmb_CatalogNo.Text;
            //           // dgv_Detail.Rows[i].Cells["JarName"].Value = table.Rows[i]["JarNo"].ToString();
            //            //dgv_Detail.Rows[i].Cells["RegName"].Value = table.Rows[i]["Temp_Reagent"].ToString();
            //            ////if (Convert.ToBoolean( dt.Rows[i]["WashRequired"].ToString()) == true)
            //            ////{
            //            ////    dgv_protodetails.Rows[i].Cells["Washreq"].Value = true;
            //            ////}
            //            ////else if (Convert.ToBoolean(dt.Rows[i]["WashRequired"].ToString()) == false)
            //            ////{
            //            ////    dgv_protodetails.Rows[i].Cells["Washreq"].Value = false;
            //            ////}
            //            ////dgv_protodetails.Rows[i].Cells["WashTime"].Value = dt.Rows[i]["WashTime"].ToString();
            //           // dgv_Detail.Rows[i].Cells["IncubTime"].Value = table.Rows[i]["IncubationTime"].ToString();
            //            //dgv_Detail.Rows[i].Cells["Noofdips"].Value = table.Rows[i]["No_of_Dips"].ToString();
            //        }
            //        //cmbNofJars.SelectedIndex = Jarinx;
            //    }
            //}
            //catch (Exception d3)
            //{
            //    MessageBox.Show(d3.ToString());
            //}
            //finally
            //{
            //}
        }
        private void load_catalogs_information()
        {
            string sqlstr = "";
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
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
                    dg_Catalogno.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cmb_CatalogNo.Items.Add(dt.Rows[i]["CatalogNo"].ToString());
                        dg_Catalogno.Rows.Add();
                        int cnt = dg_Catalogno.Rows.Count;
                        cnt = cnt - 2;
                        dg_Catalogno.Rows[cnt].Cells["Slno"].Value = (i + 1).ToString();
                        dg_Catalogno.Rows[cnt].Cells["CatlogNo"].Value = dt.Rows[i]["CatalogNo"].ToString();
                        cnt++;
                    }
                    cmb_CatalogNo.SelectedIndex = 0;
                }
            }
            catch (Exception d3)
            {

            }
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dg_Catalogno_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            row = dg_Catalogno.Rows[index];

            cmb_CatalogNo.Text = row.Cells[1].Value.ToString();
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

        private void Form_CatalogConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("Oskeyboard"))
            {
                process.Kill();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("Oskeyboard"))
            {
                process.Kill();
            }
            RequiredVariables.btnConf = true;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //con = new SqlConnection();
            Constr = "";
            Constr = RequiredVariables.DBConnStr;
            con.ConnectionString = Constr;
           // con.ConnectionString = RequiredVariables.DBConnStr;
            if (con.State == ConnectionState.Closed)
                con.Open();
            //Loading the reagents details and catalog details
            load_catalogs_information();
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnSave.Text = "Save";
        }
        private void load_specific_Catalog(string catlogno)
        {
            try
            {
                string sqlstr = "";
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                sqlstr = "select * from CatalogNo where CatalogNo = '" + catlogno + "'";
                da = new SqlDataAdapter(sqlstr, con);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    cmb_CatalogNo.Text = dt.Rows[0]["CatalogNo"].ToString();
                }
            }
            catch (Exception de)
            {

            }
        }

    }
}
