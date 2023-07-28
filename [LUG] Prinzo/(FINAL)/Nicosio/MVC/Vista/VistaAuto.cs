using MVC.Modelo;
using static System.Console;

namespace MVC.Vista
{
    internal class VistaAuto : IVistaAuto
    {
        public void DespliegaAuto(Auto auto)
        {
            ForegroundColor = ConsoleColor.White;
            Write("\nDetalles del automóvil: ");
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"{auto.Nombre} {auto.Modelo}, {auto.Costo:C}");
        }

        public int SolicitaEntrada()
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine("\t1) Cambiar costo");
            WriteLine("\t2) Cambiar modelo");
            WriteLine("\t3) Salir");
            ForegroundColor = ConsoleColor.Cyan;
            int opcion = Convert.ToInt32(ReadLine());
            return opcion;
        }
    }
}
