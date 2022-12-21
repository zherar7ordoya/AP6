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
    public class TraductorModelo : ITraductorEntidad
    {

        public TraductorModelo()
        {
            DiccionarioEquivalencias.Add(nameof(Modelo.Codigo).ObtenerFullNameMasPropiedad<Modelo>(), "Codigo");
            DiccionarioEquivalencias.Add(nameof(Modelo.Descripcion).ObtenerFullNameMasPropiedad<Modelo>(), "Descripcion");         
        }

        public IDictionary<string, string> DiccionarioEquivalencias { get; } = new Dictionary<string, string>();
    }
}
