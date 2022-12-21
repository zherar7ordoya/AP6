using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Entidad;


namespace Vista
{
    public partial class frmReporteArticuloFaltante : Form
    {
        BLL_Articulo oBLLArticulo;
        frmTerminarReporteArtFaltante frmTerminarReporteArtFaltante;
        E_Articulo oArticulo;
        BLL_Empleado oBLLPersona;

        public frmReporteArticuloFaltante()
        {
            frmTerminarReporteArtFaltante = new frmTerminarReporteArtFaltante();
            oArticulo = new E_Articulo();
            oBLLArticulo = new BLL_Articulo();
            oBLLPersona = new BLL_Empleado();
            InitializeComponent();
            Controlador_Vista.VistaReporteArticuloFaltante _vc = new Controlador_Vista.VistaReporteArticuloFaltante(this);
        }

        
        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                oArticulo = (E_Articulo)dgv_ArticulosFaltantes.CurrentRow.DataBoundItem;

                frmTerminarReporteArtFaltante.lbl_Codigo.Text = oArticulo.Codigo;
                frmTerminarReporteArtFaltante.lbl_NombreArt.Text = oArticulo.Descripcion;
                frmTerminarReporteArtFaltante.lbl_MarcaArt.Text = oArticulo.oMarca.Codigo.ToString();
                frmTerminarReporteArtFaltante.lbl_TalleArt.Text = oArticulo.Talle;
                frmTerminarReporteArtFaltante.lbl_ExistenciaAct.Text = oArticulo.Existencia.ToString();
                frmTerminarReporteArtFaltante.lbl_StockMin.Text = oArticulo.stockMin.ToString();
                frmTerminarReporteArtFaltante.lbl_StockMax.Text = oArticulo.stockMax.ToString();
                frmTerminarReporteArtFaltante.lbl_CantidadComprar.Text = txt_Cantidad.Text;
                frmTerminarReporteArtFaltante.lbl_Proveedor.Text = oArticulo.oProveedor.Id.ToString();
                frmTerminarReporteArtFaltante.lbl_Enpleado.Text = cb_Empleado.Text.ToString();

                if(oBLLArticulo.ValidarStockMax(oArticulo.Existencia, int.Parse(txt_Cantidad.Text)) > oArticulo.stockMax)
                {
                    MessageBox.Show("Esta ingresando un numero mayor al stock maximo del articulo. Vuelva a intentarlo.", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }

                frmTerminarReporteArtFaltante.Show();
                this.Close();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
