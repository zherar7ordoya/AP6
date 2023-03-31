using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version2
{
    public interface ITareaModelo : IId
    {
        string Nombre { get; set; }
        string Prioridad { get; set; }
        DateTime? FechaComienzo { get; set; }
        DateTime? FechaVencimiento { get; set; }
        bool Completada { get; set; }
        DateTime? FechaTerminacion { get; set; }
    }
}
