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
    public partial class Form_Perfil : Form
    {
        CandidatoRepos db = new CandidatoRepos(new Models.RRHH_PropietariaEntities());
        private int id=0;
        public Form_Perfil(int idCandidato)
        {
            InitializeComponent();
            fillData(idCandidato);
            id = idCandidato;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void fillData(int id)
        {
            var data = db.GetCandidatoById(id);
            if (data.Id != 0)
            {
                lbname.Text = data.Nombre;
                lbcedula.Text = data.Cedula;
                lbcompe.Text = data.Competencias;
                lbsalario.Text = data.Salario_Asp.Value.ToString();
                lbpuesto.Text = data.Puestos.Nombre;
                lbdepa.Text = data.Departamento.Descripcion;
                lbrecomen.Text = data.Recomendado_p;
                dataGridView1.DataSource = db.GetCapacitacionByCandidato(data.Id);
                dataGridView2.DataSource = db.GetExperienciasByCandidato(data.Id);
            }
            else
            {
                MessageBox.Show("Ha ocurrido un erro, intente otra vez.");
                Close();
            }
        }

        private void btnRechazo_Click(object sender, EventArgs e)
        {
            var result = db.RechazarCandidato(id);
            if (result == 200)
            {
                MessageBox.Show("Candidato rechazado");
                Close();
            }
            else
                MessageBox.Show("Ha ocurrido un error, intente otra vez");
        }

        private void btnContrato_Click(object sender, EventArgs e)
        {
            var result = db.AprobarCandidato(id);
            if (result == 200)
            {
                MessageBox.Show("Candidato Aprobado");
                Close();
            }
            else
                MessageBox.Show("Ha ocurrido un error, intente otra vez");
        }

        private void Form_Perfil_Load(object sender, EventArgs e)
        {

        }
    }
}
