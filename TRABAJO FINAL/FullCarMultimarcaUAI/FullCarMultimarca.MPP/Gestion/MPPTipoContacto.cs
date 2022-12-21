using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE;
using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.DAL;
using FullCarMultimarca.MPP.Traductores;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.Servicios.Extensiones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.MPP.Gestion
{
    public class MPPTipoContacto : IMapping<TipoContacto>
    {
        private MPPTipoContacto()
        {
            _datos = FullCarManejadorDatos.ObtenerInstancia();
            _traductor = new TraductorTiposContacto();
        }

        private static MPPTipoContacto _mppTipoContacto = null;
        private IManejadorDatos _datos;
        private ITraductorEntidad _traductor;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static MPPTipoContacto ObtenerInstancia()
        {
            if (_mppTipoContacto == null)
                _mppTipoContacto = new MPPTipoContacto();
            return _mppTipoContacto;
        }
        ~MPPTipoContacto()
        {
            _mppTipoContacto = null;
            _datos = null;
            _traductor = null;
        }

        #region IMPLEMENTACION ABSTRACCION IABMC
        public IList<TipoContacto> ObtenerTodos()
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["TipoContacto"];
                var lista = new List<TipoContacto>();
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
        public IList<TipoContacto> Buscar(string propiedad = "", string texto = "", bool incluirInactivos = true)
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

                DataRow[] drTiposContacto = ds.Tables["TipoContacto"].Select(expression);
                var lista = new List<TipoContacto>();
                foreach (DataRow dr in drTiposContacto)
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
        public TipoContacto Leer(TipoContacto objeto)
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();
                var row = ds.Tables["TipoContacto"].AsEnumerable().FirstOrDefault(dr => dr["Descripcion"].ToString().EqualsAICI(objeto.Descripcion));
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

        public void Agregar(TipoContacto objeto)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["TipoContacto"];
                DataRow dr = dt.NewRow();
                dr["Descripcion"] = objeto.Descripcion;
                dr["Activo"] = objeto.Activo;
                dr["ExpresionValidacion"] = objeto.ExpresionValidacion;
                dr["TextoAyuda"] = objeto.TextoAyuda;
                dr["PermiteNotificaciones"] = objeto.PermiteNotificaciones;
                dt.Rows.Add(dr);

                _datos.GuardarDatos(ds);
                
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public void Modificar(TipoContacto objeto, string valorAnterior = null)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["TipoContacto"];

                DataRow dr = dt.AsEnumerable().FirstOrDefault(u => u["Descripcion"].ToString().EqualsAICI(valorAnterior.ToString()));
                if (dr == null)
                    throw new NegocioException("Color no encontrado");
                dr["Descripcion"] = objeto.Descripcion;
                dr["Activo"] = objeto.Activo;
                dr["ExpresionValidacion"] = objeto.ExpresionValidacion;
                dr["TextoAyuda"] = objeto.TextoAyuda;
                dr["PermiteNotificaciones"] = objeto.PermiteNotificaciones;

                _datos.GuardarDatos(ds);
                                
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public void Eliminar(TipoContacto objeto)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["TipoContacto"];

                DataRow dr = dt.AsEnumerable().FirstOrDefault(u => u["Descripcion"].ToString().EqualsAICI(objeto.Descripcion));
                if (dr != null)
                {
                    dr.Delete();
                }

                _datos.GuardarDatos(ds);
                                
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public bool Existe(TipoContacto objeto)
        {
            try
            {
                var dt = _datos.ObtenerDatos().Tables["TipoContacto"];
                return dt.AsEnumerable().Any(u => u["Descripcion"].ToString().EqualsAICI(objeto.Descripcion));
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public bool TieneObjetosDependientes(TipoContacto tipoContacto)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                var dtContactos = ds.Tables["Contacto"];
                var drTipoContacto = ds.Tables["TipoContacto"].AsEnumerable()
                    .FirstOrDefault(tc => tc["Descripcion"].ToString().EqualsAICI(tipoContacto.Descripcion));
                return dtContactos.Select($"Tipo = '{Convert.ToInt32(drTipoContacto["TipoContactoID"])}'").Count() > 0;
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }

        #endregion

        internal TipoContacto HidratarObjeto(DataRow dr)
        {
            if (dr == null)
                return null;
            else
            {
                var tipoContacto = new TipoContacto()
                {                    
                    Descripcion = dr["Descripcion"].ToString(),
                    Activo = Convert.ToBoolean(dr["Activo"]),
                    ExpresionValidacion = dr["ExpresionValidacion"].ToString(),
                    TextoAyuda = dr["TextoAyuda"].ToString(),
                    PermiteNotificaciones = Convert.ToBoolean(dr["PermiteNotificaciones"])
                };

                return tipoContacto;
            }
        }
    }
}
