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
    public partial class FormListaColores : FormListaBase
    {
        private FormListaColores()
        {
            InitializeComponent();
        }
        private static FormListaColores _instancia;

        private IAbmc<ColorUnidad, VistaColorUnidad> _abmcVista = BLLColorUnidad.ObtenerInstancia();
        public static FormListaColores ObtenerInstancia()
        {
            if (_instancia == null)
                _instancia = new FormListaColores();
            if (_instancia.IsDisposed)
                _instancia = new FormListaColores();
            return _instancia;
        }

        protected override void IniciarFormulario()
        {
            CargarCriteriosBusqueda(new List<ConsultaCriterio> { 
                new ConsultaCriterio(nameof(ColorUnidad.Descripcion).ObtenerFullNameMasPropiedad<ColorUnidad>(),"Descripción") });

            RefrescarGrilla();
        }
        protected override void ActualizarLista()
        {
            grillaDatos.DataSource = null;
            grillaDatos.DataSource = _abmcVista
                .Buscar((string)cmbCampoBusqueda.SelectedValue, txtCriterioBusqueda.Text, ckIncluirInactivos.Checked);
            UtilUI.ObtenerInstancia().LayoutGrilla(grillaDatos, typeof(VistaColorUnidad));
            ActualizarOrdenamiento<VistaColorUnidad>();
        }
        protected override void RestablecerParametros()
        {
            txtCriterioBusqueda.Text = "";
            base.RestablecerParametros();
        }
        protected override void ProcesarReordenamiento()
        {
            ActualizarOrdenamiento<VistaColorUnidad>();
        }
        protected override void AgregarElemento()
        {
            var fAlta = new FormColor();
            fAlta.ShowDialog();
            if (fAlta.DialogResult == DialogResult.OK)
                RefrescarGrilla();
        }
        protected override void ModificarElemento()
        {
            var elem = ObtenerObjetoDesdeGrilla<VistaColorUnidad>();
            if (elem != default)
            {
                var color = _abmcVista.Leer(new ColorUnidad { Descripcion = elem.Descripcion });

                var fModf = new FormColor(color);
                fModf.ShowDialog();
                RefrescarGrilla();

            }
        }
        protected override void EliminarElemento()
        {
            var elem = ObtenerObjetoDesdeGrilla<VistaColorUnidad>();
            if (elem != default)
            {
                var color = _abmcVista.Leer(new ColorUnidad { Descripcion = elem.Descripcion });

                if (MostrarMensaje.Pregunta($"¿Confirma que va a eliminar el color {color}?") == DialogResult.Yes)
                {
                    _abmcVista.Eliminar(color);
                    RefrescarGrilla();
                }
            }
        }
    }
}
