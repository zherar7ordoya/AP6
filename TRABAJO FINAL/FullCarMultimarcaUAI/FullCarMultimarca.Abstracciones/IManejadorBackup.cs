using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Abstracciones
{
    /// <summary>
    /// Incluye métodos a implementar para el manejo del backup
    /// </summary>
    public interface IManejadorBackup : IManejadorDatos
    {

        void CrearBackup(string nombreArchivo);
        void EliminarBackup(string nomberArchivo);
        void RestaurarBackup(string nombreArchivo);

    }
}
