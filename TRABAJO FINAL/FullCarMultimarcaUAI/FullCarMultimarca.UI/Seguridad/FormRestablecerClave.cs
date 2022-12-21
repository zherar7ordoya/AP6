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
    public partial class FormRestablecerClave : FormEditorBase<Usuario>
    {
        public FormRestablecerClave(Usuario beUsuario) : base(beUsuario)
        {
            InitializeComponent();
        }

        protected override void IniciarFormulario()
        {
            txtUsuario.Text = _elemento.Logon;
            lblPalabraClave.Text = _elemento.PalabraClave;
            txtEmailUsuario.Text = _elemento.Email;
        }

        protected override void GuardarCambios()
        {
            string respuestaClave = txtRespuestaClave.Text;
            string claveNueva = txtNuevaClave.Text;
            string repClave = txtClaveRep.Text;

            BLLUsuario.ObtenerInstancia().RestablecerClave(_elemento.Logon, respuestaClave, claveNueva, repClave);

            MostrarMensaje.Informacion("Clave restablecida exitosamente");


            base.GuardarCambios();
        }

        private void btnEnviarCodigoRestauracion_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(_elemento.Email))
                    throw new NegocioException("No se ha indicado el correo corporativo para el usuario");

                BLLUsuario.ObtenerInstancia().EnviarCorreoDeRestauracion(_elemento);

                this.Close();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
     
    }
}
