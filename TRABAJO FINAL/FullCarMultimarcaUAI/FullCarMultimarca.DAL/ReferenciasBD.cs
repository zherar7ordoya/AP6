using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.DAL
{
    /// <summary>
    /// Clase estática que contiene las referencias a la base de datos (nombres de archivo y carpetas)
    /// </summary>
    public static class ReferenciasBD
    {
        private static string _nombreCarpetaBaseDatos = "BaseDatos";
        private static string _nombreCarpetaBackup = "Backups";
        private static string _nombreBaseDatosFullCar = "FullCar.xml";
        private static string _nombreBaseDatosLogs = "Logs.xml";
        private static string _nombreBaseDatosBackups = "Backups.xml";

        public static string BaseDatosFullCar
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_nombreCarpetaBaseDatos))
                {
                    if (!Directory.Exists(_nombreCarpetaBaseDatos))
                        Directory.CreateDirectory(_nombreCarpetaBaseDatos);
                    return Path.Combine(_nombreCarpetaBaseDatos, _nombreBaseDatosFullCar);
                }
                else
                    return _nombreBaseDatosFullCar;
            }
        }
        public static string BaseDatosLogs
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_nombreCarpetaBaseDatos))
                {
                    if (!Directory.Exists(_nombreCarpetaBaseDatos))
                        Directory.CreateDirectory(_nombreCarpetaBaseDatos);
                    return Path.Combine(_nombreCarpetaBaseDatos, _nombreBaseDatosLogs);
                }
                else
                    return _nombreBaseDatosFullCar;
            }
        }
        public static string BaseDatosBackups
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_nombreCarpetaBaseDatos))
                {
                    if (!Directory.Exists(_nombreCarpetaBaseDatos))
                        Directory.CreateDirectory(_nombreCarpetaBaseDatos);
                    return Path.Combine(_nombreCarpetaBaseDatos, _nombreBaseDatosBackups);
                }
                else
                    return _nombreBaseDatosFullCar;
            }
        }
        public static string NombreCarpetaBackUp
        {
            get
            {
                if (!Directory.Exists(_nombreCarpetaBackup))
                    Directory.CreateDirectory(_nombreCarpetaBackup);

                return _nombreCarpetaBackup;
            }
        }
    }
}
