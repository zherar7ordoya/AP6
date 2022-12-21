using FullCarMultimarca.Vistas.Atributos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Vistas
{
    public class VistaColorUnidad
    {
        public VistaColorUnidad()
        {

        }
        
        [TituloGrilla("Descripción")]
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}
