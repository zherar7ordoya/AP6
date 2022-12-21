using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Servicios.Excepciones
{
    public class UsuarioClaveVencidaException : NegocioException
    {
        public UsuarioClaveVencidaException() : base("")
        {

        }
        public UsuarioClaveVencidaException(string mensaje) : base(mensaje)
        {

        }
    }
}
