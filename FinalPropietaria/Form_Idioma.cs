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
    public partial class Form_Idioma : Form
    {
        IdiomaRepos db = new IdiomaRepos(new Models.RRHH_PropietariaEntities());
        public Form_Idioma()
        {
            InitializeComponent();
            dataGridView1.DataSource = db.GetIdiomas();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form_Idioma_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                var model = new Models.Idiomas
                {
                    Nombre = tbNombre.Text,
                    Estado = cbEstado.Text == "Activo" ? true : false
                };
                var response = tbId.Text != "" ? db.EditIdioma(Convert.ToInt32(tbId.Text), model) : db.AddIdioma(model);
                MessageBox.Show(response == 200 ? "Agregado Exitosamente." : "Ha ocurrido un error.");
                if (response == 200)
                    cleanAll();
            }
            else
            {
                MessageBox.Show("Complete los cambos.");
            }
            dataGridView1.DataSource = db.GetIdiomas();
        }

        private void cleanAll()
        {
            tbId.Text = "";
            tbNombre.Text = "";
        }

        private bool isValid()
        {
            var valid = true;
            if (tbNombre.Text == "")
            {
                valid = false;
            }
            if (cbEstado.Text == "")
            {
                valid = false;
            }
            return valid;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cleanAll();
        }

        private void cell(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
            string a = Convert.ToString(selectedRow.Cells["Codigo"].Value);
            retrieveData(a);

        }
        private void retrieveData(string a)
        {
            var puesto = db.GetIdiomaById(Convert.ToInt32(a));
            tbNombre.Text = puesto.Nombre;
            cbEstado.SelectedItem = puesto.Estado == true ? "Activo" : "Inactivo";
            tbId.Text = puesto.Id.ToString();
        }
    }
}
