using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.Servicios.Extensiones;
using System.Collections.Generic;

namespace FullCarMultimarca.MPP.Traductores
{
    public class TraductorColorUnidad : ITraductorEntidad
    {

        public TraductorColorUnidad()
        {
            DiccionarioEquivalencias.Add(nameof(ColorUnidad.Descripcion).ObtenerFullNameMasPropiedad<ColorUnidad>(), "Descripcion");
        }

        public IDictionary<string, string> DiccionarioEquivalencias { get; } = new Dictionary<string, string>();
    }
}
