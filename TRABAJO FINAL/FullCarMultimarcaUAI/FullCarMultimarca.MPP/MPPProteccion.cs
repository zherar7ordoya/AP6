using FullCarMultimarca.DAL;
using FullCarMultimarca.MPP.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullCarMultimarca.BE.Seguridad;
using System.Collections;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.BE;
using FullCarMultimarca.MPP.Seguridad;
using FullCarMultimarca.MPP.Gestion;
using FullCarMultimarca.MPP.Ventas;
using FullCarMultimarca.MPP.Liquidaciones;
using FullCarMultimarca.Abstracciones;

namespace FullCarMultimarca.MPP
{
    public class MPPProteccion
    {
        private MPPProteccion()
        {
            _datos = FullCarManejadorDatos.ObtenerInstancia();
        }

        private static MPPProteccion _mppProteccion = null;
        private IManejadorDatos _datos;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static MPPProteccion ObtenerInstancia()
        {
            if (_mppProteccion == null)
                _mppProteccion = new MPPProteccion();
            return _mppProteccion;
        }
        ~MPPProteccion()
        {
            _mppProteccion = null;
            _datos = null;
        }

        public void VerificarProteccionDeDatos()
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();

                //Se revisa tabla por tabla que ya sabemos esta protegida buscando inconsistencias

                //Obtenemos el table de proteccion                
                List<string> tablasCorruptas = new List<string>();

                //Verificamos Usuario
                VerificarProteccion(MPPUsuario.ObtenerInstancia(), ds, "Usuario", tablasCorruptas);
                //Verificamos Unindad
                VerificarProteccion(MPPUnidad.ObtenerInstancia(),  ds, "Unidad",  tablasCorruptas);
                //Verificamos Operacion                
                VerificarProteccion(MPPOperacion.ObtenerInstancia(), ds, "Operacion", tablasCorruptas);
                //Verificar Proteccion Liquidacion
                VerificarProteccion(MPPLiquidacion.ObtenerInstancia(), ds, "LiquidacionVendedor", tablasCorruptas);

                //Si hay al menos una tabla corrupta devolvemos error especifico para proceder
                if (tablasCorruptas.Count > 0)
                {                                     
                    throw new BaseCorruptaException(tablasCorruptas);
                }
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }     

        private void VerificarProteccion(ProteccionBase mppProtegida, DataSet ds, 
            string tabla, List<string> tablasCorruptas)
        {
            DataTable dtProteccion = ds.Tables["ProteccionDatos"];
            DataRow drProteccion = dtProteccion.Select($"Tabla = '{tabla}'").FirstOrDefault();
            DataTable dtProtegida = ds.Tables[tabla];            

            string actualHashTabla = mppProtegida.CrearHashTabla(dtProtegida);
            string ultimoHashTabla = drProteccion["CodigoHash"].ToString();
            
            if (!String.IsNullOrWhiteSpace(ultimoHashTabla)
                && !actualHashTabla.Equals(ultimoHashTabla))
                tablasCorruptas.Add(tabla);
            else
            {
                foreach (DataRow drProtegida in dtProtegida.Rows)
                {
                    actualHashTabla = mppProtegida.CrearHashRegistro(drProtegida);
                    ultimoHashTabla = drProtegida["CodigoHash"].ToString();

                    if (!actualHashTabla.Equals(ultimoHashTabla))
                    {
                        tablasCorruptas.Add(tabla);
                        break;
                    }

                }
            }
        }

    }
}
