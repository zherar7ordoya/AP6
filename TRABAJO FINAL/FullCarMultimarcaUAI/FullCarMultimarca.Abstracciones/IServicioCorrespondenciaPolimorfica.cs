using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Abstracciones
{

    /// <summary>
    /// Abstracción para la inversión de control del servicio de Correspondencia Polimórfica 
    /// </summary>    
    public interface IServicioCorrespondenciaPolimorfica<TBLL>
    {
        TBLL ObtenerCorrespondencia(Type tipo);
    }
}
