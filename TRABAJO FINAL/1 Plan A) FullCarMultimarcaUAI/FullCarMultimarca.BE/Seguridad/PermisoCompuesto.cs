using System.Collections.Generic;

namespace FullCarMultimarca.BE.Seguridad
{
    public class PermisoCompuesto : Permiso
    {
        List<Permiso> _permisos;
        
        public PermisoCompuesto(string pCodigo) : base(pCodigo)
        {
            _permisos = new List<Permiso>();
        }
        public override void AgregarPermiso(Permiso Ppermiso)
        {
            _permisos.Add(Ppermiso);
        }     
        public override List<Permiso> ObtenerPermisos()
        {
            return _permisos;
        }       
    }
}
