using System;
using System.Windows.Forms;

namespace OgrenciKayit
{
    public partial class DepartmentEditForm : Form
    {
        private int? departmentId = null;

        public DepartmentEditForm()
        {
            InitializeComponent();
        }

        public DepartmentEditForm(int id, string name) : this()
        {
            departmentId = id;
            txtName.Text = name;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Bölüm adý giriniz.");
                return;
            }
            if (departmentId == null)
                DatabaseHelper.AddDepartment(txtName.Text.Trim());
            else
                DatabaseHelper.UpdateDepartment(departmentId.Value, txtName.Text.Trim());
            this.DialogResult = DialogResult.OK;
        }

        private void DepartmentEditForm_Load(object sender, EventArgs e)
        {
            txtName.Focus();
        }
    }
}
