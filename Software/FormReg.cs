using RecycloSmart.Models;
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

namespace RecycloSmart
{
    public partial class FormReg : Form
    {
        public FormReg()
        {
            InitializeComponent();
        }

        private void btnAddRadnik_Click(object sender, EventArgs e)
        {
            Radnik noviRadnik = new Radnik
            {
                KorisnickoIme = txtUsername.Text,
                Lozinka = txtPassword.Text,

            };

            RadnikRepozitori radnikRepozitori = new RadnikRepozitori();
            radnikRepozitori.AddRadnik(noviRadnik);

            MessageBox.Show("Uspjesna registracija!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void FormReg_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StartForm pocetnaForma = new StartForm();
            Hide();
            pocetnaForma.ShowDialog();
            Close();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
