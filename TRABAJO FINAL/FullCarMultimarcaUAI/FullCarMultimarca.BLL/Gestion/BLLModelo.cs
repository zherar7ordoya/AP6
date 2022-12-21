
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
using FullCarMultimarca.Servicios;

namespace FullCarMultimarca.BLL.Gestion
{

    public abstract class BLLModelo : IValidable<Modelo>, IAbmc<Modelo, VistaModelo>
    {
        protected BLLModelo()
        {
            _abmc = MPPModelo.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();           
        }        

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado.
        /// Obtiene una instancia de alguna de las subclases de BLLModelo según el T recibido.
        /// </summary>
        /// <returns></returns>      
        public static BLLModelo ObtenerInstancia<T>() where T : Modelo
        {
            _bllModelo = _servicioCorrespondenciaPolimorfica
                .ObtenerCorrespondencia(typeof(T));            

            return _bllModelo;          
        }
        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado.
        /// Obtiene una instancia de alguna de las subclases de BLLModelo según el T del modelo recibido.
        /// </summary>
        /// <returns></returns>      
        public static BLLModelo ObtenerInstancia<T>(T modelo) where T : Modelo
        {

            _bllModelo = _servicioCorrespondenciaPolimorfica
                .ObtenerCorrespondencia(modelo.GetType());            

            return _bllModelo;
        }

        private static IServicioCorrespondenciaPolimorfica<BLLModelo> _servicioCorrespondenciaPolimorfica = 
            new ServicioCorrespondenciaPolimorfica<BLLModelo>();
        private static BLLModelo _bllModelo = null;
        private IMapping<Modelo> _abmc;
        private ILogger _logger;
        
     
        ~BLLModelo()
        {
            _bllModelo = null;
            _abmc = null;
            _logger = null;            
        }

        #region IMPLEMENTACIÓN IVALIDABLE

        public string MensajeError { get; internal set; }
        public bool EsValido(Modelo objeto)
        {
            MensajeError = "";

            if (String.IsNullOrWhiteSpace(objeto.Codigo))
                MensajeError += "- Debe indicar el código\n";
            if (string.IsNullOrWhiteSpace(objeto.Descripcion))
                MensajeError += "- Debe indicar la descripción\n";
            if(objeto.Marca == null)
                MensajeError += "- Debe indicar la Marca\n";
            if(objeto.PrecioPublico <= 0)
                MensajeError += "- El precio público debe ser un valor mayor a cero.\n";         


            return String.IsNullOrEmpty(MensajeError);
        }

        #endregion

        public Modelo Leer(Modelo modelo)
        {
            Modelo modeoLeido = _abmc.Leer(modelo);
            if (modeoLeido == null)
                throw new NegocioException("No se encontró el modelo");
            return modeoLeido;
        }
        public IList<Modelo> ObtenerTodos()
        {
            return _abmc.ObtenerTodos();
        }
        public IList<VistaModelo> Buscar(string propiedad, string texto, bool incluirInactivos)
        {
            return ConstruirVista(_abmc.Buscar(propiedad, texto, incluirInactivos));
        }

        public void Agregar(Modelo objeto)
        {
            if (!EsValido(objeto))
                throw new NegocioException($"El modelo que intenta guardar es inválido.\n{MensajeError}");
            if (_abmc.Existe(objeto))
                throw new NegocioException($"El código de Modelo que intenta agregar ya existe");
            _abmc.Agregar(objeto);

            _logger.GenerarLog(objeto, Util.Log_Alta);
        }
        public void Modificar(Modelo objeto, string valorAnteriorCodigo = null)
        {
            if (!EsValido(objeto))
                throw new NegocioException($"El Modelo que intenta guardar es inválido.\n{MensajeError}");
            if (!_abmc.Existe(objeto))
                throw new NegocioException($"El código de Modelo que intenta modificar NO existe");
            _abmc.Modificar(objeto);

            _logger.GenerarLog(objeto, Util.Log_Modificacion);
        }
        public void Eliminar(Modelo objeto)
        {
            if (_abmc.TieneObjetosDependientes(objeto))
                throw new NegocioException("El modelo que intenta eliminar tiene unidades asociadas.\nNo puede eliminar.");
            _abmc.Eliminar(objeto);

            _logger.GenerarLog(objeto, Util.Log_Baja);
        }

        private IList<VistaModelo> ConstruirVista(IList<Modelo> source)
        {
            IList<VistaModelo> lista = new List<VistaModelo>();
            VistaModelo destItem;
            foreach (var sourceItem in source)
            {
                destItem = new VistaModelo();
                destItem.Codigo = sourceItem.Codigo;
                destItem.Descripcion = sourceItem.Descripcion;
                destItem.Marca = sourceItem.Marca?.ToString();
                destItem.Activo = sourceItem.Activo;
                destItem.PrecioPublico = sourceItem.PrecioPublico;
                
                lista.Add(destItem);
            }
            return lista;
        }

        #region NEGOCIO

        public abstract decimal ObtenerTasaIVA();

        #endregion

    }
}
