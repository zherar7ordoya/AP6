using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiciosI;
using Entidad;
using DAO;
using System.Collections;
using System.Data;
using ServiciosEncriptacion;

namespace MPP
{
    public class MPP_Empleado : Iabmc<E_Empleado>
    {
        //Instancio objetos de la DAO.
        AccesoDB oAcceso;
        DataSet ds;
        DataTable dtEmpleado;

        public MPP_Empleado()
        {
            try
            {
                oAcceso = new AccesoDB();

                ds = oAcceso.ds;
                dtEmpleado = oAcceso.dtEmpleado;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void Alta(E_Empleado oEmpleado)
        {
            try
            {
                DataRow dr = dtEmpleado.NewRow();

                dtEmpleado.Rows.Add(new object[]{
                   oEmpleado.Dni,
                   oEmpleado.Nombre,
                   oEmpleado.Apellido,
                   oEmpleado.Direccion,
                   oEmpleado.Celular,
                   oEmpleado.Telefono,
                   oEmpleado.fechaNacimiento,
                   oEmpleado.estadoCivil,
                   oEmpleado.sueldoBruto,
                   oEmpleado.oUsuario.idUsuario,
                   oEmpleado.mailPersonal
                });
                oAcceso.GrabarDatos();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        public void Baja(E_Empleado oEmpleado)
        {
            try
            {
                dtEmpleado.Rows.Remove(dtEmpleado.Rows.Find(oEmpleado.Dni));
                oAcceso.GrabarDatos();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Empleado> Consultar(string pNombre)
        {
            List<E_Empleado> listaEmpleado = new List<E_Empleado>();

            try
            {
                if (dtEmpleado.Rows.Count > 0)
                {
                    listaEmpleado = new List<E_Empleado>();

                    foreach (DataRow r in ds.Tables["Empleado"].Rows)
                    {
                        if (r["Empleado_Nombre"].ToString().StartsWith(pNombre))
                        {
                            E_Empleado oEmpleado = new E_Empleado();
                            oEmpleado.Dni = r.Field<Int32>(0);
                            oEmpleado.Nombre = r.Field<string>(1);
                            oEmpleado.Apellido = r.Field<string>(2);
                            oEmpleado.Direccion = r.Field<string>(3);
                            oEmpleado.Celular = r.Field<Int64>(4);
                            oEmpleado.Telefono = r.Field<Int64>(5);
                            oEmpleado.fechaNacimiento = r.Field<DateTime>(6);
                            oEmpleado.estadoCivil = r.Field<string>(7);
                            oEmpleado.sueldoBruto = r.Field<decimal>(8);
                            oEmpleado.oUsuario.idUsuario = r.Field<int>(9);
                            oEmpleado.mailPersonal = r.Field<string>(10);

                            listaEmpleado.Add(oEmpleado);
                            break;
                        }
                    }

                    return listaEmpleado;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<E_Empleado> Listar()
        {
            List<E_Empleado> listaEmpleado = new List<E_Empleado>();

            try
            {
                if (dtEmpleado.Rows.Count > 0)
                {
                    listaEmpleado = new List<E_Empleado>();

                    foreach (DataRow r in ds.Tables["Empleado"].Rows)
                    {
                        E_Empleado oEmpleado = new E_Empleado();
                        oEmpleado.Dni = r.Field<Int32>(0);
                        oEmpleado.Nombre = r.Field<string>(1);
                        oEmpleado.Apellido = r.Field<string>(2);
                        oEmpleado.Direccion = r.Field<string>(3);
                        oEmpleado.Celular = r.Field<Int64>(4);
                        oEmpleado.Telefono = r.Field<Int64>(5);
                        oEmpleado.fechaNacimiento = r.Field<DateTime>(6);
                        oEmpleado.estadoCivil = r.Field<string>(7);
                        oEmpleado.sueldoBruto = r.Field<decimal>(8);
                        oEmpleado.oUsuario.idUsuario = r.Field<int>(9);
                        oEmpleado.mailPersonal = r.Field<string>(10);

                        listaEmpleado.Add(oEmpleado);
                    }

                    return listaEmpleado;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void Modificar(E_Empleado oEmpleado)
        {
            try
            {
                dtEmpleado.Rows.Find(oEmpleado.Dni).ItemArray = new object[] { oEmpleado.Dni, oEmpleado.Nombre, oEmpleado.Apellido, oEmpleado.Direccion, oEmpleado.Celular, oEmpleado.Telefono, oEmpleado.fechaNacimiento, oEmpleado.estadoCivil, oEmpleado.sueldoBruto, oEmpleado.oUsuario.idUsuario, oEmpleado.mailPersonal };
                oAcceso.GrabarDatos();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo para validar que no ingrese dni de empleados repetidos.
        public bool ValidarDni(int pDni)
        {
            bool resultado = true;

            try
            {
                foreach (DataRow row in dtEmpleado.Rows)
                {
                    //Si el id coincide con el valor del id del objeto repetido.
                    if (Convert.ToInt32(row["Empleado_Dni"]) == pDni)
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
