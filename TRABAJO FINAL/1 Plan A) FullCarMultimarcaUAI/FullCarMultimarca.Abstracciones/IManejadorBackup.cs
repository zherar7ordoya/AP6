namespace FullCarMultimarca.Abstracciones
{
    /// <summary>
    /// Incluye métodos a implementar para el manejo del backup
    /// </summary>
    public interface IManejadorBackup : IManejadorDatos
    {

        void CrearBackup(string nombreArchivo);
        void EliminarBackup(string nomberArchivo);
        void RestaurarBackup(string nombreArchivo);

    }
}
