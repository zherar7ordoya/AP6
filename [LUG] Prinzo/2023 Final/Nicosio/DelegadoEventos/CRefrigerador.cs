using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DelegadoEventos
{
    delegate void DReservasBajas(int pKilos);
    delegate void DDescongelado(int pGrados);

    class CRefrigerador
    {
        private int kilosAlimentos = 0;
        private int grados = 0;

        private DReservasBajas delegadoReservas;
        private DDescongelado delegadoDescongelado;

        public CRefrigerador(int pKilos, int pGrados)
        {
            kilosAlimentos = pKilos;
            grados = pGrados;
        }

        public void AdicionaMetodoReservas(DReservasBajas pMetodo)
        {
            delegadoReservas += pMetodo;
        }
        public void EliminaMetodoReservas(DReservasBajas pMetodo)
        {
            delegadoReservas -= pMetodo;
        }
        public void AdicionaMetodoDescongelado(DDescongelado pMetodo)
        {
            delegadoDescongelado += pMetodo;
        }
        public void EliminaMetodoDescongelado(DDescongelado pMetodo)
        {
            delegadoDescongelado -= pMetodo;
        }
        public int Kilos { get { return kilosAlimentos; } set { kilosAlimentos = value; } }
        public int Grados { get { return grados; } set { grados = value; } }

        public void Trabajar(int pConsumo)
        {
            kilosAlimentos -= pConsumo;
            grados++;

            ForegroundColor = ConsoleColor.Gray;
            WriteLine($"--> { kilosAlimentos } kilos, { grados } grados.");

            if (kilosAlimentos < 10)
            {
                delegadoReservas(kilosAlimentos);
            }
            if (grados > 0)
            {
                delegadoDescongelado(grados);
            }
        }
    }
}
