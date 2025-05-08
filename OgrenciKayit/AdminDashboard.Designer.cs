namespace OgrenciKayit
{
    partial class AdminDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed.</param>
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
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblCurrentSection = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.panelSidebarInfo = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnCities = new System.Windows.Forms.Button();
            this.btnDepartments = new System.Windows.Forms.Button();
            this.btnSchools = new System.Windows.Forms.Button();
            this.btnStudents = new System.Windows.Forms.Button();
            this.lblAppName = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelStudents = new System.Windows.Forms.Panel();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.txtStudentSearch = new System.Windows.Forms.TextBox();
            this.btnStudentSearch = new System.Windows.Forms.Button();
            this.btnStudentAdd = new System.Windows.Forms.Button();
            this.btnStudentEdit = new System.Windows.Forms.Button();
            this.btnStudentDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelSchools = new System.Windows.Forms.Panel();
            this.dgvSchools = new System.Windows.Forms.DataGridView();
            this.btnSchoolAdd = new System.Windows.Forms.Button();
            this.btnSchoolEdit = new System.Windows.Forms.Button();
            this.btnSchoolDelete = new System.Windows.Forms.Button();
            this.txtSchoolSearch = new System.Windows.Forms.TextBox();
            this.btnSchoolSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panelDepartments = new System.Windows.Forms.Panel();
            this.dgvDepartments = new System.Windows.Forms.DataGridView();
            this.btnDepartmentAdd = new System.Windows.Forms.Button();
            this.btnDepartmentEdit = new System.Windows.Forms.Button();
            this.btnDepartmentDelete = new System.Windows.Forms.Button();
            this.txtDepartmentSearch = new System.Windows.Forms.TextBox();
            this.btnDepartmentSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panelCities = new System.Windows.Forms.Panel();
            this.dgvCities = new System.Windows.Forms.DataGridView();
            this.btnCityAdd = new System.Windows.Forms.Button();
            this.btnCityEdit = new System.Windows.Forms.Button();
            this.btnCityDelete = new System.Windows.Forms.Button();
            this.txtCitySearch = new System.Windows.Forms.TextBox();
            this.btnCitySearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelStudents = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelDepartments = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSchools = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelCities = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            this.panelSidebarInfo.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.panelSchools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchools)).BeginInit();
            this.panelDepartments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).BeginInit();
            this.panelCities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCities)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.panelTop.Controls.Add(this.lblCurrentSection);
            this.panelTop.Controls.Add(this.btnMinimize);
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(900, 40);
            this.panelTop.TabIndex = 1;
            // 
            // lblCurrentSection
            // 
            this.lblCurrentSection.AutoSize = true;
            this.lblCurrentSection.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCurrentSection.ForeColor = System.Drawing.Color.White;
            this.lblCurrentSection.Location = new System.Drawing.Point(272, 9);
            this.lblCurrentSection.Name = "lblCurrentSection";
            this.lblCurrentSection.Size = new System.Drawing.Size(94, 21);
            this.lblCurrentSection.TabIndex = 3;
            this.lblCurrentSection.Text = "Öðrenciler";
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(824, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(40, 40);
            this.btnMinimize.TabIndex = 2;
            this.btnMinimize.Text = "_";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(860, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(172, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Öðrenci Kayýt Sistemi";
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = ThemeColors.PrimaryDark;
            this.panelSidebar.Controls.Add(this.panelSidebarInfo);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.btnCities);
            this.panelSidebar.Controls.Add(this.btnDepartments);
            this.panelSidebar.Controls.Add(this.btnSchools);
            this.panelSidebar.Controls.Add(this.btnStudents);
            this.panelSidebar.Controls.Add(this.lblAppName);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 40);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(220, 560);
            this.panelSidebar.TabIndex = 2;
            // 
            // panelSidebarInfo
            // 
            this.panelSidebarInfo.BackColor = System.Drawing.Color.Transparent;
            this.panelSidebarInfo.Controls.Add(this.lblWelcome);
            this.panelSidebarInfo.Controls.Add(this.lblStatus);
            this.panelSidebarInfo.Controls.Add(this.lblDate);
            this.panelSidebarInfo.Location = new System.Drawing.Point(0, 350);
            this.panelSidebarInfo.Name = "panelSidebarInfo";
            this.panelSidebarInfo.Size = new System.Drawing.Size(220, 90);
            this.panelSidebarInfo.TabIndex = 100;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Location = new System.Drawing.Point(16, 8);
            this.lblWelcome.Size = new System.Drawing.Size(180, 24);
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblWelcome.Text = "Hoþ Geldiniz, Admin!";
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(33, 150, 243); // Modern mavi
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(16, 36);
            this.lblStatus.Size = new System.Drawing.Size(180, 20);
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatus.Text = "Durum: Baðlý";
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(76, 175, 80);   // Modern yeþil
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(16, 60);
            this.lblDate.Size = new System.Drawing.Size(180, 20);
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDate.Text = "01.01.2023";
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(120, 144, 156);   // Modern gri
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(10, 450);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(200, 40);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "ÇIKIÞ YAP";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnCities
            // 
            this.btnCities.FlatAppearance.BorderSize = 0;
            this.btnCities.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCities.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCities.ForeColor = System.Drawing.Color.White;
            this.btnCities.Location = new System.Drawing.Point(10, 214);
            this.btnCities.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.btnCities.Name = "btnCities";
            this.btnCities.Size = new System.Drawing.Size(200, 48);
            this.btnCities.TabIndex = 4;
            this.btnCities.Text = "Þehirler";
            this.btnCities.UseVisualStyleBackColor = true;
            this.btnCities.Click += new System.EventHandler(this.btnCities_Click);
            // 
            // btnDepartments
            // 
            this.btnDepartments.FlatAppearance.BorderSize = 0;
            this.btnDepartments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepartments.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnDepartments.ForeColor = System.Drawing.Color.White;
            this.btnDepartments.Location = new System.Drawing.Point(10, 156);
            this.btnDepartments.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.btnDepartments.Name = "btnDepartments";
            this.btnDepartments.Size = new System.Drawing.Size(200, 48);
            this.btnDepartments.TabIndex = 3;
            this.btnDepartments.Text = "Bölümler";
            this.btnDepartments.UseVisualStyleBackColor = true;
            this.btnDepartments.Click += new System.EventHandler(this.btnDepartments_Click);
            // 
            // btnSchools
            // 
            this.btnSchools.FlatAppearance.BorderSize = 0;
            this.btnSchools.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSchools.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSchools.ForeColor = System.Drawing.Color.White;
            this.btnSchools.Location = new System.Drawing.Point(10, 98);
            this.btnSchools.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.btnSchools.Name = "btnSchools";
            this.btnSchools.Size = new System.Drawing.Size(200, 48);
            this.btnSchools.TabIndex = 2;
            this.btnSchools.Text = "Okullar";
            this.btnSchools.UseVisualStyleBackColor = true;
            this.btnSchools.Click += new System.EventHandler(this.btnSchools_Click);
            // 
            // btnStudents
            // 
            this.btnStudents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.btnStudents.FlatAppearance.BorderSize = 0;
            this.btnStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudents.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnStudents.ForeColor = System.Drawing.Color.White;
            this.btnStudents.Location = new System.Drawing.Point(10, 40);
            this.btnStudents.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.Size = new System.Drawing.Size(200, 48);
            this.btnStudents.TabIndex = 1;
            this.btnStudents.Text = "Öðrenciler";
            this.btnStudents.UseVisualStyleBackColor = false;
            this.btnStudents.Click += new System.EventHandler(this.btnStudents_Click);
            // 
            // lblAppName
            // 
            this.lblAppName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.lblAppName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.Location = new System.Drawing.Point(0, 0);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblAppName.Size = new System.Drawing.Size(220, 60);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "Admin Panel";
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContent.Controls.Add(this.btnExportExcel);
            this.panelContent.Controls.Add(this.panelCities);
            this.panelContent.Controls.Add(this.panelDepartments);
            this.panelContent.Controls.Add(this.panelSchools);
            this.panelContent.Controls.Add(this.panelStudents);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(220, 40);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelContent.Size = new System.Drawing.Size(680, 560);
            this.panelContent.TabIndex = 3;
            // 
            // panelStudents
            // 
            this.panelStudents.Controls.Add(this.txtStudentSearch);
            this.panelStudents.Controls.Add(this.btnStudentSearch);
            this.panelStudents.Controls.Add(this.dgvStudents);
            this.panelStudents.Controls.Add(this.btnStudentAdd);
            this.panelStudents.Controls.Add(this.btnStudentEdit);
            this.panelStudents.Controls.Add(this.btnStudentDelete);
            this.panelStudents.Controls.Add(this.label1);
            this.panelStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStudents.Location = new System.Drawing.Point(20, 20);
            this.panelStudents.Name = "panelStudents";
            this.panelStudents.Size = new System.Drawing.Size(640, 520);
            this.panelStudents.TabIndex = 0;
            // 
            // dgvStudents
            // 
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudents.BackgroundColor = System.Drawing.Color.White;
            this.dgvStudents.Location = new System.Drawing.Point(22, 55);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.ReadOnly = true;
            this.dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudents.Size = new System.Drawing.Size(566, 400);
            this.dgvStudents.TabIndex = 2;
            // 
            // txtStudentSearch
            // 
            this.txtStudentSearch.Location = new System.Drawing.Point(22, 20);
            this.txtStudentSearch.Name = "txtStudentSearch";
            this.txtStudentSearch.Size = new System.Drawing.Size(180, 25);
            this.txtStudentSearch.TabIndex = 10;
            // 
            // btnStudentSearch
            // 
            this.btnStudentSearch.Location = new System.Drawing.Point(210, 20);
            this.btnStudentSearch.Name = "btnStudentSearch";
            this.btnStudentSearch.Size = new System.Drawing.Size(60, 25);
            this.btnStudentSearch.TabIndex = 11;
            this.btnStudentSearch.Text = "Ara";
            this.btnStudentSearch.UseVisualStyleBackColor = true;
            this.btnStudentSearch.Click += new System.EventHandler(this.btnStudentSearch_Click);
            // 
            // btnStudentAdd
            // 
            this.btnStudentAdd.Location = new System.Drawing.Point(22, 470);
            this.btnStudentAdd.Name = "btnStudentAdd";
            this.btnStudentAdd.Size = new System.Drawing.Size(90, 32);
            this.btnStudentAdd.TabIndex = 3;
            this.btnStudentAdd.Text = "Ekle";
            this.btnStudentAdd.UseVisualStyleBackColor = true;
            this.btnStudentAdd.Click += new System.EventHandler(this.btnStudentAdd_Click);
            // 
            // btnStudentEdit
            // 
            this.btnStudentEdit.Location = new System.Drawing.Point(122, 470);
            this.btnStudentEdit.Name = "btnStudentEdit";
            this.btnStudentEdit.Size = new System.Drawing.Size(90, 32);
            this.btnStudentEdit.TabIndex = 4;
            this.btnStudentEdit.Text = "Düzenle";
            this.btnStudentEdit.UseVisualStyleBackColor = true;
            this.btnStudentEdit.Click += new System.EventHandler(this.btnStudentEdit_Click);
            // 
            // btnStudentDelete
            // 
            this.btnStudentDelete.Location = new System.Drawing.Point(222, 470);
            this.btnStudentDelete.Name = "btnStudentDelete";
            this.btnStudentDelete.Size = new System.Drawing.Size(90, 32);
            this.btnStudentDelete.TabIndex = 5;
            this.btnStudentDelete.Text = "Sil";
            this.btnStudentDelete.UseVisualStyleBackColor = true;
            this.btnStudentDelete.Click += new System.EventHandler(this.btnStudentDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Öðrenciler";
            // 
            // panelSchools
            // 
            this.panelSchools.Controls.Add(this.dgvSchools);
            this.panelSchools.Controls.Add(this.btnSchoolAdd);
            this.panelSchools.Controls.Add(this.btnSchoolEdit);
            this.panelSchools.Controls.Add(this.btnSchoolDelete);
            this.panelSchools.Controls.Add(this.txtSchoolSearch);
            this.panelSchools.Controls.Add(this.btnSchoolSearch);
            this.panelSchools.Controls.Add(this.label2);
            this.panelSchools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSchools.Location = new System.Drawing.Point(20, 20);
            this.panelSchools.Name = "panelSchools";
            this.panelSchools.Size = new System.Drawing.Size(640, 520);
            this.panelSchools.TabIndex = 1;
            this.panelSchools.Visible = false;
            // 
            // dgvSchools
            // 
            this.dgvSchools.AllowUserToAddRows = false;
            this.dgvSchools.AllowUserToDeleteRows = false;
            this.dgvSchools.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSchools.BackgroundColor = System.Drawing.Color.White;
            this.dgvSchools.Location = new System.Drawing.Point(22, 55);
            this.dgvSchools.Name = "dgvSchools";
            this.dgvSchools.ReadOnly = true;
            this.dgvSchools.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSchools.Size = new System.Drawing.Size(566, 400);
            this.dgvSchools.TabIndex = 2;
            // 
            // btnSchoolAdd
            // 
            this.btnSchoolAdd.Location = new System.Drawing.Point(22, 470);
            this.btnSchoolAdd.Name = "btnSchoolAdd";
            this.btnSchoolAdd.Size = new System.Drawing.Size(90, 32);
            this.btnSchoolAdd.TabIndex = 3;
            this.btnSchoolAdd.Text = "Ekle";
            this.btnSchoolAdd.UseVisualStyleBackColor = true;
            this.btnSchoolAdd.Click += new System.EventHandler(this.btnSchoolAdd_Click);
            // 
            // btnSchoolEdit
            // 
            this.btnSchoolEdit.Location = new System.Drawing.Point(122, 470);
            this.btnSchoolEdit.Name = "btnSchoolEdit";
            this.btnSchoolEdit.Size = new System.Drawing.Size(90, 32);
            this.btnSchoolEdit.TabIndex = 4;
            this.btnSchoolEdit.Text = "Düzenle";
            this.btnSchoolEdit.UseVisualStyleBackColor = true;
            this.btnSchoolEdit.Click += new System.EventHandler(this.btnSchoolEdit_Click);
            // 
            // btnSchoolDelete
            // 
            this.btnSchoolDelete.Location = new System.Drawing.Point(222, 470);
            this.btnSchoolDelete.Name = "btnSchoolDelete";
            this.btnSchoolDelete.Size = new System.Drawing.Size(90, 32);
            this.btnSchoolDelete.TabIndex = 5;
            this.btnSchoolDelete.Text = "Sil";
            this.btnSchoolDelete.UseVisualStyleBackColor = true;
            this.btnSchoolDelete.Click += new System.EventHandler(this.btnSchoolDelete_Click);
            // 
            // txtSchoolSearch
            // 
            this.txtSchoolSearch.Location = new System.Drawing.Point(22, 20);
            this.txtSchoolSearch.Name = "txtSchoolSearch";
            this.txtSchoolSearch.Size = new System.Drawing.Size(180, 25);
            this.txtSchoolSearch.TabIndex = 10;
            // 
            // btnSchoolSearch
            // 
            this.btnSchoolSearch.Location = new System.Drawing.Point(210, 20);
            this.btnSchoolSearch.Name = "btnSchoolSearch";
            this.btnSchoolSearch.Size = new System.Drawing.Size(60, 25);
            this.btnSchoolSearch.TabIndex = 11;
            this.btnSchoolSearch.Text = "Ara";
            this.btnSchoolSearch.UseVisualStyleBackColor = true;
            this.btnSchoolSearch.Click += new System.EventHandler(this.btnSchoolSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(18, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Okullar";
            // 
            // panelDepartments
            // 
            this.panelDepartments.Controls.Add(this.dgvDepartments);
            this.panelDepartments.Controls.Add(this.btnDepartmentAdd);
            this.panelDepartments.Controls.Add(this.btnDepartmentEdit);
            this.panelDepartments.Controls.Add(this.btnDepartmentDelete);
            this.panelDepartments.Controls.Add(this.txtDepartmentSearch);
            this.panelDepartments.Controls.Add(this.btnDepartmentSearch);
            this.panelDepartments.Controls.Add(this.label3);
            this.panelDepartments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDepartments.Location = new System.Drawing.Point(20, 20);
            this.panelDepartments.Name = "panelDepartments";
            this.panelDepartments.Size = new System.Drawing.Size(640, 520);
            this.panelDepartments.TabIndex = 2;
            this.panelDepartments.Visible = false;
            // 
            // dgvDepartments
            // 
            this.dgvDepartments.AllowUserToAddRows = false;
            this.dgvDepartments.AllowUserToDeleteRows = false;
            this.dgvDepartments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDepartments.BackgroundColor = System.Drawing.Color.White;
            this.dgvDepartments.Location = new System.Drawing.Point(22, 55);
            this.dgvDepartments.Name = "dgvDepartments";
            this.dgvDepartments.ReadOnly = true;
            this.dgvDepartments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepartments.Size = new System.Drawing.Size(566, 400);
            this.dgvDepartments.TabIndex = 2;
            // 
            // btnDepartmentAdd
            // 
            this.btnDepartmentAdd.Location = new System.Drawing.Point(22, 470);
            this.btnDepartmentAdd.Name = "btnDepartmentAdd";
            this.btnDepartmentAdd.Size = new System.Drawing.Size(90, 32);
            this.btnDepartmentAdd.TabIndex = 3;
            this.btnDepartmentAdd.Text = "Ekle";
            this.btnDepartmentAdd.UseVisualStyleBackColor = true;
            this.btnDepartmentAdd.Click += new System.EventHandler(this.btnDepartmentAdd_Click);
            // 
            // btnDepartmentEdit
            // 
            this.btnDepartmentEdit.Location = new System.Drawing.Point(122, 470);
            this.btnDepartmentEdit.Name = "btnDepartmentEdit";
            this.btnDepartmentEdit.Size = new System.Drawing.Size(90, 32);
            this.btnDepartmentEdit.TabIndex = 4;
            this.btnDepartmentEdit.Text = "Düzenle";
            this.btnDepartmentEdit.UseVisualStyleBackColor = true;
            this.btnDepartmentEdit.Click += new System.EventHandler(this.btnDepartmentEdit_Click);
            // 
            // btnDepartmentDelete
            // 
            this.btnDepartmentDelete.Location = new System.Drawing.Point(222, 470);
            this.btnDepartmentDelete.Name = "btnDepartmentDelete";
            this.btnDepartmentDelete.Size = new System.Drawing.Size(90, 32);
            this.btnDepartmentDelete.TabIndex = 5;
            this.btnDepartmentDelete.Text = "Sil";
            this.btnDepartmentDelete.UseVisualStyleBackColor = true;
            this.btnDepartmentDelete.Click += new System.EventHandler(this.btnDepartmentDelete_Click);
            // 
            // txtDepartmentSearch
            // 
            this.txtDepartmentSearch.Location = new System.Drawing.Point(22, 20);
            this.txtDepartmentSearch.Name = "txtDepartmentSearch";
            this.txtDepartmentSearch.Size = new System.Drawing.Size(180, 25);
            this.txtDepartmentSearch.TabIndex = 10;
            // 
            // btnDepartmentSearch
            // 
            this.btnDepartmentSearch.Location = new System.Drawing.Point(210, 20);
            this.btnDepartmentSearch.Name = "btnDepartmentSearch";
            this.btnDepartmentSearch.Size = new System.Drawing.Size(60, 25);
            this.btnDepartmentSearch.TabIndex = 11;
            this.btnDepartmentSearch.Text = "Ara";
            this.btnDepartmentSearch.UseVisualStyleBackColor = true;
            this.btnDepartmentSearch.Click += new System.EventHandler(this.btnDepartmentSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(18, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Bölümler";
            // 
            // panelCities
            // 
            this.panelCities.Controls.Add(this.dgvCities);
            this.panelCities.Controls.Add(this.btnCityAdd);
            this.panelCities.Controls.Add(this.btnCityEdit);
            this.panelCities.Controls.Add(this.btnCityDelete);
            this.panelCities.Controls.Add(this.txtCitySearch);
            this.panelCities.Controls.Add(this.btnCitySearch);
            this.panelCities.Controls.Add(this.label4);
            this.panelCities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCities.Location = new System.Drawing.Point(20, 20);
            this.panelCities.Name = "panelCities";
            this.panelCities.Size = new System.Drawing.Size(640, 520);
            this.panelCities.TabIndex = 3;
            this.panelCities.Visible = false;
            // 
            // dgvCities
            // 
            this.dgvCities.AllowUserToAddRows = false;
            this.dgvCities.AllowUserToDeleteRows = false;
            this.dgvCities.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCities.BackgroundColor = System.Drawing.Color.White;
            this.dgvCities.Location = new System.Drawing.Point(22, 55);
            this.dgvCities.Name = "dgvCities";
            this.dgvCities.ReadOnly = true;
            this.dgvCities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCities.Size = new System.Drawing.Size(566, 400);
            this.dgvCities.TabIndex = 2;
            // 
            // btnCityAdd
            // 
            this.btnCityAdd.Location = new System.Drawing.Point(22, 470);
            this.btnCityAdd.Name = "btnCityAdd";
            this.btnCityAdd.Size = new System.Drawing.Size(90, 32);
            this.btnCityAdd.TabIndex = 3;
            this.btnCityAdd.Text = "Ekle";
            this.btnCityAdd.UseVisualStyleBackColor = true;
            this.btnCityAdd.Click += new System.EventHandler(this.btnCityAdd_Click);
            // 
            // btnCityEdit
            // 
            this.btnCityEdit.Location = new System.Drawing.Point(122, 470);
            this.btnCityEdit.Name = "btnCityEdit";
            this.btnCityEdit.Size = new System.Drawing.Size(90, 32);
            this.btnCityEdit.TabIndex = 4;
            this.btnCityEdit.Text = "Düzenle";
            this.btnCityEdit.UseVisualStyleBackColor = true;
            this.btnCityEdit.Click += new System.EventHandler(this.btnCityEdit_Click);
            // 
            // btnCityDelete
            // 
            this.btnCityDelete.Location = new System.Drawing.Point(222, 470);
            this.btnCityDelete.Name = "btnCityDelete";
            this.btnCityDelete.Size = new System.Drawing.Size(90, 32);
            this.btnCityDelete.TabIndex = 5;
            this.btnCityDelete.Text = "Sil";
            this.btnCityDelete.UseVisualStyleBackColor = true;
            this.btnCityDelete.Click += new System.EventHandler(this.btnCityDelete_Click);
            // 
            // txtCitySearch
            // 
            this.txtCitySearch.Location = new System.Drawing.Point(22, 20);
            this.txtCitySearch.Name = "txtCitySearch";
            this.txtCitySearch.Size = new System.Drawing.Size(180, 25);
            this.txtCitySearch.TabIndex = 10;
            // 
            // btnCitySearch
            // 
            this.btnCitySearch.Location = new System.Drawing.Point(210, 20);
            this.btnCitySearch.Name = "btnCitySearch";
            this.btnCitySearch.Size = new System.Drawing.Size(60, 25);
            this.btnCitySearch.TabIndex = 11;
            this.btnCitySearch.Text = "Ara";
            this.btnCitySearch.UseVisualStyleBackColor = true;
            this.btnCitySearch.Click += new System.EventHandler(this.btnCitySearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(18, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Þehirler";
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStudents,
            this.toolStripStatusLabelDepartments,
            this.toolStripStatusLabelSchools,
            this.toolStripStatusLabelCities});
            this.statusStripMain.Location = new System.Drawing.Point(0, this.Height - 22);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(this.Width, 22);
            this.statusStripMain.TabIndex = 999;
            this.statusStripMain.Text = "statusStripMain";
            // 
            // toolStripStatusLabelStudents
            // 
            this.toolStripStatusLabelStudents.Name = "toolStripStatusLabelStudents";
            this.toolStripStatusLabelStudents.Size = new System.Drawing.Size(120, 17);
            this.toolStripStatusLabelStudents.Text = "Öðrenciler: 0 kayýt";
            // 
            // toolStripStatusLabelDepartments
            // 
            this.toolStripStatusLabelDepartments.Name = "toolStripStatusLabelDepartments";
            this.toolStripStatusLabelDepartments.Size = new System.Drawing.Size(120, 17);
            this.toolStripStatusLabelDepartments.Text = "Bölümler: 0 kayýt";
            // 
            // toolStripStatusLabelSchools
            // 
            this.toolStripStatusLabelSchools.Name = "toolStripStatusLabelSchools";
            this.toolStripStatusLabelSchools.Size = new System.Drawing.Size(120, 17);
            this.toolStripStatusLabelSchools.Text = "Okullar: 0 kayýt";
            // 
            // toolStripStatusLabelCities
            // 
            this.toolStripStatusLabelCities.Name = "toolStripStatusLabelCities";
            this.toolStripStatusLabelCities.Size = new System.Drawing.Size(120, 17);
            this.toolStripStatusLabelCities.Text = "Þehirler: 0 kayýt";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Text = "Excel'e Aktar";
            this.btnExportExcel.Size = new System.Drawing.Size(120, 32);
            this.btnExportExcel.Location = new System.Drawing.Point(540, 20);
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = ThemeColors.Background;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.statusStripMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminDashboard";
            this.Text = "AdminDashboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminDashboard_FormClosed);
            this.Load += new System.EventHandler(this.AdminDashboard_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebarInfo.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelStudents.ResumeLayout(false);
            this.panelStudents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.panelSchools.ResumeLayout(false);
            this.panelSchools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchools)).EndInit();
            this.panelDepartments.ResumeLayout(false);
            this.panelDepartments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).EndInit();
            this.panelCities.ResumeLayout(false);
            this.panelCities.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCities)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            // After initializing controls, apply modern styles
            FormUtils.StyleButton(this.btnLogout);
            FormUtils.StyleButton(this.btnMinimize);
            FormUtils.StyleButton(this.btnClose);
            FormUtils.StyleButton(this.btnCities);
            FormUtils.StyleButton(this.btnDepartments);
            FormUtils.StyleButton(this.btnSchools);
            FormUtils.StyleButton(this.btnStudents);
            FormUtils.StyleButton(this.btnDepartmentAdd);
            FormUtils.StyleButton(this.btnDepartmentEdit);
            FormUtils.StyleButton(this.btnDepartmentDelete);
            FormUtils.StyleButton(this.btnCityAdd);
            FormUtils.StyleButton(this.btnCityEdit);
            FormUtils.StyleButton(this.btnCityDelete);
            FormUtils.StyleButton(this.btnSchoolAdd);
            FormUtils.StyleButton(this.btnSchoolEdit);
            FormUtils.StyleButton(this.btnSchoolDelete);
            FormUtils.StyleButton(this.btnDepartmentSearch);
            FormUtils.StyleButton(this.btnCitySearch);
            FormUtils.StyleButton(this.btnSchoolSearch);
            FormUtils.StyleButton(this.btnStudentSearch);
            FormUtils.StyleButton(this.btnStudentAdd);
            FormUtils.StyleButton(this.btnStudentEdit);
            FormUtils.StyleButton(this.btnStudentDelete);
            FormUtils.StyleButton(this.btnExportExcel);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblCurrentSection;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button btnCities;
        private System.Windows.Forms.Button btnDepartments;
        private System.Windows.Forms.Button btnSchools;
        private System.Windows.Forms.Button btnStudents;
        private System.Windows.Forms.Panel panelSidebarInfo;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelCities;
        private System.Windows.Forms.DataGridView dgvCities;
        private System.Windows.Forms.Button btnCityAdd;
        private System.Windows.Forms.Button btnCityEdit;
        private System.Windows.Forms.Button btnCityDelete;
        private System.Windows.Forms.TextBox txtCitySearch;
        private System.Windows.Forms.Button btnCitySearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelDepartments;
        private System.Windows.Forms.DataGridView dgvDepartments;
        private System.Windows.Forms.Button btnDepartmentAdd;
        private System.Windows.Forms.Button btnDepartmentEdit;
        private System.Windows.Forms.Button btnDepartmentDelete;
        private System.Windows.Forms.TextBox txtDepartmentSearch;
        private System.Windows.Forms.Button btnDepartmentSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelSchools;
        private System.Windows.Forms.DataGridView dgvSchools;
        private System.Windows.Forms.Button btnSchoolAdd;
        private System.Windows.Forms.Button btnSchoolEdit;
        private System.Windows.Forms.Button btnSchoolDelete;
        private System.Windows.Forms.TextBox txtSchoolSearch;
        private System.Windows.Forms.Button btnSchoolSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelStudents;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.TextBox txtStudentSearch;
        private System.Windows.Forms.Button btnStudentSearch;
        private System.Windows.Forms.Button btnStudentAdd;
        private System.Windows.Forms.Button btnStudentEdit;
        private System.Windows.Forms.Button btnStudentDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStudents;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDepartments;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSchools;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCities;
        private System.Windows.Forms.Button btnExportExcel;
    }
}
