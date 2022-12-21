using FullCarMultimarca.Vistas.Atributos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Vistas
{
    public class VistaLog
    {
        public VistaLog()
        {

        }

        [NoVisibleEnGrilla]
        public virtual Guid? ID { get; set; }      

        [FormatoGrilla(formato: "dd/MM/yyyy HH:mm:ss")]
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
        [AnchoGrilla(ancho: 450)]
        public string Operacion { get; set; }
    }
}
