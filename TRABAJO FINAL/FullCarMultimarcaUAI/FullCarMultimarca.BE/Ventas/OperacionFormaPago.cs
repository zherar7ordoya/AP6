using FullCarMultimarca.BE.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.BE.Ventas
{
    public class OperacionFormaPago
    {
        public OperacionFormaPago(Operacion ope, FormaPago fPago)
        {
            Operacion = ope;
            FormaPago = fPago;
            Modificable = true;
        }
        ~OperacionFormaPago()
        {

        }

        
        public Operacion Operacion { get; set; }        
        public FormaPago FormaPago { get; set; }        
        public bool Modificable { get; set; }        
        public decimal ArancelGasto { get; set; }        
        public decimal Importe { get; set; }

        public override string ToString()
        {
            return $"{FormaPago}";
        }
        public override bool Equals(object obj)
        {
            if (this.FormaPago == null || this.Operacion == null)
                return false;
            else if (obj == null || !(obj is OperacionFormaPago))
                return false;
            return this.FormaPago.Equals(((OperacionFormaPago)obj).FormaPago);
        }
        public override int GetHashCode()
        {
            return FormaPago != null ? FormaPago.GetHashCode() : base.GetHashCode();
        }
    }
}
