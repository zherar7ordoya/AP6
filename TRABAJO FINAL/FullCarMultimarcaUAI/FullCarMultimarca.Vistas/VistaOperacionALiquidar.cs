using FullCarMultimarca.Vistas.Atributos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Vistas
{
    public class VistaOperacionALiquidar
    {
        public VistaOperacionALiquidar()
        {
           
        }


        [NoVisibleEnGrilla]
        public int NumeroInterno { get; set; }   
        public string Numero { get; set; }
        [FormatoGrilla("dd/MM/yyyy")]
        public DateTime Fecha { get; set; }
        [TituloGrilla("Vendedor")]
        public string UsuarioVendedor { get; set; }
        public string Cliente { get; set; }
        [TituloGrilla("Descripción\nModelo")]
        public string DescModelo { get; set; }
        [TituloGrilla("Tasa IVA"),FormatoGrilla("p2")]
        public decimal TasaIVA { get; set; }                
        [TituloGrilla("Precio\nUnidad"), FormatoGrilla("c2")]
        public decimal PrecioUnidad { get; set; }
        [TituloGrilla("Neto\na Comisionar"),FormatoGrilla("c2")]
        public decimal NetoAComisionar { get; set; }
    }

}

