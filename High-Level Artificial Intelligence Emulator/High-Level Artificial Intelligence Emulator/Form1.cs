using System;
using System.Data;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json; 

namespace High_Level_Artificial_Intelligence_Emulator
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=database.db;Version=3;";
        private string apiUrl = "http://<SUNUCU_IP_ADRESI>:8000/ask/"; 
        public Form1()
        {
            InitializeComponent();
            InitializeDynamicLayout();
            CreateDatabaseIfNotExists();
        }

        private void InitializeDynamicLayout()
        {
            this.Text = "High-Level AI Emulator - Hukuk Danýþan Yönetimi";
            this.Size = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(600, 400);

            Label lblName = new Label { Text = "Ýsim:", AutoSize = true, Top = 20, Left = 20 };
            TextBox txtName = new TextBox { Name = "txtName", Top = 50, Left = 20, Width = 200 };

            Label lblSurname = new Label { Text = "Soyisim:", AutoSize = true, Top = 90, Left = 20 };
            TextBox txtSurname = new TextBox { Name = "txtSurname", Top = 120, Left = 20, Width = 200 };

            Label lblPhone = new Label { Text = "Telefon:", AutoSize = true, Top = 160, Left = 20 };
            TextBox txtPhone = new TextBox { Name = "txtPhone", Top = 190, Left = 20, Width = 200 };

            Label lblCaseType = new Label { Text = "Hukuki Süreç Konusu:", AutoSize = true, Top = 230, Left = 20 };
            ListBox lstCaseType = new ListBox { Name = "lstCaseType", Top = 260, Left = 20, Width = 200, Height = 100 };
            lstCaseType.Items.AddRange(new string[] { "Dava", "Ýcra", "Danýþmanlýk", "Ceza Hukuku", "Aile Hukuku" });

            Label lblDetail = new Label { Text = "Olayýn Detayý:", AutoSize = true, Top = 370, Left = 20 };
            TextBox txtDetail = new TextBox { Name = "txtDetail", Top = 400, Left = 20, Width = 200, Height = 100, Multiline = true };

            Button btnSave = new Button { Text = "Kaydet", Top = 520, Left = 20, Width = 100 };
            btnSave.Click += (sender, e) => SaveDanisan(txtName, txtSurname, txtPhone, lstCaseType, txtDetail);

            Button btnLogin = new Button { Text = "Giriþ Yap", Top = 520, Left = 140, Width = 100 };
            btnLogin.Click += (sender, e) => ShowLoginForm();

            this.Controls.AddRange(new Control[] { lblName, txtName, lblSurname, txtSurname, lblPhone, txtPhone, lblCaseType, lstCaseType, lblDetail, txtDetail, btnSave, btnLogin });
        }

        private async void BtnSendChat_Click(object sender, EventArgs e)
        {
            string userInput = txtChatInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                MessageBox.Show("Lütfen bir soru giriniz.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AppendMessage("Siz", userInput);

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var requestData = new { question = userInput };
                    string jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseBody);
                        string aiResponse = responseObject.response.ToString();

                        AppendMessage("AI", aiResponse);
                    }
                    else
                    {
                        AppendMessage("Sistem", $"Hata kodu: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                AppendMessage("Sistem", $"Hata oluþtu: {ex.Message}");
            }

            txtChatInput.Clear();
        }

        private void AppendMessage(string sender, string message)
        {
            rtbChatHistory.AppendText($"{sender}: {message}\n");
            rtbChatHistory.ScrollToCaret();
        }
    

    private void CreateDatabaseIfNotExists()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string createAvukatlarTable = @"
            CREATE TABLE IF NOT EXISTS Avukatlar (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                KullaniciAdi TEXT NOT NULL,
                Sifre TEXT NOT NULL
            )";
                string createDanisanlarTable = @"
            CREATE TABLE IF NOT EXISTS Danisanlar (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Isim TEXT NOT NULL,
                Soyisim TEXT NOT NULL,
                Telefon TEXT NOT NULL,
                Konu TEXT NOT NULL,
                Durum TEXT NOT NULL
            )";

                using (SQLiteCommand cmd = new SQLiteCommand(createAvukatlarTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                using (SQLiteCommand cmd = new SQLiteCommand(createDanisanlarTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                AddDefaultAdminUser(conn);
            }
        }

        private void AddDefaultAdminUser(SQLiteConnection conn)
        {
            string defaultUsername = "admin";
            string defaultPassword = HashPassword("admin"); 

            string checkUserQuery = "SELECT COUNT(*) FROM Avukatlar WHERE KullaniciAdi = @username";
            using (SQLiteCommand cmd = new SQLiteCommand(checkUserQuery, conn))
            {
                cmd.Parameters.AddWithValue("@username", defaultUsername);
                int userCount = Convert.ToInt32(cmd.ExecuteScalar());

                if (userCount == 0)
                {
                    string insertUserQuery = "INSERT INTO Avukatlar (KullaniciAdi, Sifre) VALUES (@username, @password)";
                    using (SQLiteCommand insertCmd = new SQLiteCommand(insertUserQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@username", defaultUsername);
                        insertCmd.Parameters.AddWithValue("@password", defaultPassword);
                        insertCmd.ExecuteNonQuery();
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

        private void SaveDanisan(TextBox txtName, TextBox txtSurname, TextBox txtPhone, ListBox lstCaseType, TextBox txtDetail)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSurname.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) || lstCaseType.SelectedItem == null || string.IsNullOrWhiteSpace(txtDetail.Text))
            {
                MessageBox.Show("Lütfen tüm alanlarý doldurun.");
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Danisanlar (Isim, Soyisim, Telefon, Konu, Durum) VALUES (@isim, @soyisim, @telefon, @konu, @durum)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@isim", txtName.Text);
                    cmd.Parameters.AddWithValue("@soyisim", txtSurname.Text);
                    cmd.Parameters.AddWithValue("@telefon", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@konu", lstCaseType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@durum", txtDetail.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Danýþan bilgileri baþarýyla kaydedildi.");
        }

        private void ShowLoginForm()
        {
            LoginForm loginForm = new LoginForm(connectionString);
            loginForm.ShowDialog();
        }
    }
}
