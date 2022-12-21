
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
using FullCarMultimarca.Servicios.Excepciones;

namespace FullCarMultimarca.UI.Seguridad
{
    public partial class FormPermiso : FormEditorBase<Permiso>
    {
        public FormPermiso()
        {
            InitializeComponent();
        }
        public FormPermiso(Permiso permiso) : base(permiso)
        {
            InitializeComponent();
        }

        protected override void IniciarFormulario()
        {
            if (!_esAlta && _elemento == default)
                throw new NegocioException("No se encontró el elemento a modificar");

            CargarCombo();
            cmbTipo.Enabled = false;
            cmbTipo.TabStop = false;

            if (!_esAlta)
            {                
                txtPCCodigo.ReadOnly = true;
                txtPCCodigo.TabStop = false;
                txtPCDescripcion.Select();
                cmbTipo.SelectedItem = _elemento.GetType().Name;
                txtPCCodigo.Text = _elemento.Codigo;
                txtPCDescripcion.Text = _elemento.Descripcion;
            }
            else
                txtPCCodigo.Select();
        }
        protected override void GuardarCambios()
        {

            string codigo = txtPCCodigo.Text;
            string descripcion = txtPCDescripcion.Text;
            
            if (_esAlta)
            {
                if ((string)cmbTipo.SelectedItem == typeof(PermisoSimple).Name)
                    _elemento = new PermisoSimple(codigo) { Descripcion = descripcion};
                else
                    _elemento = new PermisoCompuesto(codigo) {  Descripcion = descripcion};

                BLLPermiso.ObtenerInstancia().Agregar(_elemento);
                MostrarMensaje.Informacion("Permiso agregado.");
            }
            else
            {                
                _elemento.Descripcion = descripcion;

                BLLPermiso.ObtenerInstancia().Modificar(_elemento);
                MostrarMensaje.Informacion("Permiso modificado");
            }           
        }

        private void CargarCombo()
        {
            List<string> tipos = new List<string> { typeof(PermisoSimple).Name, typeof(PermisoCompuesto).Name };
            UtilUI.ObtenerInstancia().CargarComboDesdeList(cmbTipo, tipos);
            cmbTipo.SelectedIndex = 1;     
            
        }
      
    }
}
