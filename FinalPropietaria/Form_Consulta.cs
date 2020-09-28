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
    public partial class Form_Consulta : Form
    {
        CandidatoRepos db = new CandidatoRepos(new Models.RRHH_PropietariaEntities());
        PuestosRepos puestos = new PuestosRepos(new Models.RRHH_PropietariaEntities());
        public Form_Consulta()
        {
            InitializeComponent();
            dataGridView1.DataSource = db.GetCandidatos();
            var data = puestos.GetPuestos();
            cbPuesto.ValueMember = "Id";
            cbPuesto.DisplayMember = "Nombre";
            cbPuesto.DataSource = data;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form_Consulta_Load(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.GetCandidatos();
        }

        private void cleanAll()
        {
            tbNombre.Text = "";
            tbSd.Text = "";
            tbsH.Text = "";
            tbCompe.Text = "";
        }

        private void tbcancel_Click(object sender, EventArgs e)
        {
            cleanAll();
            dataGridView1.DataSource = db.GetCandidatos();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            var data = db.Search(tbNombre.Text, Convert.ToInt32(cbPuesto.SelectedValue), tbCompe.Text,
                Convert.ToDecimal(tbSd.Text), Convert.ToDecimal(tbsH.Text));
            dataGridView1.DataSource = data;
        }
    }
}
