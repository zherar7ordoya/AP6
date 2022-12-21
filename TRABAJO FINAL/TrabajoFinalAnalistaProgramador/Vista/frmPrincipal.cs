using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidad;
using PermisoComposite;
using BLL;
using ServiciosDGV;
using System.Threading;

namespace Vista
{
    public partial class frmPrincipal : Form
    {
        E_Usuario oUsuario;
        BLL_Usuario oBLLUsuario;
        BLL_LogIn oBLLLogin;
        BLL_Permiso oBLLPermiso;
        BLL_Entrega oBLLEntrega;
        EdicionDGV oEdicionDGV;
        E_Entrega oEntrega;

        public frmPrincipal()
        {
            
            InitializeComponent();
            oUsuario = new E_Usuario();
            oBLLUsuario = new BLL_Usuario();
            oBLLLogin = new BLL_LogIn();
            oBLLPermiso = new BLL_Permiso();
            oBLLEntrega = new BLL_Entrega();
            oEdicionDGV = new EdicionDGV();
            oEntrega = new E_Entrega();
        }

        private void btn_Articulos_MouseMove(object sender, MouseEventArgs e)
        {
            //Hago visible el panelBoton1 y le asigno una localizacion.
            PanelBoton1.Visible = true;
            PanelBoton1.Location = new Point(254, 89);
            //Escondo los demas panelBoton.
            PanelBoton3.Hide();
            PanelBoton4.Hide();
            PanelBoton5.Hide();
            PanelBoton6.Hide();
            PanelBoton7.Hide();
            PanelBoton2.Hide();
        }

        private void btn_Proveedores_MouseMove(object sender, MouseEventArgs e)
        {
            //Hago visible el panelBoton3 y le asigno una localizacion.
            PanelBoton3.Visible = true;
            PanelBoton3.Location = new Point(253, 230);
            //Escondo los demas panelBoton.
            PanelBoton1.Hide();
            PanelBoton5.Hide();
            PanelBoton4.Hide();
            PanelBoton6.Hide();
            PanelBoton7.Hide();
            PanelBoton2.Hide();
        }

        private void btn_FechasEntrega_MouseMove(object sender, MouseEventArgs e)
        {
            //Hago visible el panelBoton4 y le asigno una localizacion.
            PanelBoton4.Visible = true;
            PanelBoton4.Location = new Point(253, 277);
            //Escondo los demas panelBoton.
            PanelBoton1.Hide();
            PanelBoton3.Hide();
            PanelBoton5.Hide();
            PanelBoton6.Hide();
            PanelBoton7.Hide();
            PanelBoton2.Hide();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            PanelBoton1.Hide();
            PanelBoton3.Hide();
            PanelBoton4.Hide();
            PanelBoton5.Hide();
            PanelBoton6.Hide();
            PanelBoton7.Hide();
            PanelBoton2.Hide();
            LlenarGrilla();
            VerificarPermisos();
            oEdicionDGV.EditarDGV(dgv_EntregasPendientes);
            lbl_Hora.Text = DateTime.Now.ToShortTimeString();
            lbl_Fecha.Text = DateTime.Now.ToLongDateString();
            PanelBoton1.BorderStyle = BorderStyle.None;
            PanelBoton3.BorderStyle = BorderStyle.None;
            PanelBoton4.BorderStyle = BorderStyle.None;
            PanelBoton5.BorderStyle = BorderStyle.None;
            PanelBoton6.BorderStyle = BorderStyle.None;
            PanelBoton7.BorderStyle = BorderStyle.None;
        }

        private void frmPrincipal_MouseMove(object sender, MouseEventArgs e)
        {
            PanelBoton1.Hide();
            PanelBoton3.Hide();
            PanelBoton4.Hide();
            PanelBoton5.Hide();
            PanelBoton6.Hide();
            PanelBoton7.Hide();
            PanelBoton2.Hide();
        }        

        private void LlenarGrilla()
        {
            try
            {
                dgv_EntregasPendientes.DataSource = null;
                dgv_EntregasPendientes.DataSource = oBLLEntrega.ListarOrdenadoFecha();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_DatosProveedores_Click(object sender, EventArgs e)
        {
            frmProveedor proveedor = new frmProveedor();
            proveedor.Show();
            PanelBoton3.Hide();
        }

        private void btn_CreacionUsuarios_Click_1(object sender, EventArgs e)
        {
            frmUsuario usuario = new frmUsuario();
            usuario.Show();
            PanelBoton5.Hide();
        }

        private void btn_DatosGerentes_Click(object sender, EventArgs e)
        {
            frmGerentes gerentes = new frmGerentes();
            gerentes.Show();
            PanelBoton5.Hide();
        }

        private void btn_CrearPermisos_Click_1(object sender, EventArgs e)
        {
            frmPermisos permisos = new frmPermisos();
            permisos.Show();
            PanelBoton5.Hide();
        }

        private void btn_CerrarSesion_Click(object sender, EventArgs e)
        {
            //Opcion Cerrar Sesion.
            if (MessageBox.Show("¿Estas seguro " + label_Usuario.Text + " que deseas Cerrar la Sesión?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                //Cierro el formulario.
                this.Close();
            }
        }

        private void btn_ArmarPermisos_Click_1(object sender, EventArgs e)
        {
            frmArmarPermisos armarPermisos = new frmArmarPermisos();
            armarPermisos.Show();
            PanelBoton5.Hide();
        }

        private void btn_DeterminarSueldos_Click_1(object sender, EventArgs e)
        {
            frmDeterminarSueldos determinarSueldos = new frmDeterminarSueldos();
            determinarSueldos.Show();
            PanelBoton5.Hide();
        }

        private void btn_BackUp_Click(object sender, EventArgs e)
        {
            frmBackUp backUp = new frmBackUp();
            backUp.Show();
        }

        private void btn_Marcas_Click(object sender, EventArgs e)
        {
            frmMarcas marcas = new frmMarcas();
            marcas.Show();
            PanelBoton1.Hide();
        }

        private void btn_AdmInventario_Click(object sender, EventArgs e)
        {
            frmAdmInventario admInventario = new frmAdmInventario();
            admInventario.Show();
            PanelBoton1.Hide();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            PanelBoton1.Hide();
            PanelBoton3.Hide();
            PanelBoton4.Hide();
            PanelBoton5.Hide();
            PanelBoton7.Hide();
            PanelBoton2.Hide();
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            PanelBoton1.Hide();
            PanelBoton3.Hide();
            PanelBoton4.Hide();
            PanelBoton5.Hide();
            PanelBoton7.Hide();
            PanelBoton2.Hide();
        }

        private void btn_Calculadora_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("calc.exe");
                PanelBoton6.Hide();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_Herramientas_MouseMove(object sender, MouseEventArgs e)
        {
            //Hago visible el panelBoton4 y le asigno una localizacion.
            PanelBoton6.Visible = true;
            PanelBoton6.Location = new Point(253, 324);
            //Escondo los demas panelBoton.
            PanelBoton1.Hide();
            PanelBoton3.Hide();
            PanelBoton5.Hide();
            PanelBoton4.Hide();
            PanelBoton7.Hide();
            PanelBoton2.Hide();
        }

        private void btn_Notas_Click(object sender, EventArgs e)
        {
            try
            {
                //Abrimos el bloc de notas.
                System.Diagnostics.Process.Start("notepad.exe");
                PanelBoton6.Hide();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_Calendario_Click(object sender, EventArgs e)
        {
            try
            {
                //Abrimos el bloc de notas.
                frmCalendario calendario = new frmCalendario();
                calendario.Show();
                PanelBoton6.Hide();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        private void VerificarPermisos()
        {
            try
            {
                List<Permiso> Perfil = new List<Permiso>();
                List<Button> listaBotones = new List<Button>() { btn_DatosImportantes, btn_Telefonos };
                //Muestro en el label el usuario logeado.
                //Obtengo el id del usuario logeado.
                oUsuario.idUsuario = int.Parse(oBLLLogin.ObtenerUsuarioLogeado());
                //Obtengo el nombre del usuario.
                oBLLUsuario.ObtenerNombreUsuario(oUsuario);
                label_Usuario.Text = oUsuario.Nombre;
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

        private void btn_IngresarFechas_Click(object sender, EventArgs e)
        {
            frmEntrega entrega = new frmEntrega();
            entrega.Show();
        }

        private void dgv_EntregasPendientes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                this.dgv_EntregasPendientes.Columns["oGerente"].Visible = false;
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_QuitarEntrega_Click(object sender, EventArgs e)
        {
            try
            {
                //Establezco condicion.
                if (!string.IsNullOrEmpty(oEntrega.Id.ToString()))
                {
                    //Me aseguro que haya una marca seleccionada.
                    if (dgv_EntregasPendientes.CurrentRow == null)
                    {
                        MessageBox.Show("Debe seleccionar la entrega pendiente!!!", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    //Pregunto si deseo eliminar la marca.
                    oEntrega = (E_Entrega)dgv_EntregasPendientes.CurrentRow.DataBoundItem;
                    if (MessageBox.Show("¿Está seguro que la entrega del dia: " + oEntrega.Fecha + " fue realizada?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1
                    ) == DialogResult.Yes)
                    {
                        //Se elimina la marca.
                        oBLLEntrega.Baja(oEntrega);
                        //Refresco grilla.
                        LlenarGrilla();
                    }
                }
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        private void dgv_EntregasPendientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                //Recorro el datagrid.
                foreach (DataGridViewRow row in dgv_EntregasPendientes.Rows)
                {   
                    //Si la fecha es menor a la fecha actual, pinto de rojo el registro.
                    if (Convert.ToDateTime(row.Cells[1].Value) < DateTime.Now)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_Estadisticas_MouseMove(object sender, MouseEventArgs e)
        {
            //Hago visible el panelBoton4 y le asigno una localizacion.
            PanelBoton7.Visible = true;
            PanelBoton7.Location = new Point(253, 371);
            //Escondo los demas panelBoton.
            PanelBoton1.Hide();
            PanelBoton3.Hide();
            PanelBoton5.Hide();
            PanelBoton4.Hide();
            PanelBoton6.Hide();
            PanelBoton2.Hide();
        }

        private void dgv_EntregasPendientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DateTime fechaEntrega;

            try
            {
                //Hago visible el label.
                lbl_ProximaEntrega.Visible = true;
                //Obtengo el registro seleccionado.
                oEntrega = (E_Entrega)dgv_EntregasPendientes.CurrentRow.DataBoundItem;
                //Asigno un el valor a una variable.
                fechaEntrega = oEntrega.Fecha;
                //Llamo al metodo que calcula la proxima entrega y lo muestro en el label. Ademas, establezco que se muestre un solo decimal.
                lbl_ProximaEntrega.Text = oBLLEntrega.CalcularProximaEntrega(fechaEntrega).ToString("N1") + " Días.";

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_DatosImportantes_Click(object sender, EventArgs e)
        {
            frmDatosImportates datosImportates = new frmDatosImportates();
            datosImportates.Show();
        }

        private void btn_Graficos_Click(object sender, EventArgs e)
        {
            frmGraficos graficos = new frmGraficos();
            graficos.Show();
        }

        private void btn_ArticuloFaltante_Click(object sender, EventArgs e)
        {
            frmReporteArticuloFaltante reporteArticuloFaltante = new frmReporteArticuloFaltante();
            reporteArticuloFaltante.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_Hora.Text = DateTime.Now.ToShortTimeString();
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                frmSplashCreen2 splashCreen2 = new frmSplashCreen2();
                splashCreen2.Visible = true;
                splashCreen2.Show();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        private void btn_BackUp_MouseMove(object sender, MouseEventArgs e)
        {
            PanelBoton7.Hide();
        }

        private void btn_Gerente_MouseMove(object sender, MouseEventArgs e)
        {
            //Hago visible el panelBoton5 y le asigno una localizacion.
            PanelBoton5.Visible = true;
            //Escondo los demas panelBoton.
            PanelBoton5.Location = new Point(254, 136);
            PanelBoton1.Hide();
            PanelBoton4.Hide();
            PanelBoton6.Hide();
            PanelBoton7.Hide();
            PanelBoton2.Hide();
        }
        
        private void btn_Empleado_MouseMove(object sender, MouseEventArgs e)
        {
            //Hago visible el panelBoton5 y le asigno una localizacion.
            PanelBoton2.Visible = true;
            //Escondo los demas panelBoton.
            PanelBoton2.Location = new Point(253, 183);
            PanelBoton1.Hide();
            PanelBoton4.Hide();
            PanelBoton6.Hide();
            PanelBoton7.Hide();
            PanelBoton5.Hide();
            PanelBoton3.Hide();
        }

        private void btn_DatosPersonalesEmpl_Click(object sender, EventArgs e)
        {
            frmEmpleados empleados = new frmEmpleados();
            empleados.Show();
        }

        private void btn_Telefonos_Click_1(object sender, EventArgs e)
        {
            frmTelefonos telefonos = new frmTelefonos();
            telefonos.Show();
        }
    }
}
