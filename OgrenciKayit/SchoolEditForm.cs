using System;
using System.Windows.Forms;
using System.Data;

namespace OgrenciKayit
{
    public partial class SchoolEditForm : Form
    {
        private int? schoolId = null;

        public SchoolEditForm()
        {
            InitializeComponent();
        }

        public SchoolEditForm(int id, string name, int cityId) : this()
        {
            schoolId = id;
            txtName.Text = name;
            // Set city after loading cities in Load event
            this.Tag = cityId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Okul adý giriniz.");
                return;
            }
            if (cmbCity.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir þehir seçiniz.");
                return;
            }
            int cityId = (int)cmbCity.SelectedValue;
            if (schoolId == null)
                DatabaseHelper.AddSchool(txtName.Text.Trim(), cityId);
            else
                DatabaseHelper.UpdateSchool(schoolId.Value, txtName.Text.Trim(), cityId);
            this.DialogResult = DialogResult.OK;
        }

        private void SchoolEditForm_Load(object sender, EventArgs e)
        {
            // Load cities into cmbCity
            DataTable dt = DatabaseHelper.GetCities();
            cmbCity.DataSource = dt;
            cmbCity.DisplayMember = "Name";
            cmbCity.ValueMember = "Id";

            // If editing, select the correct city
            if (this.Tag is int cityId)
            {
                cmbCity.SelectedValue = cityId;
            }
            txtName.Focus();
        }
    }
}
