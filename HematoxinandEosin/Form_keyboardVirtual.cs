﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
//using System.Collections.Generic;
//using System.Linq;

namespace HematoxinandEosin
{
    public partial class Form_keyboardvirtual : Form
    {
        public Form_keyboardvirtual()
        {
            InitializeComponent();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                param.ExStyle |= 0x08000000;
                return param;
            }
        }
        //ParentForm _parent;
        //public ChildForm(ParentForm parent)
        //{
        //    _parent = parent;
        //    KeyPress += KeyPressHandler;
        //}

        //public KeyPressHandler(object sender, KeyPressEventArgs e)
        //{
        //    if (_parent != null)
        //    {
        //        _parent.NotifyKeyPress(e);
        //    }
        //}
        private void Form_keyboardvirtual_Load(object sender, EventArgs e)
        {
           // checkBox1.Checked = true;      
        }

        private void button85_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{ESC}");
        }

        private void button72_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F1}");
        }

        private void button69_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F2}");
        }

        private void button71_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F3}");
        }

        private void button70_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void button76_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F5}");
        }

        private void button73_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F6}");
        }

        private void button75_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F7}");
        }

        private void button74_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F8}");
        }

        private void button80_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F9}");
        }

        private void button77_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F10}");
        }

        private void button79_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F11}");
        }

        private void button78_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F12}");
        }

        private void button84_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{DELETE}");
        }

        private void button81_Click(object sender, EventArgs e)
        {
            if (altgr.Checked)
            {
                SendKeys.Send("{BREAK}");
            }
            else
            {
                SendKeys.Send("{PAUSE}");
            }
        }

        private void button83_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{PRTSC}");
        }

        private void button82_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{HOME}");
        }

        private void button41_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{END}");
        }

        private void button87_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{INSERT}");
            if (label2.Text == "INS")
            {
                label2.Text = "OVR";
            }
            else
                label2.Text = "INS";
        }

        private void button90_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{PGUP}");
        }

        private void button89_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{PGDN}");
        }

        private void button88_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{SCROLLLOCK}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("{~}");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("`");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("!");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("1");
            }
        }

        private void button48_Click(object sender, EventArgs e)
        {
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("@");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("2");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("#");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("3");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("$");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("4");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("{%}");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("5");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("{^}");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("6");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("{&}");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("7");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("*");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("8");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("{(}");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("9");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("{)}");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("0");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("_");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("-");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("{+}");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("=");
            }
        }

        private void numlock_CheckedChanged(object sender, EventArgs e)
        {
            label3.Visible = numlock.Checked;
            if (numlock.Checked == true)
            {
                numlock.BackColor = System.Drawing.ColorTranslator.FromHtml("#0076D7");
            }
            else
                numlock.BackColor = System.Drawing.ColorTranslator.FromHtml("#333333");

        }

        private void button51_Click(object sender, EventArgs e)
        {
            if (numlock.Checked)
            {
                SendKeys.Send("{DIVIDE}");
            }
            else
            {
                SendKeys.Send("{/}");
            }
        }

        private void button52_Click(object sender, EventArgs e)
        {
            if (numlock.Checked)
            {
                SendKeys.Send("{MULTIPLY}");
            }
            else
            {
                SendKeys.Send("{*}");
            }
        }

        private void button68_Click(object sender, EventArgs e)
        {
            if (numlock.Checked)
            {
                SendKeys.Send("{SUBTRACT}");
            }
            else
            {
                SendKeys.Send("{-}");
            }
        }

        private void button86_Click(object sender, EventArgs e)
        {
            if (numlock.Checked)
            {
                SendKeys.Send("{ADD}");
            }
            else
            {
                SendKeys.Send("{+}");
            }
        }

        private void button54_Click(object sender, EventArgs e)
        {
            {
                SendKeys.Send("7");
            }
        }

        private void button53_Click(object sender, EventArgs e)
        {
            if (numlock.Checked)
            {
                SendKeys.Send("8");
            }
            else
            {
                SendKeys.Send("{PGUP}");
            }
        }

        private void button55_Click(object sender, EventArgs e)
        {
            {
                SendKeys.Send("9");
            }
        }

        private void button56_Click(object sender, EventArgs e)
        {
            if (numlock.Checked)
            {
                SendKeys.Send("4");
            }
            else
            {
                SendKeys.Send("{LEFT}");
            }
        }

        private void button57_Click(object sender, EventArgs e)
        {
            {
                SendKeys.Send("5");
            }
        }

        private void button58_Click(object sender, EventArgs e)
        {
            if (numlock.Checked)
            {
                SendKeys.Send("6");
            }
            else
            {
                SendKeys.Send("{RIGHT}");
            }
        }

        private void button63_Click(object sender, EventArgs e)
        {
            {
                SendKeys.Send("1");
            }
        }

        private void button62_Click(object sender, EventArgs e)
        {
            if (numlock.Checked)
            {
                SendKeys.Send("2");
            }
            else
            {
                SendKeys.Send("{PGDN}");
            }
        }

        private void button64_Click(object sender, EventArgs e)
        {
            {
                SendKeys.Send("3");
            }
        }

        private void button60_Click(object sender, EventArgs e)
        {
            {
                SendKeys.Send("0");
            }
        }

        private void button67_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{ENTER}");
        }

        private void button61_Click(object sender, EventArgs e)
        {
            {
                SendKeys.Send(".");
            }
        }

        private void tab_CheckedChanged(object sender, EventArgs e)
        {
            if (tab.Checked)
            {
                SendKeys.Send("{TAB}");
            }
            tab.Checked = false;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("Q");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("q");
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("W");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("w");
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("E");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else if (checkBox5.Checked)
            {
                Process.Start("explorer.exe");
                checkBox5.Checked = false;
            }
            else
            {
                SendKeys.Send("e");
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("R");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("r");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("T");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("t");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("Y");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("y");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("U");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("u");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("I");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("ı");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("O");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("o");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("P");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("p");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("{{}");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("[");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("{}}");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("]");
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("|");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("\\");
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("A");
                lshift.Checked = false;
                rshift.Checked = false;
            }

            else if (lctrl.Checked || rctrl.Checked)
            {
                SendKeys.Send("^{A}");
                lctrl.Checked = false;
                rctrl.Checked = false;
            }

            else
            {
                SendKeys.Send("a");
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("S");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("s");
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("D");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("d");
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("F");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("f");
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("G");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("g");
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("H");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("h");
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("J");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("j");
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("K");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("k");
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("L");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("l");
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send(":");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send(";");
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("\"");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("'");
            }
        }

        private void button47_Click(object sender, EventArgs e)
        {
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("Z");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else if (lctrl.Checked || rctrl.Checked)
            {
                SendKeys.Send("^{Z}");
                lctrl.Checked = false;
                rctrl.Checked = false;
            }
            else
            {
                SendKeys.Send("z");
            }
        }

        private void button46_Click(object sender, EventArgs e)
        {
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("X");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("x");
            }
        }

        private void button45_Click(object sender, EventArgs e)
        {
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("C");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else if (lctrl.Checked || rctrl.Checked)
            {
                SendKeys.Send("^{C}");
                lctrl.Checked = false;
                rctrl.Checked = false;
            }
            else
            {
                SendKeys.Send("c");
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("V");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else if (lctrl.Checked || rctrl.Checked)
            {
                SendKeys.Send("^{V}");
                lctrl.Checked = false;
                rctrl.Checked = false;
            }
            else
            {
                SendKeys.Send("v");
            }
        }

        private void button43_Click(object sender, EventArgs e)
        {
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("B");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("b");
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("N");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("n");
            }
        }

        private void button39_Click(object sender, EventArgs e)
        {
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("M");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("m");
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("<");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send(",");
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send(">");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send(".");
            }
        }

        private void button42_Click(object sender, EventArgs e)
        {
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("?");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("/");
            }
        }

        private void rshift_CheckedChanged(object sender, EventArgs e)
        {
            lshift.Checked = rshift.Checked;
            if (rshift.Checked == true)
            {
                lshift.BackColor = System.Drawing.ColorTranslator.FromHtml("#0076D7");
                lshift.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");

                rshift.BackColor = System.Drawing.ColorTranslator.FromHtml("#0076D7");
                rshift.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            }
        }

        private void capslock_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = capslock.Checked;
            if (capslock.Checked == true)
            {
                capslock.BackColor = System.Drawing.ColorTranslator.FromHtml("#0076D7");
            }
            else
                capslock.BackColor = System.Drawing.ColorTranslator.FromHtml("#333333");
        }

        private void lshift_CheckedChanged(object sender, EventArgs e)
        {
            rshift.Checked = lshift.Checked;
            if (lshift.Checked == true)
            {
                lshift.BackColor = System.Drawing.ColorTranslator.FromHtml("#0076D7");
                rshift.BackColor = System.Drawing.ColorTranslator.FromHtml("#0076D7");

            }
            else
            {
                lshift.BackColor = System.Drawing.ColorTranslator.FromHtml("#333333");
                rshift.BackColor = System.Drawing.ColorTranslator.FromHtml("#333333");
            }
        }

        private void lctrl_CheckedChanged(object sender, EventArgs e)
        {
            if (lctrl.Checked == true)
            {
                rctrl.Checked = true;
                lctrl.BackColor = System.Drawing.ColorTranslator.FromHtml("#0076D7");
                rctrl.BackColor = System.Drawing.ColorTranslator.FromHtml("#0076D7");
            }
            else
            {
                rctrl.Checked = false;
                lctrl.BackColor = System.Drawing.ColorTranslator.FromHtml("#333333");
                rctrl.BackColor = System.Drawing.ColorTranslator.FromHtml("#333333");
            }
        }

        private void alt_CheckedChanged(object sender, EventArgs e)
        {
            if (alt.Checked == true)
            {
                altgr.Checked = true;
                alt.BackColor = System.Drawing.ColorTranslator.FromHtml("#0076D7");
                altgr.BackColor = System.Drawing.ColorTranslator.FromHtml("#0076D7");
            }
            else
            {
                altgr.Checked = false;
                alt.BackColor = System.Drawing.ColorTranslator.FromHtml("#333333");
                altgr.BackColor = System.Drawing.ColorTranslator.FromHtml("#333333");
            }
        }

        private void altgr_CheckedChanged(object sender, EventArgs e)
        {
            if (altgr.Checked == true)
            {
                alt.Checked = true;
                alt.BackColor = System.Drawing.ColorTranslator.FromHtml("#0076D7");
                altgr.BackColor = System.Drawing.ColorTranslator.FromHtml("#0076D7");
            }
            else
            {
                alt.Checked = false;
                alt.BackColor = System.Drawing.ColorTranslator.FromHtml("#333333");
                altgr.BackColor = System.Drawing.ColorTranslator.FromHtml("#333333");
            }
        }

        private void button49_Click(object sender, EventArgs e)
        {
            SendKeys.Send(" ");
        }

        private void button91_Click(object sender, EventArgs e)
        {
            SendKeys.Send("+({F10})");
        }

        private void rctrl_CheckedChanged(object sender, EventArgs e)
        {
            if (rctrl.Checked == true)
            {
                lctrl.Checked = true;
                lctrl.BackColor = System.Drawing.ColorTranslator.FromHtml("#0076D7");
                rctrl.BackColor = System.Drawing.ColorTranslator.FromHtml("#0076D7");
            }
            else
            {
                lctrl.Checked = false;
                lctrl.BackColor = System.Drawing.ColorTranslator.FromHtml("#333333");
                rctrl.BackColor = System.Drawing.ColorTranslator.FromHtml("#333333");
            }
        }

        private void button65_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{DOWN}");
        }

        private void button50_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{LEFT}");
        }

        private void button59_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{UP}");
        }

        private void button66_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{RIGHT}");
        }

        private void button92_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button94_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Form_keyboardvirtual_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{ENTER}");
        }

        private void button93_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{BACKSPACE}");
        }
    }
}
