using FullCarMultimarca.Vistas.Atributos;
using System;

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
