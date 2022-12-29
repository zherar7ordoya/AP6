using FullCarMultimarca.Abstracciones;

namespace FullCarMultimarca.BE.Gestion
{
    public sealed class FormaPagoCredito : FormaPago, IArancelable
    {
        public FormaPagoCredito() : base()
        {

        }

        public decimal ArancelGasto { get; set; }
       
    }
}
