using System;

namespace SeparationMVP
{
    /**
     * The model is usually very simple and in our case will be a single class
     * that has properties that we want to store. We will store our data in a
     * (non-persistent) List<> of this type. In a fuller example there will be
     * a database (or other persistent storage) and the model would reflect
     * those tables and fields that the application can work with.
     */
    public class TareaModelo
    {
        public string    Name           { get; set; }
        public string    Priority       { get; set; }
        public DateTime? StartDate      { get; set; }
        public DateTime? DueDate        { get; set; }
        public bool      Completed      { get; set; }
        public DateTime? CompletionDate { get; set; }
    }
}
