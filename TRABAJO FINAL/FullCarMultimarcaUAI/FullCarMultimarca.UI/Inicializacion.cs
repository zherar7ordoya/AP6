
using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.BLL.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FullCarMultimarca.UI.Base;
using FullCarMultimarca.UI.Seguridad;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.BE;
using FullCarMultimarca.BLL;
using FullCarMultimarca.BLL.Ventas;
using FullCarMultimarca.UI.UserControls;

namespace FullCarMultimarca.UI
{
    public class Inicializacion
    {
        public Inicializacion()
        {

        }

        public void VerificarExistenciaBaseDeDatos()
        {
            try
            {
                BLLMigracion.ObtenerInstancia().VerificarYActualizarBaseDatos();
            }
            catch
            {
                throw;
            }
        }
        public void InicializarSistema(Form formMenu, ToolStripItemCollection dropDownItems)
        {
            bool visible = false;

            if (Ticket.UsuarioLogueado != null)
            {
                Ticket.LimpiarCachePermisos();
                foreach (Permiso permiso in BLLPermiso.ObtenerInstancia().ObtenerTodosLosPermisosParaUsuario(Ticket.UsuarioLogueado))
                {
                    //Inicializo los permisos de usuario
                    Ticket.AgregarPermiso(permiso);
                }
                //Verificamos consistencia de la base de datos.
                ValidarProteccionDatos();              
                visible = true;
                GuardarUltimoUsuarioLogueado(Ticket.UsuarioLogueado.Logon);
            }
            
            UtilUI.ObtenerInstancia()
                .CambiarVisibilidadMenu(dropDownItems, Ticket.ObtenerPermisos());

            if (visible)
            {
                formMenu.Text = $"FULLCAR Multimarca [{Ticket.UsuarioLogueado}] - v{Assembly.GetExecutingAssembly().GetName().Version}";
            }
            else
            {
                formMenu.Text = $"FULLCAR Multimarca [NO IDENTIFICADO]";
            }
        }

        public void ValidarProteccionDatos()
        {
            try
            {
                BLLProteccion.ObtenerInstancia().VerificarProteccionDeDatos();
            }
            catch (BaseCorruptaException exBC)
            {
                string msje = exBC.Message;

                if (Ticket.TienePermiso(ConstPermisos.GESTIONAR_BACKUPS))
                {
                    msje = msje + "\nTablas afectadas:\n";
                    if (exBC.TablasCorruptas != null)
                    {
                        foreach (string tabla in exBC.TablasCorruptas)
                        {
                            msje = $"{msje}- {tabla}\n";
                        }
                    }

                    msje = $"{msje}\n¿Desea ver los backups guardados para la restauración?";

                    if (MostrarMensaje.Pregunta(msje) == DialogResult.Yes)
                    {
                        var form = FormCatalogoBackup.ObtenerInstancia(true);
                        form.ShowDialog(); //Abrimos moFullCarMultimarca.DAL para no permitir usar el resto del sistema                                 
                        Application.Exit();//Si llega hasta acá es porque NO restauró, ergo, se cierra el sistema porque sigue en estado inconsitente
                    }
                    else
                        Application.Exit();

                }
                else //No tiene permisos de restaurar backuo
                {
                    MostrarMensaje.Error($"{msje}\nContacte al administrador.");
                    Application.Exit();
                }

            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
                Application.Exit();
            }
        }      
        public void GuardarUltimoUsuarioLogueado(string usuario)
        {
            Properties.Settings.Default.UltimoUsuarioLogueado = usuario;
            Properties.Settings.Default.Save();
        }
       

    }
}
