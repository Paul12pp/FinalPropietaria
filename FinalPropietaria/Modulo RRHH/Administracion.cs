using System;
using System.Windows.Forms;

namespace FinalPropietaria
{
    public partial class Administracion : Form
    {
        private int childFormNumber = 0;

        public Administracion(string name)
        {
            InitializeComponent();
            statusName.Text =$"Bienvenido, {name}.";
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_Puesto puesto = new Form_Puesto
            {
                MdiParent = this
            };
            puesto.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form_Idioma idioma = new Form_Idioma();
            idioma.MdiParent = this;
            idioma.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form_Empleado empleado = new Form_Empleado();
            empleado.MdiParent = this;
            empleado.Show();
        }

        private void competenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Competencia compet = new Form_Competencia();
            compet.MdiParent = this;
            compet.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void viewMenu_Click(object sender, EventArgs e)
        {
            Form_Consulta cons = new Form_Consulta();
            cons.MdiParent = this;
            cons.Show();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Reporte rp = new Form_Reporte();
            rp.MdiParent = this;
            rp.Show();
        }

        private void editMenu_Click(object sender, EventArgs e)
        {
            Form_Seleccion sl = new Form_Seleccion();
            sl.MdiParent = this;
            sl.Show();
        }

        private void Administracion_Load(object sender, EventArgs e)
        {

        }
    }
}
