using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
