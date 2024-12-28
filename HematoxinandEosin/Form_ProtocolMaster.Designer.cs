
namespace HematoxinandEosin
{
    partial class Form_ProtocolMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ProtocolMaster));
            this.dg_proto = new System.Windows.Forms.DataGridView();
            this.sln = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.protoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.protoType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.describe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_ExportPdf = new System.Windows.Forms.Button();
            this.btn_Print = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_proto)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_proto
            // 
            this.dg_proto.AllowUserToAddRows = false;
            this.dg_proto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_proto.BackgroundColor = System.Drawing.Color.White;
            this.dg_proto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_proto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sln,
            this.protoName,
            this.protoType,
            this.describe,
            this.createdOn,
            this.createdBy});
            this.dg_proto.Location = new System.Drawing.Point(49, 50);
            this.dg_proto.Name = "dg_proto";
            this.dg_proto.Size = new System.Drawing.Size(692, 433);
            this.dg_proto.TabIndex = 0;
            this.dg_proto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_proto_CellClick);
            // 
            // sln
            // 
            this.sln.HeaderText = "Slno";
            this.sln.Name = "sln";
            // 
            // protoName
            // 
            this.protoName.HeaderText = "Protocol Name";
            this.protoName.Name = "protoName";
            // 
            // protoType
            // 
            this.protoType.HeaderText = "Protocol Type";
            this.protoType.Name = "protoType";
            // 
            // describe
            // 
            this.describe.HeaderText = "Description";
            this.describe.Name = "describe";
            // 
            // createdOn
            // 
            this.createdOn.HeaderText = "Created On";
            this.createdOn.Name = "createdOn";
            // 
            // createdBy
            // 
            this.createdBy.HeaderText = "Created By";
            this.createdBy.Name = "createdBy";
            // 
            // btn_ExportPdf
            // 
            this.btn_ExportPdf.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ExportPdf.Location = new System.Drawing.Point(793, 195);
            this.btn_ExportPdf.Name = "btn_ExportPdf";
            this.btn_ExportPdf.Size = new System.Drawing.Size(107, 38);
            this.btn_ExportPdf.TabIndex = 33;
            this.btn_ExportPdf.Text = "Export to PDF";
            this.btn_ExportPdf.UseVisualStyleBackColor = true;
            this.btn_ExportPdf.Click += new System.EventHandler(this.btn_ExportPdf_Click);
            // 
            // btn_Print
            // 
            this.btn_Print.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Print.Location = new System.Drawing.Point(793, 275);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(107, 38);
            this.btn_Print.TabIndex = 50;
            this.btn_Print.Text = "Print";
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
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
            this.label1.Size = new System.Drawing.Size(947, 30);
            this.label1.TabIndex = 62;
            this.label1.Text = "View Protocols ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(793, 417);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 38);
            this.btnClose.TabIndex = 66;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Form_ProtocolMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(947, 502);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.btn_ExportPdf);
            this.Controls.Add(this.dg_proto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_ProtocolMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Master Protocols Details";
            this.Load += new System.EventHandler(this.Form_ProtocolMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_proto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_proto;
        private System.Windows.Forms.DataGridViewTextBoxColumn sln;
        private System.Windows.Forms.DataGridViewTextBoxColumn protoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn protoType;
        private System.Windows.Forms.DataGridViewTextBoxColumn describe;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdBy;
        private System.Windows.Forms.Button btn_ExportPdf;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
    }
}