using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public static class ImpresionColores
    {
        /// <summary>
        /// Invierte colores de la consola. Esto posibilita que los espacios
        /// asignados a la cadena (nombre de cada nodo) se muestren en 
        /// pantalla de esta manera: (espacio pintado) A (espacio pintado)
        /// </summary>
        public static void InvertirColores()
        {
            (Console.BackgroundColor, Console.ForegroundColor) =
                (Console.ForegroundColor, Console.BackgroundColor);
        }
    }
}
