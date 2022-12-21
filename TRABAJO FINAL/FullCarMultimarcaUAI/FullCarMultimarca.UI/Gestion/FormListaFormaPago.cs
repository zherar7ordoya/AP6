using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.BLL.Gestion;
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
using FullCarMultimarca.Vistas;
using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.Servicios.Extensiones;

namespace FullCarMultimarca.UI.Gestion
{
    public partial class FormListaFormaPago : FormListaBase
    {
        private FormListaFormaPago()
        {
            InitializeComponent();
        }
        private static FormListaFormaPago _instancia;
        private IAbmc<FormaPago, VistaFormaPago> _abmcVista = BLLFormaPago.ObtenerInstancia();
        public static FormListaFormaPago ObtenerInstancia()
        {
            if (_instancia == null)
                _instancia = new FormListaFormaPago();
            if (_instancia.IsDisposed)
                _instancia = new FormListaFormaPago();
            return _instancia;
        }

        protected override void IniciarFormulario()
        {
            CargarCriteriosBusqueda(new List<ConsultaCriterio> {  
                new ConsultaCriterio(nameof(FormaPago.Descripcion).ObtenerFullNameMasPropiedad<FormaPago>(),"Descripción") });

            RefrescarGrilla();
        }
        protected override void ActualizarLista()
        {
            grillaDatos.DataSource = null;
            grillaDatos.DataSource = _abmcVista
                .Buscar((string)cmbCampoBusqueda.SelectedValue, txtCriterioBusqueda.Text, ckIncluirInactivos.Checked);
            UtilUI.ObtenerInstancia().LayoutGrilla(grillaDatos, typeof(VistaFormaPago));
            ActualizarOrdenamiento<VistaFormaPago>();
        }
        protected override void RestablecerParametros()
        {
            txtCriterioBusqueda.Text = "";
            base.RestablecerParametros();
        }
        protected override void ProcesarReordenamiento()
        {
            ActualizarOrdenamiento<VistaFormaPago>();
        }
        protected override void AgregarElemento()
        {
            var fAlta = new FormFormaPago();
            fAlta.ShowDialog();
            if (fAlta.DialogResult == DialogResult.OK)
                RefrescarGrilla();
        }
        protected override void ModificarElemento()
        {
            var elem = ObtenerObjetoDesdeGrilla<VistaFormaPago>();
            if (elem != default)
            {
                var fPago = _abmcVista
                    .Leer(new FormaPagoContado { Descripcion = elem.Descripcion });

                var fModf = new FormFormaPago(fPago);
                fModf.ShowDialog();
                RefrescarGrilla();

            }
        }
        protected override void EliminarElemento()
        {
            var elem = ObtenerObjetoDesdeGrilla<VistaFormaPago>();
            if (elem != default)
            {
                var fPago = _abmcVista.Leer(new FormaPagoContado { Descripcion = elem.Descripcion });

                if (MostrarMensaje.Pregunta($"¿Confirma que va a eliminar la forma de pago {fPago}?") == DialogResult.Yes)
                {
                    _abmcVista.Eliminar(fPago);
                    RefrescarGrilla();
                }
            }
        }
    }
}
