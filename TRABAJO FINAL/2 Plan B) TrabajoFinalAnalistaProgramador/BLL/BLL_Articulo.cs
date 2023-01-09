using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiciosI;
using Entidad;
using MPP;

namespace BLL
{
    public class BLL_Articulo : Iabmc<E_Articulo>
    {
        MPP_Articulo oMPPArticulo;

        public BLL_Articulo()
        {
            oMPPArticulo = new MPP_Articulo();
        }

        //Metodo Alta.
        public void Alta(E_Articulo oArticulo)
        {
            try
            {
                oMPPArticulo.Alta(oArticulo);
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Baja.
        public void Baja(E_Articulo oArticulo)
        {
            try
            {
                oMPPArticulo.Baja(oArticulo);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Consultar por descripcion.
        public List<E_Articulo> Consultar(string pDescripcion)
        {
            try
            {
                return oMPPArticulo.Consultar(pDescripcion);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Listar.
        public List<E_Articulo> Listar()
        {
            try
            {
                return oMPPArticulo.Listar();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo para evitar que se repitan Id.
        public bool ValidarCodigo(string pCodigo)
        {
            try
            {
                return oMPPArticulo.ValidarCodigo(pCodigo);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Listar por precio de venta.
        public List<E_Articulo> ListarOrdenadoPVenta()
        {
            try
            {
                return oMPPArticulo.ListarOrdenadoPVenta();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Listar por precio de costo.
        public List<E_Articulo> ListarOrdenadoPrecioCosto()
        {
            try
            {
                return oMPPArticulo.ListarOrdenadoPCosto();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Listar por existencias.
        public List<E_Articulo> ListarOrdenadoExistencias()
        {
            try
            {
                return oMPPArticulo.ListarOrdenadoExistencias();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Listar por descripcion.
        public List<E_Articulo> ListarOrdenadoDescripcion()
        {
            try
            {
                return oMPPArticulo.ListarOrdenadoDescripcion();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Modificar.
        public void Modificar(E_Articulo oArticulo)
        {
            try
            {
                oMPPArticulo.Modificar(oArticulo);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo para calcular el stock minimo.
        public double CalcularStockMin(int pTiempoEntrega, double pConsumoPromedio)
        {
            try
            {
                //Creo una variable.
                double resultado = 0;
                //Multiplico el tiempo de entrega por el consumo promedio del articulo.
                resultado = double.Parse(pTiempoEntrega.ToString()) * double.Parse(pConsumoPromedio.ToString());
                //Si el resultado es menor a 2, valido que si o si sea 2, ya que segun requerimientos siempre debe quedar
                //un articulo en deposito y el restante seria para comercializar.
                if(resultado < 2)
                {
                    resultado = 2;
                }
                //Retorno el resultado.
                return resultado;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            
        }

        //Metodo para calcular el stock maximo.
        public double CalcularStockMax(int pTiempoEntrega, double pConsumoPromedio, int pStockMin)
        {
            try
            {
                //Creo una variable.
                double resultado = 0;
                //Multiplico el tiempo de entrega por el consumo promedio mas el stock min.
                resultado = (double.Parse(pTiempoEntrega.ToString()) * pConsumoPromedio) + double.Parse(pStockMin.ToString());
                //Teniendo en cuenta que el valor minimo para los stock minimos es 2, para los stocks maximos se va a establecer en 4,
                //ya que por teoria, el stock maximo es el doble del stock minimo.
                if(resultado < 4)
                {
                    resultado = 4;
                }

                return resultado;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo PPP para ingreso de articulo.
        public decimal CalculoPPP(int pCantidad, int pExistenciaActual, decimal pPrecioCostoActual, decimal pPrecioCostoAnterior)
        {
            try
            {
                //Creo variables.
                int cantidadTotal = 0;
                decimal entrada = 0;
                decimal totalActual = 0;
                decimal resultado = 0;
                decimal totalIngresoAnterior = 0;

                //Aplico PPP.
                //Obtengo la entrada, es decir, la cantidad que ingresa por el precio de costo.
                entrada = (pCantidad * pPrecioCostoActual);
                //Obtengo la cantidad total, sumando la cantidad que ingresa mas las existencias actuales que hay en el deposito.
                cantidadTotal = pCantidad + pExistenciaActual;
                //Obtengo el total del ingreso anterior, es decir, multiplico el precio de costo anterior por las existencias actuales que hay en deposito.
                totalIngresoAnterior = pExistenciaActual * pPrecioCostoAnterior;
                //Obtengo el totalActual del ingreso en cuestion (entrada), sumando el total del ingreso anterior mas la entrada actual.
                totalActual = totalIngresoAnterior + entrada;
                //Obtengo el nuevo precio de costo diviendo el total obtenido con la cantidad total.
                return resultado = (totalActual / cantidadTotal); 
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            
        }
        //Metodo PPP para egreso de articulo.
        public decimal CalculoPPPEgreso(int pCantidad, int pExistenciaActual, decimal pPrecioCostoActual, decimal pPrecioCostoAnterior)
        {
            try
            {
                //Creo variables.
                int cantidadTotal = 0;
                decimal salida = 0;
                decimal totalActual = 0;
                decimal resultado = 0;
                decimal totalIngresoAnterior = 0;

                //Aplico PPP.
                //Obtengo la salida, es decir, la cantidad que egresa por el precio de costo.
                salida = (pCantidad * pPrecioCostoActual);
                //Obtengo la cantidad total, restando las existencias de deposito  menos la cantidad que egresa.
                cantidadTotal = pExistenciaActual - pCantidad;
                //Obtengo el total del ingreso anterior, es decir, multiplico el precio de costo anterior por las existencias actuales que hay en deposito.
                totalIngresoAnterior = pExistenciaActual * pPrecioCostoAnterior;
                //Obtengo el totalActual del egreso en cuestion (salida), restando el total anterior menos la salida actual.
                totalActual = totalIngresoAnterior - salida;
                //Obtengo el nuevo precio de costo diviendo el total obtenido con la cantidad total.
                return resultado = (totalActual / cantidadTotal);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }
        //Metodo que calcula el precio de venta
        public decimal CalculoPrecioVenta(decimal pPrecioCostoNuevo, decimal pIva, decimal pFlete, decimal pGanancia)
        {
            decimal resultado = 0;

            try
            {
                //Sumo al precio de costo nuevo los distintos porcentajes.
                return resultado = pPrecioCostoNuevo + (((pPrecioCostoNuevo) * pGanancia) / 100) + (((pPrecioCostoNuevo) * pIva) / 100) + (((pPrecioCostoNuevo) * pFlete) / 100);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo para aumentar el precio de venta de articulo.
        public void IncrementarPrecioVenta(decimal pPorcentaje)
        {
            try
            {
                decimal precioVentaFinal = 0;

                //Recorro el metodo listar de articulo.
                foreach (E_Articulo oArticulo in oMPPArticulo.Listar())
                {
                    //Calculo el precio de venta final, sumandole el porcentaje.
                    precioVentaFinal = oArticulo.precioVenta + (oArticulo.precioVenta * (pPorcentaje) / 100);
                    //Asigno al atributo el valor de la variable.
                    oArticulo.precioVenta = precioVentaFinal;
                    //Modifico el precio de venta en la bd.
                    oMPPArticulo.Modificar(oArticulo);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo para reducir el precio de venta de articulo.
        public void ReducirPrecioVenta(decimal pPorcentaje)
        {
            try
            {
                decimal precioVentaFinal = 0;

                //Recorro el metodo listar de articulo.
                foreach (E_Articulo oArticulo in oMPPArticulo.Listar())
                {
                    //Calculo el precio de venta final, restandole el porcentaje.
                    precioVentaFinal = oArticulo.precioVenta - (oArticulo.precioVenta * (pPorcentaje) / 100);
                    //Asigno al atributo el valor de la variable.
                    oArticulo.precioVenta = precioVentaFinal;
                    //Modifico el precio de venta en la bd.
                    oMPPArticulo.Modificar(oArticulo);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo para calcular el total de la valorazion del inventario (Sumatoria de (precioCosto * Existencia))
        public decimal CalcularTotalValorizacionInventario()
        {
            try
            {
                decimal valorizacionInventario = 0;

                //Recorro el metodo listar de articulo.
                foreach (E_Articulo oArticulo in oMPPArticulo.Listar())
                {
                    //Calculo el total de la valorizacion del articulo en el inventario, multiplicando la existencia por el precioCosto.
                    valorizacionInventario += oArticulo.precioCosto * oArticulo.Existencia;
                }
                //Retorno.
                return valorizacionInventario;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo que obtine el tipo de articulo de acuerdo a la clasificacion A-B-C.
        public decimal ObtenerTipoArticulo(E_Articulo oArticulo)
        {
            try
            {
                //Declaro variables.
                decimal porcentaje = 0;
                decimal porcentaje2 = 0;

                //Calculo el porcentaje de valorizacion de inventario del articulo seleccionado.
                porcentaje2 = (oArticulo.precioCosto * oArticulo.Existencia) / CalcularTotalValorizacionInventario();
                //Recorro el metodo listar de articulo, ordenado por precio de venta, es decir de los articulos mas valorados a lo menos valorados.
                foreach (E_Articulo a in oMPPArticulo.ListarOrdenadoPCosto())
                {
                    //Calculo la sumatoria del porcentaje de valorizacion dividiendo la valorizacion de inventario 
                    //(precioCosto * Existencia) dividido el total de valorizacion de inventario.
                    porcentaje += (a.precioCosto * a.Existencia) / CalcularTotalValorizacionInventario();
                    //Si el porcentaje del articulo seleccionado, coincide con el calculo del porcentaje de valorizacion que va realizando la variable porcentaje, 
                    //corto la ejecucion del foreach.
                    if (porcentaje2 == (a.precioCosto * a.Existencia) / CalcularTotalValorizacionInventario())
                    { break; }
                }
                //Devuelvo la sumatoria del porcentaje.
                return porcentaje;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo para calcular el total de las existencias del deposito.
        public decimal CalcularTotalExistencias()
        {
            try
            {
                int suma = 0;
                //Recorro el metodo listar de articulo.
                foreach (E_Articulo oArticulo in oMPPArticulo.Listar())
                {
                    //Realizo la suma de las exitencias.
                    suma = suma + oArticulo.Existencia;
                }
                //Retorno el resultado.
                return suma;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo que obtiene la cantidad de articulos.
        public int ObtenerCantidadArticulos()
        {
            try
            {
                //Declaro variable entera.
                int resultado = 0;
                //Asigno a la variable, el listar con la propiedad count, para obtener la cantidad de registros.
                resultado  = oMPPArticulo.Listar().Count();
                //Devuelvo el numero de articulos.
                return resultado;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public decimal ObtenerPrecioVentaAlto()
        {
            try
            {
                return oMPPArticulo.ObtenerPrecioVentaAlto();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public decimal ObtenerPrecioVentaBajo()
        {
            try
            {
                return oMPPArticulo.ObtenerPrecioVentaBajo();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Articulo> ObtenerDatosGraficoPVenta()
        {
            try
            {
                return oMPPArticulo.ObtenerDatosGraficoPVenta();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Articulo> ObtenerDatosGraficoExistencias()
        {
            try
            {
                return oMPPArticulo.ObtenerDatosGraficoExistencias();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Articulo> ObtenerDatosGraficoPVenta2()
        {
            try
            {
                return oMPPArticulo.ObtenerDatosGraficoPVenta2();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Articulo> ObtenerDatosGraficoExistencias2()
        {
            try
            {
                return oMPPArticulo.ObtenerDatosGraficoExistencias2();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Articulo> ListarExistenciasMenores()
        {
            try
            {
                return oMPPArticulo.ListarExistenciasMenores();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo utilizado para validar que no se sobrepase el stock maximo al momento de hacer el reporte de articulo faltante.
        public int ValidarStockMax(int pExistenciaActual, int pCantidad)
        {
            int calculo = 0;
            try
            {
                calculo = pExistenciaActual + pCantidad;
                return calculo;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }


    }
}
