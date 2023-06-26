using System.Text;
using static System.Console;

#region  *******************************\ MAIN /*******************************

IComponente<string> arbol = new Compuesto<string>("root");
IComponente<string> trabajo = arbol;
string opcion = string.Empty;
string dato = string.Empty;

while (opcion != "6")
{
    WriteLine("Estoy en {0}", trabajo.Nombre);
    WriteLine
        (
        "1) Adicionar Compuesto\n" +
        "2) Adicionar Componente\n" +
        "3) Borrar\n" +
        "4) Buscar\n" +
        "5) Mostrar\n" +
        "6) Salir\n"
        );
    opcion = ReadLine();
    WriteLine("*-----------------------*");

    if (opcion =="1")
    {
        WriteLine("Nombre del Compuesto: ");
        dato = ReadLine();
        IComponente<string> c = new Compuesto<string>(dato);
        trabajo.Adiciona(c);
        trabajo = c;
    }
    if (opcion == "2")
    {
        WriteLine("Nombre del Componente: ");
        dato = ReadLine();
        trabajo.Adiciona(new Componente<string>(dato));
    }
    if (opcion == "3")
    {
        WriteLine("Elemento a Borrar: ");
        dato = ReadLine();
        trabajo = trabajo.Borra(dato);
    }
    if (opcion == "4")
    {
        WriteLine("Elemento a Buscar: ");
        dato = ReadLine();
        trabajo = arbol.Busca(dato);
    }
    if (opcion == "5")
    {
        WriteLine(arbol.Muestra(0));
    }
}

#endregion  *-----------------------------------------------------------------*



interface IComponente<T>
{
    T Nombre { get; set; }
    void Adiciona(IComponente<T> pElemento);
    IComponente<T> Borra(T pElemento);
    IComponente<T> Busca(T pElemento);
    string Muestra(int pProfundidad);
}


class Componente<T> : IComponente<T>
{
    public T Nombre { get; set;}

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


class Compuesto<T> : IComponente<T>
{
    readonly List<IComponente<T>> elementos;
    public T Nombre { get; set; }
    public Compuesto(T pNombre)
    {
        Nombre = pNombre;
        elementos = new List<IComponente<T>>();
    }

    public void Adiciona(IComponente<T> pElemento) => elementos.Add(pElemento);

    public IComponente<T> Borra(T pElemento)
    {
        IComponente<T> elemento = this.Busca(pElemento);
        if (elemento != null)
        {
            (this as Compuesto<T>).elementos.Remove(elemento);
        }
        return this;
    }

    public IComponente<T> Busca(T pElemento)
    {
        if (Nombre.Equals(pElemento)) { return this; }
        IComponente<T> encontrado = null;
        foreach (IComponente<T> elemento in elementos)
        {
            encontrado = elemento.Busca(pElemento);
            if (encontrado != null) { break; }
        }
        return encontrado;
    }

    public string Muestra(int pProfundidad)
    {
        StringBuilder infoElemento = new StringBuilder(new String('-', pProfundidad));
        infoElemento.Append("Compuesto: " + Nombre + " elementos: " + elementos.Count + "\r\n");

        foreach (IComponente<T> elemento in elementos)
        {
            infoElemento.Append(elemento.Muestra(pProfundidad + 1));
        }

        return infoElemento.ToString();
    }
}