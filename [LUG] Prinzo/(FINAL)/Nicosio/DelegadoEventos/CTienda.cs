using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DelegadoEventos
{
    class CTienda
    {
        public static void MandaViveres(int pKilos)
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine("--> Vamos a mandar sus víveres, estoy en la tienda");
            WriteLine($"--> Serán { pKilos } kilos.");
        }
    }
}
