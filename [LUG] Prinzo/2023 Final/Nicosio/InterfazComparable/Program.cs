using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazIComparable
{
    class Program
    {
        static void Main(string[] args)
        {
            CRectangulo[] rectangulos = new CRectangulo[5];

            rectangulos[0] = new CRectangulo(7, 5);
            rectangulos[1] = new CRectangulo(6, 4);
            rectangulos[2] = new CRectangulo(4, 3);
            rectangulos[3] = new CRectangulo(7, 6);
            rectangulos[4] = new CRectangulo(5, 7);

            foreach (CRectangulo rectangulo in rectangulos)
            {
                Console.WriteLine(rectangulo);
            }
            Console.WriteLine("*************");
            Array.Sort(rectangulos);
            foreach (CRectangulo rectangulo in rectangulos)
            {
                Console.WriteLine(rectangulo);
            }
            Console.ReadKey();
        }
    }
}
