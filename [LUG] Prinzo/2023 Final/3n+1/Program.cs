using System;
using static System.Console;

/**
 * Developer/s: Gerardo Tordoya
 * Description: Recursividad con Funciones Anónimas (Expresiones Lambda)
 * Create Date: 2023-07-07
 * Update Date: XXXX-XX-XX
 * https://youtu.be/v5Tdb5NqLlY
 */

namespace _3n_1
{
    class Program
    {
        static void Main()
        {
            
            WriteLine("Recursividad con Funciones Anónimas (Expresiones Lambda)");
            
            Func<long, bool> isEven = (n) => n % 2 == 0;
            Action<long> collatz = null;
            collatz = (n) =>
            {
                WriteLine(n);
                long result = 0;
                if (isEven(n)) result = n / 2;
                else { result = n * 3 + 1; }
                if (result != 1) collatz(result);
                else
                {
                    WriteLine(result); // Imprime el 1 final
                    return;
                }
            };
            collatz(10);
            ReadKey();

            // ---------------------------------------------------------------
            
            WriteLine("\nRefactorización"); // 2 primeras líneas "prestadas"
            
            // Func<long, bool> isEven = (n) => n % 2 == 0;
            // Action<long> collatz = null;
            collatz = (n) =>
            {
                WriteLine(n);
                if (n != 1) collatz(isEven(n) ? n / 2 : n * 3 + 1);
            };
            collatz(10);
            ReadKey();
        }
    }
}
