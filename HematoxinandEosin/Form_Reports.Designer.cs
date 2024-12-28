
namespace HematoxinandEosin
{
    partial class Form_Reports
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ExportPdf = new System.Windows.Forms.Button();
            this.dg_ProtoRun = new System.Windows.Forms.DataGridView();
            this.rdn_Daily = new System.Windows.Forms.RadioButton();
            this.rdn_Weekly = new System.Windows.Forms.RadioButton();
            this.rdn_Monthly = new System.Windows.Forms.RadioButton();
            this.btn_Show = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.cmb_Month = new System.Windows.Forms.ComboBox();
            this.lbl_date = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.lbl_toDate = new System.Windows.Forms.Label();
            this.btn_Print = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.protoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.performedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.temp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arrivedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dg_ProtoRun)).BeginInit();
            this.SuspendLayout();
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
            this.label1.Text = "Proto Run Report";
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
            // dg_ProtoRun
            // 
            this.dg_ProtoRun.AllowUserToAddRows = false;
            this.dg_ProtoRun.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_ProtoRun.BackgroundColor = System.Drawing.Color.White;
            this.dg_ProtoRun.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_ProtoRun.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtime,
            this.protoName,
            this.performedBy,
            this.jar,
            this.temp,
            this.rack,
            this.arrivedTime,
            this.exit,
            this.duration});
            this.dg_ProtoRun.Location = new System.Drawing.Point(12, 121);
            this.dg_ProtoRun.Name = "dg_ProtoRun";
            this.dg_ProtoRun.Size = new System.Drawing.Size(571, 301);
            this.dg_ProtoRun.TabIndex = 21;
            // 
            // rdn_Daily
            // 
            this.rdn_Daily.AutoSize = true;
            this.rdn_Daily.Checked = true;
            this.rdn_Daily.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdn_Daily.Location = new System.Drawing.Point(12, 57);
            this.rdn_Daily.Name = "rdn_Daily";
            this.rdn_Daily.Size = new System.Drawing.Size(62, 24);
            this.rdn_Daily.TabIndex = 22;
            this.rdn_Daily.TabStop = true;
            this.rdn_Daily.Text = "Daily";
            this.rdn_Daily.UseVisualStyleBackColor = true;
            this.rdn_Daily.CheckedChanged += new System.EventHandler(this.rdn_Daily_CheckedChanged);
            // 
            // rdn_Weekly
            // 
            this.rdn_Weekly.AutoSize = true;
            this.rdn_Weekly.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdn_Weekly.Location = new System.Drawing.Point(80, 57);
            this.rdn_Weekly.Name = "rdn_Weekly";
            this.rdn_Weekly.Size = new System.Drawing.Size(78, 24);
            this.rdn_Weekly.TabIndex = 23;
            this.rdn_Weekly.TabStop = true;
            this.rdn_Weekly.Text = "Weekly";
            this.rdn_Weekly.UseVisualStyleBackColor = true;
            this.rdn_Weekly.CheckedChanged += new System.EventHandler(this.rdn_Weekly_CheckedChanged);
            // 
            // rdn_Monthly
            // 
            this.rdn_Monthly.AutoSize = true;
            this.rdn_Monthly.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdn_Monthly.Location = new System.Drawing.Point(164, 57);
            this.rdn_Monthly.Name = "rdn_Monthly";
            this.rdn_Monthly.Size = new System.Drawing.Size(86, 24);
            this.rdn_Monthly.TabIndex = 24;
            this.rdn_Monthly.TabStop = true;
            this.rdn_Monthly.Text = "Monthly";
            this.rdn_Monthly.UseVisualStyleBackColor = true;
            this.rdn_Monthly.CheckedChanged += new System.EventHandler(this.rdn_Monthly_CheckedChanged);
            // 
            // btn_Show
            // 
            this.btn_Show.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Show.Location = new System.Drawing.Point(597, 95);
            this.btn_Show.Name = "btn_Show";
            this.btn_Show.Size = new System.Drawing.Size(65, 29);
            this.btn_Show.TabIndex = 25;
            this.btn_Show.Text = "Show";
            this.btn_Show.UseVisualStyleBackColor = true;
            this.btn_Show.Click += new System.EventHandler(this.btn_Show_Click);
            // 
            // btn_close
            // 
            this.btn_close.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.Location = new System.Drawing.Point(691, 384);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 38);
            this.btn_close.TabIndex = 31;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // cmb_Month
            // 
            this.cmb_Month.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Month.FormattingEnabled = true;
            this.cmb_Month.Items.AddRange(new object[] {
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
            this.cmb_Month.Location = new System.Drawing.Point(267, 56);
            this.cmb_Month.Name = "cmb_Month";
            this.cmb_Month.Size = new System.Drawing.Size(107, 25);
            this.cmb_Month.TabIndex = 43;
            this.cmb_Month.Text = "Select Month";
            this.cmb_Month.Visible = false;
            this.cmb_Month.SelectedIndexChanged += new System.EventHandler(this.cmb_Month_SelectedIndexChanged);
            this.cmb_Month.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_Month_KeyPress);
            // 
            // lbl_date
            // 
            this.lbl_date.AutoSize = true;
            this.lbl_date.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_date.Location = new System.Drawing.Point(380, 61);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.Size = new System.Drawing.Size(85, 17);
            this.lbl_date.TabIndex = 44;
            this.lbl_date.Text = "Select Date :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(471, 57);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(112, 25);
            this.dateTimePicker1.TabIndex = 45;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(668, 57);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(112, 25);
            this.dateTimePicker2.TabIndex = 46;
            this.dateTimePicker2.Visible = false;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // lbl_toDate
            // 
            this.lbl_toDate.AutoSize = true;
            this.lbl_toDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_toDate.Location = new System.Drawing.Point(598, 61);
            this.lbl_toDate.Name = "lbl_toDate";
            this.lbl_toDate.Size = new System.Drawing.Size(64, 17);
            this.lbl_toDate.TabIndex = 47;
            this.lbl_toDate.Text = "To Date :";
            this.lbl_toDate.Visible = false;
            // 
            // btn_Print
            // 
            this.btn_Print.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Print.Location = new System.Drawing.Point(691, 279);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(75, 35);
            this.btn_Print.TabIndex = 48;
            this.btn_Print.Text = "Print";
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(629, 131);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 49;
            this.textBox1.Visible = false;
            // 
            // dtime
            // 
            this.dtime.HeaderText = "Date";
            this.dtime.Name = "dtime";
            // 
            // protoName
            // 
            this.protoName.HeaderText = "Protocol Name";
            this.protoName.Name = "protoName";
            // 
            // performedBy
            // 
            this.performedBy.HeaderText = "Performed By";
            this.performedBy.Name = "performedBy";
            // 
            // jar
            // 
            this.jar.HeaderText = "Jar Name";
            this.jar.Name = "jar";
            // 
            // temp
            // 
            this.temp.HeaderText = "Temp.";
            this.temp.Name = "temp";
            // 
            // rack
            // 
            this.rack.HeaderText = "Rack No";
            this.rack.Name = "rack";
            // 
            // arrivedTime
            // 
            this.arrivedTime.HeaderText = "Arrived";
            this.arrivedTime.Name = "arrivedTime";
            // 
            // exit
            // 
            this.exit.HeaderText = "Departure";
            this.exit.Name = "exit";
            // 
            // duration
            // 
            this.duration.HeaderText = "Duration";
            this.duration.Name = "duration";
            // 
            // Form_Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.lbl_toDate);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lbl_date);
            this.Controls.Add(this.cmb_Month);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_Show);
            this.Controls.Add(this.rdn_Monthly);
            this.Controls.Add(this.rdn_Weekly);
            this.Controls.Add(this.rdn_Daily);
            this.Controls.Add(this.dg_ProtoRun);
            this.Controls.Add(this.btn_ExportPdf);
            this.Controls.Add(this.label1);
            this.Name = "Form_Reports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Reports";
            this.Load += new System.EventHandler(this.Form_Reports_Load_2);
            ((System.ComponentModel.ISupportInitialize)(this.dg_ProtoRun)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ExportPdf;
        private System.Windows.Forms.DataGridView dg_ProtoRun;
        private System.Windows.Forms.RadioButton rdn_Daily;
        private System.Windows.Forms.RadioButton rdn_Weekly;
        private System.Windows.Forms.RadioButton rdn_Monthly;
        private System.Windows.Forms.Button btn_Show;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.ComboBox cmb_Month;
        private System.Windows.Forms.Label lbl_date;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label lbl_toDate;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn protoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn performedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn jar;
        private System.Windows.Forms.DataGridViewTextBoxColumn temp;
        private System.Windows.Forms.DataGridViewTextBoxColumn rack;
        private System.Windows.Forms.DataGridViewTextBoxColumn arrivedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn exit;
        private System.Windows.Forms.DataGridViewTextBoxColumn duration;
    }
}