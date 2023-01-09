using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class E_Movimiento
    {
        public E_Movimiento() { }

        public E_Movimiento(int pId, E_Articulo pArticulo, DateTime pFecha, string pAccion, 
            int pCantidadMov, decimal pPrecioCosto, decimal pPrecioVenta, decimal pPrecioCostoNuevo, E_Empleado pEmpleado)
        {
            Id = pId;
            oArticulo = pArticulo;
            Fecha = pFecha;
            Accion = pAccion;
            cantidadMov = pCantidadMov;
            precioCostoCalculado = pPrecioCosto;
            precioVentaCalculado = pPrecioVenta;
            oEmpleado = pEmpleado;
        }

        public int Id { get; set; }
        public E_Articulo _Articulo = new E_Articulo();
        public E_Articulo oArticulo
        {
            get { return _Articulo; }
            set { _Articulo = value; }
        }
        public DateTime Fecha { get; set; }
        public string Accion { get; set; }
        public int cantidadMov { get; set; }
        public decimal precioCostoCalculado { get; set; }
        public decimal precioVentaCalculado { get; set; }
        public E_Empleado _Empleado = new E_Empleado();
        public E_Empleado oEmpleado
        {
            get { return _Empleado; }
            set { _Empleado = value; }
        }
    }
}
