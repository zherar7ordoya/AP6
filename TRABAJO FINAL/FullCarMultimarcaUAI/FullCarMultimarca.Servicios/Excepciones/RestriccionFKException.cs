using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Servicios.Excepciones
{
    public class RestriccionFKException : NegocioException
    {
        public RestriccionFKException(string mensaje, DataException ex)  : base(mensaje)
        {
            Exepcion = ex;
        }

        DataException Exepcion;

        public override string Message => $"{base.Message}Utilice el tilde de ACTIVO si lo que desea es dejar de utilizar este elemento.\n\nDETALLE:\n{Exepcion.Message}";
    }
}
