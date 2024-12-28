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

namespace HematoxinandEosin
{
    public partial class LabDetails_Configuration : Form
    {
        Form_MainMenu f1 = new Form_MainMenu();
        string FilePath = Path.Combine(@"G:\projects\mukesh\HematoxinandEosin\HematoxinandEosin\bin\Debug\" + "Lab.txt");
        string FilePath1 = Path.Combine(@"G:\projects\mukesh\HematoxinandEosin\HematoxinandEosin\bin\Debug\Images\"+"logos.png");
        public LabDetails_Configuration()
        {
            InitializeComponent();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();

            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("Oskeyboard"))
            {
                process.Kill();
            }
            RequiredVariables.btnConf = true;
        }

        private void btn_SelectLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            pB_logo.Image = Image.FromFile(dlg.FileName);
        }
        public void clear()
        {
            txt_labName.Text = "";
            txt_LabAddress1.Text = "";
            txt_LabAddress2.Text = "";
            txt_StateName.Text = "";
            txt_countryName.Text = "";
            pB_logo.Image = null; 
        }
        public void txtfields()
        {
            if (txt_labName.Text == "")
            {
                MessageBox.Show("Please enter Lab name ..!!", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txt_labName.Focus();
            }
            if (txt_LabAddress1.Text == "")
            {
                MessageBox.Show("Please enter Lab Address line1 ..!!", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txt_LabAddress1.Focus();
            }
            if (txt_LabAddress2.Text == "")

            {
                MessageBox.Show("Please enter Lab Address line2 ..!!", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txt_LabAddress2.Focus();
            }
            if (txt_StateName.Text == "")
            {
                MessageBox.Show("Please enter State name ..!!", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txt_StateName.Focus();
            }
            if (txt_countryName.Text == "")
            {
                MessageBox.Show("Please enter Country name ..!!", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txt_countryName.Focus();
            }
           
           
           
            if (pB_logo.Image == null)
            {
                MessageBox.Show("Please provide Lab Logo ..!!", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                
            }

        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_StateName.Text != "" && txt_LabAddress1.Text != "" && txt_LabAddress2.Text != "" && txt_labName.Text != "" && txt_countryName.Text != "" && pB_logo.Image != null)
            {
                FileStream fileStream = new FileStream(FilePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                byte[] bdata = Encoding.Default.GetBytes("" + txt_labName.Text + "$" + txt_LabAddress1.Text + "$" + txt_LabAddress2.Text + "," + txt_StateName.Text + "," + txt_countryName.Text);
                fileStream.Write(bdata, 0, bdata.Length);
                fileStream.Close();
                pB_logo.Image.Save(FilePath1);
                MessageBox.Show("Lab details Saved Sucessfully", RequiredVariables.Msgtext, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                clear();
            }
            else
            {
                txtfields();
            }
        }
        Image img;
        private void pB_logo_DragDrop(object sender, DragEventArgs e)
        {
            foreach(string pic in ((string[])e.Data.GetData(DataFormats.FileDrop)))
            {
                //img = Image.FromFile(pic);
                //pB_logo.Image = img;
            }
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

        private void LabDetails_Configuration_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("Oskeyboard"))
            {
                process.Kill();
            }
        }
    }
}
