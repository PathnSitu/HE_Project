
namespace HematoxinandEosin
{
    partial class Form_UserReports
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
            this.btn_Load = new System.Windows.Forms.Button();
            this.dg_Users = new System.Windows.Forms.DataGridView();
            this.btn_close = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Users)).BeginInit();
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
            this.label1.Text = "User Information Report";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_ExportPdf
            // 
            this.btn_ExportPdf.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ExportPdf.Location = new System.Drawing.Point(571, 217);
            this.btn_ExportPdf.Name = "btn_ExportPdf";
            this.btn_ExportPdf.Size = new System.Drawing.Size(120, 29);
            this.btn_ExportPdf.TabIndex = 19;
            this.btn_ExportPdf.Text = "Export to PDF";
            this.btn_ExportPdf.UseVisualStyleBackColor = true;
            this.btn_ExportPdf.Click += new System.EventHandler(this.btn_ExportPdf_Click);
            // 
            // btn_Load
            // 
            this.btn_Load.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Load.Location = new System.Drawing.Point(222, 44);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(177, 29);
            this.btn_Load.TabIndex = 26;
            this.btn_Load.Text = "Load Details in the grid";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Visible = false;
            this.btn_Load.Click += new System.EventHandler(this.btn_Show_Click);
            // 
            // dg_Users
            // 
            this.dg_Users.AllowUserToAddRows = false;
            this.dg_Users.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_Users.BackgroundColor = System.Drawing.Color.White;
            this.dg_Users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Users.Location = new System.Drawing.Point(46, 89);
            this.dg_Users.Name = "dg_Users";
            this.dg_Users.Size = new System.Drawing.Size(479, 317);
            this.dg_Users.TabIndex = 28;
            // 
            // btn_close
            // 
            this.btn_close.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.Location = new System.Drawing.Point(691, 384);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 38);
            this.btn_close.TabIndex = 29;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 21);
            this.label2.TabIndex = 30;
            this.label2.Text = "User Information :";
            // 
            // Form_UserReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.dg_Users);
            this.Controls.Add(this.btn_Load);
            this.Controls.Add(this.btn_ExportPdf);
            this.Controls.Add(this.label1);
            this.Name = "Form_UserReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_UserReports";
            this.Load += new System.EventHandler(this.Form_UserReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Users)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ExportPdf;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.DataGridView dg_Users;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label label2;
    }
}