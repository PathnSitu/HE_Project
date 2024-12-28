
namespace HematoxinandEosin
{
    partial class Form_JarpositionReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_JarpositionReports));
            this.dg_JarPosition = new System.Windows.Forms.DataGridView();
            this.roboticArm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xaxis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yaxis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zaxis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calibratedby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calibratedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ExportPdf = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.listBox_jp = new System.Windows.Forms.ListBox();
            this.txtList = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Show = new System.Windows.Forms.Button();
            this.cmb_Month = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Print = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_JarPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_JarPosition
            // 
            this.dg_JarPosition.AllowUserToAddRows = false;
            this.dg_JarPosition.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_JarPosition.BackgroundColor = System.Drawing.Color.White;
            this.dg_JarPosition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_JarPosition.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.roboticArm,
            this.jarName,
            this.xaxis,
            this.yaxis,
            this.zaxis,
            this.calibratedby,
            this.calibratedTime});
            this.dg_JarPosition.Location = new System.Drawing.Point(210, 109);
            this.dg_JarPosition.Name = "dg_JarPosition";
            this.dg_JarPosition.Size = new System.Drawing.Size(449, 317);
            this.dg_JarPosition.TabIndex = 1;
            // 
            // roboticArm
            // 
            this.roboticArm.HeaderText = "Robotic Arm";
            this.roboticArm.Name = "roboticArm";
            // 
            // jarName
            // 
            this.jarName.HeaderText = "Jar Name";
            this.jarName.Name = "jarName";
            // 
            // xaxis
            // 
            this.xaxis.HeaderText = "X axis";
            this.xaxis.Name = "xaxis";
            // 
            // yaxis
            // 
            this.yaxis.HeaderText = "Y axis";
            this.yaxis.Name = "yaxis";
            // 
            // zaxis
            // 
            this.zaxis.HeaderText = "Z axis";
            this.zaxis.Name = "zaxis";
            // 
            // calibratedby
            // 
            this.calibratedby.HeaderText = "Calibrated By";
            this.calibratedby.Name = "calibratedby";
            // 
            // calibratedTime
            // 
            this.calibratedTime.HeaderText = "Calibrated Time";
            this.calibratedTime.Name = "calibratedTime";
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
            this.label1.Size = new System.Drawing.Size(800, 30);
            this.label1.TabIndex = 18;
            this.label1.Text = "Jar Position Report";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_ExportPdf
            // 
            this.btn_ExportPdf.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ExportPdf.Location = new System.Drawing.Point(675, 208);
            this.btn_ExportPdf.Name = "btn_ExportPdf";
            this.btn_ExportPdf.Size = new System.Drawing.Size(120, 38);
            this.btn_ExportPdf.TabIndex = 20;
            this.btn_ExportPdf.Text = "Export to PDF";
            this.btn_ExportPdf.UseVisualStyleBackColor = true;
            this.btn_ExportPdf.Click += new System.EventHandler(this.btn_ExportPdf_Click);
            // 
            // btn_close
            // 
            this.btn_close.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.Location = new System.Drawing.Point(691, 384);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 38);
            this.btn_close.TabIndex = 30;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // listBox_jp
            // 
            this.listBox_jp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_jp.FormattingEnabled = true;
            this.listBox_jp.ItemHeight = 21;
            this.listBox_jp.Location = new System.Drawing.Point(12, 109);
            this.listBox_jp.Name = "listBox_jp";
            this.listBox_jp.Size = new System.Drawing.Size(167, 319);
            this.listBox_jp.TabIndex = 35;
            this.listBox_jp.SelectedIndexChanged += new System.EventHandler(this.listBox_jp_SelectedIndexChanged);
            // 
            // txtList
            // 
            this.txtList.Location = new System.Drawing.Point(572, 45);
            this.txtList.Name = "txtList";
            this.txtList.Size = new System.Drawing.Size(100, 20);
            this.txtList.TabIndex = 37;
            this.txtList.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 21);
            this.label2.TabIndex = 38;
            this.label2.Text = "JarPosition Calibration Datewise";
            // 
            // btn_Show
            // 
            this.btn_Show.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Show.Location = new System.Drawing.Point(493, 77);
            this.btn_Show.Name = "btn_Show";
            this.btn_Show.Size = new System.Drawing.Size(51, 25);
            this.btn_Show.TabIndex = 43;
            this.btn_Show.Text = "Show Details";
            this.btn_Show.UseVisualStyleBackColor = true;
            this.btn_Show.Click += new System.EventHandler(this.btn_Show_Click);
            // 
            // cmb_Month
            // 
            this.cmb_Month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Month.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Month.FormattingEnabled = true;
            this.cmb_Month.Items.AddRange(new object[] {
            "Select",
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmb_Month.Location = new System.Drawing.Point(379, 77);
            this.cmb_Month.Name = "cmb_Month";
            this.cmb_Month.Size = new System.Drawing.Size(96, 25);
            this.cmb_Month.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(276, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 17);
            this.label3.TabIndex = 41;
            this.label3.Text = "Select Month :";
            // 
            // btn_Print
            // 
            this.btn_Print.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Print.Location = new System.Drawing.Point(691, 290);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(75, 35);
            this.btn_Print.TabIndex = 44;
            this.btn_Print.Text = "Print";
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // Form_JarpositionReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.btn_Show);
            this.Controls.Add(this.cmb_Month);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtList);
            this.Controls.Add(this.listBox_jp);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_ExportPdf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dg_JarPosition);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_JarpositionReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "jar Position Calibration Report";
            this.Load += new System.EventHandler(this.Form_JarpositionReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_JarPosition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_JarPosition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ExportPdf;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.ListBox listBox_jp;
        private System.Windows.Forms.TextBox txtList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Show;
        private System.Windows.Forms.ComboBox cmb_Month;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn roboticArm;
        private System.Windows.Forms.DataGridViewTextBoxColumn jarName;
        private System.Windows.Forms.DataGridViewTextBoxColumn xaxis;
        private System.Windows.Forms.DataGridViewTextBoxColumn yaxis;
        private System.Windows.Forms.DataGridViewTextBoxColumn zaxis;
        private System.Windows.Forms.DataGridViewTextBoxColumn calibratedby;
        private System.Windows.Forms.DataGridViewTextBoxColumn calibratedTime;
        private System.Windows.Forms.Button btn_Print;
    }
}