namespace High_Level_Artificial_Intelligence_Emulator
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblName;
        private TextBox txtName;
        private Label lblSurname;
        private TextBox txtSurname;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblCaseType;
        private ListBox lstCaseType;
        private Label lblDetail;
        private TextBox txtDetail;
        private Button btnSave;
        private Button btnLogin;


        private System.Windows.Forms.Label lblChatTitle;
        private System.Windows.Forms.RichTextBox rtbChatHistory;
        private System.Windows.Forms.TextBox txtChatInput;
        private System.Windows.Forms.Button btnSendChat;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblName = new Label();
            this.txtName = new TextBox();
            this.lblSurname = new Label();
            this.txtSurname = new TextBox();
            this.lblPhone = new Label();
            this.txtPhone = new TextBox();
            this.lblCaseType = new Label();
            this.lstCaseType = new ListBox();
            this.lblDetail = new Label();
            this.txtDetail = new TextBox();
            this.btnSave = new Button();
            this.btnLogin = new Button();





            this.lblChatTitle = new System.Windows.Forms.Label();
            this.rtbChatHistory = new System.Windows.Forms.RichTextBox();
            this.txtChatInput = new System.Windows.Forms.TextBox();
            this.btnSendChat = new System.Windows.Forms.Button();

            this.lblChatTitle.Text = "AI Chatbot";
            this.lblChatTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblChatTitle.Location = new System.Drawing.Point(450, 20);
            this.lblChatTitle.AutoSize = true;

            this.rtbChatHistory.Location = new System.Drawing.Point(450, 50);
            this.rtbChatHistory.Size = new System.Drawing.Size(300, 350);
            this.rtbChatHistory.ReadOnly = true;
            this.rtbChatHistory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rtbChatHistory.BackColor = System.Drawing.Color.WhiteSmoke;

            this.txtChatInput.Location = new System.Drawing.Point(450, 420);
            this.txtChatInput.Size = new System.Drawing.Size(220, 30);
            this.txtChatInput.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.btnSendChat.Text = "Gönder";
            this.btnSendChat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSendChat.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSendChat.ForeColor = System.Drawing.Color.White;
            this.btnSendChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendChat.Location = new System.Drawing.Point(680, 420);
            this.btnSendChat.Size = new System.Drawing.Size(70, 30);
            this.btnSendChat.Click += new System.EventHandler(this.BtnSendChat_Click);

            this.Controls.Add(this.lblChatTitle);
            this.Controls.Add(this.rtbChatHistory);
            this.Controls.Add(this.txtChatInput);
            this.Controls.Add(this.btnSendChat);



            this.SuspendLayout();
            this.Text = "High-Level AI Emulator - Hukuk Danışan Yönetimi";
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.lblName.Text = "İsim:";
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.lblName.AutoSize = true;

            this.txtName.Location = new System.Drawing.Point(20, 50);
            this.txtName.Size = new System.Drawing.Size(200, 30);
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.lblSurname.Text = "Soyisim:";
            this.lblSurname.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSurname.Location = new System.Drawing.Point(20, 90);
            this.lblSurname.AutoSize = true;

            this.txtSurname.Location = new System.Drawing.Point(20, 120);
            this.txtSurname.Size = new System.Drawing.Size(200, 30);
            this.txtSurname.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.lblPhone.Text = "Telefon:";
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblPhone.Location = new System.Drawing.Point(20, 160);
            this.lblPhone.AutoSize = true;

            this.txtPhone.Location = new System.Drawing.Point(20, 190);
            this.txtPhone.Size = new System.Drawing.Size(200, 30);
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.lblCaseType.Text = "Hukuki Süreç Konusu:";
            this.lblCaseType.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCaseType.Location = new System.Drawing.Point(20, 230);
            this.lblCaseType.AutoSize = true;

            this.lstCaseType.Location = new System.Drawing.Point(20, 260);
            this.lstCaseType.Size = new System.Drawing.Size(200, 100);
            this.lstCaseType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstCaseType.Items.AddRange(new string[] { "Dava", "İcra", "Danışmanlık", "Ceza Hukuku", "Aile Hukuku" });

            this.lblDetail.Text = "Olayın Detayı:";
            this.lblDetail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDetail.Location = new System.Drawing.Point(20, 370);
            this.lblDetail.AutoSize = true;

            this.txtDetail.Location = new System.Drawing.Point(20, 400);
            this.txtDetail.Size = new System.Drawing.Size(200, 100);
            this.txtDetail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDetail.Multiline = true;

            this.btnSave.Text = "Kaydet";
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(20, 520);
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.Click += (sender, e) => SaveDanisan(txtName, txtSurname, txtPhone, lstCaseType, txtDetail);

            this.btnLogin.Text = "Giriş Yap";
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogin.BackColor = System.Drawing.Color.ForestGreen;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.Location = new System.Drawing.Point(140, 520);
            this.btnLogin.Size = new System.Drawing.Size(100, 40);
            this.btnLogin.Click += (sender, e) => ShowLoginForm();

            this.Controls.AddRange(new Control[] {
                lblName, txtName, lblSurname, txtSurname,
                lblPhone, txtPhone, lblCaseType, lstCaseType,
                lblDetail, txtDetail, btnSave, btnLogin
            });

            this.ResumeLayout(false);
        }
    }
}
