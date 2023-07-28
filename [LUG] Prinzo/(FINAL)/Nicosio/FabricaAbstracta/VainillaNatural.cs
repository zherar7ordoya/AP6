using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace FabricaAbstracta
{
    public class VainillaNatural : IProductoSaborizante
    {
        public void obtener()
        {
            WriteLine("Se obtiene de las vainas");
        }

        public string informacion()
        {
            return "Extracto natural de vainilla";
        }
    }
}