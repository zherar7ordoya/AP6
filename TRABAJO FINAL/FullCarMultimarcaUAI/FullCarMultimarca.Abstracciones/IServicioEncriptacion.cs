namespace FullCarMultimarca.Abstracciones
{
    /// <summary>
    /// Abstracción para la inversión de control para el servicio de encriptación 
    /// </summary>
    public interface IServicioEncriptacion
    {

        string EncriptarSHA(string texto);
        string Encriptar3DES(string texto);
        string Desencriptar3DES(string textoEncriptado);
    }
}
