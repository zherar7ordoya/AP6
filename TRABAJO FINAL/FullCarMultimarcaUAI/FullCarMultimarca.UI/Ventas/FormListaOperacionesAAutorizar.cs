using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.BE.Ventas;
using FullCarMultimarca.BLL;
using FullCarMultimarca.BLL.Ventas;
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

namespace FullCarMultimarca.UI.Ventas
{
    public partial class FormListaOperacionesAAutorizar : FormListaBase
    {
        private FormListaOperacionesAAutorizar()
        {
            InitializeComponent();
        }
        private static FormListaOperacionesAAutorizar _instancia;
        private bool _puedeAutorizarOperacion = false;
        public static FormListaOperacionesAAutorizar ObtenerInstancia()
        {
            if (_instancia == null)
                _instancia = new FormListaOperacionesAAutorizar();
            if (_instancia.IsDisposed)
                _instancia = new FormListaOperacionesAAutorizar();
            return _instancia;
        }

        protected override void IniciarFormulario()
        {
            CargarCriteriosBusqueda(new List<ConsultaCriterio> {
                  new ConsultaCriterio(nameof(Operacion.Numero).ObtenerFullNameMasPropiedad<Operacion>(),"Nro.Operación")
               , new ConsultaCriterio(nameof(Usuario.Logon).ObtenerFullNameMasPropiedad<Usuario>(), "Vendedor Logon") });

            _puedeAutorizarOperacion = Ticket.TienePermiso(ConstPermisos.OPERACION_AUTORIZAR);

            RestablecerParametros();
            RefrescarGrilla();

            txtCriterioBusqueda.Select();
        }
        protected override void ActualizarLista()
        {
            grillaDatos.DataSource = null;
            grillaDatos.DataSource = BLLOperacion.ObtenerInstancia().ObtenerAutorizacionPendiente((string)cmbCampoBusqueda.SelectedValue, txtCriterioBusqueda.Text);
            UtilUI.ObtenerInstancia().LayoutGrilla(grillaDatos, typeof(VistaAutorizacionOperacion));
            ActualizarOrdenamiento<VistaAutorizacionOperacion>();
        }
        protected override void RestablecerParametros()
        {          
            txtCriterioBusqueda.Text = "";         
            base.RestablecerParametros();
        }
        protected override void ProcesarReordenamiento()
        {
            ActualizarOrdenamiento<VistaAutorizacionOperacion>();
        }
        protected override void ModificarElemento()
        {
            AbrirOperacionAAutorizar();
        }
        private void btnAutorizarOperacion_Click(object sender, EventArgs e)
        {
            AbrirOperacionAAutorizar();
        }

        private void AbrirOperacionAAutorizar()
        {
            try
            {
                var elem = ObtenerObjetoDesdeGrilla<VistaAutorizacionOperacion>();
                if (elem != null && _puedeAutorizarOperacion)
                {
                    this.Cursor = Cursors.Default;
                    //Actualizamos la operación
                    var operacion = BLLOperacion.ObtenerInstancia().Leer(new Operacion { Numero = elem.NumeroInterno });
                    FormAutorizarOperacion fAut = new FormAutorizarOperacion(operacion);
                    fAut.ShowDialog();
                    RefrescarGrilla();

                }
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
    }
}
