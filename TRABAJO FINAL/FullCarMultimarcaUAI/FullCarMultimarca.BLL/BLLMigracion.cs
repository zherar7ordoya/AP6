using FullCarMultimarca.MPP;
using FullCarMultimarca.MPP.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.BLL
{
    public class BLLMigracion
    {
        private BLLMigracion()
        {
        }

        private static BLLMigracion _bllMigracion = null;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static BLLMigracion ObtenerInstancia()
        {
            if (_bllMigracion == null)
                _bllMigracion = new BLLMigracion();
            return _bllMigracion;
        }
        ~BLLMigracion()
        {
            _bllMigracion = null;
        }
      

        public void VerificarYActualizarBaseDatos()
        {
            MPPMigracion.ObtenerInstancia().VerificarYActualizarBaseDatos();
        }

    }
}
