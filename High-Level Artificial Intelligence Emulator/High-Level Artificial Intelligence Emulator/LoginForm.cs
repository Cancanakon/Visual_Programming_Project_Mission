using System;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace High_Level_Artificial_Intelligence_Emulator
{
    public partial class LoginForm : Form
    {
        private string connectionString;

        public LoginForm(string connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;
            InitializeLoginLayout();
        }

        private void InitializeLoginLayout()
        {
            // Form özellikleri
            this.Text = "High-Level AI Emulator - Avukat Girişi";
            this.Size = new System.Drawing.Size(350, 250);

            // Kullanıcı Adı Etiketi ve Metin Kutusu
            Label lblUsername = new Label
            {
                Text = "Kullanıcı Adı:",
                AutoSize = true,
                Top = 30,
                Left = 30
            };
            TextBox txtUsername = new TextBox
            {
                Name = "txtUsername",
                Top = 60,
                Left = 30,
                Width = 250
            };

            // Şifre Etiketi ve Metin Kutusu
            Label lblPassword = new Label
            {
                Text = "Şifre:",
                AutoSize = true,
                Top = 100,
                Left = 30
            };
            TextBox txtPassword = new TextBox
            {
                Name = "txtPassword",
                Top = 130,
                Left = 30,
                Width = 250,
                UseSystemPasswordChar = true
            };

            // Giriş Yap Butonu
            Button btnLogin = new Button
            {
                Text = "Giriş Yap",
                Top = 180,
                Left = 30,
                Width = 250
            };
            btnLogin.Click += (sender, e) => Login(txtUsername, txtPassword);

            // Bileşenleri Form'a Ekle
            this.Controls.AddRange(new Control[] { lblUsername, txtUsername, lblPassword, txtPassword, btnLogin });
        }

        private void Login(TextBox txtUsername, TextBox txtPassword)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Sifre FROM Avukatlar WHERE KullaniciAdi = @kullaniciAdi";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@kullaniciAdi", txtUsername.Text);

                    string storedHash = cmd.ExecuteScalar()?.ToString();
                    if (storedHash == null)
                    {
                        MessageBox.Show("Kullanıcı adı bulunamadı.");
                        return;
                    }

                    // Şifre doğrulama
                    string inputHash = HashPassword(txtPassword.Text);
                    if (storedHash == inputHash)
                    {
                        MessageBox.Show("Giriş başarılı.");
                        this.Hide(); // Login formunu gizle
                        AdminPanelForm adminPanel = new AdminPanelForm();
                        adminPanel.ShowDialog();
                        this.Close(); // Admin panel kapandığında Login formunu da kapat
                    }
                    else
                    {
                        MessageBox.Show("Hatalı kullanıcı adı veya şifre.");
                    }
                }
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
