using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OgrenciKayit
{
    public partial class StudentEditForm : Form
    {
        private int? studentId = null;

        public StudentEditForm()
        {
            InitializeComponent();
        }

        public StudentEditForm(
            int id, string ogrNo, string ad, string soyad, DateTime dogum, string cinsiyet, string email, string telefon,
            string adres, int bolumId, string sinif, string yil, string kimlik, string veliAd, string veliTel, int okulId, int oncekiOkulId)
            : this()
        {
            studentId = id;
            txtOgrNo.Text = ogrNo;
            txtAd.Text = ad;
            txtSoyad.Text = soyad;
            dtDogum.Value = dogum;
            cmbCinsiyet.SelectedItem = cinsiyet;
            txtEmail.Text = email;
            txtTelefon.Text = telefon;
            txtAdres.Text = adres;
            txtSinif.Text = sinif;
            txtYil.Text = yil;
            txtKimlik.Text = kimlik;
            txtVeliAd.Text = veliAd;
            txtVeliTel.Text = veliTel;
            this.Tag = new Tuple<int, int>(bolumId, okulId);
            this.cmbOncekiOkul.SelectedValue = oncekiOkulId;
        }

        private void StudentEditForm_Load(object sender, EventArgs e)
        {
            // Load bolumler
            var bolumDt = DatabaseHelper.GetDepartments();
            cmbBolum.DataSource = bolumDt;
            cmbBolum.DisplayMember = "Name";
            cmbBolum.ValueMember = "Id";

            // Load okullar
            var okulDt = DatabaseHelper.GetSchools();
            cmbOkul.DataSource = okulDt;
            cmbOkul.DisplayMember = "Name";
            cmbOkul.ValueMember = "Id";

            // Load onceki okullar
            var oncekiOkulDt = DatabaseHelper.GetSchools();
            cmbOncekiOkul.DataSource = oncekiOkulDt;
            cmbOncekiOkul.DisplayMember = "Name";
            cmbOncekiOkul.ValueMember = "Id";

            // Set selected values if editing
            if (this.Tag is Tuple<int, int> t)
            {
                cmbBolum.SelectedValue = t.Item1;
                cmbOkul.SelectedValue = t.Item2;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtOgrNo.Text))
            {
                MessageBox.Show("��renci numaras� giriniz.");
                return;
            }
            if (DatabaseHelper.StudentNumberExists(txtOgrNo.Text.Trim(), studentId))
            {
                MessageBox.Show("Bu ��renci numaras� zaten kay�tl�!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtSoyad.Text))
            {
                MessageBox.Show("Ad ve soyad giriniz.");
                return;
            }
            if (dtDogum.Value > DateTime.Now || dtDogum.Value.Year < 1900 || dtDogum.Value.Year > 2025)
            {
                MessageBox.Show("Ge�erli bir do�um tarihi giriniz.");
                return;
            }
            if (cmbCinsiyet.SelectedIndex < 0)
            {
                MessageBox.Show("Cinsiyet se�iniz.");
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Ge�erli bir e-posta giriniz.");
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtTelefon.Text) && !Regex.IsMatch(txtTelefon.Text, @"^\+?\d{10,15}$"))
            {
                MessageBox.Show("Ge�erli bir telefon numaras� giriniz.");
                return;
            }
            if (txtAdres.Text.Length < 10)
            {
                MessageBox.Show("Adres en az 10 karakter olmal�.");
                return;
            }
            if (cmbBolum.SelectedValue == null)
            {
                MessageBox.Show("B�l�m se�iniz.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSinif.Text) || string.IsNullOrWhiteSpace(txtYil.Text))
            {
                MessageBox.Show("S�n�f ve y�l giriniz.");
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtKimlik.Text) && txtKimlik.Text.Length != 10)
            {
                MessageBox.Show("KKTC Kimlik Numaras� 10 haneli olmal�.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtVeliAd.Text) || string.IsNullOrWhiteSpace(txtVeliTel.Text))
            {
                MessageBox.Show("Veli ad� ve telefon giriniz.");
                return;
            }
            if (!Regex.IsMatch(txtVeliTel.Text, @"^\+?\d{10,15}$"))
            {
                MessageBox.Show("Ge�erli bir veli telefon numaras� giriniz.");
                return;
            }
            if (cmbOkul.SelectedValue == null)
            {
                MessageBox.Show("Okul se�iniz.");
                return;
            }
            if (cmbOncekiOkul.SelectedValue == null)
            {
                MessageBox.Show("�nceki okul se�iniz.");
                return;
            }

            if (studentId == null)
            {
                DatabaseHelper.AddStudent(
                    txtOgrNo.Text.Trim(), txtAd.Text.Trim(), txtSoyad.Text.Trim(), dtDogum.Value, cmbCinsiyet.SelectedItem.ToString(),
                    txtEmail.Text.Trim(), txtTelefon.Text.Trim(), txtAdres.Text.Trim(), Convert.ToInt32(cmbBolum.SelectedValue),
                    txtSinif.Text.Trim(), txtYil.Text.Trim(), txtKimlik.Text.Trim(), txtVeliAd.Text.Trim(), txtVeliTel.Text.Trim(),
                    Convert.ToInt32(cmbOkul.SelectedValue), Convert.ToInt32(cmbOncekiOkul.SelectedValue)
                );
            }
            else
            {
                DatabaseHelper.UpdateStudent(
                    studentId.Value, txtOgrNo.Text.Trim(), txtAd.Text.Trim(), txtSoyad.Text.Trim(), dtDogum.Value, cmbCinsiyet.SelectedItem.ToString(),
                    txtEmail.Text.Trim(), txtTelefon.Text.Trim(), txtAdres.Text.Trim(), Convert.ToInt32(cmbBolum.SelectedValue),
                    txtSinif.Text.Trim(), txtYil.Text.Trim(), txtKimlik.Text.Trim(), txtVeliAd.Text.Trim(), txtVeliTel.Text.Trim(),
                    Convert.ToInt32(cmbOkul.SelectedValue), Convert.ToInt32(cmbOncekiOkul.SelectedValue)
                );
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
