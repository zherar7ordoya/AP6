using FullCarMultimarca.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
