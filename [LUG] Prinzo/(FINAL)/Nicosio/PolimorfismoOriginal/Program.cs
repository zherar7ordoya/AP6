using System;

namespace Polimorfismo
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            double a = 0, b = 0;
            IOperacion operacion = new CSuma();

            while(opcion != 5)
            {
                Console.Write("Suma[1]  Resta[2]   Multiplicación[3]   División[4]   Salir[5]: ");
                opcion = Convert.ToInt32(Console.ReadLine());
                if (opcion != 5)
                {
                    Console.Write("Ingrese el valor del 1er número: ");
                    a = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Ingrese el valor del 2do número: ");
                    b = Convert.ToDouble(Console.ReadLine());
                }
                switch (opcion)
                {
                    case 1:
                        operacion = new CSuma();
                        break;
                    case 2:
                        operacion = new CResta();
                        break;
                    case 3:
                        operacion = new CMultiplicacion();
                        break;
                    case 4:
                        operacion = new CDivision();
                        break;
                    default:
                        Console.WriteLine("\n\nERROR!\n\n");
                        break;
                }
                operacion.calcular(a, b);
                operacion.mostrar();
            }
        }
    }
}
