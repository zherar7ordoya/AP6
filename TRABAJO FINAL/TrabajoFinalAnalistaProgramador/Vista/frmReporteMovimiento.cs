using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vista
{
    public partial class frmReporteMovimiento : Form
    {
        public frmReporteMovimiento()
        {
            InitializeComponent();
        }

        private void frmReporteMovimiento_Load(object sender, EventArgs e)
        {
            this.report_Movimiento.RefreshReport();
        }

        private void btn_VerInforme_Click(object sender, EventArgs e)
        {
            try
            {
                report_Movimiento.Visible = true;
                //Asigno el valor a las propiedades de los objetos.
                //Creo un vector para los parametros.
                ReportParameter[] parameters = new ReportParameter[8];
                //Asigno valor a cada uno de los parametros.
                parameters[0] = new ReportParameter("parametro_Id", lbl_Id.Text);
                parameters[1] = new ReportParameter("parametro_Articulo", lbl_Articulo.Text);
                parameters[2] = new ReportParameter("parametro_Fecha", lbl_Fecha.Text);
                parameters[3] = new ReportParameter("parametro_Accion", lbl_Accion.Text);
                parameters[4] = new ReportParameter("parametro_Cantidad", lbl_Cantidad.Text);
                parameters[5] = new ReportParameter("parametro_PrecioCosto", lbl_PrecioCosto.Text);
                parameters[6] = new ReportParameter("parametro_PrecioVenta", lbl_PrecioVenta.Text);
                parameters[7] = new ReportParameter("parametro_Empleado", lbl_Empleado.Text);

               
                //Establezco los datasources.
                report_Movimiento.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", parameters));
                report_Movimiento.LocalReport.SetParameters(parameters);
                //Refresco.
                this.report_Movimiento.RefreshReport();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
