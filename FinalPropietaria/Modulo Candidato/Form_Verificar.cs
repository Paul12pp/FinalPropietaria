using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalPropietaria.Interfaces;

namespace FinalPropietaria
{
    public partial class Form_Verificar : Form
    {
        CandidatoRepos db = new CandidatoRepos(new Models.RRHH_PropietariaEntities());
        public Form_Verificar()
        {
            InitializeComponent();
        }

        private void Form_Verificar_Load(object sender, EventArgs e)
        {

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
            if (e.KeyCode == Keys.Enter)
            {
                btnchek_Click(this, new EventArgs());
            }
        }

        private void btnchek_Click(object sender, EventArgs e)
        {
            if (validaCedula(tbcedula.Text))
            {
                var cand = db.GetCandidatoByCedula(tbcedula.Text);
                if (cand.Id != 0)
                {
                    MessageBox.Show($"{cand.Nombre} su estado es {cand.Estado}.");
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado.");
                }
            }
            else
            {

                MessageBox.Show("Cedula no valida");
            }
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
