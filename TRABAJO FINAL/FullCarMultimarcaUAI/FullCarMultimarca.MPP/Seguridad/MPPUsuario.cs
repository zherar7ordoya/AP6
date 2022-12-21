using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.DAL;
using FullCarMultimarca.MPP.Base;
using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.BE;
using FullCarMultimarca.MPP.Traductores;

namespace FullCarMultimarca.MPP.Seguridad
{
    /// <summary>
    /// Clase que gestiona ABMC desde y hacia la Base de Datos
    /// </summary>
    public class MPPUsuario : ProteccionBase, IMapping<Usuario>
    {

        private MPPUsuario()
        {
            _servicioProteccion = new ServicioProteccion();
            _datos = FullCarManejadorDatos.ObtenerInstancia() ;
            _traductor = new TraductorUsuario();
            
    }

        private static MPPUsuario _mppUsuario = null;
        private IServicioProteccion _servicioProteccion;
        private IManejadorDatos _datos;
        private ITraductorEntidad _traductor;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static MPPUsuario ObtenerInstancia()
        {
            if (_mppUsuario == null)
                _mppUsuario = new MPPUsuario();
            return _mppUsuario;
        }
        ~MPPUsuario()
        {
            _mppUsuario = null;
            _servicioProteccion = null;
            _datos = null;
            _traductor = null;
        }

        #region IMPLEMENTACION ABSTRACCION IABMC

        public IList<Usuario> ObtenerTodos()
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["Usuario"];
                var lista = new List<Usuario>();
                foreach (DataRow dr in dt.Rows)
                {
                    lista.Add(HidratarObjeto(dr));
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public IList<Usuario> Buscar(string propiedad = "", string texto = "", bool incluirInactivos = true)
        {
            try
            {                
                DataSet ds = _datos.ObtenerDatos();

                //Filtro
                string expression = "";
                if (!String.IsNullOrWhiteSpace(texto))
                {
                    string campo = Util.ObtenerCampoDesdePropiedad(_traductor.DiccionarioEquivalencias, propiedad);
                    expression += $"{campo} LIKE '%{Util.PrepararStringConsulta(texto)}%'";
                }
                if (!incluirInactivos)
                    expression += Util.AgregarOperadorAND(expression) + "Activo = 1";

                DataRow[] drUsuarios = ds.Tables["Usuario"].Select(expression);
                var lista = new List<Usuario>();
                foreach (DataRow dr in drUsuarios)
                {
                    lista.Add(HidratarObjeto(dr));
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public Usuario Leer(Usuario objeto)
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();
                var row = ds.Tables["Usuario"].AsEnumerable().FirstOrDefault(dr => dr["Logon"].ToString().Equals(objeto.Logon));
                if (row == default(DataRow))
                    return null;
                else
                    return HidratarObjeto(row);

            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }

        public void Agregar(Usuario objeto)
        {
            try
            {
                object permiso = DBNull.Value;
                if (objeto.Permiso != null) permiso = objeto.Permiso.Codigo;                 

                var ds = _datos.ObtenerDatos();
                DataTable dtUsr = ds.Tables["Usuario"];
                DataRow drUsr = dtUsr.NewRow();
                drUsr["Legajo"] = objeto.Legajo;
                drUsr["Logon"] = objeto.Logon;
                drUsr["Nombre"] = objeto.Nombre;
                drUsr["Apellido"] = objeto.Apellido;
                drUsr["Password"] = objeto.Password;
                drUsr["Activo"] = objeto.Activo;
                drUsr["Bloqueado"] = objeto.Bloqueado;
                drUsr["FechaUltimoCambioPassword"] = DBNull.Value;
                drUsr["PalabraClave"] = DBNull.Value;
                drUsr["RespuestaClave"] = DBNull.Value;
                drUsr["Email"] = objeto.Email;
                drUsr["CodigoPermiso"] = permiso;
                IncluirProteccionRegistro(drUsr);
                dtUsr.Rows.Add(drUsr);                

                IncluirProteccionTabla(dtUsr, ds.Tables["ProteccionDatos"]);

                _datos.GuardarDatos(ds);                

            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }       
        public void Modificar(Usuario objeto, string valorAnterior = null)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                var dtUsr = ds.Tables["Usuario"];
                DataRow rUsr = dtUsr.AsEnumerable().FirstOrDefault(u => Convert.ToInt32(u["Legajo"]).Equals(objeto.Legajo));
                if (rUsr == null)
                    throw new NegocioException("Usuario no encontrado");

                object permiso = DBNull.Value;
                if (objeto.Permiso != null) permiso = objeto.Permiso.Codigo;

                rUsr["Logon"] = objeto.Logon;
                rUsr["Nombre"] = objeto.Nombre;
                rUsr["Apellido"] = objeto.Apellido;
                rUsr["Activo"] = objeto.Activo;
                rUsr["Email"] = objeto.Email;
                rUsr["CodigoPermiso"] = permiso;
                rUsr["Bloqueado"] = objeto.Bloqueado;
                rUsr["Password"] = objeto.Password;

                if (objeto.FechaUltimoCambioPassword == null)
                    rUsr["FechaUltimoCambioPassword"] = DBNull.Value;
                else
                    rUsr["FechaUltimoCambioPassword"] = objeto.FechaUltimoCambioPassword;

                if (string.IsNullOrWhiteSpace(objeto.PalabraClave))
                    rUsr["PalabraClave"] = DBNull.Value;
                else
                    rUsr["PalabraClave"] = objeto.PalabraClave; ;

                if (string.IsNullOrWhiteSpace(objeto.RespuestaClave))
                    rUsr["RespuestaClave"] = DBNull.Value;
                else
                    rUsr["RespuestaClave"] = objeto.RespuestaClave; ;
              
                IncluirProteccionRegistro(rUsr); 

                IncluirProteccionTabla(dtUsr, ds.Tables["ProteccionDatos"]);

                _datos.GuardarDatos(ds);
               
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public void Eliminar(Usuario objeto)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                var dtUsr = ds.Tables["Usuario"];
                DataRow rUsr = dtUsr.AsEnumerable().FirstOrDefault(u => Convert.ToInt32(u["Legajo"]).Equals(objeto.Legajo));
                if(rUsr != null)
                {
                    rUsr.Delete();
                }

                IncluirProteccionTabla(dtUsr, ds.Tables["ProteccionDatos"]);

                _datos.GuardarDatos(ds);
                
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public bool Existe(Usuario objeto)
        {
            try
            {
                var dtUsr = _datos.ObtenerDatos().Tables["Usuario"];
                return dtUsr.AsEnumerable().Any(u => u["Logon"].ToString().Equals(objeto.Logon) && 
                (objeto.Legajo == null || Convert.ToInt32(u["Legajo"]) != objeto.Legajo));
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }          
        }
        public bool TieneObjetosDependientes(Usuario usuario)
        {
            try
            {                
                var dtOperaciones = _datos.ObtenerDatos().Tables["Operacion"];
                return dtOperaciones.Select($"UsuarioVendedor = '{usuario.Legajo}'").Count() > 0;
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }

        #endregion

        #region PROTECCION    

        internal override string CrearHashRegistro(DataRow dr)
        {
            object[] array = _servicioProteccion.DataRowToArray(dr, new[] { "Legajo", "CodigoHash", "Email" });
            return _servicioProteccion.ObtenerCodigoHash(array);
        }
        internal override string CrearHashTabla(DataTable dt)
        {
            object[] array = _servicioProteccion.DataTableToArray(dt, "CodigoHash");
            return _servicioProteccion.ObtenerCodigoHash(array);
        }

        protected override void IncluirProteccionTabla(DataTable dtAProteger, DataTable dtProteccion)
        {
            string hash = CrearHashTabla(dtAProteger);
            DataRow dr = dtProteccion.Select("Tabla = 'Usuario'").FirstOrDefault();
            dr["CodigoHash"] = hash;
        }
        protected override void IncluirProteccionRegistro(DataRow dRow)
        {
            dRow["CodigoHash"] = CrearHashRegistro(dRow);
        }

        #endregion            
       
      

        internal Usuario HidratarObjeto(DataRow dr)
        {
            if (dr == null)
                return null;
            else
            {
                var usr = new Usuario
                {
                    Legajo = Convert.ToInt32(dr["Legajo"]),
                    Logon = dr["Logon"].ToString(),
                    Nombre = dr["Nombre"].ToString(),
                    Apellido = dr["Apellido"].ToString(),
                    Bloqueado = Convert.ToBoolean(dr["Bloqueado"]),
                    Activo = Convert.ToBoolean(dr["Activo"]),
                    Password = dr["Password"].ToString(),
                    PalabraClave = dr["PalabraClave"].ToString(),
                    RespuestaClave = dr["RespuestaClave"].ToString(),
                    Email = dr["Email"].ToString()
                };

                if (dr["FechaUltimoCambioPassword"] != DBNull.Value)
                    usr.FechaUltimoCambioPassword = Convert.ToDateTime(dr["FechaUltimoCambioPassword"]);
                else
                    usr.FechaUltimoCambioPassword = null;

                DataRow drPerfil = dr.GetParentRow("DR_Usuario_Permiso");
                if (drPerfil != null)
                {
                    usr.Permiso = MPPPermiso.ObtenerInstancia().HidratarObjeto(drPerfil) as PermisoCompuesto;
                }

                return usr;
            }
        }

    }
}

