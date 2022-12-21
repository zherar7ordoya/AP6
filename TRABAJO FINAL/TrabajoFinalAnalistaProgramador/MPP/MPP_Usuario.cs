using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using DAO;
using Entidad;
using ServiciosI;
using ServiciosEncriptacion;


namespace MPP
{
    public class MPP_Usuario : Iabmc<E_Usuario>
    {
        AccesoDB oAcceso;

        DataSet ds;
        DataTable dtUsuario;
        Encriptacion oEncriptacion;

        public MPP_Usuario()
        {
            try
            {
                oAcceso = new AccesoDB();

                ds = oAcceso.ds;
                dtUsuario = oAcceso.dtUsuario;
                oEncriptacion = new Encriptacion();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Alta.
        public void Alta(E_Usuario oUsuario)
        {
            try
            {
                DataRow dr = dtUsuario.NewRow();

                dtUsuario.Rows.Add(new object[]{
                   oUsuario.idUsuario,
                   oUsuario.fechaAlta,
                   oUsuario.Nombre,
                   oUsuario.Contraseña,
                   oUsuario.Bloqueado = false,
                   oUsuario.oPermiso.Id
              });
                oAcceso.GrabarDatos();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Baja.
        public void Baja(E_Usuario oUsuario)
        {
            try
            {
                dtUsuario.Rows.Remove(dtUsuario.Rows.Find(oUsuario.idUsuario));
                oAcceso.GrabarDatos();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Consultar.
        public List<E_Usuario> Consultar(string pNombre)
        {
            List<E_Usuario> listaUsuario = new List<E_Usuario>();

            try
            {
                if (dtUsuario.Rows.Count > 0)
                {
                    listaUsuario = new List<E_Usuario>();
                    //Encripto el nombre que se encribe en el txt de busqueda, para que pueda encontrarlo en el datatatable.
                    oEncriptacion.EncriptarSimple(ref pNombre);

                    foreach (DataRow r in ds.Tables["Usuario"].Rows)
                    {
                        if (r["Usuario_Nombre"].ToString().StartsWith(pNombre))
                        {
                            //Asigno a una variable el valor del datarow correspondiente al nombre de usuario (el cual esta encriptado);
                            string nombreUsuario = r.Field<string>(2);
                            string contraseña = r.Field<string>(3);
                            //Desencripto el nombre de usuario para listarlo de esa forma.
                            oEncriptacion.DesencriptarSimple(ref nombreUsuario);
                            oEncriptacion.DesencriptarSimple(ref contraseña);

                            E_Usuario oUsuario = new E_Usuario();
                            oUsuario.idUsuario = r.Field<int>(0);
                            oUsuario.fechaAlta = r.Field<DateTime>(1);
                            oUsuario.Nombre = nombreUsuario;
                            oUsuario.Contraseña = contraseña;
                            oUsuario.Bloqueado = r.Field<bool>(4);
                            oUsuario.oPermiso.Id = r.Field<string>(5);

                            listaUsuario.Add(oUsuario);
                            break;
                        }

                    }

                    return listaUsuario;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Listar.
        public List<E_Usuario> Listar()
        {
            List<E_Usuario> listaUsuario = new List<E_Usuario>();

            try
            {
                if (dtUsuario.Rows.Count > 0)
                {
                    listaUsuario = new List<E_Usuario>();

                    foreach (DataRow r in ds.Tables["Usuario"].Rows)
                    {
                        //Asigno a una variable el valor del datarow correspondiente al nombre de usuario (el cual esta encriptado);
                        string nombreUsuario = r.Field<string>(2);
                        string contraseña = r.Field<string>(3);
                        //Desencripto el nombre de usuario para listarlo de esa forma.
                        oEncriptacion.DesencriptarSimple(ref nombreUsuario);
                        oEncriptacion.DesencriptarSimple(ref contraseña);

                        E_Usuario oUsuario = new E_Usuario();
                        oUsuario.idUsuario = r.Field<int>(0);
                        oUsuario.fechaAlta = r.Field<DateTime>(1);
                        oUsuario.Nombre = nombreUsuario;
                        oUsuario.Contraseña = contraseña;
                        oUsuario.Bloqueado = r.Field<bool>(4);
                        oUsuario.oPermiso.Id = r.Field<string>(5);

                        listaUsuario.Add(oUsuario);
                    }

                    return listaUsuario;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }
        //Metodo Modificar.
        public void Modificar(E_Usuario oUsuario)
        {
            try
            {
                dtUsuario.Rows.Find(oUsuario.idUsuario).ItemArray = new object[] {oUsuario.idUsuario, oUsuario.fechaAlta,
                oUsuario.Nombre, oUsuario.Contraseña, oUsuario.Bloqueado = false, oUsuario.oPermiso.Id };
                oAcceso.GrabarDatos();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo para validar que no ingrese nombre de usuarios repetidos.
        public bool ValidarNombreUsuario(string pNombre)
        {
            bool resultado = true;

            try
            {
                foreach (DataRow row in dtUsuario.Rows)
                {
                    //Si el id coincide con el valor del id del objeto repetido.
                    if (row["Usuario_Nombre"].ToString() == pNombre)
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

        //Metodo para validar que no ingrese id de usuarios repetidos.
        public bool ValidarIdUsuario(int pId)
        {
            bool resultado = true;

            try
            {
                foreach (DataRow row in dtUsuario.Rows)
                {
                    //Si el id coincide con el valor del id del objeto repetido.
                    if (Convert.ToInt32(row["Usuario_Id"]) == pId)
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

        public bool ValidarIdAumento(int pId)
        {
            bool resultado = true;

            try
            {
                //Obtengo el ultimo row, es decir busco el ultimo usuario logeado.
                DataRow ultimaRow = dtUsuario.Rows[dtUsuario.Rows.Count - 1];

                foreach (DataRow row in dtUsuario.Rows)
                {
                    if(row == ultimaRow)
                    {
                        //Si el id coincide con el valor del id del objeto repetido.
                        if (pId == (Convert.ToInt32(row["Usuario_Id"]) + 1))
                        {
                            
                            resultado = true;
                            break;
                        }
                        else
                        {
                            resultado = false;
                        }
                    }
                }

                return resultado;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Validar para verificar que se ingresen correctamente el usuario y contraseña en el Login.
        public bool Validar(string pNombre, string pContraseña, bool pBloqueado)
        {
            E_Usuario oUsuario = new E_Usuario();
            string nombre;
            string contraseña;
            bool bloqueado;

            try
            {
                //Recorro el datatable de usuarios.
                foreach (DataRow row in dtUsuario.Rows)
                {
                    //Asigno al objeto el valor del row.
                    oUsuario.Nombre = row["Usuario_Nombre"].ToString();
                    oUsuario.Contraseña = row["Usuario_Contraseña"].ToString();
                    oUsuario.Bloqueado = Convert.ToBoolean(row["Usuario_Bloqueado"].ToString());
                    //Verifico que los parametros coincidan con las propiedades del objeto.
                    if (pNombre == oUsuario.Nombre && pContraseña == oUsuario.Contraseña && pBloqueado == oUsuario.Bloqueado)
                    {
                        //Paso el valor de los parametros al objeto.
                        oUsuario.Nombre = pNombre;
                        oUsuario.Contraseña = pContraseña;
                        oUsuario.Bloqueado = Convert.ToBoolean(pBloqueado);
                        //Corto el recorrido.
                        break;
                    }
                    //Sino asigno todos null.
                    else
                    {
                        oUsuario.Nombre = null;
                        oUsuario.Contraseña = null;
                        oUsuario.Bloqueado = true;
                    }
                }

                //Paso a la variable el valor del objeto.
                nombre = oUsuario.Nombre;
                contraseña = oUsuario.Contraseña;
                bloqueado = oUsuario.Bloqueado;
                //Si alguna variable es null retorno false, que el usuario o contraseña ingresados son incorrectos
                //o bien el usuario esta bloqueado.
                if (nombre == null || contraseña == null || bloqueado == true)
                {
                    return false;
                }
                //Sino retorno true.
                else
                {
                    return true;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo verificar tipo de usuario, para ver que permiso tiene asignado.
        public string VerificarTipoUsuario(E_Usuario oUsuario)
        {
            string encriptar = "";
            string nombre = " ";
            string permiso = " ";
            //Encripto el nombre de usuario.
            encriptar = oUsuario.Nombre;
            oEncriptacion.EncriptarSimple(ref encriptar);
            //Asgino al objeto el nombre encriptado.
            oUsuario.Nombre = encriptar;

            try
            {
                //Recorro el datatable.
                foreach (DataRow row in dtUsuario.Rows)
                {
                    //Si el nombre coincide con el row.
                    if (oUsuario.Nombre == row["Usuario_Nombre"].ToString())
                    {
                        //Asigno a las variables los valores correspondientes.
                        nombre = oUsuario.Nombre;
                        permiso = row["Usuario_Permiso"].ToString();
                        break;
                    }
                    else
                    {
                        //Sino las coloco en null.
                        nombre = null;
                        permiso = null;
                    }
                }
                //Asigno al objeto los valores de las variables.
                oUsuario.Nombre = nombre;
                oUsuario.oPermiso.Id = permiso;

                //Si alguno es null, retorno null.
                if (oUsuario.Nombre == null || oUsuario.oPermiso.Id == null)
                {
                    return null;
                }
                //Sino retorno el objeto con los valores correspondientes.
                else
                {
                    return oUsuario.ToString();
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo Bloquear usuario.
        public void BloquearUsuario(E_Usuario oUsuario)
        {
            bool resultado = false;
            int contadorId = 0;
            string nombreUsuario;
            string contraseña;
            DateTime fechaAlta = DateTime.Now;
            //Asigno a las variables el nombre de usuario y contraseña.
            nombreUsuario = oUsuario.Nombre;
            contraseña = oUsuario.Contraseña;
            //Encripto el nombre de usuario y contraseña.
            oEncriptacion.EncriptarSimple(ref nombreUsuario);
            oEncriptacion.EncriptarSimple(ref contraseña);
            try
            {
                //Recorro el datatable.
                foreach (DataRow row in dtUsuario.Rows)
                {
                    //A medida que recorro aumento el contador de id.
                    contadorId += 1;
                    //Asigno al row y al objeto el valor del contador.
                    row["Usuario_Id"] = contadorId;
                    oUsuario.idUsuario = contadorId;
                    //Si coincide el nombre de usuario encriptado y el id con las row en cuestion.
                    if (nombreUsuario == row["Usuario_Nombre"].ToString() && oUsuario.idUsuario == Convert.ToInt32(row["Usuario_Id"]))
                    {
                        //Asigno la variable bool en true.
                        resultado = true;
                        //Me traigo la fecha de alta tambien.
                        fechaAlta = Convert.ToDateTime(row["Usuario_FechaAlta"]);
                        break;
                    }
                }
                //Si es true bloqueo al usuario mediante la variable bloqueado en true, es decir hago una modificacion.
                if (resultado == true)
                {
                    dtUsuario.Rows.Find(oUsuario.idUsuario).ItemArray = new object[] {
                       oUsuario.idUsuario, fechaAlta, nombreUsuario,
                        contraseña, oUsuario.Bloqueado = true };
                    oAcceso.GrabarDatos();
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo Desbloquear usuario.
        public void DesbloquearUsuario(E_Usuario oUsuario)
        {
            string nombreUsuario;
            string contraseña;
            try
            {
                //Asigno a las variables el nombre de usuario y contraseña, para luego encriptarlos.
                nombreUsuario = oUsuario.Nombre;
                contraseña = oUsuario.Contraseña;
                oEncriptacion.EncriptarSimple(ref nombreUsuario);
                oEncriptacion.EncriptarSimple(ref contraseña);
                //Modifico el atributo bloqueado a false.
                dtUsuario.Rows.Find(oUsuario.idUsuario).ItemArray = new object[] {oUsuario.idUsuario, oUsuario.fechaAlta,
                nombreUsuario, contraseña, oUsuario.Bloqueado = false };
                oAcceso.GrabarDatos();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Metodo para obtener el id de usuario.
        public string ObtenterIdUsuario(E_Usuario oUsuario)
        {
            int contadorId = 0;
            string nombreUsuario;
            //Asigno a la variable el nombre de usuario.
            nombreUsuario = oUsuario.Nombre;
            //Encripto el nombre de usuario.
            oEncriptacion.EncriptarSimple(ref nombreUsuario);

            try
            {
                //Recorro el datatable.
                foreach (DataRow row in dtUsuario.Rows)
                {
                    //A medida que recorro aumento el contador de id.
                    contadorId += 1;
                    //Asigno a la propiedad del objeto el valor del contador de id.
                    oUsuario.idUsuario = contadorId;
                    //Si coincide el nombre de usuario y el id con las row en cuestion.
                    if (nombreUsuario == row["Usuario_Nombre"].ToString() && oUsuario.idUsuario == Convert.ToInt32(row["Usuario_Id"]))
                    {
                        //Asigno al objeto el valor del nombre de usuario.
                        oUsuario.Nombre = nombreUsuario;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                //Retorno el objeto.
                return oUsuario.ToString();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Metodo para obtener el nombre de usuario.
        public string ObtenerNombreUsuario(E_Usuario oUsuario)
        {
            string nombreUsuario = " ";

            try
            {
                //Recorro el datatable.
                foreach (DataRow row in dtUsuario.Rows)
                {                       
                    //Si el id de usuario coincide el valor del row.
                    if (oUsuario.idUsuario == Convert.ToInt32(row["Usuario_Id"]))
                    {
                        //Asigno al objeto el valor del nombre de usuario y el permiso.
                        oUsuario.Nombre = row["Usuario_Nombre"].ToString();
                        oUsuario.oPermiso.Id = row["Usuario_Permiso"].ToString();
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

                nombreUsuario = oUsuario.Nombre;
                //Desencripto el nombre de usuario.
                oEncriptacion.DesencriptarSimple(ref nombreUsuario);
                //Asigno nombre desencriptado.
                oUsuario.Nombre = nombreUsuario;
                //Retorno el objeto con sus propiedades.
                return oUsuario.ToString();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
