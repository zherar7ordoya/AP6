using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using ServiciosI;
using Entidad;
using System.Data;

namespace MPP
{
    public class MPP_Articulo : Iabmc<E_Articulo>
    {
        //Instancio objetos de la DAO.
        AccesoDB oAcceso;
        DataSet ds;
        DataTable dtArticulo;

        public MPP_Articulo()
        {
            oAcceso = new AccesoDB();
            ds = oAcceso.ds;
            dtArticulo = oAcceso.dtArticulo;
        }

        //Metodo Alta.
        public void Alta(E_Articulo oArticulo)
        {
            try
            {
                //Creo un datarow en el datatable Articulo.
                DataRow dr = dtArticulo.NewRow();
                //Añado.
                dtArticulo.Rows.Add(new object[]{
                   oArticulo.Codigo,
                   oArticulo.Descripcion,
                   oArticulo.oMarca.Codigo,
                   oArticulo.Talle,
                   oArticulo.Existencia,
                   oArticulo.stockMin,
                   oArticulo.stockMax,
                   oArticulo.precioCosto,
                   oArticulo.precioVenta,
                   oArticulo.precioPromocion,
                   oArticulo.oProveedor.Id,
                   oArticulo.Observacion,
                   oArticulo.oEmpleado.Dni,
                   oArticulo.Activo = true
              });
                //Grabo los datos.
                oAcceso.GrabarDatos();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Baja.
        public void Baja(E_Articulo oArticulo)
        {
            try
            {
                //Busco el articulo por su codigo, y realizo una baja logica.
                dtArticulo.Rows.Find(oArticulo.Codigo).ItemArray = new object[] {oArticulo.Codigo, oArticulo.Descripcion,
                oArticulo.oMarca.Codigo, oArticulo.Talle, oArticulo.Existencia, oArticulo.stockMin, oArticulo.stockMax, oArticulo.precioCosto, oArticulo.precioVenta, oArticulo.precioPromocion, oArticulo.oProveedor.Id,
                oArticulo.Observacion, oArticulo.oEmpleado.Dni, oArticulo.Activo = false};
                //Grabo los datos.
                oAcceso.GrabarDatos();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Consultar.
        public List<E_Articulo> Consultar(string pDescripcion)
        {
            //Creo una lista.
            List<E_Articulo> listaArticulo = new List<E_Articulo>();

            try
            {
                //Verifico que el datatable tenga datos.
                if (dtArticulo.Rows.Count > 0)
                {
                    listaArticulo = new List<E_Articulo>();

                    //Recorro datatable Articulo.
                    foreach (DataRow r in ds.Tables["Articulo"].Rows)
                    {
                        //Si hay un row que empiece con la descripcion indicada.
                        if (r["Articulo_Descripcion"].ToString().StartsWith(pDescripcion))
                        {
                            E_Articulo oArticulo = new E_Articulo();
                            oArticulo.Codigo = r.Field<string>(0);
                            oArticulo.Descripcion = r.Field<string>(1);
                            oArticulo.oMarca.Codigo = r.Field<int>(2);
                            oArticulo.Talle = r.Field<string>(3);
                            oArticulo.Existencia = r.Field<int>(4);
                            oArticulo.stockMin = r.Field<int>(5);
                            oArticulo.stockMax = r.Field<int>(6);
                            oArticulo.precioCosto = r.Field<decimal>(7);
                            oArticulo.precioVenta = r.Field<decimal>(8);
                            oArticulo.precioPromocion = r.Field<decimal>(9);
                            oArticulo.oProveedor.Id = r.Field<int>(10);
                            oArticulo.Observacion = r.Field<string>(11);
                            oArticulo.oEmpleado.Dni = r.Field<int>(12);
                            oArticulo.Activo = r.Field<bool>(13);

                            listaArticulo.Add(oArticulo);
                            //Corto el foreach.
                            break;
                        }
                    }
                    //Retorno la lista.
                    return listaArticulo;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Listar.
        public List<E_Articulo> Listar()
        {
            List<E_Articulo> listaArticulo = new List<E_Articulo>();

            try
            {
                if (dtArticulo.Rows.Count > 0)
                {
                    listaArticulo = new List<E_Articulo>();

                    foreach (DataRow r in dtArticulo.Rows)
                    {
                        E_Articulo oArticulo = new E_Articulo();
                        oArticulo.Codigo = r.Field<string>(0);
                        oArticulo.Descripcion = r.Field<string>(1);
                        oArticulo.oMarca.Codigo = r.Field<int>(2);
                        oArticulo.Talle = r.Field<string>(3);
                        oArticulo.Existencia = r.Field<int>(4);
                        oArticulo.stockMin = r.Field<int>(5);
                        oArticulo.stockMax = r.Field<int>(6);
                        oArticulo.precioCosto = r.Field<decimal>(7);
                        oArticulo.precioVenta = r.Field<decimal>(8);
                        oArticulo.precioPromocion = r.Field<decimal>(9);
                        oArticulo.oProveedor.Id = r.Field<int>(10);
                        oArticulo.Observacion = r.Field<string>(11);
                        oArticulo.oEmpleado.Dni = r.Field<int>(12);
                        oArticulo.Activo = r.Field<bool>(13);

                        listaArticulo.Add(oArticulo);
                    }

                    return listaArticulo;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Ordenar por precio de venta.
        public List<E_Articulo> ListarOrdenadoPVenta()
        {
            List<E_Articulo> listaArticulo = new List<E_Articulo>();

            try
            {
                if (dtArticulo.Rows.Count > 0)
                {
                    listaArticulo = new List<E_Articulo>();

                    foreach (DataRow r in ds.Tables["Articulo"].Rows)
                    {
                        E_Articulo oArticulo = new E_Articulo();
                        oArticulo.Codigo = r.Field<string>(0);
                        oArticulo.Descripcion = r.Field<string>(1);
                        oArticulo.oMarca.Codigo = r.Field<int>(2);
                        oArticulo.Talle = r.Field<string>(3);
                        oArticulo.Existencia = r.Field<int>(4);
                        oArticulo.stockMin = r.Field<int>(5);
                        oArticulo.stockMax = r.Field<int>(6);
                        oArticulo.precioCosto = r.Field<decimal>(7);
                        oArticulo.precioVenta = r.Field<decimal>(8);
                        oArticulo.precioPromocion = r.Field<decimal>(9);
                        oArticulo.oProveedor.Id = r.Field<int>(10);
                        oArticulo.Observacion = r.Field<string>(11);
                        oArticulo.oEmpleado.Dni = r.Field<int>(12);
                        oArticulo.Activo = r.Field<bool>(13);

                        listaArticulo.Add(oArticulo);
                    }

                    listaArticulo.Sort((y, x) => x.precioVenta.CompareTo(y.precioVenta));

                    return listaArticulo;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Ordenar por precio de costo.
        public List<E_Articulo> ListarOrdenadoPCosto()
        {
            List<E_Articulo> listaArticulo = new List<E_Articulo>();

            try
            {
                if (dtArticulo.Rows.Count > 0)
                {
                    listaArticulo = new List<E_Articulo>();

                    foreach (DataRow r in ds.Tables["Articulo"].Rows)
                    {
                        E_Articulo oArticulo = new E_Articulo();
                        oArticulo.Codigo = r.Field<string>(0);
                        oArticulo.Descripcion = r.Field<string>(1);
                        oArticulo.oMarca.Codigo = r.Field<int>(2);
                        oArticulo.Talle = r.Field<string>(3);
                        oArticulo.Existencia = r.Field<int>(4);
                        oArticulo.stockMin = r.Field<int>(5);
                        oArticulo.stockMax = r.Field<int>(6);
                        oArticulo.precioCosto = r.Field<decimal>(7);
                        oArticulo.precioVenta = r.Field<decimal>(8);
                        oArticulo.precioPromocion = r.Field<decimal>(9);
                        oArticulo.oProveedor.Id = r.Field<int>(10);
                        oArticulo.Observacion = r.Field<string>(11);
                        oArticulo.oEmpleado.Dni = r.Field<int>(12);
                        oArticulo.Activo = r.Field<bool>(13);

                        listaArticulo.Add(oArticulo);
                    }

                    listaArticulo.Sort((y, x) => x.precioCosto.CompareTo(y.precioCosto));

                    return listaArticulo;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Ordenar por existencias.
        public List<E_Articulo> ListarOrdenadoExistencias()
        {
            List<E_Articulo> listaArticulo = new List<E_Articulo>();

            try
            {
                if (dtArticulo.Rows.Count > 0)
                {
                    listaArticulo = new List<E_Articulo>();

                    foreach (DataRow r in ds.Tables["Articulo"].Rows)
                    {
                        E_Articulo oArticulo = new E_Articulo();
                        oArticulo.Codigo = r.Field<string>(0);
                        oArticulo.Descripcion = r.Field<string>(1);
                        oArticulo.oMarca.Codigo = r.Field<int>(2);
                        oArticulo.Talle = r.Field<string>(3);
                        oArticulo.Existencia = r.Field<int>(4);
                        oArticulo.stockMin = r.Field<int>(5);
                        oArticulo.stockMax = r.Field<int>(6);
                        oArticulo.precioCosto = r.Field<decimal>(7);
                        oArticulo.precioVenta = r.Field<decimal>(8);
                        oArticulo.precioPromocion = r.Field<decimal>(9);
                        oArticulo.oProveedor.Id = r.Field<int>(10);
                        oArticulo.Observacion = r.Field<string>(11);
                        oArticulo.oEmpleado.Dni = r.Field<int>(12);
                        oArticulo.Activo = r.Field<bool>(13);

                        listaArticulo.Add(oArticulo);
                    }

                    listaArticulo.Sort((y, x) => x.Existencia.CompareTo(y.Existencia));
                    return listaArticulo;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Ordenar por descripcion.
        public List<E_Articulo> ListarOrdenadoDescripcion()
        {
            List<E_Articulo> listaArticulo = new List<E_Articulo>();

            try
            {
                if (dtArticulo.Rows.Count > 0)
                {
                    listaArticulo = new List<E_Articulo>();

                    foreach (DataRow r in ds.Tables["Articulo"].Rows)
                    {
                        E_Articulo oArticulo = new E_Articulo();
                        oArticulo.Codigo = r.Field<string>(0);
                        oArticulo.Descripcion = r.Field<string>(1);
                        oArticulo.oMarca.Codigo = r.Field<int>(2);
                        oArticulo.Talle = r.Field<string>(3);
                        oArticulo.Existencia = r.Field<int>(4);
                        oArticulo.stockMin = r.Field<int>(5);
                        oArticulo.stockMax = r.Field<int>(6);
                        oArticulo.precioCosto = r.Field<decimal>(7);
                        oArticulo.precioVenta = r.Field<decimal>(8);
                        oArticulo.precioPromocion = r.Field<decimal>(9);
                        oArticulo.oProveedor.Id = r.Field<int>(10);
                        oArticulo.Observacion = r.Field<string>(11);
                        oArticulo.oEmpleado.Dni = r.Field<int>(12);
                        oArticulo.Activo = r.Field<bool>(13);

                        listaArticulo.Add(oArticulo);
                    }

                    listaArticulo.Sort((x, y) => x.Descripcion.CompareTo(y.Descripcion));
                    return listaArticulo;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Ordenar por articulos que tengan existencias menores al stock minimo.
        public List<E_Articulo> ListarExistenciasMenores()
        {
            List<E_Articulo> listaArticulo = new List<E_Articulo>();

            try
            {
                if (dtArticulo.Rows.Count > 0)
                {
                    listaArticulo = new List<E_Articulo>();

                    foreach (DataRow r in ds.Tables["Articulo"].Rows)
                    {
                        if(Convert.ToInt32(r["Articulo_Existencia"]) < Convert.ToInt32(r["Articulo_StockMin"]))
                        {
                            E_Articulo oArticulo = new E_Articulo();
                            oArticulo.Codigo = r.Field<string>(0);
                            oArticulo.Descripcion = r.Field<string>(1);
                            oArticulo.oMarca.Codigo = r.Field<int>(2);
                            oArticulo.Talle = r.Field<string>(3);
                            oArticulo.Existencia = r.Field<int>(4);
                            oArticulo.stockMin = r.Field<int>(5);
                            oArticulo.stockMax = r.Field<int>(6);
                            oArticulo.precioCosto = r.Field<decimal>(7);
                            oArticulo.precioVenta = r.Field<decimal>(8);
                            oArticulo.precioPromocion = r.Field<decimal>(9);
                            oArticulo.oProveedor.Id = r.Field<int>(10);
                            oArticulo.Observacion = r.Field<string>(11);
                            oArticulo.oEmpleado.Dni = r.Field<int>(12);
                            oArticulo.Activo = r.Field<bool>(13);
                            listaArticulo.Add(oArticulo);
                        }
                    }

                    return listaArticulo;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Modificar.
        public void Modificar(E_Articulo oArticulo)
        {
            try
            {
                dtArticulo.Rows.Find(oArticulo.Codigo).ItemArray = new object[] {oArticulo.Codigo, oArticulo.Descripcion,
                oArticulo.oMarca.Codigo, oArticulo.Talle, oArticulo.Existencia, oArticulo.stockMin, oArticulo.stockMax, oArticulo.precioCosto, oArticulo.precioVenta, oArticulo.precioPromocion, oArticulo.oProveedor.Id,
                oArticulo.Observacion, oArticulo.oEmpleado.Dni, oArticulo.Activo = true};
                oAcceso.GrabarDatos();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo para validar que no ingrese ids repetidos.
        public bool ValidarCodigo(string pCodigo)
        {
            bool resultado = true;

            try
            {
                foreach (DataRow row in dtArticulo.Rows)
                {
                    //Si el id coincide con el valor del id del objeto repetido.
                    if (row["Articulo_Codigo"].ToString() == pCodigo)
                    {
                        //Coloco la variable en false, y luego doy aviso en la vista que se trata de un id repetido.
                        resultado = false;
                        break;
                    }
                    else
                    {
                        resultado = true;
                    }
                }

                return resultado;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo para obtener el precio de venta mas alto.
        public decimal ObtenerPrecioVentaAlto()
        {
            try
            {
                //Asigno a una variable, el filtro de la row con el precio mas alto.
                decimal resultado = dtArticulo.Rows.Cast<DataRow>().Select(row => row.Field<decimal>("Articulo_PrecioVenta")).Max();
                return resultado;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }

        //Metodo para obtener el precio de venta mas bajo.
        public decimal ObtenerPrecioVentaBajo()
        {
            try
            {
                //Asigno a una variable, el filtro de la row con el precio mas alto.
                decimal resultado = dtArticulo.Rows.Cast<DataRow>().Select(row => row.Field<decimal>("Articulo_PrecioVenta")).Min();
                return resultado;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }

        //Metodo que obtiene los datos para armar grafico top 3 de precio de venta mas elevados.
        public List<E_Articulo> ObtenerDatosGraficoPVenta()
        {
            //Creo dos listas.
            List<E_Articulo> listaArticulo = new List<E_Articulo>();
            List<E_Articulo> listaFiltrada = new List<E_Articulo>();
            try
            {
                if (dtArticulo.Rows.Count > 0)
                {
                    listaArticulo = new List<E_Articulo>();
                    listaFiltrada = new List<E_Articulo>();

                    foreach (DataRow r in ds.Tables["Articulo"].Rows)
                    {
                        E_Articulo oArticulo = new E_Articulo();
                        oArticulo.Codigo = r.Field<string>(0);
                        oArticulo.Descripcion = r.Field<string>(1);
                        oArticulo.oMarca.Codigo = r.Field<int>(2);
                        oArticulo.Talle = r.Field<string>(3);
                        oArticulo.Existencia = r.Field<int>(4);
                        oArticulo.stockMin = r.Field<int>(5);
                        oArticulo.stockMax = r.Field<int>(6);
                        oArticulo.precioCosto = r.Field<decimal>(7);
                        oArticulo.precioVenta = r.Field<decimal>(8);
                        oArticulo.precioPromocion = r.Field<decimal>(9);
                        oArticulo.oProveedor.Id = r.Field<int>(10);
                        oArticulo.Observacion = r.Field<string>(11);
                        oArticulo.oEmpleado.Dni = r.Field<int>(12);
                        oArticulo.Activo = r.Field<bool>(13);
                        //Añado el articulo a lista.
                        listaArticulo.Add(oArticulo);

                    }
                    //Asigno a la listaFiltrada, la lista de articulos ordenada de manera descendente y tomo los primeros 3 elementos.
                    listaFiltrada = listaArticulo.OrderByDescending(articulo => articulo.precioVenta).Take(3).ToList();
                    //Retorno lista filtrada.
                    return listaFiltrada;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo que obtiene los datos para armar grafico top 3 de precio de venta mas bajos.
        public List<E_Articulo> ObtenerDatosGraficoPVenta2()
        {
            //Creo dos listas.
            List<E_Articulo> listaArticulo = new List<E_Articulo>();
            List<E_Articulo> listaFiltrada = new List<E_Articulo>();
            try
            {
                if (dtArticulo.Rows.Count > 0)
                {
                    listaArticulo = new List<E_Articulo>();
                    listaFiltrada = new List<E_Articulo>();

                    foreach (DataRow r in ds.Tables["Articulo"].Rows)
                    {
                        E_Articulo oArticulo = new E_Articulo();
                        oArticulo.Codigo = r.Field<string>(0);
                        oArticulo.Descripcion = r.Field<string>(1);
                        oArticulo.oMarca.Codigo = r.Field<int>(2);
                        oArticulo.Talle = r.Field<string>(3);
                        oArticulo.Existencia = r.Field<int>(4);
                        oArticulo.stockMin = r.Field<int>(5);
                        oArticulo.stockMax = r.Field<int>(6);
                        oArticulo.precioCosto = r.Field<decimal>(7);
                        oArticulo.precioVenta = r.Field<decimal>(8);
                        oArticulo.precioPromocion = r.Field<decimal>(9);
                        oArticulo.oProveedor.Id = r.Field<int>(10);
                        oArticulo.Observacion = r.Field<string>(11);
                        oArticulo.oEmpleado.Dni = r.Field<int>(12);
                        oArticulo.Activo = r.Field<bool>(13);
                        //Añado el articulo a lista.
                        listaArticulo.Add(oArticulo);

                    }
                    //Asigno a la listaFiltrada, la lista de articulos ordenada de manera descendente y tomo los primeros 3 elementos.
                    listaFiltrada = listaArticulo.OrderBy(articulo => articulo.precioVenta).Take(3).ToList();
                    //Retorno lista filtrada.
                    return listaFiltrada;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo que obtiene los datos para armar grafico top 3 de exitencias mas elevados.
        public List<E_Articulo> ObtenerDatosGraficoExistencias()
        {
            //Creo dos listas.
            List<E_Articulo> listaArticulo = new List<E_Articulo>();
            List<E_Articulo> listaFiltrada = new List<E_Articulo>();
            try
            {
                if (dtArticulo.Rows.Count > 0)
                {
                    listaArticulo = new List<E_Articulo>();
                    listaFiltrada = new List<E_Articulo>();

                    foreach (DataRow r in ds.Tables["Articulo"].Rows)
                    {
                        E_Articulo oArticulo = new E_Articulo();
                        oArticulo.Codigo = r.Field<string>(0);
                        oArticulo.Descripcion = r.Field<string>(1);
                        oArticulo.oMarca.Codigo = r.Field<int>(2);
                        oArticulo.Talle = r.Field<string>(3);
                        oArticulo.Existencia = r.Field<int>(4);
                        oArticulo.stockMin = r.Field<int>(5);
                        oArticulo.stockMax = r.Field<int>(6);
                        oArticulo.precioCosto = r.Field<decimal>(7);
                        oArticulo.precioVenta = r.Field<decimal>(8);
                        oArticulo.precioPromocion = r.Field<decimal>(9);
                        oArticulo.oProveedor.Id = r.Field<int>(10);
                        oArticulo.Observacion = r.Field<string>(11);
                        oArticulo.oEmpleado.Dni = r.Field<int>(12);
                        oArticulo.Activo = r.Field<bool>(13);
                        //Añado el articulo a lista.
                        listaArticulo.Add(oArticulo);

                    }
                    //Asigno a la listaFiltrada, la lista de articulos ordenada de manera descendente y tomo los primeros 3 elementos.
                    listaFiltrada = listaArticulo.OrderByDescending(articulo => articulo.Existencia).Take(3).ToList();
                    //Retorno lista filtrada.
                    return listaFiltrada;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo que obtiene los datos para armar grafico top 3 de menos exitencias.
        public List<E_Articulo> ObtenerDatosGraficoExistencias2()
        {
            //Creo dos listas.
            List<E_Articulo> listaArticulo = new List<E_Articulo>();
            List<E_Articulo> listaFiltrada = new List<E_Articulo>();
            try
            {
                if (dtArticulo.Rows.Count > 0)
                {
                    listaArticulo = new List<E_Articulo>();
                    listaFiltrada = new List<E_Articulo>();

                    foreach (DataRow r in ds.Tables["Articulo"].Rows)
                    {
                        E_Articulo oArticulo = new E_Articulo();
                        oArticulo.Codigo = r.Field<string>(0);
                        oArticulo.Descripcion = r.Field<string>(1);
                        oArticulo.oMarca.Codigo = r.Field<int>(2);
                        oArticulo.Talle = r.Field<string>(3);
                        oArticulo.Existencia = r.Field<int>(4);
                        oArticulo.stockMin = r.Field<int>(5);
                        oArticulo.stockMax = r.Field<int>(6);
                        oArticulo.precioCosto = r.Field<decimal>(7);
                        oArticulo.precioVenta = r.Field<decimal>(8);
                        oArticulo.precioPromocion = r.Field<decimal>(9);
                        oArticulo.oProveedor.Id = r.Field<int>(10);
                        oArticulo.Observacion = r.Field<string>(11);
                        oArticulo.oEmpleado.Dni = r.Field<int>(12);
                        oArticulo.Activo = r.Field<bool>(13);
                        //Añado el articulo a lista.
                        listaArticulo.Add(oArticulo);

                    }
                    //Asigno a la listaFiltrada, la lista de articulos ordenada y tomo los primeros 3 elementos.
                    listaFiltrada = listaArticulo.OrderBy(articulo => articulo.Existencia).Take(3).ToList();
                    //Retorno lista filtrada.
                    return listaFiltrada;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        
    }
}
