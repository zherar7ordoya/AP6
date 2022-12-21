using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Microsoft.Reporting.WinForms;

namespace Controlador_Vista
{
    public class VistaReporteArticulos
    {
        System.Windows.Forms.Form frmReporteArticulos;
        BLL_Articulo oBLLArticulo;
        List<Control> ListaControles;

        public VistaReporteArticulos(Form pForm)
        {
            try
            {
                ListaControles = new List<Control>();
                // Se guarda en una variable privada la referencia al formulario que llega al parámetro del constructor
                frmReporteArticulos = pForm;

                foreach (System.Windows.Forms.Control c in frmReporteArticulos.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }

                ((Button)ListaControles.Find(x => x.Nombre == "btn_Volver").Puntero).Click += btn_Volver_Click;
                frmReporteArticulos.Load += frmReporteArticulos_Load;

                oBLLArticulo = new BLL_Articulo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region "Funciones delegadas de eventos UI"

        private void frmReporteArticulos_Load(object sender, EventArgs e)
        {
            ReportViewer reporteArticulo = (ReportViewer)ListaControles.Find(x => x.Nombre == "report_Articulo").Puntero;
            try
            {
                reporteArticulo.LocalReport.DataSources[0].Value = oBLLArticulo.Listar();
                reporteArticulo.RefreshReport();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            try
            {
                frmReporteArticulos.Close();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        #endregion
    }
}
