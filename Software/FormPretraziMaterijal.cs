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
    public partial class FormPretraziMaterijal : Form
    {
        public FormPretraziMaterijal()
        {
            InitializeComponent();
        }

        private void FormPretraziMaterijal_Load(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Materijal materijal = new Materijal();
            
            MaterijalRepozitori materijalRepozitori = new MaterijalRepozitori(); 
            string naziv = txtPretrazi.Text;
            //materijal = materijalRepozitori.PretraziMaterijal(naziv);
            List<Materijal> materijali = new List<Materijal>();
            materijali.Add(materijalRepozitori.PretraziMaterijal(naziv));
            
            dgvMaterijali.DataSource = materijali;

            dgvMaterijali.Columns["Naziv"].DisplayIndex = 0;
            dgvMaterijali.Columns["Kolicina"].DisplayIndex = 1;
            dgvMaterijali.Columns["Vrsta"].DisplayIndex = 2;
            dgvMaterijali.Columns["Datum"].DisplayIndex = 3;
            dgvMaterijali.Visible = true;
            label2.Visible = true;
        }

        private void dgvMaterijali_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormRadnik formRadnik = new FormRadnik();
            Hide();
            formRadnik.ShowDialog();
            Close();
        }
    }
}
