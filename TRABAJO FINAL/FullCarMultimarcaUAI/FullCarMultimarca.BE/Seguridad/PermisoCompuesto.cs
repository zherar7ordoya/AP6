﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
