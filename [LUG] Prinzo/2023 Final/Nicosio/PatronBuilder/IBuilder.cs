using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronBuilder
{
    internal interface IBuilder
    {
        void ConstruyeMotor();
        void ConstruyeCarroceria();
        void ConstruyeLlantas();
    }
}
