
namespace HematoxinandEosin
{
    partial class Form_engReports
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_engReports));
            this.dg_Eng = new System.Windows.Forms.DataGridView();
            this.eng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calibBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ExportPdf = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.listBox_eng = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_selectAll = new System.Windows.Forms.Button();
            this.btn_Print = new System.Windows.Forms.Button();
            this.txtList = new System.Windows.Forms.TextBox();
            this.btn_Show = new System.Windows.Forms.Button();
            this.cmb_Month = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Eng)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_Eng
            // 
            this.dg_Eng.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_Eng.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_Eng.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_Eng.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_Eng.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dg_Eng.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Eng.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eng,
            this.status,
            this.calibBy,
            this.time});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_Eng.DefaultCellStyle = dataGridViewCellStyle3;
            this.dg_Eng.Location = new System.Drawing.Point(210, 109);
            this.dg_Eng.Name = "dg_Eng";
            this.dg_Eng.RowHeadersVisible = false;
            this.dg_Eng.Size = new System.Drawing.Size(830, 408);
            this.dg_Eng.TabIndex = 0;
            // 
            // eng
            // 
            this.eng.HeaderText = "ParameterName";
            this.eng.Name = "eng";
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            // 
            // calibBy
            // 
            this.calibBy.HeaderText = "Calibrated By";
            this.calibBy.Name = "calibBy";
            // 
            // time
            // 
            this.time.HeaderText = "Time";
            this.time.Name = "time";
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
            this.label1.Size = new System.Drawing.Size(1350, 30);
            this.label1.TabIndex = 18;
            this.label1.Text = "Engineering Mode Report";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_ExportPdf
            // 
            this.btn_ExportPdf.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ExportPdf.Location = new System.Drawing.Point(1077, 205);
            this.btn_ExportPdf.Name = "btn_ExportPdf";
            this.btn_ExportPdf.Size = new System.Drawing.Size(122, 34);
            this.btn_ExportPdf.TabIndex = 20;
            this.btn_ExportPdf.Text = "Export to PDF";
            this.btn_ExportPdf.UseVisualStyleBackColor = true;
            this.btn_ExportPdf.Click += new System.EventHandler(this.btn_ExportPdf_Click);
            // 
            // btn_close
            // 
            this.btn_close.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.Location = new System.Drawing.Point(1077, 381);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(122, 34);
            this.btn_close.TabIndex = 30;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // listBox_eng
            // 
            this.listBox_eng.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_eng.FormattingEnabled = true;
            this.listBox_eng.ItemHeight = 20;
            this.listBox_eng.Location = new System.Drawing.Point(12, 109);
            this.listBox_eng.Name = "listBox_eng";
            this.listBox_eng.Size = new System.Drawing.Size(162, 404);
            this.listBox_eng.TabIndex = 34;
            this.listBox_eng.SelectedIndexChanged += new System.EventHandler(this.listBox_eng_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 21);
            this.label2.TabIndex = 36;
            this.label2.Text = "Engineering Mode Datewise";
            // 
            // btn_selectAll
            // 
            this.btn_selectAll.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_selectAll.Location = new System.Drawing.Point(1077, 132);
            this.btn_selectAll.Name = "btn_selectAll";
            this.btn_selectAll.Size = new System.Drawing.Size(122, 34);
            this.btn_selectAll.TabIndex = 37;
            this.btn_selectAll.Text = "Select All";
            this.btn_selectAll.UseVisualStyleBackColor = true;
            this.btn_selectAll.Visible = false;
            this.btn_selectAll.Click += new System.EventHandler(this.btn_selectAll_Click);
            // 
            // btn_Print
            // 
            this.btn_Print.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Print.Location = new System.Drawing.Point(1077, 292);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(122, 34);
            this.btn_Print.TabIndex = 39;
            this.btn_Print.Text = "Print";
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Read_Click);
            // 
            // txtList
            // 
            this.txtList.Location = new System.Drawing.Point(564, 33);
            this.txtList.Name = "txtList";
            this.txtList.Size = new System.Drawing.Size(100, 20);
            this.txtList.TabIndex = 35;
            this.txtList.Visible = false;
            // 
            // btn_Show
            // 
            this.btn_Show.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Show.Location = new System.Drawing.Point(497, 72);
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
            this.cmb_Month.Location = new System.Drawing.Point(383, 72);
            this.cmb_Month.Name = "cmb_Month";
            this.cmb_Month.Size = new System.Drawing.Size(96, 25);
            this.cmb_Month.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(280, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 17);
            this.label3.TabIndex = 41;
            this.label3.Text = "Select Month :";
            // 
            // Form_engReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1350, 529);
            this.Controls.Add(this.btn_Show);
            this.Controls.Add(this.cmb_Month);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.btn_selectAll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtList);
            this.Controls.Add(this.listBox_eng);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_ExportPdf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dg_Eng);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_engReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Engineering Parameters ";
            this.Load += new System.EventHandler(this.Form_engReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Eng)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_Eng;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ExportPdf;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.ListBox listBox_eng;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_selectAll;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.TextBox txtList;
        private System.Windows.Forms.Button btn_Show;
        private System.Windows.Forms.ComboBox cmb_Month;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn eng;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn calibBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
    }
}