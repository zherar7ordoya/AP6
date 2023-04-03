using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    public interface IClienteModelo : IId, ICloneable
    {
        string Nombre { get; set; }
        DateTime FechaAlta { get; set; }
        bool Activo { get; set; }
        List<ITelefonoModelo> Telefonos { get; set; }
    }
}
