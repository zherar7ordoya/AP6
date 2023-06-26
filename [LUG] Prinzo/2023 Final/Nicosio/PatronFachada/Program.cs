// See https://aka.ms/new-console-template for more information

using static System.Console;
using Subsistemas;

WriteLine("Hello, World!");

Fachada fachada = new();

fachada.Compra();
ForegroundColor = ConsoleColor.White;
WriteLine("<*********************>");

fachada.Compra();
ForegroundColor = ConsoleColor.White;
WriteLine("<*********************>");

fachada.Compra();
ForegroundColor = ConsoleColor.White;
WriteLine("<*********************>");



namespace Subsistemas
{

    class Fachada
    {
        private SubsistemaAlmacen almacen = new();
        private SubsistemaCompras compras = new();
        private SubsistemaEnvios envios = new();

        public void Compra()
        {
            if(compras.Compra())
            {
                if (almacen.SacaAlmacen())
                {
                    envios.EnviaPedido();
                }
            }
        }
    }


    class SubsistemaCompras
    {
        public bool Compra()
        {
            ForegroundColor = ConsoleColor.White;
            WriteLine("¿Número de tarjeta?");
            string dato = Console.ReadLine();

            if (dato.Equals("123"))
            {
                ForegroundColor = ConsoleColor.Green;
                WriteLine("Pago aceptado");
                return true;
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Pago rechazado");
                return false;
            }
        }
    }




    class SubsistemaAlmacen
    {
        private int cantidad;

        public SubsistemaAlmacen()
        {
            cantidad = 2;
        }

        public bool SacaAlmacen()
        {
            if (cantidad > 0)
            {
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine("Puede enviarse");
                cantidad--;
                return true;
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("No disponible");
                return false;
            }
        }
    }




    class SubsistemaEnvios
    {
        public void EnviaPedido()
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("En camino");
        }
    }


}


