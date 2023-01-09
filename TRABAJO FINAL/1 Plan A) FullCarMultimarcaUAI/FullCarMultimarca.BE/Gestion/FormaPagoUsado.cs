using FullCarMultimarca.Abstracciones;

namespace FullCarMultimarca.BE.Gestion
{
    public sealed class FormaPagoUsado : FormaPago, IArancelable
    {
        public FormaPagoUsado() : base()
        {

        }

        public decimal ArancelGasto { get; set; }
       
    }
}
