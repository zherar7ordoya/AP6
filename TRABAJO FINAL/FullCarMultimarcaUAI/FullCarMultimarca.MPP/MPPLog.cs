using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE;
using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.DAL;
using FullCarMultimarca.MPP.Base;
using FullCarMultimarca.MPP.Traductores;
using FullCarMultimarca.Servicios;
using FullCarMultimarca.Servicios.Excepciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.MPP
{
    /// <summary>
    /// MPP para obtener los Logs generados desde la Base de Datos
    /// </summary>
    public class MPPLog
    {
        private MPPLog()
        {
            _datos = LogManejadorDatos.ObtenerInstancia();
            _traductor = new TraductorLog();
        }

        private static MPPLog _mppLog = null;
        private IManejadorDatos _datos;
        private ITraductorEntidad _traductor;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static MPPLog ObtenerInstancia()
        {
            if (_mppLog == null)
                _mppLog = new MPPLog();
            return _mppLog;
        }
        ~MPPLog()
        {
            _mppLog = null;
            _datos = null;
        }

        public IList<Log> ObtenerLog(DateTime desde, DateTime hasta, string propiedad, string texto)
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();

                //Filtro
                string expression = $"Fecha >= '#{desde:dd/MM/yyyy 00:00:00}#' AND Fecha <= '#{hasta:dd/MM/yyyy 23:59:59}#'";                
                if (!String.IsNullOrWhiteSpace(texto))
                {
                    string campo = Util.ObtenerCampoDesdePropiedad(_traductor.DiccionarioEquivalencias, propiedad);
                    expression += $"{Util.AgregarOperadorAND(expression)} {campo} LIKE '%{Util.PrepararStringConsulta(texto)}%'";
                }

                DataRow[] drLogs = ds.Tables["Log"].Select(expression);                
                var lista = new List<Log>();
                foreach(DataRow dr in drLogs)
                {
                    lista.Add(HidratarObjeto(dr));
                }
                return lista.OrderByDescending(l => l.Fecha)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }      
        public void GuardarLog(Log log)
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();


                DataTable dtLog = ds.Tables["Log"];
                DataRow dr = dtLog.NewRow();
                dr["CodigoTransaccion"] = Guid.NewGuid();
                dr["Fecha"] = log.Fecha;
                dr["Usuario"] = log.Usuario;
                dr["Operacion"] = log.Operacion;
                dtLog.Rows.Add(dr);

                _datos.GuardarDatos(ds);
            }
            catch
            {
                throw new GuardarLogException();
            }
        }   
        //Metodo que modifica el logon del usuario en la base de logs cuando este se modifica
        public void ActualizarUsuarioLogon(string logonActual, string logonNuevo)
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();

                //Filtro
                string expression = $"Usuario = '{logonActual}'";
                DataRow[] drLogs = ds.Tables["Log"].Select(expression);                              
                foreach (DataRow dr in drLogs)
                    dr["Usuario"] = logonNuevo;

                _datos.GuardarDatos(ds);
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }

        internal Log HidratarObjeto(DataRow dr)
        {
            if (dr == null)
                return null;
            else
            {
                var log = new Log
                {                    
                    Fecha = Convert.ToDateTime(dr["Fecha"]),
                    Operacion = dr["Operacion"].ToString(),
                    Usuario = dr["Usuario"].ToString()
                };

                return log;
            }
        }

    }
}
