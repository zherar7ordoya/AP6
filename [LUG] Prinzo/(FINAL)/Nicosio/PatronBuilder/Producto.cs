using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PatronBuilder
{
    internal class Producto
    {
        private IMotor motor;
        private ICarroceria carroceria;
        private ILlantas llantas;

        public void ColocarMotor(IMotor pMotor)
        {
            motor = pMotor;
            WriteLine($"Se ha colocado el motor {motor.especificaciones()}");
        }

        public void ColocarCarroceria (ICarroceria pCarroceria)
        {
            carroceria = pCarroceria;
            WriteLine($"Se ha colocado la carrocería {carroceria.caracteristicas()}");
        }

        public void ColocarLlantas (ILlantas pLlantas)
        {
            llantas = pLlantas;
            WriteLine($"Se han colocado las llantas {llantas.informacion()}");
        }

        public void MostrarAuto()
        {
            WriteLine($"Tu auto tiene {motor.especificaciones()}, {carroceria.caracteristicas()}, {llantas.informacion()}");
        }
    }
}
