﻿using FullCarMultimarca.UI.Base;
using FullCarMultimarca.UI.Seguridad;
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using FullCarMultimarca.UI.Gestion;
using FullCarMultimarca.BLL.Parametros;
using FullCarMultimarca.UI.Parametros;
using FullCarMultimarca.UI.Ventas;
using FullCarMultimarca.BLL.Ventas;
using FullCarMultimarca.BLL;
using FullCarMultimarca.UI.Liquidaciones;
using FullCarMultimarca.BLL.Liquidaciones;
using FullCarMultimarca.BE.Liquidaciones;


namespace FullCarMultimarca.UI
{
    // |> INCLUYO ANÁLISIS DE FLUJO "ON-BOOT"
    public partial class FormMenu : Form
    {

        //  SIN NOVEDAD
        public FormMenu() => InitializeComponent();


        // |> AGRUPO VARIABLES DE CLASE

        // INICIALIZAR SIGNIFICA:
        // *) VerificarExistenciaBaseDeDatos()
        // *) InicializarSistema(Form formMenu, ToolStripItemCollection dropDownItems)
        // *) ValidarProteccionDatos()
        // *) GuardarUltimoUsuarioLogueado(string usuario)
        private Inicializacion _inicializacion = new Inicializacion();

        private EventHandler _onOfertasVencidas;
        private static Notification _formNotificacionOpPendientesAut;
        private static Notification _formNotificacionOpRechazadas;


        // |> TODAVÍA NO SÉ QUÉ HACE... |||||||||||||||||||||||||||||||||||||||
        public event EventHandler OnOfertasVencidas
        {
            // |> ÉSTE ES UN PATRÓN PARA EVITAR QUE UN CONTROLADOR DE EVENTOS
            // (EVENT HANDLER) SE ENGANCHE (HOOK) DOS VECES. CON ESTE CÓDIGO,
            // SE IGNORARÁ A UN LLAMADOR (CALLER) QUE SE SUSCRIBA DE NUEVO.
            add
            {
                if (_onOfertasVencidas == null || !_onOfertasVencidas.GetInvocationList().Contains(value))
                {
                    _onOfertasVencidas += value;
                }
            }
            remove
            {
                _onOfertasVencidas -= value;
            }
        }


        //#region Eventos (del menú principal) --------------------------------

        // |> ÉSTO ES LO PRIMERO QUE SE VA A EJECUTAR
        // *) CULTURIZAR
        // *) VERIFICA SI EXISTE LA BASE DE DATOS
        // *) LLAMA A INICIALIZAR EL SISTEMA
        private void FormMenu_Load(object sender, EventArgs e)
        {
            try
            {
                // CONFIGURACIÓN REGIONAL (¿PARA QUÉ?)
                var cInfo = new CultureInfo("es-AR");
                System.Threading.Thread.CurrentThread.CurrentUICulture = cInfo;
                System.Threading.Thread.CurrentThread.CurrentCulture = cInfo;

                _inicializacion.VerificarExistenciaBaseDeDatos();

                // |> VUELVE A EJECUTAR LA INICIALIZACIÓN
                Ticket.OnUsarioLogueadoCambiado += OnInicializarSistema;
            }
            catch (Exception ex)
            {
                // |> MANEJADOR DE ERRORES: SIMPLEMENTE CIERRA (CONSULTAR LAS
                // OBSERVACIONES DE TIM COREY SOBRE ESTA ESTRATEGIA, CREO
                // RECORDAR QUE ALGO DIJO SOBRE LA CORRUPCIÓN DE DATOS (QUE FUE
                // JUSTAMENTE LO QUE SUCEDIÓ AQUÍ EN EL PRIMER ARRANQUE)
                MostrarMensaje.MostrarError(ex);
                Application.Exit();
            }
        }


        // |> ESTE EVENTO OCURRE CUANDO SE MUESTRA EL FORMULARIO POR PRIMERA VEZ
        private void FormMenu_Shown(object sender, EventArgs e)
        {
            try
            {
                IngresarAlSistema();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
                Application.Exit();
            }
        }


        private void FormMenu_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }


        // |> MENUITEM INICIO *************************************************

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void cambiarDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormLogin fLogin = new FormLogin();
                if (DialogResult.OK == fLogin.ShowDialog())
                {
                    UtilUI.ObtenerInstancia().CerrarTodosLosFormsHijos(this);
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
                Application.Exit();
            }
        }


        private void modificarClaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var fAltaUsuario = new FormModificarClave(Ticket.UsuarioLogueado.Logon);
                fAltaUsuario.ShowDialog();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }


        private void modiciarPalabraClaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var fModificarPalabraClave = new FormCargarPalabraClave(Ticket.UsuarioLogueado.Logon);
                fModificarPalabraClave.ShowDialog();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }


        private void altaDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var instancia = FormListaUsuarios.ObtenerInstancia();
                UtilUI.ObtenerInstancia().AbrirOTraerAlFrente(this, instancia);
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }


        private void verLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var instancia = FormListaLogs.ObtenerInstancia();
                UtilUI.ObtenerInstancia().AbrirOTraerAlFrente(this, instancia);
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }


        private void parametrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var flags = BLLFlagsSeguridad.ObtenerInstancia().Leer();
                var fModificarParametros = new FormParametros(flags);
                fModificarParametros.ShowDialog();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }


        private void gestiónPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var instancia = FormPermisos.ObtenerInstancia();
                UtilUI.ObtenerInstancia().AbrirOTraerAlFrente(this, instancia);
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }


        private void gestiónDeBackupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var instancia = FormCatalogoBackup.ObtenerInstancia();
                UtilUI.ObtenerInstancia().AbrirOTraerAlFrente(this, instancia);
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }


        // |> MENUITEM ADMINISTRACIÓN *****************************************

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var instancia = FormListaMarcas.ObtenerInstancia();
                UtilUI.ObtenerInstancia().AbrirOTraerAlFrente(this, instancia);
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void modelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var instancia = FormListaModelos.ObtenerInstancia();
                UtilUI.ObtenerInstancia().AbrirOTraerAlFrente(this, instancia);
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void coloresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var instancia = FormListaColores.ObtenerInstancia();
                UtilUI.ObtenerInstancia().AbrirOTraerAlFrente(this, instancia);
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void parámetrosEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var flags = BLLFlagsVentas.ObtenerInstancia().Leer();
                var fModificarParametros = new FormParametrosVentas(flags);
                fModificarParametros.ShowDialog();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void parametrosComisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var flags = BLLFlagsComisiones.ObtenerInstancia().Leer();
                var fModificarParametros = new FormParametroComisiones(flags);
                fModificarParametros.ShowDialog();
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void formasDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var instancia = FormListaFormaPago.ObtenerInstancia();
                UtilUI.ObtenerInstancia().AbrirOTraerAlFrente(this, instancia);
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void tiposDeContactoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var instancia = FormListaTiposContacto.ObtenerInstancia();
                UtilUI.ObtenerInstancia().AbrirOTraerAlFrente(this, instancia);
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var instancia = FormListaClientes.ObtenerInstancia();
                UtilUI.ObtenerInstancia().AbrirOTraerAlFrente(this, instancia);
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void unidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var instancia = FormListaUnidades.ObtenerInstancia();
                //Me suscribo al evento para notificar a esta instancia abierta si ocurre un vencimiento de oferta
                OnOfertasVencidas += instancia.RefrescarGrillaDesdeSuscripcion;
                //Me suscribo a la notificación de cuando se cierra la lista para desuscribirme de la notificación de ofertas vencidas
                instancia.OnListaBaseCerrada += DesuscribirDeVencimientoOfertas;
                UtilUI.ObtenerInstancia().AbrirOTraerAlFrente(this, instancia);
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }


        // |> MENUITEM VENTAS *************************************************

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var instancia = FormListaStock.ObtenerInstancia();
                //Me suscribo al evento para notificar a esta instancia abierta si ocurre un vencimiento de oferta
                OnOfertasVencidas += instancia.RefrescarGrillaDesdeSuscripcion;
                //Me suscribo a la notificación de cuando se cierra la lista para desuscribirme de la notificación de ofertas vencidas
                instancia.OnListaBaseCerrada += DesuscribirDeVencimientoOfertas;
                UtilUI.ObtenerInstancia().AbrirOTraerAlFrente(this, instancia);
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void operacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var instancia = FormListaOperaciones.ObtenerInstancia();
                UtilUI.ObtenerInstancia().AbrirOTraerAlFrente(this, instancia);
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void operacionesPendientesDeAutorizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var instancia = FormListaOperacionesAAutorizar.ObtenerInstancia();
                UtilUI.ObtenerInstancia().AbrirOTraerAlFrente(this, instancia);
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }


        // |> MENUITEM LIQUIDACIONES ******************************************

        private void liquidarComisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var nuevaLiquidacion = new FormLiquidarComisiones();
                string codigo = nuevaLiquidacion.IniciarNuevaLiquidacion();
                if (nuevaLiquidacion.DialogResult == DialogResult.OK)
                {
                    var liqCompleta = BLLLiquidacion.ObtenerInstancia().ObtenerVistaCompleta(new Liquidacion(codigo));
                    var fDetalle = new FormVerLiquidacion(liqCompleta);
                    fDetalle.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }
        private void liquidacionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var instancia = FormListaLiquidaciones.ObtenerInstancia();
                UtilUI.ObtenerInstancia().AbrirOTraerAlFrente(this, instancia);
            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
            }
        }


        // --------------------------------------------------------------------
        // HASTA ACÁ MÁS O MENOS ERA COHERENTE, PERO A PARTIR DE AQUÍ SE PUSO
        // HORRIBLE: SIMPLEMENTE, HAY COSAS QUE NO DEBERÍAN ESTAR AQUÍ.
        // VER LA FORMA DE HACER ALGO MÁS PROLIJO, POR DIOS...
        // --------------------------------------------------------------------


        //#region EVENTOS Y METODOS DE DE INICIALIZACION

        /// <summary>
        /// Evento que se produce al cambiar el usuario del ticket; 
        /// Cachea el usuario, sus permisos y configura el menu principal.
        /// </summary>     
        private void OnInicializarSistema(object sender, EventArgs e)
        {
            try
            {
                //Si está ejecutando un cambio de usuario y habia ventanas de notificación abiertas, las cerramos.
                if (_formNotificacionOpPendientesAut != null)
                    _formNotificacionOpPendientesAut.Close();
                if (_formNotificacionOpRechazadas != null)
                    _formNotificacionOpRechazadas.Close();


                _inicializacion.InicializarSistema(this, menuStrip1.Items);

                // Al ingresar exitosamente anulamos las ofertas e incializamos
                // el timer para que se venzan nuevas ofertas cada un minuto.
                AnularOfertasVencidas();
                IniciarTimerVencimientoOfertas();
                
                // También vemos si hay operaciones pendientes de autorizar para
                // avisar, luego timer cada 3 minutos para continuar notificando.
                BuscarOperacionesPendientesDeAutorizar();
                
                // Revisamos y notificamos si el usuario tiene operaciones
                // rechazadas que revisar
                BuscarOperacionesRechazadas();
                
                // Solo se notifica a los usuarios logueados que tengan permiso
                // de autorizar operaciones
                IniciarTimerNotificacionOperaciones();

            }
            catch (Exception ex)
            {
                MostrarMensaje.MostrarError(ex);
                this.Close();
            }
        }

        
        private void IngresarAlSistema()
        {
            // POR SI ME OLVIDO LUEGO: RECUPERA EN UN STRING DESDE EL XML EN LA
            // SUBCARPETA DE USUARIO (WINDOWS) EL NOMBRE GUARDADO DEL ÚLTIMO
            // USUARIO Y LO PONE EN EL TEXTBOX "USUARIO" DEL FORMULARIO LOGIN.
            FormLogin fLogin = new FormLogin(Properties.Settings.Default.UltimoUsuarioLogueado);

            // SOLO RECUPERA LA RESPUESTA POSITIVA DEL DIÁLOGO
            // ¿DÓNDE, CUÁNDO, SE HACE EL CONTROL DE INGRESO?
            if (DialogResult.OK != fLogin.ShowDialog())
                Application.Exit();
        }



        // ********************************************************************
        // --------- DILUCIDAR DEL PDF CUÁL ES LA LÓGICA DE LOS TIMERS --------
        // ********************************************************************



        //#region MANEJO DEL VENCIMIENTO DE OFERTAS
        private void IniciarTimerVencimientoOfertas()
        {
            timerVencimientoOfertas.Interval = 180000; //Cada tres minutos
            timerVencimientoOfertas.Tick += VencerOfertas;
            timerVencimientoOfertas.Start();
        }


        private void VencerOfertas(object sender, EventArgs e)
        {
            try
            {
                timerVencimientoOfertas.Stop();
                if (AnularOfertasVencidas())
                {
                    //Si se vencieron ofertas invoco a los suscriptores que
                    //desen ser notificados
                    _onOfertasVencidas?.Invoke(this, null);
                }
            }
            catch
            {
                // |> ¿PUEDE QUEDAR VACÍO? ||||||||||||||||||||||||||||||||||||
                //Consumimos el error
            }
            finally
            {
                // DUPLICA INICIAL EL TIMER (ESTÁ EN IniciarTimerVencimientoOfertas())
                timerVencimientoOfertas.Start();
            }
        }

        
        private bool AnularOfertasVencidas()
        {
            try
            {
                // ¿CUÁL ES LA DIFERENCIA CON EL "VencerOfertas()" DE ARRIBA?
                // (ESTO ESTÁ FEO, ORDENARLO)
                return BLLStock.ObtenerInstancia().VencerOfertas();
            }
            catch
            {
                // ¿ÉSTO ES CONSUMIR UN ERROR? NO DIGO QUE ESTÉ MAL, SOLO QUE
                // ESE "RETURN" EN UN CATCH... ES LA PRIMERA VEZ QUE LO VEO.
                //Consumimos el error
                return false;
            }
        }

        private void DesuscribirDeVencimientoOfertas(object sender, EventArgs e)
        {
            // NO SÉ QUÉ QUISO HACER. PARECE QUE LA IDEA ERA HACER UNA CLASE
            // BASE, LUEGO SE DIÓ CUENTA QUE NO EXISTE EN C# MULTI-HERENCIA,
            // NO LO PODÍA SOLUCIONAR CON UNA CLASE ABSTRACTA, TAMPOCO CON UNA
            // INTERFAZ, Y EN VEZ DE HACER UNA CLASE ESTÁTICA, HIZO UN PAR DE
            // MÉTODOS PÚBLICOS (ORDENAR, POR DIOS...)
            OnOfertasVencidas -= (sender as FormListaBase).RefrescarGrillaDesdeSuscripcion;
        }

        //#endregion

        // #region MANEJO DEL POPUP NOTIFICABLE DE OPERACIONES PENDIENTES DE
        // AUTORIZAR y RECHAZADAS POR USUARIO

        private void IniciarTimerNotificacionOperaciones()
        {
            timerNotificacionOperaciones.Interval = 600000; //Cada diez minutos
            timerNotificacionOperaciones.Tick += NotificarOperaciones;
            timerNotificacionOperaciones.Start();
        }


        private void NotificarOperaciones(object sender, EventArgs e)
        {
            try
            {
                // TODO JUNTO... (ARREGLAR POR FAVOR)
                timerNotificacionOperaciones.Stop();
                BuscarOperacionesPendientesDeAutorizar();
                BuscarOperacionesRechazadas();
            }
            catch
            {
                //Consumimos el error
            }
            finally
            {
                timerNotificacionOperaciones.Start();
            }
        }


        private void BuscarOperacionesPendientesDeAutorizar()
        {
            var qAutPendientes = BLLOperacion
                .ObtenerInstancia()
                .ObtenerCantidadAutorizacionPendientes();

            // LA VERDAD, AUNQUE EL PROYECTO SE VE BIEN, LA FORMA DE PROGRAMAR...
            if (qAutPendientes > 0)
            {
                if (_formNotificacionOpPendientesAut != null)
                    _formNotificacionOpPendientesAut.Close();

                _formNotificacionOpPendientesAut = new Notification();
                //_formNotificacionOpPendientesAut.KeyComando = "FullCarMultimarca.UI.Ventas.FormListaOperacionesAAutorizar";
                _formNotificacionOpPendientesAut.BackColor = Color.LightYellow;

                if (qAutPendientes == 1)
                {
                    _formNotificacionOpPendientesAut.labelTextoNotificacion.Text = "Tiene una operación pendiente de Autorizar.";
                }
                else
                {
                    _formNotificacionOpPendientesAut.labelTextoNotificacion.Text = String.Format("Tiene {0} operaciones pendientes de Autorizar.", qAutPendientes);
                }

                _formNotificacionOpPendientesAut.linkLabel1.Text = "Presione aquí para abrir la carpeta de Operaciones a Autorizar";
                _formNotificacionOpPendientesAut.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(MostrarOperacionesPendientes);
                _formNotificacionOpPendientesAut.Show();
            }
        }


        private void BuscarOperacionesRechazadas()
        {
            var qOpRech = BLLOperacion
                .ObtenerInstancia()
                .ObtenerCantidadRechazadasPorUsuario();

            if (qOpRech > 0)
            {
                if (_formNotificacionOpRechazadas != null)
                    _formNotificacionOpRechazadas.Close();

                _formNotificacionOpRechazadas = new Notification();
                //_formNotificacionOpPendientesAut.KeyComando = "FullCarMultimarca.UI.Ventas.FormListaOperacionesAAutorizar";
                _formNotificacionOpRechazadas.BackColor = Color.LightYellow;

                if (qOpRech == 1)
                {
                    _formNotificacionOpRechazadas.labelTextoNotificacion.Text = "Tiene una operación rechazada para revisar.";
                }
                else
                {
                    _formNotificacionOpRechazadas.labelTextoNotificacion.Text = String.Format("Tiene {0} operaciones rechazadas para revisar.", qOpRech);
                }

                _formNotificacionOpRechazadas.linkLabel1.Text = "Presione aquí para abrir la carpeta de Operaciones";
                _formNotificacionOpRechazadas.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(MostrarOperacionesRechazadas);
                _formNotificacionOpRechazadas.Show();
            }
        }



        //Evento que procesa el click sobre el FormNotificación
        private void MostrarOperacionesPendientes(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                }

                this.BringToFront();
                var instancia = FormListaOperacionesAAutorizar.ObtenerInstancia();
                UtilUI.ObtenerInstancia().AbrirOTraerAlFrente(this, instancia);
            }
            catch
            {
                //Consumimos
            }
        }


        private void MostrarOperacionesRechazadas(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                }

                this.BringToFront();
                var instancia = FormListaOperaciones.ObtenerInstancia();
                UtilUI.ObtenerInstancia().AbrirOTraerAlFrente(this, instancia);
            }
            catch
            {
                //Consumimos
            }

        }
    }
}