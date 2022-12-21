using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE;
using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.DAL;
using FullCarMultimarca.MPP.Base;
using FullCarMultimarca.MPP.Traductores;
using FullCarMultimarca.Servicios;
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
    public class MPPUnidad : ProteccionBase, IMapping<Unidad>
    {
        private MPPUnidad()
        {
            _servicioProteccion = new ServicioProteccion();
            _datos = FullCarManejadorDatos.ObtenerInstancia();
            _traductor = new TraductorUnidad();
        }

        private static MPPUnidad _mppUnidad = null;
        private IServicioProteccion _servicioProteccion;
        private IManejadorDatos _datos;
        private ITraductorEntidad _traductor;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static MPPUnidad ObtenerInstancia()
        {
            if (_mppUnidad == null)
                _mppUnidad = new MPPUnidad();
            return _mppUnidad;
        }
        ~MPPUnidad()
        {
            _mppUnidad = null;
            _servicioProteccion = null;
            _datos = null;
            _traductor = null;
        }

        #region IMPLEMENTACION ABSTRACCION IABMC
        public IList<Unidad> ObtenerTodos()
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["Unidad"];
                var lista = new List<Unidad>();
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
        public IList<Unidad> Buscar(string propiedad = "", string texto = "", bool incluirNODisponibles = true)
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
                if (!incluirNODisponibles)
                    expression += Util.AgregarOperadorAND(expression) + "Disponible = 1";

                DataRow[] drUnidades = ds.Tables["Unidad"].Select(expression);                

                var lista = new List<Unidad>();
                foreach (DataRow dr in drUnidades)
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
        public Unidad Leer(Unidad objeto)
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();
                var row = ds.Tables["Unidad"].AsEnumerable().FirstOrDefault(dr => dr["Chasis"].ToString().Equals(objeto.Chasis));
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

        public void Agregar(Unidad objeto)
        {
            try
            {
                var ds = _datos.ObtenerDatos();

                var drColor = ds.Tables["ColorUnidad"].AsEnumerable()
                    .FirstOrDefault(c => c["Descripcion"].ToString().EqualsAICI(objeto.Color.Descripcion));

                DataTable dt = ds.Tables["Unidad"];
                DataRow dr = dt.NewRow();
                dr["Chasis"] = objeto.Chasis;
                dr["CodigoModelo"] = objeto.Modelo?.Codigo;
                dr["ColorID"] = drColor["ColorID"];
                dr["Disponible"] = true;
                dr["FechaCompra"] = objeto.FechaCompra;
                dr["ImporteCompra"] = objeto.ImporteCompra;
                IncluirProteccionRegistro(dr);
                dt.Rows.Add(dr);


                IncluirProteccionTabla(dt, ds.Tables["ProteccionDatos"]);

                _datos.GuardarDatos(ds);
                

            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public void Modificar(Unidad objeto, string valorChasisAnterior = null)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["Unidad"];

                string valorABuscar = objeto.Chasis;
                if (valorChasisAnterior != null)
                    valorABuscar = (string)valorChasisAnterior;

                DataRow dr = dt.AsEnumerable().FirstOrDefault(u => u["Chasis"].ToString().Equals(valorABuscar));
                if (dr == null)
                    throw new NegocioException("Unidad no encontrada");

                var drColor = ds.Tables["ColorUnidad"].AsEnumerable()
                                    .FirstOrDefault(d => d["Descripcion"].ToString().EqualsAICI(objeto.Color.Descripcion));


                dr["Chasis"] = objeto.Chasis;
                dr["CodigoModelo"] = objeto.Modelo?.Codigo;
                dr["ColorID"] = drColor["ColorID"];
                dr["FechaCompra"] = objeto.FechaCompra;
                dr["ImporteCompra"] = objeto.ImporteCompra;
                dr["Disponible"] = objeto.Disponible;
                if (objeto.Oferta == null)
                    dr["Oferta"] = DBNull.Value;
                else
                    dr["Oferta"] = objeto.Oferta;
                if (objeto.VencimientoOferta == null)
                    dr["VencimientoOferta"] = DBNull.Value;
                else
                    dr["VencimientoOferta"] = objeto.VencimientoOferta;
                IncluirProteccionRegistro(dr);

                IncluirProteccionTabla(dt, ds.Tables["ProteccionDatos"]);

                _datos.GuardarDatos(ds);
                
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public void Eliminar(Unidad objeto)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["Unidad"];

                DataRow dr = dt.AsEnumerable().FirstOrDefault(u => u["Chasis"].ToString().Equals(objeto.Chasis));
                if (dr != null)
                {
                    dr.Delete();
                }

                IncluirProteccionTabla(dt, ds.Tables["ProteccionDatos"]);

                _datos.GuardarDatos(ds);
                
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public bool Existe(Unidad objeto)
        {
            try
            {
                var dtUni = _datos.ObtenerDatos().Tables["Unidad"];
                return dtUni.AsEnumerable().Any(u => u["Chasis"].ToString().Equals(objeto.Chasis));
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public bool TieneObjetosDependientes(Unidad unidad)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                var dtOperaciones = ds.Tables["Operacion"];
                var rUnidad = ds.Tables["Unidad"].AsEnumerable().FirstOrDefault(r => r["Chasis"].ToString().Equals(unidad.Chasis));
                return dtOperaciones.Select($"Unidad = '{Convert.ToInt32(rUnidad["UnidadID"])}'").Count() > 0;
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
            object[] array = _servicioProteccion.DataRowToArray(dr, new[] { "UnidadID", "CodigoHash" });
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
            DataRow dr = dtProteccion.Select("Tabla = 'Unidad'").FirstOrDefault();
            dr["CodigoHash"] = hash;
        }
        protected override void IncluirProteccionRegistro(DataRow dRow)
        {
            dRow["CodigoHash"] = CrearHashRegistro(dRow);
        }

        #endregion
      

        internal void MarcarDisponibilidad(Unidad unidad, DataSet ds)
        {
            DataTable dt = ds.Tables["Unidad"];
            DataRow dr = dt.AsEnumerable().FirstOrDefault(u => u["Chasis"].ToString().Equals(unidad.Chasis));
            if (dr == null)
                throw new NegocioException("Unidad no encontrada");
            dr["Disponible"] = unidad.Disponible;
            IncluirProteccionRegistro(dr);
            IncluirProteccionTabla(dt, ds.Tables["ProteccionDatos"]);
        }

        internal Unidad HidratarObjeto(DataRow dr)
        {
            if (dr == null)
                return null;
            else
            {
                Unidad unidad;
                Modelo modelo = null; ColorUnidad color = null;
                DataRow drModelo = dr.GetParentRow("DR_Unidad_Modelo");

                if (drModelo != null)
                {
                    modelo = MPPModelo.ObtenerInstancia().HidratarObjeto(drModelo) as Modelo;
                }
                DataRow drColor = dr.GetParentRow("DR_Unidad_Color");
                if (drColor != null)
                {
                    color = MPPColorUnidad.ObtenerInstancia().HidratarObjeto(drColor) as ColorUnidad;
                }

                unidad = new Unidad(modelo, color);                
                unidad.Chasis = dr["Chasis"].ToString();
                unidad.Disponible = Convert.ToBoolean(dr["Disponible"]);
                unidad.FechaCompra = Convert.ToDateTime(dr["FechaCompra"]);
                unidad.ImporteCompra = Convert.ToDecimal(dr["ImporteCompra"]);

                if (dr["Oferta"] == DBNull.Value)
                    unidad.Oferta = null;
                else
                    unidad.Oferta = Convert.ToDecimal(dr["Oferta"]);

                if (dr["VencimientoOferta"] == DBNull.Value)
                    unidad.VencimientoOferta = null;
                else
                    unidad.VencimientoOferta = Convert.ToDateTime(dr["VencimientoOferta"]);




                return unidad;
            }
        }


    }
}
