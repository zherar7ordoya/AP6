using FullCarMultimarca.Abstracciones;
using FullCarMultimarca.BE.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.BE.Parametros
{
    public class FlagsVentas
    {
        /// <summary>
        /// Parametros de la gestión de ventas de la empresa
        /// </summary>
        public FlagsVentas()
        {

        }

        //Gestion de Ventas
        public decimal PorcentajeCoberturaARecuperar { get; set; }
        public decimal PorcentajeGastoPatentamiento { get; set; }
        public FormaPagoContado FormaPagoContadoDefault { get; set; }
        public int DiasRetroactivoDeterminacionPauta { get; set; }
        public string DestinatariosNotificacionVencimientoOfertas { get; set; }
        public string DestinatariosNotificacionAutorizacionAPerdida { get; set; }
        public decimal TasaIVAModelosPickUp { get; set; }
        public decimal TasaIVAModelosResto { get; set; }


        public override string ToString()
        {
            return "Parámetros Ventas";
        }
    }
}
