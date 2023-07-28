using System;

namespace Polimorfismo
{
    class CDivision : IOperacion
    {
        private double resultado = 0;

        public void calcular(double a, double b)
        {
            resultado = a / b;
        }

        public void mostrar()
        {
            Console.WriteLine($"División: {resultado}");
        }
    }
}
