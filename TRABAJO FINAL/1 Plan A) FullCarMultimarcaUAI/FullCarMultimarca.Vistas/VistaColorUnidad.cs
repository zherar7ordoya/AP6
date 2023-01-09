using FullCarMultimarca.Vistas.Atributos;

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
