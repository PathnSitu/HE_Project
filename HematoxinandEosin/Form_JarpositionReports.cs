using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Data.SqlClient;
using System.Diagnostics;
using Image = iTextSharp.text.Image;

namespace HematoxinandEosin
{
    public partial class Form_JarpositionReports : Form
    {
        string Constr = "";//"Data Source=SYSPSENG006;User ID=sa;Password=sree@pns2013;Initial Catalog=PNSHE;Pooling=false;Max Pool Size=400;workstation id =SYSPSENG006";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        // DataTable table = new DataTable("table");
        SqlDataAdapter sda = new SqlDataAdapter();
        DataTable table = new DataTable("table");
        string sqlstr;
        string IMG1 = "Images/logos.png";
        //string FilePath = Path.Combine(@"G:\projects\mukesh\HematoxinandEosin\HematoxinandEosin\bin\Debug\Lab.txt");
        string FilePath = Application.StartupPath + "\\Lab.txt";

        public Form_JarpositionReports()
        {
            InitializeComponent();
        }

        
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            RequiredVariables.btnReports = true;
        }

        private void Form_JarpositionReports_Load(object sender, EventArgs e)
        {
            //ofd1();
            Constr = RequiredVariables.DBConnStr;
            con.ConnectionString = Constr;
            if (con.State == ConnectionState.Closed)
            con.Open();
            //jarretrieveDate();
        }

        private void jarretrieveDate()
        {
            sqlstr = "";
            sqlstr = "Select DISTINCT Calibratedon from JarpositionCalibration";

            //sda = new SqlDataAdapter(sqlstr, con);
            //list = new List();
            //sda.Fill(list);
            cmd = new SqlCommand(sqlstr, con);
            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            listBox_jp.Items.Clear();
            while (reader.Read())
            {
                listBox_jp.Items.Add(reader["Calibratedon"].ToString());
            }

            con.Close();
            //cmd.ExecuteNonQuery();
        }
        private void btn_ExportPdf_Click(object sender, EventArgs e)
        {

            

                if (dg_JarPosition.Rows.Count > 0)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "PDF (*.pdf)|*.pdf";
                    sfd.FileName = "Output.pdf";
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
                                PdfPTable pdfTable = new PdfPTable(dg_JarPosition.Columns.Count);
                                pdfTable.DefaultCell.Padding = 3;
                                pdfTable.WidthPercentage = 100;
                                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            pdfTable.HeaderRows = 4;
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
                            cell1.Colspan = 5;
                            pdfTable.AddCell(cell1);
                            cell1 = new PdfPCell(new Phrase("For Date :" + listBox_jp.SelectedItem.ToString(), FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                            cell1.VerticalAlignment = Element.ALIGN_CENTER;
                            cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell1.BackgroundColor = BaseColor.GRAY;
                            cell1.Colspan = 7;
                            pdfTable.AddCell(cell1);
                            cell1 = new PdfPCell(new Phrase("Generated By :" + RequiredVariables.UserName, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));

                            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell1.BackgroundColor = BaseColor.GRAY;
                            cell1.Colspan = 3;
                            pdfTable.AddCell(cell1);
                            cell1 = new PdfPCell(new Phrase("Date & Time : " + DateTime.Now.ToString(), FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell1.BackgroundColor = BaseColor.GRAY;
                            cell1.Colspan = 4;
                            pdfTable.AddCell(cell1);
                            foreach (DataGridViewColumn column in dg_JarPosition.Columns)
                                {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));

                               

                                pdfTable.AddCell(cell);
                                }

                                //foreach (DataGridViewRow row in dg_Users.Rows)
                                //{
                                //    foreach (DataGridViewCell cell in row.Cells)
                                //    {
                                //        pdfTable.AddCell(cell.Value.ToString());
                                //    }
                                //}
                                foreach (DataGridViewRow row in dg_JarPosition.Rows)
                                {
                                    // PdfPCell cell = new PdfPCell(new Phrase(row.HeaderText));
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
                

                //PdfPTable pdfTable = new PdfPTable(dg_Users.ColumnCount);
                //pdfTable.DefaultCell.Padding = 3;
                //pdfTable.WidthPercentage = 30;
                //pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                //pdfTable.DefaultCell.BorderWidth = 1;

                ////Adding Header row
                //foreach (DataGridViewColumn column in dg_Users.Columns)
                //{
                //    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                //    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                //    pdfTable.AddCell(cell);
                //}

                ////Adding DataRow
                //foreach (DataGridViewRow row in dg_Users.Rows)
                //{
                //    foreach (DataGridViewCell cell in row.Cells)
                //    {
                //        try
                //        {
                //            pdfTable.AddCell(cell.Value.ToString());
                //        }
                //        catch { }
                //    }
                //}

                ////Exporting to PDF
                //string folderPath = "C:\\PDFs\\";
                //if (!Directory.Exists(folderPath))
                //{
                //    Directory.CreateDirectory(folderPath);
                //}
                //using (FileStream stream = new FileStream(folderPath + "DataGridViewExport.pdf", FileMode.Create))
                //{
                //    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                //    PdfWriter.GetInstance(pdfDoc, stream);
                //    pdfDoc.Open();
                //    pdfDoc.Add(pdfTable);
                //    pdfDoc.Close();
                //    stream.Close();
                //}



                //public static string[] GetTableExcel(string strFileName)
                //{
                //    string[] strTables = new string[100];
                //    Catalog oCatlog = new Catalog();
                //    ADOX.Table oTable = new ADOX.Table();
                //    ADODB.Connection oConn = new ADODB.Connection();
                //    oConn.Open("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + strFileName + "; Extended Properties = \"Excel 8.0;HDR=Yes;IMEX=1\";", "", "", 0);
                //    oCatlog.ActiveConnection = oConn;
                //    if (oCatlog.Tables.Count > 0)
                //    {
                //        int item = 0;
                //        foreach (ADOX.Table tab in oCatlog.Tables)
                //        {
                //            if (tab.Type == "TABLE")
                //            {
                //                strTables[item] = tab.Name;
                //                item++;
                //            }
                //        }
                //    }
                //    return strTables;
                //}
                //public static DataTable GetDataTableExcel(string strFileName, string Table)
                //{
                //    System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + strFileName + "; Extended Properties = \"Excel 8.0;HDR=Yes;IMEX=1\";");
                //    conn.Open();
                //    string strQuery = "SELECT * FROM [" + Table + "]";
                //    System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter(strQuery, conn);
                //    System.Data.DataSet ds = new System.Data.DataSet();
                //    adapter.Fill(ds);
                //    return ds.Tables[0];
                //}
            }
        
        private void ofd1()
        {
            listBox_jp.Items.Clear();

            DirectoryInfo di = new DirectoryInfo(@"G:\projects\mukesh\CalibLog\Jp\");

            FileInfo[] files = di.GetFiles("*.csv");



            foreach (FileInfo file in files)
            {

                string Pth = file.Name;
                Pth = Pth.Replace(".csv", "");
                listBox_jp.Items.Add(Pth);


            }



        }
        

        private void listBox_jp_SelectedIndexChanged(object sender, EventArgs e)
        {
            String s1 = listBox_jp.SelectedItem.ToString();
            sqlstr = "";
            sqlstr = "Select RoboticArm,JarParameterName,Xaxis,Yaxis,Zaxis,Calibratedby,CalibratedTime from JarpositionCalibration Where Calibratedon= '" + s1 + "'";
            sda = new SqlDataAdapter(sqlstr, con);
            table = new DataTable();
            sda.Fill(table);
            cmd = new SqlCommand(sqlstr, con);
            if (con.State == ConnectionState.Closed)
            con.Open();
            cmd.ExecuteNonQuery();
            //dg_JarPosition.DataSource = table;
            if (dg_JarPosition.Rows.Count > 0) dg_JarPosition.Rows.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                //if (table.Rows[i]["Status"].ToString() == "sign in")
                //{

                    dg_JarPosition.Rows.Add();
                    //dg_UserIndetailed.Rows.Add();
                   dg_JarPosition.Rows[dg_JarPosition.Rows.Count - 1].Cells["roboticArm"].Value = table.Rows[i]["RoboticArm"].ToString();
                dg_JarPosition.Rows[dg_JarPosition.Rows.Count - 1].Cells["jarName"].Value = table.Rows[i]["JarParameterName"].ToString(); ;
                dg_JarPosition.Rows[dg_JarPosition.Rows.Count - 1].Cells["xaxis"].Value = table.Rows[i]["Xaxis"].ToString();
                dg_JarPosition.Rows[dg_JarPosition.Rows.Count - 1].Cells["yaxis"].Value = table.Rows[i]["Yaxis"].ToString();
                dg_JarPosition.Rows[dg_JarPosition.Rows.Count - 1].Cells["zaxis"].Value = table.Rows[i]["Zaxis"].ToString(); ;
                dg_JarPosition.Rows[dg_JarPosition.Rows.Count - 1].Cells["calibratedby"].Value = table.Rows[i]["Calibratedby"].ToString();
                //dg_JarPosition.Rows[dg_JarPosition.Rows.Count - 1].Cells["calibratedon"].Value = table.Rows[i]["Calibratedon"].ToString();
               // dg_JarPosition.Rows[dg_JarPosition.Rows.Count - 1].Cells["inStatuss"].Value = table.Rows[i]["Status"].ToString(); ;
                dg_JarPosition.Rows[dg_JarPosition.Rows.Count - 1].Cells["calibratedTime"].Value = table.Rows[i]["CalibratedTime"].ToString();
                //dg_UserIndetailed.Rows[dg_UserIndetailed.Rows.Count - 1].Cells["inTime"].Value = intime;
            }

                    //txtList.Text = listBox_jp.SelectedItem.ToString();
                    //string FilePath = Path.Combine(@"G:\projects\mukesh\CalibLog\Jp\" + txtList.Text + ".csv");
                    //System.IO.StreamReader file = new System.IO.StreamReader(FilePath);

                    //string[] columnnames = file.ReadLine().Split(',');
                    //DataTable dt = new DataTable();
                    //foreach (string c in columnnames)
                    //{
                    //    dt.Columns.Add(c);
                    //}
                    //string newline;
                    //while ((newline = file.ReadLine()) != null)
                    //{
                    //    DataRow dr = dt.NewRow();
                    //    string[] values = newline.Split(',');
                    //    for (int i = 0; i < values.Length; i++)
                    //    {
                    //        dr[i] = values[i];
                    //    }
                    //    dt.Rows.Add(dr);
                    //}
                    //file.Close();
                    //dg_JarPosition.DataSource = dt;
                }

                private void btn_Show_Click(object sender, EventArgs e)
        {
            string s2 = "";
            s2 = cmb_Month.SelectedItem.ToString();
            listBox_jp.Items.Clear();

            if (dg_JarPosition.Rows.Count > 0)
                dg_JarPosition.Rows.Clear();

            sqlstr = "";
            sqlstr = "Select DISTINCT Calibratedon from JarpositionCalibration Where Month= '" + s2 + "'";

            DataTable t1 = new DataTable();
            sda = new SqlDataAdapter(sqlstr, con);
            sda.Fill(t1);

            if (t1.Rows.Count > 0)
            {
                sda.Dispose();
                for (int j = 0; j < t1.Rows.Count; j++)
                {
                    listBox_jp.Items.Add(t1.Rows[j]["Calibratedon"].ToString());
                }
            }
            else
            {
                MessageBox.Show("No Data was recorded for the Selected month", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmb_Month.Focus();
            }
            con.Close();
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            if (dg_JarPosition.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "JarCalib.pdf";
                bool fileError = false;
                sfd.InitialDirectory = new DirectoryInfo(Application.StartupPath + "\\HematoxinandEosin\\HematoxinandEosin\\bin\\Debug").FullName;
                //if (sfd.ShowDialog() == DialogResult.OK)
                //{
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
                        PdfPTable pdfTable = new PdfPTable(dg_JarPosition.Columns.Count);
                        pdfTable.DefaultCell.Padding = 3;
                        pdfTable.WidthPercentage = 100;
                        pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                        pdfTable.HeaderRows = 4;
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
                        cell1.Colspan = 5;
                        pdfTable.AddCell(cell1);
                        cell1 = new PdfPCell(new Phrase("For Date :" + listBox_jp.SelectedItem.ToString(), FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                        cell1.VerticalAlignment = Element.ALIGN_CENTER;
                        cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell1.BackgroundColor = BaseColor.GRAY;
                        cell1.Colspan = 7;
                        pdfTable.AddCell(cell1);
                        cell1 = new PdfPCell(new Phrase("Generated By :" + RequiredVariables.UserName, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));

                        cell1.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell1.BackgroundColor = BaseColor.GRAY;
                        cell1.Colspan = 3;
                        pdfTable.AddCell(cell1);
                        cell1 = new PdfPCell(new Phrase("Date & Time : " + DateTime.Now.ToString(), FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                        cell1.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell1.BackgroundColor = BaseColor.GRAY;
                        cell1.Colspan = 4;
                        pdfTable.AddCell(cell1);

                        foreach (DataGridViewColumn column in dg_JarPosition.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));

                            pdfTable.AddCell(cell);
                        }


                        foreach (DataGridViewRow row in dg_JarPosition.Rows)
                        {
                            // PdfPCell cell = new PdfPCell(new Phrase(row.HeaderText));
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                try
                                {
                                    cell1=new PdfPCell(new Phrase(cell.Value.ToString(), FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
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
                        string FilePath1 = @"G:/projects/mukesh/HematoxinandEosin/HematoxinandEosin/bin/Debug/JarCalib.pdf";
                        AddPageNumber(FilePath1);
                        //Process p = new Process();
                        //p.StartInfo = new ProcessStartInfo()
                        //{
                        //    CreateNoWindow = true,
                        //    Verb = "print",
                        //    FileName = FilePath1  //put the correct path here
                        //};
                        //p.StartInfo.ErrorDialog = true;
                        //p.Start();
                        MessageBox.Show("Data Printed Successfully !!!", "Info");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error :" + ex.Message);
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
        //private void btn_
        //}
    }
}
