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
