using System;
using System.Collections.Generic;

namespace Refactored
{
    class Program
    {
        static void Main()
        {
            ArbolBinario arbol = new ArbolBinario();
            arbol.AgregarNodo(6);
            arbol.AgregarNodo(2);
            arbol.AgregarNodo(3);
            arbol.AgregarNodo(11);
            arbol.AgregarNodo(30);
            arbol.AgregarNodo(9);
            arbol.AgregarNodo(13);
            arbol.AgregarNodo(18);
            arbol.AgregarNodo(1);
            arbol.AgregarNodo(4);
            arbol.AgregarNodo(8);
            arbol.Imprimir();
            Console.ReadKey();
        }
    }

    public class ArbolBinario
    {
        private ArbolNodo _raiz;
        private int _contador;
        private readonly IComparer<int> _comparer = Comparer<int>.Default;

        public ArbolNodo Raiz { get { return _raiz; } }

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
            int resultadoComparado = _comparer.Compare(pNodo.Item, pItem);

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
        public int Item;
        public ArbolNodo Derecha;
        public ArbolNodo Izquierda;

        public ArbolNodo(int pItem)
        {
            Item = pItem;
        }
    }



    public static class ArbolBinarioImpresor
    {
        class NodoInfo
        {
            public ArbolNodo Nodo;
            public string Texto;
            public int PosicionInicial;
            public int Tamaño { get { return Texto.Length; } }
            public int PosicionFinal { get { return PosicionInicial + Tamaño; } set { PosicionInicial = value - Tamaño; } }
            public NodoInfo Padre, Izquierda, Derecha;
        }

        public static void Imprimir(this ArbolNodo pRaiz, int pMargenSuperior = 2, int pMargenIzquierdo = 2)
        {
            if (pRaiz == null) return;
            int raizMargenSuperior = Console.CursorTop + pMargenSuperior;
            var ultimo = new List<NodoInfo>();
            var proximo = pRaiz;

            for (int nivel = 0; proximo != null; nivel++)
            {
                var item = new NodoInfo { Nodo = proximo, Texto = proximo.Item.ToString(" 0 ") };

                if (nivel < ultimo.Count)
                {
                    item.PosicionInicial = ultimo[nivel].PosicionFinal + 1;
                    ultimo[nivel] = item;
                }
                else
                {
                    item.PosicionInicial = pMargenIzquierdo;
                    ultimo.Add(item);
                }

                if (nivel > 0)
                {
                    item.Padre = ultimo[nivel - 1];
                    if (proximo == item.Padre.Nodo.Izquierda)
                    {
                        item.Padre.Izquierda = item;
                        item.PosicionFinal = Math.Max(item.PosicionFinal, item.Padre.PosicionInicial);
                    }
                    else
                    {
                        item.Padre.Derecha = item;
                        item.PosicionInicial = Math.Max(item.PosicionInicial, item.Padre.PosicionFinal);
                    }
                }

                proximo = proximo.Izquierda ?? proximo.Derecha;

                for (; proximo == null; item = item.Padre)
                {
                    ImprimeAngulares(item, raizMargenSuperior + 2 * nivel);
                    if (--nivel < 0) break;
                    if (item == item.Padre.Izquierda)
                    {
                        item.Padre.PosicionInicial = item.PosicionFinal;
                        proximo = item.Padre.Nodo.Derecha;
                    }
                    else
                    {
                        if (item.Padre.Izquierda == null)
                            item.Padre.PosicionFinal = item.PosicionInicial;
                        else
                            item.Padre.PosicionInicial += (item.PosicionInicial - item.Padre.PosicionFinal) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, raizMargenSuperior + 2 * ultimo.Count - 1);
        }

        private static void ImprimeAngulares(NodoInfo pItem, int pSuperior)
        {
            IntercambiarColores();
            ImprimeNodos(pItem.Texto, pSuperior, pItem.PosicionInicial);
            IntercambiarColores();
            if (pItem.Izquierda != null)
                ImprimeHorizontales(pSuperior + 1, "┌", "┘", pItem.Izquierda.PosicionInicial + pItem.Izquierda.Tamaño / 2, pItem.PosicionInicial);
            if (pItem.Derecha != null)
                ImprimeHorizontales(pSuperior + 1, "└", "┐", pItem.PosicionFinal - 1, pItem.Derecha.PosicionInicial + pItem.Derecha.Tamaño / 2);
        }

        private static void ImprimeHorizontales(int pSuperior, string pInicio, string pFinal, int pPosicionInicial, int pPosicionFinal)
        {
            ImprimeNodos(pInicio, pSuperior, pPosicionInicial);
            ImprimeNodos("─", pSuperior, pPosicionInicial + 1, pPosicionFinal);
            ImprimeNodos(pFinal, pSuperior, pPosicionFinal);
        }

        private static void ImprimeNodos(string pTexto, int pSuperior, int pIzquierda, int pDerecha = -1)
        {
            Console.SetCursorPosition(pIzquierda, pSuperior);
            if (pDerecha < 0) pDerecha = pIzquierda + pTexto.Length;
            while (Console.CursorLeft < pDerecha) Console.Write(pTexto);
        }

        private static void IntercambiarColores()
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = Console.BackgroundColor;
            Console.BackgroundColor = color;
        }
    }


}
