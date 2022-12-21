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
    public class BLLCliente : IValidable<Cliente>, IAbmc<Cliente, VistaCliente>
    {
        private BLLCliente()
        {
            _abmc = MPPCliente.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
            _servicioValidacion = new ServicioValidacion();
        }

        private static BLLCliente _bllCliente = null;

        private IMapping<Cliente> _abmc;
        private ILogger _logger;
        private IServicioValidacion _servicioValidacion;


        /// <summary>
        /// Unifica la forma de obtener una instancia de esta clase. Constructor es privado
        /// </summary>
        /// <returns></returns>
        public static BLLCliente ObtenerInstancia()
        {
            if (_bllCliente == null)
                _bllCliente = new BLLCliente();
            return _bllCliente;
        }
        ~BLLCliente()
        {
            _bllCliente = null;
            _logger = null;
            _abmc = null;
            _servicioValidacion = null;
        }

        #region IMPLEMENTACIÓN IVALIDABLE

        public string MensajeError { get; internal set; }
        public bool EsValido(Cliente objeto)
        {
            MensajeError = "";

            if (String.IsNullOrWhiteSpace(objeto.CUIT))
                MensajeError += "- Debe indicar el CUIL/CUIT\n";
            else if (!_servicioValidacion.ValidarPatronString(objeto.CUIT, Util.PatronValidacionCUIT))
                MensajeError += "- El CUIL/CUIT ingresado es inválido\n";
            else if(!_servicioValidacion.ValidarCuit(objeto.CUIT))
                MensajeError += "- El CUIL/CUIT ingresado es inválido\n";        

            if (string.IsNullOrWhiteSpace(objeto.Apellido))
                MensajeError += "- Debe ingresar el apellido\n";
            if (string.IsNullOrWhiteSpace(objeto.Nombre))
                MensajeError += "- Debe ingresar el nombre\n";

            if (string.IsNullOrWhiteSpace(objeto.Direccion))
                MensajeError += "- Debe ingresar una dirección\n";
            if (string.IsNullOrWhiteSpace(objeto.Localidad))
                MensajeError += "- Debe ingresar la localidad\n";
            if (string.IsNullOrWhiteSpace(objeto.CodigoPostal))
                MensajeError += "- Debe ingresar un código postal\n";
            if (string.IsNullOrWhiteSpace(objeto.Provincia))
                MensajeError += "- Debe ingresar la provincia\n";

            if(objeto.ObtenerContactos().Count == 0)
                MensajeError += "- Debe ingresar al menos un dato de contacto\n";

            foreach(var contacto in objeto.ObtenerContactos())
            {
                if(!String.IsNullOrWhiteSpace(contacto.Tipo.ExpresionValidacion))
                {
                    if(!_servicioValidacion.ValidarPatronString(contacto.Valor,contacto.Tipo.ExpresionValidacion))
                    {
                        MensajeError += $"- Contacto {contacto.Tipo} {contacto.Valor} - Formato inváldo.\n";
                    }
                }                
            }          

            return String.IsNullOrEmpty(MensajeError);
        }

        #endregion

        public Cliente Leer(Cliente cliente)
        {
            Cliente color = _abmc.Leer(cliente);
            if (color == null)
                throw new NegocioException("No se encontró el cliente");
            return color;
        }
        public IList<Cliente> ObtenerTodos()
        {
            return _abmc.ObtenerTodos();
        }
        public IList<VistaCliente> Buscar(string propiedad, string texto, bool incluirInactivos = false)
        {
            return ConstruirVista(_abmc.Buscar(propiedad, texto));
        }       

        public void Agregar(Cliente objeto)
        {
            if (!EsValido(objeto))
                throw new NegocioException($"El cliente que intenta guardar es inválido.\n{MensajeError}");

            if (_abmc.Existe(objeto))
                throw new NegocioException("El CUIT del cliente que intenta agregar ya existe ingresado.");

            _abmc.Agregar(objeto);

            _logger.GenerarLog(objeto, Util.Log_Alta);
        }
        public void Modificar(Cliente objeto, string valorCUITAnterior)
        {
            if (!EsValido(objeto))
                throw new NegocioException($"El cliente que intenta guardar es inválido.\n{MensajeError}");

            if (!_abmc.Existe(new Cliente { CUIT = valorCUITAnterior }))
                throw new NegocioException($"El Cliente que intenta modificar NO existe");

            if (!objeto.CUIT.Equals(valorCUITAnterior) && _abmc.Existe(objeto))
                throw new NegocioException("El CUIT que intenta modificar ya existe ingresado.");

            _abmc.Modificar(objeto, valorCUITAnterior);

            _logger.GenerarLog(objeto, Util.Log_Modificacion);
        }
        public void Eliminar(Cliente objeto)
        {            
            if (_abmc.TieneObjetosDependientes(objeto))
                throw new NegocioException("El cliente que intenta eliminar tiene operaciones asociadas.\nNo puede eliminar.");
            _abmc.Eliminar(objeto);

            _logger.GenerarLog(objeto, Util.Log_Baja);
        }
     
        private IList<VistaCliente> ConstruirVista(IList<Cliente> source)
        {
            IList<VistaCliente> lista = new List<VistaCliente>();
            VistaCliente destItem;
            foreach (var sourceItem in source)
            {
                destItem = new VistaCliente();
                
                destItem.CUIT = sourceItem.CUIT;
                destItem.Nombre = sourceItem.Nombre;
                destItem.Apellido = sourceItem.Apellido;
                destItem.Direccion = sourceItem.Direccion;
                destItem.Localidad = sourceItem.Localidad;
                destItem.CodigoPostal = sourceItem.CodigoPostal;
                destItem.Provincia = sourceItem.Provincia;

                lista.Add(destItem);
            }
            return lista;
        }
    }
}
