using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Servicios.Excepciones
{
    public class GuardarLogException : NegocioException
    {
        public GuardarLogException(string mensaje = "") : base("")
        {            
        }            

        public override string Message => $"Ocurrió un error al guardar el log asociado a esta acción.";

    }
}
