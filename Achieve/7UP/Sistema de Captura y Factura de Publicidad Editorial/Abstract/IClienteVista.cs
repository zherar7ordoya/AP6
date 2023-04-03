using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    public interface IClienteVista : IClienteModelo
    {
        string BarraEstado { set; }
        bool CambioDetectado { get; set; }

        event EventHandler<EventArgs> GetAllClientes;
        event EventHandler<EventArgs> GetCliente;
        event EventHandler<EventArgs> AddCliente;
        event EventHandler<EventArgs> RemoveCliente;
        event EventHandler<EventArgs> UpdateCliente;
    }
}
