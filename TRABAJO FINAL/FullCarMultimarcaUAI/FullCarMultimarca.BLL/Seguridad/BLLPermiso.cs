
using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.MPP.Seguridad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.Servicios.Extensiones;

namespace FullCarMultimarca.BLL.Seguridad
{
    public class BLLPermiso : IValidable<Permiso>
    {
        private BLLPermiso()
        {
            _abmc = MPPPermiso.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
        }


        private static BLLPermiso _bllPermiso;

        private IMappingAsignable<Permiso> _abmc;
        private ILogger _logger;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static BLLPermiso ObtenerInstancia()
        {
            if (_bllPermiso == null)
                _bllPermiso = new BLLPermiso();
            return _bllPermiso;
        }
        ~BLLPermiso()
        {
            _bllPermiso = null;
            _abmc = null;
            _logger = null;
        }

        #region IMPLEMENTACIÓN IVALIDABLE

        public string MensajeError { get; internal set; }
        public bool EsValido(Permiso objeto)
        {
            MensajeError = "";

            if (String.IsNullOrWhiteSpace(objeto.Codigo))
                MensajeError += "- El código no puede estar vacío";
            if (string.IsNullOrWhiteSpace(objeto.Descripcion))
                MensajeError += "- La descripción no puede estar vacía";


            return String.IsNullOrEmpty(MensajeError);
        }

        #endregion

        public IList<Permiso> ObtenerPermisosDisponibles()
        {
            return _abmc.ObtenerTodos();
        }
        /// <summary>
        /// Solo se obtiene el primer nivel para armar el arbol de permisos y si suma o resta
        /// </summary>
        /// <param name="codigoPermisoCompuesto"></param>
        /// <returns></returns>
        public IList<Permiso> ObtenerEstructuraPermisos(string codigoPermisoCompuesto = "")
        {            
            return _abmc.Buscar(nameof(Permiso.Codigo).ObtenerFullNameMasPropiedad<Permiso>(), codigoPermisoCompuesto);
        }
        public IList<Permiso> ObtenerTodosLosPermisosParaUsuario(Usuario usr)
        {
            List<Permiso> permisos = new List<Permiso>();
            if (usr == null || usr.Permiso == null)
                return permisos;
            else
            {                
                LlenarPermisosRecursivo(permisos, usr.Permiso.Codigo, new ArrayList(), false);              
                

                //Neteamos los permisos para determinar cuales tiene finalmente.
                var netoPermisos = permisos.GroupBy(p => p)
                    .Select(grp => new
                    {
                        Clave = grp.Key,
                        Valor = grp.Sum(p => p.Otorgado ? 1 : -1)
                    });                   

                //Llenamos una lista plana de permisos concedidos siempre y cuando el neto sea mayor a cero
                List<Permiso> permisosOtorgados = new List<Permiso>();
                foreach(var grp in netoPermisos)
                {
                    if (grp.Valor > 0)
                        permisosOtorgados.Add(grp.Clave);
                }

                //Devolvemos lista plana con los permisos concedidos
                return permisosOtorgados;
            }
        }
        /// <summary>
        /// Algoritmo recursivo para la generación de permisos otorgados a un usuario
        /// </summary>       
        private void LlenarPermisosRecursivo(List<Permiso> permisos, string codigoPermiso, ArrayList arbolCodigos, bool denegar)
        {
            if (!arbolCodigos.Contains(codigoPermiso)) //Evia el abrazo de oso; si el codigo de permiso a recorrer ya se encuentra en el arbol es porque hay una referencia circular, ergo, se ignora.
            {
                arbolCodigos.Add(codigoPermiso);
                foreach (Permiso p in _abmc.Buscar(nameof(Permiso.Codigo).ObtenerFullNameMasPropiedad<Permiso>(), codigoPermiso)[0].ObtenerPermisos())
                {
                    if (denegar) //Si el compuesto llamador está denegado (es decir no otorgado) se denegan todos los permisos asociados.
                        p.Otorgado = false;                   
                    if (p is PermisoCompuesto)
                    {
                        denegar = !p.Otorgado;
                        LlenarPermisosRecursivo(permisos, p.Codigo, arbolCodigos, denegar);
                    }
                    else
                        permisos.Add(p);
                }
                arbolCodigos.Remove(codigoPermiso);
            }
        }

        public void Agregar(Permiso permiso)
        {
            if (!EsValido(permiso))
                throw new NegocioException($"El permiso que intenta agregar es inválido.\n{MensajeError}");
            if(_abmc.Existe(permiso))
                throw new NegocioException($"El código de permiso que intenta agregar ya existe.");
            _abmc.Agregar(permiso);

            _logger.GenerarLog(permiso, Util.Log_Alta);
        }
        public void Modificar(Permiso permiso)
        {
            if (!EsValido(permiso))
                throw new NegocioException($"El permiso que intenta modificar es inválido.\n{MensajeError}");

            _abmc.Modificar(permiso);

            _logger.GenerarLog(permiso, Util.Log_Modificacion);
        }
        public void Eliminar(Permiso permiso)
        {
            //Para eliminar primero revisamos que el permiso no tenga dependencias.
            //Es decir que no haya usuarios que tengan el permiso asignado.
            if (_abmc.TieneObjetosDependientes(permiso))
                throw new NegocioException("El permiso que intenta eliminar tiene usuarios asignados.\nDebe desasignar previamente.");

            _abmc.Eliminar(permiso);

            _logger.GenerarLog(permiso, Util.Log_Baja);
        }      
        
        public void AsignarPermiso(Permiso padre, Permiso hijo)
        {            
            if (!(padre is PermisoCompuesto))
                throw new NegocioException("No puede asignar un permiso a un permiso simple.");

            if(_abmc.ExisteAsignacion(padre,hijo))
                throw new NegocioException("La asignación de permiso ya existe.");

            if (padre.Codigo.Equals(hijo.Codigo))
                throw new NegocioException("No puede asignarle el mismo permiso a si mismo.");

            _abmc.Asignar(padre, hijo);
            padre.ObtenerPermisos().Add(hijo);
            _logger.GenerarLog($"Composición del permiso {padre} modificada.");
            
        }
        public void DesasignarPermiso(Permiso padre, Permiso hijo)
        {
            if (!(padre is PermisoCompuesto))
                throw new NegocioException("No puede desasignar un permiso de un permiso simple.");

            if (!_abmc.ExisteAsignacion(padre, hijo))
                throw new NegocioException("La asignación de permiso no existe.");

            _abmc.Desasignar(padre, hijo);
            padre.ObtenerPermisos().Remove(hijo);
            _logger.GenerarLog($"Composición del permiso {padre} modificada.");
        }
        public void ActualizarAsignacion(Permiso padre, Permiso hijo)
        {
            if (!(padre is PermisoCompuesto))
                throw new NegocioException("No puede actualizar una asignación de un permiso simple.");

            if (!_abmc.ExisteAsignacion(padre, hijo))
                throw new NegocioException("La asignación de permiso no existe.");       

            _abmc.ActualizarAsignacion(padre, hijo);

            _logger.GenerarLog($"Composición del permiso {padre} modificada.");
        }

    }
}
