using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using MPP;


namespace BLL
{
    public class BLL_BackUp 
    {
        MPP_BackUp oMPPBackUp;

        public BLL_BackUp()
        {
            oMPPBackUp = new MPP_BackUp();
        }

        //Metodo Alta.
        public void Alta(E_BackUp oBackUp)
        {
            try
            {
                oMPPBackUp.Alta(oBackUp);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Listar.
        public List<E_BackUp> Listar()
        {
            try
            {
                return oMPPBackUp.Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Consultar por fecha.
        public List<E_BackUp> Consultar(string pFecha)
        {
            try
            {
                return oMPPBackUp.Consultar(pFecha);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo RealizarBackUp.
        public void RealizarBackUp(string ruta)
        {
            try
            {
                oMPPBackUp.RealizarBackUp(ruta);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

    }
}
