using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.Servicios.Extensiones;
using System.Collections.Generic;

namespace FullCarMultimarca.MPP.Traductores
{
    public class TraductorFormaPago : ITraductorEntidad
    {

        public TraductorFormaPago()
        {
            DiccionarioEquivalencias.Add(nameof(FormaPago.Descripcion).ObtenerFullNameMasPropiedad<FormaPago>(), "Descripcion");
        }

        public IDictionary<string, string> DiccionarioEquivalencias { get; } = new Dictionary<string, string>();
    }
}
