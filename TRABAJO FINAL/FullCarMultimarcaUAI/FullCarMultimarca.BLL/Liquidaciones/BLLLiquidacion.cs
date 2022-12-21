using FullCarMultimarca.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullCarMultimarca.BE.Liquidaciones;
using FullCarMultimarca.Vistas;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.BE.Ventas;
using FullCarMultimarca.MPP.Ventas;
using FullCarMultimarca.BLL.Ventas;
using FullCarMultimarca.BLL.Parametros;
using FullCarMultimarca.MPP.Liquidaciones;
using FullCarMultimarca.BLL.Gestion;

namespace FullCarMultimarca.BLL.Liquidaciones
{
    public class BLLLiquidacion : IValidable<Liquidacion>
    {

        private BLLLiquidacion()
        {
            _abm = MPPLiquidacion.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
        }

        private static BLLLiquidacion _bllLiquidacion = null;        
        private ILogger _logger;
        private IMapping<Liquidacion> _abm;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static BLLLiquidacion ObtenerInstancia()
        {
            if (_bllLiquidacion == null)
                _bllLiquidacion = new BLLLiquidacion();
            return _bllLiquidacion;
        }
        ~BLLLiquidacion()
        {
            _bllLiquidacion = null;
            _logger = null;
            _abm = null;
        }

        #region IMPLEMENTACIÓN IVALIDABLE

        public string MensajeError { get; internal set; }
        public bool EsValido(Liquidacion objeto)
        {
            MensajeError = "";

            if(String.IsNullOrWhiteSpace(objeto.Codigo))
                MensajeError += "- Debe indicar el código de liquidación.\n";

            if (_abm.Existe(objeto))
                throw new NegocioException($"El código de liquidación que intenta agregar ya existe");


            return String.IsNullOrEmpty(MensajeError);
        }

        #endregion        


        public IList<VistaLiquidacionHeader> ObtenerLiquidaciones()
        {
            return ConstruirVista(_abm
                .ObtenerTodos()
                .OrderByDescending(l => l.FechaLiquidacion)
                .ToList());
        }
        public VistaLiquidacion ObtenerVistaCompleta(Liquidacion liquidacion)
        {
            var liquidacionLeida = _abm.Leer(liquidacion);
            return ConstruirVista(liquidacionLeida);
        }
        public Dictionary<string, decimal> AgruparComisionesPorVendedor(IList<VistaLiquidacionVendedor> vistaLiqVendedor)
        {
            var grp = vistaLiqVendedor
                .GroupBy(v => v.UsuarioVendedor);

            Dictionary<string, decimal> grupoVendedores = new Dictionary<string, decimal>();
            foreach (var kvp in grp)
            {
                grupoVendedores.Add(kvp.Key, kvp.Sum(s => s.Comision));
            }
            return grupoVendedores;
        }

        public void GenerarLiquidacion(Liquidacion nuevaLiquidacion, 
            IList<VistaOperacionALiquidar> operacionesALiquidar)
        {
            if (!Ticket.TienePermiso(ConstPermisos.LIQUIDACION_CREAR))
                throw new NegocioException("No tiene permisos suficientes para realizar esta acción");
            
            //Validamos la integridad del objeto
            if (!EsValido(nuevaLiquidacion))
                throw new NegocioException($"La liquidación que intenta agregar es inválida.\n{MensajeError}");

            if(operacionesALiquidar.Count() == 0)
                throw new NegocioException($"La liquidación debe contener al menos una operación.");           

            //Obtenemos un list de operaciones
            IList<Operacion> operaciones = new List<Operacion>();
            Operacion opLeida;
            StringBuilder sbErrores = new StringBuilder();
            foreach(var vop in operacionesALiquidar)
            {
                opLeida = BLLOperacion.ObtenerInstancia().Leer(new Operacion { Numero = vop.NumeroInterno });
                if (opLeida == null)
                    sbErrores.AppendLine($"- {vop.Numero}: No encontrada.");
                else if (opLeida.Anulada)
                    sbErrores.AppendLine($"- {vop.Numero}: Anulada.");
                else if (opLeida.Liquidada)
                    sbErrores.AppendLine($"- {vop.Numero}: Ya Liquidada.");
                else if (opLeida.Estado != Operacion.EstadoOperacion.Autorizada)
                    sbErrores.AppendLine($"- {vop.Numero}: NO Autorizada.");
                else
                    operaciones.Add(opLeida);
            }
            if (!String.IsNullOrWhiteSpace(sbErrores.ToString()))
                throw new NegocioException($"Existen errores entre las operaciones seleccionadas:\n{sbErrores}");


            //Algoritmo de calculo de comisión
            CalcularComisiones(nuevaLiquidacion, operaciones);

            //Guardamos
            _abm.Agregar(nuevaLiquidacion);

            //Log
            _logger.GenerarLog($"Liquidación {nuevaLiquidacion.Codigo} del {nuevaLiquidacion.FechaLiquidacion:dd/MM/yyyy} GENERADA");

        }
        public void EliminarLiquidacion(Liquidacion liquidacion)
        {
            if (!Ticket.TienePermiso(ConstPermisos.LIQUIDACION_ELIMINAR))
                throw new NegocioException("No tiene permisos suficientes para realizar esta acción");

            if(!_abm.Existe(liquidacion))
                throw new NegocioException("La liquidación que intenta eliminar ya no existe.");

            if(_abm.TieneObjetosDependientes(liquidacion))
                throw new NegocioException("No se puede eliminar la liquidación debido a que tiene objetos dependientes.");

            _abm.Eliminar(liquidacion);

            //Log
            _logger.GenerarLog($"Liquidación {liquidacion.Codigo} del {liquidacion.FechaLiquidacion:dd/MM/yyyy} ELIMINADA");
        }                  
      

        /// <summary>
        /// Algorítmo para el cálculo de comisiones
        /// </summary>        
        private void CalcularComisiones(Liquidacion liquidacion, IList<Operacion> operaciones)
        {
            //El algorítmo sigue los lienamientos de la documentación especificados en el flujograma,
            //pero reduce la utilización de variables y calculos debido a que utiliza campos calculados, y linq.

            //Obtenemos los parámetros de liquidación
            var parametros = BLLFlagsComisiones.ObtenerInstancia().Leer();
            if (parametros == null)
                throw new NegocioException("No se pudieron obtener los parámetros de las comisiones.");

            LiquidacionVendedor liquidacionVendedor;
            decimal totalOperaciones = 0;
            decimal totalVendedores = 0;
            //Recorre las operaciones a liquidar y las agrega a la liquidación
            foreach (var operacion in operaciones)
            {
                liquidacionVendedor = null;
                totalOperaciones++;               
                liquidacionVendedor = liquidacion.ObtenerLiquidacionVendedores().FirstOrDefault(lv => lv.UsuarioVendedor.Legajo == operacion.UsuarioVendedor.Legajo);
                if (liquidacionVendedor == null)
                {
                    totalVendedores++;                    
                    liquidacion.AgregarLiquidacionVendedor(operacion.UsuarioVendedor);
                    liquidacionVendedor = liquidacion.ObtenerLiquidacionVendedores().FirstOrDefault(lv => lv.UsuarioVendedor.Legajo == operacion.UsuarioVendedor.Legajo);
                }
                liquidacionVendedor.AgregarOperacion(operacion);
            }


            //Obtenemos el promedio de operaciones: es el total de operaciones sobre el total de vendedores.
            decimal promedioOps = Decimal.Round(totalOperaciones / totalVendedores, 2);

            //Ahora que tenemos el objeto liquidación completo, tenemos que recorrer cada liquidación vendedor para calcular.
            foreach (var liqVendedor in liquidacion.ObtenerLiquidacionVendedores())
            {
                //Calculamos el neto a comisionar
                liqVendedor.NetoAComisionar = Decimal.Round(liqVendedor.ObtenerOperaciones()
                    .Sum(o => BLLOperacion.ObtenerInstancia().ObtenerImporteALiquidar(o)), 2);

                //Determinamos la comisión
                liqVendedor.PorcentajeComision = parametros.PorcentajeComisionN1 / 100;
                if (liqVendedor.CantidadOperaciones >= parametros.CantidadMinimaN3)
                    liqVendedor.PorcentajeComision = parametros.PorcentajeComisionN3 / 100;
                else if (liqVendedor.CantidadOperaciones >= parametros.CantidadMinimaN2)
                    liqVendedor.PorcentajeComision = parametros.PorcentajeComisionN2 / 100;

                //Determinamos el premio volumen
                if (liqVendedor.CantidadOperaciones >= promedioOps)
                    liqVendedor.PremioVolumen = parametros.ImportePremioVolumen;

            }


        }

        private VistaLiquidacion ConstruirVista(Liquidacion sourceItem)
        {            
            VistaLiquidacion destItem;
            VistaLiquidacionVendedor destVend;
            VistaLiquidacionOperacion destOp;

            destItem = new VistaLiquidacion();

            destItem.Codigo = sourceItem.Codigo;
            destItem.Fecha = sourceItem.FechaLiquidacion.ToString("dd/MM/yyyy");
            destItem.Comentarios = sourceItem.Comentarios;

            foreach (var liqVendedor in sourceItem.ObtenerLiquidacionVendedores())
            {
                destVend = new VistaLiquidacionVendedor();

                destVend.UsuarioVendedor = liqVendedor.UsuarioVendedor.Logon;
                destVend.CantidadOperaciones = liqVendedor.CantidadOperaciones;
                destVend.NetoAComisionar = liqVendedor.NetoAComisionar;
                destVend.PorcentajeComision = liqVendedor.PorcentajeComision;
                destVend.Comision = liqVendedor.Comision;
                destVend.PremioVolumen = liqVendedor.PremioVolumen;
                destVend.TotalACobrar = liqVendedor.TotalACobrar;


                foreach (var op in liqVendedor.ObtenerOperaciones())
                {

                    destOp = new VistaLiquidacionOperacion();

                    destOp.Numero = op.ToString();
                    destOp.DescModelo = op.Unidad.Modelo.Descripcion;                                        
                    destOp.PrecioUnidad = op.PrecioUnidad;                    

                    destVend.AgegarOperacion(destOp);

                }

                destItem.AgregarVendedor(destVend);
            }

            destItem.TotalEnComisiones = sourceItem.ObtenerLiquidacionVendedores().Sum(v => v.Comision).ToString("c2");
            destItem.TotalEnPremioVolumen = sourceItem.ObtenerLiquidacionVendedores().Sum(v => v.PremioVolumen).ToString("c2");
            destItem.TotalGeneral = sourceItem.ObtenerLiquidacionVendedores().Sum(v => v.PremioVolumen + v.Comision).ToString("c2");

            return destItem;
        }
        private IList<VistaLiquidacionHeader> ConstruirVista(IList<Liquidacion> source)
        {
            IList<VistaLiquidacionHeader> lista = new List<VistaLiquidacionHeader>();
            VistaLiquidacionHeader destItem;
            foreach (var sourceItem in source)
            {
                destItem = new VistaLiquidacionHeader();
                destItem.Codigo = sourceItem.Codigo;
                destItem.FechaLiquidacion = sourceItem.FechaLiquidacion;
                destItem.Comentarios = sourceItem.Comentarios;
                
                lista.Add(destItem);
            }
            return lista;
        }


    }
}
