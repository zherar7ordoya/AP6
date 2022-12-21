using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class E_SueldoNeto
    {
        public E_SueldoNeto() { }

        public E_SueldoNeto(int pId, DateTime pFecha, E_Empleado pEmpleado, decimal pSueldoBruto, int pCantidadInasistencias, string pPuntualidad, int pHorasExtra, E_Gerente pGerente, decimal pImporte)
        {
            Id = pId;
            Fecha = pFecha;
            oEmpleado = pEmpleado;
            sueldoBruto = pSueldoBruto;
            cantidadInasistencia = pCantidadInasistencias;
            Puntualidad = pPuntualidad;
            horasExtra = pHorasExtra;
            oGerente = pGerente;
            Importe = pImporte;
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public E_Empleado _Empleado = new E_Empleado();
        public E_Empleado oEmpleado
        {
            get { return _Empleado; }
            set { _Empleado = value; }
        }
        public decimal sueldoBruto { get; set; }
        public int cantidadInasistencia { get; set; }
        public string Puntualidad { get; set; }
        public int horasExtra { get; set; }
        public E_Gerente _Gerente = new E_Gerente();
        public E_Gerente oGerente
        {
            get { return _Gerente; }
            set { _Gerente = value; }
        }
        public decimal Importe { get; set; }

    }
}
