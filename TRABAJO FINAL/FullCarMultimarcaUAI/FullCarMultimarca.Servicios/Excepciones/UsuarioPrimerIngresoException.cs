using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Servicios.Excepciones
{
    public class UsuarioPrimerIngresoException : NegocioException
    {
        public UsuarioPrimerIngresoException() : base("")
        {

        }
        public UsuarioPrimerIngresoException(string mensaje) : base(mensaje)
        {

        }
    }
}
