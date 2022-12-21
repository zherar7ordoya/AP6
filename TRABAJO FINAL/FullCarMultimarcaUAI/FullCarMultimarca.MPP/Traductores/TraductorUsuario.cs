using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.Servicios.Extensiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
