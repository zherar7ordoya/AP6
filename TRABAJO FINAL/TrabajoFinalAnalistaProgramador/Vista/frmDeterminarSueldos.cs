using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidad;

namespace Vista
{
    public partial class frmDeterminarSueldos : Form
    {
        E_SueldoNeto oSueldoNeto;

        public frmDeterminarSueldos()
        {
            try
            {
                oSueldoNeto = new E_SueldoNeto();
                InitializeComponent();
                Controlador_Vista.VistaDeterminarSueldo _vc = new Controlador_Vista.VistaDeterminarSueldo(this);
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_ReporteSueldoNeto_Click(object sender, EventArgs e)
        {
            frmReporteSueldoNetos frmReporteSueldoNetos = new frmReporteSueldoNetos();

            try
            {
                //Obtengo el sueldo seleccionado.
                oSueldoNeto = (E_SueldoNeto)dgv_SueldosNetos.CurrentRow.DataBoundItem;
                //Lo añado a la lista del form reporte de sueldos.
                frmReporteSueldoNetos.sueldos.Add(oSueldoNeto);
                //Muestro el nuevo form.
                frmReporteSueldoNetos.Show();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
