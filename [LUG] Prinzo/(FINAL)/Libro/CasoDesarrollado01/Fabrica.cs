using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoDesarrollado01
{
    public static class Fabrica
    {
        public static PromedioPresentador CrearPromedioPresentador()
        {
            return new PromedioPresentador(CrearPromedioModelo(), CrearPromedioVista());
        }
        public static IPromedioModelo CrearPromedioModelo()
        {
            return new PromedioModelo();
        }

        public static IPromedioVista CrearPromedioVista()
        {
            return new PromedioVista();
        }
    }
}
