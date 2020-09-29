using FinalPropietaria.Interfaces;
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
        EmpleadoRepos db = new EmpleadoRepos(new Models.RRHH_PropietariaEntities());
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var result = db.Loggin(tbcedula.Text);
            if (result)
            {
                Administracion adm = new Administracion();
                adm.Show();
                adm.FormClosed += new FormClosedEventHandler(adm_closed);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario no encontrado, intente otra vez.");
            }
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

        private void label5_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void numbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbcedula_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1_Click_1(this, new EventArgs());
            }
        }
    }

}
