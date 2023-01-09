using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using MPP;
using ServiciosI;

namespace BLL
{
    public class BLL_SueldoNeto 
    {
        MPP_SueldoNeto oMPPSueldoNeto;

        public BLL_SueldoNeto()
        {
            oMPPSueldoNeto = new MPP_SueldoNeto();
        }

        //Metodo Alta.
        public void Alta(E_SueldoNeto oSueldoNeto)
        {
            try
            {
                oMPPSueldoNeto.Alta(oSueldoNeto);
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Baja.
        public void Baja(E_SueldoNeto oSueldoNeto)
        {
            try
            {
                oMPPSueldoNeto.Baja(oSueldoNeto);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Consultar.
        public List<E_SueldoNeto> Consultar(string pFecha)
        {
            try
            {
                return oMPPSueldoNeto.Consultar(pFecha);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Listar.
        public List<E_SueldoNeto> Listar()
        {
            try
            {
                return oMPPSueldoNeto.Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Calcular.
        public decimal Calcular(decimal sdoBruto, decimal impInasistencia, decimal impPuntualidad, int horasExtra, decimal impHorasExtra)
        {
            //Declaro variable.
            decimal total = 0;
            //Realizo el calculo.
            total = sdoBruto + impInasistencia + impPuntualidad + (horasExtra * impHorasExtra);
            //Retorno.
            return total;
        }

        //Metodo que obtiene el sueldo mas alto.
        public decimal ObtenerSueldoNetoAlto()
        {
            try
            {
                return oMPPSueldoNeto.ObtenerSueldoNetoAlto();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo utilizado para el grafico de top 3 de sueldos.
        public List<E_SueldoNeto> ObtenerDatosGraficoSueldo()
        {
            try
            {
                return oMPPSueldoNeto.ObtenerDatosGraficoSueldo();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

    }
}
