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
    }
}
