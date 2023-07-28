using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace FabricaAbstracta
{
    public class LecheCoco : IProductoLeche
    {
public void producir()
        {
            WriteLine("Buscamos los cocos");
        }

        public string obtenDatos()
        {
            return "Leche de coco natural, 250 ml";
        }
    }
}