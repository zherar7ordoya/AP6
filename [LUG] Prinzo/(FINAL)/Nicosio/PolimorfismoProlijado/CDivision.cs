using System;

namespace Video03
{
    class CDivision : IOperacion
    {
        private double r = 0;
        public void calcular(double a, double b)
        {
            r = a / b;
        }

        public void mostrar()
        {
            Console.WriteLine("División: {0}", r);
        }
    }
}
