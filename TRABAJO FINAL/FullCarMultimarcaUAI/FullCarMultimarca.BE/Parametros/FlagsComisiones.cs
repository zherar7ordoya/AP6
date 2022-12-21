using FullCarMultimarca.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.BE.Parametros
{
    /// <summary>
    /// Parametros de la gestión de comisiones
    /// </summary>
    public class FlagsComisiones
    {
        /// <summary>
        /// Parametros a nivel global de la empresa
        /// </summary>
        public FlagsComisiones()
        {

        }      


        //Gestion de Comisiones
        public decimal PorcentajeComisionN1 { get; set; }
        public int CantidadMinimaN2 { get; set; }
        public decimal PorcentajeComisionN2 { get; set; }
        public int CantidadMinimaN3 { get; set; }
        public decimal PorcentajeComisionN3 { get; set; }
        public decimal ImportePremioVolumen { get; set; }

        public override string ToString()
        {
            return "Parámetros Comisiones";
        }
    }
}
