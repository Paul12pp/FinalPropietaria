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
    public partial class Form_Empleado : Form
    {
        EmpleadoRepos db = new EmpleadoRepos(new Models.RRHH_PropietariaEntities());
        PuestosRepos puestos = new PuestosRepos(new Models.RRHH_PropietariaEntities());
        public Form_Empleado()
        {
            InitializeComponent();
            dataGridView1.DataSource = db.GetEmpleados();
            fillCombox();
        }

        private void fillCombox()
        {
            var data = puestos.GetPuestos();
            cbPuesto.ValueMember = "Codigo";
            cbPuesto.DisplayMember = "Nombre";
            cbPuesto.DataSource = data;
            var data1 = puestos.GetDepartamentos();
            cbDepartamento.ValueMember = "Codigo";
            cbDepartamento.DisplayMember = "Descripcion";
            cbDepartamento.DataSource = data1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                var model = new Models.Empleado
                {
                    Nombre = tbNombre.Text,
                    Cedula = tbCedula.Text,
                    IdDepartamento = Convert.ToInt32(cbDepartamento.SelectedValue),
                    Puesto = cbPuesto.Text,
                    Fecha_Ing = dtFecha.Value,
                    Salario_M = Convert.ToDecimal(tbSalario.Text),
                    Estado = cbEstado.Text == "Activo" ? true : false
                };
                var response = tbId.Text != "" ? db.EditEmpleado(Convert.ToInt32(tbId.Text), model) : db.AddEmpleado(model);
                MessageBox.Show(response == 200 ? "Agregado Exitosamente." : "Ha ocurrido un error.");
                if (response == 200)
                    cleanAll();
            }
            else
            {
                MessageBox.Show("Complete los cambos.");
            }
            dataGridView1.DataSource = db.GetEmpleados();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cleanAll();
        }
        private void change(object sender, EventArgs e)
        {
            Console.WriteLine(cbDepartamento.SelectedValue);
        }

        private void cleanAll()
        {
            tbNombre.Text = "";
            tbSalario.Text = "";
            tbCedula.Text = "";
            cbEstado.SelectedItem = "Activo";
            tbId.Text = "";
            dtFecha.Value = DateTime.Now;
            dtFecha.Enabled = true;
        }

        private bool isValid()
        {
            var valid = true;
            if (tbNombre.Text == "")
            {
                valid = false;
            }
            if (tbCedula.Text == "")
            {
                valid = false;
            }
            if (tbSalario.Text == "")
            {
                valid = false;
            }
            if (cbDepartamento.Text == "")
            {
                valid = false;
            }
            if (cbEstado.Text == "")
            {
                valid = false;
            }
            if (cbPuesto.Text == "")
            {
                valid = false;
            }
            if (dtFecha.Text == "")
            {
                valid = false;
            }
            return valid;
        }


        private void cell(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
            string a = Convert.ToString(selectedRow.Cells["Codigo"].Value);
            retrieveData(a);

        }
        private void retrieveData(string a)
        {
            var puesto = db.GetEmpleadoById(Convert.ToInt32(a));
            tbNombre.Text = puesto.Nombre;
            tbSalario.Text = puesto.Salario_M.ToString();
            tbCedula.Text = puesto.Cedula.ToString();
            cbEstado.SelectedItem = puesto.Estado == true ? "Activo" : "Inactivo";
            cbPuesto.SelectedItem = puesto.Puesto;
            cbDepartamento.SelectedItem = puesto.IdDepartamento;
            dtFecha.Value = puesto.Fecha_Ing.Value;
            dtFecha.Enabled = false;
            tbId.Text = puesto.Id.ToString();
        }

        private void Form_Empleado_Load(object sender, EventArgs e)
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
