using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalPropietaria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Administracion adm = new Administracion();
            adm.Show();
            adm.FormClosed += new FormClosedEventHandler(adm_closed);
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        void adm_closed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form_Candidato cand = new Form_Candidato();
            cand.Show();
            cand.FormClosed += new FormClosedEventHandler(adm_closed);
            this.Hide();
        }
    }

}
