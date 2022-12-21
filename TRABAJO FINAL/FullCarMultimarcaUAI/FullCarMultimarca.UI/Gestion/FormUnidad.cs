using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.BLL.Gestion;
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
using FullCarMultimarca.BLL.Ventas;
using FullCarMultimarca.Abstracciones;

namespace FullCarMultimarca.UI.Gestion
{
    public partial class FormUnidad : FormEditorBase<Unidad>
    {
        public FormUnidad()
        {
            InitializeComponent();
        }
        public FormUnidad(Unidad unidad) : base(unidad)
        {
            InitializeComponent();
        }

        private string _valorChasisAnterior = null;
        private IAbmc<Unidad> _abmc = BLLUnidad.ObtenerInstancia();
        private IAbmc<ColorUnidad> _abmcColor = BLLColorUnidad.ObtenerInstancia();
        private IAbmc<Modelo> _abmcModelo = BLLModelo.ObtenerInstancia<ModeloResto>();

        protected override void IniciarFormulario()
        {
            if (!_esAlta && _elemento == default)
                throw new NegocioException("No se encontró el elemento a modificar");

            CargarCombos();

            _controlesAExcluirProcesamientoSoloLectura.Add(grupoOferta);
            _controlesAExcluirProcesamientoSoloLectura.Add(ckDisponible);
            _controlesAExcluirProcesamientoSoloLectura.Add(cmbModelo);
            //_controlesAExcluirProcesamientoSoloLectura.Add(txtImporteCompra);
            //_controlesAExcluirProcesamientoSoloLectura.Add(txtFechaCompra);
            _controlesAExcluirProcesamientoSoloLectura.Add(btnCancelar);

                        
            txtChasis.MostrarBotonDeshacer = true;
            txtChasis.MensajeErrorValidacion = "El valor de chasis ingresado es inválido.\nDebe contener solo letras y números, exactamente 17 posiciones.";
            txtChasis.RegularValidacion = BLL.Util.PatronValidacionCHASIS;
            txtChasis.OnTextoModificado += txtChasis_ActualizarCantidadCaracteres;

            txtFechaCompra.Value = DateTime.Today.Date;

            if (!_esAlta)
            {
                txtChasis.Text = _elemento.Chasis;
                cmbModelo.SelectedItem = _elemento.Modelo;
                cmbColor.SelectedItem = _elemento.Color;
                txtFechaCompra.Value = _elemento.FechaCompra;
                txtImporteCompra.Value = _elemento.ImporteCompra;
                ckDisponible.Checked = _elemento.Disponible;
                if(_elemento.Oferta.HasValue)
                    txtOfertaActual.Text = _elemento.Oferta.Value.ToString("c2");
                if (_elemento.VencimientoOferta.HasValue)
                    txtVtoOfertaActual.Text = _elemento.VencimientoOferta.Value.ToString("dd/MM/yyyy");                

                if (!_elemento.Disponible)
                {
                    SoloLectura = true;
                    lblUnidadVendida.Visible = true;
                }
                else if(_elemento.OfertaVigente)
                {
                    cmbModelo.Enabled = false;
                    txtImporteCompra.ReadOnly = true;                    
                    txtFechaCompra.Enabled = false;
                    lblInfoModificacion.Visible = true;
                }

                _valorChasisAnterior = _elemento.Chasis;

            }        
        }
        protected override void GuardarCambios()
        {
            //Actualizamos el objeto            
            if (!txtImporteCompra.TryGetValue(out decimal costo))
                throw new NegocioException("No se pudo interpretar el valor del precio de compra.");


            if (_esAlta)
                _elemento = new Unidad();

            _elemento.Chasis = txtChasis.Text;            
            _elemento.Modelo = cmbModelo.SelectedItem as Modelo;
            _elemento.Color = cmbColor.SelectedItem as ColorUnidad;
            _elemento.FechaCompra = txtFechaCompra.Value;
            _elemento.ImporteCompra = costo;

            if (_esAlta)
            {
                _abmc.Agregar(_elemento);
                MostrarMensaje.Informacion("Unidad agregada exitosamente.");
            }
            else
            {
                _abmc.Modificar(_elemento, _valorChasisAnterior);
                MostrarMensaje.Informacion("Unidad modificada exitosamente");
            }
        }

        private void CargarCombos()
        {
            var queryModelo = from m in _abmcModelo.ObtenerTodos()
                        where m.Activo == true || (_elemento != null && !(_elemento.Modelo == null) && m.Equals(_elemento.Modelo))
                        orderby m
                        select m;
            UtilUI.ObtenerInstancia().CargarComboDesdeList(cmbModelo, queryModelo, true,"<Seleccione...>");
            cmbModelo.SelectedIndex = 0;
            var queryColores = from c in _abmcColor.ObtenerTodos()
                              where c.Activo == true || (_elemento != null && !(_elemento.Color == null) && c.Equals(_elemento.Color))
                              orderby c
                              select c;
            UtilUI.ObtenerInstancia().CargarComboDesdeList(cmbColor, queryColores.ToList(), true, "<Seleccione...>");
            cmbColor.SelectedIndex = 0;
        }

        private void cmbModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var modeloSeleccionado = cmbModelo.SelectedItem as Modelo;
            if (modeloSeleccionado == null)
                txtPrecioPublicVigente.Value = 0;
            else
            {
                txtPrecioPublicVigente.Value = modeloSeleccionado.PrecioPublico;
            }

        }

        private void txtChasis_ActualizarCantidadCaracteres(object sender, EventArgs e)
        {
            lblLargoVIN.Text = $"Largo Chasis: {txtChasis.Text.Length}";
        }

        private void txtChasis_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
