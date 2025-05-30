using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq;

namespace OgrenciKayit
{
    public partial class StudentEditForm : Form
    {
        private int? studentId = null;
        private DateTime? kayitTarihi = null;

        public StudentEditForm()
        {
            InitializeComponent();
        }

        public StudentEditForm(
            int id, string ogrNo, string ad, string soyad, DateTime dogum, string cinsiyet, string email, string telefon,
            string adres, int bolumId, string sinif, string yil, string kimlik, string veliAd, string veliTel, int okulId, int oncekiOkulId, DateTime kayitTarihi)
            : this()
        {
            studentId = id;
            txtOgrNo.Text = ogrNo;
            txtAd.Text = ad?.ToUpper();
            txtSoyad.Text = soyad?.ToUpper();
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
            this.kayitTarihi = kayitTarihi;
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

            // Kayıt tarihi gösterimi
            if (kayitTarihi.HasValue)
            {
                lblKayitTarihi.Text = kayitTarihi.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                lblKayitTarihi.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtOgrNo.Text))
            {
                MessageBox.Show("Öğrenci numarası giriniz.");
                return;
            }
            if (DatabaseHelper.StudentNumberExists(txtOgrNo.Text.Trim(), studentId))
            {
                MessageBox.Show("Bu öğrenci numarası zaten kayıtlı!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtSoyad.Text))
            {
                MessageBox.Show("Ad ve soyad giriniz.");
                return;
            }
            DateTime dogumTarihi = dtDogum.Value;
            DateTime kayitTarihiToUse = kayitTarihi ?? DateTime.Now;

            // Doğum tarihi mantıklı aralık ve kayıt tarihinden önce olmalı
            if (dogumTarihi.Year < 1900 || dogumTarihi.Year > 2025)
            {
                MessageBox.Show("Doğum tarihi 1900 ile 2025 arasında olmalıdır.", "Geçersiz Tarih", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtDogum.Focus();
                return;
            }
            if (dogumTarihi > kayitTarihiToUse)
            {
                MessageBox.Show("Doğum tarihi, kayıt tarihinden sonra olamaz.", "Geçersiz Tarih", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtDogum.Focus();
                return;
            }
            if (cmbCinsiyet.SelectedIndex < 0)
            {
                MessageBox.Show("Cinsiyet seçiniz.");
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Geçerli bir e-posta giriniz.");
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtTelefon.Text) && !Regex.IsMatch(txtTelefon.Text, @"^\+?\d{10,15}$"))
            {
                MessageBox.Show("Geçerli bir telefon numarası giriniz.");
                return;
            }

            // Adres detaylı kontrol: en az 10 karakter, harf ve rakam içermeli
            string adres = txtAdres.Text.Trim();
            if (adres.Length < 10 || !adres.Any(char.IsLetter) || !adres.Any(char.IsDigit))
            {
                MessageBox.Show("Adres en az 10 karakter olmalı ve hem harf hem rakam içermelidir.", "Adres Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdres.Focus();
                return;
            }

            if (cmbBolum.SelectedValue == null)
            {
                MessageBox.Show("Bölüm seçiniz.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSinif.Text) || string.IsNullOrWhiteSpace(txtYil.Text))
            {
                MessageBox.Show("Sınıf ve yıl giriniz.");
                return;
            }

            // Kimlik numarası benzersiz olmalı (varsa ve doluysa kontrol et)
            string kimlik = txtKimlik.Text.Trim();
            if (!string.IsNullOrWhiteSpace(kimlik))
            {
                if (DatabaseHelper.IsIdentityNumberExists(kimlik, studentId))
                {
                    MessageBox.Show("Bu KKTC Kimlik Numarası başka bir öğrenciye ait!", "Kimlik Numarası Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKimlik.Focus();
                    return;
                }
            }

            if (!string.IsNullOrWhiteSpace(txtKimlik.Text) && txtKimlik.Text.Length != 10)
            {
                MessageBox.Show("KKTC Kimlik Numarası 10 haneli olmalı.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtVeliAd.Text) || string.IsNullOrWhiteSpace(txtVeliTel.Text))
            {
                MessageBox.Show("Veli adı ve telefon giriniz.");
                return;
            }
            if (!Regex.IsMatch(txtVeliTel.Text, @"^\+?\d{10,15}$"))
            {
                MessageBox.Show("Geçerli bir veli telefon numarası giriniz.");
                return;
            }
            if (cmbOkul.SelectedValue == null)
            {
                MessageBox.Show("Okul seçiniz.");
                return;
            }
            if (cmbOncekiOkul.SelectedValue == null)
            {
                MessageBox.Show("Önceki okul seçiniz.");
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

        private void txtAd_TextChanged(object sender, EventArgs e)
        {
            var selStart = txtAd.SelectionStart;
            txtAd.Text = txtAd.Text.ToUpper();
            txtAd.SelectionStart = selStart;
        }

        private void txtSoyad_TextChanged(object sender, EventArgs e)
        {
            var selStart = txtSoyad.SelectionStart;
            txtSoyad.Text = txtSoyad.Text.ToUpper();
            txtSoyad.SelectionStart = selStart;
        }
    }
}
