using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class E_Proveedor
    {
        public E_Proveedor() { }
        
        public E_Proveedor(int pId, string pNombre, string pDireccion, string pLocalidad, string pProvincia, long pTelefono, string pEmail, bool pActivo, E_Gerente pGerente)
        { Id = pId; Nombre = pNombre; Direccion = pDireccion; Localidad = pLocalidad; Provincia = pProvincia; Telefono = pTelefono; Mail = pEmail; Activo = pActivo; oGerente = pGerente; }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public long Telefono { get; set; }
        public string Mail { get; set; }
        public bool Activo { get; set; }
        public E_Gerente _Gerente = new E_Gerente();
        public E_Gerente oGerente
        {
            get { return _Gerente; }
            set { _Gerente = value; }
        }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
