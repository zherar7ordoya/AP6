using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.BE.Ventas;
using FullCarMultimarca.BLL;
using FullCarMultimarca.BLL.Parametros;
using FullCarMultimarca.BLL.Ventas;
using FullCarMultimarca.UI.Parametros;
using FullCarMultimarca.BE.Liquidaciones;
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
using FullCarMultimarca.BLL.Liquidaciones;

namespace FullCarMultimarca.UI.Liquidaciones
{
    public partial class FormLiquidarComisiones : Form
    {
        public FormLiquidarComisiones()
        {
            InitializeComponent();
        }

        private IList<VistaOperacionALiquidar> _opALiquidar = new List<VistaOperacionALiquidar>();

        public string IniciarNuevaLiquidacion()
        {
            this.ShowDialog();
            return txtCodigoLiquidacion.Text;
        }

        private void FormLiquidarComisiones_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _opALiquidar = BLLOperacion.ObtenerInstancia().ObtenerPendientesDeLiquidar();

                //Puede modificar parámetros de comisiones?
                this.btnModificarParametrosLiquidacion.Visible = Ticket.TienePermiso(ConstPermisos.GESTIONAR_PARAMETROS_COMISIONES);

                ActualizarGrillaALiquidar();
                this.txtFechaLiquidacion.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");

            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
                this.Close();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void btnRemoverOperacion_Click(object sender, EventArgs e)
        {
            try
            {
                var op = UtilUI.ObtenerInstancia().ObtenerObjetoDesdeGrilla<VistaOperacionALiquidar>(grillaOperacionesALiquidar);
                if(op != null)
                {
                    if(MostrarMensaje.Pregunta($"¿Desea remover la operación {op.Numero} de esta liquidación?") == DialogResult.Yes)
                    {
                        _opALiquidar.Remove(op);
                        ActualizarGrillaALiquidar();

                    }
                }

            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void btnModificarParametrosLiquidacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Ticket.TienePermiso(ConstPermisos.GESTIONAR_PARAMETROS_COMISIONES))
                    throw new NegocioException("No tiene permisos de modificar los parámetros de comisiones");

                var flags = BLLFlagsComisiones.ObtenerInstancia().Leer();
                var fModificarParametros = new FormParametroComisiones(flags);
                fModificarParametros.ShowDialog();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void btnGenerarLiquidacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (MostrarMensaje.Pregunta("¿Confirma la generación de la liquidación?") != DialogResult.Yes)
                    return;

                this.Cursor = Cursors.WaitCursor;

                //Creamos el header;
                string codigo = txtCodigoLiquidacion.Text;
                var nuevaLiquidacion = new Liquidacion(codigo);
                nuevaLiquidacion.Comentarios = txtComentariosLiquidacion.Text;
                nuevaLiquidacion.FechaLiquidacion = DateTime.Today.Date;

                BLLLiquidacion.ObtenerInstancia().GenerarLiquidacion(nuevaLiquidacion, _opALiquidar);

                this.DialogResult = DialogResult.OK;
                this.Close();

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

        private void ActualizarGrillaALiquidar()
        {
            grillaOperacionesALiquidar.DataSource = null;
            grillaOperacionesALiquidar.DataSource = _opALiquidar;
            UtilUI.ObtenerInstancia().LayoutGrilla(grillaOperacionesALiquidar, typeof(VistaOperacionALiquidar));

            txtTtlOpALiquidar.Text = _opALiquidar.Count().ToString("n0");
        }

      
    }
}
