using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.BE.Liquidaciones;
using FullCarMultimarca.BE.Ventas;
using FullCarMultimarca.BLL;
using FullCarMultimarca.BLL.Liquidaciones;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace FullCarMultimarca.UI.Liquidaciones
{
    public partial class FormVerLiquidacion : Form
    {
        public FormVerLiquidacion(VistaLiquidacion vistaLiquidacion)
        {
            _vistaLiquidacion = vistaLiquidacion;
            InitializeComponent();
        }

        private VistaLiquidacion _vistaLiquidacion;

        private void FormVerLiquidacion_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (!Ticket.TienePermiso(ConstPermisos.LIQUIDACION_VER))
                    throw new NegocioException("No tiene permisos para ver la liquidación");
                if(_vistaLiquidacion == null)
                    throw new NegocioException("No se encontró la liquidación");

                txtCodigoLiquidacion.Text = _vistaLiquidacion.Codigo;
                txtFechaLiquidacion.Text = _vistaLiquidacion.Fecha;
                txtComentariosLiquidacion.Text = _vistaLiquidacion.Comentarios;

                ActualizarGrillaVendedores();
                ActualizarGrillaOperacionesLiquidadas();

                txtTtlComisiones.Text = _vistaLiquidacion.TotalEnComisiones;
                txtTtlPremioVolumen.Text = _vistaLiquidacion.TotalEnPremioVolumen;
                txtTotalLiquidacion.Text = _vistaLiquidacion.TotalGeneral;

                ChartLiquidadas();

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
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void grillaLiquidacionVendedor_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ActualizarGrillaOperacionesLiquidadas();
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


        private void ActualizarGrillaVendedores()
        {
            grillaLiquidacionVendedor.DataSource = null;
            grillaLiquidacionVendedor.DataSource = _vistaLiquidacion.ObtenerVendedores();
            UtilUI.ObtenerInstancia().LayoutGrilla(grillaLiquidacionVendedor, typeof(VistaLiquidacionVendedor));
        }
        private void ActualizarGrillaOperacionesLiquidadas()
        {
            grillaOperacionesLiquidadas.DataSource = null;

            var liqSelect = UtilUI.ObtenerInstancia().ObtenerObjetoDesdeGrilla<VistaLiquidacionVendedor>(grillaLiquidacionVendedor);
            if (liqSelect != null)
            {
                grillaOperacionesLiquidadas.DataSource = liqSelect.ObtenerOperaciones();
                UtilUI.ObtenerInstancia().LayoutGrilla(grillaOperacionesLiquidadas, typeof(VistaLiquidacionOperacion));
            }
        }

        private void ChartLiquidadas()
        {
            try
            {
                var comparativaVendedores = BLLLiquidacion.ObtenerInstancia().AgruparComisionesPorVendedor(_vistaLiquidacion.ObtenerVendedores());
                chartCompVendedores.Series[0].Points.DataBindXY(comparativaVendedores.Keys, comparativaVendedores.Values);
                chartCompVendedores.Series[0].ChartType = SeriesChartType.Pie;
                chartCompVendedores.Series[0].IsValueShownAsLabel = true;
                //chartCompVendedores.Series[0].Label = "#VALY (#PERCENT)";
                chartCompVendedores.Series[0].Label = "#PERCENT";
                chartCompVendedores.Series[0].LegendText = "#AXISLABEL";
                //chartCompVendedores.ChartAreas[0].Area3DStyle.Enable3D = true;

                chartCompVendedores.DataBind();

            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
    }
}
