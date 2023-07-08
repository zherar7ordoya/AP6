using System;
using System.Diagnostics;

using static System.Console;

/**
 * Developer/s: Gerardo Tordoya
 * Description: Recursividad con Funciones Anónimas (Expresiones Lambda)
 * Create Date: 2023-07-07
 * Update Date: XXXX-XX-XX
 * https://youtu.be/v5Tdb5NqLlY
 */

namespace ConjeturaCollatz
{
    class Program
    {
        static void Main()
        {
            long numero = 1234567890;

            // ---------------------------------------------------------------

            Stopwatch timeMeasure = new Stopwatch();

            // ---------------------------------------------------------------

            WriteLine("Recursividad con Funciones Anónimas (Expresiones Lambda)");
            timeMeasure.Start();

            // Func<long, bool> esPar = (n) => n % 2 == 0;
            bool esPar(long n) => n % 2 == 0;

            Action<long> collatz = null;
            collatz = (n) =>
             {
                 WriteLine(n);
                 long result = 0;
                 if (esPar(n)) result = n / 2;
                 else { result = n * 3 + 1; }
                 if (result != 1) collatz(result);
                 else
                 {
                     WriteLine(result); // Imprime el 1 final
                     return;
                 }
             };

            collatz(numero);

            timeMeasure.Stop();
            WriteLine($"Tiempo: {timeMeasure.Elapsed.TotalMilliseconds} ms.");
            ReadKey();

            // ---------------------------------------------------------------

            WriteLine("\nRefactorización según [Hdeleon.net]");
            timeMeasure.Restart();

            collatz = (n) =>
            {
                WriteLine(n);
                if (n != 1) collatz(esPar(n) ? n / 2 : n * 3 + 1);
            };
            collatz(numero);

            timeMeasure.Stop();
            WriteLine($"Tiempo: {timeMeasure.Elapsed.TotalMilliseconds} ms.");
            ReadKey();

            // ---------------------------------------------------------------

            // Es el que se resuelve en menor tiempo.
            WriteLine("\nConjetura de Collatz según ChatGPT");
            timeMeasure.Restart();

            collatz = (long n) =>
            {
                while (n != 1)
                {
                    WriteLine(n);
                    n = n % 2 == 0 ? n / 2 : n * 3 + 1;
                }
                WriteLine(n);
            };

            collatz(numero);

            timeMeasure.Stop();
            WriteLine($"Tiempo: {timeMeasure.Elapsed.TotalMilliseconds} ms.");
            ReadKey();
        }
    }
}
