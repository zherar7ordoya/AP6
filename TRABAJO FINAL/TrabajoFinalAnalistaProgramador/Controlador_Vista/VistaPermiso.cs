using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using BLL;
using System.Windows.Forms;
using PermisoComposite;
using ServiciosI;
using System.Text.RegularExpressions;
using ServiciosDGV;

namespace Controlador_Vista
{
    public class VistaPermiso 
    {
        System.Windows.Forms.Form frmPermiso;
        PermisoSimple oPermisoSimple;
        PermisoCompuesto oPermisoCompuesto;
        E_Permiso oEPermiso;
        BLL_Permiso oBLLPermiso;
        List<Control> ListaControles;
        EdicionDGV oEdicionDgv;
        //Declaro variables.
        string _idPermiso; string _nombrePermiso; string _tipo;
        BLL_LogIn oBLLLogin;
        E_Usuario oUsuario;
        BLL_Usuario oBLLUsuario;
        //Declaro variables.
        string Accion;

        public VistaPermiso(Form pForm)
        {
            try
            {
                ListaControles = new List<Control>();
                // Se guarda en una variable privada la referencia al formulario que llega al parámetro del constructor
                frmPermiso = pForm;
                //Recorro el form en busca de controles.
                foreach (System.Windows.Forms.Control c in frmPermiso.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }

                ((Button)ListaControles.Find(x => x.Nombre == "btn_AltaPermiso").Puntero).Click += btn_AltaPermiso_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_ModPermisoSimple").Puntero).Click += btn_ModPermisoSimple_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_ModPermisoCompuesto").Puntero).Click += btn_ModPermisoCompuesto_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_CancelarPermiso").Puntero).Click += btn_CancelarPermiso_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_BajaPermisoSimple").Puntero).Click += btn_BajaPermisoSimple_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_BajaPermisoCompuesto").Puntero).Click += btn_BajaPermisoCompuesto_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_GuardarPermiso").Puntero).Click += btn_GuardarPermiso_Click;
                ((TextBox)ListaControles.Find(x => x.Nombre == "txt_Busqueda").Puntero).KeyUp += txt_Busqueda_KeyUp;
                frmPermiso.Load += frmPermiso_Load;

                oPermisoSimple = new PermisoSimple(new E_Permiso(_idPermiso, _nombrePermiso, _tipo));
                oPermisoCompuesto = new PermisoCompuesto(new E_Permiso(_idPermiso, _nombrePermiso, _tipo));
                oBLLPermiso = new BLL_Permiso();
                oEPermiso = new E_Permiso();
                oBLLLogin = new BLL_LogIn();
                oUsuario = new E_Usuario();
                oBLLUsuario = new BLL_Usuario();
                oEdicionDgv = new EdicionDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region "Funciones delegadas de eventos UI"
        private void frmPermiso_Load(object sender, EventArgs e)
        {
            DataGridView dgvSimple = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Permisos").Puntero;
            try
            {
                oEdicionDgv.EditarDGV(dgvSimple);
                DesactivarComponentes();
                ActualizarGrilla();
                VerificarPermisos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Boton Alta.
        private void btn_AltaPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                ActivarComponentes();
                Accion = "A";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Boton Guardar.
        private void btn_GuardarPermiso_Click(object sender, EventArgs e)
        {
            RadioButton rbSimple = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Simple").Puntero;
            RadioButton rbCompuesto = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Compuesto").Puntero;

            try
            {
                if (Accion == "A")
                {
                    #region Validaciones
                    if (rbSimple.Checked == false && rbCompuesto.Checked == false)
                    {
                        MessageBox.Show("Debe ingresar el tipo de permiso!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    #endregion

                    //Si es un permiso simple.
                    if (rbSimple.Checked == true)
                    {
                        #region Validaciones
                        //Valido que el id de permiso simple sea un numero entero.
                        Regex exp = new Regex("^[0-9]+$");

                        if (!exp.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_IdPermiso").Puntero).Text))
                        {
                            MessageBox.Show("Ingreso incorrecto de formato de Id. Debe ser un numero entero y mayor a 0", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            return;
                        }

                        //Valido que el Id sea mayor a 0.
                        if (Convert.ToInt32(((TextBox)ListaControles.Find(x => x.Nombre == "txt_IdPermiso").Puntero).Text) <= 0)
                        {
                            MessageBox.Show("Debe ingresar un Id mayor a 0!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            ((TextBox)ListaControles.Find(x => x.Nombre == "txt_IdPermiso").Puntero).Focus();
                            return;
                        }
                        //Valido que no quede en blanco el txt de nombre de permiso.
                        if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombrePermiso").Puntero).Text))
                        {
                            MessageBox.Show("Debe ingresar el nombre!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            ((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombrePermiso").Puntero).Focus();
                            return;
                        }
                        //Valido que no quede en blanco el txt de nombre de permiso.
                        if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombrePermiso").Puntero).Text))
                        {
                            MessageBox.Show("Debe ingresar el nombre!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            ((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombrePermiso").Puntero).Focus();
                            return;
                        }
                        #endregion

                        _idPermiso = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_IdPermiso").Puntero).Text;
                        _nombrePermiso = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombrePermiso").Puntero).Text;
                        _tipo = "Simple";
                        //Creo el objeto con su constructor.
                        PermisoSimple oPermisoSimple = new PermisoSimple(new E_Permiso(_idPermiso, _nombrePermiso, _tipo));
                        //Valido que no se repita el ID.
                        if (oBLLPermiso.ValidarId(oPermisoSimple) == true)
                        {
                            //Valido que ya no lo haya creado.
                            if (oBLLPermiso.ValidarPermisosCreacion(oPermisoSimple) == true)
                            {
                                oBLLPermiso.Alta(oPermisoSimple);
                            }
                            else
                            {
                                MessageBox.Show("Ya existe un permiso con el mismo nombre y tipo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ya existe un permiso con el mismo Id", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        ActualizarGrilla();
                    }
                    //Si es un permiso compuesto.
                    else if (rbCompuesto.Checked == true)
                    {
                        #region Validaciones
                        //Valido que el id de permiso compuesto sea PC y un numero cualquiera.
                        Regex exp = new Regex("^[PC]{2}[0-9]+$");

                        if (!exp.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_IdPermiso").Puntero).Text))
                        {
                            MessageBox.Show("Ingreso incorrecto de formato de Id. Debe ser PC00. Ejemplo: PC1, PC15, PC100", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            return;
                        }
                        //Valido que no quede en blanco el txt de nombre de permiso.
                        if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombrePermiso").Puntero).Text))
                        {
                            MessageBox.Show("Debe ingresar el nombre!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            ((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombrePermiso").Puntero).Focus();
                            return;
                        }
                        #endregion

                        _idPermiso = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_IdPermiso").Puntero).Text;
                        _nombrePermiso = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombrePermiso").Puntero).Text;
                        _tipo = "Compuesto";
                        //Creo el objeto con el constructor.
                        PermisoCompuesto oPermisoCompuesto = new PermisoCompuesto(new E_Permiso(_idPermiso, _nombrePermiso, _tipo));
                        //Valido que no se repita el ID.
                        if (oBLLPermiso.ValidarId(oPermisoCompuesto) == true)
                        {
                            //Valido que no haya creado el permiso.
                            if (oBLLPermiso.ValidarPermisosCreacion(oPermisoCompuesto) == true)
                            {
                                oBLLPermiso.Alta(oPermisoCompuesto);
                            }
                            else
                            {
                                MessageBox.Show("Ya existe un permiso con el mismo nombre y tipo", "Advertencia");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ya existe un permiso con el mismo Id", "Advertencia");
                        }

                        ActualizarGrilla();
                    }
                }
                else if (Accion == "M")
                {
                    if (rbSimple.Checked == true)
                    {
                        #region Validaciones
                        //Valido que el id de permiso simple sea un numero entero.
                        Regex exp = new Regex("^[1-9]+$");

                        if (!exp.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_IdPermiso").Puntero).Text))
                        {
                            MessageBox.Show("Ingreso incorrecto de formato de Id. Debe ser un numero entero y mayor a 0", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            return;
                        }
                        //Valido que no quede en blanco el txt de nombre de permiso.
                        if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombrePermiso").Puntero).Text))
                        {
                            MessageBox.Show("Debe ingresar el nombre!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            ((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombrePermiso").Puntero).Focus();
                            return;
                        }
                        #endregion

                        _idPermiso = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_IdPermiso").Puntero).Text;
                        _nombrePermiso = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombrePermiso").Puntero).Text;
                        _tipo = "Simple";

                        PermisoSimple oPermisoSimple = new PermisoSimple(new E_Permiso(_idPermiso, _nombrePermiso, _tipo));

                        if (oBLLPermiso.ValidarPermisosCreacion(oPermisoSimple) == true)
                        {
                            oBLLPermiso.Modificar(oPermisoSimple);
                        }
                        else
                        {
                            MessageBox.Show("Ya existe un permiso con el mismo nombre y tipo", "Advertencia");
                        }

                        ActualizarGrilla();
                    }
                    else if (rbCompuesto.Checked == true)
                    {
                        #region Validaciones
                        //Valido que el id de permiso compuesto sea PC y un numero cualquiera.
                        Regex exp = new Regex("^[PC]{2}[0-9]+$");

                        if (!exp.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_IdPermiso").Puntero).Text))
                        {
                            MessageBox.Show("Ingreso incorrecto de formato de Id. Debe ser PC00. Ejemplo: PC1, PC15, PC100", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            return;
                        }
                        //Valido que no quede en blanco el txt de nombre de permiso.
                        if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombrePermiso").Puntero).Text))
                        {
                            MessageBox.Show("Debe ingresar el nombre!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            ((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombrePermiso").Puntero).Focus();
                            return;
                        }
                        #endregion

                        _idPermiso = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_IdPermiso").Puntero).Text;
                        _nombrePermiso = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombrePermiso").Puntero).Text;
                        _tipo = "Compuesto";

                        PermisoCompuesto oPermisoCompuesto = new PermisoCompuesto(new E_Permiso(_idPermiso, _nombrePermiso, _tipo));

                        if (oBLLPermiso.ValidarPermisosCreacion(oPermisoCompuesto) == true)
                        {
                            oBLLPermiso.Modificar(oPermisoCompuesto);
                        }
                        else
                        {
                            MessageBox.Show("Ya existe un permiso con el mismo nombre y tipo", "Advertencia");
                        }

                        ActualizarGrilla();
                    }
                }

                LimpiarComponentes();
                DesactivarComponentes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Boton Modificar permiso simple.
        private void btn_ModPermisoSimple_Click(object sender, EventArgs e)
        {
            try
            {
                ActivarComponentes();
                DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Permisos").Puntero;
                TextBox txtIdPermiso = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IdPermiso").Puntero;
                TextBox txtNombrePermiso = (TextBox)ListaControles.Find(x => x.Nombre == "txt_NombrePermiso").Puntero;
                RadioButton rbSimple = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Simple").Puntero;
                RadioButton rbCompuesto = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Compuesto").Puntero;

                txtIdPermiso.Enabled = false;
                rbCompuesto.Enabled = false;

                //Valido que no este seleccionando un permiso compuesto.
                foreach (DataGridViewRow item in dgv.SelectedRows)
                {
                    if (item.Cells[2].Value.ToString() == "Compuesto")
                    {
                        MessageBox.Show("Error!!! Esta seleccionado un permiso compuesto", "Advertencia");
                        return;
                    }
                }
                //Me aseguro que se seleccione un permiso.
                if (dgv.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar un permiso a modificar", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }

                //Obtengo el permiso.
                oPermisoSimple = (PermisoSimple)dgv.CurrentRow.DataBoundItem;

                //Paso valores de la grilla a los txt.
                txtIdPermiso.Text = oPermisoSimple.Id;
                txtNombrePermiso.Text = oPermisoSimple.Nombre;
                rbSimple.Checked = true;
                rbSimple.Text = oPermisoSimple.Tipo;

                Accion = "M";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }
        //Boton Modificar permiso compuesto.
        private void btn_ModPermisoCompuesto_Click(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Permisos").Puntero;
            TextBox txtIdPermiso = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IdPermiso").Puntero;
            TextBox txtNombrePermiso = (TextBox)ListaControles.Find(x => x.Nombre == "txt_NombrePermiso").Puntero;
            RadioButton rbSimple = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Simple").Puntero;
            RadioButton rbCompuesto = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Compuesto").Puntero;

            try
            {
                ActivarComponentes();
                txtIdPermiso.Enabled = false;
                rbSimple.Enabled = false;

                //Valido que no este seleccionando un permiso simple.
                foreach (DataGridViewRow item in dgv.SelectedRows)
                {
                    if (item.Cells[2].Value.ToString() == "Simple")
                    {
                        MessageBox.Show("Error!!! Esta seleccionado un permiso simple", "Advertencia");
                        return;
                    }

                }

                if (dgv.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar un permiso a modificar", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //Obtengo el permiso compuesto.
                oPermisoCompuesto = (PermisoCompuesto)dgv.CurrentRow.DataBoundItem;

                //Paso valores de la grilla a los txt.
                txtIdPermiso.Text = oPermisoCompuesto.Id;
                txtNombrePermiso.Text = oPermisoCompuesto.Nombre;
                rbCompuesto.Checked = true;
                rbCompuesto.Text = oPermisoCompuesto.Tipo;

                Accion = "M";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Boton Baja permiso compuesto.
        private void btn_BajaPermisoCompuesto_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Permisos").Puntero;

                //Valido que no este seleccionando un permiso simple.
                foreach (DataGridViewRow item in dgv.SelectedRows)
                {
                    if (item.Cells[2].Value.ToString() == "Simple")
                    {
                        MessageBox.Show("Error!!! Esta seleccionado un permiso simple", "Advertencia");
                        return;
                    }

                }

                ////Establezco condicion.
                if (oPermisoCompuesto.Id != " ")
                {
                    //Me aseguro que haya un permiso seleccionado.
                    if (dgv.CurrentRow == null)
                    {
                        MessageBox.Show("Debe seleccionar el permiso a eliminar", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }

                    //Pregunto si deseo eliminar el permiso.
                    oPermisoCompuesto = (PermisoCompuesto)dgv.CurrentRow.DataBoundItem;
                    if (MessageBox.Show("¿Está seguro que desea eliminar el permiso " + oPermisoCompuesto.Nombre.ToString() + " ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1
                    ) == DialogResult.Yes)
                    {
                        //Se elimina el permiso.
                        oBLLPermiso.Baja(oPermisoCompuesto);
                        //Refresco grilla.
                        ActualizarGrilla();
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Boton baja permiso simple.
        private void btn_BajaPermisoSimple_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Permisos").Puntero;

                //Valido que no este seleccionando un permiso compuesto.
                foreach (DataGridViewRow item in dgv.SelectedRows)
                {
                    if(item.Cells[2].Value.ToString() == "Compuesto")
                    {
                        MessageBox.Show("Error!!! Esta seleccionado un permiso compuesto", "Advertencia");
                        return;
                    }
                   
                }

                //Establezco condicion.
                if (oPermisoSimple.Id != " ")
                {
                    //Me aseguro que haya un permiso seleccionado.
                    if (dgv.CurrentRow == null)
                    {
                        MessageBox.Show("Debe seleccionar el permiso a eliminar", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }

                    //Pregunto si deseo eliminar el permiso.
                    oPermisoSimple = (PermisoSimple)dgv.CurrentRow.DataBoundItem;
                    if (MessageBox.Show("¿Está seguro que desea eliminar el permiso " + oPermisoSimple.Nombre.ToString() + " ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1
                    ) == DialogResult.Yes)
                    {
                        //Se elimina el permiso.
                        oBLLPermiso.Baja(oPermisoSimple);
                        //Refresco grilla.
                        ActualizarGrilla();
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Boton Cancelar.
        private void btn_CancelarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarComponentes();
                DesactivarComponentes();
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
        //Evento KeyUp del txt de busqueda.
        private void txt_Busqueda_KeyUp(object sender, KeyEventArgs e)
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Permisos").Puntero;
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
                    dgv.DataSource = oBLLPermiso.Consultar(pNombre);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        #endregion

        private void ActualizarGrilla()
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Permisos").Puntero;
            try
            {
                dgv.DataSource = null;
                dgv.DataSource = oBLLPermiso.Listar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //Verifico los permisos del usuario logeado.
        private void VerificarPermisos()
        {
            try
            {
                Label lblUsuario = (Label)ListaControles.Find(x => x.Nombre == "lbl_UsuarioLog").Puntero;
                Label lblAviso = (Label)ListaControles.Find(x => x.Nombre == "lbl_Aviso").Puntero;
                Button btnAlta = (Button)ListaControles.Find(x => x.Nombre == "btn_AltaPermiso").Puntero;
                Button btnBaja1 = (Button)ListaControles.Find(x => x.Nombre == "btn_BajaPermisoSimple").Puntero;
                Button btnBaja2 = (Button)ListaControles.Find(x => x.Nombre == "btn_BajaPermisoCompuesto").Puntero;
                Button btnMod1 = (Button)ListaControles.Find(x => x.Nombre == "btn_ModPermisoCompuesto").Puntero;
                Button btnMod2 = (Button)ListaControles.Find(x => x.Nombre == "btn_ModPermisoSimple").Puntero;
                Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_GuardarPermiso").Puntero;               
                Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarPermiso").Puntero;
                TextBox txtBusqueda = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Busqueda").Puntero;
                DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Permisos").Puntero;
                //El tipo true significa que tiene los permisos, en cambio el tipo false no.
                bool tipoUsuario = true;
                List<Permiso> Perfil = new List<Permiso>();
                List<Button> listaBotones = new List<Button>() { btnAlta, btnBaja1, btnBaja2, btnMod1, btnMod2, btnGuardar, btnCancelar };
                List<DataGridView> listaDgv = new List<DataGridView>() { dgv };
                List<TextBox> listaTxt = new List<TextBox>() { txtBusqueda };
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
                //Si no tiene permisos, doy un aviso.
                if (tipoUsuario == false)
                {
                    lblAviso.Enabled = true;
                    lblAviso.Location = new System.Drawing.Point(100, 250);
                    lblAviso.Text = "No posee permisos para trabajar con esta opción del sistema";
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

        private void ActivarComponentes()
        {
            TextBox txtIdPSimple = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IdPermiso").Puntero;
            TextBox txtNombrePSimple = (TextBox)ListaControles.Find(x => x.Nombre == "txt_NombrePermiso").Puntero;
            RadioButton rbSimple = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Simple").Puntero;
            RadioButton rbCompuesto = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Compuesto").Puntero;
            try
            {
                txtIdPSimple.Enabled = true;
                txtNombrePSimple.Enabled = true;
                rbSimple.Enabled = true;
                rbCompuesto.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        

        private void DesactivarComponentes()
        {
            TextBox txtIdPSimple = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IdPermiso").Puntero;
            TextBox txtNombrePSimple = (TextBox)ListaControles.Find(x => x.Nombre == "txt_NombrePermiso").Puntero;
            RadioButton rbSimple = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Simple").Puntero;
            RadioButton rbCompuesto = (RadioButton)ListaControles.Find(x => x.Nombre == "rb_Compuesto").Puntero;
            try
            {
                txtIdPSimple.Enabled = false;
                txtNombrePSimple.Enabled = false;
                rbSimple.Enabled = false;
                rbCompuesto.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LimpiarComponentes()
        {
            TextBox txtIdPSimple = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IdPermiso").Puntero;
            TextBox txtNombrePSimple = (TextBox)ListaControles.Find(x => x.Nombre == "txt_NombrePermiso").Puntero;
            try
            {
                txtIdPSimple.Text = string.Empty;
                txtNombrePSimple.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
