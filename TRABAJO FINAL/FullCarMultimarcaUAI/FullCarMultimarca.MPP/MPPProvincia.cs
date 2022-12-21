using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE;
using FullCarMultimarca.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.MPP
{
    public class MPPProvincia
    {

        private MPPProvincia()
        {
            _datos = FullCarManejadorDatos.ObtenerInstancia();
        }


        private static MPPProvincia _mppProvincia = null;
        private IManejadorDatos _datos;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static MPPProvincia ObtenerInstancia()
        {
            if (_mppProvincia == null)
                _mppProvincia = new MPPProvincia();
            return _mppProvincia;
        }
        ~MPPProvincia()
        {
            _mppProvincia = null;
            _datos = null;
        }

        public IList<Provincia> Obtener()
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();

                var lista = new List<Provincia>();
                foreach (DataRow dr in ds.Tables["Provincia"].Rows)
                {
                    lista.Add(HidratarObjeto(dr));
                }
                return lista.OrderBy(p => p.Nombre)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }

        }

        internal Provincia HidratarObjeto(DataRow dr)
        {
            if (dr == null)
                return null;
            else
            {
                var provincia = new Provincia
                {                  
                    Nombre = dr["Nombre"].ToString()
                };

                return provincia;
            }
        }
    }
}
