namespace eProdaja.WinUI
{
    partial class frmKorisnici
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvKorisinici = new System.Windows.Forms.DataGridView();
            this.btnShow = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorisinici)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKorisinici
            // 
            this.dgvKorisinici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKorisinici.Location = new System.Drawing.Point(12, 112);
            this.dgvKorisinici.Name = "dgvKorisinici";
            this.dgvKorisinici.RowHeadersWidth = 51;
            this.dgvKorisinici.RowTemplate.Height = 29;
            this.dgvKorisinici.Size = new System.Drawing.Size(776, 326);
            this.dgvKorisinici.TabIndex = 0;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(694, 43);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(94, 29);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "Prikaži";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(20, 43);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(234, 27);
            this.txtUsername.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ime";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(273, 43);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(234, 27);
            this.txtName.TabIndex = 4;
            // 
            // frmKorisnici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.dgvKorisinici);
            this.Name = "frmKorisnici";
            this.Text = "frmKorisnici";
            this.Load += new System.EventHandler(this.frmKorisnici_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorisinici)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvKorisinici;
        private Button btnShow;
        private TextBox txtUsername;
        private Label label1;
        private Label label2;
        private TextBox txtName;
    }
}