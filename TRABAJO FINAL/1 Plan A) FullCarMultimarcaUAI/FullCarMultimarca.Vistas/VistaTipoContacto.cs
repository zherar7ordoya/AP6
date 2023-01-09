using FullCarMultimarca.Vistas.Atributos;

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
