using System;

namespace Aplicativo
{
    public interface IOperacionVista
    {
        double Num1 { get; set; }
        double Num2 { get; set; }
        double Resultado { set; }

        // Ayuda-Memoria: los eventos que vaya a manipular en la vista los
        // tengo que definir aquí.
        event EventHandler Actualizar;
    }
}
