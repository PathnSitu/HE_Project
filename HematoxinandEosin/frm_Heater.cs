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
using System.Data.SqlClient;

namespace HematoxinandEosin
{
    
    public partial class frm_Heater : Form
    {
        //string FilePath = Path.Combine(@"G:\projects\mukesh\CalibLog\Eng", DateTime.Today.ToString("dd/MM/yyyy") + ".csv");
        // string data = File.ReadAllText(FilePath);
        // string withHeader = "Parametername, Status, Time," ;
        string Constr = "Data Source=SYSPSENG006;User ID=sa;Password=sree@pns2013;Initial Catalog=PNSHE;Pooling=false;Max Pool Size=400;workstation id =SYSPSENG006";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        // DataTable table = new DataTable("table");
        SqlDataAdapter sda = new SqlDataAdapter();
        string status;
        string sqlstr;
        public frm_Heater()
        {
            InitializeComponent();
        }


        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
            RequiredVariables.btnCalib = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tg_Heater_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tg_HeaterFan_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void btn_Set_Click(object sender, EventArgs e)
        {
            string st = "S-Tem";
            sqlstr = "";
            sqlstr = "Insert into EngineeringMode(EngModeParameterName,CalibratedBy,TestedOn,Status,ChangedTime) values('";
            sqlstr = sqlstr + st + "','" + RequiredVariables.UserName + "','";
            //String s = DateTime.Now.ToString("dd-MM-yyyy");
            string s2 = DateTime.Now.ToString("dd-MM-yyyy");
            sqlstr = sqlstr +s2 + "','";
            // sqlstr= sqlstr + "'" + s + "','";
            // status = "";

            sqlstr = sqlstr+cmb_setTemperature.Text + "',";

           // sqlstr = sqlstr + "ON',";

            String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
            sqlstr = sqlstr + "'" + s1 + "')";
            cmd = new SqlCommand(sqlstr, con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();

            //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
            //byte[] bdata = Encoding.Default.GetBytes("\n  S-Tem,"+cmb_setTemperature.Text+ "," + s1);
            //fileStream.Write(bdata, 0, bdata.Length);
            //fileStream.Close();
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            string r = "R-Tem";
            sqlstr = "";
            sqlstr = "Insert into EngineeringMode(EngModeParameterName,CalibratedBy,TestedOn,Status,ChangedTime) values('";
            sqlstr = sqlstr + r + "','" + RequiredVariables.UserName + "','";
            String s = DateTime.Now.ToString("dd-MM-yyyy");
            sqlstr = sqlstr + s + "','";
            // sqlstr= sqlstr + "'" + s + "','";
            // status = "";

            sqlstr = sqlstr + txt_readTemperature.Text + "',";

            // sqlstr = sqlstr + "ON',";

            String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
            sqlstr = sqlstr + "'" + s1 + "')";
            cmd = new SqlCommand(sqlstr, con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();
           // txt_readTemperature.Clear();
            //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
            //byte[] bdata = Encoding.Default.GetBytes("\n  R-Tem," + txt_readTemperature.Text + "," + s1);
            //fileStream.Write(bdata, 0, bdata.Length);
            //fileStream.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void tg_Heater_Click(object sender, EventArgs e)
        {
            string h = "Heater";
            sqlstr = "";
            sqlstr = "Insert into EngineeringMode(EngModeParameterName,CalibratedBy,TestedOn,Status,ChangedTime) values('";
            sqlstr = sqlstr + h + "','" + RequiredVariables.UserName + "','";
            String s = DateTime.Now.ToString("dd-MM-yyyy");
            sqlstr = sqlstr +s + "','";
            // sqlstr= sqlstr + "'" + s + "','";
            // status = "";
            if (tg_Heater.Checked == true)
            {
                tg_Heater.CapText = "OFF";
                tg_Heater.Checked = false;
                sqlstr = sqlstr + "OFF',";
                //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                //byte[] bdata = Encoding.Default.GetBytes("\n  Heater,OFF," + s1);
                //fileStream.Write(bdata, 0, bdata.Length);
                //fileStream.Close();
            }


            else
            {
                tg_Heater.CapText = "ON";
                tg_Heater.Checked = true;
                sqlstr = sqlstr + "ON',";
                //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                //byte[] bdata = Encoding.Default.GetBytes("\n  Heater,ON," + s1);
                //fileStream.Write(bdata, 0, bdata.Length);
                //fileStream.Close();
            }
            String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
            sqlstr = sqlstr + "'" + s1 + "')";
            cmd = new SqlCommand(sqlstr, con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();
            
           
              
            
        }

        private void tg_HeaterFan_Click(object sender, EventArgs e)
        {
            string s = "Heater Fan";
            sqlstr = "";
            sqlstr = "Insert into EngineeringMode(EngModeParameterName,CalibratedBy,TestedOn,Status,ChangedTime) values('";
            sqlstr = sqlstr + s + "','" + RequiredVariables.UserName + "','";
            //String s = DateTime.Now.ToString("dd-MM-yyyy");
            string s2 = DateTime.Now.ToString("dd-MM-yyyy");
            sqlstr = sqlstr + s2 + "','";
          // sqlstr= sqlstr + "'" + s + "','";
           // status = "";

            if (tg_HeaterFan.Checked == true)
            {
                tg_HeaterFan.CapText = "OFF";
                tg_HeaterFan.Checked = false;
                sqlstr=sqlstr+ "OFF',";
                //status = "OFF";
                //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                //byte[] bdata = Encoding.Default.GetBytes("\n  Heaterfan,OFF," + s1);
                //fileStream.Write(bdata, 0, bdata.Length);
                //fileStream.Close();
            }
            else
            {
                tg_HeaterFan.CapText = "ON";
                tg_HeaterFan.Checked = true;
                sqlstr = sqlstr + "ON',";
                //FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                //String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
                //byte[] bdata = Encoding.Default.GetBytes("\n  Heaterfan,ON," + s1);
                //fileStream.Write(bdata, 0, bdata.Length);
                //fileStream.Close();
            }
            String s1 = DateTime.Now.ToString("HH:mm:ss:fff");
            sqlstr = sqlstr + "'" + s1+  "')";
            cmd = new SqlCommand(sqlstr, con);
            if (con.State == ConnectionState.Closed)
            con.Open();
            cmd.ExecuteNonQuery();
            
        
    }
       
        private void frm_Heater_Load(object sender, EventArgs e)
        {
           
                
                con.ConnectionString = Constr;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                
           
                //File.WriteAllText(withHeader);
                //if (!File.Exists(FilePath))
                //{
                //    FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                //    //String s1 = DateTime.Now.ToString("hh:mm:ss:fff tt");
                //    byte[] bdata = Encoding.Default.GetBytes("Parametername,Status,Time");
                //    fileStream.Write(bdata, 0, bdata.Length);
                //    fileStream.Close();
                //}
            }

        private void txt_Stem_TextChanged(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_Heater_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Fan_TextChanged(object sender, EventArgs e)
        {

        }

        private void genDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_Rtem_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
