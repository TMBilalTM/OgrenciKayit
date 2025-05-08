using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace OgrenciKayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Modern style
            FormUtils.StyleForm(this);

            // Modernize buttons
            FormUtils.StyleButton(btnLogin);
            FormUtils.StyleButton(btnClose);
            FormUtils.StyleButton(btnMinimize);

            // Enable drag for top panel if exists
            if (panelTop != null)
                FormUtils.EnableFormDrag(this, panelTop);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Basic validation
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblError.Visible = true;
                lblError.Text = "Kullanıcı adı ve şifre gereklidir!";
                return;
            }

            try
            {
                if (DatabaseHelper.VerifyLogin(username, password))
                {
                    lblError.Visible = false;
                    MessageBox.Show("Giriş başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Open admin dashboard and hide login form
                    AdminDashboard dashboard = new AdminDashboard();
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Kullanıcı adı veya şifre hatalı!";
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (MySqlException ex)
            {
                lblError.Visible = true;
                lblError.Text = "Veritabanı hatası: " + ex.Message;
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "Hata: " + ex.Message;
            }
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Varsayılan giriş bilgileri:\nKullanıcı adı: admin\nŞifre: admin123", 
                "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = checkBoxShowPassword.Checked ? '\0' : '•';
        }

        // Allow the form to be dragged
        private bool isDragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void panelTop_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
