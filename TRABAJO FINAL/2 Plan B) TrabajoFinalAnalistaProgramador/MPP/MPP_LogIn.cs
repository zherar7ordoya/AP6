using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidad;
using DAO;
using System.Data;

namespace MPP
{
    public class MPP_LogIn
    {
        //Instancio objetoa de la DAO.
        AccesoDB oAcceso;
        DataSet ds;
        DataTable dtLogIn;

        public MPP_LogIn()
        {
            try
            {
                oAcceso = new AccesoDB();

                ds = oAcceso.ds;
                dtLogIn = oAcceso.dtLogin;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Alta.
        public void Alta(E_LogIn oLogin)
        {
            try
            {
                DataRow dr = dtLogIn.NewRow();

                dtLogIn.Rows.Add(new object[]{
                   null,
                   oLogin.Fecha,
                   oLogin.oUsuario.idUsuario
              });
                oAcceso.GrabarDatos();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Listar.
        public List<E_LogIn> Listar()
        {
            List<E_LogIn> listaLogin = new List<E_LogIn>();

            try
            {
                if (dtLogIn.Rows.Count > 0)
                {
                    listaLogin = new List<E_LogIn>();

                    foreach (DataRow r in ds.Tables["LogIn"].Rows)
                    {
                        E_LogIn oLogin = new E_LogIn();
                        oLogin.Numero = r.Field<Int32>(0);
                        oLogin.Fecha = r.Field<DateTime>(1);
                        oLogin.oUsuario.idUsuario = r.Field<int>(2);

                        listaLogin.Add(oLogin);
                    }

                    return listaLogin;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Obtener usuario logeado.
        public string ObtenerUsuarioLogeado()
        {
            //Declaro variable.
            int idUsuario = 0;

            try
            {
                //Obtengo el ultimo row, es decir busco el ultimo usuario logeado.
                DataRow ultimaRow = dtLogIn.Rows[dtLogIn.Rows.Count - 1];
                //Recorro.
                foreach (DataRow r in dtLogIn.Rows)
                {
                    //Si r coincide con la ultima row.
                    if (r == ultimaRow)
                    {
                        //Asigno el id a la variable y corto el recorrido.
                        idUsuario = Convert.ToInt32(r["LogIn_Usuario_Id"]);
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                //Retorno el id de usuario logeado.
                return idUsuario.ToString();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
