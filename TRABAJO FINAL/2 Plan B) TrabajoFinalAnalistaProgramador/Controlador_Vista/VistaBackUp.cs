using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Entidad;
using PermisoComposite;


namespace Controlador_Vista
{
    public class VistaBackUp
    {
        System.Windows.Forms.Form frmBackUp;
        System.Windows.Forms.Form frmHistorialBackUp;
        E_BackUp oBackUp;
        BLL_BackUp oBLLBackUp;
        BLL_Usuario oBLLUsuario;
        List<Control> ListaControles;
        E_Usuario oUsuario;
        BLL_LogIn oBLLLogin;
        BLL_Permiso oBLLPermiso;
        int _usuario; DateTime _fecha;

        public VistaBackUp(Form pForm, Form pForm2)
        {
            try
            {
                ListaControles = new List<Control>();
                // Se guarda en una variable privada la referencia al formulario que llega al parámetro del constructor
                frmBackUp = pForm;
                frmHistorialBackUp = pForm2;

                foreach (System.Windows.Forms.Control c in frmBackUp.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }

                ((Button)ListaControles.Find(x => x.Nombre == "btn_GuardarBackUp").Puntero).Click += btn_GuardarBackUp_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_CancelarBackUp").Puntero).Click += btn_CancelarBackUp_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_RealizarBackUp").Puntero).Click += btn_RealizarBackUp_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_Historial").Puntero).Click += btn_Historial_Click;
                frmBackUp.Load += frmBackUp_Load;

                oBackUp = new E_BackUp();
                oBLLBackUp = new BLL_BackUp();
                oBLLUsuario = new BLL_Usuario();
                oBLLLogin = new BLL_LogIn();
                oUsuario = new E_Usuario();
                oBLLPermiso = new BLL_Permiso();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region "Funciones delegadas de eventos UI"

        private void frmBackUp_Load(object sender, EventArgs e)
        {
            try
            {
                DesactivarComponentes();
                CargarComboUsuario();
                VerificarPermisos();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
        //Boton Guardar backup.
        private void btn_GuardarBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                _usuario = int.Parse(((ComboBox)ListaControles.Find(x => x.Nombre == "cb_Usuario").Puntero).SelectedValue.ToString());
                _fecha = ((DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaBackUp").Puntero).Value;
                //Llamo al metodo, y le paso el objeto con sus valores.
                Alta(oBackUp);
                //Aviso.
                MessageBox.Show("Datos almacenados correctamente: \n" + "Usuario: " + oBackUp.oUsuario.idUsuario + "\n" + "Fecha: " + oBackUp.Fecha, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Activo los demas botones.
                ActivarComponentes();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
        //Boton Cancelar backUp.
        private void btn_CancelarBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                DateTimePicker dtFecha = (DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaBackUp").Puntero;
                dtFecha.Value = DateTime.Now;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Boton Realizar backup.
        private void btn_RealizarBackUp_Click(object sender, EventArgs e)
        {
            Button btnRealizar = (Button)ListaControles.Find(x => x.Nombre == "btn_RealizarBackUp").Puntero;

            try
            {
                //Establezco que el usuario coloque una ubicacion para guardar el archivo.
                SaveFileDialog dialog = new SaveFileDialog();
                //Establezco el filtro para que sean solo archivos .xml los que se guarden.
                dialog.Filter = "Archivos xml (*.xml)|*.xml";
                //Creo una variable.
                string ruta = string.Empty;
                //Obtengo la ruta y asigno nombre del archivo del backUp.
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ruta = dialog.FileName;
                }
                //Llamo al metodo RealizarBackUp y le paso la ruta donde se va a almacenar el archivo .xml.
                oBLLBackUp.RealizarBackUp(ruta);
                //Aviso.
                MessageBox.Show("BackUp realizado con exito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Desactivo boton.
                btnRealizar.Enabled = false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }         
        }
        //Boton Historal de backup.
        private void btn_Historial_Click(object sender, EventArgs e)
        {
            try
            {
                frmHistorialBackUp.Show();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        #endregion

        //Metodo para verificar permisos.
        private void VerificarPermisos()
        {
            Label lblUsuario = (Label)ListaControles.Find(x => x.Nombre == "lbl_UsuarioLog").Puntero;
            Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_GuardarBackUp").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarBackUp").Puntero;
            Button btnRealizar = (Button)ListaControles.Find(x => x.Nombre == "btn_RealizarBackUp").Puntero;
            Button btnHistorial = (Button)ListaControles.Find(x => x.Nombre == "btn_Historial").Puntero;
            try
            {
                List<Permiso> Perfil = new List<Permiso>();
                List<Button> listaBotones = new List<Button>() { btnGuardar, btnCancelar, btnRealizar, btnHistorial };
                //Muestro en el label el usuario logeado.
                //Obtengo el id del usuario logeado.
                oUsuario.idUsuario = int.Parse(oBLLLogin.ObtenerUsuarioLogeado());
                //Obtengo el nombre del usuario.
                oBLLUsuario.ObtenerNombreUsuario(oUsuario);
                //Asigno al label el nombre de usuario.
                lblUsuario.Text = oUsuario.Nombre;
                //Verifico el pemriso que tiene ese usuario.
                oBLLUsuario.VerificarTipoUsuario(oUsuario);
                //Asigno a lista perfil, la carga de permiso.
                Perfil = oBLLPermiso.CargarPermisos(oUsuario.oPermiso.Id);

                //Recorro la lista de botones.
                foreach (Button boton in listaBotones)
                {
                    if (Perfil.Exists(x => x.Id == ((Button)boton).Tag.ToString()))
                    {
                        boton.Visible = true;
                    }
                    else
                    {
                        boton.Visible = false;
                    }

                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void DesactivarComponentes()
        {
            Button btnRealizarBackUp = (Button)ListaControles.Find(x => x.Nombre == "btn_RealizarBackUp").Puntero;
            try
            {
                btnRealizarBackUp.Enabled = false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void ActivarComponentes()
        {
            Button btnRealizarBackUp = (Button)ListaControles.Find(x => x.Nombre == "btn_RealizarBackUp").Puntero;
            try
            {
                btnRealizarBackUp.Enabled = true;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void Alta(E_BackUp oBackUp)
        {
            try
            {
                oBackUp.oUsuario.idUsuario = _usuario;
                oBackUp.Fecha = _fecha;

                oBLLBackUp.Alta(oBackUp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void CargarComboUsuario()
        {
            try
            {
                ComboBox cbUsuario = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Usuario").Puntero;

                //Establezco una instancia de BLL  con el metodo listar.
                cbUsuario.DataSource = oBLLUsuario.Listar();
                //Establezco el valor real.
                cbUsuario.ValueMember = "idUsuario";
                //Establezco el valor que muestro.
                cbUsuario.DisplayMember = "Nombre";
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
