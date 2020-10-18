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
        private int idcandida = 0;
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
            if (isValid() && validaCedula(tbCedula.Text))
            {
                var cand = new Candidatos
                {
                    Nombre = tbNombre.Text,
                    Cedula = tbCedula.Text,
                    IdDepartamento = Convert.ToInt32(cbDepartamento.SelectedValue),
                    IdPuesto = Convert.ToInt32(cbPuesto.SelectedValue),
                    Recomendado_p = tbRecomendado.Text,
                    Salario_Asp = Convert.ToDecimal(tbSalario.Text),
                   

                };
                if (idcandida != 0)
                {
                    db.EditCandidato(idcandida, cand);
                    tabControl.SelectTab(tpComp);
                }
                else
                {
                    var response= db.AddCandidato(cand);
                    if (response.Id != 0)
                    {
                        idcandida = response.Id;
                        tabControl.SelectTab(tpComp);

                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error, intente otra vez.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Complete los cambos o verifique la cedula");
            }
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
            cbPuesto.ValueMember = "Codigo";
            cbPuesto.DisplayMember = "Nombre";
            cbPuesto.DataSource = data;
            var data1 = util.GetDepartamentos();
            cbDepartamento.ValueMember = "Id";
            cbDepartamento.DisplayMember = "Descripcion";
            cbDepartamento.DataSource = data1;
            cbNivel2.DataSource = cbNivel3.DataSource = cbNivel1.Items;
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
            if (lbNombre.Text == "")
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
            if (Convert.ToDecimal(tbSalario.Text)<0)
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

        private bool isValid2()
        {
            bool valid = true;
            if (clCompetencias.SelectedItems.Count == 0)
            {

                valid = false;
            }
            return valid;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isValid2())
            {
                string competencias = "";
                foreach (var item in clCompetencias.SelectedItems)
                {
                    competencias += " " + item;
                }
                var response = db.AddCapacitaciones(idcandida, CapacitacionesList(), competencias);
                if (response == 200)
                {
                    MessageBox.Show("Agregado exitosamente, contiune.");
                    tabControl.SelectTab(tpExp);
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error, intente otra vez.");
                }
            }
        }

        private List<Capacitaciones> CapacitacionesList()
        {
            int active = 0;
            if (tbDescripcion1.Text != "")
                active = 1;
            if (tbDescripcion2.Text != "")
                active = 2;
            if (tbDescripcion3.Text != "")
                active = 3;
            switch (active)
            {
                case 1:
                    return new List<Capacitaciones>
                    {
                        new Capacitaciones
                        {
                            Descripcion=tbDescripcion1.Text,
                            Fecha_desde=dtDesde1.Value,
                            Fecha_hasta=dtHasta1.Value,
                            Nivel= cbNivel1.Text,
                            Institucion=tbInstitucion1.Text,
                            IdCandidato=idcandida,
                        }
                    };
                case 2:
                    return new List<Capacitaciones>
                    {
                        new Capacitaciones
                        {
                            Descripcion=tbDescripcion1.Text,
                            Fecha_desde=dtDesde1.Value,
                            Fecha_hasta=dtHasta1.Value,
                            Nivel= cbNivel1.Text,
                            Institucion=tbInstitucion1.Text,
                            IdCandidato=idcandida,
                        },
                         new Capacitaciones
                        {
                            Descripcion=tbDescripcion2.Text,
                            Fecha_desde=dtDesde2.Value,
                            Fecha_hasta=dtHasta2.Value,
                            Nivel= cbNivel2.Text,
                            Institucion=tbInstitucion2.Text,
                            IdCandidato=idcandida,
                        }
                    };
                case 3:
                    return new List<Capacitaciones>
                    {
                        new Capacitaciones
                        {
                            Descripcion=tbDescripcion1.Text,
                            Fecha_desde=dtDesde1.Value,
                            Fecha_hasta=dtHasta1.Value,
                            Nivel= cbNivel1.Text,
                            Institucion=tbInstitucion1.Text,
                            IdCandidato=idcandida,
                        },
                         new Capacitaciones
                        {
                            Descripcion=tbDescripcion2.Text,
                            Fecha_desde=dtDesde2.Value,
                            Fecha_hasta=dtHasta2.Value,
                            Nivel= cbNivel2.Text,
                            Institucion=tbInstitucion2.Text,
                            IdCandidato=idcandida,
                        },
                          new Capacitaciones
                        {
                            Descripcion=tbDescripcion3.Text,
                            Fecha_desde=dtDesde3.Value,
                            Fecha_hasta=dtHasta3.Value,
                            Nivel= cbNivel3.Text,
                            Institucion=tbInstitucion3.Text,
                            IdCandidato=idcandida,
                        }
                    };
                default:
                    return new List<Capacitaciones>();
            }
        }

        private void clCompetencias_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (clCompetencias.SelectedItems.Count > 0)
            {
                tbDescripcion1.Enabled = true;
                tbInstitucion1.Enabled = true;
                dtDesde1.Enabled = true;
                dtHasta1.Enabled = true;
                cbNivel1.Enabled = true;
            }
            else
            {
                tbDescripcion1.Enabled = false;
                tbInstitucion1.Enabled = false;
                dtDesde1.Enabled = false;
                dtHasta1.Enabled = false;
                cbNivel1.Enabled = false;
            }
        }
        private void changeFirst(object sender, EventArgs e)
        {
            if(tbDescripcion1.Text!=""&&tbInstitucion1.Text!=""
                && cbNivel1.Text != "")
            {
                tbDescripcion2.Enabled = true;
                tbInstitucion2.Enabled = true;
                dtDesde2.Enabled = true;
                dtHasta2.Enabled = true;
                cbNivel2.Enabled = true;
            }
            else
            {
                tbDescripcion2.Enabled = false;
                tbInstitucion2.Enabled = false;
                dtDesde2.Enabled = false;
                dtHasta2.Enabled = false;
                cbNivel2.Enabled = false;
            }
        }
        private void changeSecond(object sender, EventArgs e)
        {
            if (tbDescripcion2.Text != "" && tbInstitucion2.Text != ""
                && cbNivel2.Text != "")
            {
                tbDescripcion3.Enabled = true;
                tbInstitucion3.Enabled = true;
                dtDesde3.Enabled = true;
                dtHasta3.Enabled = true;
                cbNivel3.Enabled = true;
            }
            else
            {
                tbDescripcion3.Enabled = false;
                tbInstitucion3.Enabled = false;
                dtDesde3.Enabled = false;
                dtHasta3.Enabled = false;
                cbNivel3.Enabled = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            tabControl.SelectTab(tpDatos);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tpComp);
        }

        private void changeOneE(object sender, EventArgs e)
        {
            if(tbEmpr1.Text!="" && tbPuesto1.Text!=""
                && tbSalario1.Text != "")
            {
                tbEmpr2.Enabled = true;
                tbPuesto2.Enabled = true;
                tbSalario2.Enabled = true;
                dtD2.Enabled = true;
                dtH2.Enabled = true;
                btnFin.Enabled = true;
            }
            else
            {
                tbEmpr2.Enabled = false;
                tbPuesto2.Enabled = false;
                tbSalario2.Enabled = false;
                dtD2.Enabled = false;
                dtH2.Enabled = false;
                btnFin.Enabled = false;
            }
        }
        private void changeTwoE(object sender, EventArgs e)
        {
            if (tbEmpr2.Text != "" && tbPuesto2.Text != ""
                && tbSalario2.Text != "")
            {
                tbEmpr3.Enabled = true;
                tbPuesto3.Enabled = true;
                tbSalario3.Enabled = true;
                dtD3.Enabled = true;
                dtH3.Enabled = true;
            }
            else
            {
                tbEmpr3.Enabled = false;
                tbPuesto3.Enabled = false;
                tbSalario3.Enabled = false;
                dtD3.Enabled = false;
                dtH3.Enabled = false;
            }
        }
        private void changeThreeE(object sender, EventArgs e)
        {
            if (tbEmpr3.Text != "" && tbPuesto3.Text != ""
                && tbSalario3.Text != "")
            {
                tbEmpr4.Enabled = true;
                tbPuesto4.Enabled = true;
                tbSalario4.Enabled = true;
                dtD4.Enabled = true;
                dtH4.Enabled = true;
            }
            else
            {
                tbEmpr4.Enabled = false;
                tbPuesto4.Enabled = false;
                tbSalario4.Enabled = false;
                dtD4.Enabled = false;
                dtH4.Enabled = false;
            }
        }

        private List<Experiencia> ExperienciasList()
        {
            int active = 0;
            if (tbEmpr1.Text != "")
                active = 1;
            if (tbEmpr2.Text != "")
                active = 2;
            if (tbEmpr3.Text != "")
                active = 3;
            if (tbEmpr4.Text != "")
                active = 3;
            switch (active)
            {
                case 1:
                    return new List<Experiencia>
                    {
                        new Experiencia
                        {
                            Empresa=tbEmpr1.Text,
                            Fecha_desde=dtD1.Value,
                            Fecha_hasta=dtD2.Value,
                            Salario= Convert.ToDecimal(tbSalario1.Text),
                            Puesto=tbPuesto1.Text,
                            IdCandidato=idcandida,
                        }
                    };
                case 2:
                    return new List<Experiencia>
                    {
                        new Experiencia
                        {
                            Empresa=tbEmpr1.Text,
                            Fecha_desde=dtD1.Value,
                            Fecha_hasta=dtH1.Value,
                            Salario= Convert.ToDecimal(tbSalario1.Text),
                            Puesto=tbPuesto1.Text,
                            IdCandidato=idcandida,
                        },
                         new Experiencia
                        {
                            Empresa=tbEmpr2.Text,
                            Fecha_desde=dtD2.Value,
                            Fecha_hasta=dtH2.Value,
                            Salario= Convert.ToDecimal(tbSalario2.Text),
                            Puesto=tbPuesto2.Text,
                            IdCandidato=idcandida,
                        }
                    };
                case 3:
                    return new List<Experiencia>
                    {
                        new Experiencia
                        {
                            Empresa=tbEmpr1.Text,
                            Fecha_desde=dtD1.Value,
                            Fecha_hasta=dtH1.Value,
                            Salario= Convert.ToDecimal(tbSalario1.Text),
                            Puesto=tbPuesto1.Text,
                            IdCandidato=idcandida,
                        },
                         new Experiencia
                        {
                            Empresa=tbEmpr2.Text,
                            Fecha_desde=dtD2.Value,
                            Fecha_hasta=dtH2.Value,
                            Salario= Convert.ToDecimal(tbSalario2.Text),
                            Puesto=tbPuesto2.Text,
                            IdCandidato=idcandida,
                        },
                          new Experiencia
                        {
                            Empresa=tbEmpr3.Text,
                            Fecha_desde=dtD3.Value,
                            Fecha_hasta=dtH3.Value,
                            Salario= Convert.ToDecimal(tbSalario3.Text),
                            Puesto=tbPuesto3.Text,
                            IdCandidato=idcandida,
                        }
                    };
                case 4:
                    return new List<Experiencia>
                    {
                        new Experiencia
                        {
                            Empresa=tbEmpr1.Text,
                            Fecha_desde=dtD1.Value,
                            Fecha_hasta=dtH1.Value,
                            Salario= Convert.ToDecimal(tbSalario1.Text),
                            Puesto=tbPuesto1.Text,
                            IdCandidato=idcandida,
                        },
                         new Experiencia
                        {
                            Empresa=tbEmpr2.Text,
                            Fecha_desde=dtD2.Value,
                            Fecha_hasta=dtH2.Value,
                            Salario= Convert.ToDecimal(tbSalario2.Text),
                            Puesto=tbPuesto2.Text,
                            IdCandidato=idcandida,
                        },
                          new Experiencia
                        {
                            Empresa=tbEmpr3.Text,
                            Fecha_desde=dtD3.Value,
                            Fecha_hasta=dtH3.Value,
                            Salario= Convert.ToDecimal(tbSalario3.Text),
                            Puesto=tbPuesto3.Text,
                            IdCandidato=idcandida,
                        },
                          new Experiencia
                        {
                            Empresa=tbEmpr4.Text,
                            Fecha_desde=dtD4.Value,
                            Fecha_hasta=dtH4.Value,
                            Salario= Convert.ToDecimal(tbSalario4.Text),
                            Puesto=tbPuesto4.Text,
                            IdCandidato=idcandida,
                        }
                    };
                default:
                    return new List<Experiencia>();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var result = db.DeleteCandidato(idcandida);
            if (result == 200)
            {
                MessageBox.Show("Proceso abortado.");
                Close();
            }
            else
            {
                MessageBox.Show("Proceso abortado.");
                Close();
            }

        }

        private bool isValid3()
        {
            bool valid = false;
            if (tbEmpr1.Text != "" && tbPuesto1.Text != ""
               && tbSalario1.Text != "" && Convert.ToInt32(tbSalario1.Text)<0)
            {
                valid = true;
            }
            return valid;
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            if (isValid3())
            {
                var response = db.AddExperiencia(ExperienciasList());

                if (response == 200)
                {
                    MessageBox.Show("Formulario llenado exitosamente, espere por respuesta.");
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Complete los campos.");
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
