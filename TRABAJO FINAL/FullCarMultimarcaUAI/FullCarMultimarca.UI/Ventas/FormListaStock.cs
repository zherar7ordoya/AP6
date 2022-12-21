using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.BE.Ventas;
using FullCarMultimarca.BLL;
using FullCarMultimarca.BLL.Gestion;
using FullCarMultimarca.BLL.Ventas;
using FullCarMultimarca.Servicios.Excepciones;
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
using System.Drawing.Printing;
using System.IO;
using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.Servicios.Extensiones;

namespace FullCarMultimarca.UI.Ventas
{
    public partial class FormListaStock : FormListaBase
    {
        private FormListaStock()
        {
            InitializeComponent();
        }
        private static FormListaStock _instancia;
        public static FormListaStock ObtenerInstancia()
        {
            if (_instancia == null)
                _instancia = new FormListaStock();
            if (_instancia.IsDisposed)
                _instancia = new FormListaStock();
            return _instancia;
        }

        private bool _puedeGestionarOfertas = false;
        private bool _puedeIniciarVenta = false;
        private IAbmc<Unidad> _abmc = BLLUnidad.ObtenerInstancia();

        protected override void IniciarFormulario()
        {            
            CargarCriteriosBusqueda(new List<ConsultaCriterio> {
                new ConsultaCriterio(nameof(Unidad.Chasis).ObtenerFullNameMasPropiedad<Unidad>(),"Chasis")
                , new ConsultaCriterio(nameof(Modelo.Codigo).ObtenerFullNameMasPropiedad<Modelo>(),"Cod.Modelo")
                , new ConsultaCriterio(nameof(Modelo.Descripcion).ObtenerFullNameMasPropiedad<Modelo>(), "Desc.Modelo")
                , new ConsultaCriterio(nameof(ColorUnidad.Descripcion).ObtenerFullNameMasPropiedad<ColorUnidad>(), "Color") });

            
            _puedeGestionarOfertas = Ticket.TienePermiso(ConstPermisos.STOCK_PONER_EN_OFERTA);
            _puedeIniciarVenta = Ticket.TienePermiso(ConstPermisos.OPERACION_CARGAR_VENTA);

            btnPonerUnidadEnOferta.Visible = btnAnularOferta.Visible = _puedeGestionarOfertas;
            btnIniciarNuevaOperacion.Visible = _puedeIniciarVenta;

            this.grillaDatos.RowPostPaint += GrillaDatos_RowPostPaint;


            RefrescarGrilla();
        }
        protected override void ActualizarLista()
        {
            grillaDatos.DataSource = null;
            grillaDatos.DataSource = BLLStock.ObtenerInstancia().ObtenerStock((string)cmbCampoBusqueda.SelectedValue, txtCriterioBusqueda.Text);
            UtilUI.ObtenerInstancia().LayoutGrilla(grillaDatos, typeof(VistaStock));
            ActualizarOrdenamiento<VistaStock>();
        }
        protected override void RestablecerParametros()
        {
            txtCriterioBusqueda.Text = "";
            base.RestablecerParametros();
        }
        protected override void ProcesarReordenamiento()
        {
            ActualizarOrdenamiento<VistaStock>();
        }
        protected override void ProcesarCambioFila()
        {
            var elem = ObtenerObjetoDesdeGrilla<VistaStock>();
            if(elem != null && _puedeGestionarOfertas)
            {
                if (elem.EnOferta)
                    btnAnularOferta.Enabled = true;
                else
                    btnAnularOferta.Enabled = false;
            }
        }


        private void GrillaDatos_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                //Este evento se ejecuta cada vez que se actualiza el datasource de la grilla, sirve para colorear las unidades en oferta
                var grilla = ((DataGridView)sender);
                var fila = grilla.Rows[e.RowIndex];

                if (grilla.Columns.Contains("EnOferta")                    
                    && (bool)fila.Cells["EnOferta"].Value == true)
                    fila.DefaultCellStyle.BackColor = Color.LightSalmon;

            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void btnPonerUnidadEnOferta_Click(object sender, EventArgs e)
        {
            try
            {
                var elem = ObtenerObjetoDesdeGrilla<VistaStock>();
                if (elem != null && _puedeGestionarOfertas)
                {
                    var unidad = _abmc.Leer(new Unidad { Chasis = elem.Chasis });
                    if (unidad == null)
                        throw new NegocioException("No se econtró la unidad.");

                    FormEstablecerOferta fOferta = new FormEstablecerOferta(unidad);
                    fOferta.ShowDialog();
                    RefrescarGrilla();
                }

            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void btnAnularOferta_Click(object sender, EventArgs e)
        {
            try
            {
                var elem = ObtenerObjetoDesdeGrilla<VistaStock>();
                if (elem != null && _puedeGestionarOfertas && elem.EnOferta)
                {
                    if (MostrarMensaje.Pregunta($"¿Desea anular la oferta de la unidad {elem.Chasis}?") == DialogResult.Yes)
                    {
                        BLLStock.ObtenerInstancia().AnularOfertaUnidad(new Unidad { Chasis = elem.Chasis });
                        RefrescarGrilla();
                    }                    
                }

            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void btnIniciarNuevaOperacion_Click(object sender, EventArgs e)
        {
            try
            {
                var elem = ObtenerObjetoDesdeGrilla<VistaStock>();
                if (elem != null && _puedeIniciarVenta)
                {
                    this.Cursor = Cursors.Default;
                    Unidad unidadSeleccionada = null;

                    try
                    {
                        unidadSeleccionada = BLLStock.ObtenerInstancia().VerificarUnidadOptima(new Unidad { Chasis = elem.Chasis });
                    }
                    catch (UnidadOptimaException<Unidad> optEx)
                    {
                        if(MostrarMensaje.Pregunta(optEx.Message) == DialogResult.Yes)
                        {
                            unidadSeleccionada = optEx.UnidadOptima;
                        }
                    }
                    catch 
                    {
                        throw;
                    }

                    if(unidadSeleccionada != null) //Tenemos la unidad, ya sea que es la seleccionada u optima
                    {
                        //Iniciar nueva venta
                        FormOperacion fOp = new FormOperacion(BLLOperacion.ObtenerInstancia().IniciarNuevaOperacion(unidadSeleccionada));
                        fOp.ShowDialog();
                        RefrescarGrilla();
                    }

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
