namespace FullCarMultimarca.Abstracciones
{
    /// <summary>
    /// Interfaz que expone los métodos a implementar cuando un objeto se puede autorizar/rechazar
    /// </summary>    
    public interface IAutorizable<T>
    {
        void Rechazar(T objeto);
        void Autorizar(T objeto, bool autorizacionAPerdida);

    }
}
