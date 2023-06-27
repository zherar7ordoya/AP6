/*...
Uso de tipos genéricos
...*/

namespace PatronComposite
{
    public interface IComponente<T>
    {
        T Nombre { get; set; }
        void Adicionar(IComponente<T> pElemento);
        IComponente<T> Borrar(T pElemento);
        IComponente<T> Buscar(T pElemento);
        string Mostrar(int pProfundidad);
    }
}
