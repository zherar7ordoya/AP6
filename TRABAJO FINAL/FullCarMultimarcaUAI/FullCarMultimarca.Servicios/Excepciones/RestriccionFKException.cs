using System.Data;

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
