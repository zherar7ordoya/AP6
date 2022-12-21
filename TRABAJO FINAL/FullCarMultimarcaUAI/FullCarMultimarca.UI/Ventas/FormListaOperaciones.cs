using FullCarMultimarca.BE.Ventas;
using FullCarMultimarca.BLL;
using FullCarMultimarca.BLL.Ventas;
using FullCarMultimarca.Servicios.Excepciones;
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
using FullCarMultimarca.UI.Impresiones;
using FullCarMultimarca.BLL.Gestion;
using System.Linq.Expressions;
using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.BE.Seguridad;

namespace FullCarMultimarca.UI.Ventas
{
    public partial class FormListaOperaciones : FormListaBase
    {
        private FormListaOperaciones()
        {
            InitializeComponent();
        }
        private static FormListaOperaciones _instancia;
        public static FormListaOperaciones ObtenerInstancia()
        {
            if (_instancia == null)
                _instancia = new FormListaOperaciones();
            if (_instancia.IsDisposed)
                _instancia = new FormListaOperaciones();
            return _instancia;
        }

        protected override void IniciarFormulario()
        {            
            CargarCriteriosBusqueda(new List<ConsultaCriterio> {
                new ConsultaCriterio(nameof(Operacion.Numero).ObtenerFullNameMasPropiedad<Operacion>(),"Nro.Operación")
                , new ConsultaCriterio(nameof(Unidad.Chasis).ObtenerFullNameMasPropiedad<Unidad>(),"Chasis")
                , new ConsultaCriterio(nameof(Usuario.Logon).ObtenerFullNameMasPropiedad<Usuario>(), "Vendedor Logon")
                , new ConsultaCriterio(nameof(Cliente.CUIT).ObtenerFullNameMasPropiedad<Cliente>(),"CUIL/CUIT")
                , new ConsultaCriterio(nameof(Cliente.Apellido).ObtenerFullNameMasPropiedad<Cliente>(), "Apellido/Razón Social")
                , new ConsultaCriterio(nameof(Cliente.Nombre).ObtenerFullNameMasPropiedad<Cliente>(), "Nombre/Contacto") });           

           

            UtilUI.ObtenerInstancia().CargarComboDesdeEnum(cmbEstado, typeof(Operacion.EstadoOperacion), true, "[Todos]");


            btnModificar.Visible = Ticket.TienePermiso(ConstPermisos.OPERACION_MODIFICAR_VENTA);
            btnEliminar.Visible = Ticket.TienePermiso(ConstPermisos.OPERACION_ANULAR_VENTA);

            this.grillaDatos.RowPostPaint += GrillaDatos_RowPostPaint;

            RestablecerParametros();
            RefrescarGrilla();

            txtCriterioBusqueda.Select();
        }
        protected override void ActualizarLista()
        {
            txtNotaRechazo.Text = "";
            grillaDatos.DataSource = null;
            grillaDatos.DataSource = BLLOperacion.ObtenerInstancia().BuscarOperaciones((string)cmbCampoBusqueda.SelectedValue, txtCriterioBusqueda.Text, ckIncluirInactivos.Checked,
                txtFechaDesde.Value, txtFechaHasta.Value, cmbEstado.SelectedItem as Operacion.EstadoOperacion?);
            UtilUI.ObtenerInstancia().LayoutGrilla(grillaDatos, typeof(VistaOperacion));
            ActualizarOrdenamiento<VistaOperacion>();
        }
        protected override void RestablecerParametros()
        {
            txtFechaDesde.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            txtFechaHasta.Value = DateTime.Today;
            txtCriterioBusqueda.Text = "";
            ckIncluirInactivos.Checked = false;
            cmbEstado.SelectedIndex = 0;
            base.RestablecerParametros();
        }
        protected override void ProcesarReordenamiento()
        {
            ActualizarOrdenamiento<VistaOperacion>();
        }
        protected override void ProcesarCambioFila()
        {
            var elem = ObtenerObjetoDesdeGrilla<VistaOperacion>();
            if (elem != null)
            {
                txtNotaRechazo.Text = elem.Estado.Equals(Operacion.EstadoOperacion.Rechazada.ToString()) ? elem.NotaRechazo : "";
            }
        }
        protected override void ModificarElemento()
        {
            var elem = ObtenerObjetoDesdeGrilla<VistaOperacion>();
            if (elem != null)
            {
                //Leer operacion
                var operacionLeida = BLLOperacion.ObtenerInstancia().LeerParaMostrar(new Operacion { Numero = elem.NumeroInterno });
                if (operacionLeida == null)
                    throw new NegocioException("No se encontró la operación seleccionada");                

                FormOperacion formOperacion = new FormOperacion(operacionLeida);
                formOperacion.ShowDialog();
                RefrescarGrilla();
            }
        }
        protected override void EliminarElemento()
        {
            var elem = ObtenerObjetoDesdeGrilla<VistaOperacion>();
            if (elem != null)
            {
                //Leer operacion
                var operacionLeida = BLLOperacion.ObtenerInstancia().Leer(new Operacion { Numero = elem.NumeroInterno });
                if (operacionLeida == null)
                    throw new NegocioException("No se encontró la operación seleccionada");

                if (MostrarMensaje.Pregunta($"¿Confirma que desea anular la operación {operacionLeida}?\nEsta acción NO podrá deshacerse.") == DialogResult.Yes)
                {
                    BLLOperacion.ObtenerInstancia().AnularOperacion(operacionLeida);
                    RefrescarGrilla();
                }
            }
        }
       
        //Colorea las filas de la grilla según el estado de la operación
        private void GrillaDatos_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                //Este evento se ejecuta cada vez que se actualiza el datasource de la grilla, sirve para colorear las unidades en oferta
                var grilla = ((DataGridView)sender);
                var fila = grilla.Rows[e.RowIndex];

                if (grilla.Columns.Contains("Anulada")
                    && (bool)fila.Cells["Anulada"].Value == true)
                {
                    fila.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    fila.DefaultCellStyle.ForeColor = Color.Red;
                }
                else if(grilla.Columns.Contains("Estado")
                    && (string)fila.Cells["Estado"].Value == Operacion.EstadoOperacion.Autorizada.ToString())
                {
                    fila.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (grilla.Columns.Contains("Estado")
                   && (string)fila.Cells["Estado"].Value == Operacion.EstadoOperacion.Rechazada.ToString())
                {
                    fila.DefaultCellStyle.BackColor = Color.Coral;
                }

            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }

        //Impresion y envio por mail
        private void btnEnviarPorMailOperacion_Click(object sender, EventArgs e)
        {
            try
            {
                var elem = ObtenerObjetoDesdeGrilla<VistaOperacion>();
                if (elem != null)
                {

                    var operacion = BLLOperacion.ObtenerInstancia().Leer(new Operacion { Numero = elem.NumeroInterno });
                    if (operacion != null)
                    {
                        var destinatarios = BLLOperacion.ObtenerInstancia().ObtenerMailsCliente(operacion);
                        var vistaOp = BLLOperacion.ObtenerInstancia().ObtenerVistaOperacionImpresion(operacion);

                        FormEnviarPorMailFormulario fenv = new FormEnviarPorMailFormulario(vistaOp, destinatarios);
                        fenv.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }

           
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                var elem = ObtenerObjetoDesdeGrilla<VistaOperacion>();
                if (elem != null)
                {
                    var vImpresion = BLLOperacion.ObtenerInstancia()
                       .ObtenerVistaOperacionImpresion(new Operacion { Numero = elem.NumeroInterno });

                    FormImprimirFormulario form = new FormImprimirFormulario();
                    DialogResult resu = form.ShowDialog();
                    if (resu != DialogResult.OK)
                    {
                        return;
                    }

                    string impresora = (string)form.cmbImpresoras.SelectedItem;
                    if (String.IsNullOrWhiteSpace(impresora))
                        return;

                    this.Cursor = Cursors.WaitCursor;                   

                    Imprimir.ImprimirOperacion(vImpresion, impresora);
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

        //public string ObtenerFullNameMasPropiedad<T>(string nombrePropiedad) where T : class
        //{
        //    var pInfo = typeof(T).GetProperty(nombrePropiedad);
        //    return $"{pInfo.DeclaringType.FullName}.{pInfo.Name}";
        //}
    }
}
