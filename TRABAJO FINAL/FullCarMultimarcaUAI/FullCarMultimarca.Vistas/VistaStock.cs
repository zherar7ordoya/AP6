using FullCarMultimarca.Vistas.Atributos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Vistas
{
    public class VistaStock
    {

        public VistaStock()
        {           
        }

              
        public string Chasis { get; set; }
        public string Marca { get; set; }
        [TituloGrilla("Código\nModelo")]
        public string CodigoModelo { get; set; }
        [TituloGrilla("Descripción\nModelo")]
        public string DescripcionModelo { get; set; }
        public string Color { get; set; }
        [TituloGrilla("Precio\nPúblico"), FormatoGrilla("c2")]
        public decimal PrecioPublico { get; set; }
        [TituloGrilla("Fecha Compra"), FormatoGrilla("dd/MM/yyyy")]
        public DateTime FechaCompra { get; set; }
        [TituloGrilla("Antig.Stock\n(días)"), FormatoGrilla("n0")]
        public int Antiguedad { get; set; }
        [TituloGrilla("En Oferta")]
        public bool EnOferta { get; set; }
        [TituloGrilla("Precio\nOferta"), FormatoGrilla("c2")]
        public decimal? Oferta { get; set; }
        [TituloGrilla("Vencimiento\nOferta"), FormatoGrilla("dd/MM/yyyy")]
        public DateTime? VencimientoOferta { get; set; }




    }
}
