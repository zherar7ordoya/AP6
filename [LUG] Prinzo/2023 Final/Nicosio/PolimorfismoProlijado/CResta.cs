using System;

namespace Video03
{
    class CResta : IOperacion
    {
        private double r = 0;
        public void calcular(double a, double b)
        {
            r = a -b;
        }

        public void mostrar()
        {
            Console.WriteLine("Resultado resta: {0}", r);
        }
    }
}
