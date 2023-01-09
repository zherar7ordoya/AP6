using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.Servicios.Extensiones;
using System.Collections.Generic;

namespace FullCarMultimarca.MPP.Traductores
{
    class TraductorTiposContacto : ITraductorEntidad
    {

        public TraductorTiposContacto()
        {
            DiccionarioEquivalencias.Add(nameof(TipoContacto.Descripcion).ObtenerFullNameMasPropiedad<TipoContacto>(), "Descripcion");
        }

        public IDictionary<string, string> DiccionarioEquivalencias { get; } = new Dictionary<string, string>();
    }
}
