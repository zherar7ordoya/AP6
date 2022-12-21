using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.BLL.Parametros;
using FullCarMultimarca.BLL.Ventas;
using FullCarMultimarca.Servicios.Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FullCarMultimarca.BLL.Gestion;
using FullCarMultimarca.Abstracciones;

namespace FullCarMultimarca.UI.Ventas
{
    public partial class FormEstablecerOferta : Form
    {
        public FormEstablecerOferta(Unidad unidad)
        {
            _unidad = unidad;            
            InitializeComponent();
        }

        private Unidad _unidad = null;
        

        private void FormEstablecerOferta_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_unidad == null)
                    throw new NegocioException("No se ha encontrado la unidad");

                var fVenta = BLLFlagsVentas.ObtenerInstancia().Leer();
                if (fVenta == null)
                    throw new NegocioException("No se lograron obtener los flags de venta.");

                decimal cobertura = BLLStock.ObtenerInstancia().CalcularCobertura(_unidad.ImporteCompra, fVenta.PorcentajeCoberturaARecuperar / 100);
                decimal tasaIva = BLLModelo.ObtenerInstancia(_unidad.Modelo).ObtenerTasaIVA();
                decimal vMinimoVenta = BLLStock.ObtenerInstancia().ObtenerValorMinimoVenta(_unidad, cobertura);

                txtModelo.Text = _unidad.Modelo.Descripcion;
                txtColor.Text = _unidad.Color.Descripcion;
                txtChasis.Text = _unidad.Chasis;

                if(_unidad.OfertaVigente)
                {
                    txtOfertaActual.Text = _unidad.Oferta?.ToString("c2");
                    txtVtoOfertaActual.Text = _unidad.VencimientoOferta?.ToString("dd/MM/yyyy");
                }

                txtFCompra.Text = _unidad.FechaCompra.ToString("dd/MM/yyyy");
                txtImpCompra.Text = _unidad.ImporteCompra.ToString("c2");
                txtPrecioPublico.Text = _unidad.Modelo.PrecioPublico.ToString("c2");
                txtPorCobertura.Text = (fVenta.PorcentajeCoberturaARecuperar/100).ToString("p2");
                txtValorCobertura.Text = cobertura.ToString("c2");
                txtIvaModelo.Text = tasaIva.ToString("p2");
                txtValorIVA.Text = (cobertura * tasaIva).ToString("c2");
                txtValMinVenta.Text = vMinimoVenta.ToString("c2");

                txtOferta.Value = _unidad.Modelo.PrecioPublico;


                if (_unidad.Modelo.PrecioPublico < vMinimoVenta)
                    lblInfoInconsistencia.Visible = true;

            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
                this.Close();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEstablecerOferta_Click(object sender, EventArgs e)
        {
            try
            {
                if (_unidad.OfertaVigente)
                {
                    if (MostrarMensaje.Pregunta("La unidad tiene oferta vigente. Si continúa La misma será reemplazada por la nueva que está cargando.\n¿Desea continuar?") != DialogResult.Yes)
                        return;
                }
                BLLStock.ObtenerInstancia().PonerEnOfertaUnidad(_unidad, txtOferta.Value, txtVtoOferta.Value);
                MostrarMensaje.Informacion("Unidad puesta en oferta correctamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
    }
}
