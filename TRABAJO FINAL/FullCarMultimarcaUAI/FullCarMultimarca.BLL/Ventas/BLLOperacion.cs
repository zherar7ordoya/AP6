using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.BE.Ventas;
using FullCarMultimarca.BLL.Parametros;
using FullCarMultimarca.MPP.Gestion;
using FullCarMultimarca.MPP.Parametros;
using FullCarMultimarca.MPP.Ventas;
using FullCarMultimarca.Servicios;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullCarMultimarca.BLL.Gestion;

namespace FullCarMultimarca.BLL.Ventas
{
    public class BLLOperacion : IValidable<Operacion>, IAutorizable<Operacion>
    {
        private BLLOperacion()
        {            
            _abmc = MPPOperacion.ObtenerInstancia();            
            _logger = BLLLog.ObtenerInstancia();
            _servicioCorreo = new ServicioCorreo();
            _servicioAsync = new ServicioTransfAsync();
        }

        private static BLLOperacion _bllOperacion = null;
        private IMapping<Operacion> _abmc;          
        private ILogger _logger;
        private IServicioCorreo _servicioCorreo;
        private IServicioTransfAsync _servicioAsync;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static BLLOperacion ObtenerInstancia()
        {
            if (_bllOperacion == null)
                _bllOperacion = new BLLOperacion();
            return _bllOperacion;
        }
        ~BLLOperacion()
        {
            _bllOperacion = null;
            _abmc = null;            
            _logger = null;
            _servicioCorreo = null;
            _servicioAsync = null;
        }

        #region IMPLEMENTACIÓN IVALIDABLE

        public string MensajeError { get; internal set; }
        public bool EsValido(Operacion objeto)
        {
            MensajeError = "";

            if (objeto.Unidad == null)
                MensajeError += "- Falta indicar la Unidad.\n";

            if(objeto.Cliente == null)
                MensajeError += "- Falta indicar el Cliente.\n";

            if(objeto.PrecioUnidad <= 0)
                MensajeError += "- El precio de la unidad debe ser mayor a cero.\n";

            if(objeto.EsOferta && objeto.Unidad.Oferta != objeto.PrecioUnidad)
                MensajeError += "- Unidad en Oferta. El precio de unidad no puede diferir de la oferta.\n";

            if(objeto.ObtenerFormasDePago().Count ==  0)
                MensajeError += "- Debe existir al menos una forma de pago.\n";

            if (!objeto.ObtenerFormasDePago().Any(fp => !fp.Modificable))
                MensajeError += "- Entre las formas de pago debe existir una forma de pago NO modificable para ajuste (contado).\n";

            var balanceo = objeto.PrecioFinal - objeto.ObtenerFormasDePago().Sum(p => p.Importe);
            if(balanceo != 0)
                MensajeError += "- La operación está desbalanceada. Revise los Precios y Formas de Pago.\n";

            var pagosContado = objeto.ObtenerFormasDePago()
                .Where(fp => !(fp.FormaPago is IArancelable))
                .Sum(fp => fp.Importe);

            var gastosFinMasUsado = objeto.GastoFinanciacion + objeto.GastoUsado;

            if(pagosContado < gastosFinMasUsado)
                MensajeError += $"- La suma de los pagos contado debe cubrir al menos los gastos en concepto de Usado y Financiado. Pagos Contado: {pagosContado:c2} - Fin+Usado: {gastosFinMasUsado:c2}\n";


            return String.IsNullOrEmpty(MensajeError);
        }

        #endregion        

        public IList<VistaOperacion> BuscarOperaciones(string propiedad, string texto, bool incluirAnuladas, 
            DateTime fDesde, DateTime fHasta, Operacion.EstadoOperacion? estadoOperacion)
        {
            //Determinamos que puede ver
            bool puedeVerTodasLasOperaciones = Ticket.TienePermiso(ConstPermisos.OPERACION_VER_TODAS_LAS_VENTAS);
            bool puedeVerSoloSusOperaciones = Ticket.TienePermiso(ConstPermisos.OPERACION_VER_MIS_VENTAS);

            Usuario usrFiltro = puedeVerTodasLasOperaciones ? null : (puedeVerSoloSusOperaciones ? Ticket.UsuarioLogueado : throw new NegocioException("No tiene permisos para ver operaciones."));

            var query = _abmc.Buscar(propiedad, texto, incluirAnuladas).AsQueryable();
            query = query.Where(o => o.Fecha.Date >= fDesde.Date && o.Fecha.Date <= fHasta.Date);
            if (estadoOperacion != null)
                query = query.Where(o => o.Estado.Equals(estadoOperacion.Value));
            if (usrFiltro != null)
                query = query.Where(o => o.UsuarioVendedor.Equals(usrFiltro));
                       

            return ConstruirVista(query.ToList());
        }
        public IList<VistaAutorizacionOperacion> ObtenerAutorizacionPendiente(string propiedad, string texto)
        {

            if (!Ticket.TienePermiso(ConstPermisos.OPERACION_AUTORIZAR))
                throw new NegocioException("No tiene permisos para autorizar Operaciones");            

            var query = _abmc.Buscar(propiedad, texto, false).AsQueryable();
            query = query.Where(o => o.Estado.Equals(Operacion.EstadoOperacion.Pendiente));

            return ConstruirVistaAutorizacion(query.ToList());
        }            
        public Operacion Leer(Operacion operacion)
        {
            return _abmc.Leer(operacion);
        }
        public Operacion LeerParaMostrar(Operacion operacion)
        {
            var op = _abmc.Leer(operacion);
            if (op == null)
                throw new NegocioException("No se encontró la operación.");
            if(op.Anulada)
                throw new NegocioException("No puede abrir la ficha de una operación anulada.");

            return op;
        }

        public Operacion IniciarNuevaOperacion(Unidad unidad)
        {

            var flagsVentas = BLLFlagsVentas.ObtenerInstancia().Leer();

            if (flagsVentas.FormaPagoContadoDefault == null)
                throw new NegocioException("No puede iniciar una venta ya que no se ha indicado la forma de pago de contado default.");


            var operacion = new Operacion(unidad);
            operacion.EsOferta = unidad.OfertaVigente;
            operacion.Pauta = CalcularPauta(unidad);
            operacion.UsuarioVendedor = Ticket.UsuarioLogueado;
            operacion.Fecha = DateTime.Today.Date;
            operacion.Estado = Operacion.EstadoOperacion.Pendiente;
            operacion.PrecioPublico = unidad.Modelo.PrecioPublico;
            operacion.PrecioUnidad = operacion.EsOferta ? unidad.Oferta.Value : operacion.PrecioPublico;
            operacion.PorcentajeGastoGestoria = flagsVentas.PorcentajeGastoPatentamiento / 100;
            operacion.Anulada = false;
            operacion.PatentaEmpresa = false;            

            //Agregamos la forma de pago default si hay
            //var opFPago = new OperacionFormaPago(operacion, flagsVentas.FormaPagoContadoDefault)
            //{                
            //    Importe = operacion.PrecioFinal,
            //    Modificable = false,
            //    ArancelGasto = 0
            //};
            operacion.AgregarFormaDePago(flagsVentas.FormaPagoContadoDefault, false, operacion.PrecioFinal, 0);
            return operacion;
        }
        private decimal CalcularPauta(Unidad unidad)
        {            
            decimal pauta = 0;

            //Obtenemos flags de venta
            var fVenta = BLLFlagsVentas.ObtenerInstancia().Leer();
            if (fVenta == null)
                throw new NegocioException("No se lograron obtener los parametros de venta.");
        

            DateTime dtDesde = DateTime.Today.AddDays(-1 * fVenta.DiasRetroactivoDeterminacionPauta).Date;
            var query = _abmc.Buscar("", "", false).AsQueryable();
            query = query.Where(o => o.Estado.Equals(Operacion.EstadoOperacion.Autorizada) && o.Fecha.Date >= dtDesde.Date);

            decimal promDescuentos = 0;
            if(query.Any(op => !op.Anulada && !op.EsOferta && op.Unidad.Modelo.Equals(unidad.Modelo)))
            {
                promDescuentos = query
                .Where(op => !op.Anulada && !op.EsOferta && op.Unidad.Modelo.Equals(unidad.Modelo)) //La operacion no debe ser oferta y debe ser del mismo modelo
                .Average(op => op.Descuento);
            }                

            //Obtenemos el menor porcentaje de descuento entre el valor minimo de venta y el precio publico del modelo.
            var unidadesDisponibles = BLLStock.ObtenerInstancia().ObtenerUnidadesDisponiblesPorModelo(unidad);
            decimal maximoValorMinimoVenta = 0;
            decimal menorPorcValMinVenta = 0;
            foreach (var unidadDisponible in unidadesDisponibles)
            {
                var cobertura = BLLStock.ObtenerInstancia().CalcularCobertura(unidadDisponible.ImporteCompra, fVenta.PorcentajeCoberturaARecuperar / 100);
                var valMinimoVenta = BLLStock.ObtenerInstancia().ObtenerValorMinimoVenta(unidadDisponible, cobertura);
                if (valMinimoVenta > maximoValorMinimoVenta)
                    maximoValorMinimoVenta = valMinimoVenta;
            }
            //Si el maximo valor minimo de venta llegase a ser superior al precio publico, dejamos el % en cero, porque puede haber un error de carga, es preferible NO oferecer descuento en este caso
            if (maximoValorMinimoVenta <= unidad.Modelo.PrecioPublico) 
                menorPorcValMinVenta = 1 - (maximoValorMinimoVenta / unidad.Modelo.PrecioPublico);

            if (promDescuentos == 0)
                pauta = menorPorcValMinVenta;
            else
                pauta = Math.Min(promDescuentos, menorPorcValMinVenta);

            return Decimal.Round(pauta,4);


        }

        public string AltaOperacion(Operacion operacion)
        {
            if (!Ticket.TienePermiso(ConstPermisos.OPERACION_CARGAR_VENTA))
                throw new NegocioException("No tiene permisos suficientes para realizar esta acción");


            //Validamos la integridad del objeto
            if (!EsValido(operacion))
                throw new NegocioException($"La operación que intenta agregar es inválida.\n{MensajeError}");

            //Volvemos a leer la unidad para verificar que exista, sigua disponible y si la operación fue con oferta, la misma siga vigente.
            var unidadSeleccionada = BLLUnidad.ObtenerInstancia().Leer(operacion.Unidad);
            if(unidadSeleccionada == null || !unidadSeleccionada.Disponible)
                throw new NegocioException($"La unidad seleccionada ya no se encuentra disponible.");
            if(!unidadSeleccionada.OfertaVigente && operacion.EsOferta)
                throw new NegocioException($"La unidad seleccionada ya no se encuentra en oferta.");

            //Verificamos la forma de autorización
            operacion.Estado = Operacion.EstadoOperacion.Autorizada;

            var descuento = Decimal.Round(operacion.Descuento, 4);
            if (!operacion.EsOferta && descuento > operacion.Pauta)
                operacion.Estado = Operacion.EstadoOperacion.Pendiente;

            operacion.Unidad.Disponible = false;
            operacion.AutorizadaEl = null;
            operacion.AutorizadaPor = null;

            _abmc.Agregar(operacion);

            string textoAdicionalLog = "";
            if (operacion.Estado == Operacion.EstadoOperacion.Autorizada)
                textoAdicionalLog = "Autorizada automáticamente.";
            _logger.GenerarLog(operacion, Util.Log_Alta, textoAdicionalLog);
            

            if (operacion.Estado == Operacion.EstadoOperacion.Autorizada)
                return $"Alta de operación exitosa.\nNúmero: {operacion}.\n\nEstado: {operacion.Estado}";
            else
                return $"Alta de operación exitosa.\nNúmero: {operacion}\nEl descuento realizado es superior a la pauta.\n\nEstado: {operacion.Estado}";
        }
        public string ModificarOperacion(Operacion operacion)
        {

            if (!Ticket.TienePermiso(ConstPermisos.OPERACION_MODIFICAR_VENTA))
                throw new NegocioException("No tiene permisos suficientes para realizar esta acción");

            //Validamos la integridad del objeto
            if (!EsValido(operacion))
                throw new NegocioException($"La operación que intenta modificar es inválida.\n{MensajeError}");

            //Leemos la operación que estamos modificando para revisar integridad
            var opLeida = _abmc.Leer(operacion);
            if (opLeida == null)
                throw new NegocioException("No se encontró la operación a actualizar");
            if(opLeida.Estado != operacion.Estado)
                throw new NegocioException($"La operación ya no se encuentra en estado {operacion.Estado}");
            if(opLeida.Anulada)
                throw new NegocioException($"La operación se encuentra anulada.");
            if (!opLeida.Unidad.Equals(operacion.Unidad))
                throw new NegocioException($"La unidad de la operación no coindice con la unidad que tenía.");
            if(opLeida.Unidad.Disponible)
                throw new NegocioException($"La unidad que tiene esta operación se encuentra disponible.");

            //Verificamos la forma de autorización, al modificar, la operación puede ahora autorizarse de forma automática.
            operacion.Estado = Operacion.EstadoOperacion.Autorizada;

            var descuento = Decimal.Round(operacion.Descuento, 4);
            if (!operacion.EsOferta && descuento > operacion.Pauta)
                operacion.Estado = Operacion.EstadoOperacion.Pendiente;

            operacion.Unidad.Disponible = false;
            operacion.AutorizadaEl = null;
            operacion.AutorizadaPor = null;

            _abmc.Modificar(operacion);

            string textoAdicionalLog = "";
            if (operacion.Estado == Operacion.EstadoOperacion.Autorizada)
                textoAdicionalLog = "Autorizada automáticamente.";
            _logger.GenerarLog(operacion, Util.Log_Modificacion, textoAdicionalLog);

            if (operacion.Estado == Operacion.EstadoOperacion.Autorizada)
                return $"Modificación de operación exitosa.\nNúmero: {operacion}.\n\nEstado: {operacion.Estado}";
            else
                return $"Modificación de operación exitosa.\nNúmero: {operacion}.\nEl descuento realizado es superior a la pauta.\n\nEstado: {operacion.Estado}";
        }
        public void AnularOperacion(Operacion operacion)
        {
            if (!Ticket.TienePermiso(ConstPermisos.OPERACION_ANULAR_VENTA))
                throw new NegocioException("No tiene permisos suficientes para realizar esta acción");

            //Controles de consistencia antes de anular.
            var opLeida = _abmc.Leer(operacion);
            if (opLeida == null)
                throw new NegocioException("No se encontró la unidad a actualizar");
            if (opLeida.Anulada)
                throw new NegocioException($"La operación YA se encuentra anulada.");
            if (!opLeida.Unidad.Equals(operacion.Unidad))
                throw new NegocioException($"La unidad de la operación no coindice con la unidad que tenía.");
            if (opLeida.Unidad.Disponible)
                throw new NegocioException($"La unidad que tiene esta operación se encuentra disponible.");

            if (_abmc.TieneObjetosDependientes(opLeida))
                throw new NegocioException("La operación que intenta anular forma parte de una liquidación.\nNo se puede anular.");

            _abmc.Eliminar(opLeida);

            _logger.GenerarLog(opLeida, Util.Log_Anulacion);

            //Si la unidad ahora liberada esta en oferta, habría que vencerla; para eso llamamos al proceso que vence ofertas de forma manual.
            //Como ahora la unidad está disponible, si la oferta está vencida, este proceso la vence.
            BLLStock.ObtenerInstancia().VencerOfertas();

        }

        public void Rechazar(Operacion operacion)
        {
            if (!Ticket.TienePermiso(ConstPermisos.OPERACION_AUTORIZAR))
                throw new NegocioException("No tiene permisos suficientes para realizar esta acción");
            
            //Leemos la operación que estamos modificando para revisar integridad
            var opLeida = _abmc.Leer(operacion);
            if (opLeida == null)
                throw new NegocioException("No se encontró la operación a actualizar");
            if (opLeida.Estado != operacion.Estado)
                throw new NegocioException($"La operación ya no se encuentra en estado {operacion.Estado}");
            if (opLeida.Anulada)
                throw new NegocioException($"La operación se encuentra anulada.");

            opLeida.NotaRechazo = operacion.NotaRechazo;
            opLeida.Estado = Operacion.EstadoOperacion.Rechazada;
            if(String.IsNullOrWhiteSpace(opLeida.NotaRechazo) || opLeida.NotaRechazo.Length < 3)
                throw new NegocioException($"Debe indicar un motivo de rechazo de al menos 3 caractéres.");

            _abmc.Modificar(opLeida);

            string textoLog = $"{opLeida} - Operación Rechazada.";
            _logger.GenerarLog(textoLog);

        }
        public void Autorizar(Operacion operacion, bool operacionAPerdida)
        {
            if (!Ticket.TienePermiso(ConstPermisos.OPERACION_AUTORIZAR))
                throw new NegocioException("No tiene permisos suficientes para realizar esta acción");

            //Leemos la operación que estamos modificando para revisar integridad
            var opLeida = _abmc.Leer(operacion);
            if (opLeida == null)
                throw new NegocioException("No se encontró la operación a actualizar");
            if (opLeida.Estado != operacion.Estado)
                throw new NegocioException($"La operación ya no se encuentra en estado {operacion.Estado}");
            if (opLeida.Anulada)
                throw new NegocioException($"La operación se encuentra anulada.");

            opLeida.NotaRechazo = "";
            opLeida.Estado = Operacion.EstadoOperacion.Autorizada;
            opLeida.AutorizadaEl = DateTime.Now;
            opLeida.AutorizadaPor = Ticket.UsuarioLogueado;

            _abmc.Modificar(opLeida);

            string textoLog = $"{opLeida} - Operación Autorizada.";
            _logger.GenerarLog(textoLog);

            //Determinamos si debemos notificar por ser una autorización NO sugerida por el sistema
            if(operacionAPerdida)
            {
                //Leemos los destinatarios de los flags 
                var parametrosVenta = BLLFlagsVentas.ObtenerInstancia().Leer();
                if (parametrosVenta != null
                    && !string.IsNullOrWhiteSpace(parametrosVenta.DestinatariosNotificacionAutorizacionAPerdida))
                {
                    _servicioAsync.EjectutarAsincronico(
                        async () => await EnviarCorreoAutorizacionNOSugeridaAsync(parametrosVenta.DestinatariosNotificacionAutorizacionAPerdida,
                        opLeida, parametrosVenta.PorcentajeCoberturaARecuperar));
                }
            }
        }

        public IList<VistaOperacionALiquidar> ObtenerPendientesDeLiquidar()
        {
            if (!Ticket.TienePermiso(ConstPermisos.LIQUIDACION_CREAR))
                throw new NegocioException("No tiene permiso para liquidar comisiones..");         


            var query = _abmc.Buscar("","",false).AsQueryable();
            query = query.Where(o => !o.Liquidada && o.Estado.Equals(Operacion.EstadoOperacion.Autorizada));
            if (query == null || query.Count() == 0)
                throw new NegocioException("No hay operaciones pendientes de liquidar.\nNo puede continuar con la liquidación.");

            return ConstruirVistaALiquidar(query.ToList());
        }

        //Metodos para los notificadores popup 
        public int ObtenerCantidadAutorizacionPendientes()
        {
            if (Ticket.TienePermiso(ConstPermisos.OPERACION_AUTORIZAR))
            {
                return _abmc.Buscar("","",false)
                    .Where(o => o.Estado.Equals(Operacion.EstadoOperacion.Pendiente))
                    .Count();
            }
            else
                return 0;
        }
        public int ObtenerCantidadRechazadasPorUsuario()
        {
            if (Ticket.UsuarioLogueado == null)
                return 0;

            if (Ticket.TienePermiso(ConstPermisos.OPERACION_VER))
            {
                //return MPPOperacion.ObtenerInstancia().ObtenerCantidadRechazadasPorUsuario(Ticket.UsuarioLogueado);

                var query = _abmc.Buscar("", "", false).AsQueryable();
                query = query.Where(o => o.Estado.Equals(Operacion.EstadoOperacion.Rechazada));
                query = query.Where(o => o.UsuarioVendedor.Legajo == Ticket.UsuarioLogueado.Legajo);
                return query.Count();
            }
            else
                return 0;
        }

        //Ajuste automatico de forma de pago al cargar/modificar una opeacion
        public void AjustarFormaPago(Operacion operacion)
        {
            decimal fPagoSinAjuste = operacion.ObtenerFormasDePago().Where(p => p.Modificable).Sum(p => p.Importe);
            OperacionFormaPago fPagoAjustable = operacion.ObtenerFormasDePago().Where(p => !p.Modificable)
                .FirstOrDefault();
            if (fPagoAjustable != null)
                fPagoAjustable.Importe = (operacion.PrecioFinal - fPagoSinAjuste) >= 0 ? operacion.PrecioFinal - fPagoSinAjuste : 0;
        }

        //Obtener importe a liquidar para el calculo de comisiones
        public decimal ObtenerImporteALiquidar(Operacion operacion)
        {
            decimal ivaModelo =   BLLModelo.ObtenerInstancia(operacion.Unidad.Modelo).ObtenerTasaIVA();                        
            decimal pVentaSinIVA = operacion.PrecioUnidad / (1 + ivaModelo);
            return pVentaSinIVA;
        }

        //Impresión de Operación
        public VistaImpresionOperacion ObtenerVistaOperacionImpresion(Operacion operacion)
        {
            var operacionLeida = _abmc.Leer(operacion);
            if (operacionLeida == null)
                throw new NegocioException("No se encontró la operación solicitada");

            if(operacionLeida.Anulada)
                throw new NegocioException("No puede imprimir o enviar por mail una operación anulada");          

            return ConstruirVistaImpresion(operacionLeida);
        }
        //Obtener los contactos notificacles del cliente
        public IList<string> ObtenerMailsCliente(Operacion operacion)
        {
            Cliente cli = operacion.Cliente;

            //Armamos un array con los contatos que sean email
            IList<string> contactosEmail = new List<string>();
            foreach (var contacto in cli.ObtenerContactos())
            {
                if (contacto.Tipo.PermiteNotificaciones)
                    contactosEmail.Add(contacto.Valor);
            }

            return contactosEmail;
        }
        public void EnviarOperacionAlCliente(string nroOperacion, string destinatario, string cuerpoMensaje, string pathAdjunto)
        {
            string asunto = $"FULLCAR - Ref.Operación {nroOperacion}";

            _servicioAsync.EjectutarAsincronico(async () => 
                        await EnviarOperacionAlCliente(nroOperacion, destinatario, asunto, cuerpoMensaje, pathAdjunto));

            string textoLog = $"{nroOperacion} - Se envío una copia por e-mail a {destinatario}";
            _logger.GenerarLog(textoLog);
        }

        //El envio lo hacemos asincrono
        private async Task EnviarOperacionAlCliente(string nroOperacion, string destinatario, string asunto, string cuerpoMensaje, string pathAdjunto)
        {
            await _servicioCorreo.EnviarEmailAsync(destinatario, asunto, cuerpoMensaje, pathAdjunto);
        }
        //Envio de mail sobre autorizacion NO sugerica
        private async Task EnviarCorreoAutorizacionNOSugeridaAsync(string destinatarios, Operacion op, decimal porcCobertura)
        {
            if (String.IsNullOrWhiteSpace(destinatarios))
                return;

            if (op == null)
                return;

            decimal cobertura = BLLStock.ObtenerInstancia().CalcularCobertura( op.Unidad.ImporteCompra, porcCobertura / 100);
            decimal valMinimoVenta = BLLStock.ObtenerInstancia().ObtenerValorMinimoVenta(op.Unidad, cobertura);
            decimal precioUnidad = op.PrecioUnidad;

            string asunto = $"FULLCAR - Notificación Autorización de {op} NO sugerida";
            string cuerpo = $"Se efectuado una autorización NO sugerida:\n";
            cuerpo += $"Operacion: {op}\n";
            cuerpo += $"Usuario Autorizante: {op.AutorizadaPor}\n";
            cuerpo += $"Fecha y Hora de Autorización: {op.AutorizadaEl:dd/MM/yyyy HH:mm}\n";
            cuerpo += $"Valor mínimo de venta: {valMinimoVenta:c2}\n";
            cuerpo += $"Precio de venta de la unidad:: {precioUnidad:c2}\n";
            await _servicioCorreo.EnviarEmailAsync(destinatarios, asunto, cuerpo);           
        }


        //Vistas
        private IList<VistaOperacionALiquidar> ConstruirVistaALiquidar(IList<Operacion> source)
        {
            IList<VistaOperacionALiquidar> lista = new List<VistaOperacionALiquidar>();
            VistaOperacionALiquidar destItem;
            foreach (var sourceItem in source)
            {
                destItem = new VistaOperacionALiquidar();

                destItem.NumeroInterno = sourceItem.Numero.Value;
                destItem.Numero = sourceItem.ToString();
                destItem.Fecha = sourceItem.Fecha;
                destItem.UsuarioVendedor = sourceItem.UsuarioVendedor.ToString();
                destItem.DescModelo = sourceItem.Unidad?.Modelo?.Descripcion;
                destItem.TasaIVA = BLLModelo.ObtenerInstancia(sourceItem.Unidad.Modelo).ObtenerTasaIVA();
                destItem.Cliente = sourceItem.Cliente.ToString();
                destItem.PrecioUnidad = sourceItem.PrecioUnidad;
                destItem.NetoAComisionar = BLLOperacion.ObtenerInstancia().ObtenerImporteALiquidar(sourceItem);


                lista.Add(destItem);
            }
            return lista;
        }
        private IList<VistaOperacion> ConstruirVista(IList<Operacion> source)
        {
            IList<VistaOperacion> lista = new List<VistaOperacion>();
            VistaOperacion destItem;
            foreach (var sourceItem in source)
            {
                destItem = new VistaOperacion();

                destItem.NumeroInterno = sourceItem.Numero.Value;
                destItem.Numero = sourceItem.ToString();
                destItem.UsuarioVendedor = sourceItem.UsuarioVendedor.ToString();
                destItem.Chasis = sourceItem.Unidad?.Chasis;
                destItem.CodModelo = sourceItem.Unidad?.Modelo?.Codigo;
                destItem.DescModelo = sourceItem.Unidad?.Modelo?.Descripcion;
                destItem.Color = sourceItem.Unidad?.Color?.Descripcion;
                destItem.Cliente = sourceItem.Cliente.ToString();
                destItem.Fecha = sourceItem.Fecha;
                destItem.Estado = sourceItem.Estado.ToString();
                destItem.PrecioFinal = sourceItem.PrecioFinal;
                destItem.EsOferta = sourceItem.EsOferta;
                destItem.Anulada = sourceItem.Anulada;
                destItem.NotaRechazo = sourceItem.NotaRechazo;
                destItem.Liquidada = sourceItem.Liquidada;
                destItem.PatentaEmpresa = sourceItem.PatentaEmpresa;
                destItem.FechaAutorizacion = sourceItem.AutorizadaEl;
                destItem.UsuarioAutorizacion = sourceItem.AutorizadaPor?.Logon;

                lista.Add(destItem);
            }
            return lista;
        }
        private IList<VistaAutorizacionOperacion> ConstruirVistaAutorizacion(IList<Operacion> source)
        {
            IList<VistaAutorizacionOperacion> lista = new List<VistaAutorizacionOperacion>();
            VistaAutorizacionOperacion destItem;
            foreach (var sourceItem in source)
            {
                destItem = new VistaAutorizacionOperacion();

                destItem.NumeroInterno = sourceItem.Numero.Value;
                destItem.Numero = sourceItem.ToString();
                destItem.UsuarioVendedor = sourceItem.UsuarioVendedor.ToString();
                destItem.CodModelo = sourceItem.Unidad?.Modelo?.Codigo;
                destItem.DescModelo = sourceItem.Unidad?.Modelo?.Descripcion;
                destItem.Color = sourceItem.Unidad?.Color?.Descripcion;
                destItem.Cliente = sourceItem.Cliente.ToString();
                destItem.PrecioPublico = sourceItem.PrecioPublico;
                destItem.Pauta = sourceItem.Pauta;
                destItem.PrecioUnidad = sourceItem.PrecioUnidad;
                destItem.Descuento = sourceItem.Descuento;
                destItem.Descalce = sourceItem.Descalce;
                destItem.PrecioFinal = sourceItem.PrecioFinal;

                lista.Add(destItem);
            }
            return lista;
        }
        private VistaImpresionOperacion ConstruirVistaImpresion(Operacion sourceItem)
        {
            VistaImpresionOperacion destItem;
            destItem = new VistaImpresionOperacion();

            destItem.NroOperacion = sourceItem.ToString();
            destItem.Fecha = sourceItem.Fecha.ToString("dd/MM/yyyy");
            destItem.Vendedor = $"{sourceItem.UsuarioVendedor.Nombre} {sourceItem.UsuarioVendedor.Apellido}";
            destItem.Cliente_Nombre = $"{sourceItem.Cliente.Apellido},  {sourceItem.Cliente.Nombre}";
            destItem.Cliente_CUIT = sourceItem.Cliente.CUIT;
            destItem.Unidad_Chasis = sourceItem.Unidad.Chasis;
            destItem.Unidad_Modelo = sourceItem.Unidad.Modelo.Descripcion;
            destItem.Unidad_Color = sourceItem.Unidad.Color.Descripcion;
            destItem.PrecioUnidad = sourceItem.PrecioUnidad.ToString("c2");
            if (sourceItem.PatentaEmpresa)
                destItem.TextoPatentamiento = "Patentamiento a cargo de la EMPRESA";
            else
                destItem.TextoPatentamiento = "Patentamiento a cargo del CLIENTE";
            destItem.GastoGestoria = sourceItem.GastoGestoria.ToString("c2");
            destItem.GastoUsados = sourceItem.GastoUsado.ToString("c2");
            destItem.GastoFinanciacion = sourceItem.GastoFinanciacion.ToString("c2");
            destItem.PrecioFinal = sourceItem.PrecioFinal.ToString("c2");
            if (sourceItem.Estado == Operacion.EstadoOperacion.Autorizada)
                destItem.TextoAutorizacion = "(*) Operación AUTORIZADA";
            else
                destItem.TextoAutorizacion = "(*) Precio sujeto a aprobación.";

            foreach (var opfpago in sourceItem.ObtenerFormasDePago())
            {
                destItem.AgregarFormaPago(new VistaImpresionOperacionFormaPago()
                {
                    FormaPago = opfpago.FormaPago.Descripcion,
                    Importe = opfpago.Importe.ToString("c2")
                });
            }
            return destItem;
        }

    }
}
