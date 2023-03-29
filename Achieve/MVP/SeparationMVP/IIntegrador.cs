using System;

namespace SeparationMVP
{
    internal interface IIntegrador
    {
        string    Nombre     { get; set; }
        string    Prioridad  { get; set; }
        DateTime? Desde      { get; set; }
        DateTime? Hasta      { get; set; }
        bool      Completado { get; set; }
        DateTime? Finalizado { get; set; }

        // communication/messaging
        string StatusChange { set;      }
        bool   isDirty      { get; set; }

        event EventHandler<EventArgs> SaveTask;
        event EventHandler<EventArgs> NewTask;
        event EventHandler<EventArgs> PrevTask;
        event EventHandler<EventArgs> NextTask;
    }
}
