using System.Collections.Generic;

namespace FullCarMultimarca.Abstracciones
{
    /// <summary>
    /// Interfaz que ofrece un diccionario que cada entidad debe completar en la Capa MPP para realizar traducciones de propiedades (o descripciones de ellas) a campos 
    /// </summary>
    public interface ITraductorEntidad
    {

        IDictionary<string, string> DiccionarioEquivalencias { get; }
    }
}
