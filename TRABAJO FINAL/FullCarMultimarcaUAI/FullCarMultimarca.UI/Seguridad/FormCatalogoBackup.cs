
using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.BLL.Seguridad;
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
using FullCarMultimarca.BE;
using FullCarMultimarca.BLL;
using FullCarMultimarca.Vistas;

namespace FullCarMultimarca.UI.Seguridad
{
    public partial class FormCatalogoBackup : FormListaBase
    {
        private FormCatalogoBackup(bool soloRestaurar)
        {
            _soloRestaurarBackup = soloRestaurar;
            InitializeComponent();
        }
        private static FormCatalogoBackup _instancia;
        public static FormCatalogoBackup ObtenerInstancia(bool soloRestaurar = false)
        {           
            if (_instancia == null)
                _instancia = new FormCatalogoBackup(soloRestaurar);
            if (_instancia.IsDisposed)
                _instancia = new FormCatalogoBackup(soloRestaurar);
            return _instancia;
        }
        ~FormCatalogoBackup()
        {
            _instancia = null;
        }

        

        private bool _soloRestaurarBackup;

        protected override void IniciarFormulario()
        {
            if(_soloRestaurarBackup)
            {
                btnAgregar.Visible = false;
                btnEliminar.Visible = false;
            }


            RefrescarGrilla();
        }
        protected override void ActualizarLista()
        {
            grillaDatos.DataSource = null;
            grillaDatos.DataSource = BLLCatalogo.ObtenerInstancia().ObtenerCatalogosBackup();
            UtilUI.ObtenerInstancia().LayoutGrilla(grillaDatos, typeof(VistaCatalogo));
            ActualizarOrdenamiento<VistaCatalogo>();
        }
        protected override void AgregarElemento()
        {
            try
            {
                FormConfirmarBackup fcbckup = new FormConfirmarBackup();
                fcbckup.ShowDialog();
                RefrescarGrilla();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
          
        }
        protected override void EliminarElemento()
        {
            var elem = ObtenerObjetoDesdeGrilla<VistaCatalogo>();
            if (elem != default)
            {
                var cat = BLLCatalogo.ObtenerInstancia().Leer(new Catalogo { FechaYHora = elem.FechaYHora });

                if (MostrarMensaje.Pregunta($"¿Confirma que desea eliminar el backup del día {cat.FechaYHora:dd/MM/yyyy HH:mm:ss}?") == DialogResult.Yes)
                {
                    BLLCatalogo.ObtenerInstancia().EliminarBackup(cat);
                    RefrescarGrilla();
                }
            }
        }
        protected override void ProcesarReordenamiento()
        {
            ActualizarOrdenamiento<VistaCatalogo>();
        }
        protected override void ProcesarCambioFila()
        {
            var elem = ObtenerObjetoDesdeGrilla<VistaCatalogo>();
            if (elem != null)
                txtDescripcion.Text = elem.Descripcion;
        }

        private void btnRestaurarBackup_Click(object sender, EventArgs e)
        {
            try
            {
                var elem = ObtenerObjetoDesdeGrilla<VistaCatalogo>();
                if (elem != default)
                {
                    var cat = BLLCatalogo.ObtenerInstancia().Leer(new Catalogo { FechaYHora = elem.FechaYHora });

                    if (MostrarMensaje.Pregunta($"¿Confirma que desea restaurar el backup del día {cat.FechaYHora:dd/MM/yyyy HH:mm:ss}?\n" +
                        $"Al finalizar el proceso el sistema se reiniciará.\n" +
                        $"Esta acción NO puede deshacerse.") == DialogResult.Yes)
                    {
                        BLLCatalogo.ObtenerInstancia().RestaurarBackup(cat);
                        Application.Restart();                        
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
    }
}
