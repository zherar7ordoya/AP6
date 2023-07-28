using System.Collections;

namespace IEnumerableIEnumerator
{
    class CConcesionaria
    {
        private readonly CAutomovil[] disponibles;
        public CConcesionaria()
        {
            disponibles = new CAutomovil[4];
            disponibles[0] = new CAutomovil("Soul ", 22000 );
            disponibles[1] = new CAutomovil("Fit  ", 17000 );
            disponibles[2] = new CAutomovil("March", 16890 );
            disponibles[3] = new CAutomovil("Spark", 160040);
        }
        public IEnumerator GetEnumerator()
        {
            return disponibles.GetEnumerator();
        }
    }
}