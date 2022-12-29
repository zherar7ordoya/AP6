using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE;
using FullCarMultimarca.Servicios.Extensiones;
using System.Collections.Generic;

namespace FullCarMultimarca.MPP.Traductores
{
    public class TraductorLog : ITraductorEntidad
    {

        public TraductorLog()
        {
            DiccionarioEquivalencias.Add(nameof(Log.Usuario).ObtenerFullNameMasPropiedad<Log>(), "Usuario");
            DiccionarioEquivalencias.Add(nameof(Log.Operacion).ObtenerFullNameMasPropiedad<Log>(), "Operacion");
            
        }

        public IDictionary<string, string> DiccionarioEquivalencias { get; } = new Dictionary<string, string>();
    }
}
