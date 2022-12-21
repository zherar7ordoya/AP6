using FullCarMultimarca.Vistas.Atributos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Vistas
{
    public class VistaOperacion
    {

        public VistaOperacion()
        {
          
        }


        [NoVisibleEnGrilla]
        public int NumeroInterno { get; set; }
        public string Estado { get; set; }
        public string Numero { get; set; }
        [TituloGrilla("Vendedor")]
        public string UsuarioVendedor { get; set; }
        public string Chasis { get; set; }
        [TituloGrilla("Código\nModelo")]
        public string CodModelo { get; set; }
        [TituloGrilla("Descripción\nModelo")]
        public string DescModelo { get; set; }
        public string Color { get; set; }
        public string Cliente { get; set; }
        [FormatoGrilla("dd/MM/yyyy")]
        public DateTime Fecha { get; set; }
        [TituloGrilla("Es\nOferta")]
        public bool EsOferta { get; set; }
        [TituloGrilla("Patenta\nEmpresa")]
        public bool PatentaEmpresa { get; set; }
        [TituloGrilla("Precio\nFinal"),FormatoGrilla("c2")]
        public decimal PrecioFinal { get; set; }
        [TituloGrilla("Fecha\nAutorización")]
        public DateTime? FechaAutorizacion { get; set; }
        [TituloGrilla("Usuario\nAutorización")]
        public string UsuarioAutorizacion { get; set; }
        public bool Anulada { get; set; }
        [NoVisibleEnGrilla]
        public string NotaRechazo { get; set; }
        public bool Liquidada { get; set; }
    }
}
