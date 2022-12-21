using FullCarMultimarca.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.BE
{
    public class Catalogo
    {

        public Catalogo()
        {

        }      
        
               
        public DateTime FechaYHora { get; set; }        
        public string Creador { get; set; }        
        public string NombreArchivo { get; set; }        
        public string Descripcion { get; set; }
    }
}
