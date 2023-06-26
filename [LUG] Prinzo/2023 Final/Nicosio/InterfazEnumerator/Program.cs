using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableIEnumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            CConcesionaria concesionaria = new CConcesionaria();
            foreach(CAutomovil auto in concesionaria)
            {
                Console.WriteLine();
                auto.CalcularImpuesto(0.05);
                auto.MostrarInformacion();
            }
            Console.ReadKey();
        }
    }
}
