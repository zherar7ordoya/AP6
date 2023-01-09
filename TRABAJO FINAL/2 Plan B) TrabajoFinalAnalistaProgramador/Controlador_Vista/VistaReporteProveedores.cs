using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Microsoft.Reporting.WinForms;

namespace Controlador_Vista
{
    public class VistaReporteProveedores
    {
        System.Windows.Forms.Form frmReporteProveedores;
        BLL_Proveedor oBLLProveedor;
        List<Control> ListaControles;

        public VistaReporteProveedores(Form pForm)
        {
            try
            {
                ListaControles = new List<Control>();
                // Se guarda en una variable privada la referencia al formulario que llega al parámetro del constructor
                frmReporteProveedores = pForm;

                foreach (System.Windows.Forms.Control c in frmReporteProveedores.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }

                ((Button)ListaControles.Find(x => x.Nombre == "btn_Volver").Puntero).Click += btn_Volver_Click;
                frmReporteProveedores.Load += frmReporteProveedores_Load;

                oBLLProveedor = new BLL_Proveedor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region "Funciones delegadas de eventos UI"

        private void frmReporteProveedores_Load(object sender, EventArgs e)
        {
            ReportViewer reporteArticulo = (ReportViewer)ListaControles.Find(x => x.Nombre == "report_Proveedor").Puntero;
            try
            {
                reporteArticulo.LocalReport.DataSources[0].Value = oBLLProveedor.Listar();
                reporteArticulo.RefreshReport();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            try
            {
                frmReporteProveedores.Close();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        #endregion
    }
}
