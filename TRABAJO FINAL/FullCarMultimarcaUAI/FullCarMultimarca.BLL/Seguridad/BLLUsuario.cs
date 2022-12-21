using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullCarMultimarca.BE.Seguridad;

using FullCarMultimarca.MPP.Seguridad;
using System.Text.RegularExpressions;
using FullCarMultimarca.Servicios;
using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.BE.Parametros;
using FullCarMultimarca.BE;
using FullCarMultimarca.BLL.Parametros;
using FullCarMultimarca.Vistas;

namespace FullCarMultimarca.BLL.Seguridad
{
    /// <summary>
    /// BLL para gestionar ABMC de usuarios, logins, intentos de conexión, etc.
    /// </summary>
    public class BLLUsuario : IValidable<Usuario>
    {
        private BLLUsuario()
        {            
            CargarFlagsSeguirdad();
            _abmc = MPPUsuario.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
            _servicioEncriptacion = new ServicioEncriptacion();
            _servicioValidacion = new ServicioValidacion();
            _servicioCorreo = new ServicioCorreo();
            _servicioAsync = new ServicioTransfAsync();
        }

        private FlagsSeguridad FlagsSeguridad { get; set; } = null;


        private static BLLUsuario _bllUsuario = null;
        

        private IMapping<Usuario> _abmc;
        private ILogger _logger;
        private IServicioEncriptacion _servicioEncriptacion;
        private IServicioValidacion _servicioValidacion;
        private IServicioCorreo _servicioCorreo;
        private IServicioTransfAsync _servicioAsync;
        

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static BLLUsuario ObtenerInstancia()
        {
            if (_bllUsuario == null)
                _bllUsuario = new BLLUsuario();
            return _bllUsuario;
        }
        ~BLLUsuario()
        {
            _bllUsuario = null;
            _logger = null;
            _servicioEncriptacion = null;
            _servicioValidacion = null;
            _servicioCorreo = null;
            _servicioAsync = null;
        }

        #region IMPLEMENTACIÓN IVALIDABLE

        public string MensajeError { get; internal set; }
        public bool EsValido(Usuario objeto)
        {
            MensajeError = "";            

            if(objeto.Legajo == null || objeto.Legajo <= 0)
                MensajeError += "- El legajo debe ser un número válido mayor a cero\n";
            if (String.IsNullOrWhiteSpace(objeto.Logon) ||objeto.Logon.Length < 3)
                MensajeError += "- Debe indicar el logon (al menos 3 posiciones)\n";
            if (string.IsNullOrWhiteSpace(objeto.Nombre))
                MensajeError += "- Debe indicar el nombre\n";
            if (string.IsNullOrWhiteSpace(objeto.Apellido))
                MensajeError += "- Debe indicar el apellido\n";
            if(string.IsNullOrWhiteSpace(objeto.Email))
                MensajeError += "- Debe indicar el e-mail\n";
            else if (!_servicioValidacion.ValidarPatronString(objeto.Email,Util.PatronValidacionEmail))
                MensajeError += "- El formato del e-mail es inválido\n";
            if (String.IsNullOrWhiteSpace(objeto.Password))
                MensajeError += "- Debe indicar el password\n";
            //La unida medida de seguiridad que tomamos al dar de alta un usuario o restablecer la clave es respetar el minimo de largo, siempre el usuario debería generar una nueva luego
            else if (objeto.Password.Length < FlagsSeguridad.MinimoCaracteresPassword) 
                MensajeError += $"- El password debe tener al menos {FlagsSeguridad.MinimoCaracteresPassword} posiciones\n";


            return String.IsNullOrEmpty(MensajeError);
        }

        #endregion

        #region GESTION DE LOGUEO
        
        private static Dictionary<string, int> _intentosUsuario = new Dictionary<string, int>();

        public static void ResetIntentosUsuario()
        {
            _intentosUsuario.Clear();
        }
        private void AgergarIntento(string logon)
        {
            if (_intentosUsuario.ContainsKey(logon))
            {
                var valor = _intentosUsuario[logon];
                _intentosUsuario[logon] = valor - 1;
            }                
            else
                _intentosUsuario.Add(logon,FlagsSeguridad.IntentosBloqueoPassword-1);
        }
        private bool IntentosAgotados(string logon)
        {
            if (_intentosUsuario.ContainsKey(logon) && _intentosUsuario[logon] <= 0)
                return true;
            else
                return false;
        }
        private int ObtenerIntentos(string logon)
        {
            if (_intentosUsuario.ContainsKey(logon))
                return _intentosUsuario[logon];
            else
                return FlagsSeguridad.IntentosBloqueoPassword;
        }

        public bool ValidarUsuario(Usuario bEUsuario)
        {           

            Usuario usr = _abmc.Leer(bEUsuario);
            if (usr != null)
            {
                if (!usr.Activo)
                    throw new NegocioException("El usuario está deshabilitado.");
                if (usr.Bloqueado)
                    throw new UsuarioBloqueadoException("El usuario está bloqueado, debe contactar al administrador.");
                string passEncripted = _servicioEncriptacion.EncriptarSHA(bEUsuario.Password);
                if (!passEncripted.Equals(usr.Password))
                {                    
                    if (FlagsSeguridad.IntentosBloqueoPassword <= 0) //Si el valor es cero o inferior, no se realiza bloqueo por demasiados intentos.
                        throw new NegocioException("Contraseña incorrecta.");

                    AgergarIntento(usr.Logon);
                    if (IntentosAgotados(usr.Logon))
                    {
                        usr.Bloqueado = true;
                        _abmc.Modificar(usr);
                        _logger.GenerarLog($"Usuario {usr.Logon} BLOQUEADO", usr.Logon);
                        throw new UsuarioBloqueadoException("Se agotaron los intentos. El usuario ha sido bloqueado");
                    }
                    else
                    {
                        throw new NegocioException($"Contraseña incorrecta. Quedan {ObtenerIntentos(usr.Logon)} intentos.");
                    }
                }
                if (!usr.FechaUltimoCambioPassword.HasValue)
                    throw new UsuarioPrimerIngresoException ("Debe modificar la clave actual.");
                if (FlagsSeguridad.DiasVigenciaPassword > 0 &&
                    usr.FechaUltimoCambioPassword.Value.AddDays(FlagsSeguridad.DiasVigenciaPassword).Date < DateTime.Today.Date)
                    throw new UsuarioClaveVencidaException("Su contraseña ha expirado, indique una nueva a continuación");

                Ticket.UsuarioLogueado = usr;              
            }
            else
            {
                throw new NegocioException("Usuario inexistente");
            }
            return Ticket.UsuarioLogueado != null;
        }

        #endregion

        public void ModificarClave(string claveActual, string nuevaClave, string repeClave)
        {
            ModificarClave("", claveActual, nuevaClave, repeClave);
        }
        public void ModificarClave(string logon, string claveActual, string nuevaClave, string repeClave)
        {
            Usuario usuario;
            if(!string.IsNullOrWhiteSpace(logon))            
                usuario = _abmc.Leer(new Usuario { Logon = logon });
            else
                usuario = Ticket.UsuarioLogueado;            
                
            if (usuario == null)
                throw new NegocioException("El usuario que intenta modificar no fue encontrado.");
            if (!usuario.Activo)
                throw new NegocioException("El usuario está deshabilitado.");
            if (usuario.Bloqueado)
                throw new UsuarioBloqueadoException("El usuario está bloqueado, debe contactar al administrador.");

            string passEncripted = _servicioEncriptacion.EncriptarSHA(claveActual);
            if (!passEncripted.Equals(usuario.Password))
                throw new NegocioException("La clave actual NO coincide.");

            if(claveActual.Equals(nuevaClave))
                throw new NegocioException("La nueva clave no puede ser igual a la ultima utilizada.");

            VerificarSeguridadClave(usuario,nuevaClave);
           
            if (!nuevaClave.Equals(repeClave))
                throw new NegocioException($"La nueva clave y su repetición no coinciden.");

            usuario.Password = _servicioEncriptacion.EncriptarSHA(nuevaClave);
            usuario.FechaUltimoCambioPassword = DateTime.Now;

            _abmc.Modificar(usuario);
        }
        public void ModificarPalabraClave(string claveActual, string palabraClave, string respuestaClave)
        {
            ModificarPalabraClave(claveActual, palabraClave, respuestaClave);
        }
        public void ModificarPalabraClave(string logon, string claveActual, string palabraClave, string respuestaClave)
        {            
            Usuario usuario;
            if (!string.IsNullOrWhiteSpace(logon))
                usuario = _abmc.Leer(new Usuario { Logon = logon });
            else
                usuario = Ticket.UsuarioLogueado;
            if (usuario == null)
                throw new NegocioException("El usuario que intenta modificar no fue encontrado.");
            if (!usuario.Activo)
                throw new NegocioException("El usuario está deshabilitado.");
            if (usuario.Bloqueado)
                throw new UsuarioBloqueadoException("El usuario está bloqueado, debe contactar al administrador.");

            string passEncripted = _servicioEncriptacion.EncriptarSHA(claveActual);
            if (!passEncripted.Equals(usuario.Password))
                throw new NegocioException("La clave actual NO coincide.");

            if (string.IsNullOrWhiteSpace(palabraClave) || palabraClave.Length < 3)
                throw new NegocioException("Debe indicar una palabra o texto clave válido mayor o igual a 3 caractéres.");
            if (string.IsNullOrWhiteSpace(respuestaClave) || respuestaClave.Length < 3)
                throw new NegocioException("Debe indicar una respuesta válida mayor o igual a 3 caractéres.");

            //Encripamos respuesta para ocularla en la base de datos
            string respEncriped = _servicioEncriptacion.EncriptarSHA(respuestaClave.ToLower().Trim());

            usuario.PalabraClave = palabraClave;
            usuario.RespuestaClave = respEncriped;

            _abmc.Modificar(usuario);
        }
        public void RestablecerClave(string logon, string respuestaClave, string nuevaClave, string repeClave)
        {
            Usuario usuario = _abmc.Leer(new Usuario { Logon = logon });            
            if (usuario == null)
                throw new NegocioException("El usuario que intenta modificar no fue encontrado.");
            if (!usuario.Activo)
                throw new NegocioException("El usuario está deshabilitado.");
            if (usuario.Bloqueado)
                throw new UsuarioBloqueadoException("El usuario está bloqueado, debe contactar al administrador.");

            string respuestaEncripted = _servicioEncriptacion.EncriptarSHA(respuestaClave.ToLower().Trim());
            if (!respuestaEncripted.Equals(usuario.RespuestaClave))
                throw new NegocioException("La respuesta clave NO coincide con la proporcionada por ud.");

            string nuevaClaveEncripted = _servicioEncriptacion.EncriptarSHA(nuevaClave);

            if (nuevaClaveEncripted.Equals(usuario.Password))
                throw new NegocioException("La nueva clave es igual a su clave actual.");

            VerificarSeguridadClave(usuario, nuevaClave);

            if (!nuevaClave.Equals(repeClave))
                throw new NegocioException($"La nueva clave y su repetición no coinciden.");

            usuario.Password = nuevaClaveEncripted;
            usuario.FechaUltimoCambioPassword = DateTime.Now;

            _abmc.Modificar(usuario);
        }
        public void EnviarCorreoDeRestauracion(Usuario usr)
        {
            if (String.IsNullOrWhiteSpace(usr.Email))
                throw new NegocioException("No se ha indicado el correo corporativo para el usuario.");

            string claveRandom = GenerarClaveRandom(usr);

            string subject = "FULLCAR - Restauración clave";
            string body = $"Su clave temporaria es: {claveRandom}\n\n";
            body += "Esta clave NO vence pero el sistema solicitará cambiarla en su próximo ingreso.\n";
            body += "Si usted NO realizó esta solicitud contacte al administrador del sistema.";

            //El envío se realiza de forma asincrona
            _servicioAsync.EjectutarAsincronico(
                async () => await _servicioCorreo.EnviarEmailAsync(usr.Email, subject, body));            

        }

        public Usuario Leer(Usuario logon)
        {
            Usuario usr = _abmc.Leer(logon);
            if (usr == null)
                throw new NegocioException("No se encontró el usuario");
            return usr;
        }                
        public IList<VistaUsuario> Buscar(string propiedad, string texto, bool incluirInactivos)
        {
            return ConstruirVista(_abmc.Buscar(propiedad, texto, incluirInactivos));
        }
        public Usuario ObtenerUsuarioParaRecuperoDeClave(Usuario logon)
        {
            var usr = Leer(logon);
            if (usr.Bloqueado)
                throw new NegocioException("El usuario está bloqueado, no puede ejecutar esta acción.");
            if (!usr.Activo)
                throw new NegocioException("El usuario está inactivo, no puede ejecutar esta acción.");
            return usr;
        }
        
        public void Agregar(Usuario beUsuario)
        {
            if (!EsValido(beUsuario))
                throw new NegocioException($"El usuario que intenta guardar es inválido.\n{MensajeError}");            
            if (_abmc.Existe(beUsuario))
                throw new NegocioException($"El logon de usuario que intenta agregar ya existe");
            if (_abmc.ObtenerTodos().Any(u => u.Legajo == beUsuario.Legajo))
                throw new NegocioException($"El legajo de usuario que intenta agregar ya existe");

            beUsuario.Password = _servicioEncriptacion.EncriptarSHA(beUsuario.Password);
            _abmc.Agregar(beUsuario);

            _logger.GenerarLog(beUsuario, Util.Log_Alta);
        }
        public void Modificar(Usuario beUsuario)
        {         
            if (!EsValido(beUsuario))
                throw new NegocioException($"El usuario que intenta guardar es inválido.\n{MensajeError}");
            if (_abmc.Existe(beUsuario))
                throw new NegocioException($"El logon de usuario que intenta modificar ya existe");

            //Obtengo el usuario de la base para notificar si se está modificando el Logon
            var usrLeido = _abmc.ObtenerTodos().FirstOrDefault(u => u.Legajo == beUsuario.Legajo);
            string logonActual = usrLeido.Logon;
            
            _abmc.Modificar(beUsuario);          

            if (beUsuario.Equals(Ticket.UsuarioLogueado))
                Ticket.UsuarioLogueado = beUsuario; //Actualizo la información del usuario logueado.

            _logger.GenerarLog(beUsuario, Util.Log_Modificacion);

            //Si se modificó el Logon debemos actualizarlo en la base de logs.
            //La base de logs se decidió poner a parte para no perder trazabilidad ante una restaración de la base FullCar.
            if (logonActual.CompareTo(beUsuario.Logon) != 0)
                (_logger as BLLLog).ActualizarUsuarioLogon(logonActual, beUsuario.Logon);

        }
        public void Eliminar(Usuario beUsuario)
        {
            if (beUsuario.Equals(Ticket.UsuarioLogueado))
                throw new NegocioException("No puede eliminar al usuario logueado.");

            if (_abmc.TieneObjetosDependientes(beUsuario))
                throw new NegocioException("El usuario que intenta eliminar tiene operaciones asociadas.\nNo puede eliminar.");

            _abmc.Eliminar(beUsuario);

            _logger.GenerarLog(beUsuario, Util.Log_Baja);
        }       

        public void DesbloquearUsuario(Usuario bEUsuario)
        {
            var usr = _abmc.Leer(bEUsuario);
            if (usr == null)
                throw new NegocioException("No se encontró el usuario");
            usr.Bloqueado = false;
            _abmc.Modificar(usr);
            _logger.GenerarLog($"Usuario {bEUsuario.Logon} DESBLOQUEADO");
        }
        public string GenerarClaveRandom(Usuario beUsuario)
        {
            string nuevaClave = Util.RandomString(FlagsSeguridad.MinimoCaracteresPassword);
            beUsuario.Password = _servicioEncriptacion.EncriptarSHA(nuevaClave);
            beUsuario.FechaUltimoCambioPassword = null;
            _abmc.Modificar(beUsuario);            
            return nuevaClave;
        }

        private void CargarFlagsSeguirdad()
        {
            FlagsSeguridad = BLLFlagsSeguridad.ObtenerInstancia().Leer();
        }               
        private void VerificarSeguridadClave(Usuario usr, string clave)
        {
            //Validamos seguridad de la clave nueva
            if (string.IsNullOrWhiteSpace(clave))
                throw new NegocioException("La nueva clave no puede estar vacía");
            if (clave.Length < FlagsSeguridad.MinimoCaracteresPassword)
                throw new NegocioException($"La nueva clave debe contener al menos {FlagsSeguridad.MinimoCaracteresPassword} caracteres");

            string patron = @"\s{1,}";
            if(Regex.IsMatch(clave, patron))
                throw new NegocioException("La nueva clave no puede contener espacios");

            if(clave.ToLower().Contains(usr.Nombre.ToLower()) 
                || clave.ToLower().Contains(usr.Apellido.ToLower()) 
                || clave.ToLower().Contains(usr.Logon.ToLower()))
                throw new NegocioException("La nueva clave no puede contener datos de su usuario como Nombre, Apellido y/o Logon.");

            patron = @"\d{1,}";
            if (FlagsSeguridad.DebeContenerNumero && !Regex.IsMatch(clave,patron))
                throw new NegocioException("La nueva clave debe contener al menos un numero.");

            if(FlagsSeguridad.DebeContenerMayuscula && !clave.Any(x => Char.IsUpper(x)))
                throw new NegocioException("La nueva clave debe contener al menos una mayúscula.");

            if (FlagsSeguridad.DebeContenerMinuscula && !clave.Any(x => Char.IsLower(x)))
                throw new NegocioException("La nueva clave debe contener al menos una minúscula.");

            patron = @"[@#$%&-+=()¡!¿?]{1,}";
            string posiblesCaracteres = "@, #, $, %, &, -, +, =, (, ), ¡, !, ¿, ?";
            if (FlagsSeguridad.DebeContenerCaracterEspecial && !Regex.IsMatch(clave, patron))
                throw new NegocioException($"La nueva clave debe contener al menos un caractér especial.\nSe espera al menos uno de los siguientes caractéres: {posiblesCaracteres}");


        }

        private IList<VistaUsuario> ConstruirVista(IList<Usuario> source)
        {
            IList<VistaUsuario> lista = new List<VistaUsuario>();
            VistaUsuario destItem;
            foreach (var sourceItem in source)
            {
                destItem = new VistaUsuario();
                
                destItem.Logon = sourceItem.Logon;
                destItem.Nombre = sourceItem.Nombre;
                destItem.Apellido = sourceItem.Apellido;
                destItem.Bloqueado = sourceItem.Bloqueado;
                destItem.Activo = sourceItem.Activo;
                destItem.FechaUltimoCambioPassword = sourceItem.FechaUltimoCambioPassword;
                destItem.Email = sourceItem.Email;
                destItem.Permiso = sourceItem.Permiso?.ToString();

                lista.Add(destItem);
            }
            return lista;
        }
    }
}
