using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DelegadoEventos
{
    class Program
    {
        static void Main(string[] args)
        {
            CRefrigerador refrigerador = new CRefrigerador(70, -20);
            Random aleatorio = new Random();

            DReservasBajas kilos1 = new DReservasBajas(InformeKilos);
            DReservasBajas kilos2 = new DReservasBajas(CTienda.MandaViveres);

            DDescongelado desc1 = new DDescongelado(InformeGrados);

            refrigerador.AdicionaMetodoReservas(kilos1);
            refrigerador.AdicionaMetodoReservas(kilos2);
            refrigerador.AdicionaMetodoDescongelado(desc1);

            while (refrigerador.Kilos > 0)
            {
                refrigerador.Trabajar(aleatorio.Next(1, 5));
            }

            refrigerador.EliminaMetodoReservas(kilos2);
            refrigerador.Kilos = 50;
            refrigerador.Grados = -15;

            while (refrigerador.Kilos > 0)
            {
                refrigerador.Trabajar(aleatorio.Next(1, 5));
            }

            ReadKey();
        }
        public static void InformeKilos(int pKilos)
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("--> Reservas bajas de alimentos, estoy a nivel Main.");
            WriteLine($"--> Quedan { pKilos } kilos.");
        }
        public static void InformeGrados(int pGrados)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("--> Se descongela el refrigerador, estoy a nivel Main.");
            WriteLine($"--> Está a { pGrados } grados.");
        }
    }
}
