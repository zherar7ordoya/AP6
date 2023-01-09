using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class E_Gerente : E_Empleado
    {
        public E_Gerente() { }

        public E_Gerente(int pDni, string pNombre, string pApellido, string pDireccion,
            int pCelular, int pTelefono, DateTime pFechaNac, string pEstadoCivil, decimal pSueldoBruto, E_Usuario pUsuario, string pMailPersonal, string pMailEmpresarial) : base(pDni, pNombre, pApellido, pDireccion, pCelular, pTelefono, pFechaNac, pEstadoCivil, pSueldoBruto, pUsuario, pMailPersonal)
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
            mailEmpresarial = pMailEmpresarial;
        }

        public string mailEmpresarial { get; set; }

    }
}
