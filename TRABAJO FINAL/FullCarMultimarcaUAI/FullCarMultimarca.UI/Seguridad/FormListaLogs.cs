
using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.BLL.Seguridad;
using FullCarMultimarca.UI.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.Servicios.Extensiones;
using FullCarMultimarca.BE;
using FullCarMultimarca.BLL;
using FullCarMultimarca.Vistas;

namespace FullCarMultimarca.UI.Seguridad
{
    public partial class FormListaLogs : FormListaBase
    {
        private FormListaLogs()
        {
            InitializeComponent();
        }
        private static FormListaLogs _instancia;
        public static FormListaLogs ObtenerInstancia()
        {
            if (_instancia == null)
                _instancia = new FormListaLogs();
            if (_instancia.IsDisposed)
                _instancia = new FormListaLogs();
            return _instancia;
        }

        protected override void IniciarFormulario()
        {
            if (Ticket.UsuarioLogueado == null)
                throw new NegocioException("No tiene permisos para ver los Logs del sistema");

            CargarCriteriosBusqueda(new List<ConsultaCriterio> { 
                new ConsultaCriterio(nameof(Log.Usuario).ObtenerFullNameMasPropiedad<Log>(), "Usuario"), 
                new ConsultaCriterio(nameof(Log.Operacion).ObtenerFullNameMasPropiedad<Log>(), "Operacion") });

            RestablecerParametros();
            RefrescarGrilla();
            txtCriterioBusqueda.Select();
        }
        protected override void ActualizarLista()
        {
            grillaDatos.DataSource = null;            
            grillaDatos.DataSource = BLLLog.ObtenerInstancia().ObtenerLogs(txtFechaDesde.Value, txtFechaHasta.Value, (string)cmbCampoBusqueda.SelectedValue, txtCriterioBusqueda.Text);
            UtilUI.ObtenerInstancia().LayoutGrilla(grillaDatos, typeof(VistaLog));
            ActualizarOrdenamiento<VistaLog>();
        }
        protected override void ProcesarReordenamiento()
        {
            ActualizarOrdenamiento<VistaLog>();
        }
        protected override void RestablecerParametros()
        {         
            txtFechaDesde.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            txtFechaHasta.Value = DateTime.Today;
            txtCriterioBusqueda.Text = "";
            base.RestablecerParametros();
        }     
       
    }
}
