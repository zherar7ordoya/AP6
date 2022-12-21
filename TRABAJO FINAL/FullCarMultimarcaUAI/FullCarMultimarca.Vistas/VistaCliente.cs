using FullCarMultimarca.Vistas.Atributos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Vistas
{
    public class VistaCliente
    {
        public VistaCliente()
        {

        }
      
        [TituloGrilla("CUIT/CUIL")]
        public string CUIT { get; set; }
        [TituloGrilla("Nombre /\nContacto")]
        public string Nombre { get; set; }
        [TituloGrilla("Apellido /\nRazón Social")]
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        [TituloGrilla("Código\nPostal")]
        public string CodigoPostal { get; set; }
        public string Provincia { get; set; }
    }
}
