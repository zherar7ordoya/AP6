using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using ServiciosI;
using BLL;
using System.Windows.Forms;
using PermisoComposite;
using ServiciosEncriptacion;
using System.Text.RegularExpressions;
using ServiciosDGV;

namespace Controlador_Vista
{
    public class VistaProveedor : Iabmc<E_Proveedor>
    {
        System.Windows.Forms.Form frmProveedor;
        System.Windows.Forms.Form frmReporteProveedores;
        E_Proveedor oProveedor;
        BLL_Proveedor oBLLProveedor;
        BLL_Gerente oBLLGerente;
        BLL_Usuario oBLLUsuario;
        List<Control> ListaControles;
        BLL_Permiso oBLLPermiso;
        BLL_LogIn oBLLLogin;
        E_Usuario oUsuario;
        Encriptacion oEncriptacion;
        EdicionDGV oEdicionDgv;
        //Declaro variables.
        string _nombre; string _direccion; string _localidad; string _provincia; long _telefono; string _email; int _gerente; int _id;
        string Accion;

        public VistaProveedor(Form pForm, Form pForm2)
        {
            try
            {
                ListaControles = new List<Control>();
                // Se guarda en una variable privada la referencia al formulario que llega al parámetro del constructor
                frmProveedor = pForm;
                frmReporteProveedores = pForm2;
                //Recorro el form en busca de controles.
                foreach (System.Windows.Forms.Control c in frmProveedor.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }

                ((Button)ListaControles.Find(x => x.Nombre == "btn_AceptarProveedor").Puntero).Click += btn_AceptarProveedor_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_AltaProveedor").Puntero).Click += btn_AltaProveedor_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_CancelarProveedor").Puntero).Click += btn_CancelarProveedor_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_ModProveedor").Puntero).Click += btn_ModProveedor_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_ReporteProveedor").Puntero).Click += btn_ReporteProveedor_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_BajaProveedor").Puntero).Click += btn_BajaProveedor_Click;
                ((TextBox)ListaControles.Find(x => x.Nombre == "txt_Busqueda").Puntero).KeyUp += txt_Busqueda_KeyUp;

                frmProveedor.Load += frmProveedor_Load;

                oUsuario = new E_Usuario();
                oProveedor = new E_Proveedor();
                oBLLProveedor = new BLL_Proveedor();
                oBLLGerente = new BLL_Gerente();
                oBLLUsuario = new BLL_Usuario();
                oBLLPermiso = new BLL_Permiso();
                oBLLLogin = new BLL_LogIn();
                oEncriptacion = new Encriptacion();
                oEdicionDgv = new EdicionDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        #region "Funciones delegadas de eventos UI"

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            DataGridView _dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Proveedores").Puntero;
            try
            {
                oEdicionDgv.EditarDGV(_dgv);
                ActualizarGrilla();
                DesactivarComponentes();
                CargarComboGerente();
                VerificarPermisos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_AceptarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validaciones
                //Valido que no quede en blanco el txt de nombre.
                if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreProv").Puntero).Text))
                {
                    MessageBox.Show("Debe ingresar el nombre del proveedor!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    ((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreProv").Puntero).Focus();
                    return;
                }
                //Valido que no se escriban numeros en el nombre.
                Regex exp2 = new Regex("^([a-zA-Z])");
                if (!exp2.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreProv").Puntero).Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de nombre. Deben ser solo letras", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    ((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreProv").Puntero).Focus();
                    return;
                }
                //Valido que no quede en blanco el txt direccion.
                if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_DireccionProv").Puntero).Text))
                {
                    MessageBox.Show("Debe ingresar la direccion del proveedor!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    ((TextBox)ListaControles.Find(x => x.Nombre == "txt_DireccionProv").Puntero).Focus();
                    return;
                }
                //Valido que la direccion no sean solo numeros.
                Regex exp = new Regex("^[0-9]+$");

                if (exp.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_DireccionProv").Puntero).Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de direccion. No deben ser solo numeros.", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Valido que no quede en blanco el txt de localidad.
                if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_LocalidadProv").Puntero).Text))
                {
                    MessageBox.Show("Debe ingresar la direccion del proveedor!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    ((TextBox)ListaControles.Find(x => x.Nombre == "txt_LocalidadProv").Puntero).Focus();
                    return;
                }
                //Valido que la localidad no sean numeros.
                if (exp.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_LocalidadProv").Puntero).Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de localidad. Deben ser solo letras.", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Valido que no quede en blanco el txt de provincia.
                if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_ProvinciaProv").Puntero).Text))
                {
                    MessageBox.Show("Debe ingresar la provincia del proveedor!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    ((TextBox)ListaControles.Find(x => x.Nombre == "txt_ProvinciaProv").Puntero).Focus();
                    return;
                }
                //Valido las provincias.
                Regex exp3 = new Regex("(buenos aires|Buenos Aires|catamarca|Catamarca|chaco|Chaco|chubut|Chubut|cordoba|Cordoba|corrientes|Corrientes|entre rios|Entre rios|formosa|Formosa|jujuy|Jujuy|la pampa|La pampa|la rioja|La rioja|mendoza|Mendoza|misiones|Misiones|neuquen|Neuquen|rio negro|Rio negro|salta|Salta|san juan|San juan|san luis|San luis|santa cruz|Santa cruz|santiago del estero|Santiago del estero|santa fe|Santa Fe|tierra del fuego|Tierra del fuego|tucuman|Tucuman)");

                if (!exp3.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_ProvinciaProv").Puntero).Text))
                {
                    MessageBox.Show("Ingreso incorrecto de provincia!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Valido el formato de numero de telefono.
                Regex exp4 = new Regex("^[0-9]+$");

                if (!exp4.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_TelefonoProv").Puntero).Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de telefono. Deben ser numeros enteros y sin guiones de por medio", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Valido el formato de mail.
                Regex exp5 = new Regex("^([\\w-]+\\.)*?[\\w-]+@[\\w-]+\\.([\\w-]+\\.)*?[\\w]+$");

                if (!exp5.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_EmailProv").Puntero).Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de email.", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }

                #endregion

                if (Accion == "A")
                {
                    _nombre = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreProv").Puntero).Text;
                    _direccion = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_DireccionProv").Puntero).Text;
                    _localidad = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_LocalidadProv").Puntero).Text;
                    _provincia = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_ProvinciaProv").Puntero).Text;
                    _telefono = Int64.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_TelefonoProv").Puntero).Text);
                    _email = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_EmailProv").Puntero).Text;
                    _gerente = int.Parse(((ComboBox)ListaControles.Find(x => x.Nombre == "cb_Gerente").Puntero).SelectedValue.ToString());

                    Alta(oProveedor);
                }
                else
                {
                    _nombre = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreProv").Puntero).Text;
                    _direccion = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_DireccionProv").Puntero).Text;
                    _localidad = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_LocalidadProv").Puntero).Text;
                    _provincia = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_ProvinciaProv").Puntero).Text;
                    _telefono = Int64.Parse(((TextBox)ListaControles.Find(x => x.Nombre == "txt_TelefonoProv").Puntero).Text);
                    _email = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_EmailProv").Puntero).Text;
                    _gerente = int.Parse(((ComboBox)ListaControles.Find(x => x.Nombre == "cb_Gerente").Puntero).SelectedValue.ToString());

                    Modificar(oProveedor);
                }

                ActualizarGrilla();
                Limpiar();
                DesactivarComponentes();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_AltaProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                ActivarComponentes();
                Accion = "A";
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_ModProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Proveedores").Puntero;
                TextBox txtId = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IdProv").Puntero;
                TextBox txtNombre = (TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreProv").Puntero;
                TextBox txtDireccion = (TextBox)ListaControles.Find(x => x.Nombre == "txt_DireccionProv").Puntero;
                TextBox txtLocalidad = (TextBox)ListaControles.Find(x => x.Nombre == "txt_LocalidadProv").Puntero;
                TextBox txtProvincia = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ProvinciaProv").Puntero;
                TextBox txtTelefono = (TextBox)ListaControles.Find(x => x.Nombre == "txt_TelefonoProv").Puntero;
                TextBox txtEmail = (TextBox)ListaControles.Find(x => x.Nombre == "txt_EmailProv").Puntero;
                ComboBox cb_Gerente = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Gerente").Puntero;

                txtId.Enabled = false;
                ActivarComponentes();

                //Me aseguro de haya un proveedor seleccionado.
                if (dgv.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar un proveedor a modificar", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }

                //Obtengo el proveedor.
                oProveedor = (E_Proveedor)dgv.CurrentRow.DataBoundItem;

                //Paso valores de la grilla a los txt.
                txtId.Text = oProveedor.Id.ToString();
                txtNombre.Text = oProveedor.Nombre;
                txtDireccion.Text = oProveedor.Direccion;
                txtLocalidad.Text = oProveedor.Localidad;
                txtProvincia.Text = oProveedor.Provincia;
                txtTelefono.Text = oProveedor.Telefono.ToString();
                txtEmail.Text = oProveedor.Mail;
                cb_Gerente.Text = oProveedor.oGerente.Dni.ToString();

                //Establezco la variable Accion en modo MODIFICAR..
                Accion = "M";
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_BajaProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView _dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Proveedores").Puntero;
                TextBox txtId = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IdProv").Puntero;
                TextBox txtNombre = (TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreProv").Puntero;
                TextBox txtDireccion = (TextBox)ListaControles.Find(x => x.Nombre == "txt_DireccionProv").Puntero;
                TextBox txtLocalidad = (TextBox)ListaControles.Find(x => x.Nombre == "txt_LocalidadProv").Puntero;
                TextBox txtProvincia = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ProvinciaProv").Puntero;
                TextBox txtTelefono = (TextBox)ListaControles.Find(x => x.Nombre == "txt_TelefonoProv").Puntero;
                TextBox txtEmail = (TextBox)ListaControles.Find(x => x.Nombre == "txt_EmailProv").Puntero;
                ComboBox cb_Gerente = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Gerente").Puntero;

                //Establezco condicion.
                if (!string.IsNullOrEmpty(oProveedor.Id.ToString()))
                {
                    //Me aseguro que haya un proveedor seleccionado.
                    if (_dgv.CurrentRow == null)
                    {
                        MessageBox.Show("Debe seleccionar el proveedor a eliminar", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    //Pregunto si deseo eliminar el proveedor.
                    oProveedor = (E_Proveedor)_dgv.CurrentRow.DataBoundItem;
                    if (MessageBox.Show("¿Está seguro que desea dar de baja al proveedor: " + oProveedor.Nombre.ToString() + " ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1
                    ) == DialogResult.Yes)
                    {
                        txtId.Text = oProveedor.Id.ToString();
                        txtNombre.Text = oProveedor.Nombre;
                        txtDireccion.Text = oProveedor.Direccion;
                        txtLocalidad.Text = oProveedor.Localidad;
                        txtProvincia.Text = oProveedor.Provincia;
                        txtTelefono.Text = oProveedor.Telefono.ToString();
                        txtEmail.Text = oProveedor.Mail;
                        oProveedor.Activo = false;
                        cb_Gerente.Text = oProveedor.oGerente.Dni.ToString();
                        //Se elimina el proveedor.
                        Baja(oProveedor);
                        //Refresco grilla.
                        ActualizarGrilla();
                        Limpiar();
                        //OrdenarColumnas();
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void txt_Busqueda_KeyUp(object sender, KeyEventArgs e)
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Proveedores").Puntero;
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

        private void btn_CancelarProveedor_Click(object sender, EventArgs e)
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

        private void btn_ReporteProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                frmReporteProveedores.ShowDialog();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        #endregion

        private void VerificarPermisos()
        {
            Label lblUsuario = (Label)ListaControles.Find(x => x.Nombre == "lbl_UsuarioLog").Puntero;
            Button btnAlta = (Button)ListaControles.Find(x => x.Nombre == "btn_AltaProveedor").Puntero;
            Button btnBaja = (Button)ListaControles.Find(x => x.Nombre == "btn_BajaProveedor").Puntero;
            Button btnMod = (Button)ListaControles.Find(x => x.Nombre == "btn_ModProveedor").Puntero;
            Button btnAceptar = (Button)ListaControles.Find(x => x.Nombre == "btn_AceptarProveedor").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarProveedor").Puntero;
            Button btnReporte = (Button)ListaControles.Find(x => x.Nombre == "btn_ReporteProveedor").Puntero;
            TextBox txtBusqueda = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Busqueda").Puntero;
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Proveedores").Puntero;

            try
            {
                List<Permiso> Perfil = new List<Permiso>();
                List<Button> listaBotones = new List<Button>() { btnAlta, btnBaja, btnMod, btnAceptar, btnCancelar, btnReporte };
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
            }
            catch (Exception ex) { throw new Exception(ex.Message); } 
        }
            

        private void ActualizarGrilla()
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Proveedores").Puntero;
            try
            {
                dgv.DataSource = null;
                dgv.DataSource = oBLLProveedor.Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void DesactivarComponentes()
        {
            TextBox txtId = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IdProv").Puntero;
            TextBox txtNombre = (TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreProv").Puntero;
            TextBox txtDireccion = (TextBox)ListaControles.Find(x => x.Nombre == "txt_DireccionProv").Puntero;
            TextBox txtLocalidad = (TextBox)ListaControles.Find(x => x.Nombre == "txt_LocalidadProv").Puntero;
            TextBox txtProvincia = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ProvinciaProv").Puntero;
            TextBox txtTelefono = (TextBox)ListaControles.Find(x => x.Nombre == "txt_TelefonoProv").Puntero;
            TextBox txtEmail = (TextBox)ListaControles.Find(x => x.Nombre == "txt_EmailProv").Puntero;
            ComboBox cb_Gerente = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Gerente").Puntero;
            Button btnAceptar = (Button)ListaControles.Find(x => x.Nombre == "btn_AceptarProveedor").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarProveedor").Puntero;
            try
            {
                txtId.Enabled = false;
                txtNombre.Enabled = false;
                txtDireccion.Enabled = false;
                txtLocalidad.Enabled = false;
                txtProvincia.Enabled = false;
                txtTelefono.Enabled = false;
                txtEmail.Enabled = false;
                cb_Gerente.Enabled = false;
                btnAceptar.Enabled = false;
                btnCancelar.Enabled = false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void ActivarComponentes()
        {
            TextBox txtId = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IdProv").Puntero;
            TextBox txtNombre = (TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreProv").Puntero;
            TextBox txtDireccion = (TextBox)ListaControles.Find(x => x.Nombre == "txt_DireccionProv").Puntero;
            TextBox txtLocalidad = (TextBox)ListaControles.Find(x => x.Nombre == "txt_LocalidadProv").Puntero;
            TextBox txtProvincia = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ProvinciaProv").Puntero;
            TextBox txtTelefono = (TextBox)ListaControles.Find(x => x.Nombre == "txt_TelefonoProv").Puntero;
            TextBox txtEmail = (TextBox)ListaControles.Find(x => x.Nombre == "txt_EmailProv").Puntero;
            ComboBox cb_Gerente = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Gerente").Puntero;
            Button btnAceptar = (Button)ListaControles.Find(x => x.Nombre == "btn_AceptarProveedor").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarProveedor").Puntero;
            try
            {

                txtNombre.Enabled = true;
                txtDireccion.Enabled = true;
                txtLocalidad.Enabled = true;
                txtProvincia.Enabled = true;
                txtTelefono.Enabled = true;
                txtEmail.Enabled = true;
                cb_Gerente.Enabled = true;
                btnAceptar.Enabled = true;
                btnCancelar.Enabled = true;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void Limpiar()
        {
            TextBox txtId = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IdProv").Puntero;
            TextBox txtNombre = (TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreProv").Puntero;
            TextBox txtDireccion = (TextBox)ListaControles.Find(x => x.Nombre == "txt_DireccionProv").Puntero;
            TextBox txtLocalidad = (TextBox)ListaControles.Find(x => x.Nombre == "txt_LocalidadProv").Puntero;
            TextBox txtProvincia = (TextBox)ListaControles.Find(x => x.Nombre == "txt_ProvinciaProv").Puntero;
            TextBox txtTelefono = (TextBox)ListaControles.Find(x => x.Nombre == "txt_TelefonoProv").Puntero;
            TextBox txtEmail = (TextBox)ListaControles.Find(x => x.Nombre == "txt_EmailProv").Puntero;
            try
            {
                txtId.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtDireccion.Text = string.Empty;
                txtLocalidad.Text = string.Empty;
                txtProvincia.Text = string.Empty;
                txtTelefono.Text = string.Empty;
                txtEmail.Text = string.Empty;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void CargarComboGerente()
        {
            try
            {
                ComboBox cbGerente = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Gerente").Puntero;

                //Establezco una instancia de BLL Descripcion con el metodo listar.
                cbGerente.DataSource = oBLLGerente.Listar();
                //Establezco el valor real.
                cbGerente.ValueMember = "Dni";
                //Establezco el valor que muestro.
                cbGerente.DisplayMember = "Dni";
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }
        }

        public void Alta(E_Proveedor oProveedor)
        {
            try
            {
                oProveedor.Nombre = _nombre;
                oProveedor.Direccion = _direccion;
                oProveedor.Localidad = _localidad;
                oProveedor.Provincia = _provincia;
                oProveedor.Telefono = _telefono;
                oProveedor.Mail = _email;
                oProveedor.oGerente.Dni = _gerente;

                oBLLProveedor.Alta(oProveedor);
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }
        }

        public void Baja(E_Proveedor oProveedor)
        {
            try
            {
                oProveedor.Nombre = _nombre;
                oProveedor.Direccion = _direccion;
                oProveedor.Localidad = _localidad;
                oProveedor.Provincia = _provincia;
                oProveedor.Telefono = _telefono;
                oProveedor.Mail = _email;
                oProveedor.oGerente.Dni = _gerente;

                oBLLProveedor.Baja(oProveedor);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Proveedor> Listar()
        {
            throw new NotImplementedException();
        }

        public void Modificar(E_Proveedor oProveedor)
        {
            try
            {
                oProveedor.Nombre = _nombre;
                oProveedor.Direccion = _direccion;
                oProveedor.Localidad = _localidad;
                oProveedor.Provincia = _provincia;
                oProveedor.Telefono = _telefono;
                oProveedor.Mail = _email;
                oProveedor.oGerente.Dni = _gerente;

                oBLLProveedor.Modificar(oProveedor);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Proveedor> Consultar(string pNombre)
        {
            try
            {
                return oBLLProveedor.Consultar(pNombre);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
