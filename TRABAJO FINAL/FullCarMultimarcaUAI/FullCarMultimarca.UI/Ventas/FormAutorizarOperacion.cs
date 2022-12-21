using FullCarMultimarca.BE.Parametros;
using FullCarMultimarca.BE.Ventas;
using FullCarMultimarca.BLL;
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
    public partial class FormAutorizarOperacion : Form
    {
        public FormAutorizarOperacion(Operacion operacion)
        {
            _operacion = operacion;
            _autorizable = BLLOperacion.ObtenerInstancia();
            InitializeComponent();
        }

        private Operacion _operacion;
        private FlagsVentas _flagsVentas;
        private bool _operacionAPerdida = false;
        private IAutorizable<Operacion> _autorizable;

        private void FormAutorizarOperacion_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_operacion == null)
                    throw new NegocioException("No se encontró la operación asociada.");

                if (_operacion.Anulada)
                    throw new NegocioException("La operación está anulada.");

                if (_operacion.Estado != Operacion.EstadoOperacion.Pendiente)
                    throw new NegocioException("La operación debe estar pendiente para poder Autorizarse.");

                if(!Ticket.TienePermiso(ConstPermisos.OPERACION_AUTORIZAR))
                    throw new NegocioException("No tiene permisos de autorizar operaciones.");

                _flagsVentas = BLLFlagsVentas.ObtenerInstancia().Leer();

                if(_flagsVentas == null)
                    throw new NegocioException("No se lograron obtener los parámetros de venta de la aplicación.");

                BindearInformacionAutorizacion();               

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
        private void btnRechazar_Click(object sender, EventArgs e)
        {            
            try
            {
                if (String.IsNullOrWhiteSpace(txtNotaRechazo.Text) || txtNotaRechazo.Text.Length < 3)
                    throw new NegocioException("Es obligatorio ingresar el motivo de rechazo (al menos 3 caractéres)");


                this.Cursor = Cursors.WaitCursor;
                _operacion.NotaRechazo = txtNotaRechazo.Text;
                _autorizable.Rechazar(_operacion);
                this.Close();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnAutorizar_Click(object sender, EventArgs e)
        {
            try
            {                
                if (_operacionAPerdida)
                {
                    if (MostrarMensaje.Pregunta("¿Confirma la autorización de esta operación? (El precio de la unidad NO cubre el valor mínimo de venta)\nEsta acción NO podrá deshacerse.") != DialogResult.Yes)
                        return;
                }
                this.Cursor = Cursors.WaitCursor;
                _autorizable.Autorizar(_operacion, _operacionAPerdida);
                this.Close();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BindearInformacionAutorizacion()
        {
            decimal cobertura =  BLLStock.ObtenerInstancia().CalcularCobertura(_operacion.Unidad.ImporteCompra, _flagsVentas.PorcentajeCoberturaARecuperar / 100);
            decimal tasaIva = BLLModelo.ObtenerInstancia(_operacion.Unidad.Modelo).ObtenerTasaIVA();
            decimal valMinimoVenta =  BLLStock.ObtenerInstancia().ObtenerValorMinimoVenta(_operacion.Unidad, cobertura);
            decimal precioUnidad = _operacion.PrecioUnidad;

            txtNroOperacion.Text = _operacion.ToString();           
            txtVendedor.Text = _operacion.UsuarioVendedor.ToString();
            txtModelo.Text = _operacion.Unidad.Modelo.ToString();
            txtColor.Text = _operacion.Unidad.Color.ToString();
            txtChasis.Text = _operacion.Unidad.Chasis;
            txtCliente.Text = _operacion.Cliente.ToString();
            txtImpCompra.Text = _operacion.Unidad.ImporteCompra.ToString("c2");
            txtPorCobertura.Text = (_flagsVentas.PorcentajeCoberturaARecuperar / 100).ToString("p2");
            txtValorCobertura.Text = cobertura.ToString("c2");
            txtIvaModelo.Text = tasaIva.ToString("p2");
            txtValorIVA.Text = (cobertura * tasaIva).ToString("c2");
            txtValMinVenta.Text = valMinimoVenta.ToString("c2");

            txtPrecioPublico.Text = _operacion.PrecioPublico.ToString("c2");
            txtPrecioUnidad.Text = precioUnidad.ToString("c2");
            txtPauta.Text = _operacion.Pauta.ToString("p2");            
            txtDescuento.Text = _operacion.Descuento.ToString("p2");
            txtDescalce.Text = _operacion.Descalce.ToString("c2");


            _operacionAPerdida = precioUnidad < valMinimoVenta;

            if (!_operacionAPerdida)
            {
                lblSugerenciaAutorizacion.Text = $"{lblSugerenciaAutorizacion.Text} el precio de la unidad cubre el valor mínimo.";
                lblSugerenciaAutorizacion.ForeColor = Color.Blue;
            }
            else
            {
                lblSugerenciaAutorizacion.Text = $"{lblSugerenciaAutorizacion.Text} el precio de la unidad NO cubre el valor mínimo de venta.\nNO se recomienda autorizar.";
                lblSugerenciaAutorizacion.ForeColor = Color.Red;
                txtDifPUnidadVsMinVta.Text = (precioUnidad - valMinimoVenta).ToString("c2");
                txtDifPUnidadVsMinVta.Visible = true;
                lblDifUnidadVsMin.Visible = true;                
            }



        }

        
    }
}
