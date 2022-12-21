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
using FullCarMultimarca.Servicios.Excepciones;

namespace FullCarMultimarca.UI.Seguridad
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        public FormLogin(string usuario) :this()
        {
            _ultimoUsuarioLogueado = usuario;
        }


        private string _ultimoUsuarioLogueado;

        public static string TextoInfo = "Ingrese sus Credenciales";

        private void FormLogin_Load(object sender, EventArgs e)
        {
            try
            {

                BLLUsuario.ResetIntentosUsuario(); //Cada vez que abro el form reseteo los intentos para todos los usuarios que intenten loguearse
                lblInfoLogin.Text = TextoInfo;

                if (!string.IsNullOrWhiteSpace(_ultimoUsuarioLogueado))
                {
                    txtUsuario.Text = _ultimoUsuarioLogueado;
                    txtClave.Select();
                }

            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
                DialogResult = DialogResult.Abort;
                this.Close();
            }
        }
        private void btnOlvideMiClave_Click(object sender, EventArgs e)
        {
            try
            {
                string logon = txtUsuario.Text;
                if (string.IsNullOrWhiteSpace(logon))
                    throw new NegocioException("Por favor indique el usuario logon para iniciar el protocolo de recuperación de clave.");

                Usuario usr = BLLUsuario.ObtenerInstancia().ObtenerUsuarioParaRecuperoDeClave(new Usuario { Logon = logon });
                if(string.IsNullOrWhiteSpace(usr.RespuestaClave))
                {
                    if (string.IsNullOrWhiteSpace(usr.Email))
                        throw new NegocioException("No se ha indicado protocolo de pregunta/respuesta clave ni se ha brindado un correo corporativo.\nNo puede hacer uso de esta opcion. Contacte al administrador.");

                    if(MostrarMensaje.Pregunta($"¿Desea restablecer y enviar una clave temporaría a su casilla corporativa?\nDestinatario: {usr.Email}") == DialogResult.Yes)
                    {
                        BLLUsuario.ObtenerInstancia().EnviarCorreoDeRestauracion(usr);
                    }
                }
                else
                {
                    FormRestablecerClave fRestablecer = new FormRestablecerClave(usr);
                    fRestablecer.ShowDialog();
                    
                }
                txtClave.Select();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.Abort;
                this.Close();

            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            ValidarIngreso();
        }     
        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
                ValidarIngreso();
        }

        private void ValidarIngreso()
        {
            string usr = txtUsuario.Text;
            string clave = txtClave.Text;
            try
            {              
                if (String.IsNullOrWhiteSpace(usr) || String.IsNullOrWhiteSpace(clave))
                    throw new NegocioException("Debe ingresar usuario y clave");

                this.Cursor = Cursors.WaitCursor;

                if (BLLUsuario.ObtenerInstancia().ValidarUsuario(new Usuario { Logon = usr.Trim(), Password = clave.Trim() }) == false)
                    return;

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (UsuarioPrimerIngresoException piEx)
            {
                MostrarMensaje.MostrarError(piEx);
                ProcesarPrimerIngreso(usr);                
                txtClave.Text = "";
                txtClave.Select();
            }
            catch(UsuarioClaveVencidaException cvEx)
            {                
                MostrarMensaje.MostrarError(cvEx);
                AbrirFormularioCambioClave(usr);
                txtClave.Text = "";
                txtClave.Select();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
                this.txtUsuario.Select();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void AbrirFormularioCambioClave(string logon)
        {
            var fCambioClave = new FormModificarClave(logon);
            fCambioClave.ShowDialog();
        }
        private void ProcesarPrimerIngreso(string logon)
        {
            var fCambioClave = new FormModificarClave(logon);
            DialogResult resu = fCambioClave.ShowDialog();
            if (resu == DialogResult.OK)
            {
                //Leo el usuario para ver si ya cargó palabra clave
                var usr = BLLUsuario.ObtenerInstancia().Leer(new Usuario { Logon = logon });
                if (usr != null && string.IsNullOrWhiteSpace(usr.PalabraClave))
                {
                    var fCargaPalabraClave = new FormCargarPalabraClave(logon, "Omitir");
                    fCargaPalabraClave.ShowDialog();
                }
            }
        }


    }
}
