using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidad;
using Microsoft.Reporting.WinForms;

namespace Vista
{
    public partial class frmTerminarReporteArtFaltante : Form
    {
        public frmTerminarReporteArtFaltante()
        {
            InitializeComponent();
        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                //Hago visible el reporte.
                reportViewer1.Visible = true;
                //Creo un vector para los parametros.
                ReportParameter[] parameters = new ReportParameter[10];
                //Asigno valor a cada uno de los parametros.
                parameters[0] = new ReportParameter("parametro_CodigoArt", lbl_Codigo.Text);
                parameters[1] = new ReportParameter("parametro_NombreArt", lbl_NombreArt.Text);
                parameters[2] = new ReportParameter("parametro_Marca", lbl_MarcaArt.Text);
                parameters[3] = new ReportParameter("parametro_Talle", lbl_TalleArt.Text);
                parameters[4] = new ReportParameter("parametro_Existencia", lbl_ExistenciaAct.Text);
                parameters[5] = new ReportParameter("parametro_StockMin", lbl_StockMin.Text);
                parameters[6] = new ReportParameter("parametro_StockMax", lbl_StockMax.Text);
                parameters[7] = new ReportParameter("parametro_Cantidad", lbl_CantidadComprar.Text);
                parameters[8] = new ReportParameter("parametro_NombreProv", lbl_Proveedor.Text);
                parameters[9] = new ReportParameter("parametro_Empleado", lbl_Enpleado.Text);

                //Establezco los datasources.
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", parameters));
                //Añado los parametros.
                reportViewer1.LocalReport.SetParameters(parameters);
                //Refresco.
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void frmTerminarReporteArtFaltante_Load(object sender, EventArgs e)
        {
           
            this.reportViewer1.RefreshReport();
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
