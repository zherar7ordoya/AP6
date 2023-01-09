using System;

namespace FullCarMultimarca.BE
{
    /// <summary>
    /// Entidad de la auditoria que generan los objetos del sistema.
    /// </summary>
    public class Log 
    {
        public Log()
        {

        }                
        
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }        
        public string Operacion { get; set; }       

    }
}
