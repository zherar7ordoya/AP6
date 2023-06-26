using System;
using static System.Console;

namespace InterfazCallBack
{
    class CTiendaSink : IEventosRefrigerador
    {
        public void ElDescongelado(int pGrados)
        {
            // throw new NotImplementedException();
        }

        public void EReservasBajas(int pKilos)
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine("\n---> Le enviaremos su pedido");
            WriteLine($"---> Serán { pKilos } kilos");
        }
    }
}
