﻿using FullCarMultimarca.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
