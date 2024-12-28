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
    public partial class Form_ProtocolMaster : Form
    {
        string Constr = "";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
       
        SqlDataAdapter sda = new SqlDataAdapter();
        DataTable table = new DataTable("table");
        string sqlstr;
        string IMG1 = "Images/logos.png";
        //string FilePath = Path.Combine(@"G:\projects\mukesh\HematoxinandEosin\HematoxinandEosin\bin\Debug\Lab.txt");
        string FilePath = Path.Combine(Application.StartupPath+"\\Lab.txt");
        public Form_ProtocolMaster()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           

        }

        private void lbl_time_Click(object sender, EventArgs e)
        {

        }

        private void btn_Calibration_Click(object sender, EventArgs e)
        {
           

        }

        private void btn_Configuration_Click(object sender, EventArgs e)
        {
          

        }

        private void btn_RunProtocol_Click(object sender, EventArgs e)
        {
          


        }

        private void btn_Reports_Click(object sender, EventArgs e)
        {

        }
        public void retreiveProto()
        {
            sqlstr = "Select ProtocolName,ProtocolType,Description,CreatedOn,CreatedBy from ProtocolMaster";
            sda = new SqlDataAdapter(sqlstr, con);
            table = new DataTable();
            sda.Fill(table);
            cmd = new SqlCommand(sqlstr, con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();
            if (dg_proto.Rows.Count > 0) dg_proto.Rows.Clear();
           
        
            for (int i = 0; i < table.Rows.Count; i++)
            {
                dg_proto.Rows.Add();
                int j = 1;
                foreach (DataGridViewRow row in dg_proto.Rows)
                {
                    dg_proto.Rows[dg_proto.Rows.Count -1].Cells["sln"].Value = j; j++;
                }
                dg_proto.Rows[dg_proto.Rows.Count - 1].Cells["protoName"].Value = table.Rows[i]["ProtocolName"].ToString();
                dg_proto.Rows[dg_proto.Rows.Count - 1].Cells["protoType"].Value = table.Rows[i]["ProtocolType"].ToString(); 
                dg_proto.Rows[dg_proto.Rows.Count - 1].Cells["describe"].Value = table.Rows[i]["Description"].ToString();
                dg_proto.Rows[dg_proto.Rows.Count - 1].Cells["createdOn"].Value = table.Rows[i]["CreatedOn"].ToString();
                dg_proto.Rows[dg_proto.Rows.Count - 1].Cells["createdBy"].Value = table.Rows[i]["CreatedBy"].ToString();
            }
        }
        private void Form_ProtocolMaster_Load(object sender, EventArgs e)
        {
            Constr = "";
            Constr = RequiredVariables.DBConnStr;
            con.ConnectionString = Constr;
            if (con.State == ConnectionState.Closed)
                con.Open();
            retreiveProto();
        }

        private void btn_ExportPdf_Click(object sender, EventArgs e)
        {
            if (dg_proto.Rows.Count > 0)
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
                            PdfPTable pdfTable = new PdfPTable(6);
                            pdfTable.HorizontalAlignment = 0;
                            pdfTable.TotalWidth = 500f;
                            pdfTable.LockedWidth = true;
                            float[] widths = new float[] { 25f, 80f, 35f, 90f, 50f, 80f };
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

                            cell1 = new PdfPCell(new Phrase("Protocol List", FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));

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

                            foreach (DataGridViewColumn column in dg_proto.Columns)
                            {

                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                                //column.Width =cell.


                                pdfTable.AddCell(cell);
                            }


                            foreach (DataGridViewRow row in dg_proto.Rows)
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
                
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }

        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            if (dg_proto.Rows.Count > 0)
            {
                PrintDocument Pd = new PrintDocument();
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Protocols.pdf";
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
                        //PdfPTable pdfTable = new PdfPTable(dg_proto.Columns.Count);
                        //pdfTable.HeaderRows = 1;

                        //pdfTable.DefaultCell.Padding = 3;
                        //pdfTable.WidthPercentage = 100;
                        //pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                        PdfPTable pdfTable = new PdfPTable(6);
                        pdfTable.HorizontalAlignment = 0;
                        pdfTable.TotalWidth = 500f;
                        pdfTable.LockedWidth = true;
                        float[] widths = new float[] { 25f, 80f, 35f, 90f, 50f, 80f };
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
                       
                        cell1 = new PdfPCell(new Phrase("Protocol List", FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                        
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
                        
                        foreach (DataGridViewColumn column in dg_proto.Columns)
                        {
                           
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                            //column.Width =cell.


                            pdfTable.AddCell(cell);
                        }


                        foreach (DataGridViewRow row in dg_proto.Rows)
                        {
                            //PdfPCell cell = new PdfPCell(new Phrase(row.HeaderText));
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                try
                                {
                                    cell1= new PdfPCell(new Phrase(cell.Value.ToString(), FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
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
                        string FilePath1 = @"G:/projects/mukesh/HematoxinandEosin/HematoxinandEosin/bin/Debug/Protocols.pdf";
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
        private void dg_proto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dg_proto.Rows[rowIndex];
            RequiredVariables.protoName = dg_proto.Rows[rowIndex].Cells[1].Value.ToString();
            Form_ProtoConf f1 = new Form_ProtoConf();
            f1.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
