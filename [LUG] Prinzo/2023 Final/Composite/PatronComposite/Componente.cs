
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

        public void Adiciona(IComponente<T> pElemento)
        {
            WriteLine(
                "Solo se adiciona a los compuestos, " +
                "no a los componentes");
        }

        public IComponente<T> Borra(T pElemento)
        {
            WriteLine("No se puede eliminar directamente");
            return this;
        }

        public IComponente<T> Busca(T pElemento)
        {
            if (pElemento.Equals(Nombre)) { return this; }
            else { return null; }
        }

        public string Muestra(int pProfundidad)
        {
            return new string('-', pProfundidad) + Nombre + "\n\r";
        }
    }

}
