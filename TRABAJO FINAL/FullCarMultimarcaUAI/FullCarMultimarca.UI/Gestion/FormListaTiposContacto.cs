using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.BLL.Gestion;
using FullCarMultimarca.Servicios.Extensiones;
using FullCarMultimarca.UI.Base;
using FullCarMultimarca.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullCarMultimarca.UI.Gestion
{
    public partial class FormListaTiposContacto : FormListaBase
    {
        private FormListaTiposContacto()
        {
            InitializeComponent();
        }
        private static FormListaTiposContacto _instancia;

        private IAbmc<TipoContacto, VistaTipoContacto> _abmcVista = BLLTipoContacto.ObtenerInstancia();
        public static FormListaTiposContacto ObtenerInstancia()
        {
            if (_instancia == null)
                _instancia = new FormListaTiposContacto();
            if (_instancia.IsDisposed)
                _instancia = new FormListaTiposContacto();
            return _instancia;
        }

        protected override void IniciarFormulario()
        {
            CargarCriteriosBusqueda(new List<ConsultaCriterio> { 
                new ConsultaCriterio(nameof(TipoContacto.Descripcion).ObtenerFullNameMasPropiedad<TipoContacto>(),"Descripción") });

            RefrescarGrilla();
        }
        protected override void ActualizarLista()
        {
            grillaDatos.DataSource = null;
            grillaDatos.DataSource = _abmcVista
                .Buscar((string)cmbCampoBusqueda.SelectedValue, txtCriterioBusqueda.Text, ckIncluirInactivos.Checked);
            UtilUI.ObtenerInstancia().LayoutGrilla(grillaDatos, typeof(VistaTipoContacto));
            ActualizarOrdenamiento<VistaTipoContacto>();
        }
        protected override void RestablecerParametros()
        {
            txtCriterioBusqueda.Text = "";
            base.RestablecerParametros();
        }
        protected override void ProcesarReordenamiento()
        {
            ActualizarOrdenamiento<VistaTipoContacto>();
        }
        protected override void AgregarElemento()
        {
            var fAlta = new FormTipoContacto();
            fAlta.ShowDialog();
            if (fAlta.DialogResult == DialogResult.OK)
                RefrescarGrilla();
        }
        protected override void ModificarElemento()
        {
            var elem = ObtenerObjetoDesdeGrilla<VistaTipoContacto>();
            if (elem != default)
            {
                var tContacto = _abmcVista.Leer(new TipoContacto { Descripcion = elem.Descripcion });

                var fModf = new FormTipoContacto(tContacto);
                fModf.ShowDialog();
                RefrescarGrilla();

            }
        }
        protected override void EliminarElemento()
        {
            var elem = ObtenerObjetoDesdeGrilla<VistaTipoContacto>();
            if (elem != default)
            {

                var tContacto = _abmcVista.Leer(new TipoContacto { Descripcion = elem.Descripcion });

                if (MostrarMensaje.Pregunta($"¿Confirma que va a eliminar el tipo de contacto {tContacto}?") == DialogResult.Yes)
                {
                    _abmcVista.Eliminar(tContacto);
                    RefrescarGrilla();
                }
            }
        }
    }
}
