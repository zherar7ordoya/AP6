using System.Text;
using static System.Console;



//*----------------------------------> * <----------------------------------*\\



#region THE CLIENT

class PatronComposición
{
    static void Main()
    {
        IComponente<string> album = new Contenedor<string>("Album");
        IComponente<string> nodo = album;
        string[] cadena;
        string instrucción, parámetro;

        // Create and manipulate a structure
        StreamReader archivo = new StreamReader("Composite.dat");
        do
        {
            string? línea = archivo.ReadLine();

            if (línea == null) { break; }

            WriteLine("\t\n" + línea);
            cadena = línea.Split(' ');
            instrucción = cadena[0];

            if (cadena.Length > 1) { parámetro = cadena[1]; }
            else { parámetro = null; }

            switch (instrucción)
            {
                case "AddSet":
                    IComponente<string> componente = new Contenedor<string>(parámetro);
                    nodo.Agrega(componente);
                    nodo = componente;
                    break;
                case "AddPhoto":
                    nodo.Agrega(new Componente<string>(parámetro));
                    break;
                case "Remove":
                    nodo = nodo.Borra(parámetro);
                    break;
                case "Find":
                    nodo = album.Encuentra(parámetro);
                    break;
                case "Display":
                    WriteLine(album.Muestra(0));
                    break;
                case "Quit":
                    break;
            }
        } while (!instrucción.Equals("Quit"));
    }
}

#endregion



#region THE INTERFACE

public interface IComponente<T>
{
    // Métodos
    void Agrega(IComponente<T> componente);
    IComponente<T> Borra(T cadena);
    string Muestra(int cantidad);
    IComponente<T>? Encuentra(T cadena);

    // Propiedades
    T Nombre { get; set; }
}

#endregion



#region THE COMPONENT

public class Componente<T> : IComponente<T>
{
    public T Nombre { get; set; }

    public Componente(T nombre)
    {
        this.Nombre = nombre;
    }

    // Solo válido para el Contenedor
    public void Agrega(IComponente<T> componente)
    {
        WriteLine("Cannot add to an item");
    }

    // Solo válido para el Contenedor
    public IComponente<T> Borra(T cadena)
    {
        WriteLine("Cannot remove directly");
        return this;
    }

    public string Muestra(int cantidad)
    {
        return new string('-', cantidad) + Nombre + "\n";
    }

    public IComponente<T>? Encuentra(T cadena)
    {
        if (cadena == null) { return null; }
        if (cadena.Equals(Nombre)) { return this; }
        else { return null; }
    }
}

#endregion



#region THE COMPOSITE

public class Contenedor<T> : IComponente<T>
{
    readonly List<IComponente<T>> listado;
    public T Nombre { get; set; }

    public Contenedor(T nombre)
    {
        Nombre = nombre;
        listado = new List<IComponente<T>>();
    }

    public void Agrega(IComponente<T> componente)
    {
        listado.Add(componente);
    }

    IComponente<T> portador = null;

    // Finds the item from a particular point in the structure
    // and returns the composite from which it was removed.
    // If not found, return the point as given.
    public IComponente<T> Borra(T cadena)
    {
        portador = this;
        IComponente<T> item = portador.Encuentra(cadena);
        if (portador != null)
        {
            (portador as Contenedor<T>).listado.Remove(item);
            return portador;
        }
        else { return this; }
    }

    // Recursively looks for an item.
    // Returns its reference (or else null).
    public IComponente<T> Encuentra(T cadena)
    {
        portador = this;

        if (Nombre.Equals(cadena)) { return this; }

        IComponente<T>? encontrado = null;

        foreach (IComponente<T> componente in listado)
        {
            encontrado = componente.Encuentra(cadena);
            if (encontrado != null) { break; }
        }

        return encontrado;
    }

    // Displays items in a format indicating their level in the composite structure
    public string Muestra(int cantidad)
    {
        StringBuilder cadena = new(new String('-', cantidad));
        cadena.Append("Set " + Nombre + " length :" + listado.Count + "\n");
        foreach (IComponente<T> componente in listado)
        {
            cadena.Append(componente.Muestra(cantidad + 2));
        }
        return cadena.ToString();
    }
}

#endregion