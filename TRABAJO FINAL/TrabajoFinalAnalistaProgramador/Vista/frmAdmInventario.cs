using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidad;
using BLL;
using Microsoft.VisualBasic;

namespace Vista
{
    public partial class frmAdmInventario : Form
    {
        frmDefinirStocks frmDefinirStocks;
        frmIngresoEgreso frmIngresoEgreso;
        frmTipoArticulo_Ubicacion frmTipoArticulo_Ubicacion;
        frmMovimiento frmMovimiento;
        frmReporteArticulos frmReporteArticulos;
        E_Articulo oArticulo;
        BLL_Articulo oBLLArticulo;
        public frmAdmInventario()
        {
            oBLLArticulo = new BLL_Articulo();
            frmDefinirStocks = new frmDefinirStocks();
            frmIngresoEgreso = new frmIngresoEgreso();
            frmTipoArticulo_Ubicacion = new frmTipoArticulo_Ubicacion();
            frmMovimiento = new frmMovimiento();
            frmReporteArticulos = new frmReporteArticulos();
            oArticulo = new E_Articulo();
            InitializeComponent();
            Controlador_Vista.VistaAdmInventario _vc = new Controlador_Vista.VistaAdmInventario(this, frmDefinirStocks, frmIngresoEgreso, frmTipoArticulo_Ubicacion, frmMovimiento, frmReporteArticulos);
        }

        private void btn_DefinirStocks_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtengo articulo seleccionado en grilla.
                oArticulo = (E_Articulo)dgv_Articulos.CurrentRow.DataBoundItem;

                //Paso los valores para tener los datos del articulo en el nuevo form abierto.
                frmDefinirStocks.lbl_Codigo.Text = oArticulo.Codigo;
                frmDefinirStocks.lbl_Descripcion.Text = oArticulo.Descripcion;
                frmDefinirStocks.lbl_Marca.Text = oArticulo.oMarca.Codigo.ToString();
                frmDefinirStocks.lbl_Talle.Text = oArticulo.Talle;
                frmDefinirStocks.lbl_Existencia.Text = oArticulo.Existencia.ToString();
                frmDefinirStocks.lbl_StockMin.Text = oArticulo.stockMin.ToString();
                frmDefinirStocks.lbl_StockMax.Text = oArticulo.stockMax.ToString();
                frmDefinirStocks.lbl_PrecioCosto.Text = oArticulo.precioCosto.ToString("N2");
                frmDefinirStocks.lbl_PrecioVenta.Text = oArticulo.precioVenta.ToString("N2");
                frmDefinirStocks.lbl_PrecioProm.Text = oArticulo.precioPromocion.ToString("N2");
                frmDefinirStocks.lbl_Proveedor.Text = oArticulo.oProveedor.Id.ToString();
                frmDefinirStocks.lbl_Empleado.Text = oArticulo.oEmpleado.Dni.ToString();
                //Oculto el frmAdmInventario.
                this.Close();
                //Abro el form.
                frmDefinirStocks.Show();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
