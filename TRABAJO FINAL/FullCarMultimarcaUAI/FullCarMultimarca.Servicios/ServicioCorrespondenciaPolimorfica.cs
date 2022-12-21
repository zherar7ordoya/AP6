using FullCarMultimarca.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Servicios
{
    /// <summary>
    /// Servicio utilizado para devolver una instancia del tipo de BLL subclase del TBLL genérico que implemente IEntidadCorrespondiente.  
    /// </summary>        
    public class ServicioCorrespondenciaPolimorfica<TBLL> : IServicioCorrespondenciaPolimorfica<TBLL>
    {
        public ServicioCorrespondenciaPolimorfica()
        {
           
            //Leemos todos los tipos del ensamblado de TBLL que son SubClase de este.
            var tipos =  typeof(TBLL)
                .Assembly
                .GetTypes()
                .Where(type => type.IsSubclassOf(typeof(TBLL)));

            if(tipos.Count() == 0)
                throw new ArgumentException($"El tipo genérico NO tiene subclases asociadas para generar la correspondencia.");

            //Por cada tipo obtenido
            foreach (var tipoBll in tipos)
            {               
                //Obtenemos sus interfaces que tienen generic del tipo IEntidadCorresponidnete y nos quedamos con el tipo genérico asociado.
                var t = tipoBll.GetInterfaces()
                    .Where(i => i.IsGenericType)
                    .Where(i => i.GetGenericTypeDefinition() == typeof(IEntidadCorrespondiente<>))
                    .Select(i => i.GetGenericArguments()).FirstOrDefault();

                //Si hay tipo generico, agregamos al diccionario.
                if (t != null)
                {
                    var tEntidad = t[0];
                    if (_correspondencias.ContainsKey(tEntidad))
                        throw new ArgumentException($"La entidad {tEntidad.Name} ya fue agregada como correspondencia.");

                    _correspondencias.Add(tEntidad, (TBLL)Activator.CreateInstance(tipoBll, true));
                }
            }

            if(_correspondencias.Count == 0)
                throw new ArgumentException("Ninguna de las subclases del tipo genérico indicado implementa la interfaz de correspondencia IEntidadCorrespondiente<T>");

        }        

        private IDictionary<Type, TBLL> _correspondencias = new Dictionary<Type, TBLL>();        

        //Metodo que expone la interfaz para obtener la instancia de BLL en base a la entidad recibida
        public TBLL ObtenerCorrespondencia(Type entidad)
        {
            if (_correspondencias.ContainsKey(entidad))
                return _correspondencias[entidad];
            else
                throw new ArgumentException($"No se encontró ningún tipo asociado a la entidad {nameof(entidad)}");
        }


    }
}
