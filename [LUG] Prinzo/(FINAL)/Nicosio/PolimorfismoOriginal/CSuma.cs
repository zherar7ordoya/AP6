using System;

namespace Polimorfismo
{
    class CSuma : IOperacion
    {
        private double resultado = 0;

        public void calcular(double a, double b)
        {
            resultado = a + b;
        }

        public void mostrar()
        {
            Console.WriteLine($"Suma: {resultado}");
        }
    }
}
