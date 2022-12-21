using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Vistas.Atributos
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AnchoGrillaAttribute : Attribute
    {
        public AnchoGrillaAttribute(int ancho)
        {
            _ancho = ancho;
        }

        private int _ancho;

        public int Ancho
        {
            get { return _ancho; }
        }
    }
}
