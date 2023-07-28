using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Delegados
{
    class CPastel
    {
        public static void MostrarPastel(string pAnuncio)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine($"El pastel mensajeará: { pAnuncio }");
        }
    }
}
