using FullCarMultimarca.BE.Parametros;
using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.MPP.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullCarMultimarca.Servicios.Excepciones;

namespace FullCarMultimarca.BLL.Parametros
{
    /// <summary>
    /// BLL para la obtención y manipulación de los parámetros de comisiones
    /// </summary>
    public class BLLFlagsComisiones : IValidable<FlagsComisiones>
    {

        private BLLFlagsComisiones()
        {
            _logger = BLLLog.ObtenerInstancia();
        }

        private static BLLFlagsComisiones _bllFlagsComisiones = null;

        private ILogger _logger;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static BLLFlagsComisiones ObtenerInstancia()
        {
            if (_bllFlagsComisiones == null)
                _bllFlagsComisiones = new BLLFlagsComisiones();
            return _bllFlagsComisiones;
        }
        ~BLLFlagsComisiones()
        {
            _bllFlagsComisiones = null;
            _logger = null;
        }

        public string MensajeError { get; internal set; }
        public bool EsValido(FlagsComisiones objeto)
        {
            MensajeError = "";

            MensajeError = "";

            if (objeto.PorcentajeComisionN1 > 100 || objeto.PorcentajeComisionN1 < 0)
                MensajeError += "- El porcentaje de comisión N1 debe estar entre 0 y 100.";

            if (objeto.PorcentajeComisionN2 > 100 || objeto.PorcentajeComisionN2 < 0)
                MensajeError += "- El porcentaje de comisión N2 debe estar entre 0 y 100.";

            if (objeto.PorcentajeComisionN3 > 100 || objeto.PorcentajeComisionN3 < 0)
                MensajeError += "- El porcentaje de comisión N3 debe estar entre 0 y 100.";

            if(objeto.PorcentajeComisionN1 > objeto.PorcentajeComisionN2)
                MensajeError += "- El porcentaje de comisión N1 debe ser inferior al porcentaje de comisión N2.";

            if (objeto.PorcentajeComisionN2 > objeto.PorcentajeComisionN3)
                MensajeError += "- El porcentaje de comisión N2 debe ser inferior al porcentaje de comisión N3.";

            if (objeto.CantidadMinimaN2 <= 0)
                MensajeError += "- La cantidad minima para N2 no puede ser cero o inferior.";

            if (objeto.CantidadMinimaN3 <= 0)
                MensajeError += "- La cantidad minima para N3 no puede ser cero o inferior.";

            if (objeto.CantidadMinimaN2 >= objeto.CantidadMinimaN3)
                MensajeError += "- La cantidad mínima N2 no puede ser igual o superior a la cantidad mínima de N3.";

            return String.IsNullOrEmpty(MensajeError);
        }

        public FlagsComisiones Leer()
        {
            return MPPFlagsComisiones.ObtenerInstancia().Leer();
        }

        public void Guardar(FlagsComisiones flags)
        {
            if (!EsValido(flags))
                throw new NegocioException(MensajeError);

            MPPFlagsComisiones.ObtenerInstancia().Guardar(flags);

            _logger.GenerarLog("Parametros de comisiones modificados");
        }

    }
}
