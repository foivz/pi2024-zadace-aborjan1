using RecycloSmart.Models;
using DBLayer;
using RecycloSmart.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace RecycloSmart
{
    public partial class FormLogin : Form
    {

        public static Radnik Ulogiran {  get; set; }



        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Korisničko ime nije uneseno!", "Problem",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Lozinka nije unesena!", "Problem", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            else
            {
              
                Ulogiran = RadnikRepozitori.GetRadnik(txtPassword.Text);


                if (Ulogiran != null && Ulogiran.Lozinka.Trim().Equals(txtPassword.Text.Trim(), StringComparison.OrdinalIgnoreCase) && Ulogiran.KorisnickoIme.Trim().Equals(txtUsername.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    FormRadnik formaRadnika = new FormRadnik();
                    Hide();
                    formaRadnika.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Krivi podaci!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StartForm pocetnaForma = new StartForm();
            Hide();
            pocetnaForma.ShowDialog();
            Close();
        }
    }
}
