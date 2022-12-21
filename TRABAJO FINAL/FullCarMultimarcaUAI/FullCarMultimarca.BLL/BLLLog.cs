using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE;
using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.MPP;
using FullCarMultimarca.MPP.Seguridad;
using FullCarMultimarca.Servicios;
using FullCarMultimarca.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.BLL
{
    /// <summary>
    /// BLL para obtener los logs del sistema
    /// </summary>
    public class BLLLog : ILogger
    {
        private BLLLog()
        {

        }

        private static BLLLog _bllLog = null;
      
        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static BLLLog ObtenerInstancia()
        {
            if (_bllLog == null)
                _bllLog = new BLLLog();
            return _bllLog;
        }
      
        ~BLLLog()
        {
            _bllLog = null;
        }

        public IList<VistaLog> ObtenerLogs(DateTime desde, DateTime hasta, string propiedad, string texto)
        {            
            return ConstruirVista(MPPLog.ObtenerInstancia().ObtenerLog(desde,hasta, propiedad, texto));
        }


        public void GenerarLog(string detalle, string usuario = default)
        {            
            Log log = new Log()
            {                
                Usuario = usuario ?? Ticket.UsuarioLogueado.Logon,
                Fecha = DateTime.Now,
                Operacion = detalle
            };

            MPPLog.ObtenerInstancia().GuardarLog(log);
        }
        public void GenerarLog(IAuditable auditable, string tipoAccion, string textoAdicional = default)
        {
            
            string operacion = $"{tipoAccion.ToUpper()} de {auditable.GetType().Name} - {auditable}";
            if (!String.IsNullOrWhiteSpace(textoAdicional))
            {
                operacion = $"{operacion}. {textoAdicional}";
            }

            Log log = new Log()
            {                
                Usuario = Ticket.UsuarioLogueado.Logon,
                Fecha = DateTime.Now,
                Operacion = operacion
            };

            MPPLog.ObtenerInstancia().GuardarLog(log);
        }

        public void ActualizarUsuarioLogon(string logonActual, string logonNuevo)
        {
            MPPLog.ObtenerInstancia().ActualizarUsuarioLogon(logonActual, logonNuevo);
        }

        private IList<VistaLog> ConstruirVista(IList<Log> source)
        {
            IList<VistaLog> lista = new List<VistaLog>();
            VistaLog destItem;
            foreach (var sourceItem in source)
            {
                destItem = new VistaLog();
                
                destItem.Fecha = sourceItem.Fecha;
                destItem.Usuario = sourceItem.Usuario;
                destItem.Operacion = sourceItem.Operacion;              


                lista.Add(destItem);
            }
            return lista;
        }


    }
}
