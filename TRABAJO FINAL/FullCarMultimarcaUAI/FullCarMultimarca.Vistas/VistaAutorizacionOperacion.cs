
using FullCarMultimarca.Vistas.Atributos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Vistas
{
    public class VistaAutorizacionOperacion
    {

        public VistaAutorizacionOperacion()
        {
         
        }


        [NoVisibleEnGrilla]
        public int NumeroInterno { get; set; }        
        public string Numero { get; set; }
        [TituloGrilla("Vendedor")]
        public string UsuarioVendedor { get; set; }      
        [TituloGrilla("Código\nModelo")]
        public string CodModelo { get; set; }
        [TituloGrilla("Descripción\nModelo")]
        public string DescModelo { get; set; }
        public string Color { get; set; }
        public string Cliente { get; set; }
        [TituloGrilla("Precio\nPúblico"), FormatoGrilla("c2")]
        public decimal PrecioPublico { get; set; }        
        [FormatoGrilla("p2")]
        public decimal Pauta { get; set; }
        [TituloGrilla("Precio\nUnidad"), FormatoGrilla("c2")]
        public decimal PrecioUnidad { get; set; }
        [FormatoGrilla("p2")]
        public decimal Descuento { get; set; }
        [FormatoGrilla("c2")]
        public decimal Descalce { get; set; }
        [TituloGrilla("Precio\nFinal"), FormatoGrilla("c2")]
        public decimal PrecioFinal { get; set; }

    }
}
