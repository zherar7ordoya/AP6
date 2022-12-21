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
    public class MPPMarca : IMapping<Marca>
    {

        private MPPMarca()
        {
            _datos = FullCarManejadorDatos.ObtenerInstancia();
            _traductor = new TraductorMarca();
        }

        private static MPPMarca _mppMarca = null;
        private IManejadorDatos _datos;
        private ITraductorEntidad _traductor;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static MPPMarca ObtenerInstancia()
        {
            if (_mppMarca == null)
                _mppMarca = new MPPMarca();
            return _mppMarca;
        }
        ~MPPMarca()
        {
            _mppMarca = null;
            _datos = null;
            _traductor = null;
        }

        #region IMPLEMENTACION ABSTRACCION IABMC
        public IList<Marca> ObtenerTodos()
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["Marca"];
                var lista = new List<Marca>();
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
        public IList<Marca> Buscar(string propiedad = "", string texto = "", bool incluirInactivos = true)
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
                    expression += Util.AgregarOperadorAND(expression) + "Activa = 1";

                DataRow[] drMarcas = ds.Tables["Marca"].Select(expression);
                var lista = new List<Marca>();
                foreach (DataRow dr in drMarcas)
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
        public Marca Leer(Marca objeto)
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();
                var row = ds.Tables["Marca"].AsEnumerable().FirstOrDefault(dr => dr["Descripcion"].ToString().EqualsAICI(objeto.Descripcion));
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

        public void Agregar(Marca objeto)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["Marca"];
                DataRow dr = dt.NewRow();                
                dr["Descripcion"] = objeto.Descripcion;
                dr["Activa"] = objeto.Activa;
                dt.Rows.Add(dr);

                _datos.GuardarDatos(ds);                

            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public void Modificar(Marca objeto, string descripcionAnterior)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["Marca"];

                DataRow dr = dt.AsEnumerable().FirstOrDefault(u => u["Descripcion"].ToString().EqualsAICI(descripcionAnterior.ToString()));
                if (dr == null)
                    throw new NegocioException("Marca no encontrada");
                dr["Descripcion"] = objeto.Descripcion;
                dr["Activa"] = objeto.Activa;

                _datos.GuardarDatos(ds);                
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public void Eliminar(Marca objeto)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["Marca"];

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
        public bool Existe(Marca objeto)
        {
            try
            {
                var dt = _datos.ObtenerDatos().Tables["Marca"];
                return dt.AsEnumerable().Any(u => u["Descripcion"].ToString().EqualsAICI(objeto.Descripcion));
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public bool TieneObjetosDependientes(Marca marca)
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();
                var drMarca = ds.Tables["Marca"].AsEnumerable().FirstOrDefault(m => m["Descripcion"].ToString().EqualsAICI(marca.ToString()));
                var dtModelos = ds.Tables["Modelo"];
                return dtModelos.Select($"MarcaID = '{Convert.ToInt32(drMarca["MarcaID"])}'").Count() > 0;
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }

        #endregion

        internal Marca HidratarObjeto(DataRow dr)
        {
            if (dr == null)
                return null;
            else
            {
                var marca = new Marca()
                {                                       
                    Descripcion = dr["Descripcion"].ToString(),                 
                    Activa = Convert.ToBoolean(dr["Activa"])                    
                };             

                return marca;
            }
        }
    }
}
