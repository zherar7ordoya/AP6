using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class E_BackUp
    {
        public E_BackUp() { }

        public E_BackUp(int pCodigo, E_Usuario pUsuario, DateTime pFecha) { Codigo = pCodigo; oUsuario = pUsuario; Fecha = pFecha; }

        public int Codigo { get; set; }
        public E_Usuario _Usuario = new E_Usuario();
        public E_Usuario oUsuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }
        public DateTime Fecha { get; set; }

    }
}
