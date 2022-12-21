
using FullCarMultimarca.BE.Parametros;
using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.MPP.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.Servicios;

namespace FullCarMultimarca.BLL.Parametros
{
    /// <summary>
    /// BLL para la obtención y manipulación de los parámetros de ventas
    /// </summary>
    public class BLLFlagsVentas : IValidable<FlagsVentas>
    {

        private BLLFlagsVentas()
        {
            _logger = BLLLog.ObtenerInstancia();
            _servicioValidacion = new ServicioValidacion();
        }

        private static BLLFlagsVentas _bllFlagsVentas = null;
        private ILogger _logger;
        private IServicioValidacion _servicioValidacion;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static BLLFlagsVentas ObtenerInstancia()
        {
            if (_bllFlagsVentas == null)
                _bllFlagsVentas = new BLLFlagsVentas();
            return _bllFlagsVentas;
        }
        ~BLLFlagsVentas()
        {
            _bllFlagsVentas = null;
            _logger = null;
            _servicioValidacion = null;
        }

        public string MensajeError { get; internal set; }
        public bool EsValido(FlagsVentas objeto)
        {
            MensajeError = "";

            if (objeto.PorcentajeCoberturaARecuperar > 100 || objeto.PorcentajeCoberturaARecuperar < 0)
                MensajeError += "- El porcentaje de cobertura a recuperar debe estar entre 0 y 100.";

            if (objeto.PorcentajeGastoPatentamiento > 100 || objeto.PorcentajeGastoPatentamiento < 0)
                MensajeError += "- El porcentaje de gasto patentamiento a recuperar debe estar entre 0 y 100.";

            if(objeto.FormaPagoContadoDefault == null)
                MensajeError += "- Debe seleccionar la forma de pago contado default..";

            if (objeto.DiasRetroactivoDeterminacionPauta < 1)
                MensajeError += "- La cantidad de meses retroactivos no puede ser inferior a 1.";


            //Validamos los correos ingresados:
            if(!CadenaMultiplesDestinatariosValida(objeto.DestinatariosNotificacionVencimientoOfertas))
                MensajeError += "- Formato de email inválido; revise los destinatarios para la notificación de vencimiento de ofertas.";
            if (!CadenaMultiplesDestinatariosValida(objeto.DestinatariosNotificacionAutorizacionAPerdida))
                MensajeError += "- Formato de email inválido; revise los destinatarios para la notificación de autorizaciones a pérdida.";


            return String.IsNullOrEmpty(MensajeError);
        }

        public FlagsVentas Leer()
        {
            return MPPFlagsVentas.ObtenerInstancia().Leer();
        }

        public void Guardar(FlagsVentas flags)
        {
            if (!EsValido(flags))
                throw new NegocioException(MensajeError);

            MPPFlagsVentas.ObtenerInstancia().Guardar(flags);

            _logger.GenerarLog("Parametros de venta modificados");
        }

        private bool CadenaMultiplesDestinatariosValida(string destinatarios)
        {
            bool cadenaValida = true;
            if (!String.IsNullOrWhiteSpace(destinatarios))
            {
                
                destinatarios = destinatarios.Replace(";", ",");
                string[] split = destinatarios.Split(',');
                foreach (string correo in split)
                {
                    if (string.IsNullOrWhiteSpace(correo))
                        continue;
                    if (!_servicioValidacion.ValidarPatronString(correo.Trim(), Util.PatronValidacionEmail))
                    {
                        cadenaValida = false;
                        break;
                    }
                }
            }
            return cadenaValida;
        }
    }
}
