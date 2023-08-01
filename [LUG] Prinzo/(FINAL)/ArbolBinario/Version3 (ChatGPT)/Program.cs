////////10////////20////////30////////40////////50////////60////////70////////80////////90///////100///////110///////120


using System;
using System.Collections.Generic;


namespace Version3
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
        private ArbolNodo _raiz;
        private int _contador;
        private readonly IComparer<int> _comparer = Comparer<int>.Default;

        public ArbolNodo Raiz => _raiz;

        public ArbolBinario()
        {
            _raiz = null;
            _contador = 0;
        }

        public void Imprimir()
        {
            ArbolBinarioImpresor.Imprimir(Raiz);
        }

        public bool AgregarNodo(int pItem)
        {
            if (_raiz == null)
            {
                _raiz = new ArbolNodo(pItem);
                _contador++;
                return true;
            }
            else
            {
                return AgregarSubnodo(_raiz, pItem);
            }
        }

        private bool AgregarSubnodo(ArbolNodo pNodo, int pItem)
        {
            var resultadoComparado = _comparer.Compare(pNodo.Item, pItem);

            if (resultadoComparado < 0)
            {
                if (pNodo.Derecha == null)
                {
                    pNodo.Derecha = new ArbolNodo(pItem);
                    _contador++;
                    return true;
                }
                else
                {
                    return AgregarSubnodo(pNodo.Derecha, pItem);
                }
            }
            else if (resultadoComparado > 0)
            {
                if (pNodo.Izquierda == null)
                {
                    pNodo.Izquierda = new ArbolNodo(pItem);
                    _contador++;
                    return true;
                }
                else
                {
                    return AgregarSubnodo(pNodo.Izquierda, pItem);
                }
            }
            else
            {
                return false;
            }
        }
    }




    public class ArbolNodo
    {
        public int Item { get; }

        public ArbolNodo Derecha { get; set; }

        public ArbolNodo Izquierda { get; set; }

        public ArbolNodo(int pItem)
        {
            Item = pItem;
        }
    }



    public static class ArbolBinarioImpresor
    {
        // Clase interna que almacena información sobre un nodo del árbol para su impresión
        private class NodoInfo
        {
            public ArbolNodo Nodo { get; set; }    // Nodo actual
            public string Texto { get; set; }      // Representación del valor del nodo en formato de texto
            public int PosicionInicial { get; set; } // Posición inicial del nodo en la consola
            public int Tamaño => Texto.Length;     // Tamaño del texto del nodo
            public int PosicionFinal               // Posición final del nodo en la consola
            {
                get { return PosicionInicial + Tamaño; }
                set { PosicionInicial = value - Tamaño; }
            }
            public NodoInfo Padre { get; set; }    // Nodo padre del nodo actual
            public NodoInfo Izquierda { get; set; } // Nodo hijo izquierdo del nodo actual
            public NodoInfo Derecha { get; set; }   // Nodo hijo derecho del nodo actual
        }

        // Método para imprimir el árbol binario
        public static void Imprimir(this ArbolNodo pRaiz,
                                    int pMargenSuperior = 2,
                                    int pMargenIzquierdo = 2)
        {
            if (pRaiz == null) return; // Si el árbol está vacío, no se imprime nada

            int raizMargenSuperior = Console.CursorTop + pMargenSuperior;
            var lista = new List<NodoInfo>(); // Lista para almacenar la información de los nodos
            var nodoActual = pRaiz; // Nodo actual que se está procesando

            for (int nivel = 0; nodoActual != null; nivel++)
            {
                // Crear una nueva NodoInfo con la información del nodo actual
                var nodoInfo = new NodoInfo
                {
                    Nodo = nodoActual,
                    Texto = nodoActual.Item.ToString(" 0 ")
                };

                // Actualizar la posición del nodo en la lista según el nivel actual
                if (nivel < lista.Count)
                {
                    nodoInfo.PosicionInicial = lista[nivel].PosicionFinal + 1;
                    lista[nivel] = nodoInfo;
                }
                else
                {
                    nodoInfo.PosicionInicial = pMargenIzquierdo;
                    lista.Add(nodoInfo);
                }

                if (nivel > 0)
                {
                    // Asignar el nodo actual como hijo izquierdo o derecho de su padre
                    nodoInfo.Padre = lista[nivel - 1];
                    if (nodoActual == nodoInfo.Padre.Nodo.Izquierda)
                    {
                        nodoInfo.Padre.Izquierda = nodoInfo;
                        nodoInfo.PosicionFinal = Math.Max(nodoInfo.PosicionFinal, nodoInfo.Padre.PosicionInicial);
                    }
                    else
                    {
                        nodoInfo.Padre.Derecha = nodoInfo;
                        nodoInfo.PosicionInicial = Math.Max(nodoInfo.PosicionInicial, nodoInfo.Padre.PosicionFinal);
                    }
                }

                nodoActual = nodoActual.Izquierda ?? nodoActual.Derecha;

                // Imprimir los ángulos entre nodos en el mismo nivel
                for (; nodoActual == null; nodoInfo = nodoInfo.Padre)
                {
                    ImprimeAngulares(nodoInfo, raizMargenSuperior + 2 * nivel);

                    if (--nivel < 0) break;

                    if (nodoInfo == nodoInfo.Padre.Izquierda)
                    {
                        nodoInfo.Padre.PosicionInicial = nodoInfo.PosicionFinal;
                        nodoActual = nodoInfo.Padre.Nodo.Derecha;
                    }
                    else
                    {
                        if (nodoInfo.Padre.Izquierda == null)
                            nodoInfo.Padre.PosicionFinal = nodoInfo.PosicionInicial;
                        else
                            nodoInfo.Padre.PosicionInicial += (nodoInfo.PosicionInicial - nodoInfo.Padre.PosicionFinal) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, raizMargenSuperior + 2 * lista.Count - 1);
        }

        // Método para imprimir los ángulos entre nodos
        private static void ImprimeAngulares(NodoInfo pItem, int pSuperior)
        {
            IntercambiarColores();
            ImprimeNodos(pItem.Texto, pSuperior, pItem.PosicionInicial);
            IntercambiarColores();

            if (pItem.Izquierda != null)
            {
                ImprimeHorizontales(pSuperior + 1,
                                    "┌",
                                    "┘",
                                    pItem.Izquierda.PosicionInicial + pItem.Izquierda.Tamaño / 2,
                                    pItem.PosicionInicial);
            }
            if (pItem.Derecha != null)
            {
                ImprimeHorizontales(pSuperior + 1,
                                    "└",
                                    "┐",
                                    pItem.PosicionFinal - 1,
                                    pItem.Derecha.PosicionInicial + pItem.Derecha.Tamaño / 2);
            }
        }

        // Método para imprimir las líneas horizontales entre nodos
        private static void ImprimeHorizontales(int pSuperior,
                                                string pInicio,
                                                string pFinal,
                                                int pPosicionInicial,
                                                int pPosicionFinal)
        {
            ImprimeNodos(pInicio, pSuperior, pPosicionInicial);
            ImprimeNodos("─", pSuperior, pPosicionInicial + 1, pPosicionFinal - 1);
            ImprimeNodos(pFinal, pSuperior, pPosicionFinal);
        }

        // Método para imprimir un nodo en una posición dada
        private static void ImprimeNodos(string pTexto,
                                         int pSuperior,
                                         int pIzquierda,
                                         int pDerecha = -1)
        {
            Console.SetCursorPosition(pIzquierda, pSuperior);
            if (pDerecha < 0) pDerecha = pIzquierda + pTexto.Length;
            while (Console.CursorLeft < pDerecha) Console.Write(pTexto);
        }

        // Método para intercambiar los colores de fondo y texto en la consola
        private static void IntercambiarColores()
        {
            // Se utiliza el patrón de desestructuración de tuplas para intercambiar los colores
            (Console.BackgroundColor, Console.ForegroundColor) =
                (Console.ForegroundColor, Console.BackgroundColor);
        }
    }


}
