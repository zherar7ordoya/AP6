using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableIEnumerator
{
    class CAutomovil : IAutomovil
    {
        double costo, impuesto;
        string modelo;
        public CAutomovil(string pModelo, double pCosto)
        {
            this.modelo = pModelo;
            this.costo = pCosto;
        }
        public void CalcularImpuesto(double pImpuesto)
        {
            impuesto = 5000 + costo * pImpuesto;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Automovil: { modelo }"          );
            Console.WriteLine($"Costo:     { costo }"           );
            Console.WriteLine($"Impuesto:  { impuesto }"        );
            Console.WriteLine($"TOTAL:     { costo + impuesto }");
        }
    }
}
