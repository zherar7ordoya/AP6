using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using BLL;
using ServiciosI;
using ServiciosDGV;
using System.Windows.Forms;
using PermisoComposite;
using System.Text.RegularExpressions;

namespace Controlador_Vista
{
    public class VistaGerente : Iabmc<E_Gerente>
    {
        System.Windows.Forms.Form frmGerente;
        E_Gerente oGerente;
        BLL_Gerente oBLLGerente;
        BLL_Usuario oBLLUsuario;
        E_Usuario oUsuario;
        BLL_LogIn oBLLLogin;
        List<Control> ListaControles;
        BLL_Permiso oBLLPermiso;
        EdicionDGV oEdicionDgv;
        int _dni; string _nombre; string _apellido; string _direccion; Int64 _celular; Int64 _telefono; DateTime _fechaNac; string _estadoCivil; decimal _sueldoBruto; int _idUsuario; string _mailPersonal; string _mailEmpresarial;
        string Accion;

        public VistaGerente(Form pForm)
        {
            try
            {
                ListaControles = new List<Control>();
                // Se guarda en una variable privada la referencia al formulario que llega al parámetro del constructor
                frmGerente = pForm;
                //Recorro el form en busca de controles.
                foreach (System.Windows.Forms.Control c in frmGerente.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }

                ((Button)ListaControles.Find(x => x.Nombre == "btn_GuardarGerente").Puntero).Click += btn_GuardarGerente_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_AltaGerente").Puntero).Click += btn_AltaGerente_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_CancelarGerente").Puntero).Click += btn_CancelarGerente_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_BajaGerente").Puntero).Click += btn_BajaGerente_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_ModGerente").Puntero).Click += btn_ModGerente_Click;
                ((TextBox)ListaControles.Find(x => x.Nombre == "txt_Busqueda").Puntero).KeyUp += txt_Busqueda_KeyUp;
                frmGerente.Load += frmGerente_Load;


                oBLLPermiso = new BLL_Permiso();
                oGerente = new E_Gerente();
                oBLLGerente = new BLL_Gerente();
                oUsuario = new E_Usuario();
                oBLLUsuario = new BLL_Usuario();
                oBLLLogin = new BLL_LogIn();
                oEdicionDgv = new EdicionDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region "Funciones delegadas de eventos UI"
        private void frmGerente_Load(object sender, EventArgs e)
        {
            DataGridView _dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Gerentes").Puntero;
            try
            {
                oEdicionDgv.EditarDGV(_dgv);
                ActualizarGrilla();
                DesactivarComponentes();
                CargarComboUsuario();
                VerificarPermisos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Boton Guardar
        private void btn_GuardarGerente_Click(object sender, EventArgs e)
        {
            try
            {

                #region Validaciones
                //Valido que no quede en blanco el txt de dni.
                if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_DniGerente").Puntero).Text))
                {
                    MessageBox.Show("Debe ingresar el dni del gerente!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    ((TextBox)ListaControles.Find(x => x.Nombre == "txt_DniGerente").Puntero).Focus();
                    return;
                }
                //Valido que la cantidad de digitos del dni sea 8.
                Regex exp = new Regex("^([0-9]{8})");
                if (!exp.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_DniGerente").Puntero).Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de DNI. Debe contener 8 digitos", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Valido que no quede en blanco el txt de nombre.
                if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreGerente").Puntero).Text))
                {
                    MessageBox.Show("Debe ingresar el nombre del gerente!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    ((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreGerente").Puntero).Focus();
                    return;
                }
                //Valido que no quede en blanco el txt de apellido.
                if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_ApellidoGerente").Puntero).Text))
                {
                    MessageBox.Show("Debe ingresar el apellido del gerente!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    ((TextBox)ListaControles.Find(x => x.Nombre == "txt_ApellidoGerente").Puntero).Focus();
                    return;
                }
                //Valido que no se escriban numeros en el nombre.
                Regex exp2 = new Regex("^([a-zA-Z])");
                if (!exp2.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreGerente").Puntero).Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de nombre. Deben ser solo letras", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Valido que no se escriban numeros en el apellido.
                if (!exp2.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_ApellidoGerente").Puntero).Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de apellido. Deben ser solo letras", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Valido que no quede en blanco el txt de direccion.
                if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_DireccionGerente").Puntero).Text))
                {
                    MessageBox.Show("Debe ingresar la direccion del gerente!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    ((TextBox)ListaControles.Find(x => x.Nombre == "txt_DireccionGerente").Puntero).Focus();
                    return;
                }
                //Valido que no quede en blanco el txt de celular.
                if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_CelularGerente").Puntero).Text))
                {
                    MessageBox.Show("Debe ingresar el celular del gerente!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    ((TextBox)ListaControles.Find(x => x.Nombre == "txt_CelularGerente").Puntero).Focus();
                    return;
                }
                //Valido que no quede en blanco el txt de telefono.
                if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_TelefonoGerente").Puntero).Text))
                {
                    MessageBox.Show("Debe ingresar el telefono del gerente!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    ((TextBox)ListaControles.Find(x => x.Nombre == "txt_TelefonoGerente").Puntero).Focus();
                    return;
                }
                //Valido el formato de celular y telefono.
                Regex exp3 = new Regex("^[0-9]+$");
                if (!exp3.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_CelularGerente").Puntero).Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de celular. Deben ser solo numeros.", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                if (!exp3.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_TelefonoGerente").Puntero).Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de telefono. Deben ser solo numeros.", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Valido que la fecha de nacimiento sea menor a la fecha actual.
                if (((DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaNac").Puntero).Value.Date >= DateTime.Now.Date)
                {
                    MessageBox.Show("Ingreso incorrecto de fecha de nacimiento. Debe ser menor a la fecha actual.", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Valido que no quede en blanco el txt de estado civil.
                if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_EstCivilGerente").Puntero).Text))
                {
                    MessageBox.Show("Debe ingresar el estado civil del gerente!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    ((TextBox)ListaControles.Find(x => x.Nombre == "txt_EstCivilGerente").Puntero).Focus();
                    return;
                }
                //Valido que el estado civil sea soltero, casado, viudo, divorciado.
                Regex exp4 = new Regex("(soltero|Soltero|casado|Casado|viudo|Viudo|divorciado|Divorciado)");

                if (!exp4.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_EstCivilGerente").Puntero).Text))
                {
                    MessageBox.Show("Ingreso incorrecto de estado civil. Debe ser soltero, casado, viudo o divorciado", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Valido que no quede en blanco el txt de sueldo bruto.
                if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_SdoBrutoGerente").Puntero).Text))
                {
                    MessageBox.Show("Debe ingresar el sueldo bruto del gerente!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    ((TextBox)ListaControles.Find(x => x.Nombre == "txt_SdoBrutoGerente").Puntero).Focus();
                    return;
                }
                //Valido que el sueldo bruto sea mayor a 0.
                if (decimal.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_SdoBrutoGerente").Puntero).Text) <= 0)
                {
                    MessageBox.Show("Ingreso incorrecto de sueldo bruto. Debe ser mayor a $0.", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Valido formato decimal para sueldo bruto.
                Regex exp5 = new Regex("^[0-9]*\\,?[0-9]*$");
                if (!exp5.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_SdoBrutoGerente").Puntero).Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de sueldo bruto. En caso de ingresar un numero decimal utilizar , (coma). Si esta trabajando con numeros enteros debe ser mayor a 0 (cero)", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Valido que no quede en blanco el txt de mail personal.
                if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_MailGerente").Puntero).Text))
                {
                    MessageBox.Show("Debe ingresar el mail personal del gerente!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    ((TextBox)ListaControles.Find(x => x.Nombre == "txt_MailGerente").Puntero).Focus();
                    return;
                }
                //Valido que no quede en blanco el txt de mail empresarial.
                if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_MailEmpGerente").Puntero).Text))
                {
                    MessageBox.Show("Debe ingresar el mail empresarial del gerente!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    ((TextBox)ListaControles.Find(x => x.Nombre == "txt_MailEmpGerente").Puntero).Focus();
                    return;
                }
                //Valido el formato de mail personal y empresarial.
                Regex exp6 = new Regex("^([\\w-]+\\.)*?[\\w-]+@[\\w-]+\\.([\\w-]+\\.)*?[\\w]+$");
                if (!exp6.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_MailGerente").Puntero).Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de email personal.", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                if (!exp6.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_MailEmpGerente").Puntero).Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de email empresarial.", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                #endregion

                if (Accion == "A")
                {
                    _dni = int.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_DniGerente").Puntero).Text);
                    _nombre = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreGerente").Puntero).Text;
                    _apellido = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_ApellidoGerente").Puntero).Text;
                    _direccion = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_DireccionGerente").Puntero).Text;
                    _celular = long.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_CelularGerente").Puntero).Text);
                    _telefono = long.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_TelefonoGerente").Puntero).Text);
                    _fechaNac = ((DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaNac").Puntero).Value;
                    _estadoCivil = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_EstCivilGerente").Puntero).Text;
                    _sueldoBruto = decimal.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_SdoBrutoGerente").Puntero).Text);
                    _idUsuario = int.Parse(((ComboBox)ListaControles.Find(x => x.Nombre == "cb_Usuario").Puntero).SelectedValue.ToString());
                    _mailPersonal = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_MailGerente").Puntero).Text;
                    _mailEmpresarial = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_MailEmpGerente").Puntero).Text;

                    if(oBLLGerente.ValidarCodigo(_dni) == true)
                    {
                        Alta(oGerente);
                    }
                    else
                    {
                        MessageBox.Show("Ya existe un gerente con el mismo Dni.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else if (Accion == "M")
                {
                    _dni = int.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_DniGerente").Puntero).Text);
                    _nombre = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreGerente").Puntero).Text;
                    _apellido = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_ApellidoGerente").Puntero).Text;
                    _direccion = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_DireccionGerente").Puntero).Text;
                    _celular = long.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_CelularGerente").Puntero).Text);
                    _telefono = long.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_TelefonoGerente").Puntero).Text);
                    _fechaNac = ((DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaNac").Puntero).Value;
                    _estadoCivil = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_EstCivilGerente").Puntero).Text;
                    _sueldoBruto = decimal.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_SdoBrutoGerente").Puntero).Text);
                    _idUsuario = int.Parse(((ComboBox)ListaControles.Find(x => x.Nombre == "cb_Usuario").Puntero).SelectedValue.ToString());
                    _mailPersonal = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_MailGerente").Puntero).Text;
                    _mailEmpresarial = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_MailEmpGerente").Puntero).Text;

                    Modificar(oGerente);
                }

                ActualizarGrilla();
                Limpiar();
                DesactivarComponentes();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btn_AltaGerente_Click(object sender, EventArgs e)
        {
            try
            {
                ActivarComponentes();
                Accion = "A";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btn_BajaGerente_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView _dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Gerentes").Puntero;

                //Establezco condicion.
                if (!string.IsNullOrEmpty(oGerente.Dni.ToString()))
                {
                    //Me aseguro que haya un gerente seleccionado.
                    if (_dgv.CurrentRow == null)
                    {
                        MessageBox.Show("Debe seleccionar el gerente a eliminar", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    //Pregunto si deseo eliminar el gerente.
                    oGerente = (E_Gerente)_dgv.CurrentRow.DataBoundItem;
                    if (MessageBox.Show("¿Está seguro que desea eliminar a " + oGerente.Nombre.ToString() + " ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1
                    ) == DialogResult.Yes)
                    {
                        //Se elimina el gerente.
                        Baja(oGerente);
                        //Refresco grilla.
                        ActualizarGrilla();
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_ModGerente_Click(object sender, EventArgs e)
        {
            try
            {
                //Activo componentes.
                ActivarComponentes();
                DataGridView _dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Gerentes").Puntero;
                TextBox txtDni = (TextBox)ListaControles.Find(x => x.Nombre == "txt_DniGerente").Puntero;
                TextBox txtNombre = (TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreGerente").Puntero;
                TextBox txtApellido = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ApellidoGerente").Puntero;
                TextBox txtDireccion = (TextBox)ListaControles.Find(x => x.Nombre == "txt_DireccionGerente").Puntero;
                TextBox txtCelular = (TextBox)ListaControles.Find(x => x.Nombre == "txt_CelularGerente").Puntero;
                TextBox txtTelefono = (TextBox)ListaControles.Find(x => x.Nombre == "txt_TelefonoGerente").Puntero;
                DateTimePicker dtFecha = (DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaNac").Puntero;
                TextBox txtEstadoCivil = (TextBox)ListaControles.Find(x => x.Nombre == "txt_EstCivilGerente").Puntero;
                TextBox txtSdoBruto = (TextBox)ListaControles.Find(x => x.Nombre == "txt_SdoBrutoGerente").Puntero;
                ComboBox cb_Usuario = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Usuario").Puntero;
                TextBox txtMail = (TextBox)ListaControles.Find(x => x.Nombre == "txt_MailGerente").Puntero;
                TextBox txtMailEmp = (TextBox)ListaControles.Find(x => x.Nombre == "txt_MailEmpGerente").Puntero;
                txtDni.Enabled = false;

                //Me aseguro de haya un gerente seleccionado.
                if (_dgv.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar un gerente a modificar", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }

                //Obtengo el gerente.
                oGerente = (E_Gerente)_dgv.CurrentRow.DataBoundItem;

                //Paso valores de la grilla a los txt.
                txtDni.Text = oGerente.Dni.ToString();
                txtNombre.Text = oGerente.Nombre;
                txtApellido.Text = oGerente.Apellido;
                txtDireccion.Text = oGerente.Direccion;
                txtCelular.Text = oGerente.Celular.ToString();
                txtTelefono.Text = oGerente.Telefono.ToString();
                dtFecha.Value = oGerente.fechaNacimiento;
                txtEstadoCivil.Text = oGerente.estadoCivil;
                txtSdoBruto.Text = oGerente.sueldoBruto.ToString();
                cb_Usuario.DisplayMember = oGerente.oUsuario.idUsuario.ToString();
                txtMail.Text = oGerente.mailPersonal;
                txtMailEmp.Text = oGerente.mailEmpresarial;

                //Establezco la variable Accion en modo MODIFICAR..
                Accion = "M";
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Evento KeyUp del txt de busqueda.
        private void txt_Busqueda_KeyUp(object sender, KeyEventArgs e)
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Gerentes").Puntero;
            try
            {
                TextBox txtBusqueda = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Busqueda").Puntero;
                string pNombre;
                pNombre = txtBusqueda.Text;

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

        private void btn_CancelarGerente_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar();
                DesactivarComponentes();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        #endregion

        private void ActualizarGrilla()
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Gerentes").Puntero;
            try
            {
                dgv.DataSource = null;
                dgv.DataSource = oBLLGerente.Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void VerificarPermisos()
        {
            try
            {
                Label lblUsuario = (Label)ListaControles.Find(x => x.Nombre == "lbl_UsuarioLog").Puntero;
                Label lblAviso = (Label)ListaControles.Find(x => x.Nombre == "lbl_Aviso").Puntero;
                Button btnAlta = (Button)ListaControles.Find(x => x.Nombre == "btn_AltaGerente").Puntero;
                Button btnBaja = (Button)ListaControles.Find(x => x.Nombre == "btn_BajaGerente").Puntero;
                Button btnMod = (Button)ListaControles.Find(x => x.Nombre == "btn_ModGerente").Puntero;
                Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_GuardarGerente").Puntero;
                Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarGerente").Puntero;
                TextBox txtBusqueda = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Busqueda").Puntero;
                DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Gerentes").Puntero;
                //El tipo true significa que tiene los permisos, en cambio el tipo false no.
                bool tipoUsuario = true;
                List<Permiso> Perfil = new List<Permiso>();
                List<Button> listaBotones = new List<Button>() { btnAlta, btnBaja, btnMod, btnGuardar, btnCancelar };
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
                    }
                    else
                    {
                        boton.Visible = false;
                    }

                }
                //Recorro la lista de dgv.
                foreach (DataGridView d in listaDgv)
                {
                    if (Perfil.Exists(x => x.Id == ((DataGridView)d).Tag.ToString()))
                    {
                        d.Visible = true;
                        //Pongo variable en true.
                        tipoUsuario = true;
                    }
                    else
                    {
                        d.Visible = false;
                        //Pongo la variable en false, para mostrar aviso (label).
                        tipoUsuario = false;
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
                //Si no hay permisos, aviso.
                if (tipoUsuario == false)
                {
                    lblAviso.Enabled = true;
                    lblAviso.Location = new System.Drawing.Point(100, 200);
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
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }
        }

        private void DesactivarComponentes()
        {
            TextBox txtDni = (TextBox)ListaControles.Find(x => x.Nombre == "txt_DniGerente").Puntero;
            TextBox txtNombre = (TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreGerente").Puntero;
            TextBox txtApellido = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ApellidoGerente").Puntero;
            TextBox txtDireccion = (TextBox)ListaControles.Find(x => x.Nombre == "txt_DireccionGerente").Puntero;
            TextBox txtCelular = (TextBox)ListaControles.Find(x => x.Nombre == "txt_CelularGerente").Puntero;
            TextBox txtTelefono = (TextBox)ListaControles.Find(x => x.Nombre == "txt_TelefonoGerente").Puntero;
            TextBox txtMail = (TextBox)ListaControles.Find(x => x.Nombre == "txt_MailGerente").Puntero;
            TextBox txtMailEmp = (TextBox)ListaControles.Find(x => x.Nombre == "txt_MailEmpGerente").Puntero;
            DateTimePicker dtFecha = (DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaNac").Puntero;
            TextBox txtEstadoCivil = (TextBox)ListaControles.Find(x => x.Nombre == "txt_EstCivilGerente").Puntero;
            TextBox txtSdoBruto = (TextBox)ListaControles.Find(x => x.Nombre == "txt_SdoBrutoGerente").Puntero;
            ComboBox cb_Usuario = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Usuario").Puntero;
            Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_GuardarGerente").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarGerente").Puntero;

            try
            {
                txtDni.Enabled = false;
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                cb_Usuario.Enabled = false;
                txtDireccion.Enabled = false;
                txtCelular.Enabled = false;
                txtTelefono.Enabled = false;
                dtFecha.Enabled = false;
                txtEstadoCivil.Enabled = false;
                txtSdoBruto.Enabled = false;
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
                txtMail.Enabled = false;
                txtMailEmp.Enabled = false;
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }
        }

        private void ActivarComponentes()
        {
            TextBox txtDni = (TextBox)ListaControles.Find(x => x.Nombre == "txt_DniGerente").Puntero;
            TextBox txtNombre = (TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreGerente").Puntero;
            TextBox txtApellido = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ApellidoGerente").Puntero;
            TextBox txtDireccion = (TextBox)ListaControles.Find(x => x.Nombre == "txt_DireccionGerente").Puntero;
            TextBox txtCelular = (TextBox)ListaControles.Find(x => x.Nombre == "txt_CelularGerente").Puntero;
            TextBox txtTelefono = (TextBox)ListaControles.Find(x => x.Nombre == "txt_TelefonoGerente").Puntero;
            TextBox txtMail = (TextBox)ListaControles.Find(x => x.Nombre == "txt_MailGerente").Puntero;
            TextBox txtMailEmp = (TextBox)ListaControles.Find(x => x.Nombre == "txt_MailEmpGerente").Puntero;
            DateTimePicker dtFecha = (DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaNac").Puntero;
            TextBox txtEstadoCivil = (TextBox)ListaControles.Find(x => x.Nombre == "txt_EstCivilGerente").Puntero;
            TextBox txtSdoBruto = (TextBox)ListaControles.Find(x => x.Nombre == "txt_SdoBrutoGerente").Puntero;
            ComboBox cb_Usuario = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Usuario").Puntero;
            Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_GuardarGerente").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarGerente").Puntero;

            try
            {
                txtDni.Enabled = true;
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                cb_Usuario.Enabled = true;
                txtDireccion.Enabled = true;
                txtCelular.Enabled = true;
                txtTelefono.Enabled = true;
                dtFecha.Enabled = true;
                txtEstadoCivil.Enabled = true;
                txtSdoBruto.Enabled = true;
                btnGuardar.Enabled = true;
                btnCancelar.Enabled = true;
                txtMail.Enabled = true;
                txtMailEmp.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }
        }

        private void Limpiar()
        {
            TextBox txtDni = (TextBox)ListaControles.Find(x => x.Nombre == "txt_DniGerente").Puntero;
            TextBox txtNombre = (TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreGerente").Puntero;
            TextBox txtApellido = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ApellidoGerente").Puntero;
            TextBox txtDireccion = (TextBox)ListaControles.Find(x => x.Nombre == "txt_DireccionGerente").Puntero;
            TextBox txtCelular = (TextBox)ListaControles.Find(x => x.Nombre == "txt_CelularGerente").Puntero;
            TextBox txtTelefono = (TextBox)ListaControles.Find(x => x.Nombre == "txt_TelefonoGerente").Puntero;
            TextBox txtMail = (TextBox)ListaControles.Find(x => x.Nombre == "txt_MailGerente").Puntero;
            TextBox txtMailEmp = (TextBox)ListaControles.Find(x => x.Nombre == "txt_MailEmpGerente").Puntero;
            DateTimePicker dtFecha = (DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaNac").Puntero;
            TextBox txtEstadoCivil = (TextBox)ListaControles.Find(x => x.Nombre == "txt_EstCivilGerente").Puntero;
            TextBox txtSdoBruto = (TextBox)ListaControles.Find(x => x.Nombre == "txt_SdoBrutoGerente").Puntero;
            ComboBox cb_Usuario = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Usuario").Puntero;
            Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_GuardarGerente").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarGerente").Puntero;

            try
            {
                txtDni.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
                txtDireccion.Text = string.Empty;
                txtCelular.Text = string.Empty;
                txtTelefono.Text = string.Empty;
                dtFecha.Value = DateTime.Now;
                txtEstadoCivil.Text = string.Empty;
                txtSdoBruto.Text = string.Empty;
                txtMail.Text = string.Empty;
                txtMailEmp.Text = string.Empty;
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }

        }

        public void Alta(E_Gerente oGerente)
        {
            try
            {
                oGerente.Dni = _dni;
                oGerente.Nombre = _nombre;
                oGerente.Apellido = _apellido;
                oGerente.Direccion = _direccion;
                oGerente.Celular = _celular;
                oGerente.Telefono = _telefono;
                oGerente.fechaNacimiento = _fechaNac;
                oGerente.estadoCivil = _estadoCivil;
                oGerente.sueldoBruto = _sueldoBruto;
                oGerente.oUsuario.idUsuario = _idUsuario;
                oGerente.mailPersonal = _mailPersonal;
                oGerente.mailEmpresarial = _mailEmpresarial;

                oBLLGerente.Alta(oGerente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void Baja(E_Gerente oGerente)
        {
            try
            {
                oBLLGerente.Baja(oGerente);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Gerente> Listar()
        {
            try
            {
                return oBLLGerente.Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void Modificar(E_Gerente oGerente)
        {
            try
            {
                oGerente.Dni = _dni;
                oGerente.Nombre = _nombre;
                oGerente.Apellido = _apellido;
                oGerente.Direccion = _direccion;
                oGerente.Celular = _celular;
                oGerente.Telefono = _telefono;
                oGerente.fechaNacimiento = _fechaNac;
                oGerente.estadoCivil = _estadoCivil;
                oGerente.sueldoBruto = _sueldoBruto;
                oGerente.oUsuario.idUsuario = _idUsuario;
                oGerente.mailPersonal = _mailPersonal;
                oGerente.mailEmpresarial = _mailEmpresarial;

                oBLLGerente.Modificar(oGerente);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Gerente> Consultar(string pNombre)
        {
            try
            {
                return oBLLGerente.Consultar(pNombre);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}

