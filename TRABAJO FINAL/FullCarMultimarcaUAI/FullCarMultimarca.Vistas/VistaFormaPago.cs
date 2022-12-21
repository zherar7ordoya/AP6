using FullCarMultimarca.Vistas.Atributos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Vistas
{
    public class VistaFormaPago
    {
        public VistaFormaPago()
        {        
        }
                
        [TituloGrilla("Descripción")]
        public string Descripcion { get; set; }
        public bool Activa { get; set; }
        [TituloGrilla("Arancel\nGasto"), FormatoGrilla("p2")]
        public decimal? ArancelGasto { get; set; }



    }
}
