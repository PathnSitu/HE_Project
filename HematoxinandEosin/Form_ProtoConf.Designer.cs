
namespace HematoxinandEosin
{
    partial class Form_ProtoConf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ProtoConf));
            this.label1 = new System.Windows.Forms.Label();
            this.panel_protocol = new System.Windows.Forms.Panel();
            this.txt_Agitation = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_ProtoType = new System.Windows.Forms.TextBox();
            this.txtProtocol = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_describe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProtoShortName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_NoofJars = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_ExportPdf = new System.Windows.Forms.Button();
            this.btn_Print = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgv_Detail = new System.Windows.Forms.DataGridView();
            this.sln = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.protoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IncubTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Noofdips = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel_protocol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Detail)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(910, 30);
            this.label1.TabIndex = 61;
            this.label1.Text = "Protocol Configuration";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_protocol
            // 
            this.panel_protocol.Controls.Add(this.txt_Agitation);
            this.panel_protocol.Controls.Add(this.label6);
            this.panel_protocol.Controls.Add(this.txt_ProtoType);
            this.panel_protocol.Controls.Add(this.txtProtocol);
            this.panel_protocol.Controls.Add(this.label10);
            this.panel_protocol.Controls.Add(this.txt_describe);
            this.panel_protocol.Controls.Add(this.label2);
            this.panel_protocol.Controls.Add(this.label3);
            this.panel_protocol.Controls.Add(this.txtProtoShortName);
            this.panel_protocol.Controls.Add(this.label5);
            this.panel_protocol.Location = new System.Drawing.Point(5, 33);
            this.panel_protocol.Name = "panel_protocol";
            this.panel_protocol.Size = new System.Drawing.Size(665, 156);
            this.panel_protocol.TabIndex = 62;
            // 
            // txt_Agitation
            // 
            this.txt_Agitation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Agitation.Location = new System.Drawing.Point(198, 70);
            this.txt_Agitation.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Agitation.Name = "txt_Agitation";
            this.txt_Agitation.Size = new System.Drawing.Size(112, 23);
            this.txt_Agitation.TabIndex = 69;
            this.txt_Agitation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Agitation_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(35, 70);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 20);
            this.label6.TabIndex = 68;
            this.label6.Text = "Agitation Required :";
            // 
            // txt_ProtoType
            // 
            this.txt_ProtoType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ProtoType.Location = new System.Drawing.Point(455, 40);
            this.txt_ProtoType.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ProtoType.Name = "txt_ProtoType";
            this.txt_ProtoType.Size = new System.Drawing.Size(188, 23);
            this.txt_ProtoType.TabIndex = 65;
            this.txt_ProtoType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ProtoType_KeyPress);
            // 
            // txtProtocol
            // 
            this.txtProtocol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProtocol.Location = new System.Drawing.Point(198, 10);
            this.txtProtocol.Margin = new System.Windows.Forms.Padding(4);
            this.txtProtocol.Name = "txtProtocol";
            this.txtProtocol.Size = new System.Drawing.Size(445, 23);
            this.txtProtocol.TabIndex = 64;
            this.txtProtocol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProtocol_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(35, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 20);
            this.label10.TabIndex = 63;
            this.label10.Text = "Description :";
            // 
            // txt_describe
            // 
            this.txt_describe.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_describe.Location = new System.Drawing.Point(198, 100);
            this.txt_describe.Multiline = true;
            this.txt_describe.Name = "txt_describe";
            this.txt_describe.Size = new System.Drawing.Size(445, 50);
            this.txt_describe.TabIndex = 62;
            this.txt_describe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_describe_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Protocol Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Protocol Short Name :";
            // 
            // txtProtoShortName
            // 
            this.txtProtoShortName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProtoShortName.Location = new System.Drawing.Point(198, 40);
            this.txtProtoShortName.Margin = new System.Windows.Forms.Padding(4);
            this.txtProtoShortName.Name = "txtProtoShortName";
            this.txtProtoShortName.Size = new System.Drawing.Size(112, 23);
            this.txtProtoShortName.TabIndex = 20;
            this.txtProtoShortName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProtoShortName_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(340, 40);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Protocol Type :";
            // 
            // txt_NoofJars
            // 
            this.txt_NoofJars.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NoofJars.Location = new System.Drawing.Point(737, 103);
            this.txt_NoofJars.Margin = new System.Windows.Forms.Padding(4);
            this.txt_NoofJars.Name = "txt_NoofJars";
            this.txt_NoofJars.Size = new System.Drawing.Size(125, 23);
            this.txt_NoofJars.TabIndex = 67;
            this.txt_NoofJars.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(733, 133);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "No. Of Jars :";
            this.label4.Visible = false;
            // 
            // btn_ExportPdf
            // 
            this.btn_ExportPdf.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ExportPdf.Location = new System.Drawing.Point(676, 270);
            this.btn_ExportPdf.Name = "btn_ExportPdf";
            this.btn_ExportPdf.Size = new System.Drawing.Size(107, 38);
            this.btn_ExportPdf.TabIndex = 63;
            this.btn_ExportPdf.Text = "Export to PDF";
            this.btn_ExportPdf.UseVisualStyleBackColor = true;
            this.btn_ExportPdf.Click += new System.EventHandler(this.btn_ExportPdf_Click);
            // 
            // btn_Print
            // 
            this.btn_Print.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Print.Location = new System.Drawing.Point(676, 341);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(107, 38);
            this.btn_Print.TabIndex = 64;
            this.btn_Print.Text = "Print";
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(676, 437);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 38);
            this.btnClose.TabIndex = 65;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgv_Detail
            // 
            this.dgv_Detail.AllowUserToAddRows = false;
            this.dgv_Detail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Detail.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Detail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sln,
            this.protoName,
            this.JarName,
            this.RegName,
            this.IncubTime,
            this.Noofdips});
            this.dgv_Detail.Location = new System.Drawing.Point(22, 196);
            this.dgv_Detail.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Detail.Name = "dgv_Detail";
            this.dgv_Detail.Size = new System.Drawing.Size(626, 301);
            this.dgv_Detail.TabIndex = 66;
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
            // JarName
            // 
            this.JarName.HeaderText = "Jar Name";
            this.JarName.Name = "JarName";
            // 
            // RegName
            // 
            this.RegName.HeaderText = "Reagent/ Temperature";
            this.RegName.Name = "RegName";
            // 
            // IncubTime
            // 
            this.IncubTime.HeaderText = "Incubation Time";
            this.IncubTime.Name = "IncubTime";
            // 
            // Noofdips
            // 
            this.Noofdips.HeaderText = "No of Dips";
            this.Noofdips.Name = "Noofdips";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(737, 162);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(125, 21);
            this.comboBox1.TabIndex = 70;
            this.comboBox1.Visible = false;
            // 
            // Form_ProtoConf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(910, 500);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dgv_Detail);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txt_NoofJars);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.btn_ExportPdf);
            this.Controls.Add(this.panel_protocol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_ProtoConf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Protocol Configuration";
            this.Load += new System.EventHandler(this.Form_ProtoConf_Load);
            this.panel_protocol.ResumeLayout(false);
            this.panel_protocol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Detail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_protocol;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_describe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProtoShortName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_ExportPdf;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgv_Detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn sln;
        private System.Windows.Forms.DataGridViewTextBoxColumn protoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn JarName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IncubTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Noofdips;
        private System.Windows.Forms.TextBox txt_Agitation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_NoofJars;
        private System.Windows.Forms.TextBox txt_ProtoType;
        private System.Windows.Forms.TextBox txtProtocol;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}