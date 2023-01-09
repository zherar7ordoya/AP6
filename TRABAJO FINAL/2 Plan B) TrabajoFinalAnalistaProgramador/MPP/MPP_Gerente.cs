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
    public class MPP_Gerente : Iabmc<E_Gerente>
    {
        //Instancio objetos de la DAO.
        AccesoDB oAcceso;
        DataSet ds;
        DataTable dtGerente;

        public MPP_Gerente()
        {
            try
            {
                oAcceso = new AccesoDB();

                ds = oAcceso.ds;
                dtGerente = oAcceso.dtGerente;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void Alta(E_Gerente oGerente)
        {
            try
            {
                DataRow dr = dtGerente.NewRow();

                dtGerente.Rows.Add(new object[]{
                   oGerente.Dni,
                   oGerente.Nombre,
                   oGerente.Apellido,
                   oGerente.Direccion,
                   oGerente.Celular,
                   oGerente.Telefono,
                   oGerente.fechaNacimiento,
                   oGerente.estadoCivil,
                   oGerente.sueldoBruto,
                   oGerente.oUsuario.idUsuario,
                   oGerente.mailPersonal,
                   oGerente.mailEmpresarial
                });
                oAcceso.GrabarDatos();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        public void Baja(E_Gerente oGerente)
        {
            try
            {
                dtGerente.Rows.Remove(dtGerente.Rows.Find(oGerente.Dni));
                oAcceso.GrabarDatos();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Gerente> Consultar(string pNombre)
        {
           
                List<E_Gerente> listaGerente = new List<E_Gerente>();

                try
                {
                    if (dtGerente.Rows.Count > 0)
                    {
                        listaGerente = new List<E_Gerente>();

                        foreach (DataRow r in ds.Tables["Gerente"].Rows)
                        {
                            if (r["Gerente_Nombre"].ToString().StartsWith(pNombre))
                            {
                                E_Gerente oGerente = new E_Gerente();
                                oGerente.Dni = r.Field<Int32>(0);
                                oGerente.Nombre = r.Field<string>(1);
                                oGerente.Apellido = r.Field<string>(2);
                                oGerente.Direccion = r.Field<string>(3);
                                oGerente.Celular = r.Field<Int64>(4);
                                oGerente.Telefono = r.Field<Int64>(5);
                                oGerente.fechaNacimiento = r.Field<DateTime>(6);
                                oGerente.estadoCivil = r.Field<string>(7);
                                oGerente.sueldoBruto = r.Field<decimal>(8);
                                oGerente.oUsuario.idUsuario = r.Field<int>(9);
                                oGerente.mailPersonal = r.Field<string>(10);
                                oGerente.mailEmpresarial = r.Field<string>(11);

                                listaGerente.Add(oGerente);
                                break;
                            }
                        }

                        return listaGerente;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex) { throw new Exception(ex.Message); }
        }  

        public List<E_Gerente> Listar()
        {
            List<E_Gerente> listaGerente = new List<E_Gerente>();

            try
            {
                if (dtGerente.Rows.Count > 0)
                {
                    listaGerente = new List<E_Gerente>();

                    foreach (DataRow r in ds.Tables["Gerente"].Rows)
                    {
                        E_Gerente oGerente = new E_Gerente();
                        oGerente.Dni = r.Field<Int32>(0);
                        oGerente.Nombre = r.Field<string>(1);
                        oGerente.Apellido = r.Field<string>(2);
                        oGerente.Direccion = r.Field<string>(3);
                        oGerente.Celular = r.Field<Int64>(4);
                        oGerente.Telefono = r.Field<Int64>(5);
                        oGerente.fechaNacimiento = r.Field<DateTime>(6);
                        oGerente.estadoCivil = r.Field<string>(7);
                        oGerente.sueldoBruto = r.Field<decimal>(8);
                        oGerente.oUsuario.idUsuario = r.Field<int>(9);
                        oGerente.mailPersonal = r.Field<string>(10);
                        oGerente.mailEmpresarial = r.Field<string>(11);

                        listaGerente.Add(oGerente);
                    }

                    return listaGerente;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void Modificar(E_Gerente oGerente)
        {
            try
            {
                dtGerente.Rows.Find(oGerente.Dni).ItemArray = new object[] { oGerente.Dni, oGerente.Nombre, oGerente.Apellido, oGerente.Direccion, oGerente.Celular, oGerente.Telefono, oGerente.fechaNacimiento, oGerente.estadoCivil, oGerente.sueldoBruto, oGerente.oUsuario.idUsuario, oGerente.mailPersonal, oGerente.mailEmpresarial };
                oAcceso.GrabarDatos();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo para validar que no ingrese dni repetidos.
        public bool ValidarDni(int pDni)
        {
            bool resultado = true;

            try
            {
                foreach (DataRow row in dtGerente.Rows)
                {
                    //Si el id coincide con el valor del id del objeto repetido.
                    if (Convert.ToInt32(row["Gerente_Dni"]) == pDni)
                    {
                        //Coloco la variable en false, y luego doy aviso en la vista que se trata de un dni repetido.
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
    }
}
