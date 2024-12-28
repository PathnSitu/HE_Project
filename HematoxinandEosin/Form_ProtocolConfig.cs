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
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Diagnostics;
using System.Drawing.Printing;

using Image = iTextSharp.text.Image;
using System.Threading;

namespace HematoxinandEosin
{
    public partial class Form_ProtocolConfig : Form
    {
        string Constr = "";//"Data Source=SYSPSENG006;User ID=sa;Password=sree@pns2013;Initial Catalog=PNSHE;Pooling=false;Max Pool Size=400;workstation id =SYSPSENG006";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataTable table = new DataTable("table");
        SqlDataAdapter sda = new SqlDataAdapter();
        Boolean addflg = false, modflg = false, delflg = false, gridsel = false;
        string sqlstr = "";
        string prototype = "";
        int index;
        int Slno = 1;
        int Jarinx = 0, tot_Jars = 0;
        //Boolean addflg = false, modflg = false, delflg = false, gridsel = false;
        string tabName = string.Empty;
        //DateTimePicker genDate;
        string IMG1 = "Images/logos.png";
        //string FilePath = Path.Combine(@"G:\projects\mukesh\HematoxinandEosin\HematoxinandEosin\bin\Debug\Lab.txt");
        string FilePath = Application.StartupPath + "\\Lab.txt";

        public Form_ProtocolConfig()
        {
            InitializeComponent();
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
        
        private void Form9_Load(object sender, EventArgs e)
        {
            

            try
            {
                #region Database Connection
                Constr = "";
                Constr = RequiredVariables.DBConnStr;
                con.ConnectionString = Constr;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                #endregion

                #region Jar Details Loading
                //Loading Jar Names
                loadPositiondetails_db(); //Loading Jar Names from database to grid
                //Updating Temperature Value to Grid
                cmbNofJars.Items.Clear();
                cmbNofJars.Items.Add("Select");
                for (int i = 1; i <= 51; i++)
                    cmbNofJars.Items.Add(i.ToString());
               // cmbNofJars.SelectedIndex = 0;
                //if (((RequiredVariables.Usertype == "Admin") && (RequiredVariables.SWUpdate == "1")) || (RequiredVariables.Usertype == "Service"))
                //{
                //    bt_USBUpload.Enabled = true;
                //    bt_USBUpload.Visible = true;
                //}
                //else
                //{
                //    bt_USBUpload.Enabled = false;
                //    bt_USBUpload.Visible = false;
                //}
                #endregion

                #region Reagents Information Loading
                load_reagents_information();
                #endregion

                #region Heater Related
                panel_Heat.Enabled = false;
                panel_Heat.Visible = false;
                cmbTempature.Items.Clear();
                cmbTempature.Items.Add("Select");
                for (int t = 1; t <= 100; t++)
                    cmbTempature.Items.Add(t.ToString());
                cmbTempature.SelectedIndex = 0;
                #endregion

                #region Dips Information
                cmbNofDips.Items.Clear();
                cmbNofDips.Items.Add("Select");
                for (int j = 0; j <= 30; j++)
                    cmbNofDips.Items.Add(j.ToString());
                cmbNofDips.SelectedIndex = 0;
                #endregion

                #region Available Protocols
                load_Protocols();
                #endregion
            }
            catch (Exception d3)
            {

            }
            finally
            {
            }

        }

        private DataTable FetchJPosDetails()
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection(RequiredVariables.DBConnStr);
            string sqlstr = "";
            sqlstr = "select * from JarPosDeatils order by sno";
            SqlDataAdapter sda = new SqlDataAdapter(sqlstr, cn);
            sda.Fill(dt);
            if(cn.State == ConnectionState.Open) cn.Close();
            return dt;
        }
        private async void loadPositiondetails_db()
        {
            try
            {
                
                DataTable JPos_DB = new DataTable();
                JPos_DB = await Task.Run(() => FetchJPosDetails());
                if (JPos_DB.Rows.Count > 0)
                {
                    cmbJarName.Items.Clear();
                    cmbJarName.Items.Add("Select");
                    for (int i = 0; i < JPos_DB.Rows.Count; i++)
                    {
                        cmbJarName.Items.Add(JPos_DB.Rows[i]["JarName"].ToString());                        
                    }
                    cmbJarName.SelectedIndex = 0;
                }
            }
            catch (Exception d3)
            {
                MessageBox.Show(d3.ToString(), "Loading Jar's value details to combobox from database", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button2_Click(object sender, EventArgs e)//btn_Load
        {
            //panel_Heat.Visible = true;
            if (cmbProtocol.Text != "" && txtProtoShortName.Text != "" && cmbNofJars.Text != "")
            {
              //  chkHeat.Visible = true;

                panel_reagent.Visible = true;

            if (rdnFactory.Checked == true)
            {
                prototype = "FP";
            }
            else if (rdnUser.Checked == true)
            {
                prototype = "UP";
            }
            sqlstr = "Select * from ProtocolMaster where ProtocolName = '" + cmbProtocol.Text + "' and ProtocolType = '" + prototype + "'";
            sda = new SqlDataAdapter(sqlstr, con);
            table = new DataTable();
            sda.Fill(table);
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Protocol Already Exist with this Name....\r\n Please Enter Another Name", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbProtocol.Text = "";
                cmbProtocol.Focus();
                return;
            }
            tot_Jars = 0;
            tot_Jars = Convert.ToInt32(cmbNofJars.Text);


            Jarinx = 0;
            sqlstr = "";
            sqlstr = "Insert into ProtocolMaster(ProtocolName,ShortName,ProtocolType,CreatedOn,CreatedBy,Agitation,Description) values('";
            sqlstr = sqlstr + cmbProtocol.Text + "','" + txtProtoShortName.Text + "','";
            prototype = "";
            if (rdnFactory.Checked == true)
            {
                sqlstr = sqlstr + "FP',";
                prototype = "Factory";
            }
            else if (rdnUser.Checked == true)
            {
                sqlstr = sqlstr + "UP',";
                prototype = "User";
            }
            sqlstr = sqlstr + "'" + genDate.Value.ToString().Substring(0, 10) + "','" + RequiredVariables.UserName + "',";
            if (chkAgitation.Checked == true)
            {
                sqlstr = sqlstr + "'1',";
            }
            else
            {
                sqlstr = sqlstr + "'0',";
            }
                sqlstr = sqlstr + "'" + txt_describe.Text+"')";
                cmd = new SqlCommand(sqlstr, con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Protocol Master details Updated to database sucessfully", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_loadDetails.Enabled = false;
        }
            if(cmbProtocol.Text==""|| txtProtoShortName.Text=="" || cmbNofJars.Text=="" ) {
                MessageBox.Show("Please enter the details", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbProtocol.Focus();
            }
            //Adding details to Grid
            if (chkHeat.Checked == true)
            {
                DateTime d1;
                d1 = System.DateTime.Now.AddSeconds(0);
                d1 = System.DateTime.Now.AddMinutes(0);
                //dt_Washtime.Enabled = true;
                dt_Heatingtime.Value = d1;
                Slno = 1;
                dgv_Detail.Rows.Clear();
                dgv_Detail.Rows.Add();
                dgv_Detail.Rows[dgv_Detail.Rows.Count - 2].Cells["sln"].Value = Slno.ToString();
                dgv_Detail.Rows[dgv_Detail.Rows.Count -2].Cells["protoName"].Value = cmbProtocol.Text;
                dgv_Detail.Rows[dgv_Detail.Rows.Count - 2].Cells["JarName"].Value = "Heater";
                dgv_Detail.Rows[dgv_Detail.Rows.Count - 2].Cells["RegName"].Value = cmbTempature.Text;
                dgv_Detail.Rows[dgv_Detail.Rows.Count - 2].Cells["IncubTime"].Value = dt_Heatingtime.Value.ToString().Substring(14, 5);
                ////dgv_protodetails.Rows[dgv_protodetails.Rows.Count - 2].Cells["Washreq"].Value = false;
                ////dgv_protodetails.Rows[dgv_protodetails.Rows.Count - 2].Cells["WashTime"].Value = "00:00";
                dgv_Detail.Rows[dgv_Detail.Rows.Count - 2].Cells["Noofdips"].Value = "0";
                Slno++;
            }
            else
            {
                dgv_Detail.Rows.Clear();
                Slno = 1;
            }
        }

        private void chkHeat_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHeat.Checked == true)
            {
                panel_Heat.Enabled = true;
                panel_Heat.Visible = true;               
            }
            else
            {
                panel_Heat.Enabled = false;
                panel_Heat.Visible = false;
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            addflg = false;
            modflg = true;
            delflg = false;
            btnSave.Text = "Update";
            //Write code to load user details            
            cmbProtocol.Focus();
            cmbProtocol.SelectedIndex = 0;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnModify.Enabled = false;
            btnSave.Enabled = true;
        }
           
        private void Clear()
        {
            cmbProtocol.Text = String.Empty;
            txtProtoShortName.Text = String.Empty;
            cmbNofJars.Text= String.Empty;
            txt_describe.Text= String.Empty;
            cmbJarName.Text = String.Empty;
            cmbNofDips.Text = String.Empty;
            cmbReagent.Text = String.Empty;
            cmbTempature.Text = String.Empty;
            txtReagentShortName.Text = String.Empty;
        }
        private void chk_WashRequired_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_WashRequired.Checked == true)
            {
                pnl_Wsh.Visible = true;
            }
            else
            {
                pnl_Wsh.Visible =false;
            }
        }
        private int numberOfThreads = 1;
        private int iterationsPerThread = 1;
        private async void fetchprotodetails(String prtoname)
        {
            try
            {                
                string d2 = "";
                try
                {
                    sqlstr = "";
                    sqlstr = "Select * from ProtocolMaster where ProtocolName = '" + prtoname + "'";
                    sda = new SqlDataAdapter(sqlstr, con);
                    table = new DataTable();
                    sda.Fill(table);
                    // chkHeat.Visible = true;
                    chkHeat.Visible = true;

                    panel_reagent.Visible = true;
                    if (table.Rows.Count > 0)
                    {
                        if (table.Rows[0]["ProtocolType"].ToString() == "FP")
                        {
                            tabName = "FactoryProtocolDetails";
                            rdnFactory.Checked = true;
                        }
                        else if (table.Rows[0]["ProtocolType"].ToString() == "UP")
                        {
                            tabName = "UserProtocolDetails";
                            rdnUser.Checked = true;
                        }

                        txtProtoShortName.Text = table.Rows[0]["ShortName"].ToString();
                        if (Convert.ToBoolean(table.Rows[0]["Agitation"].ToString()) == true)
                            chkAgitation.Checked = true;
                        else if (Convert.ToBoolean(table.Rows[0]["Agitation"].ToString()) == false)
                            chkAgitation.Checked = false;
                        txt_describe.Text = table.Rows[0]["Description"].ToString();
                        d2 = table.Rows[0]["CreatedOn"].ToString() + " 00:00:00";
                        genDate.Value = Convert.ToDateTime(d2);
                    }
                    table.Dispose();
                    sda.Dispose();
                }
                catch (Exception d3)
                {
                    MessageBox.Show(d3.ToString());
                }
                finally
                {

                }

                try
                {
                    sqlstr = "";
                    sqlstr = "Select * from " + tabName + " where ProtocolName = '" + prtoname + "' order by Slno";
                    sda = new SqlDataAdapter(sqlstr, con);
                    table = new DataTable();
                    sda.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        dgv_Detail.Rows.Clear();
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            if (i == 0)
                            {
                                Jarinx = 0;
                                if (table.Rows[i]["JarNo"].ToString() == "Heater")
                                {
                                    chkHeat.Checked = true;
                                    cmbTempature.Text = table.Rows[i]["Temp_Reagent"].ToString();
                                    string[] st = table.Rows[i]["IncubationTime"].ToString().Split(':');
                                    //WashIncubatio.Value = DateTime.Now.AddMinutes(Convert.ToInt32(st[0]));
                                    //WashIncubatio.Value = DateTime.Now.AddSeconds(Convert.ToInt32(st[1]));                               
                                    d2 = "01-01-2000 00:" + st[0] + ":" + st[1];
                                    DateTime d1 = Convert.ToDateTime(d2);
                                    dt_Heatingtime.Value = d1;
                                }
                                else
                                {
                                    chkHeat.Checked = false;
                                }
                            }
                            if ((table.Rows[i]["JarNo"].ToString() == "W1") || (table.Rows[i]["JarNo"].ToString() == "W2") || (table.Rows[i]["JarNo"].ToString() == "W3") || (table.Rows[i]["JarNo"].ToString() == "W4") || (table.Rows[i]["JarNo"].ToString() == "W5") || (table.Rows[i]["JarNo"].ToString() == "W6") || (table.Rows[i]["JarNo"].ToString() == "Heater"))
                            {

                            }
                            else
                            {
                                Jarinx++;
                            }
                            dgv_Detail.Rows.Add();
                            dgv_Detail.Rows[i].Cells["sln"].Value = table.Rows[i]["Slno"].ToString();
                            dgv_Detail.Rows[i].Cells["protoName"].Value = cmbProtocol.Text;
                            dgv_Detail.Rows[i].Cells["JarName"].Value = table.Rows[i]["JarNo"].ToString();
                            dgv_Detail.Rows[i].Cells["RegName"].Value = table.Rows[i]["Temp_Reagent"].ToString();
                            ////if (Convert.ToBoolean( dt.Rows[i]["WashRequired"].ToString()) == true)
                            ////{
                            ////    dgv_protodetails.Rows[i].Cells["Washreq"].Value = true;
                            ////}
                            ////else if (Convert.ToBoolean(dt.Rows[i]["WashRequired"].ToString()) == false)
                            ////{
                            ////    dgv_protodetails.Rows[i].Cells["Washreq"].Value = false;
                            ////}
                            ////dgv_protodetails.Rows[i].Cells["WashTime"].Value = dt.Rows[i]["WashTime"].ToString();
                            dgv_Detail.Rows[i].Cells["IncubTime"].Value = table.Rows[i]["IncubationTime"].ToString();
                            dgv_Detail.Rows[i].Cells["Noofdips"].Value = table.Rows[i]["No_of_Dips"].ToString();
                        }
                        cmbNofJars.SelectedIndex = Jarinx;
                    }
                }
                catch (Exception d3)
                {
                    MessageBox.Show(d3.ToString());
                }
                finally
                {

                }

            }
            finally
            {
                
            }
        }
        private void cmbProtocol_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (cmbProtocol.Text == "Select")
                return;            
            fetchprotodetails(cmbProtocol.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            addflg = false;
            modflg = false;
            delflg = true;
            btnSave.Text = "Remove";
            //Write code to load user details            
           // cmbProtocol.SelectedIndex = 0;
            cmbProtocol.Focus();
            btnAdd.Enabled    = false;
            btnDelete.Enabled = false;
            btnModify.Enabled = false;
            btnSave.Enabled   = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (prototype == "Factory")
                    tabName = "FactoryProtocolDetails";
                else if (prototype == "User")
                    tabName = "UserProtocolDetails";
                if (addflg == true)
                {
                    for (int i = 0; i < dgv_Detail.Rows.Count - 1; i++)
                    {
                        sqlstr = "";
                        //sqlstr = "Insert into " + tabName + "(Slno,ProtocolName,JarNo,Temp_Reagent,WashRequired,IncubationTime,No_of_Dips,WashTime) Values(";
                        sqlstr = "Insert into " + tabName + "(Slno,ProtocolName,JarNo,Temp_Reagent,IncubationTime,No_of_Dips) Values(";
                        sqlstr = sqlstr + Convert.ToInt32(dgv_Detail.Rows[i].Cells["sln"].Value.ToString()) + ",'";
                        sqlstr = sqlstr + (dgv_Detail.Rows[i].Cells["protoName"].Value.ToString()) + "','";
                        sqlstr = sqlstr + (dgv_Detail.Rows[i].Cells["JarName"].Value.ToString()) + "','";
                        sqlstr = sqlstr + (dgv_Detail.Rows[i].Cells["RegName"].Value.ToString()) + "','";
                        ////if(Convert.ToBoolean(dgv_protodetails.Rows[i].Cells["Washreq"].Value)==true)
                        ////{
                        ////    sqlstr = sqlstr + "1,'";
                        ////}
                        ////else if (Convert.ToBoolean(dgv_protodetails.Rows[i].Cells["Washreq"].Value) == false)
                        ////{
                        ////    sqlstr = sqlstr + "0,'";
                        ////}
                        sqlstr = sqlstr + (dgv_Detail.Rows[i].Cells["IncubTime"].Value.ToString()) + "',";
                        sqlstr = sqlstr + Convert.ToInt32(dgv_Detail.Rows[i].Cells["Noofdips"].Value.ToString()) + ")";
                        ////sqlstr = sqlstr + ",'" + (dgv_protodetails.Rows[i].Cells["Washtime"].Value.ToString()) + "')";                         
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        cmd = new SqlCommand(sqlstr, con);
                        cmd.ExecuteNonQuery();                            
                    }
                    MessageBox.Show("Protocol details Sucessfully Saved to database", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    cmd.Dispose();
                    con.Close();
                    Jarinx = 1;
                }
                else if (modflg == true)
                {
                    //Updating only Selected Record...
                    sqlstr = "";
                    sqlstr = "Update " + tabName + " set JarNo = '" + cmbJarName.Text + "',Temp_Reagent='" + cmbReagent.Text + "',";
                    sqlstr = sqlstr + "IncubationTime='" + dt_incubationtime.Value.ToString().Substring(14, 5) + "',No_of_Dips = " + Convert.ToInt32(cmbNofDips.Text);
                    sqlstr = sqlstr + " where ProtocolName = '" + cmbProtocol.Text + "' and Slno = " + Slno;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd = new SqlCommand(sqlstr, con);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();
                    MessageBox.Show("Protocol details Sucessfully Modified and updated to database", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Clear();
                    btnAdd.Enabled = true;
                    btnDelete.Enabled = true;
                    btnModify.Enabled = true;
                    btnSave.Enabled = true;

                }
                else if (delflg == true)
                {
                    if (MessageBox.Show("Are you Sure to delete the Selected Protocol Information", RequiredVariables.Msgtext, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (MessageBox.Show("The deleted Protocol details cann't be restored back \r\n Confirm to delete the Selected protocol Information from database ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            if (con.State == ConnectionState.Closed)
                                con.Open();
                            //Deleting information from protocol Master Table
                            sqlstr = string.Empty;
                            sqlstr = "Delete from ProtocolMaster where ProtocolName = '" + cmbProtocol.Text + "'";
                            cmd = new SqlCommand(sqlstr, con);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();

                            if (con.State == ConnectionState.Closed)
                                con.Open();
                            //Deleting information from protocol details from Factory / User protocol
                            sqlstr = string.Empty;
                            sqlstr = "Delete from " + tabName + "where ProtocolName = '" + cmbProtocol.Text + "'";
                            cmd = new SqlCommand(sqlstr, con);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                            con.Close();
                            MessageBox.Show("Selected Protocol details Sucessfully Deleted from database", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            Clear();
                            btnAdd.Enabled = true;
                            btnDelete.Enabled = true;
                            btnModify.Enabled = true;
                            btnSave.Enabled = true;
                        }
                    }
                }
                btnAdd.Enabled = true;
                btnModify.Enabled = true;
                btnDelete.Enabled = true;
                btn_LoadGrid.Enabled = true;
                btn_loadDetails.Enabled = true;
                btnSave.Enabled = false;                    
                btnAdd.Focus();
                Slno = 1;
                load_Protocols();
            }
            catch (Exception d3)
            {

            }
            finally
            {
            
            }        
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear();
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnModify.Enabled = true;
            btnSave.Enabled = true;            
            btn_LoadGrid.Enabled = true;
            btn_LoadGrid.Enabled = true;
        }

        private void cmbNofJars_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btn_ExportPdf_Click(object sender, EventArgs e)
        {
            if (dgv_Detail.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dgv_Detail.Columns.Count);

                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dgv_Detail.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));

                                pdfTable.AddCell(cell);
                            }


                            foreach (DataGridViewRow row in dgv_Detail.Rows)
                            {
                                // PdfPCell cell = new PdfPCell(new Phrase(row.HeaderText));
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    try
                                    {
                                        pdfTable.AddCell(cell.Value.ToString());
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error :" + ex.Message);
                                    }
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }

                    }
                }
                //else
                //{
                //    MessageBox.Show("No Record To Export !!!", "Info");
                //}
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }

        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            if (dgv_Detail.Rows.Count > 0)
            {
                PrintDocument Pd = new PrintDocument();
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "ProtoConf.pdf";
                bool fileError = false;
                sfd.InitialDirectory = new DirectoryInfo(Application.StartupPath + "\\HematoxinandEosin\\HematoxinandEosin\\bin\\Debug").FullName;
                if (File.Exists(sfd.FileName))
                {

                    try
                    {
                        File.Delete(sfd.FileName);
                    }
                    catch (IOException ex)
                    {
                        fileError = true;
                        MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                    }
                }
                if (!fileError)
                {
                    try
                    {
                        PdfPTable pdfTable = new PdfPTable(dgv_Detail.Columns.Count);
                        pdfTable.HeaderRows = 1;

                        pdfTable.DefaultCell.Padding = 3;
                        pdfTable.WidthPercentage = 100;
                        pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                        /// PdfPCell cell1 = new PdfPCell(new Phrase("Pathnsitu Biotechnologies"));
                        PdfPCell cell1 = new PdfPCell();

                        Image img1 = Image.GetInstance(IMG1);
                        cell1.AddElement(img1);
                        cell1.HorizontalAlignment = Element.ALIGN_LEFT;
                        //cell1.BackgroundColor = BaseColor.GRAY;
                        cell1.Colspan = 2;

                        pdfTable.AddCell(cell1);

                        StreamReader file = new System.IO.StreamReader(FilePath);


                        string result = file.ReadToEnd();
                        result = result.Replace('$', '\n');

                        cell1 = new PdfPCell(new Phrase(result));


                        cell1.VerticalAlignment = Element.ALIGN_CENTER;
                        cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell1.BackgroundColor = BaseColor.GRAY;
                        cell1.Colspan = 4;
                        pdfTable.AddCell(cell1);
                        cell1 = new PdfPCell(new Phrase("For Date :" + cmbProtocol.Text));
                        cell1.VerticalAlignment = Element.ALIGN_CENTER;
                        cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell1.BackgroundColor = BaseColor.GRAY;
                        cell1.Colspan = 6;
                        pdfTable.AddCell(cell1);
                        cell1 = new PdfPCell(new Phrase("Generated By :" + RequiredVariables.UserName));

                        cell1.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell1.BackgroundColor = BaseColor.GRAY;
                        cell1.Colspan = 3;
                        pdfTable.AddCell(cell1);
                        cell1 = new PdfPCell(new Phrase("Date & Time : " + DateTime.Now.ToString()));
                        cell1.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell1.BackgroundColor = BaseColor.GRAY;
                        cell1.Colspan = 3;
                        pdfTable.AddCell(cell1);
                        foreach (DataGridViewColumn column in dgv_Detail.Columns)
                        {

                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));

                            pdfTable.AddCell(cell);
                        }


                        foreach (DataGridViewRow row in dgv_Detail.Rows)
                        {
                            //PdfPCell cell = new PdfPCell(new Phrase(row.HeaderText));
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                try
                                {
                                    pdfTable.AddCell(cell.Value.ToString());
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error :" + ex.Message);
                                }
                            }
                        }

                        using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                        {
                            Document pdfDoc = new Document(PageSize.A4, 55f, 20f, 30f, 70f);
                            PdfWriter.GetInstance(pdfDoc, stream);
                            pdfDoc.Open();
                            pdfDoc.Add(pdfTable);
                            pdfDoc.Close();
                            stream.Close();
                        }


                        //For prinnting please enable this lines 
                        string FilePath1 = @"G:/projects/mukesh/HematoxinandEosin/HematoxinandEosin/bin/Debug/ProtoConf.pdf";
                        Process p = new Process();
                        p.StartInfo = new ProcessStartInfo()
                        {
                            CreateNoWindow = true,
                            Verb = "print",
                            FileName = FilePath1  //put the correct path here
                        };
                        p.StartInfo.ErrorDialog = true;
                        p.Start();
                        MessageBox.Show("Data Printed Successfully !!!", "Info");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error :" + ex.Message);
                    }

                }
            }
            else
            {
                MessageBox.Show("No Record To Print !!!", "Info");
            }
        }

        private void cmbReagent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbReagent.Text == "Select")
            {
                return;
            }
            else
            {
                loadregdetails(cmbReagent.Text);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
                addflg = true;
                modflg = false;
                delflg = false;
                btnSave.Text = "Save";
                cmbProtocol.Text = "";
                cmbProtocol.Focus();
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnModify.Enabled = false;
                btn_loadDetails.Enabled = true;
                btn_LoadGrid.Enabled = true;
                btnSave.Enabled = true;
                dgv_Detail.Rows.Clear();
                cmbNofJars.Text = "";
                //pnl_Ip1.Enabled = true;
                Jarinx = 0;
            }
            catch (Exception d3)
            {

            }
            finally
            {
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            
            SendKeys.Send("Q");
           // txtProtoShortName.Text = txtProtoShortName.Text + button24.Text.Trim();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            SendKeys.Send("E");
        }

        private void button23_Click(object sender, EventArgs e)
        {
            SendKeys.Send("W");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            SendKeys.Send("R");
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
            panel1.Controls.Add(Childform);
            panel1.Tag = Childform;
            Childform.BringToFront();
            Childform.Show();

            //btn_Refresh.Visible = true;


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

        private void Form_ProtocolConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("Oskeyboard"))
            {
                process.Kill();
            }
        }

        private void button1_Click(object sender, EventArgs e)//btn_loadgrid
        {
          
            if ((string.IsNullOrEmpty(cmbReagent.Text)) || (cmbReagent.Text == "Select"))
            {
                MessageBox.Show("Reagent Name Should not be Select / Empty Please select Valid Reagent Name", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbReagent.SelectedIndex = 0;
                cmbReagent.Focus();
                return;
            }

            if (string.IsNullOrEmpty(cmbJarName.Text))
            {
                MessageBox.Show("Jars Name Should not be Select Please select Valid reagent Name", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbReagent.SelectedIndex = 0;
                cmbReagent.Focus();
                return;
            }

            if ((string.IsNullOrEmpty(cmbNofDips.Text)) || (cmbNofDips.Text == "Select"))
            {
                MessageBox.Show("Number of Dips Should not be Select / Empty Please select Valid Reagent Name", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbNofDips.SelectedIndex = 0;
                cmbNofDips.Focus();
                return;
            }

            if (cmbReagent.Text == "Running TAP Water")
                tot_Jars++;

            int i = 0;
            if (!cmbJarName.Text.Contains("W"))
            {
                for (i = 0; i <= dgv_Detail.Rows.Count - 2; i++)
                {
                
                    if (dgv_Detail.Rows[i].Cells["JarName"].Value.ToString() == cmbJarName.Text)
                    {
                        MessageBox.Show("Already this Jar details Loaded to Protocol with Other Reagent Name....\r\nPlease select another Jar Number and then click Load details to Grid Button", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cmbJarName.SelectedIndex = 0;
                        cmbJarName.Focus();
                        return;
                    }
                }                
            }
            //Add code to load details to grid
            dgv_Detail.Rows.Add();
            dgv_Detail.Rows[dgv_Detail.Rows.Count - 2].Cells["sln"].Value = Slno.ToString();
            dgv_Detail.Rows[dgv_Detail.Rows.Count - 2].Cells["protoName"].Value = cmbProtocol.Text;
            dgv_Detail.Rows[dgv_Detail.Rows.Count - 2].Cells["JarName"].Value = cmbJarName.Text;
            dgv_Detail.Rows[dgv_Detail.Rows.Count - 2].Cells["RegName"].Value = cmbReagent.Text;
            ////if(chk_Washing.Checked==true)
            ////{                
            ////    dgv_protodetails.Rows[dgv_protodetails.Rows.Count - 2].Cells["Washreq"].Value = true;                
            ////}
            ////else if (chk_Washing.Checked == false)
            ////{                
            ////    dgv_protodetails.Rows[dgv_protodetails.Rows.Count - 2].Cells["Washreq"].Value = false;             
            ////}
            ////dgv_protodetails.Rows[dgv_protodetails.Rows.Count - 2].Cells["WashTime"].Value = WashtimeVal.Value.ToString().Substring(14, 5);
            dgv_Detail.Rows[dgv_Detail.Rows.Count - 2].Cells["IncubTime"].Value = dt_incubationtime.Value.ToString().Substring(14, 5);
            dgv_Detail.Rows[dgv_Detail.Rows.Count - 2].Cells["Noofdips"].Value = cmbNofDips.Text;
            Slno++;
            Jarinx++;
            if (chk_WashRequired.Checked == true)
            {
                DateTime d1;
                d1 = System.DateTime.Now.AddSeconds(0);
                d1 = System.DateTime.Now.AddMinutes(0);
                dt_Washtime.Value = d1;
                dgv_Detail.Rows.Add();
                dgv_Detail.Rows[dgv_Detail.Rows.Count - 2].Cells["sln"].Value = Slno.ToString();
                dgv_Detail.Rows[dgv_Detail.Rows.Count - 2].Cells["protoName"].Value = cmbProtocol.Text;
                dgv_Detail.Rows[dgv_Detail.Rows.Count - 2].Cells["JarName"].Value = "Water";
                dgv_Detail.Rows[dgv_Detail.Rows.Count - 2].Cells["RegName"].Value = "Room Temperature";
                dgv_Detail.Rows[dgv_Detail.Rows.Count - 2].Cells["IncubTime"].Value = dt_Washtime.Value.ToString().Substring(14, 5);
                dgv_Detail.Rows[dgv_Detail.Rows.Count - 2].Cells["Noofdips"].Value = "0";
                Slno++;
            }
            else
            {
                //dgv_Detail.Rows.Clear();
                //Slno = 1;
            }

            

            if (Jarinx == tot_Jars)
            {
                btn_LoadGrid.Enabled = false;
                btnSave.Focus();
            }
            else
            {
                cmbReagent.Focus();
                cmbJarName.Text = "";
                cmbReagent.Text = "";
                txtReagentShortName.Text = "";
                cmbNofDips.Text = "";
                chk_WashRequired.Checked = false;
              //  cmbReagent.SelectedIndex = 0;
            }
        }
        private void load_reagents_information()
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
                    cmbReagent.Items.Clear();
                    cmbReagent.Items.Add("Select");

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cmbReagent.Items.Add(dt.Rows[i]["ReagentName"].ToString());
                    }
                    cmbReagent.SelectedIndex = 0;
                }
            }
            catch (Exception d3)
            {

            }
        }

        private void loadregdetails(string regname)
        {
            try
            {
               // Color bkcolor;
                sqlstr = "";
                sqlstr = "Select * from ReagentMaster where ReagentName = '" + regname + "'";
                SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    cmbReagent.Text = dt.Rows[0]["ReagentName"].ToString();
                    txtReagentShortName.Text = dt.Rows[0]["ShortName"].ToString();
                    //bkcolor = Color.FromArgb(Convert.ToInt32(dt.Rows[0]["ColorVal"].ToString()));
                    //txt_Color.BackColor = Color.FromArgb(Convert.ToInt32(dt.Rows[0]["ColorVal"].ToString()));
                }
                da.Dispose();
                dt.Dispose();
                //cbo_JarsNames.Focus();
            }
            catch (Exception dx)
            {
            }
        }
        private void load_Protocols()
        {
            string sqlstr = "";
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            int cnt = 0;
            //Reagents Loading to the combobox
            try
            {
                sqlstr = "select * from ProtocolMaster order by Slno";
                da = new SqlDataAdapter(sqlstr, con);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    cmbProtocol.Items.Clear();
                    cmbProtocol.Items.Add("Select");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cmbProtocol.Items.Add(dt.Rows[i]["ProtocolName"].ToString());
                    }
                    cmbProtocol.SelectedIndex = 0;
                }
            }
            catch (Exception d3)
            {

            }
        }
        //private void loadPositiondetails()
        //{
        //    try
        //    {
        //        string filename = "";
        //        filename = Application.StartupPath + "\\Configuration\\JarsPos.cfg";
        //        string jarposvalstring = string.Empty;
        //        string[] jarposval;
        //        if (File.Exists(filename))
        //        {
        //            using (System.IO.StreamReader file = new System.IO.StreamReader(filename))
        //            {
        //                cbo_JarsNames.Items.Clear();
        //                cbo_JarsNames.Items.Add("Select");
        //                while ((jarposvalstring = file.ReadLine()) != null)
        //                {
        //                    jarposval = jarposvalstring.Split(',');
        //                    cbo_JarsNames.Items.Add(jarposval[0].ToString());
        //                }
        //                cbo_JarsNames.SelectedIndex = 0;
        //            }
        //        }
        //    }
        //    catch (Exception d3)
        //    {
        //        MessageBox.Show(d3.ToString(), "Load position details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //}
    }
}
