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
    public partial class Form_Seleccion : Form
    {
        CandidatoRepos db = new CandidatoRepos(new Models.RRHH_PropietariaEntities());
        PuestosRepos util = new PuestosRepos(new Models.RRHH_PropietariaEntities());
        public Form_Seleccion()
        {
            InitializeComponent();
            dataGridView1.DataSource = db.GetCandidatos();
            var data = util.GetPuestos();
            cbPuesto.ValueMember = "Codigo";
            cbPuesto.DisplayMember = "Nombre";
            cbPuesto.DataSource = data;
        }

        private void btnfilter_Click(object sender, EventArgs e)
        {

            var data = db.GetCandidatosByPuestos(Convert.ToInt32(cbPuesto.SelectedValue));
            dataGridView1.DataSource = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.GetCandidatos();
        }

        private void cell(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
            string a = Convert.ToString(selectedRow.Cells["Codigo"].Value);
            //retrieveData(a);
            Form_Perfil pp = new Form_Perfil(Convert.ToInt32(a));
            pp.Show();
            pp.FormClosed += new FormClosedEventHandler(adm_closed);
        }

        void adm_closed(object sender, FormClosedEventArgs e)
        {
            dataGridView1.DataSource = db.GetCandidatos();
        }

        private void Form_Seleccion_Load(object sender, EventArgs e)
        {

        }
    }
}
