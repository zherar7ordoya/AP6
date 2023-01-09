using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.Servicios.Extensiones;
using System.Collections.Generic;

namespace FullCarMultimarca.MPP.Traductores
{
    public class TraductorCliente : ITraductorEntidad
    {

        public TraductorCliente()
        {
            DiccionarioEquivalencias.Add(nameof(Cliente.CUIT).ObtenerFullNameMasPropiedad<Cliente>(), "CUIT");
            DiccionarioEquivalencias.Add(nameof(Cliente.Apellido).ObtenerFullNameMasPropiedad<Cliente>(), "Apellido");
            DiccionarioEquivalencias.Add(nameof(Cliente.Nombre).ObtenerFullNameMasPropiedad<Cliente>(), "Nombre");
        }

        public IDictionary<string, string> DiccionarioEquivalencias { get; } = new Dictionary<string, string>();
    }
}
