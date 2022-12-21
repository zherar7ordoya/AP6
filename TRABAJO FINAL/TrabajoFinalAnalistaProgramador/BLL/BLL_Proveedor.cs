using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPP;
using ServiciosI;
using Entidad;

namespace BLL
{
    public class BLL_Proveedor : Iabmc<E_Proveedor>
    {
        MPP_Proveedor oMPPProveedor;

        public BLL_Proveedor()
        {
            oMPPProveedor = new MPP_Proveedor();
        }

        //Metodo Alta.
        public void Alta(E_Proveedor oProveedor)
        {
            try
            {
                oMPPProveedor.Alta(oProveedor);
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Baja.
        public void Baja(E_Proveedor oProveedor)
        {
            try
            {
                oMPPProveedor.Baja(oProveedor);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Listar.
        public List<E_Proveedor> Listar()
        {
            try
            {
                return oMPPProveedor.Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Modificar.
        public void Modificar(E_Proveedor oProveedor)
        {
            try
            {
                oMPPProveedor.Modificar(oProveedor);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Consultar.
        public List<E_Proveedor> Consultar(string pNombre)
        {
            try
            {
                return oMPPProveedor.Consultar(pNombre);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo que obtiene la cantidad de proveedores.
        public int ObtenerCantidadProveedores()
        {
            try
            {
                //Declaro variable entera.
                int resultado = 0;
                //Asigno a la variable, el listar con la propiedad count, para obtener la cantidad de registros.
                resultado = oMPPProveedor.Listar().Count();
                //Devuelvo el numero de articulos.
                return resultado;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
