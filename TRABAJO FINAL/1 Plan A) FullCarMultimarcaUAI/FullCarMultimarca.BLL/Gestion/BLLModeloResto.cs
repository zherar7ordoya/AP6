using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.BLL.Parametros;

namespace FullCarMultimarca.BLL.Gestion
{
    public class BLLModeloResto : BLLModelo, IEntidadCorrespondiente<ModeloResto>
    {

        protected BLLModeloResto() : base()
        {

        }

        public override decimal ObtenerTasaIVA()
        {
            var flags = BLLFlagsVentas.ObtenerInstancia().Leer();
            return flags.TasaIVAModelosResto / 100;
        }
    }
}
