namespace RecycloSmart
{
    partial class StartForm
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
            this.Prijava = new System.Windows.Forms.Button();
            this.Registracija = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Prijava
            // 
            this.Prijava.Location = new System.Drawing.Point(502, 222);
            this.Prijava.Name = "Prijava";
            this.Prijava.Size = new System.Drawing.Size(210, 93);
            this.Prijava.TabIndex = 0;
            this.Prijava.Text = "Prijava u sustav";
            this.Prijava.UseVisualStyleBackColor = true;
            this.Prijava.Click += new System.EventHandler(this.button1_Click);
            // 
            // Registracija
            // 
            this.Registracija.Location = new System.Drawing.Point(89, 222);
            this.Registracija.Name = "Registracija";
            this.Registracija.Size = new System.Drawing.Size(210, 93);
            this.Registracija.TabIndex = 1;
            this.Registracija.Text = "Registracija Korisnika";
            this.Registracija.UseVisualStyleBackColor = true;
            this.Registracija.Click += new System.EventHandler(this.button2_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Registracija);
            this.Controls.Add(this.Prijava);
            this.Name = "StartForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Prijava;
        private System.Windows.Forms.Button Registracija;
    }
}

