using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.IO; // ekle

namespace OgrenciKayit
{
    public partial class AdminDashboard : Form
    {
        // Pagination helpers
        private int studentsPage = 1, studentsPageSize = 50, studentsTotal = 0;
        private int departmentsPage = 1, departmentsPageSize = 50, departmentsTotal = 0;
        private int schoolsPage = 1, schoolsPageSize = 50, schoolsTotal = 0;
        private int citiesPage = 1, citiesPageSize = 50, citiesTotal = 0;

        public AdminDashboard()
        {
            InitializeComponent();

            // Modern style
            FormUtils.StyleForm(this);

            // Modernize navbar buttons
            StyleNavButton(btnStudents);
            StyleNavButton(btnSchools);
            StyleNavButton(btnDepartments);
            StyleNavButton(btnCities);

            // Style other buttons
            FormUtils.StyleButton(btnLogout);
            FormUtils.StyleButton(btnMinimize);
            FormUtils.StyleButton(btnClose);

            // Enable drag for top panel if exists
            if (panelTop != null)
                FormUtils.EnableFormDrag(this, panelTop);
        }
        
        private void StyleNavButton(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font("Segoe UI", 12, FontStyle.Bold); // DÜZELTÝLDÝ: SemiBold yerine Bold ve FontFamily hatasý giderildi
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.Padding = new Padding(32, 0, 0, 0); // Sol padding artýrýldý
            button.Height = 48; // Yükseklik artýrýldý

            // Modern margin ekle (yalnýzca ilk yüklemede, tekrar eklenmez)
            if (button.Margin.Top < 10)
                button.Margin = new Padding(0, 10, 0, 0);

            // Modern arka plan ve hover efektleri
            button.BackColor = ThemeColors.PrimaryDark;
            button.ForeColor = Color.White;
            button.FlatAppearance.MouseOverBackColor = ThemeColors.PrimaryLight;
            button.FlatAppearance.MouseDownBackColor = ThemeColors.PrimaryMedium;

            // Hover efekti
            button.MouseEnter += (s, e) => {
                if (button.BackColor != ThemeColors.PrimaryMedium)
                    button.BackColor = ThemeColors.PrimaryLight;
            };
            button.MouseLeave += (s, e) => {
                if (button.BackColor != ThemeColors.PrimaryMedium)
                    button.BackColor = ThemeColors.PrimaryDark;
            };
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            // Set welcome message
            lblWelcome.Text = "Hoþ Geldiniz, Admin!";
            
            // Update status
            lblStatus.Text = "Durum: Baðlý";

            // Update the date
            lblDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
            
            // Update colors
            panelTop.BackColor = ThemeColors.PrimaryDark;
            panelSidebar.BackColor = ThemeColors.PrimaryDark;
            //panelSidebarInfo.BackColor = ThemeColors.PrimaryMedium;
            panelContent.BackColor = ThemeColors.BackgroundLight;
            
            // Select first tab by default
            ShowSelectedPanel(panelStudents);
            btnStudents.BackColor = ThemeColors.PrimaryMedium;
            lblCurrentSection.Text = "Öðrenciler";

            LoadDepartments();
            LoadCities();
            LoadSchools();
            LoadStudents(); // <-- EKLENDÝ: Öðrenciler grid'i ilk açýlýþta dolu gelsin

            // Attach live search events
            txtDepartmentSearch.TextChanged += txtDepartmentSearch_TextChanged;
            txtCitySearch.TextChanged += txtCitySearch_TextChanged;
            txtSchoolSearch.TextChanged += txtSchoolSearch_TextChanged;
            txtStudentSearch.TextChanged += txtStudentSearch_TextChanged;

            // Modern ve renkli bilgi kutusu metin renkleri
            lblWelcome.ForeColor = Color.FromArgb(33, 150, 243); // Modern mavi
            lblStatus.ForeColor = Color.FromArgb(76, 175, 80);   // Modern yeþil
            lblDate.ForeColor = Color.FromArgb(120, 144, 156);   // Modern gri
        }

        private void AdminDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Hide();
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            ResetNavButtonColors();
            btnStudents.BackColor = ThemeColors.PrimaryMedium;
            ShowSelectedPanel(panelStudents);
            lblCurrentSection.Text = "Öðrenciler";
        }

        private void btnSchools_Click(object sender, EventArgs e)
        {
            ResetNavButtonColors();
            btnSchools.BackColor = ThemeColors.PrimaryMedium;
            ShowSelectedPanel(panelSchools);
            lblCurrentSection.Text = "Okullar";
        }

        private void btnDepartments_Click(object sender, EventArgs e)
        {
            ResetNavButtonColors();
            btnDepartments.BackColor = ThemeColors.PrimaryMedium;
            ShowSelectedPanel(panelDepartments);
            lblCurrentSection.Text = "Bölümler";
        }

        private void btnCities_Click(object sender, EventArgs e)
        {
            ResetNavButtonColors();
            btnCities.BackColor = ThemeColors.PrimaryMedium;
            ShowSelectedPanel(panelCities);
            lblCurrentSection.Text = "Þehirler";
        }
        
        private void ResetNavButtonColors()
        {
            btnStudents.BackColor = ThemeColors.PrimaryDark;
            btnSchools.BackColor = ThemeColors.PrimaryDark;
            btnDepartments.BackColor = ThemeColors.PrimaryDark;
            btnCities.BackColor = ThemeColors.PrimaryDark;
        }

        private void ShowSelectedPanel(Panel selectedPanel)
        {
            // Hide all panels
            panelStudents.Visible = false;
            panelSchools.Visible = false;
            panelDepartments.Visible = false;
            panelCities.Visible = false;

            // Show selected panel
            selectedPanel.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void UpdateStatusStrips()
        {
            toolStripStatusLabelStudents.Text = $"Öðrenciler: {studentsTotal} kayýt";
            toolStripStatusLabelDepartments.Text = $"Bölümler: {departmentsTotal} kayýt";
            toolStripStatusLabelSchools.Text = $"Okullar: {schoolsTotal} kayýt";
            toolStripStatusLabelCities.Text = $"Þehirler: {citiesTotal} kayýt";
        }

        // --- Departments CRUD & Search ---
        private void LoadDepartments(string search = "")
        {
            var result = PaginationHelper.GetDepartmentsPaged(search, departmentsPage, departmentsPageSize, out departmentsTotal);
            dgvDepartments.DataSource = result;
            if (dgvDepartments.Columns.Contains("Name"))
                dgvDepartments.Columns["Name"].HeaderText = "Bölüm Adý";
            if (dgvDepartments.Columns.Contains("Id"))
                dgvDepartments.Columns["Id"].Visible = false;
            UpdateStatusStrips();
            dgvDepartments.ScrollBars = ScrollBars.Both;
        }

        private void btnDepartmentSearch_Click(object sender, EventArgs e)
        {
            LoadDepartments(txtDepartmentSearch.Text.Trim());
        }

        private void txtDepartmentSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDepartments(txtDepartmentSearch.Text.Trim());
        }

        private void btnDepartmentAdd_Click(object sender, EventArgs e)
        {
            using (var frm = new DepartmentEditForm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadDepartments();
            }
        }

        private void btnDepartmentEdit_Click(object sender, EventArgs e)
        {
            if (dgvDepartments.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvDepartments.CurrentRow.Cells["Id"].Value);
            string name = dgvDepartments.CurrentRow.Cells["Name"].Value.ToString();
            using (var frm = new DepartmentEditForm(id, name))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadDepartments();
            }
        }

        private void btnDepartmentDelete_Click(object sender, EventArgs e)
        {
            if (dgvDepartments.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvDepartments.CurrentRow.Cells["Id"].Value);
            if (MessageBox.Show("Silmek istediðinize emin misiniz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DatabaseHelper.DeleteDepartment(id);
                LoadDepartments();
            }
        }

        // --- Cities CRUD & Search ---
        private void LoadCities(string search = "")
        {
            var result = PaginationHelper.GetCitiesPaged(search, citiesPage, citiesPageSize, out citiesTotal);
            dgvCities.DataSource = result;
            if (dgvCities.Columns.Contains("Name"))
                dgvCities.Columns["Name"].HeaderText = "Þehir Adý";
            if (dgvCities.Columns.Contains("Id"))
                dgvCities.Columns["Id"].Visible = false;
            UpdateStatusStrips();
            dgvCities.ScrollBars = ScrollBars.Both;
        }

        private void btnCitySearch_Click(object sender, EventArgs e)
        {
            LoadCities(txtCitySearch.Text.Trim());
        }

        private void txtCitySearch_TextChanged(object sender, EventArgs e)
        {
            LoadCities(txtCitySearch.Text.Trim());
        }

        private void btnCityAdd_Click(object sender, EventArgs e)
        {
            using (var frm = new CityEditForm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadCities();
            }
        }

        private void btnCityEdit_Click(object sender, EventArgs e)
        {
            if (dgvCities.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvCities.CurrentRow.Cells["Id"].Value);
            string name = dgvCities.CurrentRow.Cells["Name"].Value.ToString();
            using (var frm = new CityEditForm(id, name))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadCities();
            }
        }

        private void btnCityDelete_Click(object sender, EventArgs e)
        {
            if (dgvCities.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvCities.CurrentRow.Cells["Id"].Value);
            if (MessageBox.Show("Silmek istediðinize emin misiniz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DatabaseHelper.DeleteCity(id);
                LoadCities();
            }
        }

        // --- Schools CRUD & Search ---
        private void LoadSchools(string search = "")
        {
            var result = DatabaseHelper.GetSchools(search);
            dgvSchools.DataSource = result;
            if (dgvSchools.Columns.Contains("Name"))
                dgvSchools.Columns["Name"].HeaderText = "Okul Adý";
            if (dgvSchools.Columns.Contains("CityName"))
                dgvSchools.Columns["CityName"].HeaderText = "Þehir";
            if (dgvSchools.Columns.Contains("Id"))
                dgvSchools.Columns["Id"].Visible = false;
            if (dgvSchools.Columns.Contains("CityId"))
                dgvSchools.Columns["CityId"].Visible = false; // CityId gizli, CityName görünüyor
            UpdateStatusStrips();
            dgvSchools.ScrollBars = ScrollBars.Both;
        }

        private void btnSchoolSearch_Click(object sender, EventArgs e)
        {
            LoadSchools(txtSchoolSearch.Text.Trim());
        }

        private void txtSchoolSearch_TextChanged(object sender, EventArgs e)
        {
            LoadSchools(txtSchoolSearch.Text.Trim());
        }

        private void btnSchoolAdd_Click(object sender, EventArgs e)
        {
            using (var frm = new SchoolEditForm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadSchools();
            }
        }

        private void btnSchoolEdit_Click(object sender, EventArgs e)
        {
            if (dgvSchools.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvSchools.CurrentRow.Cells["Id"].Value);
            string name = dgvSchools.CurrentRow.Cells["Name"].Value.ToString();
            int cityId = dgvSchools.CurrentRow.Cells["CityId"].Value != DBNull.Value
                ? Convert.ToInt32(dgvSchools.CurrentRow.Cells["CityId"].Value)
                : 0;
            using (var frm = new SchoolEditForm(id, name, cityId))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadSchools();
            }
        }

        private void btnSchoolDelete_Click(object sender, EventArgs e)
        {
            if (dgvSchools.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvSchools.CurrentRow.Cells["Id"].Value);
            if (MessageBox.Show("Silmek istediðinize emin misiniz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DatabaseHelper.DeleteSchool(id);
                LoadSchools();
            }
        }

        // --- Students CRUD & Search ---
        private void LoadStudents(string search = "")
        {
            var result = PaginationHelper.GetStudentsPaged(search, studentsPage, studentsPageSize, out studentsTotal);
            dgvStudents.DataSource = result;

            // Sadece önemli sütunlar görünsün, diðerleri gizli kalsýn
            if (dgvStudents.Columns.Contains("id"))
                dgvStudents.Columns["id"].Visible = false;
            if (dgvStudents.Columns.Contains("bolum_id"))
                dgvStudents.Columns["bolum_id"].Visible = false;
            if (dgvStudents.Columns.Contains("okul_id"))
                dgvStudents.Columns["okul_id"].Visible = false;
            if (dgvStudents.Columns.Contains("onceki_okul_id"))
                dgvStudents.Columns["onceki_okul_id"].Visible = false;
            if (dgvStudents.Columns.Contains("kktc_kimlik_no"))
                dgvStudents.Columns["kktc_kimlik_no"].Visible = false;
            if (dgvStudents.Columns.Contains("veli_telefon"))
                dgvStudents.Columns["veli_telefon"].Visible = false;
            if (dgvStudents.Columns.Contains("adres"))
                dgvStudents.Columns["adres"].Visible = false;
            if (dgvStudents.Columns.Contains("email"))
                dgvStudents.Columns["email"].Visible = false;
            if (dgvStudents.Columns.Contains("telefon"))
                dgvStudents.Columns["telefon"].Visible = false;
            if (dgvStudents.Columns.Contains("kayit_tarihi"))
                dgvStudents.Columns["kayit_tarihi"].Visible = false;

            // Baþlýklarý ayarla (görünenler)
            if (dgvStudents.Columns.Contains("ogrenci_no"))
                dgvStudents.Columns["ogrenci_no"].HeaderText = "Öðrenci No";
            if (dgvStudents.Columns.Contains("ad"))
                dgvStudents.Columns["ad"].HeaderText = "Ad";
            if (dgvStudents.Columns.Contains("soyad"))
                dgvStudents.Columns["soyad"].HeaderText = "Soyad";
            if (dgvStudents.Columns.Contains("cinsiyet"))
                dgvStudents.Columns["cinsiyet"].HeaderText = "Cinsiyet";
            if (dgvStudents.Columns.Contains("bolum"))
                dgvStudents.Columns["bolum"].HeaderText = "Bölüm";
            if (dgvStudents.Columns.Contains("okul"))
                dgvStudents.Columns["okul"].HeaderText = "Okul";
            if (dgvStudents.Columns.Contains("sinif"))
                dgvStudents.Columns["sinif"].HeaderText = "Sýnýf";
            if (dgvStudents.Columns.Contains("yil"))
                dgvStudents.Columns["yil"].HeaderText = "Yýl";
            if (dgvStudents.Columns.Contains("veli_adi"))
                dgvStudents.Columns["veli_adi"].HeaderText = "Veli Adý";
            if (dgvStudents.Columns.Contains("onceki_okul"))
                dgvStudents.Columns["onceki_okul"].HeaderText = "Önceki Okul";

            UpdateStatusStrips();
            dgvStudents.ScrollBars = ScrollBars.Both;
        }

        private void btnStudentSearch_Click(object sender, EventArgs e)
        {
            LoadStudents(txtStudentSearch.Text.Trim());
        }

        private void txtStudentSearch_TextChanged(object sender, EventArgs e)
        {
            LoadStudents(txtStudentSearch.Text.Trim());
        }

        private void btnStudentAdd_Click(object sender, EventArgs e)
        {
            using (var frm = new StudentEditForm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadStudents();
            }
        }

        private void btnStudentEdit_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null) return;
            var row = dgvStudents.CurrentRow;
            int id = Convert.ToInt32(row.Cells["id"].Value);
            string ogrNo = row.Cells["ogrenci_no"].Value.ToString();
            string ad = row.Cells["ad"].Value.ToString();
            string soyad = row.Cells["soyad"].Value.ToString();
            DateTime dogum = Convert.ToDateTime(row.Cells["dogum_tarihi"].Value);
            string cinsiyet = row.Cells["cinsiyet"].Value.ToString();
            string email = row.Cells["email"].Value.ToString();
            string telefon = row.Cells["telefon"].Value.ToString();
            string adres = row.Cells["adres"].Value.ToString();
            int bolumId = row.Cells["bolum_id"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["bolum_id"].Value) : 0;
            string sinif = row.Cells["sinif"].Value.ToString();
            string yil = row.Cells["yil"].Value.ToString();
            string kimlik = row.Cells["kktc_kimlik_no"].Value.ToString();
            string veliAd = row.Cells["veli_adi"].Value.ToString();
            string veliTel = row.Cells["veli_telefon"].Value.ToString();
            int okulId = row.Cells["okul_id"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["okul_id"].Value) : 0;
            int oncekiOkulId = row.Cells["onceki_okul_id"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["onceki_okul_id"].Value) : 0;

            using (var frm = new StudentEditForm(id, ogrNo, ad, soyad, dogum, cinsiyet, email, telefon, adres, bolumId, sinif, yil, kimlik, veliAd, veliTel, okulId, oncekiOkulId))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadStudents();
            }
        }

        private void btnStudentDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvStudents.CurrentRow.Cells["id"].Value);
            if (MessageBox.Show("Silmek istediðinize emin misiniz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DatabaseHelper.DeleteStudent(id);
                LoadStudents();
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            DataTable exportTable = null;
            string fileName = "veriler.xlsx";
            if (panelStudents.Visible)
            {
                exportTable = dgvStudents.DataSource as DataTable;
                fileName = "ogrenciler.xlsx";
            }
            else if (panelDepartments.Visible)
            {
                exportTable = dgvDepartments.DataSource as DataTable;
                fileName = "bolumler.xlsx";
            }
            else if (panelSchools.Visible)
            {
                exportTable = dgvSchools.DataSource as DataTable;
                fileName = "okullar.xlsx";
            }
            else if (panelCities.Visible)
            {
                exportTable = dgvCities.DataSource as DataTable;
                fileName = "sehirler.xlsx";
            }

            if (exportTable == null || exportTable.Rows.Count == 0)
            {
                MessageBox.Show("Aktarýlacak veri yok.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Dosyasý (*.xlsx)|*.xlsx|CSV Dosyasý (*.csv)|*.csv";
                sfd.FileName = fileName;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (Path.GetExtension(sfd.FileName).ToLower() == ".csv")
                        {
                            ExcelExportHelper.ExportToCsv(exportTable, sfd.FileName);
                        }
                        else
                        {
                            ExcelExportHelper.ExportToExcel(exportTable, sfd.FileName);
                        }
                        MessageBox.Show("Veriler baþarýyla dýþa aktarýldý.", "Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Dýþa aktarma sýrasýnda bir hata oluþtu.\n\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
