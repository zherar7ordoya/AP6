using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Delegados
{
    /// <summary>
    /// Definimos el delegado con las características que nos interesan.
    /// </summary>
    /// <param name="m"></param>
    public delegate void MiDelegado(string m);
    class Program
    {
        static void Main(string[] args)
        {
            MiDelegado delegado = new MiDelegado(CRadio.MetodoRadio);
            delegado("Hola a todos");
            delegado = new MiDelegado(CPastel.MostrarPastel);
            delegado("Feliz Cumpleaños");
            ReadKey();
        }
    }
}
