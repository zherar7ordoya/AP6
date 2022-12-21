using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.BE.Parametros;
using FullCarMultimarca.BLL.Gestion;
using FullCarMultimarca.BLL.Parametros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FullCarMultimarca.UI.Base;
using FullCarMultimarca.Abstracciones;

namespace FullCarMultimarca.UI.Parametros
{
    public partial class FormParametrosVentas : FormEditorBase<FlagsVentas>
    {
        public FormParametrosVentas(FlagsVentas parametros) : base(parametros)
        {
            InitializeComponent();
        }

        private IAbmc<FormaPago> _abmcFormaPago = BLLFormaPago.ObtenerInstancia();

        protected override void IniciarFormulario()
        {

            CargarCombo();

            txtPorcCobARecup.Value = _elemento.PorcentajeCoberturaARecuperar;
            txtPorGstPatentamiento.Value = _elemento.PorcentajeGastoPatentamiento;
            txtMesesRetroPauta.Value = _elemento.DiasRetroactivoDeterminacionPauta;
            txtDestinatarioVencOfertas.Text = _elemento.DestinatariosNotificacionVencimientoOfertas;
            txtDestinatariosAutPerdida.Text = _elemento.DestinatariosNotificacionAutorizacionAPerdida;
            txtTasaIVAPickUp.Value = _elemento.TasaIVAModelosPickUp;
            txtTasaIVAResto.Value = _elemento.TasaIVAModelosResto;
            if(_elemento.FormaPagoContadoDefault != null)
                cmbFormasPagoContado.SelectedItem = _elemento.FormaPagoContadoDefault;

        }
        protected override void GuardarCambios()
        {

            _elemento.PorcentajeCoberturaARecuperar = txtPorcCobARecup.Value;
            _elemento.PorcentajeGastoPatentamiento = txtPorGstPatentamiento.Value;
            _elemento.DiasRetroactivoDeterminacionPauta = (int)txtMesesRetroPauta.Value;
            _elemento.DestinatariosNotificacionVencimientoOfertas = txtDestinatarioVencOfertas.Text;
            _elemento.DestinatariosNotificacionAutorizacionAPerdida = txtDestinatariosAutPerdida.Text;
            _elemento.FormaPagoContadoDefault = cmbFormasPagoContado.SelectedItem as FormaPagoContado;
            _elemento.TasaIVAModelosPickUp = txtTasaIVAPickUp.Value;
            _elemento.TasaIVAModelosResto = txtTasaIVAResto.Value;

            BLLFlagsVentas.ObtenerInstancia().Guardar(_elemento);

            MostrarMensaje.Informacion("Parámetros de venta actualizados.");
        }

        private void CargarCombo()
        {
            IList<FormaPago> fpago = _abmcFormaPago.ObtenerTodos();
            UtilUI.ObtenerInstancia().CargarComboDesdeList(cmbFormasPagoContado, fpago.Where(fp => fp.GetType().Equals(typeof(FormaPagoContado))), true, "<Seleccione...>");
            cmbFormasPagoContado.SelectedIndex = 0;
        }
    }
}
