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
    public partial class FormListaUnidades : FormListaBase
    {
        private FormListaUnidades()
        {
            InitializeComponent();
        }
        private static FormListaUnidades _instancia;

        private IAbmc<Unidad, VistaUnidad> _abmcVista = BLLUnidad.ObtenerInstancia();
        public static FormListaUnidades ObtenerInstancia()
        {
            if (_instancia == null)
                _instancia = new FormListaUnidades();
            if (_instancia.IsDisposed)
                _instancia = new FormListaUnidades();
            return _instancia;
        }

        protected override void IniciarFormulario()
        {          
            CargarCriteriosBusqueda(new List<ConsultaCriterio> {
                new ConsultaCriterio(nameof(Unidad.Chasis).ObtenerFullNameMasPropiedad<Unidad>(),"Chasis")
                , new ConsultaCriterio(nameof(Modelo.Codigo).ObtenerFullNameMasPropiedad<Modelo>(),"Cod.Modelo")
                , new ConsultaCriterio(nameof(Modelo.Descripcion).ObtenerFullNameMasPropiedad<Modelo>(), "Desc.Modelo")
                , new ConsultaCriterio(nameof(ColorUnidad.Descripcion).ObtenerFullNameMasPropiedad<ColorUnidad>(), "Color") });

            RefrescarGrilla();

            grillaDatos.RowPostPaint += GrillaDatos_RowPostPaint;
        }
        protected override void ActualizarLista()
        {
            grillaDatos.DataSource = null;
            grillaDatos.DataSource = _abmcVista
                .Buscar((string)cmbCampoBusqueda.SelectedValue, txtCriterioBusqueda.Text, ckIncluirInactivos.Checked);
            UtilUI.ObtenerInstancia().LayoutGrilla(grillaDatos, typeof(VistaUnidad));
            ActualizarOrdenamiento<VistaUnidad>();
        }
        protected override void RestablecerParametros()
        {
            txtCriterioBusqueda.Text = "";
            base.RestablecerParametros();
        }
        protected override void ProcesarReordenamiento()
        {
            ActualizarOrdenamiento<VistaUnidad>();
        }
        protected override void AgregarElemento()
        {
            var fAlta = new FormUnidad();
            fAlta.ShowDialog();
            if (fAlta.DialogResult == DialogResult.OK)
                RefrescarGrilla();
        }
        protected override void ModificarElemento()
        {
            var elem = ObtenerObjetoDesdeGrilla<VistaUnidad>();
            if (elem != default)
            {
                var uni = _abmcVista.Leer(new Unidad { Chasis = elem.Chasis });

                var fModf = new FormUnidad(uni);
                fModf.ShowDialog();
                RefrescarGrilla();

            }
        }
        protected override void EliminarElemento()
        {
            var elem = ObtenerObjetoDesdeGrilla<VistaUnidad>();
            if (elem != default)
            {
                var uni = _abmcVista.Leer(new Unidad { Chasis = elem.Chasis });

                if (MostrarMensaje.Pregunta($"¿Confirma que va a eliminar la unidad {uni}?") == DialogResult.Yes)
                {
                    _abmcVista.Eliminar(uni);
                    RefrescarGrilla();
                }
            }
        }


        private void GrillaDatos_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                //Este evento se ejecuta cada vez que se actualiza el datasource de la grilla, sirve para colorear las unidades en oferta
                var grilla = ((DataGridView)sender);
                var fila = grilla.Rows[e.RowIndex];

                if (grilla.Columns.Contains("Disponible")
                    && (bool)fila.Cells["Disponible"].Value == false)
                    fila.DefaultCellStyle.BackColor = Color.LightGray;

            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
    }
}
