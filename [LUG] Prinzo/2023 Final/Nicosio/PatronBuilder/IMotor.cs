using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronBuilder
{
    internal interface IMotor
    {
        string especificaciones();
    }

    class MotorBasico : IMotor
    {
        public string especificaciones()
        {
            return "Motor de 4 cilindros";
        }
    }

    class MotorGrande : IMotor
    {
        public string especificaciones()
        {
            return "Motor de 8 cilindros";
        }
    }
}
