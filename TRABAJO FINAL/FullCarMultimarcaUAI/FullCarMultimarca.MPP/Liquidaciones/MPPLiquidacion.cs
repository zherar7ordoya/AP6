using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.BE.Liquidaciones;
using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.BE.Ventas;
using FullCarMultimarca.DAL;
using FullCarMultimarca.MPP.Base;
using FullCarMultimarca.MPP.Seguridad;
using FullCarMultimarca.MPP.Ventas;
using FullCarMultimarca.Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.MPP.Liquidaciones
{
    public class MPPLiquidacion : ProteccionBase, IMapping<Liquidacion>
    {
        private MPPLiquidacion()
        {
            _servicioProteccion = new ServicioProteccion();
            _datos = FullCarManejadorDatos.ObtenerInstancia();
        }

        private static MPPLiquidacion _mppLiquidacion = null;
        private IServicioProteccion _servicioProteccion;
        private IManejadorDatos _datos;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static MPPLiquidacion ObtenerInstancia()
        {
            if (_mppLiquidacion == null)
                _mppLiquidacion = new MPPLiquidacion();
            return _mppLiquidacion;
        }
        ~MPPLiquidacion()
        {
            _mppLiquidacion = null;
            _servicioProteccion = null;
            _datos = null;
        }


        #region IMPLEMENTACION ABSTRACCION IABMC

        public IList<Liquidacion> ObtenerTodos()
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["Liquidacion"];
                var lista = new List<Liquidacion>();
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
        public IList<Liquidacion> Buscar(string campo = "", string texto = "", bool incluirInactivos = true)
        {
            throw new NotImplementedException("Métodos NO implementado; por favor utilice 'ObtenerTodos' en su lugar");
        }
        public Liquidacion Leer(Liquidacion liquidacion)
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();
                var row = ds.Tables["Liquidacion"].AsEnumerable().FirstOrDefault(dr => dr["Codigo"].ToString().Equals(liquidacion.Codigo));
                if (row == default(DataRow))
                    return null;
                else
                    return HidratarObjeto(row,true);

            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public void Agregar(Liquidacion liquidacion)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["Liquidacion"];
                DataRow dr = dt.NewRow();
                dr["Codigo"] = liquidacion.Codigo;
                dr["FechaLiquidacion"] = liquidacion.FechaLiquidacion;
                dr["Comentarios"] = liquidacion.Comentarios;                
                dt.Rows.Add(dr);
                
                DataTable dtVendedores = ds.Tables["LiquidacionVendedor"];
                DataRow drVendedor;
                foreach (var liqVendedor in liquidacion.ObtenerLiquidacionVendedores())
                {
                    drVendedor = dtVendedores.NewRow();
                    drVendedor["CodigoLiquidacion"] = liqVendedor.Liquidacion.Codigo;
                    drVendedor["UsuarioVendedor"] = liqVendedor.UsuarioVendedor.Legajo;
                    drVendedor["PorcentajeComision"] = liqVendedor.PorcentajeComision;
                    drVendedor["PremioVolumen"] = liqVendedor.PremioVolumen;
                    drVendedor["NetoAComisionar"] = liqVendedor.NetoAComisionar;
                    IncluirProteccionRegistro(drVendedor);
                    drVendedor.SetParentRow(dr);
                    dtVendedores.Rows.Add(drVendedor);                   

                    foreach (var operacion in liqVendedor.ObtenerOperaciones())
                    {
                        MPPOperacion.ObtenerInstancia().AsignarLiquidacion(operacion, ds, liqVendedor.Liquidacion.Codigo);
                    }                    
                }
                IncluirProteccionTabla(dtVendedores, ds.Tables["ProteccionDatos"]);

                _datos.GuardarDatos(ds);

            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public void Modificar(Liquidacion liquidacion, string valorAnteior = null)
        {
            throw new NegocioException("No es posible modificar una liquidación");
        }
        public void Eliminar(Liquidacion liquidacion)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["Liquidacion"];

                DataRow dr = dt.AsEnumerable().FirstOrDefault(u => u["Codigo"].ToString().Equals(liquidacion.Codigo));

                if (dr != null)
                {
                    //Liquidación Vendedor
                    DataRow[] drLiqVendedor = dr.GetChildRows("DR_LiquidacionVendedor_Liquidacion");
                    foreach (DataRow rLiq in drLiqVendedor)
                    {
                        //Operaciones asociadas
                        DataRow[] rOperaciones = rLiq.GetChildRows("DR_LiquidacionVendedor_Operacion");
                        foreach (DataRow drOp in rOperaciones)
                        {
                            MPPOperacion.ObtenerInstancia().DesasignarLiquidacion(new Operacion { Numero = Convert.ToInt32(drOp["Numero"])}, ds);
                        }
                        rLiq.Delete();
                    }                    
                    IncluirProteccionTabla(ds.Tables["LiquidacionVendedor"], ds.Tables["ProteccionDatos"]);
                    dr.Delete();
                }
                _datos.GuardarDatos(ds);
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public bool Existe(Liquidacion liquidacion)
        {
            try
            {
                var dt = _datos.ObtenerDatos().Tables["Liquidacion"];
                return dt.AsEnumerable().Any(u => u["Codigo"].ToString().Trim().Equals(liquidacion.Codigo.Trim()));
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public bool TieneObjetosDependientes(Liquidacion liquidacion)
        {
            return false;
        }

        #endregion        

        #region PROTECCION    

        internal override string CrearHashRegistro(DataRow dr)
        {
            object[] array = _servicioProteccion.DataRowToArray(dr, new[] { "CodigoHash", "NetoAComisionar" });
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
            DataRow dr = dtProteccion.Select("Tabla = 'LiquidacionVendedor'").FirstOrDefault();
            dr["CodigoHash"] = hash;
        }
        protected override void IncluirProteccionRegistro(DataRow dRow)
        {
            dRow["CodigoHash"] = CrearHashRegistro(dRow);
        }

        #endregion

        internal Liquidacion HidratarObjeto(DataRow dr, bool leerObjetoCompleto = false)
        {
            if (dr == null)
                return null;
            else
            {
                string codigo = dr["Codigo"].ToString();
                Liquidacion liquidacion = new Liquidacion(codigo);
                liquidacion.FechaLiquidacion = Convert.ToDateTime(dr["FechaLiquidacion"]);
                liquidacion.Comentarios = dr["Comentarios"].ToString();

                if (leerObjetoCompleto)
                {
                    //Liquidación Vendedor
                    DataRow[] drLiqVendedor = dr.GetChildRows("DR_LiquidacionVendedor_Liquidacion");
                    foreach (DataRow rLiq in drLiqVendedor)
                    {
                        DataRow drUsr = rLiq.GetParentRow("DR_LiquidacionVendedor_Vendedor");
                        Usuario usrVendedor = MPPUsuario.ObtenerInstancia().Leer(new Usuario { Logon = drUsr["Logon"].ToString() });
                        liquidacion.AgregarLiquidacionVendedor(usrVendedor);
                        var liqVend = liquidacion.ObtenerLiquidacionVendedores().FirstOrDefault(lv => lv.UsuarioVendedor.Legajo == usrVendedor.Legajo);
                        liqVend.PorcentajeComision = Convert.ToDecimal(rLiq["PorcentajeComision"]);
                        liqVend.PremioVolumen = Convert.ToDecimal(rLiq["PremioVolumen"]);
                        liqVend.NetoAComisionar = Convert.ToDecimal(rLiq["NetoAComisionar"]);
                        //Operaciones asociadas
                        DataRow[] rOperaciones = rLiq.GetChildRows("DR_LiquidacionVendedor_Operacion");
                        foreach (DataRow drOp in rOperaciones)
                        {
                            var operacion = MPPOperacion.ObtenerInstancia().Leer(new Operacion { Numero = Convert.ToInt32(drOp["Numero"]) });
                            if (operacion != null)
                                liqVend.AgregarOperacion(operacion);
                        }                        
                    }
                }
                return liquidacion;
            }
        }
       
    }
}
