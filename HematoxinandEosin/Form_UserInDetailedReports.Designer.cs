
namespace HematoxinandEosin
{
    partial class Form_UserInDetailedReports
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
            this.label2 = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            this.dg_UserIndetailed = new System.Windows.Forms.DataGridView();
            this.users = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inStatuss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inTimes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_ExportPdf = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox_user = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_Month = new System.Windows.Forms.ComboBox();
            this.btn_Show = new System.Windows.Forms.Button();
            this.user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Print = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_UserIndetailed)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 21);
            this.label2.TabIndex = 36;
            this.label2.Text = "User Information :";
            // 
            // btn_close
            // 
            this.btn_close.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.Location = new System.Drawing.Point(691, 379);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 38);
            this.btn_close.TabIndex = 35;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // dg_UserIndetailed
            // 
            this.dg_UserIndetailed.AllowUserToAddRows = false;
            this.dg_UserIndetailed.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_UserIndetailed.BackgroundColor = System.Drawing.Color.White;
            this.dg_UserIndetailed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_UserIndetailed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.users,
            this.inStatuss,
            this.inTimes,
            this.outStatus,
            this.outTime,
            this.duration});
            this.dg_UserIndetailed.Location = new System.Drawing.Point(180, 109);
            this.dg_UserIndetailed.Name = "dg_UserIndetailed";
            this.dg_UserIndetailed.Size = new System.Drawing.Size(479, 317);
            this.dg_UserIndetailed.TabIndex = 34;
            // 
            // users
            // 
            this.users.HeaderText = "UserName";
            this.users.Name = "users";
            // 
            // inStatuss
            // 
            this.inStatuss.HeaderText = "In Status";
            this.inStatuss.Name = "inStatuss";
            // 
            // inTimes
            // 
            this.inTimes.HeaderText = "In Time";
            this.inTimes.Name = "inTimes";
            // 
            // outStatus
            // 
            this.outStatus.HeaderText = "Out Status";
            this.outStatus.Name = "outStatus";
            // 
            // outTime
            // 
            this.outTime.HeaderText = "Out Time";
            this.outTime.Name = "outTime";
            // 
            // duration
            // 
            this.duration.HeaderText = "Duration";
            this.duration.Name = "duration";
            // 
            // btn_ExportPdf
            // 
            this.btn_ExportPdf.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ExportPdf.Location = new System.Drawing.Point(675, 208);
            this.btn_ExportPdf.Name = "btn_ExportPdf";
            this.btn_ExportPdf.Size = new System.Drawing.Size(120, 38);
            this.btn_ExportPdf.TabIndex = 32;
            this.btn_ExportPdf.Text = "Export to PDF";
            this.btn_ExportPdf.UseVisualStyleBackColor = true;
            this.btn_ExportPdf.Click += new System.EventHandler(this.btn_ExportPdf_Click);
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
            this.label1.TabIndex = 31;
            this.label1.Text = "User Information Report";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox_user
            // 
            this.listBox_user.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_user.FormattingEnabled = true;
            this.listBox_user.ItemHeight = 21;
            this.listBox_user.Location = new System.Drawing.Point(12, 110);
            this.listBox_user.Name = "listBox_user";
            this.listBox_user.Size = new System.Drawing.Size(162, 319);
            this.listBox_user.TabIndex = 37;
            this.listBox_user.SelectedIndexChanged += new System.EventHandler(this.listBox_user_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(225, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 17);
            this.label3.TabIndex = 38;
            this.label3.Text = "Select Month :";
            // 
            // cmb_Month
            // 
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
            this.cmb_Month.Location = new System.Drawing.Point(328, 57);
            this.cmb_Month.Name = "cmb_Month";
            this.cmb_Month.Size = new System.Drawing.Size(96, 25);
            this.cmb_Month.TabIndex = 39;
            this.cmb_Month.SelectedIndexChanged += new System.EventHandler(this.cmb_Month_SelectedIndexChanged);
            this.cmb_Month.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_Month_KeyPress);
            // 
            // btn_Show
            // 
            this.btn_Show.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Show.Location = new System.Drawing.Point(442, 57);
            this.btn_Show.Name = "btn_Show";
            this.btn_Show.Size = new System.Drawing.Size(51, 25);
            this.btn_Show.TabIndex = 40;
            this.btn_Show.Text = "Show Details";
            this.btn_Show.UseVisualStyleBackColor = true;
            this.btn_Show.Click += new System.EventHandler(this.button1_Click);
            // 
            // user
            // 
            this.user.HeaderText = "User";
            this.user.Name = "user";
            this.user.Width = 62;
            // 
            // inStatus
            // 
            this.inStatus.HeaderText = "InStatus";
            this.inStatus.Name = "inStatus";
            this.inStatus.Width = 63;
            // 
            // btn_Print
            // 
            this.btn_Print.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Print.Location = new System.Drawing.Point(691, 295);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(75, 35);
            this.btn_Print.TabIndex = 49;
            this.btn_Print.Text = "Print";
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // Form_UserInDetailedReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.btn_Show);
            this.Controls.Add(this.cmb_Month);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox_user);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.dg_UserIndetailed);
            this.Controls.Add(this.btn_ExportPdf);
            this.Controls.Add(this.label1);
            this.Name = "Form_UserInDetailedReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_UserInDetailed";
            this.Load += new System.EventHandler(this.Form_UserInDetailed_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_UserIndetailed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.DataGridView dg_UserIndetailed;
        private System.Windows.Forms.Button btn_ExportPdf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox_user;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_Month;
        private System.Windows.Forms.Button btn_Show;
        private System.Windows.Forms.DataGridViewTextBoxColumn user;
        private System.Windows.Forms.DataGridViewTextBoxColumn inStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn users;
        private System.Windows.Forms.DataGridViewTextBoxColumn inStatuss;
        private System.Windows.Forms.DataGridViewTextBoxColumn inTimes;
        private System.Windows.Forms.DataGridViewTextBoxColumn outStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn outTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn duration;
        private System.Windows.Forms.Button btn_Print;
    }
}