using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Abstracciones
{
    /// <summary>
    /// Abstracción del servicio para ejecutar un método de forma asíncrona dentro de un método NO asincrónico
    /// </summary>
    public interface IServicioTransfAsync
    {

        void EjectutarAsincronico(Func<Task> delegado);
        Task<T> EjectutarAsincronico<T>(Func<Task<T>> delegado);

    }
}
