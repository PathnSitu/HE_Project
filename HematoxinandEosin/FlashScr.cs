using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HematoxinandEosin
{
    public partial class FlashScr : Form
    {
        public FlashScr()
        {
            InitializeComponent();
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            LoginScreen frm = new LoginScreen();
            tmr.Enabled = false;
            tmr.Stop();
            this.Hide();
            frm.Show();
        }

        private void FlashScr_Load(object sender, EventArgs e)
        {
            lbl_Ver.Text = RequiredVariables.VerNoRevNo;
            tmr.Enabled = true;
            tmr.Interval = 5000;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Ver_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
