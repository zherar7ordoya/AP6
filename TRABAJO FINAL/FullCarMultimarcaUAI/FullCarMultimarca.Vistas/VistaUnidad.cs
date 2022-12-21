using FullCarMultimarca.Vistas.Atributos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Vistas
{
    public class VistaUnidad
    {
        public VistaUnidad()
        {

        }

        
        public string Chasis { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public bool Disponible { get; set; } = true;
        [TituloGrilla("Fecha\nCompra"), FormatoGrilla("dd/MM/yyyy")]
        public DateTime FechaCompra { get; set; }
        [TituloGrilla("Compra\nsin IVA"), FormatoGrilla("c2")]
        public decimal ImporteCompra { get; set; }
        [TituloGrilla("Precio\nOferta"), FormatoGrilla("c2")]
        public decimal? Oferta { get; set; }
        [TituloGrilla("F.Vencimiento\nOferta"), FormatoGrilla("dd/MM/yyyy")]
        public DateTime? VencimientoOferta { get; set; }
    }
}
