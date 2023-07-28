using System;

namespace Video03
{
    class CMultiplicacion : IOperacion
    {
        private double r = 0;
        public void calcular(double a, double b)
        {
            r = a * b;
        }

        public void mostrar()
        {
            Console.WriteLine("Multiplicación: {0}", r);
        }
    }
}
