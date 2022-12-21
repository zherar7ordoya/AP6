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
    public class MPPModelo : IMapping<Modelo>
    {

        private MPPModelo()
        {
            _datos = FullCarManejadorDatos.ObtenerInstancia();
            _traductor = new TraductorModelo();
        }

        private static MPPModelo _mppModelo = null;
        private IManejadorDatos _datos;
        private ITraductorEntidad _traductor;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static MPPModelo ObtenerInstancia()
        {
            if (_mppModelo == null)
                _mppModelo = new MPPModelo();
            return _mppModelo;
        }
        ~MPPModelo()
        {
            _mppModelo = null;
            _datos = null;
            _traductor = null;
        }

        #region IMPLEMENTACION ABSTRACCION IABMC
        public IList<Modelo> ObtenerTodos()
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["Modelo"];
                var lista = new List<Modelo>();
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
        public IList<Modelo> Buscar(string propiedad = "", string texto = "", bool incluirInactivos = true)
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

                DataRow[] drModelos = ds.Tables["Modelo"].Select(expression);
                var lista = new List<Modelo>();
                foreach (DataRow dr in drModelos)
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
        public Modelo Leer(Modelo objeto)
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();
                var row = ds.Tables["Modelo"].AsEnumerable().FirstOrDefault(dr => dr["Codigo"].ToString().Equals(objeto.Codigo));
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

        public void Agregar(Modelo objeto)
        {
            try
            {
                //Leer la marca               

                var ds = _datos.ObtenerDatos();
                var drMarca = ds.Tables["Marca"].AsEnumerable()
                    .FirstOrDefault(d => d["Descripcion"].ToString().EqualsAICI(objeto.Marca.Descripcion));

                DataTable dt = ds.Tables["Modelo"];
                DataRow dr = dt.NewRow();
                dr["Codigo"] = objeto.Codigo.Trim();
                dr["Descripcion"] = objeto.Descripcion;
                dr["Tipo"] = objeto.GetType().Name;
                dr["Activo"] = objeto.Activo;
                dr["MarcaID"] = drMarca["MarcaID"];
                dr["PrecioPublico"] = objeto.PrecioPublico;              
                dt.Rows.Add(dr);

                _datos.GuardarDatos(ds);
                               

            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public void Modificar(Modelo objeto, string valorAnterior = null)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["Modelo"];

                DataRow dr = dt.AsEnumerable().FirstOrDefault(u => u["Codigo"].ToString() == objeto.Codigo);
                if (dr == null)
                    throw new NegocioException("Modelo no encontrado");

                var drMarca = ds.Tables["Marca"].AsEnumerable()
                 .FirstOrDefault(d => d["Descripcion"].ToString().EqualsAICI(objeto.Marca.Descripcion));

                dr["Descripcion"] = objeto.Descripcion;                
                dr["Tipo"] = objeto.GetType().Name;
                dr["Activo"] = objeto.Activo;
                dr["MarcaID"] = drMarca["MarcaID"];
                dr["PrecioPublico"] = objeto.PrecioPublico;

                _datos.GuardarDatos(ds);
                                
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public void Eliminar(Modelo objeto)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["Modelo"];

                DataRow dr = dt.AsEnumerable().FirstOrDefault(u => u["Codigo"].ToString() == objeto.Codigo);
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
        public bool Existe(Modelo objeto)
        {
            try
            {
                var dt = _datos.ObtenerDatos().Tables["Modelo"];
                return dt.AsEnumerable().Any(u => u["Codigo"].ToString().Trim().Equals(objeto.Codigo.Trim()));
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public bool TieneObjetosDependientes(Modelo modelo)
        {
            try
            {
                var dtUnidades = _datos.ObtenerDatos().Tables["Unidad"];
                return dtUnidades.Select($"CodigoModelo = '{modelo.Codigo}'").Count() > 0;
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }

        #endregion

        internal Modelo HidratarObjeto(DataRow dr)
        {
            if (dr == null)
                return null;
            else
            {
                Modelo modelo;
                string codigo = dr["Codigo"].ToString();
                string tipo = dr["Tipo"].ToString();

                if(tipo.Equals(typeof(ModeloPickUp).Name))
                {
                    modelo = new ModeloPickUp(codigo);
                }
                else
                {
                    modelo = new ModeloResto(codigo);
                }
                modelo.Descripcion = dr["Descripcion"].ToString();
                modelo.Activo = Convert.ToBoolean(dr["Activo"]);
                modelo.PrecioPublico = Convert.ToDecimal(dr["PrecioPublico"]);              
                
                DataRow drMarca = dr.GetParentRow("DR_Marca_Modelo");
                if (drMarca != null)
                {
                    modelo.Marca = MPPMarca.ObtenerInstancia().HidratarObjeto(drMarca) as Marca;
                }

                return modelo;
            }
        }

       
    }
}
