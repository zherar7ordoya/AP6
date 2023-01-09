using System;

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
