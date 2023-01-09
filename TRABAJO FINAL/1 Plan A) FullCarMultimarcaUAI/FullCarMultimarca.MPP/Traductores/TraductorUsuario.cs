using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.Servicios.Extensiones;
using System.Collections.Generic;

namespace FullCarMultimarca.MPP.Traductores
{
    public class TraductorUsuario : ITraductorEntidad
    {

        public TraductorUsuario()
        {
            DiccionarioEquivalencias.Add(nameof(Usuario.Logon).ObtenerFullNameMasPropiedad<Usuario>(), "Logon");
            DiccionarioEquivalencias.Add(nameof(Usuario.Nombre).ObtenerFullNameMasPropiedad<Usuario>(), "Nombre");
            DiccionarioEquivalencias.Add(nameof(Usuario.Apellido).ObtenerFullNameMasPropiedad<Usuario>(), "Apellido");
        }

        public IDictionary<string, string> DiccionarioEquivalencias { get; } = new Dictionary<string, string>();
    }
}
