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
    }
}
