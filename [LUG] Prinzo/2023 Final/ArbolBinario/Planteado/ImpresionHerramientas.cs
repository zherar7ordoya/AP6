using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static BinaryTree.ImpresionBase;

namespace BinaryTree
{
    public static class ImpresionHerramientas
    {
        public static void ImprimeConectoresAngulares(NodoInterno pItem, int pSuperior)
        {
            ImpresionColores.InvertirColores();

            ImprimeNodos(pItem.Texto, pSuperior, pItem.PosicionInicial);

            ImpresionColores.InvertirColores();

            if (pItem.HijoIzquierda != null)
            {
                ImprimeConectoresHorizontales(
                    pSuperior + 1,
                    "┌",
                    "┘",
                    pItem.HijoIzquierda.PosicionInicial + pItem.HijoIzquierda.Tamaño / 2,
                    pItem.PosicionInicial);
            }

            if (pItem.HijoDerecha != null)
            {
                ImprimeConectoresHorizontales(
                    pSuperior + 1,
                    "└",
                    "┐",
                    pItem.PosicionFinal - 1,
                    pItem.HijoDerecha.PosicionInicial + pItem.HijoDerecha.Tamaño / 2);
            }
        }

        public static void ImprimeNodos(
            string pTexto,
            int pArriba,
            int pIzquierda,
            int pDerecha = -1)
        {
            // Ubica el cursor
            Console.SetCursorPosition(pIzquierda, pArriba);

            // ¿¿??
            if (pDerecha < 0) pDerecha = pIzquierda + pTexto.Length;

            // ¿Escribe hasta que se agota el texto?
            while (Console.CursorLeft < pDerecha) Console.Write(pTexto);
        }

        public static void ImprimeConectoresHorizontales(
            int pArriba,
            string pComienzo,
            string pFinal,
            int pPosicionInicial,
            int pPosicionFinal)
        {
            ImprimeNodos(pComienzo, pArriba, pPosicionInicial);
            ImprimeNodos("─", pArriba, pPosicionInicial + 1, pPosicionFinal);
            ImprimeNodos(pFinal, pArriba, pPosicionFinal);
        }
    }
}
