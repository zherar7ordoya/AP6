using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAO;
using Entidad;


namespace PermisoComposite
{
    public class PermisoSimple : Permiso
    {
        //Declaro un objeto de entidad permiso.
        private E_Permiso oPermiso;
        //Asigno a las propiedades heredadas de permiso, los valores de la entidad permiso.
        public override string Id { get => oPermiso.Id; set { oPermiso.Id = value; } }

        public override string Nombre { get => oPermiso.Nombre; set { oPermiso.Nombre = value; } }

        public override string Tipo { get => oPermiso.Tipo; set { oPermiso.Tipo = value; } }
        //Constructor.
        public PermisoSimple(E_Permiso p)
        {
            oPermiso = p;
        }
        //Sobreescribo el metodo declarado en la clase permiso, para implementarlo.
        public override List<Permiso> RetornaPermiso()
        {
            return new List<Permiso>() { this };
        }

        public override string ToString()
        {
            return Id.ToString();
        }

    }
}
