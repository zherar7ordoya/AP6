using System;
using System.Collections.Generic;
using static System.Console;


/**
 * En este ejemplo, se crean dos instancias de la clase ListaGenerica, una para
 * almacenar enteros (ListaGenerica<int>) y otra para almacenar cadenas
 * (ListaGenerica<string>). Ambas instancias pueden almacenar y recuperar
 * elementos de forma segura y coherente, según el tipo de dato especificado.
 * Este ejemplo ilustra cómo la clase genérica ListaGenerica proporciona
 * reutilización de código al adaptarse a diferentes tipos de datos,
 * flexibilidad al permitir la parametrización con tipos específicos,
 * seguridad de tipos en tiempo de compilación y mejora del rendimiento al
 * evitar conversiones y operaciones innecesarias.
 */

namespace ClasesGenericasChatGPT
{
    class Program
    {
        static void Main()
        {
            ListaGenerica<int> listaEnteros = new ListaGenerica<int>();
            listaEnteros.AgregarElemento(10);
            listaEnteros.AgregarElemento(20);
            int primerElemento = listaEnteros.ObtenerElemento(0);
            WriteLine(primerElemento);  // Salida => 10

            ListaGenerica<string> listaStrings = new ListaGenerica<string>();
            listaStrings.AgregarElemento("Hola");
            listaStrings.AgregarElemento("Mundo");
            string segundoElemento = listaStrings.ObtenerElemento(1);
            WriteLine(segundoElemento);  // Salida => Mundo

            ReadKey();
        }
    }

    // |----------------------------------------------------------------------|

    /**
     * En este ejemplo, se ha creado una clase genérica llamada ListaGenerica. Esta
     * clase utiliza un parámetro de tipo T, que se utilizará para definir el tipo
     * de elementos que se almacenarán en la lista.
     * La clase ListaGenerica tiene un campo privado ('elementos') que es una lista
     * genérica List<T>. El constructor inicializa esta lista.
     * La clase también tiene dos métodos: AgregarElemento y ObtenerElemento. El
     * método AgregarElemento permite agregar elementos de tipo T a la lista,
     * mientras que el método ObtenerElemento devuelve el elemento en el índice
     * especificado.
     */

public class ListaGenerica<T>
    {
        private readonly List<T> elementos;

        public ListaGenerica()
        {
            elementos = new List<T>();
        }

        public void AgregarElemento(T elemento)
        {
            elementos.Add(elemento);
        }

        public T ObtenerElemento(int indice)
        {
            if (indice >= 0 && indice < elementos.Count) return elementos[indice];
            throw new IndexOutOfRangeException("El índice está fuera de rango.");
        }
    }
}
