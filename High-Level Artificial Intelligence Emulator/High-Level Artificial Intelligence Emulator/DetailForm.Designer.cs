namespace High_Level_Artificial_Intelligence_Emulator
{
    partial class DetailForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblCaseType;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.GroupBox grpDetails;

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
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSurname = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblCaseType = new System.Windows.Forms.Label();
            this.txtDetails = new System.Windows.Forms.TextBox();

            this.SuspendLayout();

            this.grpDetails.Text = "Danışan Bilgileri";
            this.grpDetails.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.grpDetails.Location = new System.Drawing.Point(12, 12);
            this.grpDetails.Size = new System.Drawing.Size(460, 300);
            this.grpDetails.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpDetails.Padding = new System.Windows.Forms.Padding(10);

            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 17);
            this.lblName.Text = "Adı:";

            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(20, 70);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(65, 17);
            this.lblSurname.Text = "Soyadı:";

            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(20, 110);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(65, 17);
            this.lblPhone.Text = "Telefon:";

            this.lblCaseType.AutoSize = true;
            this.lblCaseType.Location = new System.Drawing.Point(20, 150);
            this.lblCaseType.Name = "lblCaseType";
            this.lblCaseType.Size = new System.Drawing.Size(50, 17);
            this.lblCaseType.Text = "Konu:";

            this.txtDetails.Location = new System.Drawing.Point(20, 190);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.Size = new System.Drawing.Size(400, 80);
            this.txtDetails.ReadOnly = false; 
            this.txtDetails.BackColor = System.Drawing.Color.White;

            this.grpDetails.Controls.Add(this.lblName);
            this.grpDetails.Controls.Add(this.lblSurname);
            this.grpDetails.Controls.Add(this.lblPhone);
            this.grpDetails.Controls.Add(this.lblCaseType);
            this.grpDetails.Controls.Add(this.txtDetails);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 330);
            this.Controls.Add(this.grpDetails);
            this.Name = "DetailForm";
            this.Text = "Danışan Detayları";
            this.BackColor = System.Drawing.Color.LightGray;

            this.ResumeLayout(false);
        }
    }
}
