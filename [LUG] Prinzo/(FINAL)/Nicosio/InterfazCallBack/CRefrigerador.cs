using System;
using System.Collections;
using static System.Console;

namespace InterfazCallBack
{
    class CRefrigerador
    {
        /// <summary>
        /// Aquí guardamos todos los sinks con los que se comunicará el 
        /// refrigerador.
        /// </summary>
        private readonly ArrayList listaSinks = new ArrayList();
        private int kilosAlimentos = 0, grados = 0;

        public CRefrigerador(int pKilos, int pGrados)
        {
            kilosAlimentos = pKilos;
            grados = pGrados;
        }

        /// <summary>
        /// Con este método, adicionamos un Sink.
        /// </summary>
        /// <param name="pSink"></param>
        public void AgregarSink(IEventosRefrigerador pSink)
        {
            if (pSink != null)
            {
                listaSinks.Add(pSink);
            }
        }
        public void EliminarSink(IEventosRefrigerador pSink)
        {
            if (listaSinks.Contains(pSink))
            {
                listaSinks.Remove(pSink);
            }
        }

        public int Kilos { get { return kilosAlimentos; } }
        public int Grados { get { return grados; } }

        public void Trabajar(int pConsumo)
        {
            kilosAlimentos -= pConsumo;
            grados++;

            ForegroundColor = ConsoleColor.Gray;
            WriteLine($"\n{ kilosAlimentos } kilos, { grados } grados.");

            // Verificar si se cumple la condición para invocar los handlers.
            // En este caso, ésta es la condición del evento.
            if (kilosAlimentos < 10)
            {
                // Invocar los handlers de cada Sink.
                foreach(IEventosRefrigerador handler in listaSinks)
                {
                    handler.EReservasBajas(kilosAlimentos);
                }
            }
            if (grados >= 0)
            {
                foreach (IEventosRefrigerador handler in listaSinks)
                {
                    handler.ElDescongelado(grados);
                }
            }
        }
    }
}
