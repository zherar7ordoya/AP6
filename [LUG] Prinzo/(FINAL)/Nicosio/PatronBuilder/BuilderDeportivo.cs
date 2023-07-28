using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronBuilder
{
    internal class BuilderDeportivo : IBuilder
    {
        private Producto auto = new();

        public void ConstruyeCarroceria()
        {
            auto.ColocarCarroceria(new CarroceriaEspecial());
        }

        public void ConstruyeLlantas()
        {
            auto.ColocarLlantas(new LlantasSuper());
        }

        public void ConstruyeMotor()
        {
            auto.ColocarMotor(new MotorGrande());
        }

        public Producto ObtenProducto()
        {
            return auto;
        }
    }
}
