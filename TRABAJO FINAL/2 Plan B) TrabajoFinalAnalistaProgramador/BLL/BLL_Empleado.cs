using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiciosI;
using Entidad;
using MPP;

namespace BLL
{
    public class BLL_Empleado : Iabmc<E_Empleado>
    {
        MPP_Empleado oMPPEmpleado;

        public BLL_Empleado()
        {
            oMPPEmpleado = new MPP_Empleado();
        }

        public void Alta(E_Empleado oEmpleado)
        {
            try
            {
                oMPPEmpleado.Alta(oEmpleado);
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        public void Baja(E_Empleado oEmpleado)
        {
            try
            {
                oMPPEmpleado.Baja(oEmpleado);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Empleado> Consultar(string pNombre)
        {
            try
            {
                return oMPPEmpleado.Consultar(pNombre);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Empleado> Listar()
        {
            try
            {
                return oMPPEmpleado.Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void Modificar(E_Empleado oEmpleado)
        {
            try
            {
                oMPPEmpleado.Modificar(oEmpleado);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo que obtiene la cantidad de empleados.
        public int ObtenerCantidadEmpleados()
        {
            try
            {
                //Declaro variable entera.
                int resultado = 0;
                //Asigno a la variable, el listar con la propiedad count, para obtener la cantidad de registros.
                resultado = oMPPEmpleado.Listar().Count();
                //Devuelvo el numero de empleados.
                return resultado;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public bool ValidarDni(int pDni)
        {
            try
            {
                return oMPPEmpleado.ValidarDni(pDni);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
