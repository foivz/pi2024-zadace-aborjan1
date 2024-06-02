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
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormLogin formaLogin = new FormLogin();
            Hide();
            formaLogin.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormReg formaRegistracija = new FormReg();
            Hide();
            formaRegistracija.ShowDialog();
            Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
