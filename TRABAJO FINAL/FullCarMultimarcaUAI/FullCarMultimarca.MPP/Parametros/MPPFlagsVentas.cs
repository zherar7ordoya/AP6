using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.BE.Parametros;
using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.DAL;
using FullCarMultimarca.MPP.Base;
using FullCarMultimarca.MPP.Gestion;
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

namespace FullCarMultimarca.MPP.Parametros
{
    /// <summary>
    /// Clase MPP para obtener y actualizar los parametros de venta de la empresa
    /// </summary>
    public class MPPFlagsVentas
    {
        private MPPFlagsVentas()
        {
            _datos = FullCarManejadorDatos.ObtenerInstancia();
        }

        private static MPPFlagsVentas _mppFlagsVentas = null;
        private IManejadorDatos _datos;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static MPPFlagsVentas ObtenerInstancia()
        {
            if (_mppFlagsVentas == null)
                _mppFlagsVentas = new MPPFlagsVentas();
            return _mppFlagsVentas;
        }
        ~MPPFlagsVentas()
        {
            _mppFlagsVentas = null;
            _datos = null;
        }
       
        public FlagsVentas Leer()
        {
            try
            {
                var ds = _datos.ObtenerDatos();                
                return HidratarObjeto(ds.Tables["FlagsEmpresa"].Rows[0]);
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }

        }
        public void Guardar(FlagsVentas objeto)
        {
            try
            {
                var ds = _datos.ObtenerDatos();
                var dtFlags = ds.Tables["FlagsEmpresa"].Rows[0];
                if (dtFlags == null)
                    throw new NegocioException("No se encontraron los parámetros de la empresa");

                dtFlags["PorcentajeCoberturaARecuperar"] = objeto.PorcentajeCoberturaARecuperar;
                dtFlags["PorcentajeGastoPatentamiento"] = objeto.PorcentajeGastoPatentamiento;
                dtFlags["DiasRetroactivoDeterminacionPauta"] = objeto.DiasRetroactivoDeterminacionPauta;
                dtFlags["DestinatariosNotificacionVencimientoOfertas"] = objeto.DestinatariosNotificacionVencimientoOfertas;
                dtFlags["DestinatariosNotificacionAutorizacionAPerdida"] = objeto.DestinatariosNotificacionAutorizacionAPerdida;
                dtFlags["TasaIVAModelosPickUp"] = objeto.TasaIVAModelosPickUp;
                dtFlags["TasaIVAModelosResto"] = objeto.TasaIVAModelosResto;
                if (objeto.FormaPagoContadoDefault == null)
                    dtFlags["FormaPagoContadoDefault"] = DBNull.Value;
                else
                {
                    var drFPago = ds.Tables["FormaPago"].AsEnumerable().FirstOrDefault(d => d["Descripcion"].ToString().EqualsAICI(objeto.FormaPagoContadoDefault.Descripcion));
                    dtFlags["FormaPagoContadoDefault"] = drFPago["FormaPagoID"];
                }


                _datos.GuardarDatos(ds);                                
                
            }
            catch (Exception ex)
            {
                throw Util.WrapException(ex);
            }
        }

        internal FlagsVentas HidratarObjeto(DataRow dr)
        {
            if (dr == null)
                return null;
            else
            {
                var f =  new FlagsVentas
                {

                    PorcentajeCoberturaARecuperar = Convert.ToDecimal(dr["PorcentajeCoberturaARecuperar"]),
                    PorcentajeGastoPatentamiento = Convert.ToDecimal(dr["PorcentajeGastoPatentamiento"]),                    
                    DiasRetroactivoDeterminacionPauta = Convert.ToInt32(dr["DiasRetroactivoDeterminacionPauta"]),
                    DestinatariosNotificacionVencimientoOfertas = dr["DestinatariosNotificacionVencimientoOfertas"].ToString(),
                    DestinatariosNotificacionAutorizacionAPerdida = dr["DestinatariosNotificacionAutorizacionAPerdida"].ToString(),
                    TasaIVAModelosPickUp = Convert.ToDecimal(dr["TasaIVAModelosPickUp"]),
                    TasaIVAModelosResto = Convert.ToDecimal(dr["TasaIVAModelosResto"])

                };
                DataRow drFPago = dr.GetParentRow("DR_FormaPago_Parametro");
                if (drFPago != null)
                {
                    f.FormaPagoContadoDefault = (FormaPagoContado)MPPFormaPago.ObtenerInstancia().HidratarObjeto(drFPago);
                }

               
                return f;
            }
        }
    }
}
