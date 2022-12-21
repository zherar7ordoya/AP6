using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Abstracciones
{
    /// <summary>
    /// Interfaz que agrega al ABMC métodos para la asignación en patrones de composición para la capa mapping
    /// </summary>
    /// <typeparam name="TIPO"></typeparam>
    public interface IMappingAsignable<TIPO> : IMapping<TIPO>
    {
        void Asignar(TIPO padre, TIPO hijo);
        void Desasignar(TIPO padre, TIPO hijo);
        void ActualizarAsignacion(TIPO padre, TIPO hijo);
        bool ExisteAsignacion(TIPO padre, TIPO hijo);

    }
}
