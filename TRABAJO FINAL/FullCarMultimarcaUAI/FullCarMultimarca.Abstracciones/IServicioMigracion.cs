using System;
using System.Data;

namespace FullCarMultimarca.Abstracciones
{
    /// <summary>
    /// Abstracción para la inversión de control en el servicio de migración
    /// </summary>
    public interface IServicioMigracion
    {

        DataSet CrearBaseDatosBackup(string nombrePrimerBackup, DateTime fechaYHora);
        DataSet CrearBaseDatosLogs();
        DataSet CrearBaseDatosFullCar();
        void ActualizarVersionFullCar(DataSet ds);        

    }
}
