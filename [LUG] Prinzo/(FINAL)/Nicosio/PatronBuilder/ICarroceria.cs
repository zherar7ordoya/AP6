using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronBuilder
{
    internal interface ICarroceria
    {
        string caracteristicas();
    }

    class CarroceriaBasica : ICarroceria
    {
        public string caracteristicas()
        {
            return "Carrocería de metal";
        }
    }

    class CarroceriaEspecial : ICarroceria
    {
        public string caracteristicas()
        {
            return "Carrocería de fibra de carbono";
        }
    }
}
