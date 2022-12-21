using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.DAL;
using FullCarMultimarca.MPP.Base;
using FullCarMultimarca.Abstracciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.BE.Parametros;
using FullCarMultimarca.BE;

namespace FullCarMultimarca.MPP.Parametros
{
    /// <summary>
    /// MPP para obtener los flags de seguridad del sistema
    /// </summary>
    public class MPPFlagsSeguridad
    {
        private MPPFlagsSeguridad()
        {
            _datos = FullCarManejadorDatos.ObtenerInstancia();
        }

        private static MPPFlagsSeguridad _mppFlagsSeguridad = null;
        private IManejadorDatos _datos;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static MPPFlagsSeguridad ObtenerInstancia()
        {
            if (_mppFlagsSeguridad == null)
                _mppFlagsSeguridad = new MPPFlagsSeguridad();
            return _mppFlagsSeguridad;
        }
        ~MPPFlagsSeguridad()
        {
            _mppFlagsSeguridad = null;
            _datos = null;
        }
       
        public FlagsSeguridad Leer()
        {
            try
            {
                var ds = _datos.ObtenerDatos();                
                return HidratarObjeto(ds.Tables["FlagsSeguridad"].Rows[0]);
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
           
        }
        public void Guardar(FlagsSeguridad objeto)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                var dtFlags = ds.Tables["FlagsSeguridad"].Rows[0];                
                if (dtFlags == null)
                    throw new NegocioException("No se encontraron los parámetros de seguridad");

                dtFlags["MinimoCaracteresPassword"] = objeto.MinimoCaracteresPassword;
                dtFlags["IntentosBloqueoPassword"] = objeto.IntentosBloqueoPassword;
                dtFlags["DiasVigenciaPassword"] = objeto.DiasVigenciaPassword;
                dtFlags["DebeContenerNumero"] = objeto.DebeContenerNumero;
                dtFlags["DebeContenerMayuscula"] = objeto.DebeContenerMayuscula;
                dtFlags["DebeContenerMinuscula"] = objeto.DebeContenerMinuscula;
                dtFlags["DebeContenerCaracterEspecial"] = objeto.DebeContenerCaracterEspecial;

                _datos.GuardarDatos(ds);
                                
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }

        internal FlagsSeguridad HidratarObjeto(DataRow dr)
        {
            if (dr == null)
                return null;
            else
            {
                return new FlagsSeguridad
                {

                    MinimoCaracteresPassword = Convert.ToInt32(dr["MinimoCaracteresPassword"]),
                    IntentosBloqueoPassword = Convert.ToInt32(dr["IntentosBloqueoPassword"]),
                    DiasVigenciaPassword = Convert.ToInt32(dr["DiasVigenciaPassword"]),
                    DebeContenerMayuscula = Convert.ToBoolean(dr["DebeContenerMayuscula"]),
                    DebeContenerCaracterEspecial = Convert.ToBoolean(dr["DebeContenerCaracterEspecial"]),
                    DebeContenerMinuscula = Convert.ToBoolean(dr["DebeContenerMinuscula"]),
                    DebeContenerNumero = Convert.ToBoolean(dr["DebeContenerNumero"])
                };
            }
        }
    }
}
