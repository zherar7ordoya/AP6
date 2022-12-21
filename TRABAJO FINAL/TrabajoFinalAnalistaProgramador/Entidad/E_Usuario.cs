using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class E_Usuario
    {
        public E_Usuario()
        {
        }

        public E_Usuario(Int32 pId, DateTime pFechaAlta, string pNombreUsuario, string pContraseña, bool pBloqueado, E_Permiso pPermiso)
        {
            idUsuario = pId; fechaAlta = pFechaAlta; Nombre = pNombreUsuario; Contraseña = pContraseña; Bloqueado = pBloqueado; oPermiso = pPermiso; ;
        }

        public Int32 idUsuario { get; set; }
        public DateTime fechaAlta { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public bool Bloqueado { get; set; }
        public E_Permiso _Permiso = new E_Permiso();
        public E_Permiso oPermiso
        {
            get { return _Permiso; }
            set { _Permiso = value; }
        }


        public override string ToString()
        {
            return idUsuario.ToString();
        }
    }
}
