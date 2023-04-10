using Abstract;

using Logic;

using Model;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    public class ClientePresentador
    {
        private readonly IClienteVista _cliente;
        private List<IClienteModelo> _clientes;

        private int _posicion = 0;
        private bool _nueva = true;

        private readonly ClienteLogica _logica = new ClienteLogica();

        public ClientePresentador(IClienteVista cliente)
        {
            _cliente = cliente;
            Inicializar();
        }

        private void Inicializar()
        {
            _clientes = new List<IClienteModelo>();

            //_cliente.GetAllClientes += GetAllClientes;
            _cliente.GetCliente += GetCliente;
            _cliente.AddCliente += AddCliente;
            _cliente.RemoveCliente += RemoveCliente;
            _cliente.UpdateCliente += UpdateCliente;

            LimpiarCliente();
            _cliente.BarraEstado = "Listo";
        }

        // Métodos auxiliares
        private void LimpiarCliente()
        {
            _cliente.Id = 0;
            _cliente.Nombre = string.Empty;
            _cliente.FechaAlta = DateTime.Now;
            _cliente.Activo = false;
        }

        private void CargarTarea(IClienteModelo cliente)
        {
            _cliente.Id = cliente.Id;
            _cliente.Nombre = cliente.Nombre;
            _cliente.FechaAlta = cliente.FechaAlta;
            _cliente.Activo = cliente.Activo;
            _nueva = false;
        }

        public DataTable CargarClientes()
        {
            return _logica.GetAll();
        }

        // Métodos principales
        private DataTable GetAllClientes(object sender, EventArgs e)
        {
            return _logica.GetAll();
        }


        private void AddCliente(object sender, EventArgs e)
        {
            //LimpiarCliente();
            //_nueva = true;
            //_cliente.Cambiado = false;
            //_posicion = _clientes.Count;
            //_cliente.Estado = "Nueva tarea";
        }

        private void GetCliente(object sender, EventArgs e)
        {
            //TareaModelo tarea;

            //if (_nueva) tarea = new TareaModelo();
            //else { tarea = _clientes[_posicion]; }

            //tarea.Nombre = _cliente.Nombre;
            //tarea.Prioridad = _cliente.Prioridad;
            //tarea.FechaComienzo = _cliente.FechaComienzo;
            //tarea.FechaVencimiento = _cliente.FechaVencimiento;
            //tarea.Completada = _cliente.Completada;
            //tarea.FechaTerminacion = _cliente.FechaTerminacion;

            //if (_nueva)
            //{
            //    _clientes.Add(tarea);
            //    _nueva = false;
            //    _posicion = _clientes.Count - 1;
            //}
            //_cliente.Cambiado = false;
            //_cliente.Estado = "Tarea guardada";
        }

        private void UpdateCliente(object sender, EventArgs e)
        {
            //if (_posicion > 0)
            //{
            //    _posicion--;
            //    CargarTarea(_clientes[_posicion]);
            //    _cliente.Cambiado = false;
            //    _cliente.Estado = $"Tarea: {_posicion + 1}";
            //}
            //else { _cliente.Estado = "No hay tarea previa"; }
        }

        private void RemoveCliente(object sender, EventArgs e)
        {
            //if (_posicion < _clientes.Count - 1)
            //{
            //    _posicion++;
            //    CargarTarea(_clientes[_posicion]);
            //    _cliente.Cambiado = false;
            //    _cliente.Estado = $"Tarea: {_posicion + 1}";
            //}
            //else { _cliente.Estado = "No hay tarea siguiente"; }
        }

    }
}
