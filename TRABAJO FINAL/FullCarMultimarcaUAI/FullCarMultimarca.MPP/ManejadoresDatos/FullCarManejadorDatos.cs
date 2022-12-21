using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.MPP
{
    public class FullCarManejadorDatos : IManejadorDatos
    {
        private FullCarManejadorDatos()
        {
            _datos = AccesoXML.ObtenerInstancia();
        }
        ~FullCarManejadorDatos()
        {
            _manejador = null;
            _datos = null;
        }

        private static IManejadorDatos _manejador = null;
        private IAccesoDatos _datos;
        
        public static IManejadorDatos ObtenerInstancia()
        {
            if (_manejador == null)
                _manejador = new FullCarManejadorDatos();
            return _manejador;
        }

        private DataSet _dataSet = null;        

        #region MANEJO NIVEL CACHE

        //false: el sistema funciona completamente en modo CONECTADO para letura y escritura.
        //true: el sistema funciona en modo DESCONECTADO para la lectura (solo se lee ante la primer referencia) y en modo CONECTADO para la escritura (se mantiene la base de datos xml siempre actualizada)
        private bool _cachearDataSet = true;      

        #endregion


        public bool ExisteBaseDatos()
        {
            try
            {
                return _datos.ExisteBDFullCar();
            }
            catch
            {
                throw;
            }
        }
        public DataSet ObtenerDatos()
        {
            try
            {
                if (!_datos.ExisteBDFullCar())
                    throw new BaseDeDatosNotFoundException("FullCar");

                if (_dataSet == null || !_cachearDataSet)
                {
                    _dataSet = new DataSet();
                    _dataSet = _datos.ObtenerFullCar();
                }
                return _dataSet;
            }
            catch
            {
                throw;
            }
        }
        public void GuardarDatos(DataSet ds)
        {
            try
            {
                _datos.ActualizarFullCar(ds);
            }
            catch
            {

                throw;
            }
        }

       
    }
}
