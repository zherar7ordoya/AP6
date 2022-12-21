using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Abstracciones
{
    /// <summary>
    /// Abstracción para el servicio de validaciones generales del sistema
    /// </summary>
    public interface IServicioValidacion
    {

        bool ValidarPatronString(string valor, string patronValidacion);
        bool ValidarPatronInt(int valor, string patronValidacion);
        bool ValidarCuit(string cuit);
        bool ValidarCBU(string cbu);        
    }
}
