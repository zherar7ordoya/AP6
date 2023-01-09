namespace FullCarMultimarca.Abstracciones
{
    /// <summary>
    /// Interfaz que expone método para validar una entidad utilizado en la capa del negocio
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidable<T>
    {
        string MensajeError { get; }
        bool EsValido(T objeto);
    }
}
