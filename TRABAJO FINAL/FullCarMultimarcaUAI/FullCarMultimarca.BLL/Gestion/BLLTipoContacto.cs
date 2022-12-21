using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.MPP.Gestion;
using FullCarMultimarca.Servicios.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullCarMultimarca.Vistas;
using System.Globalization;
using FullCarMultimarca.Servicios.Extensiones;

namespace FullCarMultimarca.BLL.Gestion
{
    public class BLLTipoContacto : IValidable<TipoContacto>, IAbmc<TipoContacto, VistaTipoContacto>
    {
        private BLLTipoContacto()
        {
            _abmc = MPPTipoContacto.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
        }

        private static BLLTipoContacto _bllTipoContacto = null;
        private IMapping<TipoContacto> _abmc;
        private ILogger _logger;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static BLLTipoContacto ObtenerInstancia()
        {
            if (_bllTipoContacto == null)
                _bllTipoContacto = new BLLTipoContacto();
            return _bllTipoContacto;
        }
        ~BLLTipoContacto()
        {
            _bllTipoContacto = null;
            _logger = null;
            _abmc = null;
        }

        #region IMPLEMENTACIÓN IVALIDABLE

        public string MensajeError { get; internal set; }
        public bool EsValido(TipoContacto objeto)
        {
            MensajeError = "";

            if (string.IsNullOrWhiteSpace(objeto.Descripcion))
                MensajeError += "- Debe indicar la descripción";


            return String.IsNullOrEmpty(MensajeError);
        }

        #endregion

        public TipoContacto Leer(TipoContacto tipoContacto)
        {
            TipoContacto tContacto = _abmc.Leer(tipoContacto);
            if (tContacto == null)
                throw new NegocioException("No se encontró el tipo de contacto");
            return tContacto;
        }
        public IList<TipoContacto> ObtenerTodos()
        {
            return _abmc.ObtenerTodos();
        }
        public IList<VistaTipoContacto> Buscar(string propiedad, string texto, bool incluirInactivos)
        {
            return ConstruirVista(_abmc.Buscar(propiedad, texto, incluirInactivos));
        }

        public void Agregar(TipoContacto objeto)
        {
            if (!EsValido(objeto))
                throw new NegocioException($"El tipo de contacto que intenta guardar es inválido.\n{MensajeError}");
            if (_abmc.Existe(objeto))
                throw new NegocioException("El tipo de contacto que intenta agregar ya existe.");

            _abmc.Agregar(objeto);

            _logger.GenerarLog(objeto, Util.Log_Alta);
        }
        public void Modificar(TipoContacto objeto, string descripcionAnterior)
        {
            if (!EsValido(objeto))
                throw new NegocioException($"El tipo de contacto que intenta guardar es inválido.\n{MensajeError}");
            if (!_abmc.Existe(new TipoContacto { Descripcion = descripcionAnterior }))
                throw new NegocioException($"El tipo de contacto que intenta modificar NO existe");
            
            if (!objeto.Descripcion.EqualsAICI(descripcionAnterior) && _abmc.Existe(objeto))
                throw new NegocioException("La descripción del tipo de contacto ya existe.");

            _abmc.Modificar(objeto, descripcionAnterior);

            _logger.GenerarLog(objeto, Util.Log_Modificacion);
        }
        public void Eliminar(TipoContacto objeto)
        {
            if (_abmc.TieneObjetosDependientes(objeto))
                throw new NegocioException("El tipo de contacto que intenta eliminar tiene contactos asignados.\nNo puede eliminarlo.");
            _abmc.Eliminar(objeto);

            _logger.GenerarLog(objeto, Util.Log_Baja);
        }


        private IList<VistaTipoContacto> ConstruirVista(IList<TipoContacto> source)
        {
            IList<VistaTipoContacto> lista = new List<VistaTipoContacto>();
            VistaTipoContacto destItem;
            foreach (var sourceItem in source)
            {
                destItem = new VistaTipoContacto();                
                destItem.Descripcion = sourceItem.Descripcion;
                destItem.Activo = sourceItem.Activo;
                destItem.PermiteNotificaciones = sourceItem.PermiteNotificaciones;                

                lista.Add(destItem);
            }
            return lista;
        }
    }
}
