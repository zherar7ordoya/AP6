using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Servicios.Excepciones
{

    /// <summary>
    /// Exepción para especificar que un usuario ha agotado sus intentos para ingresar y se ha bloquado.
    /// </summary>
    public class UsuarioBloqueadoException : NegocioException
    {
        public UsuarioBloqueadoException(string mensaje) : base(mensaje)
        {

        }
    }
}
