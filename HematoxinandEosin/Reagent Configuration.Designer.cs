
namespace HematoxinandEosin
{
    partial class Reagent_Configuration
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_Reagentname = new System.Windows.Forms.ComboBox();
            this.cmb_CatalogNo = new System.Windows.Forms.ComboBox();
            this.txt_shortReagentName = new System.Windows.Forms.TextBox();
            this.txt_ReagentColor = new System.Windows.Forms.TextBox();
            this.btn_ReagentColor = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Modify = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.dg_reagents = new System.Windows.Forms.DataGridView();
            this.Slno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReagName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReagShrtName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CatlogNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_vk = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dg_reagents)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enter / Select Reagent Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Enter Short Reagent Name  :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Select Catalog No :";
            // 
            // cmb_Reagentname
            // 
            this.cmb_Reagentname.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Reagentname.FormattingEnabled = true;
            this.cmb_Reagentname.Location = new System.Drawing.Point(252, 51);
            this.cmb_Reagentname.Name = "cmb_Reagentname";
            this.cmb_Reagentname.Size = new System.Drawing.Size(407, 24);
            this.cmb_Reagentname.TabIndex = 5;
            this.cmb_Reagentname.SelectedIndexChanged += new System.EventHandler(this.cmb_Reagentname_SelectedIndexChanged);
            // 
            // cmb_CatalogNo
            // 
            this.cmb_CatalogNo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_CatalogNo.FormattingEnabled = true;
            this.cmb_CatalogNo.Location = new System.Drawing.Point(252, 147);
            this.cmb_CatalogNo.Name = "cmb_CatalogNo";
            this.cmb_CatalogNo.Size = new System.Drawing.Size(222, 24);
            this.cmb_CatalogNo.TabIndex = 6;
            // 
            // txt_shortReagentName
            // 
            this.txt_shortReagentName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_shortReagentName.Location = new System.Drawing.Point(252, 83);
            this.txt_shortReagentName.Name = "txt_shortReagentName";
            this.txt_shortReagentName.Size = new System.Drawing.Size(222, 22);
            this.txt_shortReagentName.TabIndex = 7;
            // 
            // txt_ReagentColor
            // 
            this.txt_ReagentColor.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ReagentColor.Location = new System.Drawing.Point(252, 115);
            this.txt_ReagentColor.Name = "txt_ReagentColor";
            this.txt_ReagentColor.Size = new System.Drawing.Size(222, 22);
            this.txt_ReagentColor.TabIndex = 8;
            // 
            // btn_ReagentColor
            // 
            this.btn_ReagentColor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ReagentColor.Location = new System.Drawing.Point(30, 110);
            this.btn_ReagentColor.Name = "btn_ReagentColor";
            this.btn_ReagentColor.Size = new System.Drawing.Size(154, 32);
            this.btn_ReagentColor.TabIndex = 9;
            this.btn_ReagentColor.Text = "Select Reagent Color";
            this.btn_ReagentColor.UseVisualStyleBackColor = true;
            this.btn_ReagentColor.Click += new System.EventHandler(this.btn_ReagentColor_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.Location = new System.Drawing.Point(30, 186);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 35);
            this.btn_Add.TabIndex = 10;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Modify
            // 
            this.btn_Modify.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Modify.Location = new System.Drawing.Point(168, 186);
            this.btn_Modify.Name = "btn_Modify";
            this.btn_Modify.Size = new System.Drawing.Size(75, 35);
            this.btn_Modify.TabIndex = 11;
            this.btn_Modify.Text = "Modify";
            this.btn_Modify.UseVisualStyleBackColor = true;
            this.btn_Modify.Click += new System.EventHandler(this.btn_Modify_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.Location = new System.Drawing.Point(306, 186);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(75, 35);
            this.btn_Delete.TabIndex = 12;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Location = new System.Drawing.Point(444, 186);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 35);
            this.btn_Save.TabIndex = 13;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Refresh.Location = new System.Drawing.Point(582, 186);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(75, 35);
            this.btn_Refresh.TabIndex = 14;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // dg_reagents
            // 
            this.dg_reagents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_reagents.BackgroundColor = System.Drawing.Color.White;
            this.dg_reagents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_reagents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Slno,
            this.ReagName,
            this.ReagShrtName,
            this.RegColor,
            this.CatlogNo});
            this.dg_reagents.Location = new System.Drawing.Point(29, 238);
            this.dg_reagents.Margin = new System.Windows.Forms.Padding(4);
            this.dg_reagents.Name = "dg_reagents";
            this.dg_reagents.Size = new System.Drawing.Size(627, 257);
            this.dg_reagents.TabIndex = 15;
            this.dg_reagents.DoubleClick += new System.EventHandler(this.dg_reagents_DoubleClick);
            // 
            // Slno
            // 
            this.Slno.HeaderText = "Slno";
            this.Slno.Name = "Slno";
            // 
            // ReagName
            // 
            this.ReagName.HeaderText = "Reagent Name";
            this.ReagName.Name = "ReagName";
            // 
            // ReagShrtName
            // 
            this.ReagShrtName.HeaderText = "Short Name";
            this.ReagShrtName.Name = "ReagShrtName";
            // 
            // RegColor
            // 
            this.RegColor.HeaderText = "Reagent Colour";
            this.RegColor.Name = "RegColor";
            // 
            // CatlogNo
            // 
            this.CatlogNo.HeaderText = "Catalog No";
            this.CatlogNo.Name = "CatlogNo";
            // 
            // btn_close
            // 
            this.btn_close.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.Location = new System.Drawing.Point(691, 384);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 38);
            this.btn_close.TabIndex = 16;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
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
            this.label1.Size = new System.Drawing.Size(770, 30);
            this.label1.TabIndex = 17;
            this.label1.Text = "Reagent Configuration";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chk_vk
            // 
            this.chk_vk.AutoSize = true;
            this.chk_vk.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_vk.ForeColor = System.Drawing.Color.Black;
            this.chk_vk.Location = new System.Drawing.Point(28, 502);
            this.chk_vk.Name = "chk_vk";
            this.chk_vk.Size = new System.Drawing.Size(134, 20);
            this.chk_vk.TabIndex = 67;
            this.chk_vk.Text = "Virtual Keyboard";
            this.chk_vk.UseVisualStyleBackColor = true;
            this.chk_vk.CheckedChanged += new System.EventHandler(this.chk_vk_CheckedChanged);
            // 
            // Reagent_Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(770, 525);
            this.Controls.Add(this.chk_vk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.dg_reagents);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Modify);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_ReagentColor);
            this.Controls.Add(this.txt_ReagentColor);
            this.Controls.Add(this.txt_shortReagentName);
            this.Controls.Add(this.cmb_CatalogNo);
            this.Controls.Add(this.cmb_Reagentname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "Reagent_Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Reagent_Configuration_FormClosing);
            this.Load += new System.EventHandler(this.Reagent_Configuration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_reagents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_Reagentname;
        private System.Windows.Forms.ComboBox cmb_CatalogNo;
        private System.Windows.Forms.TextBox txt_shortReagentName;
        private System.Windows.Forms.TextBox txt_ReagentColor;
        private System.Windows.Forms.Button btn_ReagentColor;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Modify;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.DataGridView dg_reagents;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Slno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReagName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReagShrtName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn CatlogNo;
        private System.Windows.Forms.CheckBox chk_vk;
    }
}