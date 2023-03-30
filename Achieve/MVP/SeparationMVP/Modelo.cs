using System;

namespace SeparationMVP
{
    internal class Modelo
    {
        public string    Name           { get; set; }
        public string    Priority       { get; set; }
        public DateTime? StartDate      { get; set; }
        public DateTime? DueDate        { get; set; }
        public bool      Completed      { get; set; }
        public DateTime? CompletionDate { get; set; }
    }
}
