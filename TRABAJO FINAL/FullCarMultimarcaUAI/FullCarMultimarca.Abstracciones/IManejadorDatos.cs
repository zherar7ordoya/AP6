using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Abstracciones
{
    /// <summary>
    /// Abstracción que utiliza la capa mapping para comunicarse con la DAL; 
    /// </summary>
    public interface IManejadorDatos
    {        

        bool ExisteBaseDatos();
        DataSet ObtenerDatos();
        void GuardarDatos(DataSet ds);

    }
}
