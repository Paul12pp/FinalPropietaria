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
    public partial class Form_Puesto : Form
    {
        PuestosRepos db = new PuestosRepos(new Models.RRHH_PropietariaEntities());
        public Form_Puesto()
        {
            InitializeComponent();
            dataGridView1.DataSource = db.GetPuestos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                var model = new Models.Puestos
                {
                    Nivel_Ma_Salarial = Convert.ToDecimal(tbSmax.Text),
                    Nivel_Mi_Salarial = Convert.ToDecimal(tbSmin.Text),
                    Nivel_Riesgo = cbNivel.Text,
                    Nombre = tbNombre.Text,
                    Estado = cbEstado.Text == "Activo" ? true : false
                };
                var response = tbId.Text != "" ? db.EditPuesto(Convert.ToInt32(tbId.Text), model) : db.AddPuesto(model);
                MessageBox.Show(response == 200 ? "Agregado Exitosamente." : "Ha ocurrido un error.");
                if (response == 200)
                    cleanAll();
            }
            else
            {
                MessageBox.Show("Complete los cambos.");
            }
            dataGridView1.DataSource = db.GetPuestos();
        }
        private bool isValid()
        {
            var valid = true;
            if (tbNombre.Text == "")
            {
                valid = false;
            }
            if (tbSmax.Text == "")
            {
                valid = false;
            }
            if (tbSmin.Text == "")
            {
                valid = false;
            }
            if(cbEstado.Text == "")
            {
                valid = false;
            }
            if (cbEstado.Text == "")
            {
                valid = false;
            }
            return valid;
        }

        private void change(object sender, EventArgs e)
        {
            Console.WriteLine(cbNivel.Text);
        }

        private void cell(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
            string a = Convert.ToString(selectedRow.Cells["Id"].Value);
            retrieveData(a);

        }
        private void retrieveData(string a)
        {
            var puesto = db.GetPuestosById(Convert.ToInt32(a));
            tbNombre.Text = puesto.Nombre;
            tbSmax.Text = puesto.Nivel_Ma_Salarial.ToString();
            tbSmin.Text = puesto.Nivel_Mi_Salarial.ToString();
            cbEstado.SelectedItem = puesto.Estado == true ? "Activo" : "Inactivo";
            cbNivel.SelectedItem = puesto.Nivel_Riesgo;
            tbId.Text = puesto.Id.ToString();
        }
        private void cleanAll()
        {
            tbNombre.Text = "";
            tbSmax.Text = "";
            tbSmin.Text = "";
            tbId.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cleanAll();
        }

        private void Form_Puesto_Load(object sender, EventArgs e)
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
    }
}
