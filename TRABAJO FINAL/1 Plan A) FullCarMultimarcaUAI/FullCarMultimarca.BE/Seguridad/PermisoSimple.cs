using System;
using System.Collections.Generic;

namespace FullCarMultimarca.BE.Seguridad
{
    public class PermisoSimple : Permiso
    {
        public PermisoSimple(string codigo) : base(codigo)
        {

        }

        public override List<Permiso> ObtenerPermisos()
        {
            return new List<Permiso>() { this };
        }
        public override void AgregarPermiso(Permiso permiso)
        {
            throw new NotImplementedException("Un permiso simple no puede contener permisos.");
        }
    }
}
