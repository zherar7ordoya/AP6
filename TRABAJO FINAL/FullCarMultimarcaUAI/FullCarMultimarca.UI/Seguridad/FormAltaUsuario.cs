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
using FullCarMultimarca.BLL.Seguridad;
using FullCarMultimarca.BE.Seguridad;


namespace FullCarMultimarca.UI.Seguridad
{
    public partial class FormAltaUsuario : FormEditorBase<Usuario>
    {
        public FormAltaUsuario() :base()
        {
            InitializeComponent();
        }

        protected override void IniciarFormulario()
        {
            var _listaPermisos = BLLPermiso.ObtenerInstancia().ObtenerPermisosDisponibles();
            UtilUI.ObtenerInstancia().CargarComboDesdeList(cmbPermisoCompuesto, _listaPermisos.Where(p => p is PermisoCompuesto), true, "<Seleccione...>");
            cmbPermisoCompuesto.SelectedIndex = 0;
        }


        protected override void GuardarCambios()
        {

            int legajo = 0;
            string strLegajo = txtLegajo.Text;
            if(!string.IsNullOrWhiteSpace(strLegajo))
            {
                legajo = Convert.ToInt32(strLegajo);
            }
            string usr = txtLogon.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string email = txtEmail.Text.Trim();
            string clave = txtClave.Text.Trim();                     
            PermisoCompuesto perfil = cmbPermisoCompuesto.SelectedItem as PermisoCompuesto;

            BLLUsuario.ObtenerInstancia().Agregar(new Usuario(legajo, usr, nombre, apellido, email, clave, perfil));

            MostrarMensaje.Informacion("Usuario creado exitosamente");

            base.GuardarCambios();

        }
    }
}
