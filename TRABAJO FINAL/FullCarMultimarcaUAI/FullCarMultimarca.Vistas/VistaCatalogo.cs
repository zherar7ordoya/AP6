using FullCarMultimarca.Vistas.Atributos;
using System;

namespace FullCarMultimarca.Vistas
{
    public class VistaCatalogo
    {
        public VistaCatalogo()
        {

        }
        
        [TituloGrilla("Fecha y Hora creación"), FormatoGrilla("dd/MM/yyyy HH:mm:ss")]
        public DateTime FechaYHora { get; set; }
        [TituloGrilla("Usuario Creador")]
        public string Creador { get; set; }
        [TituloGrilla("Nombre del archivo")]
        public string NombreArchivo { get; set; }
        [NoVisibleEnGrilla]
        public string Descripcion { get; set; }
    }
}
