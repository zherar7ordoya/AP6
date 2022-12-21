using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.DAL;
using FullCarMultimarca.MPP.Base;
using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.MPP.Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.BE;
using FullCarMultimarca.Servicios.Extensiones;
using FullCarMultimarca.MPP.Traductores;

namespace FullCarMultimarca.MPP.Gestion
{
    public class MPPColorUnidad : IMapping<ColorUnidad>
    {
        private MPPColorUnidad()
        {
            _datos = FullCarManejadorDatos.ObtenerInstancia();
            _traductor = new TraductorColorUnidad();
        }

        private static MPPColorUnidad _mppColorUnidad = null;
        private IManejadorDatos _datos;
        private ITraductorEntidad _traductor;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static MPPColorUnidad ObtenerInstancia()
        {
            if (_mppColorUnidad == null)
                _mppColorUnidad = new MPPColorUnidad();
            return _mppColorUnidad;
        }
        ~MPPColorUnidad()
        {
            _mppColorUnidad = null;
            _datos = null;
            _traductor = null;
    }

        #region IMPLEMENTACION ABSTRACCION IABMC
        public IList<ColorUnidad> ObtenerTodos()
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["ColorUnidad"];
                var lista = new List<ColorUnidad>();
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
        public IList<ColorUnidad> Buscar(string propiedad = "", string texto = "", bool incluirInactivos = true)
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

                DataRow[] drColores = ds.Tables["ColorUnidad"].Select(expression);
                var lista = new List<ColorUnidad>();
                foreach (DataRow dr in drColores)
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
        public ColorUnidad Leer(ColorUnidad objeto)
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();
                var row = ds.Tables["ColorUnidad"].AsEnumerable().FirstOrDefault(dr => dr["Descripcion"].ToString().EqualsAICI(objeto.Descripcion));
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

        public void Agregar(ColorUnidad objeto)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["ColorUnidad"];
                DataRow dr = dt.NewRow();                
                dr["Descripcion"] = objeto.Descripcion;
                dr["Activo"] = objeto.Activo;
                dt.Rows.Add(dr);

                _datos.GuardarDatos(ds);

            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public void Modificar(ColorUnidad objeto, string valorAnterior = null)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["ColorUnidad"];

                DataRow dr = dt.AsEnumerable()
                    .FirstOrDefault(u => u["Descripcion"].ToString().EqualsAICI(valorAnterior.ToString()));
                if (dr == null)
                    throw new NegocioException("Color no encontrado");
                dr["Descripcion"] = objeto.Descripcion;
                dr["Activo"] = objeto.Activo;

                _datos.GuardarDatos(ds);
                                
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public void Eliminar(ColorUnidad objeto)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["ColorUnidad"];

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
        public bool Existe(ColorUnidad objeto)
        {
            try
            {
                var dt = _datos.ObtenerDatos().Tables["ColorUnidad"];
                return dt.AsEnumerable().Any(u => u["Descripcion"].ToString().EqualsAICI(objeto.Descripcion));
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public bool TieneObjetosDependientes(ColorUnidad color)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                var drColor = ds.Tables["ColorUnidad"].AsEnumerable()
                    .FirstOrDefault(m => m["Descripcion"].ToString().EqualsAICI(color.Descripcion));
                var dtUnidades = ds.Tables["Unidad"];
                return dtUnidades.Select($"ColorID = '{Convert.ToInt32(drColor["ColorID"])}'").Count() > 0;
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }

        #endregion

        internal ColorUnidad HidratarObjeto(DataRow dr)
        {
            if (dr == null)
                return null;
            else
            {
                var color = new ColorUnidad()
                {                    
                    Descripcion = dr["Descripcion"].ToString(),
                    Activo = Convert.ToBoolean(dr["Activo"])
                };

                return color;
            }
        }
    }
}
