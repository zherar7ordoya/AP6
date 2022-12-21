using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Servicios.Excepciones
{
    public class BaseCorruptaException : NegocioException
    {
        public BaseCorruptaException(List<string> tablasCorruptas = null) : base("")
        {
            _tablasCorruptas = tablasCorruptas;
        }

        private List<string> _tablasCorruptas;

        public List<string> TablasCorruptas { get { return _tablasCorruptas; } }

        public override string Message => $"Se dan detectado inconsistencias en la base de datos. Es posible que la misma esté corrupta o haya sido manipulada por fuera del sistema.";

    }
}
