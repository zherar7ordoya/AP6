using FullCarMultimarca.Vistas.Atributos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Vistas
{
    public class VistaLiquidacionHeader
    {
        public VistaLiquidacionHeader()
        {

        }

        [TituloGrilla("Código")]
        public string Codigo { get; set; }
        [TituloGrilla("Fecha\nLiquidación")]
        public DateTime FechaLiquidacion { get; set; }
        public string Comentarios { get; set; }
    }
}
