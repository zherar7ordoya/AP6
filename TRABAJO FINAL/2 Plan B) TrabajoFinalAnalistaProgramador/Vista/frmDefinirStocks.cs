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
    public partial class frmDefinirStocks : Form
    {
        BLL_Articulo oBLLArticulo;
        E_Articulo oArticulo;
        public frmDefinirStocks()
        {
            InitializeComponent();
            Controlador_Vista.VistaDefinirStocks _vc = new Controlador_Vista.VistaDefinirStocks(this);
            oBLLArticulo = new BLL_Articulo();
            oArticulo = new E_Articulo();
        }

        private void frmDefinirStocks_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                frmAdmInventario frmAdmInventario = new frmAdmInventario();
                frmAdmInventario.Show();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_DefinirConsumo_Click(object sender, EventArgs e)
        {
            try
            {
                frmDefinir_ConsumoPromedioDiario consumoPromedioDiario = new frmDefinir_ConsumoPromedioDiario();

                consumoPromedioDiario.lbl_CodigoArticulo.Text = lbl_Codigo.Text;
                consumoPromedioDiario.Show();                
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        //Boton Guardar stocks.
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Asigno al objeto los demas valores, para luego llamar el metodo BLL modificar. De esta manera se refrescan los valores del articulo.
                oArticulo.Codigo = lbl_Codigo.Text;
                oArticulo.Descripcion = lbl_Descripcion.Text;
                oArticulo.oMarca.Codigo = int.Parse(lbl_Marca.Text);
                oArticulo.Talle = lbl_Talle.Text;
                oArticulo.Existencia = int.Parse(lbl_Existencia.Text);
                oArticulo.stockMin = int.Parse(txt_StockMin1.Text.ToString());
                oArticulo.stockMax = int.Parse(txt_StockMax.Text.ToString());
                oArticulo.precioCosto = decimal.Parse(lbl_PrecioCosto.Text);
                oArticulo.precioVenta = decimal.Parse(lbl_PrecioVenta.Text);
                oArticulo.precioPromocion = decimal.Parse(lbl_PrecioProm.Text);
                oArticulo.oProveedor.Id = int.Parse(lbl_Proveedor.Text);
                oArticulo.oEmpleado.Dni = int.Parse(lbl_Empleado.Text);

                oBLLArticulo.Modificar(oArticulo);
                //Aviso.
                MessageBox.Show("Stock mínimo y máximo almacenados con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Cierro el form.
                this.Close();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
