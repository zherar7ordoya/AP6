using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using System.Data;
using Entidad;

namespace MPP
{
    public class MPP_BackUp
    {
        //Instancio objetos de la DAO.
        AccesoDB oAcceso;

        DataSet ds;
        DataTable dtBackUp;

        public MPP_BackUp()
        {
            try
            {
                oAcceso = new AccesoDB();
                ds = oAcceso.ds;
                dtBackUp = oAcceso.dtBackUp;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
          
        }
        //Metodo Alta.
        public void Alta(E_BackUp oBackUp)
        {
            try
            {
                DataRow dr = dtBackUp.NewRow();

                dtBackUp.Rows.Add(new object[]{
                   null,
                   oBackUp.oUsuario.idUsuario,
                   oBackUp.Fecha
              });
                oAcceso.GrabarDatos();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Listar.
        public List<E_BackUp> Listar()
        {
            List<E_BackUp> listaBackUp = new List<E_BackUp>();
            try
            {
                if (dtBackUp.Rows.Count > 0)
                {
                    listaBackUp = new List<E_BackUp>();

                    foreach (DataRow r in ds.Tables["BackUp"].Rows)
                    {
                        E_BackUp oBackup = new E_BackUp();
                        oBackup.Codigo = r.Field<Int32>(0);
                        oBackup.oUsuario.idUsuario = r.Field<Int32>(1);
                        oBackup.Fecha = r.Field<DateTime>(2);

                        listaBackUp.Add(oBackup);
                    }

                    return listaBackUp;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Consultar.
        public List<E_BackUp> Consultar(string pFecha)
        {
            List<E_BackUp> listaBackUp = new List<E_BackUp>();

            try
            {
                if (dtBackUp.Rows.Count > 0)
                {
                    listaBackUp = new List<E_BackUp>();

                    foreach (DataRow r in ds.Tables["BackUp"].Rows)
                    {
                        if (r["BackUp_Fecha"].ToString().StartsWith(pFecha.ToString()))
                        {
                            E_BackUp oBackup = new E_BackUp();
                            oBackup.Codigo = r.Field<Int32>(0);
                            oBackup.oUsuario.idUsuario = r.Field<Int32>(1);
                            oBackup.Fecha = r.Field<DateTime>(2);

                            listaBackUp.Add(oBackup);
                            break;
                        }
                    }

                    return listaBackUp;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Realizar BackUp.
        public void RealizarBackUp(string ruta)
        {
            try
            {
                oAcceso.RealizarBackUp(ruta);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
