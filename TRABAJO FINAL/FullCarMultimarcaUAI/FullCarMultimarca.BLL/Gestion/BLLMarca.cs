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
    public class BLLMarca : IValidable<Marca>, IAbmc<Marca, VistaMarca>
    {
        private BLLMarca()
        {
            _abmc = MPPMarca.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
        }

        private static BLLMarca _bllMarca = null;
        private IMapping<Marca> _abmc;
        private ILogger _logger;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static BLLMarca ObtenerInstancia()
        {
            if (_bllMarca == null)
                _bllMarca = new BLLMarca();
            return _bllMarca;
        }
        ~BLLMarca()
        {
            _bllMarca = null;
            _abmc = null;
            _logger = null;
        }

        #region IMPLEMENTACIÓN IVALIDABLE

        public string MensajeError { get; internal set; }
        public bool EsValido(Marca objeto)
        {
            MensajeError = "";
                        
            if (string.IsNullOrWhiteSpace(objeto.Descripcion))
                MensajeError += "- Debe indicar la descripción";          


            return String.IsNullOrEmpty(MensajeError);
        }

        #endregion

        public Marca Leer(Marca marca)
        {
            Marca marcaLeida = _abmc.Leer(marca);
            if (marcaLeida == null)
                throw new NegocioException("No se encontró la marca");
            return marcaLeida;
        }
        public IList<Marca> ObtenerTodos()
        {
            return _abmc.ObtenerTodos();
        }
        public IList<VistaMarca> Buscar(string propiedad, string texto, bool incluirInactivos)
        {
            return ConstruirVista(_abmc.Buscar(propiedad, texto, incluirInactivos));
        }

        public void Agregar(Marca objeto)
        {
            if (!EsValido(objeto))
                throw new NegocioException($"La Marca que intenta guardar es inválida.\n{MensajeError}");

            if (_abmc.Existe(objeto))
                throw new NegocioException("La Marca que intenta agregar ya existe.");

            _abmc.Agregar(objeto);

            _logger.GenerarLog(objeto, Util.Log_Alta);
        }
        public void Modificar(Marca objeto, string descripcionAnterior)
        {
            if (!EsValido(objeto))
                throw new NegocioException($"La Marca que intenta guardar es inválida.\n{MensajeError}");
            if (!_abmc.Existe(new Marca { Descripcion = descripcionAnterior }))
                throw new NegocioException($"La Marca que intenta modificar NO existe");
            if (!objeto.Descripcion.EqualsAICI(descripcionAnterior) && _abmc.Existe(objeto))
                throw new NegocioException("La descripción de la marca ya existe.");

            _abmc.Modificar(objeto, descripcionAnterior);

            _logger.GenerarLog(objeto, Util.Log_Modificacion);
        }
        public void Eliminar(Marca objeto)
        {            
            if (_abmc.TieneObjetosDependientes(objeto))
                throw new NegocioException("La Marca que intenta eliminar tiene modelos asignados.\nDebe desasignar previamente.");
            _abmc.Eliminar(objeto);

            _logger.GenerarLog(objeto, Util.Log_Baja);
        }

        private IList<VistaMarca> ConstruirVista(IList<Marca> source)
        {
            IList<VistaMarca> lista = new List<VistaMarca>();
            VistaMarca destItem;
            foreach (var sourceItem in source)
            {
                destItem = new VistaMarca();
                
                destItem.Descripcion = sourceItem.Descripcion;
                destItem.Activa = sourceItem.Activa;              

                lista.Add(destItem);
            }
            return lista;
        }
    }
}
