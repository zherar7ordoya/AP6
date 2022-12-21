using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Abstracciones
{
    /// <summary>
    /// Interfaz que expone método para validar una entidad utilizado en la capa del negocio
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidable<T>
    {
        string MensajeError { get; }
        bool EsValido(T objeto);
    }
}
