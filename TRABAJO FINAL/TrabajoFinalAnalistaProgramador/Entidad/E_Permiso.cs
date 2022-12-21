using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class E_Permiso
    {
        public E_Permiso() { }
        public E_Permiso(string pId, string pNombre, string pTipo) { Id = pId; Nombre = pNombre; Tipo = pTipo; }

        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
