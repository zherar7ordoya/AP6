using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using MPP;

namespace BLL
{
    public class BLL_LogIn
    {
        MPP_LogIn oMPPLogin;

        public BLL_LogIn()
        {
            oMPPLogin = new MPP_LogIn();
        }
        //Metodo Alta.
        public void Alta(E_LogIn oLogin)
        {
            try
            {
                oMPPLogin.Alta(oLogin);
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Listar.
        public List<E_LogIn> Listar()
        {
            try
            {
                return oMPPLogin.Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Obtener usuario logeado, para mostrar en los labels de los forms.
        public string ObtenerUsuarioLogeado()
        {
            try
            {
                return oMPPLogin.ObtenerUsuarioLogeado();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
