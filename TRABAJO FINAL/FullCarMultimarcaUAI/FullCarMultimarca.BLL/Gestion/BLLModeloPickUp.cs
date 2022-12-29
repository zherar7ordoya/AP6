using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.BLL.Parametros;

namespace FullCarMultimarca.BLL.Gestion
{
    public class BLLModeloPickUp : BLLModelo, IEntidadCorrespondiente<ModeloPickUp>
    {

        protected BLLModeloPickUp() : base()
        {

        }

        public override decimal ObtenerTasaIVA()
        {
            var flags = BLLFlagsVentas.ObtenerInstancia().Leer();
            return flags.TasaIVAModelosPickUp / 100;
        }
    }
}
