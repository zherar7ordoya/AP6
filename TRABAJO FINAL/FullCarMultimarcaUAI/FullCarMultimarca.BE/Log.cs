using FullCarMultimarca.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
