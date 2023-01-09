using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using System.Data;
using System.Windows.Forms;
using Entidad;

namespace PermisoComposite
{
    public class PermisoCompuesto : Permiso
    {
        //Declaro un objeto de entidad permiso.
        private E_Permiso oPermiso;
        //Creo una lista de permisos.
        private  List<Permiso> listaPermisos;
        //Creo una lista auxiliar.
        private List<Permiso> listaAux;
        //Asigno a las propiedades heredadas de permiso, los valores de la entidad permiso.
        public override string Id { get => oPermiso.Id; set { oPermiso.Id = value; } }

        public override string Nombre { get => oPermiso.Nombre; set { oPermiso.Nombre = value; } }

        public override string Tipo { get => oPermiso.Tipo; set { oPermiso.Tipo = value; } }

        public override string ToString()
        {
            return Id.ToString();
        }

        public List<Permiso> ListaPermisos => listaPermisos;
        //Constructor.
        public PermisoCompuesto(E_Permiso p)
        {
            oPermiso = p;
            listaPermisos = new List<Permiso>();
        }
        //Metodo Añadir, para agregar un permiso a la lista.
        public void Añadir(Permiso oPermiso)
        {
            listaPermisos.Add(oPermiso);
        }

        public void AñadirPermisos(Permiso[] oPermisos)
        {
            listaPermisos.AddRange(oPermisos);
        }
        //Metodo Remover, para quitar un permiso de la lista.
        public void Remover(Permiso oPermiso)
        {
            listaPermisos.Remove(oPermiso);
        }
        //Sobreescribo el metodo retorna permiso, para implementarlo.
        public override List<Permiso> RetornaPermiso()
        {
            listaAux = new List<Permiso>();
            //Llamo al metodo recursivo.
            RetornarPermisosRecursivo(listaPermisos);
            //Retorno la lista auxiliar.
            return listaAux;
        }
        //Metodo recursivo.
        private void RetornarPermisosRecursivo(List<Permiso> LP)
        {
            //Recorro la lista recibida como parametro.
            foreach (Permiso permiso in LP)
            {
                //Si el permiso es simple.
                if (permiso is PermisoSimple)
                {   //Lo añado a la lista auxiliar.
                    listaAux.Add(permiso);
                }
                else
                {
                    //Si no retorno el permiso.
                    RetornarPermisosRecursivo(permiso.RetornaPermiso());
                }
            }
        }
    }
}
