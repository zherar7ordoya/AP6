using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using ServiciosI;
using BLL;
using System.Windows.Forms;
using PermisoComposite;
using System.Security.Cryptography;
using ServiciosEncriptacion;
using System.Text.RegularExpressions;
using ServiciosDGV;

namespace Controlador_Vista
{
    public class VistaUsuario : Iabmc<E_Usuario>
    {
        System.Windows.Forms.Form frmUsuario;
        E_Usuario oUsuario;
        BLL_Usuario oBLLUsuario;
        List<Control> ListaControles;
        BLL_Permiso oBLLPermiso;
        Encriptacion oEncriptacion;
        DateTime _fechaAlta;  string _nombreUsuario; string _contraseña; string _permiso; int _id;
        EdicionDGV oEdicionDgv;
        string Accion;
        BLL_LogIn oBLLLogin;

        public VistaUsuario(Form pForm)
        {
            try
            {
                ListaControles = new List<Control>();
                // Se guarda en una variable privada la referencia al formulario que llega al parámetro del constructor
                frmUsuario = pForm;
                //Recorro el form en busca de controles.
                foreach (System.Windows.Forms.Control c in frmUsuario.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }

                ((Button)ListaControles.Find(x => x.Nombre == "btn_GuardarUsuario").Puntero).Click += btn_AceptarUsuario_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_AltaUsuario").Puntero).Click += btn_AltaUsuario_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_CancelarUsuario").Puntero).Click += btn_CancelarUsuario_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_BajaUsuario").Puntero).Click += btn_BajaUsuario_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_ModUsuario").Puntero).Click += btn_ModUsuario_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_DesbloquearCuenta").Puntero).Click += btn_DesbloquearCuenta_Click;
                ((TextBox)ListaControles.Find(x => x.Nombre == "txt_Busqueda").Puntero).KeyUp += txt_Busqueda_KeyUp;
                frmUsuario.Load += frmUsuario_Load;

                oUsuario = new E_Usuario();
                oBLLUsuario = new BLL_Usuario();
                oBLLPermiso = new BLL_Permiso();
                oEncriptacion = new Encriptacion();
                oBLLLogin = new BLL_LogIn();
                oEdicionDgv = new EdicionDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region "Funciones delegadas de eventos UI"
        private void frmUsuario_Load(object sender, EventArgs e)
        {
            DataGridView _dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Usuarios").Puntero;
            try
            {
                oEdicionDgv.EditarDGV(_dgv);
                ActualizarGrilla();
                DesactivarComponentes();
                CargarComboPermiso();
                VerificarPermisos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_AceptarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validaciones
                //Valido que no quede en blanco el id de usuario.
                if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_IdUsuario").Puntero).Text))
                {
                    MessageBox.Show("Debe ingresar el id de usuario!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    ((TextBox)ListaControles.Find(x => x.Nombre == "txt_IdUsuario").Puntero).Focus();
                    return;
                }
                //Valido que no quede en blanco el nombre de usuario.
                if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreUsuario").Puntero).Text))
                {
                    MessageBox.Show("Debe ingresar el nombre de usuario!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    ((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreUsuario").Puntero).Focus();
                    return;
                }
                //Valido la contraseña, entre 8 y 15 caracteres, al menos una minuscula, al menos una mayuscula, al menos un numero, sin espacios en blanco y al menos un caracter especial.
                Regex exp = new Regex("(?=^.{8,15}$)(?=.*\\d)(?=.*[A-Z])(?=.*[a-z])(?!.*\\s).*$");

                if (!exp.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_ContraseñaUsuario").Puntero).Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de contraseña.\n" +
                        "Debe contener:\n" +
                        "Entre 8 y 15 caracteres.\n" +
                        "Al menos una mayuscula.\n" +
                        "Al menos una minuscula. \n" +
                        "Al menos un numero.\n" +
                        "Sin espacios en blanco.\n" +
                        "Al menos un caracter especial (_,.*+-)", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                #endregion

                if (Accion =="A")
                {
                    #region Validacion
                    //Valido que la fecha de alta del usuario sea igual a la fecha actual.
                    if (((DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaAlta").Puntero).Value.Date != DateTime.Now.Date)
                    {
                        MessageBox.Show("La fecha de alta del usuario debe ser igual a la fecha actual!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    #endregion

                    _id = int.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_IdUsuario").Puntero).Text);
                    _fechaAlta = ((DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaAlta").Puntero).Value;
                    _nombreUsuario = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreUsuario").Puntero).Text;
                    _contraseña = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_ContraseñaUsuario").Puntero).Text;
                    _permiso = ((ComboBox)ListaControles.Find(x => x.Nombre == "cb_Permiso").Puntero).SelectedItem.ToString();
                    //Encripto.
                    oEncriptacion.EncriptarSimple(ref _nombreUsuario);
                    oEncriptacion.EncriptarSimple(ref _contraseña);

                    if(oBLLUsuario.ValidarIdUsuario(_id) == true)
                    {
                        if(oBLLUsuario.ValidarIdAumento(_id) == true)
                        {
                            if (oBLLUsuario.ValidarNombreUsuario(_nombreUsuario) == true)
                            {
                                Alta(oUsuario);
                            }
                            else
                            {
                                MessageBox.Show("Ya existe un usuario con el mismo nombre.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("El aumento entre un id y otro debe ser de 1.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Ya existe un usuario con el mismo Id.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else if(Accion =="M")
                {
                    _id = int.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_IdUsuario").Puntero).Text);
                    _fechaAlta = ((DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaAlta").Puntero).Value;
                    _nombreUsuario = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreUsuario").Puntero).Text;
                    _contraseña = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_ContraseñaUsuario").Puntero).Text;
                    _permiso = ((ComboBox)ListaControles.Find(x => x.Nombre == "cb_Permiso").Puntero).SelectedItem.ToString();
                    //Encripto.
                    oEncriptacion.EncriptarSimple(ref _nombreUsuario);
                    oEncriptacion.EncriptarSimple(ref _contraseña);

                    Modificar(oUsuario);
                }
                
                ActualizarGrilla();
                Limpiar();
                DesactivarComponentes();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btn_AltaUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                ActivarComponentes();
                Accion = "A";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btn_BajaUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView _dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Usuarios").Puntero;

                    //Me aseguro que haya un usuario seleccionado.
                    if (_dgv.CurrentRow == null)
                    {
                        MessageBox.Show("Debe seleccionar el usuario a eliminar", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    //Pregunto si deseo eliminar el usuario.
                    oUsuario = (E_Usuario)_dgv.CurrentRow.DataBoundItem;
                    if (MessageBox.Show("¿Está seguro que desea eliminar " + oUsuario.Nombre.ToString() + " ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1
                    ) == DialogResult.Yes)
                    {
                        //Se elimina el usuario.
                        Baja(oUsuario);
                        //Refresco grilla.
                        ActualizarGrilla();
                    }
                
            }
            catch (Exception ex)
            { MessageBox.Show("Error: " + ex); }
        }

        private void btn_ModUsuario_Click(object sender, EventArgs e)
        {
            DataGridView _dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Usuarios").Puntero;
            TextBox txtId = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IdUsuario").Puntero;
            TextBox txtNombre = (TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreUsuario").Puntero;
            TextBox txtContraseña = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ContraseñaUsuario").Puntero;
            DateTimePicker dtFechaAlta = (DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaAlta").Puntero;
            ComboBox cbPermiso = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Permiso").Puntero;
            
            try
            {
                ActivarComponentes();
                txtId.Enabled = false;
                //Me aseguro de haya un usuario seleccionado.
                if (_dgv.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar un usuario a modificar", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }

                //Obtengo el usuario.
                oUsuario = (E_Usuario)_dgv.CurrentRow.DataBoundItem;

                //Paso valores de la grilla a los txt.
                txtId.Text = oUsuario.idUsuario.ToString();
                dtFechaAlta.Text = oUsuario.fechaAlta.ToString();
                txtNombre.Text = oUsuario.Nombre;
                txtContraseña.Text = oUsuario.Contraseña;
                cbPermiso.DisplayMember = oUsuario.oPermiso.Id;

                //Establezco la variable Accion en modo MODIFICAR..
                Accion = "M";
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo KeyUp del txt de busqueda.
        private void txt_Busqueda_KeyUp(object sender, KeyEventArgs e)
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Usuarios").Puntero;
            TextBox txtBusqueda = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Busqueda").Puntero;
            string pNombre;
            pNombre = txtBusqueda.Text;

            try
            {
                if (txtBusqueda.Text == string.Empty)
                {
                    ActualizarGrilla();
                }
                else
                {
                    dgv.DataSource = Consultar(pNombre);
                }

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_DesbloquearCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Usuarios").Puntero;
                //Me aseguro que haya un usuario seleccionado.
                if (dgv.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar el usuario a desbloquear", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Pregunto si deseo eliminar el usuario.
                oUsuario = (E_Usuario)dgv.CurrentRow.DataBoundItem;
                if (MessageBox.Show("¿Está seguro que desea desbloquear el usuario: " + oUsuario.Nombre.ToString() + " ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1
                ) == DialogResult.Yes)
                {

                    //Se desbloquea el usuario.
                    DesbloquearUsuario(oUsuario);
                    //Refresco grilla.
                    ActualizarGrilla();
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_CancelarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar();
                DesactivarComponentes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void ActualizarGrilla()
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Usuarios").Puntero;
            try
            {
                dgv.DataSource = null;
                dgv.DataSource = Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }         
        }

        private void DesactivarComponentes()
        {
            TextBox txtId = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IdUsuario").Puntero;
            TextBox txtNombre = (TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreUsuario").Puntero;
            TextBox txtContraseña = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ContraseñaUsuario").Puntero;
            DateTimePicker dtFechaAlta = (DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaAlta").Puntero;
            ComboBox cbPermiso = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Permiso").Puntero;
            Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_GuardarUsuario").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarUsuario").Puntero;
            try
            {
                txtId.Enabled = false;
                txtNombre.Enabled = false;
                txtContraseña.Enabled = false;
                dtFechaAlta.Enabled = false;
                cbPermiso.Enabled = false;
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }


        private void ActivarComponentes()
        {
            TextBox txtId = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IdUsuario").Puntero;
            TextBox txtNombre = (TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreUsuario").Puntero;
            TextBox txtContraseña = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ContraseñaUsuario").Puntero;
            DateTimePicker dtFechaAlta = (DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaAlta").Puntero;
            ComboBox cbPermiso = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Permiso").Puntero;
            Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_GuardarUsuario").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarUsuario").Puntero;
            try
            {
                txtId.Enabled = true;
                txtNombre.Enabled = true;
                txtContraseña.Enabled = true;
                dtFechaAlta.Enabled = true;
                cbPermiso.Enabled = true;
                btnGuardar.Enabled = true;
                btnCancelar.Enabled = true;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void Limpiar()
        {
            TextBox txtId = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IdUsuario").Puntero;
            TextBox txtNombre = (TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreUsuario").Puntero;
            TextBox txtContraseña = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ContraseñaUsuario").Puntero;
            DateTimePicker dtFechaAlta = (DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaAlta").Puntero;
            try
            {
                txtId.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtContraseña.Text = string.Empty;
                dtFechaAlta.Value = DateTime.Now;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void VerificarPermisos()
        {
            try
            {
                Label lblUsuario = (Label)ListaControles.Find(x => x.Nombre == "lbl_UsuarioLog").Puntero;
                Label lblAviso = (Label)ListaControles.Find(x => x.Nombre == "lbl_Aviso").Puntero;
                Button btnAlta = (Button)ListaControles.Find(x => x.Nombre == "btn_AltaUsuario").Puntero;
                Button btnBaja = (Button)ListaControles.Find(x => x.Nombre == "btn_BajaUsuario").Puntero;
                Button btnMod = (Button)ListaControles.Find(x => x.Nombre == "btn_ModUsuario").Puntero;
                Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_GuardarUsuario").Puntero;
                Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarUsuario").Puntero;
                Button btnDesbloquear = (Button)ListaControles.Find(x => x.Nombre == "btn_DesbloquearCuenta").Puntero;
                TextBox txtBusqueda = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Busqueda").Puntero;
                DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Usuarios").Puntero;
                try
                {
                    //El tipo true significa que tiene los permisos, en cambio el tipo false no.
                    bool tipoUsuario = true;
                    List<Permiso> Perfil = new List<Permiso>();
                    List<Button> listaBotones = new List<Button>() { btnAlta, btnBaja, btnMod, btnGuardar, btnCancelar, btnDesbloquear };
                    List<DataGridView> listaDgv = new List<DataGridView>() { dgv };
                    List<TextBox> listaTxt = new List<TextBox>() { txtBusqueda };
                    //Muestro en el label el usuario logeado.
                    //Obtengo el id del usuario logeado.
                    oUsuario.idUsuario = int.Parse(oBLLLogin.ObtenerUsuarioLogeado());
                    //Obtengo el nombre del usuario.
                    oBLLUsuario.ObtenerNombreUsuario(oUsuario);
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
                            //Pongo variable en true.
                            tipoUsuario = true;
                        }
                        else
                        {
                            boton.Visible = false;
                            //Pongo la variable en false, para mostrar aviso (label).
                            tipoUsuario = false;
                        }

                    }
                    //Recorro la lista de dgv.
                    foreach (DataGridView d in listaDgv)
                    {
                        if (Perfil.Exists(x => x.Id == ((DataGridView)d).Tag.ToString()))
                        {
                            d.Visible = true;
                        }
                        else
                        {
                            d.Visible = false;
                        }

                    }
                    //Recorro la lista de txt.
                    foreach (TextBox t in listaTxt)
                    {
                        if (Perfil.Exists(x => x.Id == ((TextBox)t).Tag.ToString()))
                        {
                            t.Visible = true;
                        }
                        else
                        {
                            t.Visible = false;
                        }
                    }
                    //Si no tiene permisos, aviso.
                    if (tipoUsuario == false)
                    {
                        lblAviso.Enabled = true;
                        lblAviso.Location = new System.Drawing.Point(90, 200);
                        lblAviso.Text = "No posee permisos para trabajar con esta opción del sistema.";
                    }
                    else
                    {
                        lblAviso.Hide();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
              

        }

        public void Alta(E_Usuario oUsuario)
        {
            try
            {
                oUsuario.idUsuario = _id;
                oUsuario.fechaAlta = _fechaAlta;
                oUsuario.Nombre = _nombreUsuario;
                oUsuario.Contraseña = _contraseña;
                oUsuario.oPermiso.Id = _permiso;

                oBLLUsuario.Alta(oUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Baja(E_Usuario oUsuario)
        {
            try
            {
                oBLLUsuario.Baja(oUsuario);
            }

            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Usuario> Listar()
        {
            try
            {
                return oBLLUsuario.Listar();

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void Modificar(E_Usuario oUsuario)
        {
            try
            {
                oUsuario.fechaAlta = _fechaAlta;
                oUsuario.Nombre = _nombreUsuario;
                oUsuario.Contraseña = _contraseña;
                oUsuario.oPermiso.Id = _permiso;

                oBLLUsuario.Modificar(oUsuario);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Usuario> Consultar(string pNombre)
        {
            try
            {
                return oBLLUsuario.Consultar(pNombre);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void DesbloquearUsuario(E_Usuario oUsuario)
        {
            try
            {
                oBLLUsuario.DesbloquearUsuario(oUsuario);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void CargarComboPermiso()
        {
            try
            {
                ComboBox cbPermiso = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Permiso").Puntero;

                //Establezco una instancia de BLL con el metodo listar.
                cbPermiso.DataSource = oBLLPermiso.Listar();
                //Establezco el valor real.
                cbPermiso.ValueMember = "Id";
                //Establezco el valor que muestro.
                cbPermiso.DisplayMember = "Nombre";
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }
        }
    }
}
