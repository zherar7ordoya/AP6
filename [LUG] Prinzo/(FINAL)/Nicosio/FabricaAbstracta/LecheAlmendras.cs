using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace FabricaAbstracta
{
    public class LecheAlmendras : IProductoLeche
    {
 public void producir()
        {
            WriteLine("Procesar las almendras");
        }

        public string obtenDatos()
        {
            return "Leche orgánica de almendra, 250ml";
        }
    }
}