using System;
using System.Windows.Forms;

namespace OgrenciKayit
{
    public partial class CityEditForm : Form
    {
        private int? cityId = null;

        public CityEditForm()
        {
            InitializeComponent();
        }

        public CityEditForm(int id, string name) : this()
        {
            cityId = id;
            txtName.Text = name;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Þehir adý giriniz.");
                return;
            }
            if (cityId == null)
                DatabaseHelper.AddCity(txtName.Text.Trim());
            else
                DatabaseHelper.UpdateCity(cityId.Value, txtName.Text.Trim());
            this.DialogResult = DialogResult.OK;
        }

        private void CityEditForm_Load(object sender, EventArgs e)
        {
            // Optionally focus textbox
            txtName.Focus();
        }
    }
}
