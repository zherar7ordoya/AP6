using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    public interface ITelefonoModelo : IId, ICloneable
    {
        int ClienteId { get; set; }
        string Numero { get; set; }
        bool Activo { get; set; }
    }
}
