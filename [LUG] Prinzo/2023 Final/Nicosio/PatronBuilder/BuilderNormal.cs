using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronBuilder
{
    internal class BuilderNormal : IBuilder
    {
        private Producto auto = new();

        public void ConstruyeCarroceria()
        {
            auto.ColocarCarroceria(new CarroceriaBasica());
        }

        public void ConstruyeLlantas()
        {
            auto.ColocarLlantas(new Llantas12());
        }

        public void ConstruyeMotor()
        {
            auto.ColocarMotor(new MotorBasico());
        }

        public Producto ObtenProducto()
        {
            return auto;
        }
    }
}
