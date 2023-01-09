using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class E_LogIn
    {
        public E_LogIn() { }

        public E_LogIn(int pNumero, DateTime pFecha, E_Usuario pUsuario) { Numero = pNumero; Fecha = pFecha; oUsuario = pUsuario; }

        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public E_Usuario _Usuario = new E_Usuario();
        public E_Usuario oUsuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }
    }
}
