using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class E_Marca
    {
        public E_Marca() { }

        public E_Marca(int pCodigo, string pNombre, E_Gerente pGerente) { Codigo = pCodigo; Nombre = pNombre; oGerente = pGerente; }

        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public E_Gerente _Gerente = new E_Gerente();
        public E_Gerente oGerente
        {
            get { return _Gerente; }
            set { _Gerente = value; }
        }

        public override string ToString()
        {
            return Codigo.ToString();
        }
    }
}
