using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace FabricaAbstracta
{
    public class FabricaNatural : IFabrica
    {
        private IProductoLeche leche;
        private IProductoSaborizante sabor;

        public IProductoLeche ObtenProductoLeche { get {return leche; } }
        public IProductoSaborizante ObtenSabor { get { return sabor; } }

        public void crearProductos()
        {
            ForegroundColor = ConsoleColor.Green;
            string seleccion;
            WriteLine("Estamos creando tu bebida");
            WriteLine(" 1) Almendras, 2) Coco");
            seleccion = ReadLine();

            if(seleccion == "1")
            {
                leche = new LecheAlmendras();
            }
            else
            {
                leche = new LecheCoco();
            }

            leche.producir();

            WriteLine("Ahora extraemos el sabor");
            sabor = new VainillaNatural();
            sabor.obtener();
        }
    }
}