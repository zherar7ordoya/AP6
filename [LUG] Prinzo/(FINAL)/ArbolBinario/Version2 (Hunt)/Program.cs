/**
 * Developer/s: Gerardo Tordoya
 * Description: Visualizador de Árboles Binarios
 * Create Date: 2022-10-10
 * Update Date: 2023-07-23
 * Forked From: https://stackoverflow.com/a/36496436/14009797
 */

using System;

using static System.Console;


namespace Version2
{
    class Program
    {
        static void Main()
        {
            // ARMAR EL ÁRBOL A IMPRIMIR
            /**
             * Los métodos "PadXXX(Int32, char)" del tipo de datos "string"
             * devuelven una nueva cadena que alinea a la izquierda/derecha
             * los caracteres de la instancia e inserta a la izquierda/derecha
             * un carácter Unicode especificado hasta alcanzar la longitud
             * total especificada.
             * Parece preferible usar "PadXXX(Int32)" porque devuelve una
             * nueva cadena que alinea a la izquierda/derecha los caracteres
             * de la instancia e inserta espacios en blanco a la
             * izquierda/derecha hasta alcanzar la longitud total
             * especificada, que es exactamente lo que hizo el autor original.
             */


            NodoExterno raiz = new NodoExterno()
            {
                Nombre = "G",
                Izquierda = new NodoExterno
                {
                    Nombre = "E"
                },
                Derecha = new NodoExterno
                {
                    Nombre = "R"
                }
            };

            raiz.Izquierda.Izquierda = new NodoExterno
            {
                Nombre = "A"
            };

            raiz.Izquierda.Derecha = new NodoExterno
            {
                Nombre = "R"
            };

            raiz.Derecha.Izquierda = new NodoExterno
            {
                Nombre = "D"
            };

            raiz.Derecha.Derecha = new NodoExterno
            {
                Nombre = "O"
            };


            // IMPRIMIR LO ARMADO
            ImpresionBase.Imprimir(raiz);
            _ = ReadKey();
        }
    }
}
