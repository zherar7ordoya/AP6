using System;
using System.Collections.Generic;

namespace Version4
{
    class Program
    {
        static void Main()
        {
            //Random rnd = new Random();
            ArbolBinario arbol = new ArbolBinario();

            arbol.AgregarNodo(51);

            arbol.AgregarNodo(42);
            arbol.AgregarNodo(93);

            arbol.AgregarNodo(32);
            arbol.AgregarNodo(72);
            arbol.AgregarNodo(95);

            arbol.AgregarNodo(6);
            arbol.AgregarNodo(35);
            arbol.AgregarNodo(67);
            arbol.AgregarNodo(94);

            arbol.AgregarNodo(18);
            arbol.AgregarNodo(36);
            arbol.AgregarNodo(54);
            arbol.AgregarNodo(69);

            arbol.AgregarNodo(31);
            arbol.AgregarNodo(70);

            arbol.AgregarNodo(29);

            arbol.AgregarNodo(20);

            //for (int x = 1; x < 20; x++)
            //{
            //    arbol.AgregarNodo(rnd.Next(100));
            //}

            arbol.Imprimir();
            Console.ReadKey();
        }
    }



    public class ArbolBinario
    {
        private ArbolNodo _raiz;  // Define el nodo raíz del árbol binario.
        private int _contador;    // Un contador que almacena el número de nodos en el árbol.
        private readonly IComparer<int> _comparer = Comparer<int>.Default; // Comparador de enteros para determinar la posición de los nodos.

        public ArbolNodo Raiz { get { return _raiz; } } // Propiedad pública para acceder al nodo raíz.

        public ArbolBinario()
        {
            _raiz = null;   // Inicializa la raíz del árbol como nula, ya que al inicio no hay nodos.
            _contador = 0;  // Inicializa el contador en 0, ya que al inicio no hay nodos.
        }

        public void Imprimir()
        {
            ArbolBinarioImpresor.Imprimir(Raiz); // Invoca el método "Imprimir" de la clase "ArbolBinarioImpresor" para imprimir el árbol binario.
        }

        public bool AgregarNodo(int pItem)
        {
            if (_raiz == null)
            {
                _raiz = new ArbolNodo(pItem); // Si el árbol está vacío, crea un nuevo nodo con el elemento dado y lo establece como la raíz.
                _contador++; // Incrementa el contador de nodos en 1.
                return true; // Retorna true, indicando que se pudo agregar el nodo correctamente.
            }
            else
            {
                return AgregarSubnodo(_raiz, pItem); // Si el árbol no está vacío, llama al método "AgregarSubnodo" para agregar el nuevo nodo en la posición correcta.
            }
        }

        private bool AgregarSubnodo(ArbolNodo pNodo, int pItem)
        {
            int resultadoComparado = _comparer.Compare(pNodo.Item, pItem); // Compara el valor del nodo actual con el elemento a insertar.

            if (resultadoComparado < 0) // Si el elemento a insertar es mayor que el elemento actual:
            {
                if (pNodo.Derecha == null)
                {
                    pNodo.Derecha = new ArbolNodo(pItem); // Si no hay un nodo a la derecha del nodo actual, crea un nuevo nodo con el elemento y lo coloca en la posición de la derecha.
                    _contador++; // Incrementa el contador de nodos en 1.
                    return true; // Retorna true, indicando que se pudo agregar el nodo correctamente.
                }
                else
                {
                    return AgregarSubnodo(pNodo.Derecha, pItem); // Si ya hay un nodo a la derecha del nodo actual, llama recursivamente al método "AgregarSubnodo" para agregar el nuevo nodo en la posición correcta de la rama derecha.
                }
            }
            else if (resultadoComparado > 0) // Si el elemento a insertar es menor que el elemento actual:
            {
                if (pNodo.Izquierda == null)
                {
                    pNodo.Izquierda = new ArbolNodo(pItem); // Si no hay un nodo a la izquierda del nodo actual, crea un nuevo nodo con el elemento y lo coloca en la posición de la izquierda.
                    _contador++; // Incrementa el contador de nodos en 1.
                    return true; // Retorna true, indicando que se pudo agregar el nodo correctamente.
                }
                else
                {
                    return AgregarSubnodo(pNodo.Izquierda, pItem); // Si ya hay un nodo a la izquierda del nodo actual, llama recursivamente al método "AgregarSubnodo" para agregar el nuevo nodo en la posición correcta de la rama izquierda.
                }
            }
            else // Si el elemento a insertar es igual al elemento actual, no se permite agregar duplicados:
            {
                return false; // Retorna false, indicando que no se pudo agregar el nodo debido a que ya existe un nodo con el mismo valor.
            }
        }
    }



    public class ArbolNodo
    {
        public int Item;          // Almacena el valor del nodo.
        public ArbolNodo Derecha; // Referencia al nodo hijo derecho.
        public ArbolNodo Izquierda; // Referencia al nodo hijo izquierdo.

        public ArbolNodo(int pItem)
        {
            Item = pItem; // Constructor de la clase que inicializa el valor del nodo con el valor pasado como argumento.
        }
    }


    /// <summary>
    /// La clase ArbolBinarioImpresor es una clase estática que se utiliza para
    /// imprimir visualmente un árbol binario en la consola. El método principal
    /// para esta impresión es el método de extensión Imprimir que se aplica a
    /// un nodo raíz del árbol. A continuación, una explicación de cada parte
    /// del código:
    /// 
    /// 1.
    /// class NodoInfo:
    /// Esta clase interna es utilizada para almacenar información sobre cada
    /// nodo durante la impresión. Contiene propiedades para el nodo actual, el
    /// texto que representa al nodo, la posición inicial y final del nodo en la
    /// impresión, así como referencias a sus nodos padre, hijo izquierdo y hijo
    /// derecho.
    /// 
    /// 2.
    /// public static void Imprimir(this ArbolNodo pRaiz,
    /// int pMargenSuperior = 2, int pMargenIzquierdo = 2):
    /// Este es el método de extensión utilizado para imprimir el árbol binario.
    /// Recibe el nodo raíz del árbol como argumento, así como opciones para
    /// ajustar los márgenes superiores e izquierdos de la impresión.
    /// 
    /// 3.
    /// El resto del código implementa la lógica necesaria para calcular las
    /// posiciones y espacios necesarios para la impresión del árbol binario en
    /// la consola. Utiliza una combinación de espacios en blanco y caracteres
    /// especiales (ángulos y líneas) para representar la estructura jerárquica
    /// del árbol.
    /// </summary>
    public static class ArbolBinarioImpresor
    {
        /// <summary>
        ///  El uso de NodoInfo tiene como objetivo separar la información
        ///  específica de la visualización y la impresión de la estructura del
        ///  árbol en sí, lo que facilita el mantenimiento, mejora la
        ///  legibilidad del código y permite una mayor reutilización del
        ///  algoritmo de impresión con diferentes estructuras de árbol:
        ///  
        /// Separación de responsabilidades: La clase ArbolNodo representa los
        /// nodos reales del árbol binario y es independiente de cualquier tarea
        /// relacionada con la visualización o impresión. Al separar la
        /// información necesaria para la visualización en NodoInfo, se mantiene
        /// una clara separación de responsabilidades entre la estructura del
        /// árbol y la lógica de impresión.
        /// 
        /// Cambio de contexto: Los atributos adicionales en NodoInfo están
        /// específicamente diseñados para la impresión del árbol en la consola,
        /// como las posiciones y tamaños de los nodos para ubicarlos
        /// correctamente en la visualización.Estos atributos son útiles para la
        /// lógica de impresión, pero no tienen relevancia en el ámbito de la
        /// estructura del árbol en sí.Al mantener esta información separada en
        /// NodoInfo, se evita ensuciar la estructura del árbol con atributos
        /// que solo se usan para la impresión.
        /// 
        /// Reusabilidad: La separación de la información de impresión en
        /// NodoInfo permite que el algoritmo de impresión sea más genérico y
        /// reutilizable. Esto significa que el mismo algoritmo de impresión se
        /// puede utilizar con diferentes estructuras de árbol simplemente
        /// adaptando la información necesaria en NodoInfo, en lugar de
        /// modificar la propia clase ArbolNodo.
        /// 
        /// Mantenimiento y legibilidad: Al tener una clase específica para la
        /// información de impresión, el código relacionado con la lógica de
        /// impresión se vuelve más claro y legible. Los atributos específicos
        /// de la visualización en NodoInfo son autoexplicativos y facilitan la
        /// comprensión del algoritmo de impresión.
        /// </summary>
        class NodoInfo
        {
            // Almacena el nodo actual.
            public ArbolNodo Nodo;

            // Texto que se mostrará para representar el nodo en la impresión.
            public string Texto;

            // Posición inicial del nodo en la línea de impresión.
            public int PosicionInicial;

            // Propiedad para obtener el tamaño del texto que representa el nodo.
            public int Tamaño
            {
                get { return Texto.Length; }
            }

            // Propiedad para obtener o establecer la posición final del nodo en la línea de impresión.
            public int PosicionFinal
            {
                get { return PosicionInicial + Tamaño; }
                set { PosicionInicial = value - Tamaño; }
            }

            // Referencias a los nodos padre, hijo izquierdo y hijo derecho del nodo actual.
            public NodoInfo Padre, Izquierda, Derecha;
        }

        public static void Imprimir(this ArbolNodo pRaiz,
                                    int pMargenSuperior = 2,
                                    int pMargenIzquierdo = 2)
        {
            // Si la raíz del árbol es nula, no hay nada que imprimir, así que se sale del método.
            if (pRaiz == null) return;

            // Calcula la posición superior de la raíz en la consola.
            int raizMargenSuperior = Console.CursorTop + pMargenSuperior;

            // Crea una lista para almacenar información de los nodos de cada nivel.
            var lista = new List<NodoInfo>();

            // Inicializa una variable para rastrear el nodo actual durante la impresión.
            var proximo = pRaiz;


            // Diagrama de esta estrucutura:
            //  for
            //   |
            //   +-- if (nivel < lista.Count)
            //   |
            //   +-- if (nivel > 0)
            //        |
            //        +-- if (proximo == item.Padre.Nodo.Izquierda)
            //   |
            //   +-- for
            //        |
            //        +-- if (--nivel < 0)
            //        |
            //        +-- if (item == item.Padre.Izquierda)

            for (int nivel = 0; proximo != null; nivel++)
            {
                // Crea una nueva instancia de NodoInfo para el nodo actual, con su información.
                var item = new NodoInfo
                {
                    Nodo = proximo,
                    Texto = proximo.Item.ToString(" 0 ")
                };

                if (nivel < lista.Count)
                {
                    // Calcula la posición inicial del nodo actual basándose en el último nodo impreso en el mismo nivel.
                    item.PosicionInicial = lista[nivel].PosicionFinal + 1;

                    // Reemplaza el último nodo impreso en el mismo nivel con el nodo actual.
                    lista[nivel] = item;
                }
                else
                {
                    // Si es el primer nodo en el nivel, establece su posición inicial con el margen izquierdo.
                    item.PosicionInicial = pMargenIzquierdo;

                    // Agrega el nodo actual a la lista de información de nodos del nivel actual.
                    lista.Add(item);
                }

                if (nivel > 0)
                {
                    // Establece la referencia al nodo padre del nodo actual utilizando el último nodo impreso en el nivel anterior.
                    item.Padre = lista[nivel - 1];

                    if (proximo == item.Padre.Nodo.Izquierda)
                    {
                        // Si el nodo actual es el hijo izquierdo del nodo padre, establece la referencia al hijo izquierdo del nodo padre.
                        item.Padre.Izquierda = item;

                        // Ajusta la posición final del nodo actual para evitar solapamientos con el nodo padre.
                        item.PosicionFinal = Math.Max(item.PosicionFinal, item.Padre.PosicionInicial);
                    }
                    else
                    {
                        // Si el nodo actual es el hijo derecho del nodo padre, establece la referencia al hijo derecho del nodo padre.
                        item.Padre.Derecha = item;

                        // Ajusta la posición inicial del nodo actual para evitar solapamientos con el nodo padre.
                        item.PosicionInicial = Math.Max(item.PosicionInicial, item.Padre.PosicionFinal);
                    }
                }

                // Se mueve al siguiente nodo en el recorrido, primero hacia el hijo izquierdo si existe, y si no, hacia el hijo derecho.
                proximo = proximo.Izquierda ?? proximo.Derecha;

                for (; proximo == null; item = item.Padre)
                {
                    // Imprime los ángulos en la impresión, mostrando la estructura jerárquica del árbol.
                    ImprimeAngulares(item, raizMargenSuperior + 2 * nivel);

                    // Decrementa el nivel y sale del bucle si se ha llegado a la raíz del árbol.
                    if (--nivel < 0) break;

                    if (item == item.Padre.Izquierda)
                    {
                        item.Padre.PosicionInicial = item.PosicionFinal;

                        // Se mueve al nodo hermano derecho del nodo actual.
                        proximo = item.Padre.Nodo.Derecha;
                    }
                    else
                    {
                        if (item.Padre.Izquierda == null)
                            item.Padre.PosicionFinal = item.PosicionInicial;
                        else
                            // Ajusta la posición inicial del nodo padre para evitar solapamientos con otros nodos hijos.
                            item.Padre.PosicionInicial += (item.PosicionInicial - item.Padre.PosicionFinal) / 2;
                    }
                }
            }
            // Posiciona el cursor en la última línea impresa, debajo del árbol completo.
            Console.SetCursorPosition(0, raizMargenSuperior + 2 * lista.Count - 1);
        }

        private static void ImprimeAngulares(NodoInfo pItem, int pSuperior)
        {
            // Intercambia los colores de texto y fondo para imprimir el nodo actual con colores invertidos.
            IntercambiarColores();

            // Imprime el texto que representa al nodo actual.
            ImprimeNodos(pItem.Texto,
                         pSuperior,
                         pItem.PosicionInicial);

            // Restaura los colores originales para imprimir los ángulos y ramas del árbol.
            IntercambiarColores();

            if (pItem.Izquierda != null)
                // Imprime las ramas y ángulos hacia el nodo hijo izquierdo.
                ImprimeHorizontales(pSuperior + 1,
                                    "┌",
                                    "┘",
                                    pItem.Izquierda.PosicionInicial + pItem.Izquierda.Tamaño / 2,
                                    pItem.PosicionInicial);
            if (pItem.Derecha != null)
                // Imprime las ramas y ángulos hacia el nodo hijo derecho.
                ImprimeHorizontales(pSuperior + 1,
                                    "└",
                                    "┐",
                                    pItem.PosicionFinal - 1,
                                    pItem.Derecha.PosicionInicial + pItem.Derecha.Tamaño / 2);
        }

        private static void ImprimeHorizontales(int pSuperior,
                                                string pInicio,
                                                string pFinal,
                                                int pPosicionInicial,
                                                int pPosicionFinal)
        {
            // Imprime el ángulo o punto de unión hacia la rama izquierda o derecha.
            ImprimeNodos(pInicio, pSuperior, pPosicionInicial);

            // Imprime líneas horizontales que conectan los ángulos o puntos de unión.
            ImprimeNodos("─", pSuperior, pPosicionInicial + 1, pPosicionFinal);

            // Imprime el ángulo o punto de unión hacia la rama derecha o izquierda.
            ImprimeNodos(pFinal, pSuperior, pPosicionFinal);
        }

        private static void ImprimeNodos(string pTexto,
                                         int pSuperior,
                                         int pIzquierda,
                                         int pDerecha = -1)
        {
            // Posiciona el cursor en la posición especificada para imprimir el texto.
            Console.SetCursorPosition(pIzquierda, pSuperior);

            // Calcula la posición derecha para la impresión si no se especifica.
            if (pDerecha < 0) pDerecha = pIzquierda + pTexto.Length;

            // Imprime el texto hasta alcanzar la posición derecha.
            while (Console.CursorLeft < pDerecha) Console.Write(pTexto);
        }

        private static void IntercambiarColores()
        {
            var color = Console.ForegroundColor;

            // Intercambia los colores de texto y fondo para resaltar los nodos en la impresión.
            Console.ForegroundColor = Console.BackgroundColor;

            Console.BackgroundColor = color;
        }
    }



}
