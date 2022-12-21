using FullCarMultimarca.BE;
using FullCarMultimarca.MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.BLL
{
    public class BLLProvincia
    {

        private BLLProvincia()
        {

        }


        private static BLLProvincia _bllProvincia = null;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static BLLProvincia ObtenerInstancia()
        {
            if (_bllProvincia == null)
                _bllProvincia = new BLLProvincia();
            return _bllProvincia;
        }
        ~BLLProvincia()
        {
            _bllProvincia = null;
        }

        public IList<Provincia> Obtener()
        {
            return MPPProvincia.ObtenerInstancia().Obtener();
        }
    }
}
