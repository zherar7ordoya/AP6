using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazIComparable
{
    class CRectangulo : IComparable
    {
        private readonly double _ancho;
        private readonly double _alto;
        private double _area;

        public CRectangulo(double pAncho, double pAlto)
        {
            this._ancho = pAncho;
            this._alto = pAlto;
            CalcularArea();
        }
        private void CalcularArea()
        {
            this._area = this._ancho * this._alto;
        }
        public override string ToString()
        {
            return string.Format($"{ this._ancho } por { this._alto } es { this._area }");
        }
        public int CompareTo(object obj)
        {
            CRectangulo temporal = (CRectangulo)obj;
            if (this._area > temporal._area)
            {
                return 1;
            }
            if (this._area < temporal._area)
            {
                return -1;
            }
            return 0;
        }
    }
}
