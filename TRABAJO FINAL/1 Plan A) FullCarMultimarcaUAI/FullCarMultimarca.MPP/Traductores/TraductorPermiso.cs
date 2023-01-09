using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.Servicios.Extensiones;
using System.Collections.Generic;

namespace FullCarMultimarca.MPP.Traductores
{
    class TraductorPermiso : ITraductorEntidad
    {

        public TraductorPermiso()
        {
            DiccionarioEquivalencias.Add(nameof(Permiso.Codigo).ObtenerFullNameMasPropiedad<Permiso>(), "Codigo");            
        }

        public IDictionary<string, string> DiccionarioEquivalencias { get; } = new Dictionary<string, string>();
    }
   
}
