using FinalPropietaria.Interfaces;
using Microsoft.Reporting.WinForms;
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
    public partial class Form_Reporte : Form
    {
        EmpleadoRepos db = new EmpleadoRepos(new Models.RRHH_PropietariaEntities());
        public Form_Reporte()
        {
            InitializeComponent();
            //dataGridView1.DataSource = db.GetEmpleados();
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinalPropietaria.Reportes.Report1.rdlc";
            ReportDataSource rds1 = new ReportDataSource("DataSet1", db.GetEmpleados());
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds1);
            this.reportViewer1.RefreshReport();

        }

        private void Form_Reporte_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            var rs = db.Search(dtD.Value, dtH.Value);
            //dataGridView1.DataSource = rs;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinalPropietaria.Reportes.Report1.rdlc";
            ReportDataSource rds1 = new ReportDataSource("DataSet1", rs);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds1);
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinalPropietaria.Reportes.Report1.rdlc";
            ReportDataSource rds1 = new ReportDataSource("DataSet1", db.GetEmpleados());
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds1);
            this.reportViewer1.RefreshReport();
        }
    }
}
