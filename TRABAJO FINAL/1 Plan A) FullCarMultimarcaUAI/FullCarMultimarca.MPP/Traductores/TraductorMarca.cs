using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE.Gestion;
using System.Collections.Generic;
using FullCarMultimarca.Servicios.Extensiones;

namespace FullCarMultimarca.MPP.Traductores
{
    public class TraductorMarca : ITraductorEntidad
    {        

        public TraductorMarca()
        {
            DiccionarioEquivalencias.Add(nameof(Marca.Descripcion).ObtenerFullNameMasPropiedad<Marca>(), "Descripcion");
        }

        public IDictionary<string, string> DiccionarioEquivalencias { get; } = new Dictionary<string, string>();
    }
}
