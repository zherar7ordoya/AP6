using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.MPP.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullCarMultimarca.Servicios.Excepciones;
using FullCarMultimarca.BE.Gestion;
using FullCarMultimarca.Vistas;
using FullCarMultimarca.Servicios.Extensiones;

namespace FullCarMultimarca.BLL.Gestion
{
    public class BLLColorUnidad : IValidable<ColorUnidad>, IAbmc<ColorUnidad, VistaColorUnidad>
    {
        private BLLColorUnidad()
        {
            _abmc = MPPColorUnidad.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
        }

        private static BLLColorUnidad _bllColorUnidad = null;
        private IMapping<ColorUnidad> _abmc;
        private ILogger _logger;

        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static BLLColorUnidad ObtenerInstancia()
        {
            if (_bllColorUnidad == null)
                _bllColorUnidad = new BLLColorUnidad();
            return _bllColorUnidad;
        }
        ~BLLColorUnidad()
        {
            _bllColorUnidad = null;
            _abmc = null;
            _logger = null;
        }

        #region IMPLEMENTACIÓN IVALIDABLE

        public string MensajeError { get; internal set; }
        public bool EsValido(ColorUnidad objeto)
        {
            MensajeError = "";
           
            if (string.IsNullOrWhiteSpace(objeto.Descripcion))
                MensajeError += "- Debe indicar la descripción";


            return String.IsNullOrEmpty(MensajeError);
        }

        #endregion

        public ColorUnidad Leer(ColorUnidad colorUnidad)
        {
            ColorUnidad color = _abmc.Leer(colorUnidad);
            if (color == null)
                throw new NegocioException("No se encontró el color");
            return color;
        }
        public IList<ColorUnidad> ObtenerTodos()
        {
            return _abmc.ObtenerTodos();
        }
        public IList<VistaColorUnidad> Buscar(string propiedad, string texto, bool incluirInactivos)
        {
            return ConstruirVista(_abmc.Buscar(propiedad, texto, incluirInactivos));
        }

        public void Agregar(ColorUnidad objeto)
        {
            if (!EsValido(objeto))
                throw new NegocioException($"El color que intenta guardar es inválido.\n{MensajeError}");
            if(_abmc.Existe(objeto))
                throw new NegocioException("El color que intenta agregar ya existe.");

            _abmc.Agregar(objeto);

            _logger.GenerarLog(objeto, Util.Log_Alta);
        }
        public void Modificar(ColorUnidad objeto, string descripcionAnterior)
        {
            if (!EsValido(objeto))
                throw new NegocioException($"El color que intenta guardar es inválido.\n{MensajeError}");
            if (!_abmc.Existe(new ColorUnidad { Descripcion =  descripcionAnterior}))
                throw new NegocioException($"El Color que intenta modificar NO existe");
            if (!objeto.Descripcion.EqualsAICI(descripcionAnterior) && _abmc.Existe(objeto))
                throw new NegocioException("La descripción de color ya existe.");
            _abmc.Modificar(objeto, descripcionAnterior);

            _logger.GenerarLog(objeto, Util.Log_Modificacion);
        }
        public void Eliminar(ColorUnidad objeto)
        {        
            if (_abmc.TieneObjetosDependientes(objeto))
                throw new NegocioException("El color que intenta eliminar tiene unidades asignadas.\nNo puede eliminarlo.");
            _abmc.Eliminar(objeto);

            _logger.GenerarLog(objeto, Util.Log_Baja);
        }

        private IList<VistaColorUnidad> ConstruirVista(IList<ColorUnidad> source)
        {
            IList<VistaColorUnidad> lista = new List<VistaColorUnidad>();
            VistaColorUnidad destItem;
            foreach (var sourceItem in source)
            {
                destItem = new VistaColorUnidad();                
                destItem.Descripcion = sourceItem.Descripcion;
                destItem.Activo = sourceItem.Activo;                

                lista.Add(destItem);
            }
            return lista;
        }
       
    }
}
