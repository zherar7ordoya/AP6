using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.DAL;
using FullCarMultimarca.Servicios.Excepciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.MPP
{    
    public class CatalogoManejadorDatos : IManejadorBackup
    {
        private CatalogoManejadorDatos()
        {
            _datos = AccesoXML.ObtenerInstancia();
        }
        ~CatalogoManejadorDatos()
        {
            _manejador = null;
            _datos = null;
        }

        private static IManejadorBackup _manejador = null;
        private IAccesoDatos _datos;

        public static IManejadorBackup ObtenerInstancia()
        {
            if (_manejador == null)
                _manejador = new CatalogoManejadorDatos();
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
                return _datos.ExisteBDCatalogo();
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
                    throw new BaseDeDatosNotFoundException("Catalogo");

                if (_dataSet == null || !_cachearDataSet)
                {
                    _dataSet = new DataSet();
                    _dataSet = _datos.ObtenerCatalogo();
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
                _datos.ActualizarCatalogo(ds);
            }
            catch
            {

                throw;
            }
        }
        public void CrearBackup(string nombreArchivo)
        {
            try
            {             
                _datos.CrearBackup(nombreArchivo);
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public void EliminarBackup(string nomberArchivo)
        {
            try
            {               
                _datos.EliminarBackup(nomberArchivo);                
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public void RestaurarBackup(string nombreArchivo)
        {
            try
            {
                _datos.RestaurarBackup(nombreArchivo);
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
    }
}
