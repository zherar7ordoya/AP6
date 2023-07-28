using System;
using System.Collections;

namespace Video03
{
    class CSuma : IOperacion
    {
        private double r = 0;
        private ArrayList resultados = new ArrayList();

        public void calcular(double a, double b)
        {
            r = a + b;
        }
        public void mostrar()
        {
            Console.WriteLine("La suma es {0}", r);
            resultados.Add(r);
        }
        public void nuestraResultados()
        {
            foreach(double r in resultados)
            {
                Console.WriteLine(r);
            }
        }
    }
}
