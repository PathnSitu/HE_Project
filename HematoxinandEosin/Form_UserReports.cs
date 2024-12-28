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
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Data.SqlClient;


namespace HematoxinandEosin
{
    public partial class Form_UserReports : Form
    {
        string Constr = "Data Source=SYSPSENG006;User ID=sa;Password=sree@pns2013;Initial Catalog=PNSHE;Pooling=false;Max Pool Size=400;workstation id =SYSPSENG006";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        // DataTable table = new DataTable("table");
        SqlDataAdapter sda = new SqlDataAdapter();
        DataTable table = new DataTable("table");
       
        string sqlstr;
        public Form_UserReports()
        {
            InitializeComponent();
        }

        private void btn_Show_Click(object sender, EventArgs e)
        {
            //OpenFileDialog fdlg = new OpenFileDialog();
            //fdlg.Title = "Select file";
            //fdlg.InitialDirectory = @"G:\projects\mukesh\Login";
            //fdlg.FileName = txtFileName.Text;
            //fdlg.Filter = "Excel Sheet(*.csv)|*.csv|All Files(*.*)|*.*";
            //fdlg.FilterIndex = 1;
            //fdlg.RestoreDirectory = true;
            //if (fdlg.ShowDialog() == DialogResult.OK)
            //{
            //    txtFileName.Text = fdlg.FileName;

            //    //Import();
            //    Application.DoEvents();
            //}
            //System.IO.StreamReader file = new System.IO.StreamReader("G:\\projects\\mukesh\\Login\\UsrDetails.txt");
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
            //dg_Users.DataSource = dt;
            sqlstr = "";
            sqlstr = "Select * from UserDetails";
            sda = new SqlDataAdapter(sqlstr, con);
            table = new DataTable();
            sda.Fill(table);
            cmd = new SqlCommand(sqlstr, con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();
            dg_Users.DataSource = table;
        }
        private void retrieveData()
        {
            sqlstr = "";
            sqlstr = "Select UserName,Status,Loggedon,LoggedTime from UserDetails order by slno";
            sda = new SqlDataAdapter(sqlstr, con);
            table = new DataTable();
            sda.Fill(table);
            cmd = new SqlCommand(sqlstr, con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();
            dg_Users.DataSource = table;
        }

        private void ldg()
        {
            System.IO.StreamReader file = new System.IO.StreamReader("G:\\projects\\mukesh\\Login\\UsrDetails.txt");
            string[] columnnames = file.ReadLine().Split(',');
            DataTable dt = new DataTable();
            foreach (string c in columnnames)
            {
                dt.Columns.Add(c);
            }
            string newline;
            while ((newline = file.ReadLine()) != null)
            {
                DataRow dr = dt.NewRow();
                string[] values = newline.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    dr[i] = values[i];
                }
                dt.Rows.Add(dr);
            }
            file.Close();
            dg_Users.DataSource = dt;
        }

        private void Form_UserReports_Load(object sender, EventArgs e)
        {
            //  ldg();
            con.ConnectionString = Constr;
            if (con.State == ConnectionState.Closed)
                con.Open();
            retrieveData();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            RequiredVariables.btnReports = true;
        }

        private void btn_ExportPdf_Click(object sender, EventArgs e)
        {
          
            if (dg_Users.Rows.Count > 0)
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
                            PdfPTable pdfTable = new PdfPTable(dg_Users.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dg_Users.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                               
                                pdfTable.AddCell(cell);
                            }

                            //foreach (DataGridViewRow row in dg_Users.Rows)
                            //{
                            //    foreach (DataGridViewCell cell in row.Cells)
                            //    {
                            //        pdfTable.AddCell(cell.Value.ToString());
                            //    }
                            //}
                            foreach (DataGridViewRow row in dg_Users.Rows)
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
                else
                {
                    MessageBox.Show("No Record To Export !!!", "Info");
                }
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
    }
}
