using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.DAL;
using FullCarMultimarca.MPP.Base;
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
    public class MPPFormaPago : IMapping<FormaPago>
    {

        private MPPFormaPago()
        {
            _datos = FullCarManejadorDatos.ObtenerInstancia();
            _traductor = new TraductorFormaPago();
        }


        private static MPPFormaPago _mppFPago = null;
        private IManejadorDatos _datos;
        private ITraductorEntidad _traductor;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static MPPFormaPago ObtenerInstancia()
        {
            if (_mppFPago == null)
                _mppFPago = new MPPFormaPago();
            return _mppFPago;
        }
        ~MPPFormaPago()
        {
            _mppFPago = null;
            _datos = null;
            _traductor = null;
        }

        #region IMPLEMENTACION ABSTRACCION IABMC
        public IList<FormaPago> ObtenerTodos()
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["FormaPago"];
                var lista = new List<FormaPago>();
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
        public IList<FormaPago> Buscar(string propiedad = "", string texto = "", bool incluirInactivos = true)
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

                DataRow[] dt = ds.Tables["FormaPago"].Select(expression);
                var lista = new List<FormaPago>();
                foreach (DataRow dr in dt)
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
        public FormaPago Leer(FormaPago objeto)
        {
            try
            {
                DataSet ds = _datos.ObtenerDatos();
                var row = ds.Tables["FormaPago"].AsEnumerable().FirstOrDefault(dr => dr["Descripcion"].ToString().EqualsAICI(objeto.Descripcion));
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

        public void Agregar(FormaPago objeto)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["FormaPago"];
                DataRow dr = dt.NewRow();               
                dr["Descripcion"] = objeto.Descripcion;
                dr["Tipo"] = objeto.GetType().Name;
                dr["Activa"] = objeto.Activa;
                dr["ArancelGasto"] = objeto is IArancelable arancelable ? arancelable.ArancelGasto : 0;

                dt.Rows.Add(dr);

                _datos.GuardarDatos(ds);


            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public void Modificar(FormaPago objeto, string valorAnterior = null)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["FormaPago"];

                DataRow dr = dt.AsEnumerable().FirstOrDefault(u => u["Descripcion"].ToString().EqualsAICI(valorAnterior.ToString()));
                if (dr == null)
                    throw new NegocioException("Forma Pago no encontrada");
                dr["Descripcion"] = objeto.Descripcion;
                dr["Tipo"] = objeto.GetType().Name;
                dr["Activa"] = objeto.Activa;
                dr["ArancelGasto"] = objeto is IArancelable arancelable ? arancelable.ArancelGasto : 0;

                _datos.GuardarDatos(ds);

            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public void Eliminar(FormaPago objeto)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                DataTable dt = ds.Tables["FormaPago"];

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
        public bool Existe(FormaPago objeto)
        {
            try
            {
                var dt = _datos.ObtenerDatos().Tables["FormaPago"];
                return dt.AsEnumerable().Any(u => u["Descripcion"].ToString().EqualsAICI(objeto.Descripcion));
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }
        public bool TieneObjetosDependientes(FormaPago fpago)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                var dtOperaciones = ds.Tables["OperacionFormaPago"];
                var drFPago = ds.Tables["FormaPago"].AsEnumerable()
                    .FirstOrDefault(d => d["Descripcion"].ToString().EqualsAICI(fpago.Descripcion));
                return dtOperaciones.Select($"FormaPagoID = '{drFPago["FormaPagoID"]}'").Count() > 0;
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }

        #endregion

        internal FormaPago HidratarObjeto(DataRow dr)
        {
            if (dr == null)
                return null;
            else
            {
                FormaPago fPago;                
                string tipo = dr["Tipo"].ToString();

                if (tipo.Equals(typeof(FormaPagoUsado).Name))
                    fPago = new FormaPagoUsado();
                else if (tipo.Equals(typeof(FormaPagoCredito).Name))
                    fPago = new FormaPagoCredito();
                else
                    fPago = new FormaPagoContado();
                                
                fPago.Descripcion = dr["Descripcion"].ToString();
                fPago.Activa = Convert.ToBoolean(dr["Activa"]);

                if(fPago is IArancelable)
                {
                    (fPago as IArancelable).ArancelGasto = Convert.ToDecimal(dr["ArancelGasto"]);
                }               

                return fPago;
            }
        }

       
    }
}
