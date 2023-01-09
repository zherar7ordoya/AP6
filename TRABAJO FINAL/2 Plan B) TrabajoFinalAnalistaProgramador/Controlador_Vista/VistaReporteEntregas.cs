using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using BLL;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Controlador_Vista
{
    public class VistaReporteEntregas
    {
        System.Windows.Forms.Form frmReporteEntregas;
        BLL_Entrega oBLLEntrega;
        List<Control> ListaControles;

        public VistaReporteEntregas(Form pForm)
        {
            try
            {
                ListaControles = new List<Control>();
                // Se guarda en una variable privada la referencia al formulario que llega al parámetro del constructor
                frmReporteEntregas = pForm;

                foreach (System.Windows.Forms.Control c in frmReporteEntregas.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }

                ((Button)ListaControles.Find(x => x.Nombre == "btn_Volver").Puntero).Click += btn_Volver_Click;
                frmReporteEntregas.Load += frmReporteEntregas_Load;

                oBLLEntrega = new BLL_Entrega();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region "Funciones delegadas de eventos UI"

        private void frmReporteEntregas_Load(object sender, EventArgs e)
        {
            ReportViewer reporteMarca = (ReportViewer)ListaControles.Find(x => x.Nombre == "report_Entrega").Puntero;
            try
            {
                reporteMarca.LocalReport.DataSources[0].Value = oBLLEntrega.Listar();
                reporteMarca.RefreshReport();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            try
            {
                frmReporteEntregas.Close();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        #endregion
    }
}
