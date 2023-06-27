
using static System.Console;

namespace PatronComposite
{
    class Componente<T> : IComponente<T>
    {
        public T Nombre { get; set; }

        public Componente(T nombre)
        {
            Nombre = nombre;
        }

        public void Adicionar(IComponente<T> pElemento)
        {
            WriteLine(
                "Solo se adiciona a los compuestos, " +
                "no a los componentes");
        }

        public IComponente<T> Borrar(T pElemento)
        {
            WriteLine("No se puede eliminar directamente");
            return this;
        }

        public IComponente<T> Buscar(T pElemento)
        {
            if (pElemento.Equals(Nombre)) { return this; }
            else { return null; }
        }

        public string Mostrar(int pProfundidad)
        {
            return new string('-', pProfundidad) + Nombre + "\n\r";
        }
    }

}
