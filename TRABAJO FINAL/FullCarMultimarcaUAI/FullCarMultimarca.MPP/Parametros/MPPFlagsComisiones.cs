using FullCarMultimarca.BE.Parametros;
using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.DAL;
using FullCarMultimarca.MPP.Base;
using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.MPP.Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.BE;

namespace FullCarMultimarca.MPP.Parametros
{
    public class MPPFlagsComisiones
    {
        private MPPFlagsComisiones()
        {
            _datos = FullCarManejadorDatos.ObtenerInstancia();
        }

        private static MPPFlagsComisiones _mppFlagsComisiones = null;
        private IManejadorDatos _datos;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static MPPFlagsComisiones ObtenerInstancia()
        {
            if (_mppFlagsComisiones == null)
                _mppFlagsComisiones = new MPPFlagsComisiones();
            return _mppFlagsComisiones;
        }
        ~MPPFlagsComisiones()
        {
            _mppFlagsComisiones = null;
            _datos = null;
        }      

        public FlagsComisiones Leer()
        {
            try
            {
                var ds = _datos.ObtenerDatos();                
                return HidratarObjeto(ds.Tables["FlagsEmpresa"].Rows[0]);
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }

        }
        public void Guardar(FlagsComisiones objeto)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                var dtFlags = ds.Tables["FlagsEmpresa"].Rows[0];
                if (dtFlags == null)
                    throw new NegocioException("No se encontraron los parámetros de la empresa");

                dtFlags["PorcentajeComisionN1"] = objeto.PorcentajeComisionN1;
                dtFlags["CantidadMinimaN2"] = objeto.CantidadMinimaN2;
                dtFlags["PorcentajeComisionN2"] = objeto.PorcentajeComisionN2;
                dtFlags["CantidadMinimaN3"] = objeto.CantidadMinimaN3;
                dtFlags["PorcentajeComisionN3"] = objeto.PorcentajeComisionN3;
                dtFlags["ImportePremioVolumen"] = objeto.ImportePremioVolumen;            


                _datos.GuardarDatos(ds);                                
                
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }

        internal FlagsComisiones HidratarObjeto(DataRow dr)
        {
            if (dr == null)
                return null;
            else
            {
                var f = new FlagsComisiones
                {

                    PorcentajeComisionN1 = Convert.ToDecimal(dr["PorcentajeComisionN1"]),
                    CantidadMinimaN2 = Convert.ToInt32(dr["CantidadMinimaN2"]),
                    PorcentajeComisionN2 = Convert.ToDecimal(dr["PorcentajeComisionN2"]),
                    CantidadMinimaN3 = Convert.ToInt32(dr["CantidadMinimaN3"]),
                    PorcentajeComisionN3 = Convert.ToDecimal(dr["PorcentajeComisionN3"]),
                    ImportePremioVolumen = Convert.ToDecimal(dr["ImportePremioVolumen"]),
 
                };              
                return f;
            }
        }
    }
}
