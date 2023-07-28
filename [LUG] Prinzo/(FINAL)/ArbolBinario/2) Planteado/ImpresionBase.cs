using System;
using System.Collections.Generic;


namespace BinaryTree
{
    public static partial class ImpresionBase
    {
        // ESTE ES EL LLAMADO POR MAIN
        public static void Imprimir(
            this NodoExterno pRaiz,
            int pMargenSuperior = 0,
            int pMargenIzquierdo = 2)
        {
            // Protocolo de Seguridad: si es null, no continúes
            if (pRaiz == null) return;

            int cursorSuperior = Console.CursorTop + pMargenSuperior;
            List<NodoInterno> lista = new List<NodoInterno>();
            NodoExterno proximo = pRaiz;

            for (int nivel = 0; proximo != null; nivel++)
            {
                NodoInterno item = new NodoInterno
                {
                    Externo = proximo,
                    Texto = proximo.Nombre
                };

                if (nivel < lista.Count)
                {
                    item.PosicionInicial = lista[nivel].PosicionFinal + 1;
                    lista[nivel] = item;
                }
                else
                {
                    item.PosicionInicial = pMargenIzquierdo;
                    lista.Add(item);
                }

                if (nivel > 0)
                {
                    item.NodoPadre = lista[nivel - 1];

                    if (proximo == item.NodoPadre.Externo.Izquierda)
                    {
                        item.NodoPadre.HijoIzquierda = item;
                        item.PosicionFinal = Math.Max(
                            item.PosicionFinal,
                            item.NodoPadre.PosicionInicial);
                    }
                    else
                    {
                        item.NodoPadre.HijoDerecha = item;
                        item.PosicionInicial = Math.Max(
                            item.PosicionInicial,
                            item.NodoPadre.PosicionFinal);
                    }
                }

                // El operador de uso combinado de NULL ?? devuelve el valor
                // del operando izquierdo si no es null; en caso contrario,
                // evalúa el operando derecho y devuelve su resultado.
                proximo = proximo.Izquierda ?? proximo.Derecha;

                /*
                 * The for statement works like:
                 * for (initialization; test-condition; update)
                 * 
                 * And any or all of those three can be omitted (left blank).
                 * So:
                 * 
                 * for (;;) is an infinite loop equivalent to while (true)
                 * because there is no test condition.
                 * In fact, for (int i=0; ;i++) would also be an infinite loop.
                 * The loop will still be interrupted if there's a break
                 * statement in the loop body, or a call to exit(), etc.
                 * 
                 * for ( ; *s != '\0'; s++) is a loop with no initialization.
                 * s will point to the beginning of (probably) a string and is
                 * incremented until it reaches the null character '\0'
                 * denoting end-of-string. This essentially means loop through
                 * all characters of the string s.
                 * 
                 */
                for (; proximo == null; item = item.NodoPadre)
                {
                    // Usa la 1ra sobrecarga
                    ImpresionHerramientas.ImprimeConectoresAngulares(item, cursorSuperior + 2 * nivel);

                    // Salida del loop (prefijo --: modifica variable antes de
                    // evaluarla; posfijo -- usa variable y luego la modifica).
                    if (--nivel < 0) break;

                    if (item == item.NodoPadre.HijoIzquierda)
                    {
                        item.NodoPadre.PosicionInicial = item.PosicionFinal;
                        proximo = item.NodoPadre.Externo.Derecha;
                    }
                    else
                    {
                        if (item.NodoPadre.HijoIzquierda == null)
                            item.NodoPadre.PosicionFinal = item.PosicionInicial;
                        else
                            item.NodoPadre.PosicionInicial += (item.PosicionInicial - item.NodoPadre.PosicionFinal) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, cursorSuperior + 2 * lista.Count - 1);
        }
    }
}
