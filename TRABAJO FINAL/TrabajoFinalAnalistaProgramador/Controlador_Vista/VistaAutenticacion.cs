using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using BLL;
using System.Windows.Forms;
using System.Drawing;
using ServiciosEncriptacion;
using System.Text.RegularExpressions;

namespace Controlador_Vista
{
    public class VistaAutenticacion
    {
        System.Windows.Forms.Form frmAutenticacion;
        System.Windows.Forms.Form frmPrincipal;
        List<Control> ListaControles;
        BLL_Usuario oBLLUsuario;
        E_Usuario oUsuario;
        Encriptacion oEncriptacion;
        BLL_LogIn oBLLLogin;
        E_LogIn oLogin;
        //Declaro variable random.
        int randomNumber = new Random().Next(0, 10000);
        //Declaro variables.
        int _idUsuario; DateTime _fecha;


        public VistaAutenticacion(Form pForm, Form pForm2)
        {
            try
            {
                ListaControles = new List<Control>();

                // Se guarda en una variable privada la referencia al formulario que llega al parámetro del constructor
                frmAutenticacion = pForm;
                frmPrincipal = pForm2;
                //Recorro el form autenticacion en busca de controles.
                foreach (System.Windows.Forms.Control c in frmAutenticacion.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }

                //Recorro el form principal en busca de controles.
                foreach (System.Windows.Forms.Control c in frmPrincipal.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }
                Panel panel1 = (Panel)ListaControles.Find(x => x.Nombre == "panel1").Puntero;
                //Recorro el form en busca de controles.
                foreach (System.Windows.Forms.Control c in panel1.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }

                ((Button)ListaControles.Find(x => x.Nombre == "btn_PedirCodigo").Puntero).Click += btn_PedirCodigo_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_Continuar").Puntero).Click += btn_Ingresar_Click;
                frmAutenticacion.Load += frmAutenticacion_Load;

                oUsuario = new E_Usuario();
                oBLLUsuario = new BLL_Usuario();
                oEncriptacion = new Encriptacion();
                oBLLLogin = new BLL_LogIn();
                oLogin = new E_LogIn();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        #region "Funciones delegadas de eventos UI"
        private void frmAutenticacion_Load(object sender, EventArgs e)
        {

        }
        //Boton Pedir codigo.
        private void btn_PedirCodigo_Click(object sender, EventArgs e)
        {
            try
            {
                //Aviso cual es el codigo de autenticacion.
                MessageBox.Show("Su codigo de autenticacion es: " + randomNumber + " \n\n\nNota: Aqui se estaria simulando el envio del codigo de autenticacion por mail. Por cuestiones de configuracion se realiza de esta manera.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Boton Ingresar.
        private void btn_Ingresar_Click(object sender, EventArgs e)
        {

            TextBox txtCodigo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_CodigoAutenticacion").Puntero;
            Label lblUsuario = (Label)ListaControles.Find(x => x.Nombre == "lbl_Usuario").Puntero;
            Label lblUsuario2 = (Label)ListaControles.Find(x => x.Nombre == "label_Usuario").Puntero;

            try
            {
                #region Validaciones
                //Valido que no quede en blanco txt de codigo.
                if (string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    MessageBox.Show("Debe ingresar el codigo de autenticacion!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtCodigo.Focus();
                    return;
                }
                //Valido que el codigo sea un numero entero.
                Regex exp = new Regex("^([0-9])");

                if (!exp.IsMatch(txtCodigo.Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de codigo de autenticacion. Debe ser un numero entero.", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                #endregion

                //Si el valor ingresado coincide con el variable aleatoria.
                if (randomNumber == int.Parse(txtCodigo.Text))
                {
                    //Asigno al objeto el nombre de usuario.
                    oUsuario.Nombre = lblUsuario.Text;
                    //Llamo al metodo obtener id, para poder almacenar el id usuario en la tabla LogIn.
                    oBLLUsuario.ObtenerIdUsuario(oUsuario);
                    //Asigno valores a las variables.
                    _fecha = DateTime.Now;
                    _idUsuario = oUsuario.idUsuario;
                    //Llamo al metodo;
                    Alta(oLogin);
                }
                //Si el valor ingresado no coincide, aviso que vuelva a inregsar el codigo.
                else
                {
                    MessageBox.Show("Error de codigo de autenticación, vuelva a intentarlo");
                    return;
                }

                Cerrar();
               
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        #endregion
        //Metodo Alta para el login.
        public void Alta(E_LogIn oLogin)
        {
            try
            {
                oLogin.Fecha = _fecha;
                oLogin.oUsuario.idUsuario = _idUsuario;

                oBLLLogin.Alta(oLogin);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Cerrar.
        public void Cerrar()
        {
            try
            {
                frmAutenticacion.Close();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
      
    }
}
