
namespace HematoxinandEosin
{
    partial class UserManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManagement));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_UserName = new System.Windows.Forms.ComboBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_ConfirmPassword = new System.Windows.Forms.TextBox();
            this.rdnAdmin = new System.Windows.Forms.RadioButton();
            this.rdnuser = new System.Windows.Forms.RadioButton();
            this.chk_Configuration = new System.Windows.Forms.CheckBox();
            this.chk_Calibration = new System.Windows.Forms.CheckBox();
            this.chk_RunProtocol = new System.Windows.Forms.CheckBox();
            this.chk_Reports = new System.Windows.Forms.CheckBox();
            this.chk_UserManagement = new System.Windows.Forms.CheckBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Modify = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.dg_UserDetails = new System.Windows.Forms.DataGridView();
            this.UsrName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsrType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conf = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.jarpositionCalib = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.engParameters = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.userManage = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.runProtocol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.viewPrint = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_Eng = new System.Windows.Forms.CheckBox();
            this.btn_CloseSignup = new System.Windows.Forms.Button();
            this.pnl_permissions = new System.Windows.Forms.Panel();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.pb_confirmPassword = new System.Windows.Forms.PictureBox();
            this.pb_password = new System.Windows.Forms.PictureBox();
            this.chk_vk = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dg_UserDetails)).BeginInit();
            this.pnl_permissions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_confirmPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_password)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter User Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Enter Password :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Confirm Password :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Select User Type :";
            // 
            // cmb_UserName
            // 
            this.cmb_UserName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_UserName.FormattingEnabled = true;
            this.cmb_UserName.Location = new System.Drawing.Point(187, 45);
            this.cmb_UserName.MaxLength = 25;
            this.cmb_UserName.Name = "cmb_UserName";
            this.cmb_UserName.Size = new System.Drawing.Size(308, 25);
            this.cmb_UserName.TabIndex = 7;
            this.cmb_UserName.SelectedIndexChanged += new System.EventHandler(this.cmb_UserName_SelectedIndexChanged);
            this.cmb_UserName.Click += new System.EventHandler(this.cmb_UserName_Click);
            // 
            // txt_password
            // 
            this.txt_password.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.Location = new System.Drawing.Point(187, 75);
            this.txt_password.MaxLength = 25;
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(308, 25);
            this.txt_password.TabIndex = 8;
            this.txt_password.UseSystemPasswordChar = true;
            // 
            // txt_ConfirmPassword
            // 
            this.txt_ConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ConfirmPassword.Location = new System.Drawing.Point(187, 105);
            this.txt_ConfirmPassword.MaxLength = 25;
            this.txt_ConfirmPassword.Name = "txt_ConfirmPassword";
            this.txt_ConfirmPassword.Size = new System.Drawing.Size(308, 25);
            this.txt_ConfirmPassword.TabIndex = 9;
            this.txt_ConfirmPassword.UseSystemPasswordChar = true;
            // 
            // rdnAdmin
            // 
            this.rdnAdmin.AutoSize = true;
            this.rdnAdmin.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdnAdmin.Location = new System.Drawing.Point(187, 135);
            this.rdnAdmin.Name = "rdnAdmin";
            this.rdnAdmin.Size = new System.Drawing.Size(118, 24);
            this.rdnAdmin.TabIndex = 10;
            this.rdnAdmin.TabStop = true;
            this.rdnAdmin.Text = "Administrator";
            this.rdnAdmin.UseVisualStyleBackColor = true;
            this.rdnAdmin.CheckedChanged += new System.EventHandler(this.rdnAdmin_CheckedChanged);
            // 
            // rdnuser
            // 
            this.rdnuser.AutoSize = true;
            this.rdnuser.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdnuser.Location = new System.Drawing.Point(322, 135);
            this.rdnuser.Name = "rdnuser";
            this.rdnuser.Size = new System.Drawing.Size(56, 24);
            this.rdnuser.TabIndex = 11;
            this.rdnuser.TabStop = true;
            this.rdnuser.Text = "User";
            this.rdnuser.UseVisualStyleBackColor = true;
            this.rdnuser.CheckedChanged += new System.EventHandler(this.rdnuser_CheckedChanged);
            // 
            // chk_Configuration
            // 
            this.chk_Configuration.AutoSize = true;
            this.chk_Configuration.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Configuration.Location = new System.Drawing.Point(8, 35);
            this.chk_Configuration.Name = "chk_Configuration";
            this.chk_Configuration.Size = new System.Drawing.Size(119, 24);
            this.chk_Configuration.TabIndex = 12;
            this.chk_Configuration.Text = "Configuration";
            this.chk_Configuration.UseVisualStyleBackColor = true;
            this.chk_Configuration.CheckedChanged += new System.EventHandler(this.chk_Configuration_CheckedChanged);
            // 
            // chk_Calibration
            // 
            this.chk_Calibration.AutoSize = true;
            this.chk_Calibration.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Calibration.Location = new System.Drawing.Point(188, 35);
            this.chk_Calibration.Name = "chk_Calibration";
            this.chk_Calibration.Size = new System.Drawing.Size(179, 24);
            this.chk_Calibration.TabIndex = 13;
            this.chk_Calibration.Text = "Jar Position Calibration";
            this.chk_Calibration.UseVisualStyleBackColor = true;
            this.chk_Calibration.CheckedChanged += new System.EventHandler(this.chk_Calibration_CheckedChanged);
            // 
            // chk_RunProtocol
            // 
            this.chk_RunProtocol.AutoSize = true;
            this.chk_RunProtocol.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_RunProtocol.Location = new System.Drawing.Point(188, 67);
            this.chk_RunProtocol.Name = "chk_RunProtocol";
            this.chk_RunProtocol.Size = new System.Drawing.Size(113, 24);
            this.chk_RunProtocol.TabIndex = 14;
            this.chk_RunProtocol.Text = "Run Protocol";
            this.chk_RunProtocol.UseVisualStyleBackColor = true;
            this.chk_RunProtocol.CheckedChanged += new System.EventHandler(this.chk_RunProtocol_CheckedChanged);
            // 
            // chk_Reports
            // 
            this.chk_Reports.AutoSize = true;
            this.chk_Reports.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Reports.Location = new System.Drawing.Point(391, 67);
            this.chk_Reports.Name = "chk_Reports";
            this.chk_Reports.Size = new System.Drawing.Size(165, 24);
            this.chk_Reports.TabIndex = 15;
            this.chk_Reports.Text = "View && Print Reports";
            this.chk_Reports.UseVisualStyleBackColor = true;
            this.chk_Reports.CheckedChanged += new System.EventHandler(this.chk_Reports_CheckedChanged);
            // 
            // chk_UserManagement
            // 
            this.chk_UserManagement.AutoSize = true;
            this.chk_UserManagement.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_UserManagement.Location = new System.Drawing.Point(8, 67);
            this.chk_UserManagement.Name = "chk_UserManagement";
            this.chk_UserManagement.Size = new System.Drawing.Size(149, 24);
            this.chk_UserManagement.TabIndex = 16;
            this.chk_UserManagement.Text = "User Management";
            this.chk_UserManagement.UseVisualStyleBackColor = true;
            this.chk_UserManagement.CheckedChanged += new System.EventHandler(this.chk_UserManagement_CheckedChanged);
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.Location = new System.Drawing.Point(45, 260);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 34);
            this.btn_Add.TabIndex = 18;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Modify
            // 
            this.btn_Modify.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Modify.Location = new System.Drawing.Point(165, 260);
            this.btn_Modify.Name = "btn_Modify";
            this.btn_Modify.Size = new System.Drawing.Size(75, 34);
            this.btn_Modify.TabIndex = 19;
            this.btn_Modify.Text = "Modify";
            this.btn_Modify.UseVisualStyleBackColor = true;
            this.btn_Modify.Click += new System.EventHandler(this.btn_Modify_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.Location = new System.Drawing.Point(285, 260);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(75, 34);
            this.btn_Delete.TabIndex = 20;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Location = new System.Drawing.Point(405, 260);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 34);
            this.btn_Save.TabIndex = 21;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.Location = new System.Drawing.Point(691, 384);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 38);
            this.btn_Close.TabIndex = 22;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // dg_UserDetails
            // 
            this.dg_UserDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_UserDetails.BackgroundColor = System.Drawing.Color.White;
            this.dg_UserDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_UserDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UsrName,
            this.UsrType,
            this.conf,
            this.jarpositionCalib,
            this.engParameters,
            this.userManage,
            this.runProtocol,
            this.viewPrint});
            this.dg_UserDetails.Location = new System.Drawing.Point(42, 300);
            this.dg_UserDetails.Name = "dg_UserDetails";
            this.dg_UserDetails.Size = new System.Drawing.Size(581, 119);
            this.dg_UserDetails.TabIndex = 23;
            this.dg_UserDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_UserDetails_CellClick);
            this.dg_UserDetails.DoubleClick += new System.EventHandler(this.dg_UserDetails_DoubleClick);
            // 
            // UsrName
            // 
            this.UsrName.HeaderText = "User Name";
            this.UsrName.Name = "UsrName";
            // 
            // UsrType
            // 
            this.UsrType.HeaderText = "Type";
            this.UsrType.Name = "UsrType";
            // 
            // conf
            // 
            this.conf.HeaderText = "Configuration";
            this.conf.Name = "conf";
            this.conf.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.conf.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // jarpositionCalib
            // 
            this.jarpositionCalib.HeaderText = "Jar Position Calibration";
            this.jarpositionCalib.Name = "jarpositionCalib";
            this.jarpositionCalib.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.jarpositionCalib.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // engParameters
            // 
            this.engParameters.HeaderText = "Engineering Parameters";
            this.engParameters.Name = "engParameters";
            this.engParameters.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.engParameters.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // userManage
            // 
            this.userManage.HeaderText = "UserManagement";
            this.userManage.Name = "userManage";
            this.userManage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.userManage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // runProtocol
            // 
            this.runProtocol.HeaderText = "Run Protocol";
            this.runProtocol.Name = "runProtocol";
            this.runProtocol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.runProtocol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // viewPrint
            // 
            this.viewPrint.HeaderText = "View & Print";
            this.viewPrint.Name = "viewPrint";
            this.viewPrint.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.viewPrint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(187, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 25);
            this.label6.TabIndex = 24;
            this.label6.Text = "User Permissions";
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
            this.label1.Size = new System.Drawing.Size(802, 30);
            this.label1.TabIndex = 31;
            this.label1.Text = "User Details Entry";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chk_Eng
            // 
            this.chk_Eng.AutoSize = true;
            this.chk_Eng.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Eng.Location = new System.Drawing.Point(391, 35);
            this.chk_Eng.Name = "chk_Eng";
            this.chk_Eng.Size = new System.Drawing.Size(184, 24);
            this.chk_Eng.TabIndex = 32;
            this.chk_Eng.Text = "Engineering Parameters";
            this.chk_Eng.UseVisualStyleBackColor = true;
            this.chk_Eng.CheckedChanged += new System.EventHandler(this.chk_Eng_CheckedChanged);
            // 
            // btn_CloseSignup
            // 
            this.btn_CloseSignup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CloseSignup.Location = new System.Drawing.Point(691, 320);
            this.btn_CloseSignup.Name = "btn_CloseSignup";
            this.btn_CloseSignup.Size = new System.Drawing.Size(75, 38);
            this.btn_CloseSignup.TabIndex = 33;
            this.btn_CloseSignup.Text = "Close";
            this.btn_CloseSignup.UseVisualStyleBackColor = true;
            this.btn_CloseSignup.Visible = false;
            this.btn_CloseSignup.Click += new System.EventHandler(this.btn_CloseSignup_Click);
            // 
            // pnl_permissions
            // 
            this.pnl_permissions.Controls.Add(this.label6);
            this.pnl_permissions.Controls.Add(this.chk_Configuration);
            this.pnl_permissions.Controls.Add(this.chk_Eng);
            this.pnl_permissions.Controls.Add(this.chk_Calibration);
            this.pnl_permissions.Controls.Add(this.chk_UserManagement);
            this.pnl_permissions.Controls.Add(this.chk_Reports);
            this.pnl_permissions.Controls.Add(this.chk_RunProtocol);
            this.pnl_permissions.Location = new System.Drawing.Point(35, 159);
            this.pnl_permissions.Name = "pnl_permissions";
            this.pnl_permissions.Size = new System.Drawing.Size(578, 100);
            this.pnl_permissions.TabIndex = 34;
            this.pnl_permissions.Visible = false;
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Refresh.Location = new System.Drawing.Point(525, 260);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(75, 34);
            this.btn_Refresh.TabIndex = 35;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // pb_confirmPassword
            // 
            this.pb_confirmPassword.Image = ((System.Drawing.Image)(resources.GetObject("pb_confirmPassword.Image")));
            this.pb_confirmPassword.Location = new System.Drawing.Point(468, 106);
            this.pb_confirmPassword.Name = "pb_confirmPassword";
            this.pb_confirmPassword.Size = new System.Drawing.Size(25, 20);
            this.pb_confirmPassword.TabIndex = 30;
            this.pb_confirmPassword.TabStop = false;
            this.pb_confirmPassword.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_confirmPassword_MouseDown);
            this.pb_confirmPassword.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pb_confirmPassword_MouseUp);
            // 
            // pb_password
            // 
            this.pb_password.Image = ((System.Drawing.Image)(resources.GetObject("pb_password.Image")));
            this.pb_password.Location = new System.Drawing.Point(468, 76);
            this.pb_password.Name = "pb_password";
            this.pb_password.Size = new System.Drawing.Size(25, 20);
            this.pb_password.TabIndex = 29;
            this.pb_password.TabStop = false;
            this.pb_password.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_password_MouseDown);
            this.pb_password.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pb_password_MouseUp);
            // 
            // chk_vk
            // 
            this.chk_vk.AutoSize = true;
            this.chk_vk.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_vk.ForeColor = System.Drawing.Color.Black;
            this.chk_vk.Location = new System.Drawing.Point(42, 425);
            this.chk_vk.Name = "chk_vk";
            this.chk_vk.Size = new System.Drawing.Size(134, 20);
            this.chk_vk.TabIndex = 67;
            this.chk_vk.Text = "Virtual Keyboard";
            this.chk_vk.UseVisualStyleBackColor = true;
            this.chk_vk.CheckedChanged += new System.EventHandler(this.chk_vk_CheckedChanged);
            // 
            // UserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(802, 507);
            this.Controls.Add(this.chk_vk);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.pnl_permissions);
            this.Controls.Add(this.btn_CloseSignup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb_confirmPassword);
            this.Controls.Add(this.pb_password);
            this.Controls.Add(this.dg_UserDetails);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Modify);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.rdnuser);
            this.Controls.Add(this.rdnAdmin);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.cmb_UserName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_ConfirmPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "UserManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserManagement";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserManagement_FormClosing);
            this.Load += new System.EventHandler(this.UserManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_UserDetails)).EndInit();
            this.pnl_permissions.ResumeLayout(false);
            this.pnl_permissions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_confirmPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_password)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_UserName;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_ConfirmPassword;
        private System.Windows.Forms.RadioButton rdnAdmin;
        private System.Windows.Forms.RadioButton rdnuser;
        private System.Windows.Forms.CheckBox chk_Configuration;
        private System.Windows.Forms.CheckBox chk_Calibration;
        private System.Windows.Forms.CheckBox chk_RunProtocol;
        private System.Windows.Forms.CheckBox chk_Reports;
        private System.Windows.Forms.CheckBox chk_UserManagement;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Modify;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.DataGridView dg_UserDetails;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pb_password;
        private System.Windows.Forms.PictureBox pb_confirmPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk_Eng;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsrName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsrType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn conf;
        private System.Windows.Forms.DataGridViewCheckBoxColumn jarpositionCalib;
        private System.Windows.Forms.DataGridViewCheckBoxColumn engParameters;
        private System.Windows.Forms.DataGridViewCheckBoxColumn userManage;
        private System.Windows.Forms.DataGridViewCheckBoxColumn runProtocol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn viewPrint;
        private System.Windows.Forms.Button btn_CloseSignup;
        private System.Windows.Forms.Panel pnl_permissions;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.CheckBox chk_vk;
    }
}