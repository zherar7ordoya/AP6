using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPP;
using Entidad;
using ServiciosI;

namespace BLL
{
    public class BLL_Gerente : Iabmc<E_Gerente>
    {
        MPP_Gerente oMPPGerente;

        public BLL_Gerente()
        {
            oMPPGerente = new MPP_Gerente();
        }

        public void Alta(E_Gerente oGerente)
        {
            try
            {
                oMPPGerente.Alta(oGerente);
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        public void Baja(E_Gerente oGerente)
        {
            try
            {
                oMPPGerente.Baja(oGerente);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Gerente> Consultar(string pNombre)
        {
            try
            {
                return oMPPGerente.Consultar(pNombre);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Gerente> Listar()
        {
            try
            {
                return oMPPGerente.Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void Modificar(E_Gerente oGerente)
        {
            try
            {
                oMPPGerente.Modificar(oGerente);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public bool ValidarCodigo(int pDni)
        {
            try
            {
                return oMPPGerente.ValidarDni(pDni);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
