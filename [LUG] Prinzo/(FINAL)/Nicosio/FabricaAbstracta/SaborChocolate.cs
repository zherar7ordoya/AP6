using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace FabricaAbstracta
{
    public class SaborChocolate : IProductoSaborizante
    {
        public void obtener()
        {
            WriteLine("Se produce C7H8N402");
        }

        public string informacion()
        {
            return "Sabor a chocolate";
        }
    }
}