using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace High_Level_Artificial_Intelligence_Emulator
{
    public partial class DetailForm : Form
    {
        private SQLiteConnection sqliteConnection;
        private int userId;

        public DetailForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            InitializeDatabaseConnection();
            LoadUserDetails();
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString = "Data Source=database.db;Version=3;";
            sqliteConnection = new SQLiteConnection(connectionString);
        }

        private void LoadUserDetails()
        {
            try
            {
                sqliteConnection.Open();
                string query = "SELECT Isim, Soyisim, Telefon, Konu, Durum FROM Danisanlar WHERE Id = @Id";
                SQLiteCommand command = new SQLiteCommand(query, sqliteConnection);
                command.Parameters.AddWithValue("@Id", userId);

                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    lblName.Text = "Adı: " + reader["Isim"].ToString();
                    lblSurname.Text = "Soyadı: " + reader["Soyisim"].ToString();
                    lblPhone.Text = "Telefon: " + reader["Telefon"].ToString();
                    lblCaseType.Text = "Konu: " + reader["Konu"].ToString();
                    txtDetails.Text = "Durum: " + reader["Durum"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                sqliteConnection.Close();
            }
        }
    }
}
