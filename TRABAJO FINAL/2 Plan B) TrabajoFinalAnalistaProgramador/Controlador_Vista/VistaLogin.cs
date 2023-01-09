using BLL;
using Entidad;
using ServiciosEncriptacion;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Controlador_Vista
{
    public class VistaLogin
    {
        private System.Windows.Forms.Form frmLogin;
        private System.Windows.Forms.Form frmAutenticacion;
        private List<Control> ListaControles;
        private E_Usuario oUsuario;
        private BLL_Usuario oBLLUsuario;
        private Encriptacion oEncriptacion;
        //Creo variable para los intentos en que se puede fallar en el ingreso.
        private int intentos = 0;

        public VistaLogin(Form pForm, Form pForm2)
        {
            try
            {
                ListaControles = new List<Control>();
                // Se guarda en una variable privada la referencia al formulario que llega al parámetro del constructor
                frmLogin = pForm;
                frmAutenticacion = pForm2;

                //Recorro el form login en busca de controles.
                foreach (System.Windows.Forms.Control c in frmLogin.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }

                ((Button)ListaControles.Find(x => x.Nombre == "btn_Ingresar").Puntero).Click += btn_Ingresar_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_Salir").Puntero).Click += btn_Salir_Click;
                frmLogin.Load += frmLogin_Load;

                oEncriptacion = new Encriptacion();
                oUsuario = new E_Usuario();
                oBLLUsuario = new BLL_Usuario();

                //Recorro el form autenticacion en busca de controles.
                foreach (System.Windows.Forms.Control c in frmAutenticacion.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region "Funciones delegadas de eventos UI"

        private void frmLogin_Load(object sender, EventArgs e)
        {
        }

        private void btn_Ingresar_Click(object sender, EventArgs e)
        {
            TextBox txtUsuario = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Usuario").Puntero;
            TextBox txtContraseña = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Contraseña").Puntero;
            //Este label corresponde al form autenticacion.
            Label lblUsuario = (Label)ListaControles.Find(x => x.Nombre == "lbl_Usuario").Puntero;
            //Creo variable bool para el estado bloqueado.
            bool bloqueado = false;

            try
            {
                #region Validaciones
                //Valido que no quede en blanco el txt de usuario.
                if (string.IsNullOrWhiteSpace(txtUsuario.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre de usuario!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtUsuario.Focus();
                    return;
                }
                //Valido que no quede en blanco el txt de contraseña.
                if (string.IsNullOrWhiteSpace(txtContraseña.Text))
                {
                    MessageBox.Show("Debe ingresar la contraseña!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtContraseña.Focus();
                    return;
                }
                #endregion

                //Valido el usuario y contraseña.
                if (Validar(txtUsuario.Text, txtContraseña.Text, bloqueado) == false)
                {
                    MessageBox.Show("Ingreso no válido!!! \nVerifique que haya ingresado correctamente sus datos.\nSi su cuenta fue bloqueada, contacte con el gerente de la empresa. ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Cuento los intentos.
                    intentos += 1;
                    //A los 3 intentos bloqueo la cuenta.
                    if (intentos == 3)
                    {
                        //Aviso que se bloqueo la cuenta.
                        MessageBox.Show("Se ha bloqueado su cuenta, contacte al gerente de la empresa", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //Asigno valores a las propiedades del objeto.
                        oUsuario.Nombre = txtUsuario.Text;
                        oUsuario.Contraseña = txtContraseña.Text;
                        //Llamo al metodo bloquear usuario y le paso como parametro el objeto con sus valores correspondientes.
                        BloquearUsuario(oUsuario);
                    }
                }
                else
                {
                    //Si en el ingreso fue correcto, lo aviso.
                    MessageBox.Show("Ingreso correcto", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Oculto el formulario.
                    frmLogin.Hide();
                    //Abro form.
                    frmAutenticacion.Show();
                    //Paso el nombre de usuario.
                    lblUsuario.Text = txtUsuario.Text;
                    //Miniminizo el form.
                    frmLogin.WindowState = FormWindowState.Minimized;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Boton Salir.
        private void btn_Salir_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        #endregion "Funciones delegadas de eventos UI"
        //Metodo validar.
        public bool Validar(string pNombre, string pContraseña, bool pBloqueado)
        {
            try
            {
                //Encripto el nombre de usuario y contraseña, ya que asi estan almacenados en el xml.
                oEncriptacion.EncriptarSimple(ref pNombre);
                oEncriptacion.EncriptarSimple(ref pContraseña);

                return oBLLUsuario.Validar(pNombre, pContraseña, pBloqueado);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo bloquear usuario.
        public void BloquearUsuario(E_Usuario oUsuario)
        {
            try
            {
                oBLLUsuario.BloquearUsuario(oUsuario);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}