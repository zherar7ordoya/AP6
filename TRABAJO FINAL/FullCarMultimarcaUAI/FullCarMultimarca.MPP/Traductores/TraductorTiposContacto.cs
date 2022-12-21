using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.Servicios.Extensiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
