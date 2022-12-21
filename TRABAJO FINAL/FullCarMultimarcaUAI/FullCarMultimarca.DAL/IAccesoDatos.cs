using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.DAL
{
    /// <summary>
    /// Abstracción de acceso a Datos que deben implementar las clases que proveen dicho servicio;
    /// En nuestro sistema el acceso es a un XML; esta abstracción podría usarse para otro tipo de Acceso, por ejemplo, SQL.
    /// </summary>
    public interface IAccesoDatos
    {

        bool ExisteBDFullCar();
        bool ExisteBDCatalogo();
        bool ExisteBDLogs();

        DataSet ObtenerFullCar();
        DataSet ObtenerCatalogo();
        DataSet ObtenerLogs();

        void ActualizarFullCar(DataSet ds);
        void ActualizarCatalogo(DataSet ds);
        void ActualizarLogs(DataSet ds);

        void CrearBackup(string nombreArchivoBackup);
        void EliminarBackup(string nombreArchivoBackup);
        void RestaurarBackup(string nombreArchivoBackup);
    }
}
