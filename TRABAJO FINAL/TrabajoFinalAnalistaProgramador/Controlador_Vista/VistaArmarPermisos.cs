using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PermisoComposite;
using Entidad;
using System.Windows.Forms;
using ServiciosDGV;
using BLL;

namespace Controlador_Vista
{
    public class VistaArmarPermisos
    {
        System.Windows.Forms.Form frmGestionPermisos;

        BLL_Permiso oBLLPermiso;
        EdicionDGV oEdicionDGV;
        List<Control> ListaControles;
        BLL_LogIn oBLLLogin;
        E_Usuario oUsuario;
        BLL_Usuario oBLLUsuario;

        public VistaArmarPermisos(Form pForm)
        {
            try
            {
                ListaControles = new List<Control>();
                // Se guarda en una variable privada la referencia al formulario que llega al parámetro del constructor.
                frmGestionPermisos = pForm;
                //Recorro frm en busca de controles.
                foreach (System.Windows.Forms.Control c in frmGestionPermisos.Controls)
                {
                    ListaControles.Add(new Control(c.Name, c));
                }

                ((Button)ListaControles.Find(x => x.Nombre == "btn_AsignarPermisoSimple").Puntero).Click += btn_AsignarPermisoSimple_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_QuitarPermiso").Puntero).Click += btn_QuitarPermiso_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_AsignarPermiso2").Puntero).Click += btn_AsignarPermiso2_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_QuitarPermisoCompuesto").Puntero).Click += btn_QuitarPermisoCompuesto_Click;
                ((Button)ListaControles.Find(x => x.Nombre == "btn_Ayuda").Puntero).Click += btn_Ayuda_Click;
                ((DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosCompuestos").Puntero).CellClick += dgv_PermisosCompuestos_CellClick;
                
                frmGestionPermisos.Load += frmGestionPermisos_Load;

                oBLLLogin = new BLL_LogIn();
                oEdicionDGV = new EdicionDGV();
                oBLLPermiso = new BLL_Permiso();
                oUsuario = new E_Usuario();
                oBLLUsuario = new BLL_Usuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region "Funciones delegadas de eventos UI"
        private void frmGestionPermisos_Load(object sender, EventArgs e)
        {
            DataGridView dgvCompuesto = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosCompuestos").Puntero;
            DataGridView dgvCompuesto2 = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosCompuestos2").Puntero;
            DataGridView dgvSimple = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosSimples").Puntero;
            DataGridView dgvPermisosP = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosPermiso").Puntero;
            try
            {
                oEdicionDGV.EditarDGV(dgvCompuesto);
                oEdicionDGV.EditarDGV(dgvCompuesto2);
                oEdicionDGV.EditarDGV(dgvSimple);
                oEdicionDGV.EditarDGV(dgvPermisosP);
                ActualizarGrilla();
                ActualizarGrilla2();
                ActualizarGrilla3();
                FiltrarPermisosCompuestos();
                FiltrarPermisosSimples();
                FiltrarPermisosCompuestos2();
                VerificarPermisos();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
        //Boton Asignar permiso simple.
        private void btn_AsignarPermisoSimple_Click(object sender, EventArgs e)
        {
            try
            {
                //Declaro variable utilizada para el obtener el id.
                string id;
                DataGridView dgvCompuesto = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosCompuestos").Puntero;
                DataGridView dgvSimple = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosSimples").Puntero;
                DataGridView dgvPermisos = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosPermiso").Puntero;

                try
                {
                    //Asigno a la variable, el id del permiso compuesto seleccionado.
                    id = ((PermisoCompuesto)dgvCompuesto.SelectedRows[0].DataBoundItem).Id.ToString();
                    //Relaciono el permiso compuesto seleccionado de la grilla permisos compuesto, con el permiso de la otra grilla de permisos simples.
                    PermisoCompuesto oPermisoCompuesto = ((PermisoCompuesto)(dgvCompuesto.SelectedRows[0].DataBoundItem));
                    Permiso oPermiso = (((Permiso)(dgvSimple.SelectedRows[0].DataBoundItem)));
                    //Añado el permiso a la lista de permisos.
                    oPermisoCompuesto.ListaPermisos.Add(oPermiso);
                    //Verifico que no este asignando un permiso repetido.
                    if (oBLLPermiso.ValidarPermisos(oPermiso, id) == true)
                    {
                        oBLLPermiso.AsignarPermiso(oPermisoCompuesto);
                    }
                    else
                    {
                        MessageBox.Show("Esta asignando un permiso que ya fue asignado", "Advertencia");
                    }
                    //Muestro en el dgv Permisos_Permiso los permisos del permiso compuesto seleccionado.
                    dgvPermisos.DataSource = null; dgvPermisos.DataSource = ((PermisoCompuesto)dgvCompuesto.SelectedRows[0].DataBoundItem);
                    dgvPermisos.DataSource = oBLLPermiso.CargarPermisos(id);
                }
                catch (Exception ex) { throw new Exception(ex.Message); }
               
            }
            catch (Exception ex) {   throw new Exception(ex.Message); }

        }
        //Boton Quitar permiso.
        private void btn_QuitarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                //Declaro variable utilizada para el obtener el id.
                string id;
                DataGridView dgvCompuesto = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosCompuestos").Puntero;
                DataGridView dgvPermisos = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosPermiso").Puntero;

                //Asigno a la variable, el id del permiso compuesto seleccionado.
                id = ((PermisoCompuesto)dgvCompuesto.SelectedRows[0].DataBoundItem).Id.ToString();
                //Relaciono el permiso compuesto seleccionado de la grilla permisos compuesto, con el permiso (simple), de la grilla de permisos simples.
                PermisoCompuesto oPermisoCompuesto = ((PermisoCompuesto)(dgvCompuesto.SelectedRows[0].DataBoundItem));
                Permiso oPermiso = (((Permiso)(dgvPermisos.SelectedRows[0].DataBoundItem)));
                //Llamo al metodo quitar permiso y le paso como parametro el permiso y el id del permiso compuesto seleccionado.
                oBLLPermiso.QuitarPermiso(oPermiso, id);
                //Muestro en el dgv Permisos_Permiso los permisos del permiso compuesto seleccionado.
                dgvPermisos.DataSource = null; dgvPermisos.DataSource = ((PermisoCompuesto)dgvCompuesto.SelectedRows[0].DataBoundItem);
                dgvPermisos.DataSource = oBLLPermiso.CargarPermisos(id);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Boton Quitar permiso compuesto.
        private void btn_QuitarPermisoCompuesto_Click(object sender, EventArgs e)
        {
            try
            {
                //Declaro variable utilizada para el obtener el id.
                string id;
                DataGridView dgvCompuesto = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosCompuestos").Puntero;
                DataGridView dgvPermisos = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosPermiso").Puntero;
                DataGridView dgvCompuesto2 = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosCompuestos2").Puntero;

                //Asigno a la variable, el id del permiso compuesto seleccionado.
                id = ((PermisoCompuesto)dgvCompuesto.SelectedRows[0].DataBoundItem).Id.ToString();
                //Relaciono el permiso compuesto seleccionado de la grilla permisos compuesto, con el permiso (compuesto), de la grilla de permisos compuestos.
                PermisoCompuesto oPermisoCompuesto = ((PermisoCompuesto)(dgvCompuesto.SelectedRows[0].DataBoundItem));
                Permiso oPermiso = (((Permiso)(dgvCompuesto2.SelectedRows[0].DataBoundItem)));
                //Llamo al metodo quitar permiso y le paso como parametro el permiso y el id del permiso compuesto seleccionado.
                oBLLPermiso.QuitarPermisoCompuesto(oPermiso, id);
                //Muestro en el dgv Permisos_Permiso los permisos del permiso compuesto seleccionado.
                dgvPermisos.DataSource = null; dgvPermisos.DataSource = ((PermisoCompuesto)dgvCompuesto.SelectedRows[0].DataBoundItem);
                dgvPermisos.DataSource = oBLLPermiso.CargarPermisos(id);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Evento Cellclick del dgv de permisos compuestos.
        private void dgv_PermisosCompuestos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id;
            DataGridView dgvPermisos = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosPermiso").Puntero;
            DataGridView dgvCompuesto = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosCompuestos").Puntero;

            try
            {
                //Obtengo el id del permiso compuesto seleccionado.
                id = ((PermisoCompuesto)dgvCompuesto.SelectedRows[0].DataBoundItem).Id.ToString();
                // Se muestra los permisos del permiso compuesto seleccionado.
                dgvPermisos.DataSource = null; dgvPermisos.DataSource =
                ((PermisoCompuesto)dgvCompuesto.SelectedRows[0].DataBoundItem);
                dgvPermisos.DataSource = oBLLPermiso.CargarPermisos(id);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Boton Asignar permiso compuesto.
        private void btn_AsignarPermiso2_Click(object sender, EventArgs e)
        {
            try
            {
                //Declaro variable utilizada para el obtener el id.
                string id;
                DataGridView dgvCompuesto = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosCompuestos").Puntero;
                DataGridView dgvCompuesto2 = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosCompuestos2").Puntero;
                DataGridView dgvPermisos = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosPermiso").Puntero;

                //Asigno a la variable, el id del permiso compuesto seleccionado.
                id = ((PermisoCompuesto)dgvCompuesto.SelectedRows[0].DataBoundItem).Id.ToString();
                //Relaciono el permiso compuesto seleccionado de la grilla permisos compuesto, con el permiso (compuesto), de la grilla de permisos compuestos.
                PermisoCompuesto oPermisoCompuesto = ((PermisoCompuesto)(dgvCompuesto.SelectedRows[0].DataBoundItem));
                Permiso oPermiso = (((Permiso)(dgvCompuesto2.SelectedRows[0].DataBoundItem)));
                //Añado el permiso a la lista de permisos.
                oPermisoCompuesto.ListaPermisos.Add(oPermiso);
                //Verifico que no este asignando un permiso repetido.
                if (oBLLPermiso.ValidarPermisos(oPermiso, id) == true)
                {
                    oBLLPermiso.AsignarPermiso(oPermisoCompuesto);
                }
                else
                {
                    MessageBox.Show("Esta asignando un permiso que ya fue asignado", "Advertencia");
                }
                //Muestro en el dgv Permisos_Permiso los permisos del permiso compuesto selecconado.
                dgvPermisos.DataSource = null; dgvPermisos.DataSource = ((PermisoCompuesto)dgvCompuesto.SelectedRows[0].DataBoundItem);
                dgvPermisos.DataSource = oBLLPermiso.CargarPermisos(id);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Boton Ayuda.
        private void btn_Ayuda_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Para asignar un permiso simple a un permiso compuesto: \n" +
                    "1- Seleccione un permiso compuesto de la primer grilla.\n" +
                    "2- Seleccion un permiso simple de la segunda grilla.\n" +
                    "3- Pulse el boton 'Asignar Permiso Simple'.\n\n" +
                    "Para asignar un permiso compuesto a otro permiso compuesto:\n" +
                    "1- Seleccione un permiso compuesto de la primer grilla.\n" +
                    "2- Seleccione otro permiso compuesto de la tercer grilla.\n" +
                    "3- Pulse el boton 'Asignar Permiso Compuesto'.\n\n" +
                    "Para quitar un permiso simple: \n" +
                    "1- Seleccionar el permiso compuesto involucrado (Primer grilla).\n" +
                    "2- Seleccionar el permiso de la grilla 'Permisos del permiso compuesto seleccionado' que desea quitar.\n" +
                    "3- Pulse el boton 'Quitar permiso'.\n\n" +
                    "Para quitar un permiso compuesto: \n" +
                    "1- Seleccionar el permiso compuesto involucrado (Primer grilla).\n" +
                    "2- Seleccionar el permiso compuesto (tercera grilla) que desea quitar.\n" +
                    "3- Pulse el boton 'Quitar permiso compuesto'. ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        #endregion

        private void ActualizarGrilla()
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosSimples").Puntero;
            try
            {
                dgv.DataSource = null;
                dgv.DataSource = oBLLPermiso.Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void ActualizarGrilla2()
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosCompuestos").Puntero;
            try
            {
                dgv.DataSource = null;
                dgv.DataSource = oBLLPermiso.Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void ActualizarGrilla3()
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosCompuestos2").Puntero;
            try
            {
                dgv.DataSource = null;
                dgv.DataSource = oBLLPermiso.Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo para verificar permisos.
        private void VerificarPermisos()
        {
            try
            {
                Label lblUsuario = (Label)ListaControles.Find(x => x.Nombre == "lbl_UsuarioLog").Puntero;
                Label lblAviso = (Label)ListaControles.Find(x => x.Nombre == "lbl_Aviso").Puntero;
                Label lblTitulo1 = (Label)ListaControles.Find(x => x.Nombre == "lbl_Titulo1").Puntero;
                Label lblTitulo2 = (Label)ListaControles.Find(x => x.Nombre == "lbl_Titulo2").Puntero;
                Label lblTitulo3 = (Label)ListaControles.Find(x => x.Nombre == "lbl_Titulo3").Puntero;
                Label lblTitulo4 = (Label)ListaControles.Find(x => x.Nombre == "lbl_Titulo4").Puntero;
                Button btnAsignarSimple = (Button)ListaControles.Find(x => x.Nombre == "btn_AsignarPermisoSimple").Puntero;
                Button btnAsignarComp = (Button)ListaControles.Find(x => x.Nombre == "btn_AsignarPermiso2").Puntero;
                Button btnQuitarComp = (Button)ListaControles.Find(x => x.Nombre == "btn_QuitarPermisoCompuesto").Puntero;
                Button btnQuitarSimple = (Button)ListaControles.Find(x => x.Nombre == "btn_QuitarPermiso").Puntero;
                Button btnAyuda = (Button)ListaControles.Find(x => x.Nombre == "btn_Ayuda").Puntero;
                DataGridView dgv1 = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosCompuestos").Puntero;
                DataGridView dgv2 = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosSimples").Puntero;
                DataGridView dgv3 = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosCompuestos2").Puntero;
                DataGridView dgv4 = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosPermiso").Puntero;
                //El tipo true significa que tiene los permisos, en cambio el tipo false no.
                bool tipoUsuario = true;
                List<Permiso> Perfil = new List<Permiso>();
                List<Button> listaBotones = new List<Button>() { btnAsignarSimple, btnAsignarComp, btnQuitarComp, btnQuitarSimple, btnAyuda };
                List<DataGridView> listaDgv = new List<DataGridView>() { dgv1, dgv2, dgv3, dgv4 };
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
                //Muestro un aviso en caso de que el usuario no tenga permisos.
                if (tipoUsuario == false)
                {
                    lblAviso.Enabled = true;
                    lblAviso.Location = new System.Drawing.Point(400, 300);
                    lblAviso.Text = "No posee permisos para trabajar con esta opción del sistema.";
                    lblTitulo1.Visible = false;
                    lblTitulo2.Visible = false;
                    lblTitulo3.Visible = false;
                    lblTitulo4.Visible = false;
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

        //Metodo que filtra los permisos simples, para mostrar solo los compuesto.
        private void FiltrarPermisosCompuestos()
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosCompuestos").Puntero;
            try
            {
                //Recorro el dgv.
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    //Si aparece una fila con una celda con el valor "Simple", la oculto.
                    if (row.Cells[2].Value.ToString() == "Simple")
                    {
                        dgv.CurrentCell = null;
                        row.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FiltrarPermisosCompuestos2()
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosCompuestos2").Puntero;
           
            try
            {
                //Recorro el dgv.
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    //Si aparece una fila con una celda con el valor "Simple", la oculto.
                    if (row.Cells[2].Value.ToString() == "Simple")
                    {
                        dgv.CurrentCell = null;
                        row.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Metodo que filtra los permisos compuestos, para mostrar solo los simples.
        private void FiltrarPermisosSimples()
        {
            DataGridView dgv = (DataGridView)ListaControles.Find(x => x.Nombre == "dgv_PermisosSimples").Puntero;
            try
            {
                //Recorro el dgv.
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    //Si aparece una fila con una celda con el valor "Simple", la oculto.
                    if (row.Cells[2].Value.ToString() == "Compuesto")
                    {
                        dgv.CurrentCell = null;
                        row.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
