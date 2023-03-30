using System;

namespace SeparationMVP
{
    public interface ITarea
    {
        string Nombre { get; set; }
        string Prioridad { get; set; }
        DateTime? FechaInicio { get; set; }
        DateTime? FechaVencimiento { get; set; }
        DateTime? FechaCompletado { get; set; }
        bool Completado { get; set; }

        // communication/messaging
        string StatusChange { set; }

        /// <summary>
        /// The PRESENTER changes it to True when a task has just been saved,
        /// or a different one loaded. The VIEW changes it to False as soon as
        /// one of the control's-values has been changed.
        /// </summary>
        bool IsDirty { get; set; }

        event EventHandler<EventArgs> SaveTask;
        event EventHandler<EventArgs> NewTask;
        event EventHandler<EventArgs> PrevTask;
        event EventHandler<EventArgs> NextTask;
    }
}
