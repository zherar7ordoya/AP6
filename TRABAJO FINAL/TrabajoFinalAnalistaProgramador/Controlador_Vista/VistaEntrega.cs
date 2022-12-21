using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL;
using Entidad;
using ServiciosI;
using ServiciosDGV;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using PermisoComposite;

namespace Controlador_Vista
{
    public class VistaEntrega : Iabmc<E_Entrega>
    {
        System.Windows.Forms.Form frmEntrega;
        System.Windows.Forms.Form frmReporteEntregas;
        E_Entrega oEntrega;
        BLL_Entrega oBLLEntrega;
        EdicionDGV oEdicionDgv;
        BLL_Proveedor oBLLProveedor;
        BLL_Gerente oBLLGerente;
        List<Control> ListaControles;
        BLL_LogIn oBLLLogin;
        E_Usuario oUsuario;
        BLL_Usuario oBLLUsuario;
        BLL_Permiso oBLLPermiso;
        //Declaro variables.
        DateTime _fecha; string _hora; int _proveedor; int _gerente;
        string Accion;
       

        public VistaEntrega(Form pForm, Form pForm2)
        {
            try
            {
                ListaControles = new List<Control>();
                // Se guarda en una variable privada la referencia al formulario que llega al parámetro del constructor
                frmEntrega = pForm;
                frmReporteEntregas = pForm2;
                //Recorro el form en busca de controles.
                foreach (System.Windows.Forms.Control c in frmEntrega.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }

                ((Button)ListaControles.Find(x => x.Nombre == "btn_AltaEntrega").Puntero).Click += btn_AltaEntrega_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_ModEntrega").Puntero).Click += btn_ModEntrega_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_BajaEntrega").Puntero).Click += btn_BajaEntrega_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_GuardarEntrega").Puntero).Click += btn_GuardarEntrega_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_CancelarEntrega").Puntero).Click += btn_CancelarEntrega_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_ReporteEntrega").Puntero).Click += btn_ReporteEntrega_Click;
                ((TextBox)ListaControles.Find(x => x.Nombre == "txt_Busqueda").Puntero).KeyUp += txt_Busqueda_KeyUp;
                frmEntrega.Load += frmEntrega_Load;

                oEntrega = new E_Entrega();
                oBLLEntrega = new BLL_Entrega();
                oBLLGerente = new BLL_Gerente();
                oEdicionDgv = new EdicionDGV();
                oBLLProveedor = new BLL_Proveedor();
                oBLLLogin = new BLL_LogIn();
                oUsuario = new E_Usuario();
                oBLLUsuario = new BLL_Usuario();
                oBLLPermiso = new BLL_Permiso();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region "Funciones delegadas de eventos UI"
        private void frmEntrega_Load(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Entregas").Puntero;
            try
            {
                oEdicionDgv.EditarDGV(dgv);
                DesactivarComponentes();
                CargarComboGerente();
                CargarComboProveedor();
                ActualizarGrilla();
                VerificarPermisos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_AltaEntrega_Click(object sender, EventArgs e)
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

        private void btn_GuardarEntrega_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validaciones
                if(DateTime.Parse(((DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaEntrega").Puntero).Value.ToShortDateString()) <= DateTime.Now)
                {
                    MessageBox.Show("Ingreso incorrecto de fecha de entrega. Debe ser posterior a la fecha actual.", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(((TextBox)ListaControles.Find(x => x.Nombre == "txt_HoraEntrega").Puntero).Text))
                {
                    MessageBox.Show("Debe ingresar la hora de entrega!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    ((TextBox)ListaControles.Find(x => x.Nombre == "txt_HoraEntrega").Puntero).Focus();
                    return;
                }
                //Valido que no se escriban numeros en el nombre.
                Regex exp = new Regex("^([01]?[0-9]|2[0-3]):[0-5][0-9]$");
                if (!exp.IsMatch(((TextBox)ListaControles.Find(x => x.Nombre == "txt_HoraEntrega").Puntero).Text))
                {
                    MessageBox.Show("Ingreso incorrecto de formato de hora. Ejemplo: 10:10.", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                #endregion

                if (Accion == "A")
                {
                    _fecha = DateTime.Parse(((DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaEntrega").Puntero).Value.ToShortDateString());
                    _hora = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_HoraEntrega").Puntero).Text;
                    _proveedor = int.Parse(((ComboBox)ListaControles.Find(x => x.Nombre == "cb_Proveedor").Puntero).SelectedValue.ToString());
                    _gerente = int.Parse(((ComboBox)ListaControles.Find(x => x.Nombre == "cb_Gerente").Puntero).SelectedValue.ToString());

                    Alta(oEntrega);
                }
                else if (Accion == "M")
                {
                    _fecha = DateTime.Parse(((DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaEntrega").Puntero).Text);
                    _hora = ((TextBox)ListaControles.Find(x => x.Nombre == "txt_HoraEntrega").Puntero).Text;
                    _proveedor = int.Parse(((ComboBox)ListaControles.Find(x => x.Nombre == "cb_Proveedor").Puntero).SelectedValue.ToString());
                    _gerente = int.Parse(((ComboBox)ListaControles.Find(x => x.Nombre == "cb_Gerente").Puntero).SelectedValue.ToString());

                    Modificar(oEntrega);
                }

                ActualizarGrilla();
                Limpiar();
                DesactivarComponentes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_ModEntrega_Click(object sender, EventArgs e)
        {
            try
            {
                //Activo componentes.
                ActivarComponentes();
                DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Entregas").Puntero;
                TextBox txtCodigo = (TextBox)ListaControles.Find(x => x.Nombre == "txt_HoraEntrega").Puntero;
                DateTimePicker dtFecha = (DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaEntrega").Puntero;
                TextBox dtHora = (TextBox)ListaControles.Find(x => x.Nombre == "txt_HoraEntrega").Puntero;
                ComboBox cbGerente = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Gerente").Puntero;
                ComboBox cbProveedor = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Proveedor").Puntero;

                //Me aseguro de haya una entrega seleccionada.
                if (dgv.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar una entrega a modificar", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }

                //Obtengo la marca.
                oEntrega = (E_Entrega)dgv.CurrentRow.DataBoundItem;

                //Paso valores de la grilla a los txt.
                txtCodigo.Text = oEntrega.Id.ToString();
                dtFecha.Value = oEntrega.Fecha;
                dtHora.Text = oEntrega.Hora.ToString();
                cbProveedor.DisplayMember = oEntrega.oProveedor.Id.ToString();
                cbGerente.Text = oEntrega.oGerente.Dni.ToString();

                //Establezco la variable Accion en modo MODIFICAR..
                Accion = "M";
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }
        }

        private void btn_BajaEntrega_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Entregas").Puntero;

                //Establezco condicion.
                if (!string.IsNullOrEmpty(oEntrega.Id.ToString()))
                {
                    //Me aseguro que haya una marca seleccionada.
                    if (dgv.CurrentRow == null)
                    {
                        MessageBox.Show("Debe seleccionar la entrega a eliminar", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    //Pregunto si deseo eliminar la marca.
                    oEntrega = (E_Entrega)dgv.CurrentRow.DataBoundItem;

                    if (MessageBox.Show("¿Está seguro que desea eliminar la entrega del dia: " + oEntrega.Fecha + " ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1
                    ) == DialogResult.Yes)
                    {
                        //Se elimina la marca.
                        Baja(oEntrega);
                        //Refresco grilla.
                        ActualizarGrilla();
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_CancelarEntrega_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar();
                DesactivarComponentes();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_ReporteEntrega_Click(object sender, EventArgs e)
        {
            try
            {
                frmReporteEntregas.ShowDialog();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Evento KeyUp del txt de busqueda.
        private void txt_Busqueda_KeyUp(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Entregas").Puntero;
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
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Entregas").Puntero;

            try
            {
                dgv.DataSource = null;
                dgv.DataSource = oBLLEntrega.Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void VerificarPermisos()
        {
            try
            {
                Label lblUsuario = (Label)ListaControles.Find(x => x.Nombre == "lbl_UsuarioLog").Puntero;
                Label lblAviso = (Label)ListaControles.Find(x => x.Nombre == "lbl_Aviso").Puntero;
                Button btnAlta = (Button)ListaControles.Find(x => x.Nombre == "btn_AltaEntrega").Puntero;
                Button btnBaja = (Button)ListaControles.Find(x => x.Nombre == "btn_BajaEntrega").Puntero;
                Button btnMod = (Button)ListaControles.Find(x => x.Nombre == "btn_ModEntrega").Puntero;
                Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_GuardarEntrega").Puntero;
                Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarEntrega").Puntero;
                Button btnReporte = (Button)ListaControles.Find(x => x.Nombre == "btn_ReporteEntrega").Puntero;
                TextBox txtBusqueda = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Busqueda").Puntero;
                DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_Entregas").Puntero;
                //El tipo true significa que tiene los permisos, en cambio el tipo false no.
                bool tipoUsuario = true;
                List<Permiso> Perfil = new List<Permiso>();
                List<Button> listaBotones = new List<Button>() { btnAlta, btnBaja, btnMod, btnGuardar, btnCancelar, btnReporte };
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

                if (tipoUsuario == false)
                {
                    lblAviso.Enabled = true;
                    lblAviso.Location = new System.Drawing.Point(70, 350);
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


        private void ActivarComponentes()
        {
            DateTimePicker dtFecha = (DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaEntrega").Puntero;
            TextBox dtHora = (TextBox)ListaControles.Find(x => x.Nombre == "txt_HoraEntrega").Puntero;
            ComboBox cbProveedor = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Proveedor").Puntero;
            ComboBox cbGerente = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Gerente").Puntero;
            Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_GuardarEntrega").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarEntrega").Puntero;
            try
            {
                dtFecha.Enabled = true;
                dtHora.Enabled = true;
                cbProveedor.Enabled = true;
                cbGerente.Enabled = true;
                btnGuardar.Enabled = true;
                btnCancelar.Enabled = true;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void DesactivarComponentes()
        {
            TextBox txtId = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IdEntrega").Puntero;
            DateTimePicker dtFecha = (DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaEntrega").Puntero;
            TextBox dtHora = (TextBox)ListaControles.Find(x => x.Nombre == "txt_HoraEntrega").Puntero;
            ComboBox cbProveedor = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Proveedor").Puntero;
            ComboBox cbGerente = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Gerente").Puntero;
            Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_GuardarEntrega").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarEntrega").Puntero;
            try
            {
                txtId.Enabled = false;
                dtFecha.Enabled = false;
                dtHora.Enabled = false;
                cbProveedor.Enabled = false;
                cbGerente.Enabled = false;
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void Limpiar()
        {
            TextBox txtId = (TextBox)ListaControles.Find(x => x.Nombre == "txt_IdEntrega").Puntero;
            DateTimePicker dtFecha = (DateTimePicker)ListaControles.Find(x => x.Nombre == "dt_FechaEntrega").Puntero;
            TextBox dtHora = (TextBox)ListaControles.Find(x => x.Nombre == "txt_HoraEntrega").Puntero;
            ComboBox cbProveedor = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Proveedor").Puntero;
            ComboBox cbGerente = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Gerente").Puntero;
            Button btnGuardar = (Button)ListaControles.Find(x => x.Nombre == "btn_GuardarEntrega").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_CancelarEntrega").Puntero;

            try
            {
                txtId.Text = string.Empty;
                dtFecha.Value = DateTime.Now;
                dtHora.Text = string.Empty;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void CargarComboGerente()
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
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void CargarComboProveedor()
        {
            try
            {
                ComboBox cbProveedor = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Proveedor").Puntero;

                //Establezco una instancia de BLL con el metodo listar.
                cbProveedor.DataSource = oBLLProveedor.Listar();
                //Establezco el valor real.
                cbProveedor.ValueMember = "Id";
                //Establezco el valor que muestro.
                cbProveedor.DisplayMember = "Nombre";
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }


        public void Alta(E_Entrega oEntrega)
        {
            try
            {
                oEntrega.Fecha = _fecha;
                oEntrega.Hora = _hora;
                oEntrega.oProveedor.Id = _proveedor;
                oEntrega.oGerente.Dni = _gerente;

                oBLLEntrega.Alta(oEntrega);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void Baja(E_Entrega oEntrega)
        {
            try
            {
                oBLLEntrega.Baja(oEntrega);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Entrega> Consultar(string pFecha)
        {
            try
            {
                return oBLLEntrega.Consultar(pFecha);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Entrega> Listar()
        {
            try
            {
                return oBLLEntrega.Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void Modificar(E_Entrega oEntrega)
        {
            try
            {
                oEntrega.Fecha = _fecha;
                oEntrega.Hora = _hora;
                oEntrega.oProveedor.Id = _proveedor;
                oEntrega.oGerente.Dni = _gerente;

                oBLLEntrega.Modificar(oEntrega);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }


    }
}
