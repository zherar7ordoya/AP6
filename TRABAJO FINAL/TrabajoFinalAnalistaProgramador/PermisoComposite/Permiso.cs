using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;


namespace PermisoComposite
{
    public abstract class Permiso
    {
        public Permiso() { }
        public Permiso(string pId, string pNombre, string pTipo) { Id = pId; Nombre = pNombre; Tipo = pTipo; }
        //Propiedades.
        public abstract string Id { get; set; }
        public abstract string Nombre { get; set; }
        public abstract string Tipo { get; set; }
        //Declaro metodo abstracto.
        public abstract List<Permiso> RetornaPermiso();
       
    }
}
