using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiciosI;
using Entidad;
using DAO;
using System.Data;

namespace MPP
{
    public class MPP_Proveedor : Iabmc<E_Proveedor>
    {
        //Instancio objetos de la DAO.
        AccesoDB oAcceso;
        DataSet ds;
        DataTable dtProveedor;

        public MPP_Proveedor()
        {
            try
            {
                oAcceso = new AccesoDB();

                ds = oAcceso.ds;
                dtProveedor = oAcceso.dtProveedor;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Alta.
        public void Alta(E_Proveedor oProveedor)
        {
            try
            {
                DataRow dr = dtProveedor.NewRow();

                dtProveedor.Rows.Add(new object[]{
                   null,
                   oProveedor.Nombre,
                   oProveedor.Direccion,
                   oProveedor.Localidad,
                   oProveedor.Provincia,
                   oProveedor.Telefono,
                   oProveedor.Mail,
                   oProveedor.Activo = true,
                   oProveedor.oGerente.Dni
              });
                oAcceso.GrabarDatos();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Baja.
        public void Baja(E_Proveedor oProveedor)
        {
            try
            {
                dtProveedor.Rows.Find(oProveedor.Id).ItemArray = new object[] {null, oProveedor.Nombre,
                oProveedor.Direccion, oProveedor.Localidad, oProveedor.Provincia, oProveedor.Telefono, oProveedor.Mail,
                oProveedor.Activo = false, oProveedor.oGerente.Dni /*oProveedor.dni_Gerente */};
                oAcceso.GrabarDatos();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Listar.
        public List<E_Proveedor> Listar()
        {
            List<E_Proveedor> listaProveedor = new List<E_Proveedor>();

            try
            {
                if (dtProveedor.Rows.Count > 0)
                {
                    listaProveedor = new List<E_Proveedor>();

                    foreach (DataRow r in ds.Tables["Proveedor"].Rows)
                    {
                        E_Proveedor oProveedor = new E_Proveedor();
                        oProveedor.Id = r.Field<int>(0);
                        oProveedor.Nombre = r.Field<string>(1);
                        oProveedor.Direccion = r.Field<string>(2);
                        oProveedor.Localidad = r.Field<string>(3);
                        oProveedor.Provincia = r.Field<string>(4);
                        oProveedor.Telefono = r.Field<Int64>(5);
                        oProveedor.Mail = r.Field<string>(6);
                        oProveedor.Activo = r.Field<bool>(7);
                        oProveedor.oGerente.Dni = r.Field<int>(8);

                        listaProveedor.Add(oProveedor);
                    }

                    return listaProveedor;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Modificar.
        public void Modificar(E_Proveedor oProveedor)
        {
            try
            {
                dtProveedor.Rows.Find(oProveedor.Id).ItemArray = new object[] {null, oProveedor.Nombre,
                oProveedor.Direccion, oProveedor.Localidad, oProveedor.Provincia, oProveedor.Telefono, oProveedor.Mail,
                oProveedor.Activo = true, oProveedor.oGerente.Dni  };
                oAcceso.GrabarDatos();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Consultar.
        public List<E_Proveedor> Consultar(string pNombre)
        {
            List<E_Proveedor> listaProveedor = new List<E_Proveedor>();

            try
            {
                if (dtProveedor.Rows.Count > 0)
                {
                    listaProveedor = new List<E_Proveedor>();

                    foreach (DataRow r in ds.Tables["Proveedor"].Rows)
                    {
                        if (r["Proveedor_Nombre"].ToString().StartsWith(pNombre))
                        {
                            E_Proveedor oProveedor = new E_Proveedor();
                            oProveedor.Id = r.Field<int>(0);
                            oProveedor.Nombre = r.Field<string>(1);
                            oProveedor.Direccion = r.Field<string>(2);
                            oProveedor.Localidad = r.Field<string>(3);
                            oProveedor.Provincia = r.Field<string>(4);
                            oProveedor.Telefono = r.Field<Int64>(5);
                            oProveedor.Mail = r.Field<string>(6);
                            oProveedor.Activo = r.Field<bool>(7);
                            oProveedor.oGerente.Dni = r.Field<int>(8);

                            listaProveedor.Add(oProveedor);
                            break;
                        }
                    }

                    return listaProveedor;
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
