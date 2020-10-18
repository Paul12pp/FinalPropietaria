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
            if (validaCedula(tbcedula.Text))
            {
                var result = db.Loggin(tbcedula.Text);
                if (result.Id != 0)
                {
                    Administracion adm = new Administracion(result.Nombre);
                    adm.Show();
                    adm.FormClosed += new FormClosedEventHandler(adm_closed);
                    tbcedula.Text = "";
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado, intente otra vez.");
                }
            }
            else
            {
                MessageBox.Show("Cedula no valida");
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        void adm_closed(object sender, FormClosedEventArgs e)
        {
            Show();
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

        private void label3_Click(object sender, EventArgs e)
        {
            Form_Verificar cand = new Form_Verificar();
            cand.Show();
            cand.FormClosed += new FormClosedEventHandler(adm_closed);
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public static bool validaCedula(string pCedula)

        {
            int vnTotal = 0;
            string vcCedula = pCedula.Replace("-", "");
            int pLongCed = vcCedula.Trim().Length;
            int[] digitoMult = new int[11] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };

            if (pLongCed < 11 || pLongCed > 11)
                return false;

            for (int vDig = 1; vDig <= pLongCed; vDig++)
            {
                int vCalculo = Int32.Parse(vcCedula.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];
                if (vCalculo < 10)
                    vnTotal += vCalculo;
                else
                    vnTotal += Int32.Parse(vCalculo.ToString().Substring(0, 1)) + Int32.Parse(vCalculo.ToString().Substring(1, 1));
            }

            if (vnTotal % 10 == 0)
                return true;
            else
                return false;
        }
    }

}
