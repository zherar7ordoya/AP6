using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.MPP.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.Vistas;
using FullCarMultimarca.Servicios.Extensiones;

namespace FullCarMultimarca.BLL.Gestion
{
    public class BLLFormaPago : IValidable<FormaPago>, IAbmc<FormaPago, VistaFormaPago>
    {
        private BLLFormaPago()
        {
            _abmc = MPPFormaPago.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
        }

        private static BLLFormaPago _bllFormaPago = null;
        private IMapping<FormaPago> _abmc;
        private ILogger _logger;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static BLLFormaPago ObtenerInstancia()
        {
            if (_bllFormaPago == null)
                _bllFormaPago = new BLLFormaPago();
            return _bllFormaPago;
        }
        ~BLLFormaPago()
        {
            _bllFormaPago = null;
        }

        #region IMPLEMENTACIÓN IVALIDABLE

        public string MensajeError { get; internal set; }
        public bool EsValido(FormaPago objeto)
        {
            MensajeError = "";          
            if (string.IsNullOrWhiteSpace(objeto.Descripcion))
                MensajeError += "- Debe indicar la descripción\n";
            if (objeto is IArancelable)
            {
                var arancel = (objeto as IArancelable).ArancelGasto;
                if(arancel < 0 || arancel > 100)
                {
                    MensajeError += "- El arancel de gasto debe estar comprendido entre 0 y 100.\n";
                }
            }

            return String.IsNullOrEmpty(MensajeError);
        }

        #endregion

        public FormaPago Leer(FormaPago fpago)
        {
            FormaPago fPago = _abmc.Leer(fpago);
            if (fPago == null)
                throw new NegocioException("No se encontró la forma de pago");
            return fPago;
        }
        public IList<FormaPago> ObtenerTodos()
        {
            return _abmc.ObtenerTodos();
        }
        public IList<VistaFormaPago> Buscar(string propiedad, string texto, bool incluirInactivos)
        {
            var lista = _abmc.Buscar(propiedad, texto, incluirInactivos);
            return ConstruirVista(lista);
        }

        public void Agregar(FormaPago objeto)
        {
            if (!EsValido(objeto))
                throw new NegocioException($"La forma de pago que intenta guardar es inválida.\n{MensajeError}");
            if (_abmc.Existe(objeto))
                throw new NegocioException("La forma de pago que intenta agregar ya existe.");

            _abmc.Agregar(objeto);

            _logger.GenerarLog(objeto, Util.Log_Alta);
        }
        public void Modificar(FormaPago objeto, string descripcionAnterior)
        {
            if (!EsValido(objeto))
                throw new NegocioException($"La forma de pago que intenta guardar es inválida.\n{MensajeError}");
            if (!_abmc.Existe(new FormaPagoContado { Descripcion = descripcionAnterior }))
                throw new NegocioException($"La Forma de Pago que intenta modificar NO existe");

            if (!objeto.Descripcion.EqualsAICI(descripcionAnterior) && _abmc.Existe(objeto))
                throw new NegocioException("La descripción de la forma de pago ya existe.");

            _abmc.Modificar(objeto, descripcionAnterior);

            _logger.GenerarLog(objeto, Util.Log_Modificacion);
        }
        public void Eliminar(FormaPago objeto)
        {
            if (_abmc.TieneObjetosDependientes(objeto))
                throw new NegocioException("La forma de pago que intenta eliminar tiene operaciones asociadas.\nNo puede eliminar.");
            _abmc.Eliminar(objeto);

            _logger.GenerarLog(objeto, Util.Log_Baja);
        }

        private IList<VistaFormaPago> ConstruirVista(IList<FormaPago> source)
        {
            IList<VistaFormaPago> lista = new List<VistaFormaPago>();
            VistaFormaPago destItem;
            foreach (var sourceItem in source)
            {
                destItem = new VistaFormaPago();                
                destItem.Descripcion = sourceItem.Descripcion;
                destItem.Activa = sourceItem.Activa;
                if (sourceItem is IArancelable)
                    destItem.ArancelGasto = (sourceItem as IArancelable).ArancelGasto / 100;

                lista.Add(destItem);
            }
            return lista;
        }

    }
}
