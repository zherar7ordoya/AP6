using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using DAO;
using System.Data;
using ServiciosI;

namespace MPP
{
    public class MPP_Movimiento : Iabmc<E_Movimiento>
    {
        //Instancio objetos de la DAO.
        AccesoDB oAcceso;
        DataSet ds;
        DataTable dtMovimiento;

        public MPP_Movimiento()
        {
            try
            {
                oAcceso = new AccesoDB();

                ds = oAcceso.ds;
                dtMovimiento = oAcceso.dtMovimiento;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Alta.
        public void Alta(E_Movimiento oMovimiento)
        {
            try
            {
                DataRow dr = dtMovimiento.NewRow();

                dtMovimiento.Rows.Add(new object[]{
                   null,
                   oMovimiento.oArticulo.Codigo,
                   oMovimiento.Fecha,
                   oMovimiento.Accion,
                   oMovimiento.cantidadMov,
                   oMovimiento.precioCostoCalculado,
                   oMovimiento.precioVentaCalculado,
                   oMovimiento.oEmpleado.Dni
              });
                oAcceso.GrabarDatos();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        
        //Metodo Listar.
        public List<E_Movimiento> Listar()
        {
            List<E_Movimiento> listaMovimiento = new List<E_Movimiento>();

            try
            {
                if (dtMovimiento.Rows.Count > 0)
                {
                    listaMovimiento = new List<E_Movimiento>();

                    foreach (DataRow r in ds.Tables["Movimiento"].Rows)
                    {
                        E_Movimiento oMovimiento = new E_Movimiento();
                        oMovimiento.Id = r.Field<Int32>(0);
                        oMovimiento.oArticulo.Codigo = r.Field<string>(1);
                        oMovimiento.Fecha = r.Field<DateTime>(2);
                        oMovimiento.Accion = r.Field<string>(3);
                        oMovimiento.cantidadMov = r.Field<Int32>(4);
                        oMovimiento.precioCostoCalculado = r.Field<decimal>(5);
                        oMovimiento.precioVentaCalculado = r.Field<decimal>(6);
                        oMovimiento.oEmpleado.Dni = r.Field<int>(7);

                        listaMovimiento.Add(oMovimiento);
                    }

                    return listaMovimiento;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Consultar.
        public List<E_Movimiento> Consultar(string pFecha)
        {
            List<E_Movimiento> listaMovimiento = new List<E_Movimiento>();

            try
            {
                if (dtMovimiento.Rows.Count > 0)
                {
                    listaMovimiento = new List<E_Movimiento>();

                    foreach (DataRow r in ds.Tables["Movimiento"].Rows)
                    {
                        if (r["Movimiento_Fecha"].ToString().StartsWith(pFecha))
                        {
                            E_Movimiento oMovimiento = new E_Movimiento();
                            oMovimiento.Id = r.Field<Int32>(0);
                            oMovimiento.oArticulo.Codigo = r.Field<string>(1);
                            oMovimiento.Fecha = r.Field<DateTime>(2);
                            oMovimiento.Accion = r.Field<string>(3);
                            oMovimiento.cantidadMov = r.Field<Int32>(4);
                            oMovimiento.precioCostoCalculado = r.Field<decimal>(5);
                            oMovimiento.precioVentaCalculado = r.Field<decimal>(6);
                            oMovimiento.oEmpleado.Dni = r.Field<int>(7);

                            listaMovimiento.Add(oMovimiento);
                            break;
                        }
                    }

                    return listaMovimiento;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Baja.
        public void Baja(E_Movimiento oMovimiento)
        {
            try
            {
                dtMovimiento.Rows.Remove(dtMovimiento.Rows.Find(oMovimiento.Id));
                oAcceso.GrabarDatos();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Modificar.
        public void Modificar(E_Movimiento oMovimiento)
        {
            try
            {
                dtMovimiento.Rows.Find(oMovimiento.Id).ItemArray = new object[] { null, oMovimiento.oArticulo.Codigo, oMovimiento.Fecha, oMovimiento.Accion, oMovimiento.cantidadMov, oMovimiento.precioCostoCalculado, oMovimiento.precioVentaCalculado, oMovimiento.oEmpleado.Dni };
                oAcceso.GrabarDatos();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Obtener cantidad de articulos egresados en el calculo de consumo promedio.
        public int ObtenerCantArticulosEgresados(string pCodigo, DateTime pFechaFinal, DateTime pFechaInicial)
        {
            //Creo variable.
            int cantidad = 0;

            try
            {
                //Recorro el datatable de movimientos.
                foreach (DataRow r in ds.Tables["Movimiento"].Rows)
                {
                    //Si el codigo del articulo coincide con el parametro entrante, el movimiento es un egreso,
                    //y la fecha coincide con la de los parametros.
                    if (r["Movimiento_Articulo_Codigo"].ToString() == pCodigo && r["Movimiento_Accion"].ToString() == "Egreso" && Convert.ToDateTime(r["Movimiento_Fecha"]).Date >= pFechaInicial.Date && Convert.ToDateTime(r["Movimiento_Fecha"]).Date <= pFechaFinal.Date)
                    {
                        //Voy sumando la cantidad de articulos.
                        cantidad = cantidad + Convert.ToInt32(r["Movimiento_CantidadMov"]);
                    }
                }
                //Retorno la cantidad.
                return cantidad;
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
