
namespace HematoxinandEosin
{
    partial class Form_CatalogConfig
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmb_CatalogNo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dg_Catalogno = new System.Windows.Forms.DataGridView();
            this.Slno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CatlogNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_vk = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Catalogno)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(680, 423);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 38);
            this.btnClose.TabIndex = 67;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(356, 80);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 38);
            this.btnRefresh.TabIndex = 65;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(463, 80);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 38);
            this.btnSave.TabIndex = 64;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(249, 80);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 38);
            this.btnDelete.TabIndex = 63;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnModify
            // 
            this.btnModify.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.Location = new System.Drawing.Point(142, 80);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 38);
            this.btnModify.TabIndex = 62;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(35, 80);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 38);
            this.btnAdd.TabIndex = 61;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmb_CatalogNo
            // 
            this.cmb_CatalogNo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_CatalogNo.FormattingEnabled = true;
            this.cmb_CatalogNo.Location = new System.Drawing.Point(275, 44);
            this.cmb_CatalogNo.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_CatalogNo.Name = "cmb_CatalogNo";
            this.cmb_CatalogNo.Size = new System.Drawing.Size(276, 25);
            this.cmb_CatalogNo.TabIndex = 51;
            this.cmb_CatalogNo.SelectedIndexChanged += new System.EventHandler(this.cmbReagent_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 20);
            this.label2.TabIndex = 68;
            this.label2.Text = "Select / Enter Catalog No : ";
            // 
            // dg_Catalogno
            // 
            this.dg_Catalogno.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_Catalogno.BackgroundColor = System.Drawing.Color.White;
            this.dg_Catalogno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Catalogno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Slno,
            this.CatlogNo});
            this.dg_Catalogno.Location = new System.Drawing.Point(34, 135);
            this.dg_Catalogno.Margin = new System.Windows.Forms.Padding(4);
            this.dg_Catalogno.Name = "dg_Catalogno";
            this.dg_Catalogno.Size = new System.Drawing.Size(263, 296);
            this.dg_Catalogno.TabIndex = 69;
            this.dg_Catalogno.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_Catalogno_CellClick);
            this.dg_Catalogno.DoubleClick += new System.EventHandler(this.dg_Catalogno_DoubleClick);
            // 
            // Slno
            // 
            this.Slno.HeaderText = "Slno";
            this.Slno.Name = "Slno";
            // 
            // CatlogNo
            // 
            this.CatlogNo.HeaderText = "Catalog No";
            this.CatlogNo.Name = "CatlogNo";
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
            this.label1.Size = new System.Drawing.Size(976, 30);
            this.label1.TabIndex = 70;
            this.label1.Text = "Catalog Configuration";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chk_vk
            // 
            this.chk_vk.AutoSize = true;
            this.chk_vk.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_vk.ForeColor = System.Drawing.Color.Black;
            this.chk_vk.Location = new System.Drawing.Point(335, 161);
            this.chk_vk.Name = "chk_vk";
            this.chk_vk.Size = new System.Drawing.Size(134, 20);
            this.chk_vk.TabIndex = 71;
            this.chk_vk.Text = "Virtual Keyboard";
            this.chk_vk.UseVisualStyleBackColor = true;
            this.chk_vk.CheckedChanged += new System.EventHandler(this.chk_vk_CheckedChanged);
            // 
            // Form_CatalogConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(976, 488);
            this.Controls.Add(this.chk_vk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dg_Catalogno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cmb_CatalogNo);
            this.Name = "Form_CatalogConfig";
            this.Text = "Form3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_CatalogConfig_FormClosing);
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Catalogno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmb_CatalogNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dg_Catalogno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Slno;
        private System.Windows.Forms.DataGridViewTextBoxColumn CatlogNo;
        private System.Windows.Forms.CheckBox chk_vk;
    }
}