using FullCarMultimarca.Vistas.Atributos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Vistas
{
    public class VistaTipoContacto
    {
        public VistaTipoContacto()
        {

        }

        [TituloGrilla("Descripción")]
        public string Descripcion { get; set; }      
        public bool Activo { get; set; }
        [TituloGrilla("Permite\nNotificaciones")]
        public bool PermiteNotificaciones { get; set; }
    }
}
