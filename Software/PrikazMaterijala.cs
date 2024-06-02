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
    public partial class PrikazMaterijala : Form
    {
        public PrikazMaterijala()
        {
            InitializeComponent();
        }

        private void PrikazMaterijala_Load(object sender, EventArgs e)
        {
            ShowMaterijals();
        }
        private void dvgMaterijali_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void ShowMaterijals()
        {
            List<Materijal> materijali = MaterijalRepozitori.GetMaterijals();
            dvgMaterijali.DataSource = materijali;
            dvgMaterijali.Columns["Naziv"].DisplayIndex = 0;
            dvgMaterijali.Columns["Kolicina"].DisplayIndex = 1;
            dvgMaterijali.Columns["Vrsta"].DisplayIndex = 2;
            dvgMaterijali.Columns["Datum"].DisplayIndex = 3;
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
