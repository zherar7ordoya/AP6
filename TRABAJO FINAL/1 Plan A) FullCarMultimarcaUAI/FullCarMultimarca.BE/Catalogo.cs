using System;

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
