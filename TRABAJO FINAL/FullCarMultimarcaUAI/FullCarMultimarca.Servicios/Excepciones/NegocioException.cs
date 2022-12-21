using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Servicios.Excepciones
{
    public class NegocioException : ApplicationException
    {

        public NegocioException(string mensaje) : base(mensaje)
        {
        }
        public NegocioException(string mensaje, Exception ex) : base(mensaje, ex)
        {
        }

        
    }
}
