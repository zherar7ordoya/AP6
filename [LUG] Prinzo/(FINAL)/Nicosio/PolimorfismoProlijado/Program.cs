using System;

namespace Video03
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            double vala = 0.0;
            double valb = 0.0;

            string valor = "";

            IOperacion operacion = new CSuma();

            while (opcion != 5)
            {
                Reinicio:
                Console.WriteLine("1 (suma)  ||  "              +
                                  "2 (resta)  ||  "             +
                                  "3 (multiplicación)  ||  "    +
                                  "4 (división)  ||  "          +
                                  "5 (salir)");
                
                Console.WriteLine("Opción:");
                valor = Console.ReadLine();
                opcion = Convert.ToInt32(valor);

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
                    case 5:
                        Console.WriteLine("Press C to continue or Q to quit.");
                        if (Console.ReadLine() == "q" || Console.ReadLine() == "Q") 
                        {
                            goto Salida;
                        }
                        else
                        {
                            goto Reinicio;
                        }
                    default:
                        goto Reinicio;
                }

                Console.WriteLine("Valor de a:");
                valor = Console.ReadLine();
                vala = Convert.ToDouble(valor);

                Console.WriteLine("Valor de b:");
                valor = Console.ReadLine();
                valb = Convert.ToDouble(valor);

                operacion.calcular(vala, valb);
                operacion.mostrar();
            Salida:
                Console.WriteLine("Saliendo...");
            }
        }
    }
}
