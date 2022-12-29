namespace FullCarMultimarca.Abstracciones
{
    /// <summary>
    /// Abstracción que se inyecta en todas las clases del negocio y brinda el servicio de logear los eventos.
    /// </summary>
    public interface ILogger
    {
     
        void GenerarLog(string detalle, string usuario = default);
        void GenerarLog(IAuditable entidad, string tipoAccion, string textoAdicional = "");


    }
}
