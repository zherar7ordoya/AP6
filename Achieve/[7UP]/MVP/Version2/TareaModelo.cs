using System;

namespace Version2
{
    public class TareaModelo: ITareaModelo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Prioridad { get; set; }
        public DateTime? FechaComienzo { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public DateTime? FechaTerminacion { get; set; }
        public bool Completada { get; set; }
    }
}
