using FullCarMultimarca.Vistas.Atributos;

namespace FullCarMultimarca.Vistas
{
    public class VistaModelo
    {
        public VistaModelo()
        {

        }

        [TituloGrilla("Código")]
        public string Codigo { get; set; }

        [TituloGrilla("Descripción")]
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public bool Activo { get; set; }
        [TituloGrilla("Precio Público"), FormatoGrilla("c2")]
        public decimal PrecioPublico { get; set; }
    }
}
