using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using ServiciosI;
using DAO;
using System.Data;

namespace MPP
{
    public class MPP_Marca : Iabmc<E_Marca>
    {
        //Instancio objetos de la DAO.
        AccesoDB oAcceso;
        DataSet ds;
        DataTable dtMarca;

        public MPP_Marca()
        {
            try
            {
                oAcceso = new AccesoDB();

                ds = oAcceso.ds;
                dtMarca = oAcceso.dtMarca;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Alta.
        public void Alta(E_Marca oMarca)
        {
            try
            {
                DataRow dr = dtMarca.NewRow();

                dtMarca.Rows.Add(new object[]{
                   null,
                   oMarca.Nombre,
                   oMarca.oGerente.Dni
                });
                oAcceso.GrabarDatos();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Baja.
        public void Baja(E_Marca oMarca)
        {
            try
            {
                dtMarca.Rows.Remove(dtMarca.Rows.Find(oMarca.Codigo));
                oAcceso.GrabarDatos();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Consultar.
        public List<E_Marca> Consultar(string pNombre)
        {
            List<E_Marca> listaMarca = new List<E_Marca>();

            try
            {
                if (dtMarca.Rows.Count > 0)
                {
                    listaMarca = new List<E_Marca>();

                    foreach (DataRow r in ds.Tables["Marca"].Rows)
                    {
                        if (r["Marca_Nombre"].ToString().StartsWith(pNombre))
                        {
                            E_Marca oMarca = new E_Marca();
                            oMarca.Codigo = r.Field<Int32>(0);
                            oMarca.Nombre = r.Field<string>(1);
                            oMarca.oGerente.Dni = r.Field<int>(2);

                            listaMarca.Add(oMarca);
                            break;
                        }
                    }

                    return listaMarca;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Listar.
        public List<E_Marca> Listar()
        {
            List<E_Marca> listaMarca = new List<E_Marca>();

            try
            {
                if (dtMarca.Rows.Count > 0)
                {
                    listaMarca = new List<E_Marca>();

                    foreach (DataRow r in ds.Tables["Marca"].Rows)
                    {
                        E_Marca oMarca = new E_Marca();
                        oMarca.Codigo = r.Field<Int32>(0);
                        oMarca.Nombre = r.Field<string>(1);
                        oMarca.oGerente.Dni = r.Field<int>(2);

                        listaMarca.Add(oMarca);
                    }

                    return listaMarca;
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Modificar.
        public void Modificar(E_Marca oMarca)
        {
            try
            {
                dtMarca.Rows.Find(oMarca.Codigo).ItemArray = new object[] { null, oMarca.Nombre, oMarca.oGerente.Dni };
                oAcceso.GrabarDatos();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
