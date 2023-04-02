using System;

namespace Version2
{
    public interface ITareaVista : ITareaModelo
    {
        string Estado { set; }
        bool Cambiado { get; set; }

        event EventHandler<EventArgs> NuevaTarea;
        event EventHandler<EventArgs> GuardarTarea;
        event EventHandler<EventArgs> TareaAnterior;
        event EventHandler<EventArgs> TareaSiguiente;
    }
}
