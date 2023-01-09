using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using MPP;
using ServiciosI;

namespace BLL
{
    public class BLL_Entrega : Iabmc<E_Entrega>
    {
        MPP_Entrega oMPPEntrega;

        public BLL_Entrega()
        {
            oMPPEntrega = new MPP_Entrega();
        }

        public void Alta(E_Entrega oEntrega)
        {
            try
            {
                oMPPEntrega.Alta(oEntrega);
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        public void Baja(E_Entrega oEntrega)
        {
            try
            {
                oMPPEntrega.Baja(oEntrega);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Entrega> Consultar(string pFecha)
        {
            try
            {
                return oMPPEntrega.Consultar(pFecha);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Entrega> Listar()
        {
            try
            {
                return oMPPEntrega.Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void Modificar(E_Entrega oEntrega)
        {
            try
            {
                oMPPEntrega.Modificar(oEntrega);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Entrega> ListarOrdenadoFecha()
        {
            try
            {
                return oMPPEntrega.ListarOrdenadoFecha();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public double CalcularProximaEntrega(DateTime fechaEntrega)
        {
            DateTime hoy = DateTime.Now;

            try
            {
                //Asigno a una variable la resta entre la fecha de entrega y la fecha actual en unidad de dias.
                double calculo = Convert.ToDouble(fechaEntrega.Subtract(hoy).TotalDays);
                
                return calculo;
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
