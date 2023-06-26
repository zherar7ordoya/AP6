using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronBuilder
{
    internal interface ILlantas
    {
        string informacion();
    }

    class Llantas12 : ILlantas
    {
        public string informacion()
        {
            return "Llantas de 14 pulgadas";
        }
    }

    class LlantasSuper : ILlantas
    {
        public string informacion()
        {
            return "Llantas de 18 pulgadas (rines de aluminio)";
        }
    }
}
