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

namespace HematoxinandEosin
{
    public partial class Form_ProtoConf : Form
    {
        string Constr = "Data Source=SYSPSENG006;User ID=sa;Password=sree@pns2013;Initial Catalog=PNSHE;Pooling=false;Max Pool Size=400;workstation id =SYSPSENG006";
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

        public Form_ProtoConf()
        {
            InitializeComponent();
        }

        private void Form_ProtoConf_Load(object sender, EventArgs e)
        {
            Constr = "";
            Constr = RequiredVariables.DBConnStr;
            con.ConnectionString = Constr;
            if (con.State == ConnectionState.Closed)
                con.Open();
            retreiveProto();
        }
        public void retreiveProto()
        {
            txtProtocol.Text = RequiredVariables.protoName;
            string d2 = "";
            try
            { 
                sqlstr = "";
                sqlstr = "Select * from ProtocolMaster where ProtocolName = '" + RequiredVariables.protoName + "'";
                sda = new SqlDataAdapter(sqlstr, con);
                table = new DataTable();
                sda.Fill(table);
                // chkHeat.Visible = true;
                //chk.Visible = true;

                //panel_reagent.Visible = true;
                if (table.Rows.Count > 0)
                {
                    if (table.Rows[0]["ProtocolType"].ToString() == "FP")
                    {
                        tabName = "FactoryProtocolDetails";
                        txt_ProtoType.Text = "Factory";
                        //rdnFactory.Checked = true;
                    }
                    else if (table.Rows[0]["ProtocolType"].ToString() == "UP")
                    {
                        tabName = "ProtocolDetails";
                        txt_ProtoType.Text = "User";
                    }

                    txtProtoShortName.Text = table.Rows[0]["ShortName"].ToString();
                    if (Convert.ToBoolean(table.Rows[0]["Agitation"].ToString()) == true)
                        // chkAgitation.Checked = true;
                        //   t
                        txt_Agitation.Text = "Required";
                    else if (Convert.ToBoolean(table.Rows[0]["Agitation"].ToString()) == false)
                        //chkAgitation.Checked = false;
                        txt_Agitation.Text = "Not Required";
                    txt_describe.Text = table.Rows[0]["Description"].ToString();
                    d2 = table.Rows[0]["CreatedOn"].ToString() + " 00:00:00";
                  //  genDate.Value = Convert.ToDateTime(d2);
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

                //Loading details to Grid
                sqlstr = "";
                sqlstr = "Select * from " + tabName + " where ProtocolName = '" + RequiredVariables.protoName + "' order by Slno";
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


                               // chkHeat.Checked = true;

                                //cmbTempature.Text = table.Rows[i]["Temp_Reagent"].ToString();
                                string[] st = table.Rows[i]["IncubationTime"].ToString().Split(':');
                                //WashIncubatio.Value = DateTime.Now.AddMinutes(Convert.ToInt32(st[0]));
                                //WashIncubatio.Value = DateTime.Now.AddSeconds(Convert.ToInt32(st[1]));                               
                                d2 = "01-01-2000 00:" + st[0] + ":" + st[1];
                                DateTime d1 = Convert.ToDateTime(d2);
                                //dt_Heatingtime.Value = d1;
                            }
                            else
                            {
                                //chkHeat.Checked = false;
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
                        dgv_Detail.Rows[i].Cells["protoName"].Value = RequiredVariables.protoName;
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
                    //comboBox1.SelectedIndex = Jarinx;
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

        private void txtProtocol_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtProtoShortName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txt_ProtoType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txt_Agitation_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txt_describe_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void pB_signout_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                            //PdfPTable pdfTable = new PdfPTable(dgv_Detail.Columns.Count);

                            //pdfTable.DefaultCell.Padding = 3;
                            //pdfTable.WidthPercentage = 100;
                            //pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            PdfPTable pdfTable = new PdfPTable(6);
                            pdfTable.HorizontalAlignment = 0;
                            pdfTable.TotalWidth = 500f;
                            pdfTable.LockedWidth = true;
                            float[] widths = new float[] { 25f, 80f, 40f, 70f, 60f, 80f };
                            pdfTable.SetWidths(widths);
                            pdfTable.HeaderRows = 4;
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
                            cell1 = new PdfPCell(new Phrase(txtProtocol.Text, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));

                            cell1.VerticalAlignment = Element.ALIGN_CENTER;
                            cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell1.BackgroundColor = BaseColor.GRAY;
                            cell1.Colspan = 6;
                            pdfTable.AddCell(cell1);
                            cell1 = new PdfPCell(new Phrase("Generated By :" + RequiredVariables.UserName, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));

                            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell1.BackgroundColor = BaseColor.GRAY;
                            cell1.Colspan = 3;
                            pdfTable.AddCell(cell1);
                            cell1 = new PdfPCell(new Phrase("Date & Time : " + DateTime.Now.ToString(), FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell1.BackgroundColor = BaseColor.GRAY;
                            cell1.Colspan = 3;
                            pdfTable.AddCell(cell1);
                            foreach (DataGridViewColumn column in dgv_Detail.Columns)
                            {

                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));

                                pdfTable.AddCell(cell);
                            }


                            foreach (DataGridViewRow row in dgv_Detail.Rows)
                            {
                                //PdfPCell cell = new PdfPCell(new Phrase(row.HeaderText));
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    try
                                    {
                                        cell1 = new PdfPCell(new Phrase(cell.Value.ToString(), FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                                        pdfTable.AddCell(cell1);
                                    }
                                    catch (Exception ex)
                                        {
                                            MessageBox.Show("Error :" + ex.Message);
                                        }
                                    }
                                }

                                using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                                {
                                    Document pdfDoc = new Document(PageSize.A4, 55f, 20f, 20f, 10f);
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
                            //PdfPTable pdfTable = new PdfPTable(dgv_Detail.Columns.Count);
                            //pdfTable.HeaderRows = 1;

                            //pdfTable.DefaultCell.Padding = 3;
                            //pdfTable.WidthPercentage = 100;
                            //pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            PdfPTable pdfTable = new PdfPTable(6);
                            pdfTable.HorizontalAlignment = 0;
                            pdfTable.TotalWidth = 500f;
                            pdfTable.LockedWidth = true;
                            float[] widths = new float[] { 25f, 80f, 40f, 70f, 60f, 80f };
                            pdfTable.SetWidths(widths);
                            pdfTable.HeaderRows = 4;
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
                            cell1 = new PdfPCell(new Phrase(txtProtocol.Text, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));

                            cell1.VerticalAlignment = Element.ALIGN_CENTER;
                            cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell1.BackgroundColor = BaseColor.GRAY;
                            cell1.Colspan = 6;
                            pdfTable.AddCell(cell1);
                            cell1 = new PdfPCell(new Phrase("Generated By :" + RequiredVariables.UserName, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));

                            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell1.BackgroundColor = BaseColor.GRAY;
                            cell1.Colspan = 3;
                            pdfTable.AddCell(cell1);
                            cell1 = new PdfPCell(new Phrase("Date & Time : " + DateTime.Now.ToString(), FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell1.BackgroundColor = BaseColor.GRAY;
                            cell1.Colspan = 3;
                            pdfTable.AddCell(cell1);
                            foreach (DataGridViewColumn column in dgv_Detail.Columns)
                            {

                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));

                                pdfTable.AddCell(cell);
                            }


                            foreach (DataGridViewRow row in dgv_Detail.Rows)
                            {
                                //PdfPCell cell = new PdfPCell(new Phrase(row.HeaderText));
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    try
                                    {
                                        cell1 = new PdfPCell(new Phrase(cell.Value.ToString(), FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                                        pdfTable.AddCell(cell1);
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


                            //For printing please enable this lines 
                            string FilePath1 = @"G:/projects/mukesh/HematoxinandEosin/HematoxinandEosin/bin/Debug/ProtoConf.pdf";
                            AddPageNumber(FilePath1);
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
        }
        protected void AddPageNumber(string filename)
        {
            string pdffilename = null, mainpdf = null;
            pdffilename = filename;
            mainpdf = filename;
            //byte[] bytes = File.ReadAllBytes(@"D:\PDFs\Test.pdf");
            byte[] bytes = File.ReadAllBytes(pdffilename);

            string WatermarkLocation = IMG1;
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(WatermarkLocation);
            img.SetAbsolutePosition(100, 100);

            //image.setAbsolutePosition(rect.Left, rect.Top - image.ScaledHeight);
            //PdfDocument doc;

            iTextSharp.text.Font blackFont = FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            using (MemoryStream stream = new MemoryStream())
            {
                PdfReader reader = new PdfReader(bytes);

                using (PdfStamper stamper = new PdfStamper(reader, stream))
                {
                    int pages = reader.NumberOfPages;
                    string pgcount = null, filename_pdf = null;

                    PdfLayer layer = new PdfLayer("WatermarkLayer", stamper.Writer);

                    filename_pdf = "File Name: " + mainpdf;
                    string s1 = null, s3 = null;
                    for (int i = 1; i <= pages; i++)
                    {
                        pgcount = null;
                        pgcount = "Page " + i.ToString() + " of " + pages;

                        float ph = reader.GetPageSize(i).Height;
                        float pw = reader.GetPageSize(i).Width;

                        s1 = "";
                        s1 = s1 + "Designed & Developed By Pathnsitu Biotechnologies";
                        // ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_LEFT, new Phrase(s1, blackFont), 50f, 5f, 0);
                        //s1 = "";
                        //s1 = s1 + "Date:";
                        //ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_LEFT, new Phrase(s1, blackFont), 250f, 15f, 0);


                        //s1 = "";
                        //s1 = s1 + "Date:";
                        //ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_LEFT, new Phrase(s1, blackFont), 725f, 15f, 0);
                        //ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT,new Phrase(pgcount, blackFont), 568f, 15f, 0);
                        //ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_LEFT, new Phrase(s1, blackFont), 50f, 60f, 0);
                        //ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase(s3, blackFont), 650f, 60f, 0);

                        //if (s1.Contains("&"))
                        //{
                        //    s1 = s1.Replace("&", "&&");
                        //}
                        //ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_CENTER, new Phrase(s1, blackFont), 400f, 580f, 0);
                        ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_RIGHT, new Phrase(pgcount, blackFont), 550f, 5f, 0);

                        //Water Mark On PDF Files
                        PdfContentByte cb = stamper.GetUnderContent(i);

                        cb.BeginLayer(layer);
                        //cb.SetFontAndSize(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 85);                        
                        cb.SetFontAndSize(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 85);
                        PdfGState gState = new PdfGState();
                        gState.FillOpacity = 0.25f;
                        //gState.FillOpacity = 0.40f;
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.SetGState(gState);

                        cb.BeginText();
                        //cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, " Pathnsitu ", ph / 2, pw / 2, 45f);
                        cb.EndText();
                        //"Close" the layer
                        cb.EndLayer();
                        //Water Mark On Pdf Files  
                    }
                }
                bytes = stream.ToArray();
            }
            //File.WriteAllBytes(@"D:\PDFs\Test_1.pdf", bytes);
            File.WriteAllBytes(mainpdf, bytes);

            //if (File.Exists(pdffilename))
            //{
            //    File.Delete(pdffilename);
            //}
        }
    }
}
