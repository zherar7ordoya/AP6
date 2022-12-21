using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.MPP.Gestion;
using FullCarMultimarca.Servicios;
using FullCarMultimarca.Servicios.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullCarMultimarca.Vistas;

namespace FullCarMultimarca.BLL.Gestion
{
    public class BLLUnidad : IValidable<Unidad>, IAbmc<Unidad, VistaUnidad>
    {
        private BLLUnidad()
        {
            _abmc = MPPUnidad.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
            _servicioValidacion = new ServicioValidacion();
        }

        private static BLLUnidad _bllUnidad = null;
        private IMapping<Unidad> _abmc;
        private ILogger _logger;
        private IServicioValidacion _servicioValidacion;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static BLLUnidad ObtenerInstancia()
        {
            if (_bllUnidad == null)
                _bllUnidad = new BLLUnidad();
            return _bllUnidad;
        }
        ~BLLUnidad()
        {
            _bllUnidad = null;
            _abmc = null;
            _logger = null;
            _servicioValidacion = null;
        }

        #region IMPLEMENTACIÓN IVALIDABLE

        public string MensajeError { get; internal set; }
        public bool EsValido(Unidad objeto)
        {
            MensajeError = "";



            if (String.IsNullOrWhiteSpace(objeto.Chasis))
                MensajeError += "- Debe indicar el chasis\n";
            else if (!_servicioValidacion.ValidarPatronString(objeto.Chasis, Util.PatronValidacionCHASIS))      
                MensajeError += "- El chasis debe ser un valor válido de 17 posiciones (solo letras y números).\n";        
            if (objeto.Modelo == null)
                MensajeError += "- Debe indicar el modelo\n";
            if (objeto.Color == null)
                MensajeError += "- Debe indicar el color.\n";
            if(objeto.FechaCompra == null || objeto.FechaCompra.Date > DateTime.Today.Date)
                MensajeError += "- La fecha de compra debe ser un valor válido no mayor a hoy.\n";
            if (objeto.ImporteCompra <= 0)
                MensajeError += "- El importe de compra debe ser un valor válido mayor a cero.\n";


            return String.IsNullOrEmpty(MensajeError);
        }

        #endregion

        public Unidad Leer(Unidad unidad)
        {
            Unidad unidadLeida = _abmc.Leer(unidad);
            if (unidadLeida == null)
                throw new NegocioException("No se encontró la unidad");
            return unidadLeida;
        }
        public IList<Unidad> ObtenerTodos()
        {
            return _abmc.ObtenerTodos();
        }
        public IList<VistaUnidad> Buscar(string propiedad, string texto, bool incluirNODisponibles)
        {
            return ConstruirVista(_abmc.Buscar(propiedad, texto, incluirNODisponibles));
        }

        public void Agregar(Unidad objeto)
        {            
            if (!EsValido(objeto))
                throw new NegocioException($"La unidad que intenta agregar es inválida.\n{MensajeError}");

            if (_abmc.Existe(objeto))
                throw new NegocioException("El Chasis que intenta agregar ya existe ingresado.");

            _abmc.Agregar(objeto);

            _logger.GenerarLog(objeto, Util.Log_Alta);
        }
        public void Modificar(Unidad objeto, string valorChasisAnterior)
        {           
            if (!EsValido(objeto))
                throw new NegocioException($"La unidad que intenta guardar es inválida.\n{MensajeError}");          

            if (!_abmc.Existe(new Unidad { Chasis = valorChasisAnterior }))
                throw new NegocioException($"El Chasis que intenta modificar NO existe");

            if (!objeto.Chasis.Equals(valorChasisAnterior) && _abmc.Existe(objeto))
                throw new NegocioException("El Chasis que intenta modificar ya existe ingresado.");

            var uniClon = (Unidad)objeto.Clone();
            uniClon.Chasis = valorChasisAnterior;
            if (VerificarCambiosConUnidadEnOferta(uniClon))
                throw new NegocioException($"No puede modificar el modelo ni los datos de compra debido a que la unidad está en oferta.");

            if (!EstaDisponible(new Unidad { Chasis = valorChasisAnterior }))
                throw new NegocioException($"La unidad que intenta modificar ya no está disponible.");

            _abmc.Modificar(objeto, valorChasisAnterior);

            _logger.GenerarLog(objeto, Util.Log_Modificacion);
        }
        public void Eliminar(Unidad objeto)
        {
            if (!EstaDisponible(objeto))
                throw new NegocioException($"La unidad que intenta eliminar ya no está disponible.");

            if (_abmc.TieneObjetosDependientes(objeto))
                throw new NegocioException("La unidad que intenta eliminar tiene operaciones asociadas.\nNo puede eliminar.");
            _abmc.Eliminar(objeto);

            _logger.GenerarLog(objeto, Util.Log_Baja);
        }      

        private bool EstaDisponible(Unidad objeto)
        {
            var uni = _abmc.Leer(objeto);
            if (uni == null || !uni.Disponible)
                return false;
            else
                return true;
                    
        }
        private bool VerificarCambiosConUnidadEnOferta(Unidad objeto)
        {
            Unidad unidadActual = _abmc.Leer(objeto);
            if (unidadActual.Oferta != null && unidadActual.Oferta > 0
                && unidadActual.VencimientoOferta >= DateTime.Today.Date)
            {
                if (unidadActual.ImporteCompra != objeto.ImporteCompra
                    || !unidadActual.Modelo.Codigo.Equals(objeto.Modelo.Codigo)
                    || unidadActual.FechaCompra != objeto.FechaCompra)
                    return true;
                    
            }
            return false;
        }

        private IList<VistaUnidad> ConstruirVista(IList<Unidad> source)
        {
            IList<VistaUnidad> lista = new List<VistaUnidad>();
            VistaUnidad destItem;
            foreach (var sourceItem in source)
            {
                destItem = new VistaUnidad();                
                destItem.Chasis = sourceItem.Chasis;
                destItem.Marca = sourceItem.Modelo?.Marca.ToString();
                destItem.Modelo = sourceItem.Modelo?.ToString();
                destItem.Color = sourceItem.Color?.ToString();
                destItem.Disponible = sourceItem.Disponible;
                destItem.FechaCompra = sourceItem.FechaCompra;
                destItem.ImporteCompra = sourceItem.ImporteCompra;
                destItem.Oferta = sourceItem.Oferta;
                destItem.VencimientoOferta = sourceItem.VencimientoOferta;

                lista.Add(destItem);
            }
            return lista;
        }

    }
}
