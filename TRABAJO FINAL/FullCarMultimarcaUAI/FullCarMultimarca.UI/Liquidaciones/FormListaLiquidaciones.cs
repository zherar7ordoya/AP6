using FullCarMultimarca.BE.Liquidaciones;
using FullCarMultimarca.BLL;
using FullCarMultimarca.BLL.Liquidaciones;
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

namespace FullCarMultimarca.UI.Liquidaciones
{
    public partial class FormListaLiquidaciones : FormListaBase
    {
        private FormListaLiquidaciones()
        {
            InitializeComponent();
        }
        private static FormListaLiquidaciones _instancia;
        public static FormListaLiquidaciones ObtenerInstancia()
        {
            if (_instancia == null)
                _instancia = new FormListaLiquidaciones();
            if (_instancia.IsDisposed)
                _instancia = new FormListaLiquidaciones();
            return _instancia;
        }

        protected override void IniciarFormulario()
        {          
            
            btnEliminar.Visible = Ticket.TienePermiso(ConstPermisos.LIQUIDACION_ELIMINAR);            
            
            RefrescarGrilla();
            
        }
        protected override void ActualizarLista()
        {            
            grillaDatos.DataSource = null;
            grillaDatos.DataSource = BLLLiquidacion.ObtenerInstancia().ObtenerLiquidaciones();                
            UtilUI.ObtenerInstancia().LayoutGrilla(grillaDatos, typeof(VistaLiquidacionHeader));
            ActualizarOrdenamiento<VistaLiquidacionHeader>();
        }
        protected override void ProcesarReordenamiento()
        {
            ActualizarOrdenamiento<VistaLiquidacionHeader>();
        }
        protected override void ModificarElemento()
        {
            var elem = ObtenerObjetoDesdeGrilla<VistaLiquidacionHeader>();
            if (elem != default)
            {
                //Leer liquidación completa
                var liqCompleta = BLLLiquidacion.ObtenerInstancia().ObtenerVistaCompleta(new Liquidacion(elem.Codigo));
                var fDetalle = new FormVerLiquidacion(liqCompleta);
                fDetalle.ShowDialog();               
                RefrescarGrilla();
            }
        }

        protected override void EliminarElemento()
        {
            var elem = ObtenerObjetoDesdeGrilla<VistaLiquidacionHeader>();
            if (elem != null)
            {                             

                if (MostrarMensaje.Pregunta($"¿Confirma que desea eliminar la liquidación {elem.Codigo}?\nEsta acción NO podrá deshacerse.") == DialogResult.Yes)
                { 
                    BLLLiquidacion.ObtenerInstancia().EliminarLiquidacion(new Liquidacion(elem.Codigo));
                    RefrescarGrilla();
                }
            }
        }

    }
}
