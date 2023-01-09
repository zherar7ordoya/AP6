using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Entidad;
using ServiciosDGV;
using PermisoComposite;

namespace Controlador_Vista
{
    public class VistaReporteArticuloFaltante
    {
        System.Windows.Forms.Form frmReporteArticuloFaltante;
        BLL_Articulo oBLLArticulo;
        List<Control> ListaControles;
        EdicionDGV oEdicionDgv;
        E_Articulo oArticulo;
        BLL_LogIn oBLLLogin;
        E_Usuario oUsuario;
        BLL_Usuario oBLLUsuario;
        BLL_Permiso oBLLPermiso;
        BLL_Empleado oBLLEmpleado;

        public VistaReporteArticuloFaltante(Form pForm)
        {
            try
            {
                ListaControles = new List<Control>();
                // Se guarda en una variable privada la referencia al formulario que llega al parámetro del constructor
                frmReporteArticuloFaltante = pForm;
                //Recorro el form en busca de controles.
                foreach (System.Windows.Forms.Control c in frmReporteArticuloFaltante.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }

                ((Button)ListaControles.Find(x => x.Nombre == "btn_GenerarReporte").Puntero).Click += btn_GenerarReporte_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_Cancelar").Puntero).Click += btn_Cancelar_Click;
                frmReporteArticuloFaltante.Load += frmReporteArticuloFaltante_Load;

                oBLLArticulo = new BLL_Articulo();
                oEdicionDgv = new EdicionDGV();
                oArticulo = new E_Articulo();
                oBLLLogin = new BLL_LogIn();
                oUsuario = new E_Usuario();
                oBLLUsuario = new BLL_Usuario();
                oBLLPermiso = new BLL_Permiso();
                oBLLEmpleado = new BLL_Empleado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region "Funciones delegadas de eventos UI"
        private void frmReporteArticuloFaltante_Load(object sender, EventArgs e)
        {
            DataGridView _dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_ArticulosFaltantes").Puntero;
            try
            {
                oEdicionDgv.EditarDGV(_dgv);
                ActualizarGrilla();
                DesabilitarComponentes();
                VerificarPermisos();
                CargarComboEmpleado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_GenerarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                ActivarComponentes();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar();
                DesabilitarComponentes();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        #endregion

        private void ActualizarGrilla()
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_ArticulosFaltantes").Puntero;

            try
            {
                dgv.DataSource = null;
                dgv.DataSource = oBLLArticulo.ListarExistenciasMenores();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void VerificarPermisos()
        {
            Label lblUsuario = (Label)ListaControles.Find(x => x.Nombre == "lbl_UsuarioLog").Puntero;
            Button btnGenerarReporte = (Button)ListaControles.Find(x => x.Nombre == "btn_GenerarReporte").Puntero;
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_ArticulosFaltantes").Puntero;
            try
            {
                List<Permiso> Perfil = new List<Permiso>();
                List<Button> listaBotones = new List<Button>() { btnGenerarReporte };
                List<DataGridView> listaDgv = new List<DataGridView>() { dgv };
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
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }

        private void Limpiar()
        {
            TextBox txtCantidad = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Cantidad").Puntero;

            try
            {
                txtCantidad.Text = string.Empty;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void DesabilitarComponentes()
        {
            Label lblTitulo = (Label)ListaControles.Find(x => x.Nombre == "lbl_Titulo").Puntero;
            Label lblCantidad = (Label)ListaControles.Find(x => x.Nombre == "lbl_Cantidad").Puntero;
            Label lblDni = (Label)ListaControles.Find(x => x.Nombre == "lbl_Dni").Puntero;
            TextBox txtCantidad = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Cantidad").Puntero;
            ComboBox cbPersona = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Empleado").Puntero;
            Button btnAceptar = (Button)ListaControles.Find(x => x.Nombre == "btn_Aceptar").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_Cancelar").Puntero;

            try
            {
                lblDni.Visible = false;
                lblTitulo.Visible = false;
                lblCantidad.Visible = false;
                txtCantidad.Visible = false;
                cbPersona.Visible = false;
                btnAceptar.Visible = false;
                btnCancelar.Visible = false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void ActivarComponentes()
        {
            Label lblTitulo = (Label)ListaControles.Find(x => x.Nombre == "lbl_Titulo").Puntero;
            Label lblCantidad = (Label)ListaControles.Find(x => x.Nombre == "lbl_Cantidad").Puntero;
            TextBox txtCantidad = (TextBox)ListaControles.Find(x => x.Nombre == "txt_Cantidad").Puntero;
            ComboBox cbPersona = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Empleado").Puntero;
            Label lblDni = (Label)ListaControles.Find(x => x.Nombre == "lbl_Dni").Puntero;
            Button btnAceptar = (Button)ListaControles.Find(x => x.Nombre == "btn_Aceptar").Puntero;
            Button btnCancelar = (Button)ListaControles.Find(x => x.Nombre == "btn_Cancelar").Puntero;

            try
            {
                lblDni.Visible = true;
                lblTitulo.Visible = true;
                lblCantidad.Visible = true;
                txtCantidad.Visible = true;
                cbPersona.Visible = true;
                btnAceptar.Visible = true;
                btnCancelar.Visible = true;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void CargarComboEmpleado()
        {
            ComboBox cbPersona = (ComboBox)ListaControles.Find(x => x.Nombre == "cb_Empleado").Puntero;

            try
            {
                //Establezco una instancia de BLL con el metodo listar.
                cbPersona.DataSource = oBLLEmpleado.Listar();
                //Establezco el valor real.
                cbPersona.ValueMember = "Dni";
                //Establezco el valor que muestro.
                cbPersona.DisplayMember = "Dni";
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }
        }
    }
}
