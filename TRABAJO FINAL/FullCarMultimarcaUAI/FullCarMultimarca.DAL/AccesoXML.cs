using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.DAL
{
    public class AccesoXML : IAccesoDatos
    {
        private AccesoXML()
        {

        }
        ~AccesoXML()
        {
            _acceso = null;          
        }

        private static AccesoXML _acceso = null;
        public static AccesoXML ObtenerInstancia()
        {
            if (_acceso == null)
                _acceso = new AccesoXML();
            return _acceso;
        }     


        #region CHECKEO DE EXISTENCIA DE LA BD

        public bool ExisteBDFullCar()
        {
            try
            {
                return File.Exists(ReferenciasBD.BaseDatosFullCar);
            }
            catch
            {
                throw;
            }
        }
        public bool ExisteBDCatalogo()
        {
            try
            {
                return File.Exists(ReferenciasBD.BaseDatosBackups);
            }
            catch
            {
                throw;
            }
        }
        public bool ExisteBDLogs()
        {
            try
            {
                return File.Exists(ReferenciasBD.BaseDatosLogs);
            }
            catch
            {
                throw;
            }
        }


        #endregion

        #region LECTURA XML

        public DataSet ObtenerFullCar()
        {
            try
            {
                if (!ExisteBDFullCar())
                    throw new FileNotFoundException("No se encontró la base de datos FullCar");

                DataSet ds = new DataSet();
                ds.ReadXml(ReferenciasBD.BaseDatosFullCar, XmlReadMode.Auto);
                return ds;
            }
            catch
            {
                throw;
            }            
        }
        public DataSet ObtenerCatalogo()
        {

            try
            {
                if (!ExisteBDCatalogo())
                    throw new FileNotFoundException("No se encontró la base de datos del Catálogo");

                DataSet ds = new DataSet();
                ds.ReadXml(ReferenciasBD.BaseDatosBackups,XmlReadMode.Auto);
                return ds;
            }
            catch
            {

                throw;
            }
        }
        public DataSet ObtenerLogs()
        {
            try
            {
                if (!ExisteBDLogs())
                    throw new FileNotFoundException("No se encontró la base de datos de Logs");

                DataSet ds = new DataSet();
                ds.ReadXml(ReferenciasBD.BaseDatosLogs, XmlReadMode.Auto);
                return ds;
            }
            catch
            {

                throw;
            }            
        }
        #endregion

        #region ESCRITURA XML

        public void ActualizarFullCar(DataSet ds)
        {
            try
            {
                ds.WriteXml(ReferenciasBD.BaseDatosFullCar, XmlWriteMode.WriteSchema);
            }
            catch
            {

                throw;
            }            
        }
        public void ActualizarCatalogo(DataSet ds)
        {
            try
            {               
                ds.WriteXml(ReferenciasBD.BaseDatosBackups, XmlWriteMode.WriteSchema);
            }
            catch
            {

                throw;
            }            
        }
        public void ActualizarLogs(DataSet ds)
        {
            try
            {               
                ds.WriteXml(ReferenciasBD.BaseDatosLogs, XmlWriteMode.WriteSchema);
            }
            catch
            {
                throw;
            }
            
        }

        #endregion

        #region GESTION ARCHIVOS BACKUP

        public void CrearBackup(string nombreArchivoBackup)
        {
            try
            {
                if (!Directory.Exists(ReferenciasBD.NombreCarpetaBackUp))
                    throw new FileNotFoundException("La carpeta especificada para los backups NO existe.");

                File.Copy(ReferenciasBD.BaseDatosFullCar, Path.Combine(ReferenciasBD.NombreCarpetaBackUp, nombreArchivoBackup), true);
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("No se encontró el archivo a partir de cual crear el backup.");
            }
            catch
            {
                throw;
            }
        }
        public void EliminarBackup(string nombreArchivoBackup)
        {
            try
            {
                if (Directory.Exists(ReferenciasBD.NombreCarpetaBackUp))
                {
                    File.Delete(Path.Combine(ReferenciasBD.NombreCarpetaBackUp, nombreArchivoBackup));
                }
                else
                    throw new FileNotFoundException();
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("No se encontró la ruta o archivo especificado a eliminar.");
            }
            catch
            {
                throw;
            }
        }
        public void RestaurarBackup(string nombreArchivoBackup)
        {
            try
            {
                if (Directory.Exists(ReferenciasBD.NombreCarpetaBackUp))
                {
                    File.Copy(Path.Combine(ReferenciasBD.NombreCarpetaBackUp, nombreArchivoBackup), ReferenciasBD.BaseDatosFullCar, true);
                }
                else
                    throw new FileNotFoundException();
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("No se encontró la ruta o archivo especificado a restaurar.");
            }
            catch
            {
                throw;
            }
        }

        #endregion

    }
}
