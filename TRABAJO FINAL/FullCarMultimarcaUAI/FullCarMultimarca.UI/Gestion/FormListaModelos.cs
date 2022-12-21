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
    public partial class FormListaModelos : FormListaBase
    {
        private FormListaModelos()
        {
            InitializeComponent();
        }
        private static FormListaModelos _instancia;

        private IAbmc<Modelo, VistaModelo> _abmcVista = BLLModelo.ObtenerInstancia<ModeloResto>();
        
        public static FormListaModelos ObtenerInstancia()
        {
            if (_instancia == null)
                _instancia = new FormListaModelos();
            if (_instancia.IsDisposed)
                _instancia = new FormListaModelos();
            return _instancia;
        }

        protected override void IniciarFormulario()
        {
            CargarCriteriosBusqueda(new List<ConsultaCriterio> { 
                new ConsultaCriterio(nameof(Modelo.Codigo).ObtenerFullNameMasPropiedad<Modelo>(),"Código"), 
                new ConsultaCriterio(nameof(Modelo.Descripcion).ObtenerFullNameMasPropiedad<Modelo>(),"Descripción")});

            RefrescarGrilla();
        }
        protected override void ActualizarLista()
        {
            grillaDatos.DataSource = null;
            grillaDatos.DataSource = _abmcVista
                .Buscar((string)cmbCampoBusqueda.SelectedValue, txtCriterioBusqueda.Text, ckIncluirInactivos.Checked);
            UtilUI.ObtenerInstancia().LayoutGrilla(grillaDatos, typeof(VistaModelo));
            ActualizarOrdenamiento<VistaModelo>();
        }
        protected override void RestablecerParametros()
        {
            txtCriterioBusqueda.Text = "";
            base.RestablecerParametros();
        }
        protected override void ProcesarReordenamiento()
        {
            ActualizarOrdenamiento<VistaModelo>();
        }
        protected override void AgregarElemento()
        {
            var fAlta = new FormModelo();
            fAlta.ShowDialog();
            if (fAlta.DialogResult == DialogResult.OK)
                RefrescarGrilla();
        }
        protected override void ModificarElemento()
        {
            var elem = ObtenerObjetoDesdeGrilla<VistaModelo>();
            if (elem != default)
            {
                var modelo = _abmcVista.Leer(new ModeloResto(elem.Codigo));

                var fModf = new FormModelo(modelo);
                fModf.ShowDialog();
                RefrescarGrilla();

            }
        }
        protected override void EliminarElemento()
        {
            var elem = ObtenerObjetoDesdeGrilla<VistaModelo>();
            if (elem != default)
            {
                var modelo = _abmcVista.Leer(new ModeloResto(elem.Codigo));

                if (MostrarMensaje.Pregunta($"¿Confirma que va a eliminar el modelo {elem}?") == DialogResult.Yes)
                {
                    _abmcVista.Eliminar(modelo);
                    RefrescarGrilla();
                }
            }
        }
    }
}
