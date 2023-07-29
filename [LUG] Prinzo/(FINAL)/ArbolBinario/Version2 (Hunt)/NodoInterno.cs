namespace Version2
{
    public static partial class ImpresionBase
    {
        public class NodoInterno
        {
            public NodoExterno Externo;
            public string Texto;
            public int PosicionInicial;
            public int PosicionFinal
            {
                get { return PosicionInicial + Tamaño; }
                set { PosicionInicial = value - Tamaño; }
            }
            public int Tamaño { get { return Texto.Length; } }
            public NodoInterno NodoPadre, HijoIzquierda, HijoDerecha;
        }
    }
}
