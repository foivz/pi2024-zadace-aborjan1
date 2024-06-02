using RecycloSmart.Models;
using RecycloSmart.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace RecycloSmart
{
    public partial class FormEvidentiraj : Form
    {
        
        
        public FormEvidentiraj()
        {
            InitializeComponent();
        }

        private void FormEvidentiraj_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MaterijalRepozitori materijalRepozitori = new MaterijalRepozitori();
            string naziv = txtNaziv.Text;
            string kolicina = txtKolicina.Text;
            string vrsta = txtVrsta.Text;
            string datum = txtDatum.Text;
            

            if (string.IsNullOrEmpty(naziv) || string.IsNullOrEmpty(kolicina) || string.IsNullOrEmpty(vrsta) || string.IsNullOrEmpty(datum))
            {
                MessageBox.Show("Sva polja moraju biti popunjena!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (materijalRepozitori.PostojiMaterijal(naziv))
            {
                using (UnosForma formOdabir = new UnosForma())
                {
                    if (formOdabir.ShowDialog() == DialogResult.OK)
                    {
                        string odabraniTip = formOdabir.OdabraniTip;
                        materijalRepozitori.UnesiMaterijal(naziv, kolicina, vrsta, datum, odabraniTip);

                    }
                }
            }else
            {
                materijalRepozitori.UnesiMaterijal(naziv, kolicina, vrsta, datum, "");
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MaterijalRepozitori materijalRepozitori = new MaterijalRepozitori();
            string naziv = txtNaziv.Text;
            materijalRepozitori.ObrisiMaterijal(naziv);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormRadnik formRadnik = new FormRadnik();
            Hide();
            formRadnik.ShowDialog();
            Close();
        }
    }
    
}
