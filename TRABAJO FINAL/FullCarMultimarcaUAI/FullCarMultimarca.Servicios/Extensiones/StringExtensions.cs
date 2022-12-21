using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Servicios.Extensiones
{
    public static class StringExtensions
    {

        /// <summary>
        /// Agerga a un string un Equals case insensitive y accent insensitive. En muchas situaciones del sistema son lo mismo
        /// </summary>        
        public static bool EqualsAICI(this string string1, string string2)
        {            
            int resu = String.Compare(string1, string2, 
                CultureInfo.CurrentCulture, 
                CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace);
            return resu == 0;
        }

        /// <summary>
        /// Dado un string que representa un nombre de propiedad y la clase que la contiene, devuelve el namespace completo de la clase más el nombre de la propiedad.
        /// Si la propiedad no existe en la clase se devuelve ArgumentException
        /// </summary>
        public static string ObtenerFullNameMasPropiedad<T>(this string nombrePropiedad) where T : class
        {
            try
            {
                var pInfo = typeof(T).GetProperty(nombrePropiedad);
                return $"{pInfo.DeclaringType.FullName}.{pInfo.Name}";
            }
            catch
            {
                throw new ArgumentException($"No se encontró la propiedad {nombrePropiedad} para la clase {typeof(T).Name}.");
            }
            
        }

    }
}
