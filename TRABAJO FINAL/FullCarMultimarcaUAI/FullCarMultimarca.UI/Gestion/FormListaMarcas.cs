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
    public partial class FormListaMarcas : FormListaBase
    {
        private FormListaMarcas()
        {
            InitializeComponent();
        }
        private static FormListaMarcas _instancia;
        private IAbmc<Marca, VistaMarca> _abmcVista = BLLMarca.ObtenerInstancia();
        public static FormListaMarcas ObtenerInstancia()
        {
            if (_instancia == null)
                _instancia = new FormListaMarcas();
            if (_instancia.IsDisposed)
                _instancia = new FormListaMarcas();
            return _instancia;
        }

        protected override void IniciarFormulario()
        {
            CargarCriteriosBusqueda(new List<ConsultaCriterio> { 
                new ConsultaCriterio(nameof(Marca.Descripcion).ObtenerFullNameMasPropiedad<Marca>(), "Descripción")});

            RefrescarGrilla();
        }
        protected override void ActualizarLista()
        {
            grillaDatos.DataSource = null;
            grillaDatos.DataSource = _abmcVista
                .Buscar((string)cmbCampoBusqueda.SelectedValue, txtCriterioBusqueda.Text, ckIncluirInactivos.Checked);
            UtilUI.ObtenerInstancia().LayoutGrilla(grillaDatos, typeof(VistaMarca));
            ActualizarOrdenamiento<VistaMarca>();
        }       
        protected override void RestablecerParametros()
        {           
            txtCriterioBusqueda.Text = "";
            base.RestablecerParametros();
        }
        protected override void ProcesarReordenamiento()
        {
            ActualizarOrdenamiento<VistaMarca>();
        }
        protected override void AgregarElemento()
        {
            var fAlta = new FormMarca();
            fAlta.ShowDialog();
            if (fAlta.DialogResult == DialogResult.OK)
                RefrescarGrilla();
        }
        protected override void ModificarElemento()
        {
            var elem = ObtenerObjetoDesdeGrilla<VistaMarca>();
            if (elem != default)
            {

                var marca = _abmcVista.Leer(new Marca { Descripcion = elem.Descripcion });

                var fModf = new FormMarca(marca);
                fModf.ShowDialog();
                RefrescarGrilla();

            }
        }
        protected override void EliminarElemento()
        {
            var elem = ObtenerObjetoDesdeGrilla<VistaMarca>();
            if (elem != default)
            {
                var marca = _abmcVista.Leer(new Marca { Descripcion = elem.Descripcion });

                if (MostrarMensaje.Pregunta($"¿Confirma que va a eliminar la marca {marca}?") == DialogResult.Yes)
                {
                    _abmcVista.Eliminar(marca);
                    RefrescarGrilla();
                }
            }
        }
    }
}
