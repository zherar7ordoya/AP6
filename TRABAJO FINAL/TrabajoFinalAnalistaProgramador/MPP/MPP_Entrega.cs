using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using DAO;
using ServiciosI;
using System.Data;

namespace MPP
{
    public class MPP_Entrega : Iabmc<E_Entrega>
    {
        //Instancio objetos de la DAO.
        AccesoDB oAcceso;
        DataSet ds;
        DataTable dtEntrega;

        public MPP_Entrega()
        {
            try
            {
                oAcceso = new AccesoDB();

                ds = oAcceso.ds;
                dtEntrega = oAcceso.dtEntrega;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void Alta(E_Entrega oEntrega)
        {
            try
            {
                DataRow dr = dtEntrega.NewRow();

                dtEntrega.Rows.Add(new object[]{
                   null,
                   oEntrega.Fecha,
                   oEntrega.Hora,
                   oEntrega.oProveedor.Id,
                   oEntrega.oGerente.Dni
                });
                oAcceso.GrabarDatos();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        public void Baja(E_Entrega oEntrega)
        {
            try
            {
                dtEntrega.Rows.Remove(dtEntrega.Rows.Find(oEntrega.Id));
                oAcceso.GrabarDatos();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Entrega> Consultar(string pFecha)
        {
            List<E_Entrega> listaEntrega = new List<E_Entrega>();

            try
            {
                if (dtEntrega.Rows.Count > 0)
                {
                    listaEntrega = new List<E_Entrega>();

                    foreach (DataRow r in ds.Tables["Entrega"].Rows)
                    {
                        if (r["Entrega_Fecha"].ToString().StartsWith(pFecha))
                        {
                            E_Entrega oEntrega = new E_Entrega();
                            oEntrega.Id = r.Field<Int32>(0);
                            oEntrega.Fecha = r.Field<DateTime>(1);
                            oEntrega.Hora = r.Field<string>(2);
                            oEntrega.oProveedor.Id = r.Field<int>(3);
                            oEntrega.oGerente.Dni = r.Field<int>(4);

                            listaEntrega.Add(oEntrega);
                            break;
                        }
                    }

                    return listaEntrega;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Entrega> Listar()
        {
            List<E_Entrega> listaEntrega = new List<E_Entrega>();

            try
            {
                if (dtEntrega.Rows.Count > 0)
                {
                    listaEntrega = new List<E_Entrega>();

                    foreach (DataRow r in ds.Tables["Entrega"].Rows)
                    {
                        E_Entrega oEntrega = new E_Entrega();
                        oEntrega.Id = r.Field<Int32>(0);
                        oEntrega.Fecha = r.Field<DateTime>(1);
                        oEntrega.Hora = r.Field<string>(2);
                        oEntrega.oProveedor.Id = r.Field<int>(3);
                        oEntrega.oGerente.Dni = r.Field<int>(4);

                        listaEntrega.Add(oEntrega);
                    }

                    return listaEntrega;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void Modificar(E_Entrega oEntrega)
        {
            try
            {
                dtEntrega.Rows.Find(oEntrega.Id).ItemArray = new object[] { null, oEntrega.Fecha, oEntrega.Hora, oEntrega.oProveedor.Id, oEntrega.oGerente.Dni };
                oAcceso.GrabarDatos();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Ordenar por fecha.
        public List<E_Entrega> ListarOrdenadoFecha()
        {
            List<E_Entrega> listaEntrega = new List<E_Entrega>();

            try
            {
                if (dtEntrega.Rows.Count > 0)
                {
                    listaEntrega = new List<E_Entrega>();

                    foreach (DataRow r in ds.Tables["Entrega"].Rows)
                    {
                        E_Entrega oEntrega = new E_Entrega();
                        oEntrega.Id = r.Field<Int32>(0);
                        oEntrega.Fecha = r.Field<DateTime>(1);
                        oEntrega.Hora = r.Field<string>(2);
                        oEntrega.oProveedor.Id = r.Field<int>(3);
                        oEntrega.oGerente.Dni = r.Field<int>(4);

                        listaEntrega.Add(oEntrega);
                    }

                    listaEntrega.Sort((x, y) => x.Fecha.CompareTo(y.Fecha));

                    return listaEntrega;
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
