using FullCarMultimarca.Vistas.Atributos;

namespace FullCarMultimarca.Vistas
{
    public class VistaMarca
    {
        public VistaMarca()
        {

        }
  
        [TituloGrilla("Descripción")]
        public string Descripcion { get; set; }
        public bool Activa { get; set; }

    }
}
