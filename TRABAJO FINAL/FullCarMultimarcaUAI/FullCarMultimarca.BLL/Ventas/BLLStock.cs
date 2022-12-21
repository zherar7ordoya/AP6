using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.MPP.Gestion;
using FullCarMultimarca.MPP.Parametros;
using FullCarMultimarca.Servicios;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullCarMultimarca.BLL.Parametros;
using System.Threading;
using FullCarMultimarca.BLL.Gestion;

namespace FullCarMultimarca.BLL.Ventas
{
    public class BLLStock
    {
        private BLLStock()
        {
            _abmc = MPPUnidad.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
            _email = new ServicioCorreo();
            _exAsync = new ServicioTransfAsync();
        }

        private static BLLStock _bllStock = null;
        private IMapping<Unidad> _abmc;
        private ILogger _logger;
        private IServicioCorreo _email;
        private IServicioTransfAsync _exAsync;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static BLLStock ObtenerInstancia()
        {
            if (_bllStock == null)
                _bllStock = new BLLStock();
            return _bllStock;
        }
        ~BLLStock()
        {
            _bllStock = null;
            _abmc = null;
            _logger = null;
            _email = null;
            _exAsync = null;
        }

        public IList<VistaStock> ObtenerStock(string propiedad, string texto)
        {
            var listaUnidades = _abmc.Buscar(propiedad, texto, false);            
            return ConstruirVista(listaUnidades);
        }
        public IList<Unidad> ObtenerUnidadesDisponiblesPorModelo(Unidad unidad)
        {           
            var query = _abmc.Buscar("", "", false).AsQueryable();
            query = query.Where(u => u.Modelo.Equals(unidad.Modelo));

            return query.ToList() ;
        }       

        /// <summary>
        /// Este método vence todas las ofertas que ya no están vigentes en el sistema.
        /// </summary>
        public bool VencerOfertas()
        {
            //Obtenemos las unidades en oferta que ya están vencidas.
            var query = _abmc.Buscar("", "", false).AsQueryable();
            query = query.Where(u => u.Oferta != null && u.Oferta > 0);
            query = query.Where(u => u.VencimientoOferta != null && u.VencimientoOferta.Value.Date < DateTime.Today.Date);

            var resultado = query.ToList();
            IList<Unidad> aEnviar = new List<Unidad>();

            foreach(var unidadEnOferta in resultado)
            {
                aEnviar.Add(unidadEnOferta.Clone() as Unidad);

                //Para cada unidad con oferta vencida, vencemos.
                unidadEnOferta.Oferta = null;
                unidadEnOferta.VencimientoOferta = null;                
               _abmc.Modificar(unidadEnOferta);
                _logger.GenerarLog($"Unidad {unidadEnOferta.Chasis} - OFERTA VENCIDA.");                
            }

            //Notificamos a el/los correos parametrizados
            if(aEnviar.Count() > 0)
            {
                //Leemos los destinatarios de los flags 
                var parametrosVenta = BLLFlagsVentas.ObtenerInstancia().Leer();
                if (parametrosVenta != null
                    && !string.IsNullOrWhiteSpace(parametrosVenta.DestinatariosNotificacionVencimientoOfertas))
                {
                    _exAsync.EjectutarAsincronico(
                        async () => await EnviarCorreoAsync(parametrosVenta.DestinatariosNotificacionVencimientoOfertas, aEnviar.ToList()));
                }
            }

            return resultado.Count() > 0;
        }      

        //Método asincronico dado que el envío de los mails puede demorarse, brindamos soporte de transformación Sync to Async
        private async Task EnviarCorreoAsync(string destinatarios, IList<Unidad> unidadesVencidas)
        {
            if (String.IsNullOrWhiteSpace(destinatarios))
                return;

            foreach(var unidad in unidadesVencidas)
            {
                string asunto = "FULLCAR - Notificación Oferta Vencida";
                string cuerpo = $"La oferta sobre la unida {unidad.Chasis} ha vencido.\n\n";
                cuerpo += $"Modelo: {unidad.Modelo}\n";
                cuerpo += $"Oferta: {unidad.Oferta?.ToString("c2")}\n";
                cuerpo += $"Vencimiento: {unidad.VencimientoOferta?.ToString("dd/MM/yyyy")}";
                await _email.EnviarEmailAsync(destinatarios, asunto, cuerpo);
                await Task.Delay(3500); //Tratamos de evitar que lleguen a span por la velocidad de envío.
            }
        }
        private IList<VistaStock> ConstruirVista(IList<Unidad> source)
        {
            IList<VistaStock> lista = new List<VistaStock>();
            VistaStock destItem;
            foreach (var sourceItem in source)
            {
                destItem = new VistaStock();                
                destItem.Chasis = sourceItem.Chasis;
                destItem.Marca = sourceItem.Modelo?.Marca.Descripcion;
                destItem.CodigoModelo = sourceItem.Modelo.Codigo;
                destItem.DescripcionModelo = sourceItem.Modelo.Descripcion;
                destItem.Color = sourceItem.Color.Descripcion;
                destItem.PrecioPublico = sourceItem.Modelo.PrecioPublico;
                destItem.Oferta = sourceItem.Oferta;
                destItem.VencimientoOferta = sourceItem.VencimientoOferta;
                destItem.Antiguedad = sourceItem.Antiguedad;
                destItem.FechaCompra = sourceItem.FechaCompra;
                destItem.EnOferta = sourceItem.OfertaVigente;


                lista.Add(destItem);
            }
            return lista;
        }


        /// <summary>
        /// Método para poner unidad en oferta
        /// </summary>
        /// <param name="unidad"></param>
        /// <param name="oferta"></param>
        /// <param name="vencimiento"></param>
        public void PonerEnOfertaUnidad(Unidad unidad, decimal oferta, DateTime vencimiento)
        {
            if (!Ticket.TienePermiso(ConstPermisos.STOCK_PONER_EN_OFERTA))
                throw new NegocioException("No tiene permisos suficientes para realizar esta acción");

            var flagsVenta = BLLFlagsVentas.ObtenerInstancia().Leer();
            if (flagsVenta == null)
                throw new NegocioException("No se lograron obtener los parámetros de aplicación. No puede establecer la oferta.");

            //Actualizamos la unidad
            var unidadActualizada = _abmc.Leer(unidad);

            if (unidadActualizada == null)
                throw new NegocioException("La unidad que intenta actualizar ya no existe. No puede establecer la oferta.");

            if (!unidadActualizada.Disponible)
                throw new NegocioException("La unidad a la que intenta actualizar la oferta ya no está disponible. No puede establecer la oferta.");

            var cobertura = CalcularCobertura(unidadActualizada.ImporteCompra, flagsVenta.PorcentajeCoberturaARecuperar / 100);
            var valMinimoVenta = ObtenerValorMinimoVenta(unidadActualizada, cobertura);

            if (oferta <= 0)
                throw new NegocioException("El valor de oferta no puede ser cero o inferior.");

            if (valMinimoVenta > oferta)
                throw new NegocioException($"El valor de la oferta NO puede ser menor que el valor mínimo de venta.\n Valor Mínimo de venta {valMinimoVenta:c2}\nOferta: {oferta:c2}");

            if (oferta > unidadActualizada.Modelo.PrecioPublico)
                throw new NegocioException($"El precio de oferta NO puede ser superior al precio público.\nPrecio Público {unidadActualizada.Modelo.PrecioPublico:c2}\nOferta: {oferta:c2}");

            if (vencimiento.Date < DateTime.Today.Date)
                throw new NegocioException($"La fecha de vencimiento de la oferta no puede ser pasada.");

            unidadActualizada.Oferta = oferta;
            unidadActualizada.VencimientoOferta = vencimiento.Date;

            _abmc.Modificar(unidadActualizada);

            _logger.GenerarLog($"Unidad {unidadActualizada.Chasis} - En OFERTA: {unidadActualizada.Oferta:c2} con vencimento {unidadActualizada.VencimientoOferta:dd/MM/yyyy}");

        }
        public void AnularOfertaUnidad(Unidad unidad)
        {
            if (!Ticket.TienePermiso(ConstPermisos.STOCK_PONER_EN_OFERTA))
                throw new NegocioException("No tiene permisos suficientes para realizar esta acción");

            //Actualizamos la unidad
            var unidadActualizada = _abmc.Leer(unidad);

            if (unidadActualizada == null)
                throw new NegocioException("La unidad que intenta actualizar ya no existe.");

            if (!unidadActualizada.Disponible)
                throw new NegocioException("La unidad a la que intenta anular la oferta ya no está disponible. No puede realizar esta acción.");

            unidadActualizada.Oferta = null;
            unidadActualizada.VencimientoOferta = null;

            _abmc.Modificar(unidadActualizada);

            _logger.GenerarLog($"Unidad {unidadActualizada.Chasis} - OFERTA ANULADA.");

        }
        public decimal CalcularCobertura(decimal importeCompra, decimal porcentajeCobertura)
        {
            //Sumamos el porcentaje de cobertura
            return importeCompra * (1 + porcentajeCobertura);
        }
        public decimal ObtenerValorMinimoVenta(Unidad unidad, decimal cobertura)
        {
            //Agregamos el IVA del modelo            
            var bllModelo = BLLModelo.ObtenerInstancia(unidad.Modelo);
            return cobertura * (1 + bllModelo.ObtenerTasaIVA());            
        }
        /// <summary>
        /// Método que dada una unidad verifica si es óptima por modelo y color (excluyendo ofertas).
        /// </summary>
        /// <param name="unidad">Unidad seleccionada por el usuario</param>
        /// <returns>La misma unidad si es óptima o aquella que lo sea por modelo y color.</returns>
        public Unidad VerificarUnidadOptima(Unidad unidad)
        {
            //Primero refrescamos la unidad
            var unidadSeleccionada = _abmc.Leer(unidad);
            if (unidadSeleccionada == null)
                throw new NegocioException("No se encontró la unidad seleccionada.");

            if (!unidadSeleccionada.Disponible)
                throw new NegocioException("La unidad que intenta utilizar ya no se encuentra disponible.");

            if (unidadSeleccionada.OfertaVigente)
                return unidadSeleccionada; //Devolvemos la misma unidad ya que es una oferta y NO participa del circuito.

            //Calculo la antiguedad de la unidad seleccionada
            int antiguedadUnidadSeleccionada = unidadSeleccionada.Antiguedad;           

            var query = _abmc.Buscar("", "", false).AsEnumerable();
            query = query.Where(u => u.Color.Equals(unidadSeleccionada.Color));
            query = query.Where(u => u.Modelo.Equals(unidadSeleccionada.Modelo));

            var resultado = query.ToList();

            if (resultado.Count() == 0)
                throw new NegocioException("No se encontró la unidad seleccionada."); //No debería pasar, pero si pasa es porque siquiera la unidad seleccionada se encontró.           

            //Nos quedamos con la undiad más antigua por modelo y color que no sea oferta.
            int maxAntiguedad = 0;
            Unidad unidadOptima = null;
            foreach (var unidadDisponible in resultado)
            {
                if (unidadDisponible.OfertaVigente)
                    continue; //Ignoramos las que tienen oferta

                int antiguedadUnidad = unidadDisponible.Antiguedad;
                if (antiguedadUnidad > maxAntiguedad)
                {
                    //La unidad es la más antigua hasta el momento.
                    maxAntiguedad = antiguedadUnidad;
                    unidadOptima = unidadDisponible;
                }
            }
            //Al finalizar, si la maxima antiguedad es igual o menor que la antiguedad de la unidad, es porque la unidad seleccionada es optima
            if (antiguedadUnidadSeleccionada >= maxAntiguedad)
                return unidadSeleccionada;
            else
                throw new UnidadOptimaException<Unidad>(unidadOptima.Modelo.ToString(),unidadOptima.Color.Descripcion, unidadOptima.Chasis, unidadOptima);

        }

    }
    
}
