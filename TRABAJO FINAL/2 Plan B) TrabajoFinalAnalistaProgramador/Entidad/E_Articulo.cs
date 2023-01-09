using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class E_Articulo
    {
        public E_Articulo() { }

        public E_Articulo(string pCodigo, string pDescripcion, E_Marca pMarca, string pTalle, 
            int pExistencia, int pStockMin, int pStockMax, decimal pPrecioCosto, 
            decimal pPrecioVenta, decimal pPrecioProm, E_Proveedor pProveedor, string pObservacion, E_Empleado pEmpleado, bool pActivo)
        {
            Codigo = pCodigo;
            Descripcion = pDescripcion;
            oMarca = pMarca;
            Talle = pTalle;
            Existencia = pExistencia;
            stockMin = pStockMin;
            stockMax = pStockMax;
            precioCosto = pPrecioCosto;
            precioVenta = pPrecioVenta;
            precioPromocion = pPrecioProm;
            oProveedor = pProveedor;
            Observacion = pObservacion;
            oEmpleado = pEmpleado;
            Activo = pActivo;
        }

        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public E_Marca _Marca = new E_Marca();
        public E_Marca oMarca
        {
            get { return _Marca; }
            set { _Marca = value; }
        }
        public string Talle { get; set; }
        public int Existencia { get; set; }
        public int stockMin { get; set; }
        public int stockMax { get; set; }
        public decimal precioCosto { get; set; }
        public decimal precioVenta { get; set; }
        public decimal precioPromocion { get; set; }
        public E_Proveedor _Proveedor = new E_Proveedor();
        public E_Proveedor oProveedor
        {
            get { return _Proveedor; }
            set { _Proveedor = value; }
        }
        public string Observacion { get; set; }
        public E_Empleado _Empleado = new E_Empleado();
        public E_Empleado oEmpleado
        {
            get { return _Empleado; }
            set { _Empleado = value; }
        }
        public bool Activo { get; set; }

        public override string ToString()
        {
            return Codigo.ToString();
        }
    }
}
