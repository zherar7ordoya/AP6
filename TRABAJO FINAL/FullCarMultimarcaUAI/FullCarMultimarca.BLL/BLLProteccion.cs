
using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.MPP;
using FullCarMultimarca.MPP.Seguridad;
using FullCarMultimarca.Servicios.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.BLL
{
    /// <summary>
    /// BLL para controlar la proteccion de los datos
    /// </summary>
    public class BLLProteccion
    {

        private BLLProteccion()
        {
            _logger = BLLLog.ObtenerInstancia();
        }

        private static BLLProteccion _bllProteccion = null;
        private ILogger _logger;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static BLLProteccion ObtenerInstancia()
        {
            if (_bllProteccion == null)
                _bllProteccion = new BLLProteccion();
            return _bllProteccion;
        }
        ~BLLProteccion()
        {
            _bllProteccion = null;
            _logger = null;
        }

        public void VerificarProteccionDeDatos()
        {
            try
            {
                MPPProteccion.ObtenerInstancia().VerificarProteccionDeDatos();
            }
            catch (BaseCorruptaException bcEx)
            {                
                _logger.GenerarLog($"Se verifió estado INCONSISTENTE de sistema en tablas: {string.Join(", ", bcEx.TablasCorruptas.ToArray())}.");                
                throw bcEx;
            }
            catch
            {
                throw;
            }
            
        }

    }
}
