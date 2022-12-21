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
    public class TraductorUnidad : ITraductorEntidad
    {

        public TraductorUnidad()
        {
            DiccionarioEquivalencias.Add(nameof(Unidad.Chasis).ObtenerFullNameMasPropiedad<Unidad>(), "Chasis");
            DiccionarioEquivalencias.Add(nameof(Modelo.Codigo).ObtenerFullNameMasPropiedad<Modelo>(), "PARENT(DR_Unidad_Modelo).Codigo");
            DiccionarioEquivalencias.Add(nameof(Modelo.Descripcion).ObtenerFullNameMasPropiedad<Modelo>(), "PARENT(DR_Unidad_Modelo).Descripcion");
            DiccionarioEquivalencias.Add(nameof(ColorUnidad.Descripcion).ObtenerFullNameMasPropiedad<ColorUnidad>(), "PARENT(DR_Unidad_Color).Descripcion");
     
        }

        public IDictionary<string, string> DiccionarioEquivalencias { get; } = new Dictionary<string, string>();
    }
}
