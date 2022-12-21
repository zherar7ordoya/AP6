using FullCarMultimarca.BE;
using FullCarMultimarca.BE.Seguridad;
using FullCarMultimarca.Servicios.Excepciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FullCarMultimarca.MPP
{
    /// <summary>
    /// Clase util estática que contiene métodos de uso común
    /// </summary>
    internal static class Util
    {       

        #region METODOS SOPORTE CONSULTA

        internal static string AgregarOperadorAND(string expresion)
        {
            return !string.IsNullOrWhiteSpace(expresion) ? " AND " : "";
        }
        internal static string AgregarOperadorOR(string expresion)
        {
            return !string.IsNullOrWhiteSpace(expresion) ? " OR " : "";
        }
        

        internal static string STR_ERROR_ELIMINAR_FK = "No puede realizar esta acción ya que hay otros elementos que dependen de él." + System.Environment.NewLine;
        internal static Exception WrapException(Exception ex)
        {
            if ((ex is InvalidConstraintException))//violacion de foreign key
            {
                return new RestriccionFKException(STR_ERROR_ELIMINAR_FK, (ex as DataException));
            }
            if((ex is XmlException)) //tomamos un error en la lectura del XML como base corrupta
            {
                return new BaseCorruptaException();
            }

            return ex;
        }
        internal static string PrepararStringConsulta(string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return texto;
            }
            texto = texto.Replace("*", "%");
            return texto.Replace("'", "''");
        }

        internal static string ObtenerCampoDesdePropiedad(IDictionary<string, string> diccionarioTraduccion, string propiedad)
        {
            try
            {
                string campo = null;
                if (diccionarioTraduccion.ContainsKey(propiedad))
                {
                    campo = diccionarioTraduccion[propiedad];
                }
                else
                    throw new ArgumentException("El valor de la propiedad no fue encontrado. No se puede proceder.");
                return campo;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

      

        #endregion

    }
}
