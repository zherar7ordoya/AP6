using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controlador_Vista
{
    public class Control
    {
        object _puntero = null;
        //Constructor.
        public Control(string pNombre, object pPuntero) { Nombre = pNombre; _puntero = pPuntero; }

        //Propiedades.
        public string Nombre { get; set; }
        public object Puntero { get { return _puntero; } }
    }
}
