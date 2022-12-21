using FullCarMultimarca.Vistas.Atributos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Vistas
{
    public class VistaModelo
    {
        public VistaModelo()
        {

        }

        [TituloGrilla("Código")]
        public string Codigo { get; set; }

        [TituloGrilla("Descripción")]
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public bool Activo { get; set; }
        [TituloGrilla("Precio Público"), FormatoGrilla("c2")]
        public decimal PrecioPublico { get; set; }
    }
}
