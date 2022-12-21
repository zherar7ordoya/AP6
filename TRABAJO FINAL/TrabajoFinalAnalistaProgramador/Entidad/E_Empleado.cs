using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class E_Empleado
    {
        public E_Empleado() { }

        public E_Empleado(int pDni, string pNombre, string pApellido, string pDireccion, 
            int pCelular, int pTelefono, DateTime pFechaNac, string pEstadoCivil, decimal pSueldoBruto, E_Usuario pUsuario, string pMailPersonal)
        {
            Dni = pDni;
            Nombre = pNombre;
            Apellido = pApellido;
            Direccion = pDireccion;
            Celular = pCelular;
            Telefono = pTelefono;
            fechaNacimiento = pFechaNac;
            estadoCivil = pEstadoCivil;
            sueldoBruto = pSueldoBruto;
            oUsuario = pUsuario;
            mailPersonal = pMailPersonal;
        }

        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public Int64 Celular { get; set; }
        public Int64 Telefono { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string estadoCivil { get; set; }
        public decimal sueldoBruto { get; set; }
        public E_Usuario _Usuario = new E_Usuario();
        public E_Usuario oUsuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }
        public string mailPersonal { get; set; }

        public override string ToString()
        {
            return Dni.ToString();
        }

    }
}
