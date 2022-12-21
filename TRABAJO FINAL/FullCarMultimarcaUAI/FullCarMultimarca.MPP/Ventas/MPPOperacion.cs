using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE;
using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.BE.Ventas;
using FullCarMultimarca.DAL;
using FullCarMultimarca.MPP.Base;
using FullCarMultimarca.MPP.Gestion;
using FullCarMultimarca.MPP.Seguridad;
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

namespace FullCarMultimarca.MPP.Ventas
{
    public class MPPOperacion : ProteccionBase, IMapping<Operacion>
    {

        private MPPOperacion()
        {
            _servicioProteccion = new ServicioProteccion();
            _datos = FullCarManejadorDatos.ObtenerInstancia();
            _traductor = new TraductorOperacion();
        }

        private static MPPOperacion _mppOperacion = null;
        private IServicioProteccion _servicioProteccion;
        private IManejadorDatos _datos;
        private ITraductorEntidad _traductor;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static MPPOperacion ObtenerInstancia()
        {
            if (_mppOperacion == null)
                _mppOperacion = new MPPOperacion();
            return _mppOperacion;
        }
        ~MPPOperacion()
        {
            _mppOperacion = null;
            _servicioProteccion = null;
            _datos = null;
            _traductor = null;
        }

        #region IMPLEMENTACION ABSTRACCION IABMC

        public IList<Operacion> ObtenerTodos()
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["Operacion"];
                var lista = new List<Operacion>();
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
        public Operacion Leer(Operacion objeto)
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();
                var row = ds.Tables["Operacion"].AsEnumerable().FirstOrDefault(dr => dr["Numero"].Equals(objeto.Numero));
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
        public IList<Operacion> Buscar(string propiedad = "", string texto = "", bool incluirAnuladas = false)
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();

                //Filtro
                string expression = "";
                if (!incluirAnuladas)
                    expression += Util.AgregarOperadorAND(expression) + "Anulada = 0";

                if (!String.IsNullOrWhiteSpace(texto))
                {
                    string campo = Util.ObtenerCampoDesdePropiedad(_traductor.DiccionarioEquivalencias, propiedad);
                    if (campo.Equals("Numero"))
                    {
                        int nro = 0;
                        int.TryParse(texto, out nro);
                        expression += Util.AgregarOperadorAND(expression) + $"{campo} = {nro}";
                    }
                    else
                        expression += Util.AgregarOperadorAND(expression) + $"{campo} LIKE '%{Util.PrepararStringConsulta(texto)}%'";
                }

                DataRow[] drOperaciones = ds.Tables["Operacion"].Select(expression);
                var lista = new List<Operacion>();
                foreach (DataRow dr in drOperaciones)
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

        public void Agregar(Operacion objeto)
        {
            try
            {
                var ds = _datos.ObtenerDatos();

                var rCliente = ds.Tables["Cliente"].AsEnumerable().FirstOrDefault(r => r["CUIT"].ToString().Equals(objeto.Cliente.CUIT));
                var rUnidad = ds.Tables["Unidad"].AsEnumerable().FirstOrDefault(r => r["Chasis"].ToString().Equals(objeto.Unidad.Chasis));

                DataTable dt = ds.Tables["Operacion"];
                DataRow dr = dt.NewRow();
                dr["Fecha"] = objeto.Fecha;
                dr["Unidad"] = rUnidad["UnidadID"];
                dr["Cliente"] = rCliente["ClienteID"];
                dr["UsuarioVendedor"] = objeto.UsuarioVendedor.Legajo;
                dr["PrecioPublico"] = objeto.PrecioPublico;
                dr["EsOferta"] = objeto.EsOferta;
                dr["Pauta"] = objeto.Pauta;
                dr["PatentaEmpresa"] = objeto.PatentaEmpresa;
                dr["PrecioUnidad"] = objeto.PrecioUnidad;                             
                dr["Estado"] = objeto.Estado.ToString();
                dr["PorcentajeGastoGestoria"] = objeto.PorcentajeGastoGestoria;
                dr["Anulada"] = objeto.Anulada;                
                IncluirProteccionRegistro(dr);
                dt.Rows.Add(dr);

                objeto.Numero = Convert.ToInt32(dr["Numero"]);
                AgregarFormasDePago(ds, dr, objeto);

                IncluirProteccionTabla(dt, ds.Tables["ProteccionDatos"]);

                objeto.Unidad.Disponible = false;
                MPPUnidad.ObtenerInstancia()
                    .MarcarDisponibilidad(objeto.Unidad, ds);

                _datos.GuardarDatos(ds);              

            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public void Modificar(Operacion objeto, string valorAnterior = null)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["Operacion"];

                DataRow dr = dt.AsEnumerable().FirstOrDefault(u => u["Numero"].Equals(objeto.Numero));
                if (dr == null)
                    throw new NegocioException("Operación no encontrada");

                var rCliente = ds.Tables["Cliente"].AsEnumerable().FirstOrDefault(r => r["CUIT"].ToString().Equals(objeto.Cliente.CUIT));

                dr["Cliente"] = rCliente["ClienteID"];
                dr["PatentaEmpresa"] = objeto.PatentaEmpresa;
                dr["PrecioUnidad"] = objeto.PrecioUnidad;                              
                dr["Estado"] = objeto.Estado.ToString();
                dr["NotaRechazo"] = objeto.NotaRechazo;

                if (objeto.AutorizadaEl == null)
                    dr["AutorizadaEl"] = DBNull.Value;
                else
                    dr["AutorizadaEl"] = objeto.AutorizadaEl;

                if (objeto.AutorizadaPor == null)
                    dr["AutorizadaPor"] = DBNull.Value;
                else
                    dr["AutorizadaPor"] = objeto.AutorizadaPor?.Legajo;
                
                IncluirProteccionRegistro(dr);

                EliminarFormasDePago(dr);
                AgregarFormasDePago(ds, dr, objeto);

                IncluirProteccionTabla(dt, ds.Tables["ProteccionDatos"]);

                objeto.Unidad.Disponible = false;
                MPPUnidad.ObtenerInstancia().MarcarDisponibilidad(objeto.Unidad, ds);

                _datos.GuardarDatos(ds);
             
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }        
        public void Eliminar(Operacion objeto)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["Operacion"];

                DataRow dr = dt.AsEnumerable().FirstOrDefault(u => u["Numero"].Equals(objeto.Numero));
                if (dr == null)
                    throw new NegocioException("Operación no encontrada");

                dr["Anulada"] = true;                
                IncluirProteccionRegistro(dr);                    

                IncluirProteccionTabla(dt, ds.Tables["ProteccionDatos"]);

                objeto.Unidad.Disponible = true;
                MPPUnidad.ObtenerInstancia().MarcarDisponibilidad(objeto.Unidad, ds);

                _datos.GuardarDatos(ds);
              
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public bool Existe(Operacion objeto)
        {
            try
            {
                var dtOp = _datos.ObtenerDatos().Tables["Operacion"];
                return dtOp.AsEnumerable().Any(u => u["Numero"].ToString().Equals(objeto.Numero));                
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public bool TieneObjetosDependientes(Operacion operacion)
        {
            try
            {                
                var dtOperaciones = _datos.ObtenerDatos().Tables["Operacion"];
                return dtOperaciones.Select($"Numero = {operacion.Numero.Value} AND CodigoLiquidacion IS NOT NULL").Count() > 0;               
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
            object[] array = _servicioProteccion.DataRowToArray(dr, new[] { "Numero", "CodigoHash", "AutorizadaEl", "AutorizadaPor" });
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
            DataRow dr = dtProteccion.Select("Tabla = 'Operacion'").FirstOrDefault();
            dr["CodigoHash"] = hash;
        }
        protected override void IncluirProteccionRegistro(DataRow dRow)
        {
            dRow["CodigoHash"] = CrearHashRegistro(dRow);
        }

        #endregion          
    

        internal void AsignarLiquidacion(Operacion operacion, DataSet ds, string codigoLiquidacion)
        {
            DataTable dt = ds.Tables["Operacion"];
            DataRow dr = dt.AsEnumerable().FirstOrDefault(u => u["Numero"].Equals(operacion.Numero));
            if (dr == null)
                throw new NegocioException("Operación no encontrada");
            dr["CodigoLiquidacion"] = codigoLiquidacion;
            IncluirProteccionRegistro(dr);
            IncluirProteccionTabla(dt, ds.Tables["ProteccionDatos"]);
        }
        internal void DesasignarLiquidacion(Operacion operacion, DataSet ds)
        {
            DataTable dt = ds.Tables["Operacion"];
            DataRow dr = dt.AsEnumerable().FirstOrDefault(u => u["Numero"].Equals(operacion.Numero));
            if (dr == null)
                throw new NegocioException("Operación no encontrada");
            dr["CodigoLiquidacion"] = DBNull.Value;
            IncluirProteccionRegistro(dr);
            IncluirProteccionTabla(dt, ds.Tables["ProteccionDatos"]);
        }
        private void EliminarFormasDePago(DataRow drOperacion)
        {
            DataRow[] drFormasPago = drOperacion.GetChildRows("DR_OperacionFormaPago_Operacion");
            foreach (var dFp in drFormasPago)
            {
                dFp.Delete();
            }

        }
        private void AgregarFormasDePago(DataSet ds, DataRow parentRow, Operacion operacion)
        {
            DataTable dt = ds.Tables["OperacionFormaPago"];
            DataRow dr;
            foreach (var fPago in operacion.ObtenerFormasDePago())
            {
                var drFPago = ds.Tables["FormaPago"].AsEnumerable()
                    .FirstOrDefault(d => d["Descripcion"].ToString().EqualsAICI(fPago.FormaPago.Descripcion));

                dr = dt.NewRow();
                dr["NumeroOperacion"] = operacion.Numero;
                dr["FormaPagoID"] = drFPago["FormaPagoID"];
                dr["Importe"] = fPago.Importe;
                dr["Modificable"] = fPago.Modificable;
                dr["ArancelGasto"] = fPago.ArancelGasto;
                dr.SetParentRow(parentRow);
                dt.Rows.Add(dr);
            }

        }

        internal Operacion HidratarObjeto(DataRow dr)
        {
            if (dr == null)
                return null;
            else
            {
                Operacion operacion;
                Unidad unidad = null;
                Cliente cliente = null;
                Usuario vendedor = null;
                FormaPago fPago = null;
                DataRow drUnidad = dr.GetParentRow("DR_Operacion_Unidad");
                DataRow drCliente = dr.GetParentRow("DR_Operacion_Cliente");
                DataRow drVendedor = dr.GetParentRow("DR_Operacion_Vendedor");

                if (drUnidad != null)
                {
                    unidad = MPPUnidad.ObtenerInstancia().HidratarObjeto(drUnidad);
                }
                if (drCliente != null)
                {
                    cliente = MPPCliente.ObtenerInstancia().HidratarObjeto(drCliente);
                }
                if (drVendedor != null)
                {
                    vendedor = MPPUsuario.ObtenerInstancia().HidratarObjeto(drVendedor);
                }

                operacion = new Operacion(unidad);
                operacion.Unidad = unidad;
                operacion.Cliente = cliente;
                operacion.UsuarioVendedor = vendedor;
                operacion.Numero = Convert.ToInt32(dr["Numero"]);
                operacion.Fecha = Convert.ToDateTime(dr["Fecha"]);
                operacion.Estado = (Operacion.EstadoOperacion)Enum.Parse(typeof(Operacion.EstadoOperacion), dr["Estado"].ToString());
                operacion.Pauta = Convert.ToDecimal(dr["Pauta"]);
                operacion.EsOferta = Convert.ToBoolean(dr["EsOferta"]);
                operacion.PrecioPublico = Convert.ToDecimal(dr["PrecioPublico"]);
                operacion.PatentaEmpresa = Convert.ToBoolean(dr["PatentaEmpresa"]);
                operacion.PrecioUnidad = Convert.ToDecimal(dr["PrecioUnidad"]);
                operacion.PorcentajeGastoGestoria = Convert.ToDecimal(dr["PorcentajeGastoGestoria"]);
                operacion.Anulada = Convert.ToBoolean(dr["Anulada"]);
                operacion.NotaRechazo = dr["NotaRechazo"].ToString();
                if (!String.IsNullOrWhiteSpace(dr["CodigoLiquidacion"].ToString()))
                    operacion.Liquidada = true;
                else
                    operacion.Liquidada = false;

                //Autorizacion
                if (dr["AutorizadaEl"] == DBNull.Value)
                    operacion.AutorizadaEl = null;
                else
                    operacion.AutorizadaEl = Convert.ToDateTime(dr["AutorizadaEl"]);

                if (dr["AutorizadaPor"] == DBNull.Value)
                    operacion.AutorizadaPor = null;
                else
                {
                    DataRow drAutorizante = dr.GetParentRow("DR_Operacion_UsuarioAutorizacion");
                    if(drAutorizante != null)
                    {
                        operacion.AutorizadaPor = MPPUsuario.ObtenerInstancia().HidratarObjeto(drAutorizante);
                    }
                }

                //Formas de pago
                DataRow[] drOpFormPago = dr.GetChildRows("DR_OperacionFormaPago_Operacion");
                foreach (DataRow rOfp in drOpFormPago)
                {
                    DataRow drFPago = rOfp.GetParentRow("DR_OperacionFormaPago_FormaPago");
                    fPago = MPPFormaPago.ObtenerInstancia().HidratarObjeto(drFPago);
                    //var opFPago = new OperacionFormaPago(operacion, fPago)
                    //{                        
                    //    Modificable = Convert.ToBoolean(rOfp["Modificable"]),
                    //    Importe = Convert.ToDecimal(rOfp["Importe"]),
                    //    ArancelGasto = Convert.ToDecimal(rOfp["ArancelGasto"])
                    //};
                    operacion.AgregarFormaDePago(fPago, Convert.ToBoolean(rOfp["Modificable"]), Convert.ToDecimal(rOfp["Importe"]), Convert.ToDecimal(rOfp["ArancelGasto"]));
                }

                return operacion;
            }
        }
    }
}
