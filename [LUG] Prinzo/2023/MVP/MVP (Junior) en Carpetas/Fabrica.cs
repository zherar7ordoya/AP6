using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicativo
{
    public static class Fabrica
    {
        public static OperacionModelo CreaOperacionModelo()
        {
            return new OperacionModelo();
        }

        public static OperacionPresentador CreaOperacionPresentador(IOperacionVista vista)
        {
            return new OperacionPresentador(vista);
        }
    }
}
