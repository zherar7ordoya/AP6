using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronBuilder
{
    internal class Director
    {
        public void Construye(IBuilder pConstructor)
        {
            pConstructor.ConstruyeMotor();
            pConstructor.ConstruyeCarroceria();
            pConstructor.ConstruyeLlantas();
        }
    }
}
