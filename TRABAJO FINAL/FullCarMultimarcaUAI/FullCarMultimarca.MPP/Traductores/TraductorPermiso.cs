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
    class TraductorPermiso : ITraductorEntidad
    {

        public TraductorPermiso()
        {
            DiccionarioEquivalencias.Add(nameof(Permiso.Codigo).ObtenerFullNameMasPropiedad<Permiso>(), "Codigo");            
        }

        public IDictionary<string, string> DiccionarioEquivalencias { get; } = new Dictionary<string, string>();
    }
   
}
