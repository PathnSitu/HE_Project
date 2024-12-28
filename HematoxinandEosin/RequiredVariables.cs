using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace HematoxinandEosin
{
    class RequiredVariables
    {
        public static string Msgtext = "Hematoxin and Eosin";
        public static string VerNoRevNo = "PnS H&&E Automation Ver. 0 && Rev. 2-T21";
        public static string UserName = "";
        public static string decryptpassword = "";
        public static string HintQuestion = "";
        public static string HintAnswer = "";
        public static string Usertype = "";
        public static string AdminUser = "";
        public static string NormalUser = "";
        public static string protoName = "";
        public static string filename = "";
        public static int pages = 0;        
        public static Boolean ServiceUser = false;
        public static string UserConfiguration = "";
        public static Boolean ForgotPassword = false;
        public static Boolean ChangePassword = false;
        public static Boolean btnConf = false;
        public static Boolean btnCalib = false;
        public static Boolean btnRunProto = false;
        public static Boolean btnReports = false;
        public static Boolean btnUser = false;
        public static Boolean btnEng = false;
        //public static Boolean btnUser = false;
        // public static Boolean btnCalib = false;
        public static Boolean RunProto_Started = false;
        public static Boolean EngineeringMode_Started = false;
        //Database Variables;
        public static string DBServerName = "";
        public static string DBName = "";
        public static string DBConnStr = "";
        public static string sqlStr = "";
        public static SqlConnection sqlcon;

        //Report Type Variable
        public static string Reptype = "";

        public static string Configuration = "";
        public static string JarPositionCalibration = "";
        public static string EngParameters = "";
        public static string UsrManage = "";
        public static string Runproto = "";
        public static string Viewproto = "";
        public static string SWUpdate = "";
        public static string PrepReagent = "";
       
        public static string SensorChk = "";
        public static Boolean alljarlvlsensed = false;
        public static void writeerrorlogfile(string exceptionstring, string functionname)
        {
            string source = Application.StartupPath + "\\Logfile\\Error";

            string dt = System.DateTime.Now.ToShortDateString();

            dt = dt.Replace("-", "");

            //Creating directory                
            if (Directory.Exists(source))
            {

            }
            else
            {
                Directory.CreateDirectory(source);
            }
            source = string.Empty;
            source = Application.StartupPath + "\\Logfile\\Error\\Errorlog_" + dt + ".txt";

            System.IO.FileStream fs = default(System.IO.FileStream);
            if (File.Exists(source))
            {
                fs = new System.IO.FileStream(source, System.IO.FileMode.Append, System.IO.FileAccess.Write);
            }
            else
            {
                fs = new System.IO.FileStream(source, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            }
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);
            sw.WriteLine("--------------------------------------------------------------------------");
            sw.WriteLine("Source : " + exceptionstring);
            sw.WriteLine("Method : " + functionname);
            sw.WriteLine("Logged Date & time : " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString());
            sw.WriteLine("--------------------------------------------------------------------------");
            sw.Flush();
            sw.Close();
        }
    }
}
