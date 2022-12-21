using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using MPP;
using ServiciosI;

namespace BLL
{
    public class BLL_Movimiento : Iabmc<E_Movimiento>
    {
        MPP_Movimiento oMPPMovimiento;

        public BLL_Movimiento()
        {
            oMPPMovimiento = new MPP_Movimiento();
        }
        //Metodo Alta.
        public void Alta(E_Movimiento oMovimiento)
        {
            try
            {
                oMPPMovimiento.Alta(oMovimiento);
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Baja.
        public void Baja(E_Movimiento oMovimiento)
        {
            try
            {
                oMPPMovimiento.Baja(oMovimiento);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Consultar.
        public List<E_Movimiento> Consultar(string pFecha)
        {
            try
            {
                return oMPPMovimiento.Consultar(pFecha);
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Listar.
        public List<E_Movimiento> Listar()
        {
            try
            {
                return oMPPMovimiento.Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Modificar.
        public void Modificar(E_Movimiento oMovimiento)
        {
            try
            {
                oMPPMovimiento.Modificar(oMovimiento);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo para obtener los dias habiles del periodo en el calculo de consumo promedio diario de articulo.
        public int ObtenerDiasPeriodo(DateTime pFechaFinal, DateTime pFechaInicial)
        {
            //Creo variables.
            int resultado = 0;
            int cantidadDomingosMensual = 4;
            int cantidadMeses = 0;
            int diasNoLaborales = 0;
            try
            {
                //Obtengo cantidad de meses.
                cantidadMeses = pFechaFinal.Month - pFechaInicial.Month;
                //Obtengo el numero de dias que debo restar correspondiente a los dias domingo, 
                //es decir multiplico los meses en cuestion por 4 que serian los domingos que hay en un mes (generalmente).
                diasNoLaborales = cantidadMeses * cantidadDomingosMensual;
                //Obtengo los dias habiles, restando a la fecha final, la fecha inicial y restandole los dias no laborales.
                resultado = Convert.ToInt32(pFechaFinal.Subtract(pFechaInicial).TotalDays) - diasNoLaborales;
                //Retorno los dias habiles del periodo.
                return resultado;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo que obtiene la cantidad de articulos egresados en un periodo determinado.
        public int ObtenerCantArticulosEgresados(string pCodigo, DateTime pFechaFinal, DateTime pFechaInicial)
        {
            try
            {
                return oMPPMovimiento.ObtenerCantArticulosEgresados(pCodigo, pFechaFinal, pFechaInicial);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo que obtiene el consumo promedio del articulo.
        public double ObtenerConsumoPromedio(int pCantidadArt, int pDiasHabiles)
        {
            //Creo variable.
            double resultado;

            try
            {
                //Divido la cantidad de articulos por los dias habiles.
                resultado = (double.Parse(pCantidadArt.ToString()) / double.Parse(pDiasHabiles.ToString()));
                //Retorno el resultado.
                return resultado;
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
