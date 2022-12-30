using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.BLL.Seguridad;
using System;
using System.Reflection;
using System.Windows.Forms;
using FullCarMultimarca.UI.Seguridad;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.BLL;


// CÓDIGO HORRIBLE, EL MÉTODO ValidarProteccionDatos() HAY QUE REFACTORIZARLO
// (ES DEMASIADO LARGO Y COMPLEJO) => MUCHO ANIDAMIENTO

namespace FullCarMultimarca.UI
{
    public class Inicializacion
    {
        // |> NO VOY A TOCAR ESTO HASTA ESTAR SEGURO QUE LA CLASE NO NECESITA
        // UN CONSTRUCTOR VACÍO.
        public Inicializacion() { /* ▂▃▅▇█ * █▇▅▃▂ */ }


        // --------------------------------------------------------------------
        // |> ÍNDICE DE INICIALIZACIÓN:
        //      VerificarExistenciaBaseDeDatos()
        //      InicializarSistema(Form formMenu, ToolStripItemCollection dropDownItems)
        //      ValidarProteccionDatos()
        //      GuardarUltimoUsuarioLogueado(string usuario)
        // --------------------------------------------------------------------

        public void VerificarExistenciaBaseDeDatos()
        {
            try
            {
                // OBTENER INSTANCIA => PATRÓN DE DISEÑO SINGLETON
                BLLMigracion.ObtenerInstancia().VerificarYActualizarBaseDatos();
            }
            catch { throw; }
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
                    msje += "\nTablas afectadas:\n";
                    
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

                        // Abrimos moFullCarMultimarca.DAL para no permitir usar
                        // el resto del sistema                                 
                        form.ShowDialog();

                        // Si llega hasta acá es porque NO restauró, ergo, se
                        // cierra el sistema porque sigue en estado inconsistente
                        Application.Exit();
                    }
                    else
                        Application.Exit();

                }
                else //No tiene permisos de restaurar backup
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


        // |> GUARDA EL ÚLTIMO USUARIO LOGUEADO EN UN XML UBICADO EN UNA
        // SUBCARPETA DE LA CARPETA OCULTA LOCAL DE DATOS DE APLICACIONES
        // https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-write-user-settings-at-run-time-with-csharp?view=netframeworkdesktop-4.8
        // EN MI CASO, PODRÍA SER C:\Users\gtordoya\AppData\Local\[APP]\[ALEATORIO]\1.1.0.0\user.config

        public void GuardarUltimoUsuarioLogueado(string usuario)
        {
            Properties.Settings.Default.UltimoUsuarioLogueado = usuario;
            Properties.Settings.Default.Save();
        }
    }
}
