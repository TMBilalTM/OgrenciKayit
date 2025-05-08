namespace OgrenciKayit
{
    partial class StudentEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblOgrNo, lblAd, lblSoyad, lblDogum, lblCinsiyet, lblEmail, lblTelefon, lblAdres, lblBolum, lblSinif, lblYil, lblKimlik, lblVeliAd, lblVeliTel, lblOkul, lblOncekiOkul;
        private System.Windows.Forms.TextBox txtOgrNo, txtAd, txtSoyad, txtEmail, txtTelefon, txtAdres, txtSinif, txtYil, txtKimlik, txtVeliAd, txtVeliTel;
        private System.Windows.Forms.ComboBox cmbCinsiyet, cmbBolum, cmbOkul, cmbOncekiOkul;
        private System.Windows.Forms.DateTimePicker dtDogum;
        private System.Windows.Forms.Button btnSave, btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblOgrNo = new System.Windows.Forms.Label();
            this.txtOgrNo = new System.Windows.Forms.TextBox();
            this.lblAd = new System.Windows.Forms.Label();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.lblSoyad = new System.Windows.Forms.Label();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.lblDogum = new System.Windows.Forms.Label();
            this.dtDogum = new System.Windows.Forms.DateTimePicker();
            this.lblCinsiyet = new System.Windows.Forms.Label();
            this.cmbCinsiyet = new System.Windows.Forms.ComboBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblTelefon = new System.Windows.Forms.Label();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.lblAdres = new System.Windows.Forms.Label();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.lblBolum = new System.Windows.Forms.Label();
            this.cmbBolum = new System.Windows.Forms.ComboBox();
            this.lblSinif = new System.Windows.Forms.Label();
            this.txtSinif = new System.Windows.Forms.TextBox();
            this.lblYil = new System.Windows.Forms.Label();
            this.txtYil = new System.Windows.Forms.TextBox();
            this.lblKimlik = new System.Windows.Forms.Label();
            this.txtKimlik = new System.Windows.Forms.TextBox();
            this.lblVeliAd = new System.Windows.Forms.Label();
            this.txtVeliAd = new System.Windows.Forms.TextBox();
            this.lblVeliTel = new System.Windows.Forms.Label();
            this.txtVeliTel = new System.Windows.Forms.TextBox();
            this.lblOkul = new System.Windows.Forms.Label();
            this.cmbOkul = new System.Windows.Forms.ComboBox();
            this.lblOncekiOkul = new System.Windows.Forms.Label();
            this.cmbOncekiOkul = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            // Set properties and positions (simplified for brevity)
            int y = 20, xLabel = 20, xInput = 150, wLabel = 120, wInput = 200, h = 25, gap = 35;
            this.lblOgrNo.SetBounds(xLabel, y, wLabel, h); this.txtOgrNo.SetBounds(xInput, y, wInput, h); y += gap;
            this.lblAd.SetBounds(xLabel, y, wLabel, h); this.txtAd.SetBounds(xInput, y, wInput, h); y += gap;
            this.lblSoyad.SetBounds(xLabel, y, wLabel, h); this.txtSoyad.SetBounds(xInput, y, wInput, h); y += gap;
            this.lblDogum.SetBounds(xLabel, y, wLabel, h); this.dtDogum.SetBounds(xInput, y, wInput, h); y += gap;
            this.lblCinsiyet.SetBounds(xLabel, y, wLabel, h); this.cmbCinsiyet.SetBounds(xInput, y, wInput, h); y += gap;
            this.lblEmail.SetBounds(xLabel, y, wLabel, h); this.txtEmail.SetBounds(xInput, y, wInput, h); y += gap;
            this.lblTelefon.SetBounds(xLabel, y, wLabel, h); this.txtTelefon.SetBounds(xInput, y, wInput, h); y += gap;
            this.lblAdres.SetBounds(xLabel, y, wLabel, h); this.txtAdres.SetBounds(xInput, y, wInput, h); y += gap;
            this.lblBolum.SetBounds(xLabel, y, wLabel, h); this.cmbBolum.SetBounds(xInput, y, wInput, h); y += gap;
            this.lblSinif.SetBounds(xLabel, y, wLabel, h); this.txtSinif.SetBounds(xInput, y, wInput, h); y += gap;
            this.lblYil.SetBounds(xLabel, y, wLabel, h); this.txtYil.SetBounds(xInput, y, wInput, h); y += gap;
            this.lblKimlik.SetBounds(xLabel, y, wLabel, h); this.txtKimlik.SetBounds(xInput, y, wInput, h); y += gap;
            this.lblVeliAd.SetBounds(xLabel, y, wLabel, h); this.txtVeliAd.SetBounds(xInput, y, wInput, h); y += gap;
            this.lblVeliTel.SetBounds(xLabel, y, wLabel, h); this.txtVeliTel.SetBounds(xInput, y, wInput, h); y += gap;
            this.lblOkul.SetBounds(xLabel, y, wLabel, h); this.cmbOkul.SetBounds(xInput, y, wInput, h); y += gap;
            this.lblOncekiOkul.SetBounds(xLabel, y, wLabel, h); this.cmbOncekiOkul.SetBounds(xInput, y, wInput, h); y += gap;
            this.btnSave.SetBounds(xInput, y, 90, 32); this.btnCancel.SetBounds(xInput + 110, y, 90, 32);

            // Set labels
            this.lblOgrNo.Text = "Öðrenci No:";
            this.lblAd.Text = "Ad:";
            this.lblSoyad.Text = "Soyad:";
            this.lblDogum.Text = "Doðum Tarihi:";
            this.lblCinsiyet.Text = "Cinsiyet:";
            this.lblEmail.Text = "E-posta:";
            this.lblTelefon.Text = "Telefon:";
            this.lblAdres.Text = "Adres:";
            this.lblBolum.Text = "Bölüm:";
            this.lblSinif.Text = "Sýnýf:";
            this.lblYil.Text = "Yýl:";
            this.lblKimlik.Text = "KKTC Kimlik No:";
            this.lblVeliAd.Text = "Veli Adý:";
            this.lblVeliTel.Text = "Veli Telefon:";
            this.lblOkul.Text = "Okul:";
            this.lblOncekiOkul.Text = "Önceki Okul:";

            // ComboBox items
            this.cmbCinsiyet.Items.AddRange(new object[] { "Erkek", "Kadýn" });
            this.cmbCinsiyet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBolum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOkul.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOncekiOkul.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // DateTimePicker
            this.dtDogum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDogum.MinDate = new System.DateTime(1900, 1, 1);
            this.dtDogum.MaxDate = new System.DateTime(2025, 12, 31);

            // Buttons
            this.btnSave.Text = "Kaydet";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnCancel.Text = "Ýptal";
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            // Add controls
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblOgrNo, txtOgrNo, lblAd, txtAd, lblSoyad, txtSoyad, lblDogum, dtDogum, lblCinsiyet, cmbCinsiyet,
                lblEmail, txtEmail, lblTelefon, txtTelefon, lblAdres, txtAdres, lblBolum, cmbBolum, lblSinif, txtSinif,
                lblYil, txtYil, lblKimlik, txtKimlik, lblVeliAd, txtVeliAd, lblVeliTel, txtVeliTel, lblOkul, cmbOkul,
                lblOncekiOkul, cmbOncekiOkul, btnSave, btnCancel
            });

            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(400, y + 60);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Öðrenci Kaydý";
            this.Load += new System.EventHandler(this.StudentEditForm_Load);

            // Modern style
            FormUtils.StyleForm(this);
            FormUtils.StyleButton(this.btnSave);
            FormUtils.StyleButton(this.btnCancel);
        }
    }
}
