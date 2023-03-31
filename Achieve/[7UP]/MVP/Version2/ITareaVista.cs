using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version2
{
    public interface ITareaVista : ITareaModelo
    {
        string Estado { set; }
        bool Cambiado { get; set; }

        event EventHandler<EventArgs> AgregarTarea;
        event EventHandler<EventArgs> GuardarTarea;
        event EventHandler<EventArgs> TareaAnterior;
        event EventHandler<EventArgs> TareaSiguiente;
    }
}
