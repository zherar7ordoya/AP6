
using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.BLL.Seguridad;
using FullCarMultimarca.UI.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FullCarMultimarca.Servicios.Excepciones;

namespace FullCarMultimarca.UI.Seguridad
{
    public partial class FormModificarUsuario : FormEditorBase<Usuario>
    {        
        public FormModificarUsuario(Usuario beUsuario) : base(beUsuario)
        {
            InitializeComponent();
        }

        protected override void IniciarFormulario()
        {
            if (_elemento == default)
                throw new NegocioException("No se encontró el elemento a modificar");

            var _listaPermisos = BLLPermiso.ObtenerInstancia().ObtenerPermisosDisponibles();
            if (_elemento.Permiso != null &&
                !_listaPermisos.Any(p => p.Codigo.Equals(_elemento.Permiso.Codigo)))
                _listaPermisos.Add(_elemento.Permiso);

            UtilUI.ObtenerInstancia().CargarComboDesdeList(cmbPermisoCompuesto, _listaPermisos.Where(p => p is PermisoCompuesto), true, "<Seleccione...>");

            txtLegajo.Text = _elemento.Legajo.ToString();
            txtUsuario.Text = _elemento.Logon;
            txtNombre.Text = _elemento.Nombre;
            txtApellido.Text = _elemento.Apellido;
            txtEmail.Text = _elemento.Email;
            ckHabilitado.Checked = _elemento.Activo;

            if (_elemento.Permiso == null)
                cmbPermisoCompuesto.SelectedIndex = 0;
            else
                cmbPermisoCompuesto.SelectedItem = _elemento.Permiso;         

        }
        protected override void GuardarCambios()
        {
            //Actualizamos el objeto                      
            _elemento.Logon = txtUsuario.Text.Trim();
            _elemento.Nombre = txtNombre.Text.Trim();
            _elemento.Apellido = txtApellido.Text.Trim();
            _elemento.Activo = ckHabilitado.Checked;
            _elemento.Email = txtEmail.Text.Trim();
            _elemento.Permiso = cmbPermisoCompuesto.SelectedItem as PermisoCompuesto;

            BLLUsuario.ObtenerInstancia().Modificar(_elemento);
            MostrarMensaje.Informacion("Usuario modificado exitosamente");
          
        }      

    }
}
