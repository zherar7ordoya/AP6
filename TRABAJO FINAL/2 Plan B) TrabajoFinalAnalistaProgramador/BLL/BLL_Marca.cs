using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiciosI;
using MPP;
using Entidad;

namespace BLL
{
    public class BLL_Marca : Iabmc<E_Marca>
    {
        MPP_Marca oMPPMarca;

        public BLL_Marca()
        {
            oMPPMarca = new MPP_Marca();
        }

        //Metodo Alta.
        public void Alta(E_Marca oMarca)
        {
            try
            {
                oMPPMarca.Alta(oMarca);
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Baja.
        public void Baja(E_Marca oMarca)
        {
            try
            {
                oMPPMarca.Baja(oMarca);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Consultar.
        public List<E_Marca> Consultar(string pNombre)
        {
            try
            {
                return oMPPMarca.Consultar(pNombre);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }

        //Metodo Listar.
        public List<E_Marca> Listar()
        {
            try
            {
                return oMPPMarca.Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Modificar.
        public void Modificar(E_Marca oMarca)
        {
            try
            {
                oMPPMarca.Modificar(oMarca);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
