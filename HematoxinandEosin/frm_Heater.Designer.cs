
namespace HematoxinandEosin
{
    partial class frm_Heater
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.tg_Heater = new Togg_Switch.Togg_Switch();
            this.label6 = new System.Windows.Forms.Label();
            this.tg_HeaterFan = new Togg_Switch.Togg_Switch();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_setTemperature = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_Set = new System.Windows.Forms.Button();
            this.btn_Read = new System.Windows.Forms.Button();
            this.txt_readTemperature = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(193, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 21);
            this.label3.TabIndex = 39;
            this.label3.Text = "Temperature Setting / Reading";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(200, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 41;
            this.label4.Text = "Heater\'s         :";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(185, 80);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(71, 23);
            this.label26.TabIndex = 60;
            this.label26.Text = "Heaters";
            this.label26.Click += new System.EventHandler(this.label26_Click);
            // 
            // tg_Heater
            // 
            this.tg_Heater.CapText = "OFF";
            this.tg_Heater.Checked = false;
            this.tg_Heater.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tg_Heater.ForeColor = System.Drawing.Color.White;
            this.tg_Heater.Location = new System.Drawing.Point(304, 117);
            this.tg_Heater.MinimumSize = new System.Drawing.Size(45, 22);
            this.tg_Heater.Name = "tg_Heater";
            this.tg_Heater.OffBackColor = System.Drawing.Color.DarkGreen;
            this.tg_Heater.OffToggleColor = System.Drawing.Color.White;
            this.tg_Heater.OnBackColor = System.Drawing.Color.Firebrick;
            this.tg_Heater.OnToggleColor = System.Drawing.Color.White;
            this.tg_Heater.Size = new System.Drawing.Size(65, 22);
            this.tg_Heater.SolidStyle = true;
            this.tg_Heater.TabIndex = 81;
            this.tg_Heater.Load += new System.EventHandler(this.tg_Heater_Load);
            this.tg_Heater.Click += new System.EventHandler(this.tg_Heater_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(200, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.TabIndex = 43;
            this.label6.Text = "Heater Fan\'s  :";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // tg_HeaterFan
            // 
            this.tg_HeaterFan.CapText = "OFF";
            this.tg_HeaterFan.Checked = false;
            this.tg_HeaterFan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tg_HeaterFan.ForeColor = System.Drawing.Color.White;
            this.tg_HeaterFan.Location = new System.Drawing.Point(304, 157);
            this.tg_HeaterFan.MinimumSize = new System.Drawing.Size(45, 22);
            this.tg_HeaterFan.Name = "tg_HeaterFan";
            this.tg_HeaterFan.OffBackColor = System.Drawing.Color.DarkGreen;
            this.tg_HeaterFan.OffToggleColor = System.Drawing.Color.White;
            this.tg_HeaterFan.OnBackColor = System.Drawing.Color.Firebrick;
            this.tg_HeaterFan.OnToggleColor = System.Drawing.Color.White;
            this.tg_HeaterFan.Size = new System.Drawing.Size(65, 22);
            this.tg_HeaterFan.SolidStyle = true;
            this.tg_HeaterFan.TabIndex = 82;
            this.tg_HeaterFan.Load += new System.EventHandler(this.tg_HeaterFan_Load);
            this.tg_HeaterFan.Click += new System.EventHandler(this.tg_HeaterFan_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(200, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 20);
            this.label2.TabIndex = 38;
            this.label2.Text = "Select Temperature :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cmb_setTemperature
            // 
            this.cmb_setTemperature.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_setTemperature.FormattingEnabled = true;
            this.cmb_setTemperature.Location = new System.Drawing.Point(350, 224);
            this.cmb_setTemperature.Name = "cmb_setTemperature";
            this.cmb_setTemperature.Size = new System.Drawing.Size(67, 25);
            this.cmb_setTemperature.TabIndex = 50;
            this.cmb_setTemperature.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(423, 227);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 17);
            this.label14.TabIndex = 52;
            this.label14.Text = "°C";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // btn_Set
            // 
            this.btn_Set.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Set.Location = new System.Drawing.Point(450, 221);
            this.btn_Set.Name = "btn_Set";
            this.btn_Set.Size = new System.Drawing.Size(35, 28);
            this.btn_Set.TabIndex = 54;
            this.btn_Set.Text = "Set";
            this.btn_Set.UseVisualStyleBackColor = true;
            this.btn_Set.Click += new System.EventHandler(this.btn_Set_Click);
            // 
            // btn_Read
            // 
            this.btn_Read.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Read.Location = new System.Drawing.Point(491, 221);
            this.btn_Read.Name = "btn_Read";
            this.btn_Read.Size = new System.Drawing.Size(45, 28);
            this.btn_Read.TabIndex = 55;
            this.btn_Read.Text = "Read";
            this.btn_Read.UseVisualStyleBackColor = true;
            this.btn_Read.Click += new System.EventHandler(this.btn_Read_Click);
            // 
            // txt_readTemperature
            // 
            this.txt_readTemperature.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_readTemperature.Location = new System.Drawing.Point(542, 221);
            this.txt_readTemperature.Multiline = true;
            this.txt_readTemperature.Name = "txt_readTemperature";
            this.txt_readTemperature.Size = new System.Drawing.Size(53, 28);
            this.txt_readTemperature.TabIndex = 51;
            this.txt_readTemperature.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(601, 227);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 17);
            this.label15.TabIndex = 53;
            this.label15.Text = "°C";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.Location = new System.Drawing.Point(691, 384);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 38);
            this.btn_Close.TabIndex = 90;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(784, 30);
            this.label1.TabIndex = 97;
            this.label1.Text = "Engineering Mode Calibration";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // frm_Heater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 425);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txt_readTemperature);
            this.Controls.Add(this.btn_Read);
            this.Controls.Add(this.btn_Set);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmb_setTemperature);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tg_HeaterFan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tg_Heater);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label26);
            this.MaximizeBox = false;
            this.Name = "frm_Heater";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Heater";
            this.Load += new System.EventHandler(this.frm_Heater_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label26;
        private Togg_Switch.Togg_Switch tg_Heater;
        private System.Windows.Forms.Label label6;
        private Togg_Switch.Togg_Switch tg_HeaterFan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_setTemperature;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btn_Set;
        private System.Windows.Forms.Button btn_Read;
        private System.Windows.Forms.TextBox txt_readTemperature;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label label1;
    }
}