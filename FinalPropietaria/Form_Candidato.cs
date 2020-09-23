using FinalPropietaria.Interfaces;
using FinalPropietaria.Models;
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
    public partial class Form_Candidato : Form
    {
        CandidatoRepos db = new CandidatoRepos(new Models.RRHH_PropietariaEntities());
        PuestosRepos util = new PuestosRepos(new Models.RRHH_PropietariaEntities());
        CompetenciaRepos comp = new CompetenciaRepos(new Models.RRHH_PropietariaEntities());
        public Form_Candidato()
        {
            InitializeComponent();
            fillCombox();
            //tabControl.Appearance = TabAppearance.FlatButtons;
            //tabControl.ItemSize = new Size(0, 1);
            //tabControl.SizeMode = TabSizeMode.Fixed;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Candidatos cand = new Candidatos
            {
                Nombre = tbNombre.Text,
                Cedula = tbCedula.Text,
                IdDepartamento = Convert.ToInt32(cbDepartamento.SelectedValue),
                IdPuesto = Convert.ToInt32(cbPuesto.SelectedValue),
                Recomendado_p = tbRecomendado.Text,
                Salario_Asp = Convert.ToDecimal(tbSalario.Text)

            };
            //tabControl.SelectedTab = tpComp;
            tabControl.SelectTab(tpComp);

        }

        private void Form_Candidato_Load(object sender, EventArgs e)
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

        private void fillCombox()
        {
            var data = util.GetPuestos();
            cbPuesto.ValueMember = "Id";
            cbPuesto.DisplayMember = "Nombre";
            cbPuesto.DataSource = data;
            var data1 = util.GetDepartamentos();
            cbDepartamento.ValueMember = "Id";
            cbDepartamento.DisplayMember = "Descripcion";
            cbDepartamento.DataSource = data1;
            var com = comp.GetCompetencias();
            foreach (var item in com)
            {
               clCompetencias.Items.Add(item.Descripcion, false);
            }
        }
        private void changedAll(object sender, EventArgs e)
        {
            if (isValid())
            {
                btnNext.Enabled = true;
            }
            else
            {
                btnNext.Enabled = false;
            }
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
            if (tbRecomendado.Text == "")
            {
                valid = false;
            }
            if (tbSalario.Text == "")
            {
                valid = false;
            }
            if (tbWhy.Text == "")
            {
                valid = false;
            }
            if (cbPuesto.Text == "")
            {
                valid = false;
            }
            if (cbDepartamento.Text == "")
            {
                valid = false;
            }
            return valid;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tpExp);
        }
    }
}
