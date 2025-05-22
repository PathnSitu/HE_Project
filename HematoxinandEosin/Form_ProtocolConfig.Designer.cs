
namespace HematoxinandEosin
{
    partial class Form_ProtocolConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ProtocolConfig));
            this.rdnUser = new System.Windows.Forms.RadioButton();
            this.rdnFactory = new System.Windows.Forms.RadioButton();
            this.chkAgitation = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btn_LoadGrid = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.dt_Washtime = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.panel_Buttons = new System.Windows.Forms.Panel();
            this.btn_AddNewRecord = new System.Windows.Forms.Button();
            this.chk_WashRequired = new System.Windows.Forms.CheckBox();
            this.panel_reagent = new System.Windows.Forms.Panel();
            this.pnl_Wsh = new System.Windows.Forms.Panel();
            this.cmbNofDips = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dt_incubationtime = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.txtReagentShortName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbReagent = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbJarName = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel_Heat = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTempature = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dt_Heatingtime = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.chkHeat = new System.Windows.Forms.CheckBox();
            this.panel_protocol = new System.Windows.Forms.Panel();
            this.lbl_CloneName = new System.Windows.Forms.Label();
            this.txt_CloneName = new System.Windows.Forms.TextBox();
            this.chk_Clone = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_loadDetails = new System.Windows.Forms.Button();
            this.txt_describe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbProtocol = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProtoShortName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbNofJars = new System.Windows.Forms.ComboBox();
            this.genDate = new System.Windows.Forms.DateTimePicker();
            this.dgv_Detail = new System.Windows.Forms.DataGridView();
            this.sln = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.protoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IncubTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Noofdips = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_ExportPdf = new System.Windows.Forms.Button();
            this.btn_Print = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.chk_vk = new System.Windows.Forms.CheckBox();
            this.txt_protocolName = new System.Windows.Forms.TextBox();
            this.chk_Detele = new System.Windows.Forms.CheckBox();
            this.panel_Buttons.SuspendLayout();
            this.panel_reagent.SuspendLayout();
            this.pnl_Wsh.SuspendLayout();
            this.panel_Heat.SuspendLayout();
            this.panel_protocol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Detail)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdnUser
            // 
            this.rdnUser.AutoSize = true;
            this.rdnUser.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdnUser.Location = new System.Drawing.Point(547, 40);
            this.rdnUser.Margin = new System.Windows.Forms.Padding(4);
            this.rdnUser.Name = "rdnUser";
            this.rdnUser.Size = new System.Drawing.Size(60, 24);
            this.rdnUser.TabIndex = 26;
            this.rdnUser.TabStop = true;
            this.rdnUser.Text = "User ";
            this.rdnUser.UseVisualStyleBackColor = true;
            // 
            // rdnFactory
            // 
            this.rdnFactory.AutoSize = true;
            this.rdnFactory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdnFactory.Location = new System.Drawing.Point(465, 40);
            this.rdnFactory.Margin = new System.Windows.Forms.Padding(4);
            this.rdnFactory.Name = "rdnFactory";
            this.rdnFactory.Size = new System.Drawing.Size(74, 24);
            this.rdnFactory.TabIndex = 25;
            this.rdnFactory.TabStop = true;
            this.rdnFactory.Text = "Factory";
            this.rdnFactory.UseVisualStyleBackColor = true;
            // 
            // chkAgitation
            // 
            this.chkAgitation.AutoSize = true;
            this.chkAgitation.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAgitation.Location = new System.Drawing.Point(38, 70);
            this.chkAgitation.Margin = new System.Windows.Forms.Padding(4);
            this.chkAgitation.Name = "chkAgitation";
            this.chkAgitation.Size = new System.Drawing.Size(144, 21);
            this.chkAgitation.TabIndex = 23;
            this.chkAgitation.Text = "Agitation Required";
            this.chkAgitation.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(18, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 45);
            this.btnAdd.TabIndex = 27;
            this.btnAdd.Text = "Add New Protocol";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnModify
            // 
            this.btnModify.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.Location = new System.Drawing.Point(18, 131);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 45);
            this.btnModify.TabIndex = 28;
            this.btnModify.Text = "Modify Details";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(18, 190);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 45);
            this.btnDelete.TabIndex = 29;
            this.btnDelete.Text = "Delete Details";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(18, 251);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 45);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(18, 323);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 45);
            this.btnRefresh.TabIndex = 31;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btn_LoadGrid
            // 
            this.btn_LoadGrid.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LoadGrid.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_LoadGrid.Location = new System.Drawing.Point(557, 36);
            this.btn_LoadGrid.Name = "btn_LoadGrid";
            this.btn_LoadGrid.Size = new System.Drawing.Size(104, 55);
            this.btn_LoadGrid.TabIndex = 59;
            this.btn_LoadGrid.Text = "Load Details to Grid";
            this.btn_LoadGrid.UseVisualStyleBackColor = true;
            this.btn_LoadGrid.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(715, 435);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 38);
            this.btnClose.TabIndex = 53;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(7, 2);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 20);
            this.label18.TabIndex = 42;
            this.label18.Text = "Wash Time :";
            // 
            // dt_Washtime
            // 
            this.dt_Washtime.CustomFormat = "mm:ss";
            this.dt_Washtime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_Washtime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_Washtime.Location = new System.Drawing.Point(106, 3);
            this.dt_Washtime.Name = "dt_Washtime";
            this.dt_Washtime.ShowUpDown = true;
            this.dt_Washtime.Size = new System.Drawing.Size(60, 23);
            this.dt_Washtime.TabIndex = 43;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(172, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 17);
            this.label17.TabIndex = 44;
            this.label17.Text = "Min:Sec";
            // 
            // panel_Buttons
            // 
            this.panel_Buttons.Controls.Add(this.btn_AddNewRecord);
            this.panel_Buttons.Controls.Add(this.btnAdd);
            this.panel_Buttons.Controls.Add(this.btnModify);
            this.panel_Buttons.Controls.Add(this.btnDelete);
            this.panel_Buttons.Controls.Add(this.btnSave);
            this.panel_Buttons.Controls.Add(this.btnRefresh);
            this.panel_Buttons.Location = new System.Drawing.Point(697, 32);
            this.panel_Buttons.Name = "panel_Buttons";
            this.panel_Buttons.Size = new System.Drawing.Size(114, 381);
            this.panel_Buttons.TabIndex = 58;
            // 
            // btn_AddNewRecord
            // 
            this.btn_AddNewRecord.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddNewRecord.Location = new System.Drawing.Point(18, 72);
            this.btn_AddNewRecord.Name = "btn_AddNewRecord";
            this.btn_AddNewRecord.Size = new System.Drawing.Size(75, 45);
            this.btn_AddNewRecord.TabIndex = 32;
            this.btn_AddNewRecord.Text = "Add New Details";
            this.btn_AddNewRecord.UseVisualStyleBackColor = true;
            this.btn_AddNewRecord.Click += new System.EventHandler(this.btn_AddNewRecord_Click);
            // 
            // chk_WashRequired
            // 
            this.chk_WashRequired.AutoSize = true;
            this.chk_WashRequired.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_WashRequired.Location = new System.Drawing.Point(38, 70);
            this.chk_WashRequired.Margin = new System.Windows.Forms.Padding(4);
            this.chk_WashRequired.Name = "chk_WashRequired";
            this.chk_WashRequired.Size = new System.Drawing.Size(107, 21);
            this.chk_WashRequired.TabIndex = 41;
            this.chk_WashRequired.Text = "Priority High";
            this.chk_WashRequired.UseVisualStyleBackColor = true;
            this.chk_WashRequired.CheckedChanged += new System.EventHandler(this.chk_WashRequired_CheckedChanged);
            // 
            // panel_reagent
            // 
            this.panel_reagent.Controls.Add(this.pnl_Wsh);
            this.panel_reagent.Controls.Add(this.btn_LoadGrid);
            this.panel_reagent.Controls.Add(this.cmbNofDips);
            this.panel_reagent.Controls.Add(this.label13);
            this.panel_reagent.Controls.Add(this.label16);
            this.panel_reagent.Controls.Add(this.chk_WashRequired);
            this.panel_reagent.Controls.Add(this.dt_incubationtime);
            this.panel_reagent.Controls.Add(this.label12);
            this.panel_reagent.Controls.Add(this.txtReagentShortName);
            this.panel_reagent.Controls.Add(this.label9);
            this.panel_reagent.Controls.Add(this.cmbReagent);
            this.panel_reagent.Controls.Add(this.label8);
            this.panel_reagent.Controls.Add(this.cmbJarName);
            this.panel_reagent.Controls.Add(this.label11);
            this.panel_reagent.Location = new System.Drawing.Point(0, 261);
            this.panel_reagent.Name = "panel_reagent";
            this.panel_reagent.Size = new System.Drawing.Size(674, 105);
            this.panel_reagent.TabIndex = 56;
            this.panel_reagent.Visible = false;
            // 
            // pnl_Wsh
            // 
            this.pnl_Wsh.Controls.Add(this.label18);
            this.pnl_Wsh.Controls.Add(this.dt_Washtime);
            this.pnl_Wsh.Controls.Add(this.label17);
            this.pnl_Wsh.Location = new System.Drawing.Point(163, 66);
            this.pnl_Wsh.Name = "pnl_Wsh";
            this.pnl_Wsh.Size = new System.Drawing.Size(230, 30);
            this.pnl_Wsh.TabIndex = 64;
            this.pnl_Wsh.Visible = false;
            // 
            // cmbNofDips
            // 
            this.cmbNofDips.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNofDips.FormattingEnabled = true;
            this.cmbNofDips.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cmbNofDips.Location = new System.Drawing.Point(499, 72);
            this.cmbNofDips.Margin = new System.Windows.Forms.Padding(4);
            this.cmbNofDips.Name = "cmbNofDips";
            this.cmbNofDips.Size = new System.Drawing.Size(51, 23);
            this.cmbNofDips.TabIndex = 63;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(404, 72);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 20);
            this.label13.TabIndex = 62;
            this.label13.Text = "No. Of Dips :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(458, 38);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 17);
            this.label16.TabIndex = 40;
            this.label16.Text = "Min:Sec";
            // 
            // dt_incubationtime
            // 
            this.dt_incubationtime.CustomFormat = "mm:ss";
            this.dt_incubationtime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_incubationtime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_incubationtime.Location = new System.Drawing.Point(392, 34);
            this.dt_incubationtime.Name = "dt_incubationtime";
            this.dt_incubationtime.ShowUpDown = true;
            this.dt_incubationtime.Size = new System.Drawing.Size(60, 23);
            this.dt_incubationtime.TabIndex = 36;
            this.dt_incubationtime.Value = new System.DateTime(2025, 4, 24, 0, 0, 0, 0);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(262, 36);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 20);
            this.label12.TabIndex = 24;
            this.label12.Text = "Incubation Time :";
            // 
            // txtReagentShortName
            // 
            this.txtReagentShortName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReagentShortName.Location = new System.Drawing.Point(178, 36);
            this.txtReagentShortName.Margin = new System.Windows.Forms.Padding(4);
            this.txtReagentShortName.Name = "txtReagentShortName";
            this.txtReagentShortName.Size = new System.Drawing.Size(67, 23);
            this.txtReagentShortName.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(32, 36);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 20);
            this.label9.TabIndex = 22;
            this.label9.Text = "Short Name :";
            // 
            // cmbReagent
            // 
            this.cmbReagent.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbReagent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbReagent.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReagent.FormattingEnabled = true;
            this.cmbReagent.Location = new System.Drawing.Point(458, 6);
            this.cmbReagent.Margin = new System.Windows.Forms.Padding(4);
            this.cmbReagent.Name = "cmbReagent";
            this.cmbReagent.Size = new System.Drawing.Size(203, 21);
            this.cmbReagent.TabIndex = 21;
            this.cmbReagent.SelectedIndexChanged += new System.EventHandler(this.cmbReagent_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(251, 7);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(199, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "Select/Enter Reagent Name :";
            // 
            // cmbJarName
            // 
            this.cmbJarName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbJarName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbJarName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbJarName.FormattingEnabled = true;
            this.cmbJarName.Location = new System.Drawing.Point(176, 6);
            this.cmbJarName.Margin = new System.Windows.Forms.Padding(4);
            this.cmbJarName.Name = "cmbJarName";
            this.cmbJarName.Size = new System.Drawing.Size(60, 23);
            this.cmbJarName.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(32, 6);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 20);
            this.label11.TabIndex = 16;
            this.label11.Text = "Select Jar Number :";
            // 
            // panel_Heat
            // 
            this.panel_Heat.Controls.Add(this.label6);
            this.panel_Heat.Controls.Add(this.cmbTempature);
            this.panel_Heat.Controls.Add(this.label14);
            this.panel_Heat.Controls.Add(this.label7);
            this.panel_Heat.Controls.Add(this.dt_Heatingtime);
            this.panel_Heat.Controls.Add(this.label15);
            this.panel_Heat.Location = new System.Drawing.Point(109, 96);
            this.panel_Heat.Name = "panel_Heat";
            this.panel_Heat.Size = new System.Drawing.Size(554, 36);
            this.panel_Heat.TabIndex = 55;
            this.panel_Heat.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(206, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Select Temperature to Attain :";
            // 
            // cmbTempature
            // 
            this.cmbTempature.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTempature.FormattingEnabled = true;
            this.cmbTempature.Location = new System.Drawing.Point(220, 7);
            this.cmbTempature.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTempature.Name = "cmbTempature";
            this.cmbTempature.Size = new System.Drawing.Size(57, 23);
            this.cmbTempature.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(280, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 17);
            this.label14.TabIndex = 36;
            this.label14.Text = "°C";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(312, 7);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Incubation Time :";
            // 
            // dt_Heatingtime
            // 
            this.dt_Heatingtime.CustomFormat = "mm:ss";
            this.dt_Heatingtime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_Heatingtime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_Heatingtime.Location = new System.Drawing.Point(436, 7);
            this.dt_Heatingtime.Name = "dt_Heatingtime";
            this.dt_Heatingtime.ShowUpDown = true;
            this.dt_Heatingtime.Size = new System.Drawing.Size(60, 23);
            this.dt_Heatingtime.TabIndex = 34;
            this.dt_Heatingtime.Value = new System.DateTime(2025, 4, 24, 0, 0, 0, 0);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(497, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 17);
            this.label15.TabIndex = 37;
            this.label15.Text = "Min:Sec";
            // 
            // chkHeat
            // 
            this.chkHeat.AutoSize = true;
            this.chkHeat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHeat.Location = new System.Drawing.Point(38, 98);
            this.chkHeat.Margin = new System.Windows.Forms.Padding(4);
            this.chkHeat.Name = "chkHeat";
            this.chkHeat.Size = new System.Drawing.Size(69, 21);
            this.chkHeat.TabIndex = 24;
            this.chkHeat.Text = "Baking";
            this.chkHeat.UseVisualStyleBackColor = true;
            this.chkHeat.CheckedChanged += new System.EventHandler(this.chkHeat_CheckedChanged);
            // 
            // panel_protocol
            // 
            this.panel_protocol.Controls.Add(this.chk_Detele);
            this.panel_protocol.Controls.Add(this.lbl_CloneName);
            this.panel_protocol.Controls.Add(this.txt_CloneName);
            this.panel_protocol.Controls.Add(this.chk_Clone);
            this.panel_protocol.Controls.Add(this.label10);
            this.panel_protocol.Controls.Add(this.btn_loadDetails);
            this.panel_protocol.Controls.Add(this.chkHeat);
            this.panel_protocol.Controls.Add(this.txt_describe);
            this.panel_protocol.Controls.Add(this.label2);
            this.panel_protocol.Controls.Add(this.cmbProtocol);
            this.panel_protocol.Controls.Add(this.label3);
            this.panel_protocol.Controls.Add(this.txtProtoShortName);
            this.panel_protocol.Controls.Add(this.label5);
            this.panel_protocol.Controls.Add(this.rdnUser);
            this.panel_protocol.Controls.Add(this.rdnFactory);
            this.panel_protocol.Controls.Add(this.panel_Heat);
            this.panel_protocol.Controls.Add(this.chkAgitation);
            this.panel_protocol.Controls.Add(this.label4);
            this.panel_protocol.Controls.Add(this.cmbNofJars);
            this.panel_protocol.Location = new System.Drawing.Point(0, 31);
            this.panel_protocol.Name = "panel_protocol";
            this.panel_protocol.Size = new System.Drawing.Size(674, 229);
            this.panel_protocol.TabIndex = 54;
            // 
            // lbl_CloneName
            // 
            this.lbl_CloneName.AutoSize = true;
            this.lbl_CloneName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CloneName.Location = new System.Drawing.Point(120, 142);
            this.lbl_CloneName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_CloneName.Name = "lbl_CloneName";
            this.lbl_CloneName.Size = new System.Drawing.Size(136, 20);
            this.lbl_CloneName.TabIndex = 65;
            this.lbl_CloneName.Text = "Enter Clone Name :";
            // 
            // txt_CloneName
            // 
            this.txt_CloneName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CloneName.Location = new System.Drawing.Point(260, 143);
            this.txt_CloneName.Margin = new System.Windows.Forms.Padding(4);
            this.txt_CloneName.Name = "txt_CloneName";
            this.txt_CloneName.Size = new System.Drawing.Size(392, 23);
            this.txt_CloneName.TabIndex = 66;
            // 
            // chk_Clone
            // 
            this.chk_Clone.AutoSize = true;
            this.chk_Clone.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Clone.Location = new System.Drawing.Point(37, 142);
            this.chk_Clone.Margin = new System.Windows.Forms.Padding(4);
            this.chk_Clone.Name = "chk_Clone";
            this.chk_Clone.Size = new System.Drawing.Size(85, 21);
            this.chk_Clone.TabIndex = 64;
            this.chk_Clone.Text = "To Clone ";
            this.chk_Clone.UseVisualStyleBackColor = true;
            this.chk_Clone.CheckedChanged += new System.EventHandler(this.chk_Clone_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(31, 182);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 20);
            this.label10.TabIndex = 63;
            this.label10.Text = "Description :";
            // 
            // btn_loadDetails
            // 
            this.btn_loadDetails.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_loadDetails.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_loadDetails.Location = new System.Drawing.Point(557, 173);
            this.btn_loadDetails.Name = "btn_loadDetails";
            this.btn_loadDetails.Size = new System.Drawing.Size(104, 48);
            this.btn_loadDetails.TabIndex = 60;
            this.btn_loadDetails.Text = "Load Details";
            this.btn_loadDetails.UseVisualStyleBackColor = true;
            this.btn_loadDetails.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_describe
            // 
            this.txt_describe.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_describe.Location = new System.Drawing.Point(129, 173);
            this.txt_describe.Multiline = true;
            this.txt_describe.Name = "txt_describe";
            this.txt_describe.Size = new System.Drawing.Size(405, 50);
            this.txt_describe.TabIndex = 62;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter / Select Protocol Name :";
            // 
            // cmbProtocol
            // 
            this.cmbProtocol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProtocol.FormattingEnabled = true;
            this.cmbProtocol.Location = new System.Drawing.Point(251, 8);
            this.cmbProtocol.Margin = new System.Windows.Forms.Padding(4);
            this.cmbProtocol.Name = "cmbProtocol";
            this.cmbProtocol.Size = new System.Drawing.Size(410, 23);
            this.cmbProtocol.TabIndex = 14;
            this.cmbProtocol.SelectedIndexChanged += new System.EventHandler(this.cmbProtocol_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Enter Short Name :";
            // 
            // txtProtoShortName
            // 
            this.txtProtoShortName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProtoShortName.Location = new System.Drawing.Point(176, 38);
            this.txtProtoShortName.Margin = new System.Windows.Forms.Padding(4);
            this.txtProtoShortName.Name = "txtProtoShortName";
            this.txtProtoShortName.Size = new System.Drawing.Size(112, 23);
            this.txtProtoShortName.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(306, 40);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Select Protocol Type :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(212, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Select No. Of Jars :";
            // 
            // cmbNofJars
            // 
            this.cmbNofJars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNofJars.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNofJars.FormattingEnabled = true;
            this.cmbNofJars.Location = new System.Drawing.Point(351, 68);
            this.cmbNofJars.Margin = new System.Windows.Forms.Padding(4);
            this.cmbNofJars.Name = "cmbNofJars";
            this.cmbNofJars.Size = new System.Drawing.Size(72, 23);
            this.cmbNofJars.TabIndex = 15;
            this.cmbNofJars.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbNofJars_KeyPress);
            // 
            // genDate
            // 
            this.genDate.Location = new System.Drawing.Point(687, 435);
            this.genDate.Name = "genDate";
            this.genDate.Size = new System.Drawing.Size(22, 20);
            this.genDate.TabIndex = 61;
            this.genDate.Visible = false;
            // 
            // dgv_Detail
            // 
            this.dgv_Detail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Detail.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Detail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sln,
            this.protoName,
            this.JarName,
            this.RegName,
            this.ShortName,
            this.IncubTime,
            this.Priority,
            this.Noofdips});
            this.dgv_Detail.Location = new System.Drawing.Point(4, 367);
            this.dgv_Detail.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Detail.Name = "dgv_Detail";
            this.dgv_Detail.Size = new System.Drawing.Size(670, 136);
            this.dgv_Detail.TabIndex = 52;
            this.dgv_Detail.DoubleClick += new System.EventHandler(this.dgv_Detail_DoubleClick);
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
            // ShortName
            // 
            this.ShortName.HeaderText = "Short Name";
            this.ShortName.Name = "ShortName";
            // 
            // IncubTime
            // 
            this.IncubTime.HeaderText = "Incubation Time";
            this.IncubTime.Name = "IncubTime";
            // 
            // Priority
            // 
            this.Priority.HeaderText = "Priority";
            this.Priority.Name = "Priority";
            this.Priority.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Priority.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Noofdips
            // 
            this.Noofdips.HeaderText = "No of Dips";
            this.Noofdips.Name = "Noofdips";
            // 
            // btn_ExportPdf
            // 
            this.btn_ExportPdf.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ExportPdf.Location = new System.Drawing.Point(1165, 136);
            this.btn_ExportPdf.Name = "btn_ExportPdf";
            this.btn_ExportPdf.Size = new System.Drawing.Size(75, 25);
            this.btn_ExportPdf.TabIndex = 62;
            this.btn_ExportPdf.Text = "Export to PDF";
            this.btn_ExportPdf.UseVisualStyleBackColor = true;
            this.btn_ExportPdf.Visible = false;
            this.btn_ExportPdf.Click += new System.EventHandler(this.btn_ExportPdf_Click);
            // 
            // btn_Print
            // 
            this.btn_Print.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Print.Location = new System.Drawing.Point(1165, 104);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(75, 25);
            this.btn_Print.TabIndex = 63;
            this.btn_Print.Text = "Print";
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Visible = false;
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
            this.label1.Size = new System.Drawing.Size(1268, 30);
            this.label1.TabIndex = 64;
            this.label1.Text = "Protocol Configuration";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button21);
            this.panel1.Controls.Add(this.button22);
            this.panel1.Controls.Add(this.button23);
            this.panel1.Controls.Add(this.button24);
            this.panel1.Location = new System.Drawing.Point(1009, 206);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 81);
            this.panel1.TabIndex = 65;
            this.panel1.Visible = false;
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.button21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button21.FlatAppearance.BorderSize = 0;
            this.button21.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(215)))));
            this.button21.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(215)))));
            this.button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button21.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button21.ForeColor = System.Drawing.Color.White;
            this.button21.Location = new System.Drawing.Point(298, 369);
            this.button21.Margin = new System.Windows.Forms.Padding(2);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(10, 10);
            this.button21.TabIndex = 19;
            this.button21.Text = "R";
            this.button21.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button21.UseVisualStyleBackColor = false;
            this.button21.Visible = false;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // button22
            // 
            this.button22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.button22.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button22.FlatAppearance.BorderSize = 0;
            this.button22.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(215)))));
            this.button22.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(215)))));
            this.button22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button22.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button22.ForeColor = System.Drawing.Color.White;
            this.button22.Location = new System.Drawing.Point(249, 369);
            this.button22.Margin = new System.Windows.Forms.Padding(2);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(10, 10);
            this.button22.TabIndex = 18;
            this.button22.Text = "E";
            this.button22.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button22.UseVisualStyleBackColor = false;
            this.button22.Visible = false;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // button23
            // 
            this.button23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.button23.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button23.FlatAppearance.BorderSize = 0;
            this.button23.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(215)))));
            this.button23.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(215)))));
            this.button23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button23.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button23.ForeColor = System.Drawing.Color.White;
            this.button23.Location = new System.Drawing.Point(199, 369);
            this.button23.Margin = new System.Windows.Forms.Padding(2);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(10, 10);
            this.button23.TabIndex = 17;
            this.button23.Text = "W";
            this.button23.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button23.UseVisualStyleBackColor = false;
            this.button23.Visible = false;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // button24
            // 
            this.button24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.button24.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button24.FlatAppearance.BorderSize = 0;
            this.button24.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(215)))));
            this.button24.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(215)))));
            this.button24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button24.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button24.ForeColor = System.Drawing.Color.White;
            this.button24.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button24.Location = new System.Drawing.Point(149, 369);
            this.button24.Margin = new System.Windows.Forms.Padding(2);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(10, 10);
            this.button24.TabIndex = 16;
            this.button24.Text = "Q\r\n   ";
            this.button24.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button24.UseVisualStyleBackColor = false;
            this.button24.Visible = false;
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // chk_vk
            // 
            this.chk_vk.AutoSize = true;
            this.chk_vk.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_vk.ForeColor = System.Drawing.Color.Black;
            this.chk_vk.Location = new System.Drawing.Point(38, 507);
            this.chk_vk.Name = "chk_vk";
            this.chk_vk.Size = new System.Drawing.Size(134, 20);
            this.chk_vk.TabIndex = 66;
            this.chk_vk.Text = "Virtual Keyboard";
            this.chk_vk.UseVisualStyleBackColor = true;
            this.chk_vk.CheckedChanged += new System.EventHandler(this.chk_vk_CheckedChanged);
            // 
            // txt_protocolName
            // 
            this.txt_protocolName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_protocolName.Location = new System.Drawing.Point(1009, 322);
            this.txt_protocolName.Margin = new System.Windows.Forms.Padding(4);
            this.txt_protocolName.Name = "txt_protocolName";
            this.txt_protocolName.Size = new System.Drawing.Size(162, 23);
            this.txt_protocolName.TabIndex = 67;
            this.txt_protocolName.Visible = false;
            // 
            // chk_Detele
            // 
            this.chk_Detele.AutoSize = true;
            this.chk_Detele.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Detele.Location = new System.Drawing.Point(525, 69);
            this.chk_Detele.Margin = new System.Windows.Forms.Padding(4);
            this.chk_Detele.Name = "chk_Detele";
            this.chk_Detele.Size = new System.Drawing.Size(127, 21);
            this.chk_Detele.TabIndex = 67;
            this.chk_Detele.Text = "Delete Protocol ";
            this.chk_Detele.UseVisualStyleBackColor = true;
            this.chk_Detele.CheckedChanged += new System.EventHandler(this.chk_Detele_CheckedChanged);
            // 
            // Form_ProtocolConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1268, 531);
            this.Controls.Add(this.txt_protocolName);
            this.Controls.Add(this.chk_vk);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.btn_ExportPdf);
            this.Controls.Add(this.genDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel_Buttons);
            this.Controls.Add(this.panel_reagent);
            this.Controls.Add(this.panel_protocol);
            this.Controls.Add(this.dgv_Detail);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_ProtocolConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Protocols Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_ProtocolConfig_FormClosing);
            this.Load += new System.EventHandler(this.Form9_Load);
            this.panel_Buttons.ResumeLayout(false);
            this.panel_reagent.ResumeLayout(false);
            this.panel_reagent.PerformLayout();
            this.pnl_Wsh.ResumeLayout(false);
            this.pnl_Wsh.PerformLayout();
            this.panel_Heat.ResumeLayout(false);
            this.panel_Heat.PerformLayout();
            this.panel_protocol.ResumeLayout(false);
            this.panel_protocol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Detail)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdnUser;
        private System.Windows.Forms.RadioButton rdnFactory;
        private System.Windows.Forms.CheckBox chkAgitation;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btn_LoadGrid;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dt_Washtime;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel_Buttons;
        private System.Windows.Forms.CheckBox chk_WashRequired;
        private System.Windows.Forms.Panel panel_reagent;
        private System.Windows.Forms.Panel panel_Heat;
        private System.Windows.Forms.CheckBox chkHeat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTempature;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dt_Heatingtime;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel_protocol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbProtocol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProtoShortName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbNofJars;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_Detail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbJarName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbReagent;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtReagentShortName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dt_incubationtime;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbNofDips;
        private System.Windows.Forms.Button btn_loadDetails;
        private System.Windows.Forms.Panel pnl_Wsh;
        private System.Windows.Forms.DateTimePicker genDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_describe;
        private System.Windows.Forms.Button btn_ExportPdf;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.CheckBox chk_vk;
        private System.Windows.Forms.DataGridViewTextBoxColumn sln;
        private System.Windows.Forms.DataGridViewTextBoxColumn protoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn JarName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShortName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IncubTime;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn Noofdips;
        private System.Windows.Forms.TextBox txt_protocolName;
        private System.Windows.Forms.Label lbl_CloneName;
        private System.Windows.Forms.TextBox txt_CloneName;
        private System.Windows.Forms.CheckBox chk_Clone;
        private System.Windows.Forms.Button btn_AddNewRecord;
        private System.Windows.Forms.CheckBox chk_Detele;
    }
}