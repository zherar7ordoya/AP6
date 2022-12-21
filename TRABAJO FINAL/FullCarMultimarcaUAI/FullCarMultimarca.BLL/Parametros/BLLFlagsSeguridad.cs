using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.MPP.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.BE.Parametros;
using FullCarMultimarca.MPP.Parametros;

namespace FullCarMultimarca.BLL.Parametros

{
    /// <summary>
    /// BLL para la obtención de los flags de Seguridad
    /// </summary>
    public class BLLFlagsSeguridad : IValidable<FlagsSeguridad>
    {      

        private BLLFlagsSeguridad()
        {
            _logger = BLLLog.ObtenerInstancia();
        }

        private static BLLFlagsSeguridad _bllFlagsSeguridad = null;

        private ILogger _logger;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static BLLFlagsSeguridad ObtenerInstancia()
        {
            if (_bllFlagsSeguridad == null)
                _bllFlagsSeguridad = new BLLFlagsSeguridad();
            return _bllFlagsSeguridad;
        }
        ~BLLFlagsSeguridad()
        {
            _bllFlagsSeguridad = null;
        }

        public string MensajeError { get; internal set; }
        public bool EsValido(FlagsSeguridad objeto)
        {
            MensajeError = "";

            if (objeto.MinimoCaracteresPassword < 4)
                MensajeError = "- El mínimo de caractéres para la contraseña es de 4.";

            return String.IsNullOrEmpty(MensajeError);
        }

        public FlagsSeguridad Leer()
        {
            return MPPFlagsSeguridad.ObtenerInstancia().Leer();
        }

        public void Guardar(FlagsSeguridad flags)
        {
            if (!EsValido(flags))
                throw new NegocioException(MensajeError);

            MPPFlagsSeguridad.ObtenerInstancia().Guardar(flags);

            _logger.GenerarLog("Parametros de seguridad modificados");
        }
      
    }
}
