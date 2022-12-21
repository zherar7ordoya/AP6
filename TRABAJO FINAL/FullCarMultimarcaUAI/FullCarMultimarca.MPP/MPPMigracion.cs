using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.DAL;
using FullCarMultimarca.Servicios;

namespace FullCarMultimarca.MPP
{
    /// <summary>
    /// Clase que brinda soporte a la creación y actualización de la base de datos (DataSet)
    /// </summary>
    public class MPPMigracion
    {
        private MPPMigracion()
        {
            _servicioMigracion = new ServicioMigracion();
            _datosFullCar = FullCarManejadorDatos.ObtenerInstancia();
            _datosLogs = LogManejadorDatos.ObtenerInstancia();
            _datosCatalogo = CatalogoManejadorDatos.ObtenerInstancia();
        }

        private static MPPMigracion _mppMigracion = null;
        private IServicioMigracion _servicioMigracion;
        private IManejadorDatos _datosFullCar;
        private IManejadorDatos _datosLogs;
        private IManejadorBackup _datosCatalogo;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static MPPMigracion ObtenerInstancia()
        {
            if (_mppMigracion == null)
                _mppMigracion = new MPPMigracion();
            return _mppMigracion;
        }
        ~MPPMigracion()
        {
            _mppMigracion = null;
            _servicioMigracion = null;
            _datosFullCar = null;
            _datosLogs = null;
            _datosCatalogo = null;
        }
     
        /// <summary>
        /// Si no existe la base de datos la crea y aplica las actualizaciones disponibles.
        /// </summary>
        public void VerificarYActualizarBaseDatos()
        {
            try
            {
                if (!_datosFullCar.ExisteBaseDatos())
                {
                    //Creamos la estructura de la base
                    ProcesarPrimerIngreso();
                }
                //Procesamos posibles actualizaciones
                ActualizarVersionBaseDatosFullCar();
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }

        private void ProcesarPrimerIngreso()
        {
            try
            {
                //Base de datos Full Car
                CrearBaseDatosFullCar();

                //Base de datos Logs
                CrearBaseDatosLogs();

                //Base de datos Catalogo
                DateTime fyh = DateTime.Now;
                string nombrePrimerBackup = $"{fyh:yyyyMMdd HHmmss}-FullCarMultimarca.xml";                
                CrearBaseDatosBackUps(nombrePrimerBackup, fyh);
                //Hacemos el primer backup
                _datosCatalogo.CrearBackup(nombrePrimerBackup);

            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }          
            
        }
        private void CrearBaseDatosFullCar()
        {
            try
            {
                if (!_datosFullCar.ExisteBaseDatos())
                {
                    var ds = _servicioMigracion.CrearBaseDatosFullCar();
                    _datosFullCar.GuardarDatos(ds);
                }
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
          
        }     
        private void CrearBaseDatosBackUps(string nombrePrimerBackup, DateTime fechaYHora)
        {
            try
            {
                if (!_datosCatalogo.ExisteBaseDatos())
                {
                    var ds = _servicioMigracion.
                        CrearBaseDatosBackup(nombrePrimerBackup, fechaYHora);
                    _datosCatalogo.GuardarDatos(ds);
                }
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
          
        }
        private void CrearBaseDatosLogs()
        {
            try
            {
                if (!_datosLogs.ExisteBaseDatos())
                {
                    var ds = _servicioMigracion.
                        CrearBaseDatosLogs();
                    _datosLogs.GuardarDatos(ds);
                }
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }

          
        }
        private void ActualizarVersionBaseDatosFullCar()
        {
            try
            {
                if (_datosFullCar.ExisteBaseDatos())
                {
                    var ds = _datosFullCar.ObtenerDatos();

                    _servicioMigracion.
                        ActualizarVersionFullCar(ds);
                    _datosFullCar.GuardarDatos(ds);
                }
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
          
        }       

    }
}
