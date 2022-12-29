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
