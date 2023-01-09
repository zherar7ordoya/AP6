using Microsoft.Reporting.WinForms;
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
    public partial class frmMovimiento : Form
    {
        E_Movimiento oMovimiento;
        frmReporteMovimiento frmReporteMovimiento;

        public frmMovimiento()
        {
            oMovimiento = new E_Movimiento();
            frmReporteMovimiento = new frmReporteMovimiento();
            InitializeComponent();
            Controlador_Vista.VistaMovimiento _vc = new Controlador_Vista.VistaMovimiento(this);
        }

        private void btn_ReporteMovimiento_Click(object sender, EventArgs e)
        {
            try
            {
                oMovimiento = (E_Movimiento)dgv_Movimientos.CurrentRow.DataBoundItem;
                
                frmReporteMovimiento.lbl_Id.Text = oMovimiento.Id.ToString();
                frmReporteMovimiento.lbl_Articulo.Text = oMovimiento.oArticulo.Codigo.ToString();
                frmReporteMovimiento.lbl_Fecha.Text = oMovimiento.Fecha.ToString();
                frmReporteMovimiento.lbl_Accion.Text = oMovimiento.Accion;
                frmReporteMovimiento.lbl_Cantidad.Text = oMovimiento.cantidadMov.ToString();
                frmReporteMovimiento.lbl_PrecioCosto.Text = oMovimiento.precioCostoCalculado.ToString();
                frmReporteMovimiento.lbl_PrecioVenta.Text = oMovimiento.precioVentaCalculado.ToString();
                frmReporteMovimiento.lbl_Empleado.Text = oMovimiento.oEmpleado.Dni.ToString();

                frmReporteMovimiento.ShowDialog();
            }
            catch(Exception ex) {  throw new Exception(ex.Message); }
        }
    }
}
