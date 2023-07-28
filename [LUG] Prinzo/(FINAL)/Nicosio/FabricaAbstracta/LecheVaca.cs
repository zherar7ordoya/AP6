using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace FabricaAbstracta
{
    public class LecheVaca : IProductoLeche
    {
        public void producir()
        {
            WriteLine("Ordeñar vaca en la granja");
        }

        public string obtenDatos()
        {
            return "Leche de vaca, 250 ml";
        }
    }
}