using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPP;
using Entidad;
using ServiciosI;

namespace BLL
{
    public class BLL_Usuario : Iabmc<E_Usuario>
    {
        MPP_Usuario oMPPUsuario;

        public BLL_Usuario()
        {
            oMPPUsuario = new MPP_Usuario();
        }

        //Metodo Alta.
        public void Alta(E_Usuario oEUsuario)
        {
            try
            {
                oMPPUsuario.Alta(oEUsuario);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Baja.
        public void Baja(E_Usuario oEUsuario)
        {
            try
            {
                oMPPUsuario.Baja(oEUsuario);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Consultar.
        public List<E_Usuario> Consultar(string pNombre)
        {
            try
            {
                return oMPPUsuario.Consultar(pNombre);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Listar.
        public List<E_Usuario> Listar()
        {
            try
            {
                return oMPPUsuario.Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Modificar.
        public void Modificar(E_Usuario oUsuario)
        {
            try
            {
                oMPPUsuario.Modificar(oUsuario);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public bool ValidarNombreUsuario(string pNombre)
        {
            try
            {
                return oMPPUsuario.ValidarNombreUsuario(pNombre);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Validar, empleado para verificar que el usuario y constraseña sean correctos y que el usuario no tenga la cuenta bloqueada.
        public bool Validar(string pNombre, string pContraseña, bool pBloqueado)
        {
            try
            {
                return oMPPUsuario.Validar(pNombre, pContraseña, pBloqueado);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Bloquear usuario.
        public void BloquearUsuario(E_Usuario oUsuario)
        {
            try
            {
                oMPPUsuario.BloquearUsuario(oUsuario);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public bool ValidarIdUsuario(int pId)
        {
            try
            {
                return oMPPUsuario.ValidarIdUsuario(pId);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public bool ValidarIdAumento(int pId)
        {
            try
            {
                return oMPPUsuario.ValidarIdAumento(pId);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Desbloquear usuario.
        public void DesbloquearUsuario(E_Usuario oUsuario)
        {
            try
            {
                oMPPUsuario.DesbloquearUsuario(oUsuario);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo para verificar el tipo de usuario que se logea.
        public string VerificarTipoUsuario(E_Usuario oUsuario)
        {
            try
            {
                return oMPPUsuario.VerificarTipoUsuario(oUsuario);
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        public string ObtenerIdUsuario(E_Usuario oUsuario)
        {
            try
            {
                return oMPPUsuario.ObtenterIdUsuario(oUsuario);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public string ObtenerNombreUsuario(E_Usuario oUsuario)
        {
            try
            {
                return oMPPUsuario.ObtenerNombreUsuario(oUsuario);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
