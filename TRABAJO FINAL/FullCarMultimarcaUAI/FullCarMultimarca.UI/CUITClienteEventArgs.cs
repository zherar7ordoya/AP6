using System;

namespace FullCarMultimarca.UI
{
    /// <summary>
    /// Argumento de Evento que transporta el CUIT de un cliente cuando se realiza una nueva alta. 
    /// 
    /// </summary>
    public class CUITClienteEventArgs : EventArgs
    {

        public CUITClienteEventArgs(string cuit)
        {
            CUIT = cuit;
        }

        public string CUIT { get; set; }
    }
}
