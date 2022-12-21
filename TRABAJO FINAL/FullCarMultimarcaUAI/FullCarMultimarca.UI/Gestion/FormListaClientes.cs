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
    public partial class FormListaClientes : FormListaBase
    {
        private FormListaClientes()
        {
            InitializeComponent();            
        }
        private static FormListaClientes _instancia;

        private IAbmc<Cliente, VistaCliente> _abmc = BLLCliente.ObtenerInstancia();
        public static FormListaClientes ObtenerInstancia()
        {
            if (_instancia == null)
                _instancia = new FormListaClientes();
            if (_instancia.IsDisposed)
                _instancia = new FormListaClientes();
            return _instancia;
        }

        protected override void IniciarFormulario()
        {
            CargarCriteriosBusqueda(new List<ConsultaCriterio> {
                new ConsultaCriterio(nameof(Cliente.CUIT).ObtenerFullNameMasPropiedad<Cliente>(),"CUIL/CUIT"),
                new ConsultaCriterio(nameof(Cliente.Apellido).ObtenerFullNameMasPropiedad<Cliente>(), "Apellido/Razón Social"),
                new ConsultaCriterio(nameof(Cliente.Nombre).ObtenerFullNameMasPropiedad<Cliente>(), "Nombre/Contacto") }); ;

            RefrescarGrilla();
        }
        protected override void ActualizarLista()
        {
            grillaDatos.DataSource = null;
            grillaDatos.DataSource = _abmc.
                Buscar((string)cmbCampoBusqueda.SelectedValue, txtCriterioBusqueda.Text);
            UtilUI.ObtenerInstancia().LayoutGrilla(grillaDatos, typeof(VistaCliente));
            ActualizarOrdenamiento<VistaCliente>();
        }
        protected override void RestablecerParametros()
        {
            txtCriterioBusqueda.Text = "";
            base.RestablecerParametros();
        }
        protected override void ProcesarReordenamiento()
        {
            ActualizarOrdenamiento<VistaCliente>();
        }
        protected override void AgregarElemento()
        {
            var fAlta = new FormCliente();
            fAlta.ShowDialog();
            if (fAlta.DialogResult == DialogResult.OK)
                RefrescarGrilla();
        }
        protected override void ModificarElemento()
        {
            var elem = ObtenerObjetoDesdeGrilla<VistaCliente>();
            if (elem != default)
            {
                var cli = _abmc.Leer(new Cliente { CUIT = elem.CUIT });

                var fModf = new FormCliente(cli);
                fModf.ShowDialog();
                RefrescarGrilla();

            }
        }
        protected override void EliminarElemento()
        {
            var elem = ObtenerObjetoDesdeGrilla<VistaCliente>();
            if (elem != default)
            {
                var cli = _abmc.Leer(new Cliente { CUIT = elem.CUIT });

                if (MostrarMensaje.Pregunta($"¿Confirma que va a eliminar el cliente {cli}?") == DialogResult.Yes)
                {
                    _abmc.Eliminar(cli);
                    RefrescarGrilla();
                }
            }
        }
    }
}
