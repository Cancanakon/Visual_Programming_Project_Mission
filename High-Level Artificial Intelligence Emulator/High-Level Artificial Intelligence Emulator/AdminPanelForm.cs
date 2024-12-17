using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace High_Level_Artificial_Intelligence_Emulator
{
    public partial class AdminPanelForm : Form
    {
        private string connectionString = "Data Source=database.db;Version=3;";
        private DataGridView dataGridView;
        private Chart chart;

        public AdminPanelForm()
        {
            InitializeComponent();
            InitializeAdminPanelLayout();
            LoadDanisanlar();
            LoadChart();
        }

        private void InitializeAdminPanelLayout()
        {
            this.Text = "High-Level AI Emulator - Admin Paneli";
            this.Size = new System.Drawing.Size(900, 700);

            // DataGridView Ayarları
            dataGridView = new DataGridView
            {
                Top = 20,
                Left = 20,
                Width = 840,
                Height = 250,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            // Chart Ayarları (Daha küçük)
            chart = new Chart
            {
                Top = 280, // Daha yukarı alındı
                Left = 20,
                Width = 840,
                Height = 220 // Yükseklik küçültüldü
            };
            ChartArea chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            // Yenile Butonu
            Button btnRefresh = new Button
            {
                Text = "Yenile",
                Top = 520,
                Left = 20,
                Width = 100
            };
            btnRefresh.Click += (sender, e) => { LoadDanisanlar(); LoadChart(); };

            // Sil Butonu
            Button btnDelete = new Button
            {
                Text = "Sil",
                Top = 520,
                Left = 140,
                Width = 100
            };
            btnDelete.Click += (sender, e) => DeleteDanisan();

            this.Controls.Add(dataGridView);
            this.Controls.Add(chart);
            this.Controls.Add(btnRefresh);
            this.Controls.Add(btnDelete);
        }

        private void LoadDanisanlar()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Id, Isim, Soyisim, Telefon, Konu, Durum FROM Danisanlar";

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView.DataSource = dt;
                }
            }
        }

        private void LoadChart()
        {
            chart.Series.Clear();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Konu, COUNT(*) AS BasvuruSayisi FROM Danisanlar GROUP BY Konu";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    Series series = new Series("Başvuru Sayısı")
                    {
                        ChartType = SeriesChartType.Column,
                        IsValueShownAsLabel = true
                    };

                    while (reader.Read())
                    {
                        string konu = reader["Konu"].ToString();
                        int basvuruSayisi = Convert.ToInt32(reader["BasvuruSayisi"]);
                        series.Points.AddXY(konu, basvuruSayisi);
                    }

                    chart.Series.Add(series);
                }
            }
        }

        private void DeleteDanisan()
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silmek için bir satır seçiniz.");
                return;
            }

            int selectedId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Danisanlar WHERE Id = @id";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", selectedId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Danışan başarıyla silindi.");
            LoadDanisanlar();
            LoadChart();
        }
    }
}
