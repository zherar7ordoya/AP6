using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.BE.Parametros;
using FullCarMultimarca.BE.Ventas;
using FullCarMultimarca.BLL;
using FullCarMultimarca.BLL.Gestion;
using FullCarMultimarca.BLL.Parametros;
using FullCarMultimarca.BLL.Ventas;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.UI.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullCarMultimarca.UI.Ventas
{
    public partial class FormOperacion : Form
    {
        public FormOperacion(Operacion operacion)
        {
            _operacion = operacion;
            _esNueva = operacion.Numero == null;
            InitializeComponent();
        }

        private bool _esNueva = false;
        private Operacion _operacion = null;
        private bool _soloLectura = false;

        private IAbmc<Cliente> _abmcCliente = BLLCliente.ObtenerInstancia();

        private void FormOperacion_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_operacion.Unidad == null)
                    throw new NegocioException("La venta debe contener una unidad.");

                if (_operacion.Anulada
                    || _operacion.Estado == Operacion.EstadoOperacion.Autorizada
                    || !_esNueva && !Ticket.TienePermiso(ConstPermisos.OPERACION_MODIFICAR_VENTA))
                    EstablecerSoloLectura();

               
                InicializarControlCliente();
                CargarCombos();
                BindearOperacion();
                SuscripcionEventos();

                if (_operacion.EsOferta)
                {
                    txtPrecioUnidad.ReadOnly = true;
                    lblUnidadEnOferta.Visible = true;
                }

                ActualizarLabelContadoMinimo();
                ActualizarLabelBalanceo();

                if (_operacion.Anulada)
                    lblOperacionAnulada.Visible = true;

                if (_operacion.Estado == Operacion.EstadoOperacion.Rechazada
                    && !String.IsNullOrWhiteSpace(_operacion.NotaRechazo))
                    toolTip1.SetToolTip(imgInfoRechazo, _operacion.NotaRechazo);

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
        private void TxtPrecioUnidad_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _operacion.PrecioUnidad = txtPrecioUnidad.Value;
                RecalcularYRebindear();
              
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void CmbPatentaEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _operacion.PatentaEmpresa = (bool)cmbPatentaEmpresa.SelectedValue;
                RecalcularYRebindear();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void btnAgregarFPago_Click(object sender, EventArgs e)
        {
            AgregarFormaPago();
        }
        private void btnModificarFPago_Click(object sender, EventArgs e)
        {
            ModificarFormaPago();
        }
        private void grillaFormasPago_DoubleClick(object sender, EventArgs e)
        {
            ModificarFormaPago();
        }
        private void btnEliminarFPago_Click(object sender, EventArgs e)
        {
            EliminarFormaPago();
        }
        private void btnABOperacion_Click(object sender, EventArgs e)
        {
            if (_soloLectura)
                return;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                //El unico valor no bindable on the fly es el cliente
                _operacion.Cliente = buscadorCliente1.ClienteSeleccionado;

                string mensajeRespuesta = "";

                if (_esNueva)
                    mensajeRespuesta = BLLOperacion.ObtenerInstancia().AltaOperacion(_operacion);
                else
                    mensajeRespuesta = BLLOperacion.ObtenerInstancia().ModificarOperacion(_operacion);


                MostrarMensaje.Informacion(mensajeRespuesta);
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


        private void InicializarControlCliente()
        {
            if (!_soloLectura)
            {
                var listaClientes = _abmcCliente.ObtenerTodos();
                buscadorCliente1.CacheClientes = listaClientes;
            }
            buscadorCliente1.ClienteSeleccionado = _operacion.Cliente;
        }      
        private void CargarCombos()
        {
            List<OpcionesPatentaEmpresa> opcionesPatentaEmpresas = 
                new List<OpcionesPatentaEmpresa> {
                    new OpcionesPatentaEmpresa { ValueMember = false, DisplayMember = "NO"}, new OpcionesPatentaEmpresa { ValueMember = true, DisplayMember = "SI"}};

            cmbPatentaEmpresa.DataSource = opcionesPatentaEmpresas;
            cmbPatentaEmpresa.ValueMember = "ValueMember";
            cmbPatentaEmpresa.DisplayMember = "DisplayMember";

            if (cmbPatentaEmpresa.Items.Count > 0)
                cmbPatentaEmpresa.SelectedIndex = 0;
        }
        private void BindearOperacion()
        {
            txtNroOperacion.Text = _operacion.ToString();
            txtEstado.Text = _operacion.Estado.ToString();
            txtVendedor.Text = _operacion.UsuarioVendedor.ToString();
            txtModelo.Text = _operacion.Unidad.Modelo.ToString();
            txtColor.Text = _operacion.Unidad.Color.ToString();
            txtChasis.Text = _operacion.Unidad.Chasis;
            txtPrecioPublico.Text = _operacion.PrecioPublico.ToString("c2");
            if (_operacion.EsOferta)
                txtOferta.Text = _operacion.Unidad.Oferta.Value.ToString("c2");
            else
                txtOferta.Text = "[SIN OFERTA]";
            txtPauta.Text = _operacion.Pauta.ToString("p2");

            buscadorCliente1.ClienteSeleccionado = _operacion.Cliente;
            txtPrecioUnidad.Value = _operacion.PrecioUnidad;
            cmbPatentaEmpresa.SelectedValue = _operacion.PatentaEmpresa;
            txtDescuento.Text = _operacion.Descuento.ToString("p2");
            txtDescalce.Text = _operacion.Descalce.ToString("c2");
            lblPorcGestoria.Text = _operacion.PorcentajeGastoGestoria.ToString("p2");
            txtGastoGestoria.Text = _operacion.GastoGestoria.ToString("c2");
            txtGastoFinanciacion.Text = _operacion.GastoFinanciacion.ToString("c2");
            txtGastoUsado.Text = _operacion.GastoUsado.ToString("c2");                        
            txtPrecioFinal.Text = _operacion.PrecioFinal.ToString("c2");

            txtPagosTotales.Text = _operacion.ObtenerFormasDePago().Sum(p => p.Importe).ToString("c2");

            ActualizarGrillaFormasPago();

        }
        private void ActualizarGrillaFormasPago()
        {
            grillaFormasPago.DataSource = null;
            if (_operacion.ObtenerFormasDePago().Count > 0)
            {
                grillaFormasPago.DataSource = _operacion.ObtenerFormasDePago();
            }
            if (grillaFormasPago.Columns.Count > 0)
            {
                grillaFormasPago.Columns["Operacion"].Visible = false;
                grillaFormasPago.Columns["Modificable"].Visible = false;
                grillaFormasPago.Columns["ArancelGasto"].Visible = false;
                grillaFormasPago.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grillaFormasPago.Columns["Importe"].DefaultCellStyle.Format = "c2";
            }
        }
        private void SuscripcionEventos()
        {
            if (_soloLectura)
                return;

            cmbPatentaEmpresa.SelectedIndexChanged += CmbPatentaEmpresa_SelectedIndexChanged;
            txtPrecioUnidad.TextChanged += TxtPrecioUnidad_TextChanged;
        }
        private void RecalcularYRebindear()
        {        
            
            BLLOperacion.ObtenerInstancia().AjustarFormaPago(_operacion);

            txtDescuento.Text = _operacion.Descuento.ToString("p2");
            txtDescalce.Text = _operacion.Descalce.ToString("c2");
            txtGastoGestoria.Text = _operacion.GastoGestoria.ToString("c2");
            txtGastoFinanciacion.Text = _operacion.GastoFinanciacion.ToString("c2");
            txtGastoUsado.Text = _operacion.GastoUsado.ToString("c2");
            txtPrecioFinal.Text = _operacion.PrecioFinal.ToString("c2");

            txtPagosTotales.Text = _operacion.ObtenerFormasDePago().Sum(p => p.Importe).ToString("c2");

            ActualizarLabelContadoMinimo();
            ActualizarLabelBalanceo();
            ActualizarGrillaFormasPago(); 
        }
        private void ActualizarLabelContadoMinimo()
        {
            lblContadoMinimo.Text = $"Contado mínimo: {_operacion.GastoFinanciacion+_operacion.GastoUsado:c2}";
        }
        private void ActualizarLabelBalanceo()
        {
            var desbalanceo = _operacion.PrecioFinal - _operacion.ObtenerFormasDePago().Sum(p => p.Importe);

            lblOperacionBalanceada.Text = $"DESBALANCEO {desbalanceo:c2}";
            lblOperacionBalanceada.Visible = desbalanceo != 0;
        }
        private void AgregarFormaPago()
        {
            if (_soloLectura)
                return;

            try
            {
                FormOperacionFormaPago fopFPago = new FormOperacionFormaPago(_operacion);
                fopFPago.ShowDialog();                
                RecalcularYRebindear();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void ModificarFormaPago()
        {
            if (_soloLectura)
                return;

            try
            {
                var opFPago = UtilUI.ObtenerInstancia().ObtenerObjetoDesdeGrilla<OperacionFormaPago>(grillaFormasPago);
                if (opFPago != null)
                {
                    if (!opFPago.Modificable)
                        return;

                    FormOperacionFormaPago fopFPago = new FormOperacionFormaPago(opFPago);
                    fopFPago.ShowDialog();                    
                    RecalcularYRebindear();
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void EliminarFormaPago()
        {
            if (_soloLectura)
                return;

            try
            {
                var opFPago = UtilUI.ObtenerInstancia().ObtenerObjetoDesdeGrilla<OperacionFormaPago>(grillaFormasPago);
                if (opFPago != null)
                {
                    if (!opFPago.Modificable)
                        return;

                    if (MostrarMensaje.Pregunta($"¿Desea eliminar la forma de pago {opFPago.FormaPago}?") == DialogResult.Yes)
                    {
                        _operacion.EliminarFormaDePago(opFPago);                        
                        RecalcularYRebindear();
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }       
        private void EstablecerSoloLectura()
        {
            _soloLectura = true;
            buscadorCliente1.EstablecerSoloLectura();
            txtPrecioUnidad.ReadOnly = true;
            cmbPatentaEmpresa.Enabled = false;
            btnAgregarFPago.Enabled = false;
            btnModificarFPago.Enabled = false;
            btnEliminarFPago.Enabled = false;
            btnABOperacion.Enabled = false;
        }

        class OpcionesPatentaEmpresa
        {
            public bool ValueMember { get; set; }
            public string DisplayMember { get; set; }
        }

       
    }
}
