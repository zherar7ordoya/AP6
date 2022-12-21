using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class E_Entrega
    {
        public E_Entrega() { }

        public E_Entrega(int pId, DateTime pFecha, string pHora, E_Proveedor pProveedor, E_Gerente pGerente)
        { Id = pId; Fecha = pFecha; Hora = pHora; oProveedor = pProveedor; oGerente = pGerente; }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public E_Proveedor _Proveedor = new E_Proveedor();
        public E_Proveedor oProveedor
        {
            get { return _Proveedor; }
            set { _Proveedor = value; }
        }
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
