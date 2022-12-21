using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Vistas
{
    public class VistaImpresionOperacion
    {

        public VistaImpresionOperacion()
        { 
         
        }

        private IList<VistaImpresionOperacionFormaPago> _formasPago = new List<VistaImpresionOperacionFormaPago>();        

        public string NroOperacion { get; set; }
        public string Fecha { get; set; }
        public string Vendedor { get; set; }
        public string Cliente_Nombre { get; set; }
        public string Cliente_CUIT { get; set; }
        public string Unidad_Chasis { get; set; }
        public string Unidad_Modelo { get; set; }
        public string Unidad_Color { get; set; }
        public string PrecioUnidad { get; set; }
        public string TextoPatentamiento { get; set; }
        public string GastoGestoria { get; set; }
        public string GastoFinanciacion { get; set; }
        public string GastoUsados { get; set; }
        public string PrecioFinal { get; set; }
        public string TextoAutorizacion { get; set; }

        public IList<VistaImpresionOperacionFormaPago> ObtenerFormasPago()
        {
            return _formasPago;
        }    
        public void AgregarFormaPago(VistaImpresionOperacionFormaPago fpago)
        {
            _formasPago.Add(fpago);
        }

    }

    public class VistaImpresionOperacionFormaPago
    {
        public VistaImpresionOperacionFormaPago()
        {           
        }

        public string FormaPago { get; set; }
        public string Importe { get; set; }
    }

}
