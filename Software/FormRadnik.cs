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
    public partial class FormRadnik : Form
    {
        public FormRadnik()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormEvidentiraj formEvidentiraj = new FormEvidentiraj();
            Hide();
            formEvidentiraj.ShowDialog();
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormPretraziMaterijal pretrazi = new FormPretraziMaterijal();
            Hide();
            pretrazi.ShowDialog();
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            StartForm startForm = new StartForm();
            Hide();
            startForm.ShowDialog();
            Close();
        }

        private void FormRadnik_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrikazMaterijala prikazMaterijala = new PrikazMaterijala();
            Hide();
            prikazMaterijala.ShowDialog();
            Close();
        }
    }
}
