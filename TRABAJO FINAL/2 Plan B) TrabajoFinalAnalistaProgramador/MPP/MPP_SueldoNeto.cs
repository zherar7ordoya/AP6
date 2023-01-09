using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using ServiciosEncriptacion;
using ServiciosI;
using DAO;
using System.Data;
using Microsoft.Reporting.WinForms;

namespace MPP
{
    public class MPP_SueldoNeto 
    {
        //Instacio objetos de la DAO.
        AccesoDB oAcceso;
        DataSet ds;
        DataTable dtSueldoNeto;

        public MPP_SueldoNeto()
        {
            try
            {
                oAcceso = new AccesoDB();

                ds = oAcceso.ds;
                dtSueldoNeto = oAcceso.dtSueldoNeto;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Alta.
        public void Alta(E_SueldoNeto oSueldoNeto)
        {
            try
            {
                DataRow dr = dtSueldoNeto.NewRow();

                dtSueldoNeto.Rows.Add(new object[]{
                   null,
                   oSueldoNeto.Fecha,
                   oSueldoNeto.oEmpleado.Dni,
                   oSueldoNeto.sueldoBruto,
                   oSueldoNeto.cantidadInasistencia,
                   oSueldoNeto.Puntualidad,
                   oSueldoNeto.horasExtra,
                   oSueldoNeto.oGerente.Dni,
                   oSueldoNeto.Importe
              });
                oAcceso.GrabarDatos();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Baja.
        public void Baja(E_SueldoNeto oSueldoNeto)
        {
            try
            {
                dtSueldoNeto.Rows.Remove(dtSueldoNeto.Rows.Find(oSueldoNeto.Id));
                oAcceso.GrabarDatos();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Consultar.
        public List<E_SueldoNeto> Consultar(string pFecha)
        {
            List<E_SueldoNeto> listaSueldo = new List<E_SueldoNeto>();

            try
            {
                if (dtSueldoNeto.Rows.Count > 0)
                {
                    listaSueldo = new List<E_SueldoNeto>();

                    foreach (DataRow r in ds.Tables["SueldoNeto"].Rows)
                    {
                        if (r["SueldoNeto_Fecha"].ToString().StartsWith(pFecha))
                        {
                            E_SueldoNeto oSueldoNeto = new E_SueldoNeto();
                            oSueldoNeto.Id = r.Field<Int32>(0);
                            oSueldoNeto.Fecha = r.Field<DateTime>(1);
                            oSueldoNeto.oEmpleado.Dni = r.Field<Int32>(2);
                            oSueldoNeto.sueldoBruto = r.Field<decimal>(3);
                            oSueldoNeto.cantidadInasistencia = r.Field<Int32>(4);
                            oSueldoNeto.Puntualidad = r.Field<string>(5);
                            oSueldoNeto.horasExtra = r.Field<Int32>(6);
                            oSueldoNeto.oGerente.Dni = r.Field<Int32>(7);
                            oSueldoNeto.Importe = r.Field<decimal>(8);

                            listaSueldo.Add(oSueldoNeto);
                            break;
                        }
                    }

                    return listaSueldo;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Listar.
        public List<E_SueldoNeto> Listar()
        {
            List<E_SueldoNeto> listaSueldo = new List<E_SueldoNeto>();

            try
            {
                if (dtSueldoNeto.Rows.Count > 0)
                {
                    listaSueldo = new List<E_SueldoNeto>();

                    foreach (DataRow r in ds.Tables["SueldoNeto"].Rows)
                    {
                        E_SueldoNeto oSueldoNeto = new E_SueldoNeto();
                        oSueldoNeto.Id = r.Field<Int32>(0);
                        oSueldoNeto.Fecha = r.Field<DateTime>(1);
                        oSueldoNeto.oEmpleado.Dni = r.Field<Int32>(2);
                        oSueldoNeto.sueldoBruto = r.Field<decimal>(3);
                        oSueldoNeto.cantidadInasistencia = r.Field<Int32>(4);
                        oSueldoNeto.Puntualidad = r.Field<string>(5);
                        oSueldoNeto.horasExtra = r.Field<Int32>(6);
                        oSueldoNeto.oGerente.Dni = r.Field<Int32>(7);
                        oSueldoNeto.Importe = r.Field<decimal>(8);

                        listaSueldo.Add(oSueldoNeto);
                    }

                    return listaSueldo;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
       
        //Metodo para obtener el sueldo mas alto.
        public decimal ObtenerSueldoNetoAlto()
        {
            try
            {
                //Asigno a una variable, el filtro de la row con el precio mas alto.
                decimal resultado = dtSueldoNeto.Rows.Cast<DataRow>().Select(row => row.Field<decimal>("SueldoNeto_Importe")).Max();
                return resultado;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo que obtiene los datos para armar grafico top 3 de exitencias mas elevados.
        public List<E_SueldoNeto> ObtenerDatosGraficoSueldo()
        {
            //Creo dos listas.
            List<E_SueldoNeto> listaSueldo = new List<E_SueldoNeto>();
            List<E_SueldoNeto> listaFiltrada = new List<E_SueldoNeto>();
            try
            {
                if (dtSueldoNeto.Rows.Count > 0)
                {
                    listaSueldo = new List<E_SueldoNeto>();
                    listaFiltrada = new List<E_SueldoNeto>();

                    foreach (DataRow r in ds.Tables["SueldoNeto"].Rows)
                    {
                        E_SueldoNeto oSueldoNeto = new E_SueldoNeto();
                        oSueldoNeto.Id = r.Field<Int32>(0);
                        oSueldoNeto.Fecha = r.Field<DateTime>(1);
                        oSueldoNeto.oEmpleado.Dni = r.Field<Int32>(2);
                        oSueldoNeto.sueldoBruto = r.Field<decimal>(3);
                        oSueldoNeto.cantidadInasistencia = r.Field<Int32>(4);
                        oSueldoNeto.Puntualidad = r.Field<string>(5);
                        oSueldoNeto.horasExtra = r.Field<Int32>(6);
                        oSueldoNeto.oGerente.Dni = r.Field<Int32>(7);
                        oSueldoNeto.Importe = r.Field<decimal>(8);
                        //Añado el articulo a lista.
                        listaSueldo.Add(oSueldoNeto);

                    }
                    //Asigno a la listaFiltrada, la lista de sueldos ordenada de manera descendente y tomo los primeros 3 elementos.
                    listaFiltrada = listaSueldo.OrderByDescending(sueldo => sueldo.Importe).Take(3).ToList();
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
