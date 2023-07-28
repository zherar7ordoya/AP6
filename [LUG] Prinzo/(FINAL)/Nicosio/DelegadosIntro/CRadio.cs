using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Delegados
{
    class CRadio
    {
        public static void MetodoRadio(string pMensaje)
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("Estamos en la clase Radio");
            WriteLine($"Tu mensaje: { pMensaje }");
        }
    }
}
