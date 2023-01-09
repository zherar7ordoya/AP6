using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using BLL;
using ServiciosI;
using System.Windows.Forms;
using ServiciosDGV;
using PermisoComposite;
using System.Text.RegularExpressions;

namespace Controlador_Vista
{
    public class VistaMarca : Iabmc<E_Marca>
    {
        System.Windows.Forms.Form frmMarca;
        System.Windows.Forms.Form frmReporteMarcas;
        E_Marca oMarca;
        BLL_Marca oBLLMarca;
        BLL_Gerente oBLLGerente;
        EdicionDGV oEdicionDgv;
        List<Control> ListaControles;
        //Declaro variables.
        string _nombre; int _gerente;
        string Accion;
        E_Usuario oUsuario;
        BLL_Usuario oBLLUsuario;
        BLL_Permiso oBLLPermiso;
        BLL_LogIn oBLLLogin;

        public VistaMarca(Form pForm, Form pForm2)
        {
            try
            {
                ListaControles = new List<Control>();
                // Se guarda en una variable privada la referencia al formulario que llega al parámetro del constructor
                frmMarca = pForm;
                frmReporteMarcas = pForm2;
                //Recorro el form en busca de controles.
                foreach (System.Windows.Forms.Control c in frmMarca.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }

                ((Button)ListaControles.Find(x => x.Nombre == "btn_AltaMarca").Puntero).Click += btn_AltaMarca_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_ModMarca").Puntero).Click += btn_ModMarca_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_BajaMarca").Puntero).Click += btn_BajaMarca_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_GuardarMarca").Puntero).Click += btn_GuardarMarca_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_CancelarMarca").Puntero).Click += btn_CancelarMarca_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_ReporteMarca").Puntero).Click += btn_ReporteMarca_Click;
                ((TextBox)ListaControles.Find(x => x.Nombre == "txt_Busqueda").Puntero).KeyUp += txt_Busqueda_KeyUp;
                frmMarca.Load += frmMarca_Load;

                oMarca = new E_Marca();
                oBLLMarca = new BLL_Marca();
                oBLLGerente = new BLL_Gerente();
                oEdicionDgv = new EdicionDGV();
                oBLLUsuario = new BLL_Usuario();
                oBLLPermiso = new BLL_Permiso();
                oBLLLogin = new BLL_LogIn();
                oUsuario = new E_Usuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        #region "Funciones delegadas de eventos UI"
        private void frmMarca_Load(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Marcas").Puntero;
            try
            {
                oEdicionDgv.EditarDGV(dgv);
                DesactivarComponentes();
                CargarComboPersona();
                ActualizarGrilla();
                VerificarPermisos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_AltaMarca_Click(object sender, EventArgs e)
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

        private void btn_GuardarMarca_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validaciones
                //Valido que no quede en blanco el txt de nombre.
                if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreMarca").Puntero).Text))
                {
                    MessageBox.Show("Debe ingresar el nombre de la marca!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    ((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreMarca").Puntero).Focus();
                    return;
                }
                //Valido que el nombre no sean numeros.
                Regex exp = new Regex("^[0-9]+$");

                if (exp.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreMarca").Puntero).Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de nombre. Esta ingresando numeros." +
                        "", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                #endregion

                if (Accion == "A")
                {
                    _nombre = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreMarca").Puntero).Text;
                    _gerente = int.Parse(((ComboBox)ListaControles.Find(x => x.Nombre == "cb_Gerente").Puntero).SelectedValue.ToString());

                    Alta(oMarca);
                }
                else if (Accion == "M")
                {
                    _nombre = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreMarca").Puntero).Text;
                    _gerente = int.Parse(((ComboBox)ListaControles.Find(x => x.Nombre == "cb_Gerente").Puntero).SelectedValue.ToString());

                    Modificar(oMarca);
                }

                ActualizarGrilla();
                Limpiar();
                DesactivarComponentes();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_ModMarca_Click(object sender, EventArgs e)
        {
            try
            {
                //Activo componentes.
                ActivarComponentes();
                DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Marcas").Puntero;
                TextBox txtCodigo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_CodigoMarca").Puntero;
                TextBox txtNombre = (TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreMarca").Puntero;
                ComboBox cbGerente = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Gerente").Puntero;

                //Me aseguro de haya una marca seleccionada.
                if (dgv.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar una marca a modificar", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }

                //Obtengo la marca.
                oMarca = (E_Marca)dgv.CurrentRow.DataBoundItem;

                //Paso valores de la grilla a los txt.
                txtCodigo.Text = oMarca.Codigo.ToString();
                txtNombre.Text = oMarca.Nombre;
                cbGerente.Text = oMarca.oGerente.Dni.ToString();

                //Establezco la variable Accion en modo MODIFICAR..
                Accion = "M";
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }
        }

        private void btn_BajaMarca_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Marcas").Puntero;

                //Establezco condicion.
                if (!string.IsNullOrEmpty(oMarca.Codigo.ToString()))
                {
                    //Me aseguro que haya una marca seleccionada.
                    if (dgv.CurrentRow == null)
                    {
                        MessageBox.Show("Debe seleccionar la marca a eliminar", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    //Pregunto si deseo eliminar la marca.
                    oMarca = (E_Marca)dgv.CurrentRow.DataBoundItem;
                    if (MessageBox.Show("¿Está seguro que desea eliminar la marca: " + oMarca.Nombre + " ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1
                    ) == DialogResult.Yes)
                    {
                        //Se elimina la marca.
                        Baja(oMarca);
                        //Refresco grilla.
                        ActualizarGrilla();
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_CancelarMarca_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar();
                DesactivarComponentes();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_ReporteMarca_Click(object sender, EventArgs e)
        {
            try
            {
                frmReporteMarcas.ShowDialog();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Evento KeyUp del txt de busqueda.
        private void txt_Busqueda_KeyUp(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Marcas").Puntero;
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

        #endregion

        private void ActualizarGrilla()
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Marcas").Puntero;
            try
            {
                dgv.DataSource = null;
                dgv.DataSource = Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void VerificarPermisos()
        {
            Label lblUsuario = (Label)ListaControles.Find(x => x.Nombre == "lbl_UsuarioLog").Puntero;
            Label lblAviso = (Label)ListaControles.Find(x => x.Nombre == "lbl_Aviso").Puntero;
            Button btnAlta = (Button)ListaControles.Find(x => x.Nombre == "btn_AltaMarca").Puntero;
            Button btnBaja = (Button)ListaControles.Find(x => x.Nombre == "btn_BajaMarca").Puntero;
            Button btnMod = (Button)ListaControles.Find(x => x.Nombre == "btn_ModMarca").Puntero;
            Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_GuardarMarca").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarMarca").Puntero;
            Button btnReporte = (Button)ListaControles.Find(x => x.Nombre == "btn_ReporteMarca").Puntero;
            TextBox txtBusqueda = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Busqueda").Puntero;
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Marcas").Puntero;
            try
            {
                List<Permiso> Perfil = new List<Permiso>();
                List<Button> listaBotones = new List<Button>() { btnAlta, btnBaja, btnMod, btnGuardar, btnCancelar, btnReporte };
                List<DataGridView> listaDgv = new List<DataGridView>() { dgv };
                List<TextBox> listaTxt = new List<TextBox>() { txtBusqueda };
                bool tipoUsuario = true;
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
                //Muestro un aviso en caso de que el usuario no tenga permisos.
                if (tipoUsuario == false)
                {
                    lblAviso.Enabled = true;
                    lblAviso.Location = new System.Drawing.Point(90, 280);
                    lblAviso.Text = "No posee permisos para trabajar con esta opción del sistema.";
                }
                else
                {
                    lblAviso.Hide();
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void ActivarComponentes()
        {
            TextBox txtNombre = (TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreMarca").Puntero;
            ComboBox cbGerente = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Gerente").Puntero;
            Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_GuardarMarca").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarMarca").Puntero;
            try
            {
                txtNombre.Enabled = true;
                cbGerente.Enabled = true;
                btnGuardar.Enabled = true;
                btnCancelar.Enabled = true;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void DesactivarComponentes()
        {
            TextBox txtCodigo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_CodigoMarca").Puntero;
            TextBox txtNombre = (TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreMarca").Puntero;
            ComboBox cbGerente = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Gerente").Puntero;
            Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_GuardarMarca").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarMarca").Puntero;
            try
            {
                txtCodigo.Enabled = false;
                txtNombre.Enabled = false;
                cbGerente.Enabled = false;
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void Limpiar()
        {
            TextBox txtCodigo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_CodigoMarca").Puntero;
            TextBox txtNombre = (TextBox)ListaControles.Find(x => x.Nombre == "txt_NombreMarca").Puntero;
            try
            {
                txtCodigo.Text = string.Empty;
                txtNombre.Text = string.Empty;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void CargarComboPersona()
        {
            try
            {
                ComboBox cbGerente = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Gerente").Puntero;

                //Establezco una instancia de BLL con el metodo listar.
                cbGerente.DataSource = oBLLGerente.Listar();
                //Establezco el valor real.
                cbGerente.ValueMember = "Dni";
                //Establezco el valor que muestro.
                cbGerente.DisplayMember = "Dni";
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }
        }

        public void Alta(E_Marca oMarca)
        {
            try
            {
                oMarca.Nombre = _nombre;
                oMarca.oGerente.Dni = _gerente;

                oBLLMarca.Alta(oMarca);
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }
        }

        public void Baja(E_Marca oMarca)
        {
            try
            {
                oBLLMarca.Baja(oMarca);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Marca> Consultar(string pNombre)
        {
            return oBLLMarca.Consultar(pNombre);
        }

        public List<E_Marca> Listar()
        {
            try
            {
                return oBLLMarca.Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void Modificar(E_Marca oMarca)
        {
            try
            {
                oMarca.Nombre = _nombre;
                oMarca.oGerente.Dni = _gerente;

                oBLLMarca.Modificar(oMarca);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }      
        }
    }
}
