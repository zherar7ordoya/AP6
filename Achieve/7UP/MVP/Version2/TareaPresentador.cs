using System;
using System.Collections.Generic;

namespace Version2
{
    public class TareaPresentador
    {
        private readonly ITareaVista _vista;
        private List<TareaModelo> _tareas;

        private int _posicion = 0;
        private bool _nueva = true;


        public TareaPresentador(ITareaVista vista)
        {
            _vista = vista;
            Inicializar();
        }

        private void Inicializar()
        {
            _tareas = new List<TareaModelo>();
            _vista.NuevaTarea += NuevaTarea;
            _vista.GuardarTarea += GuardarTarea;
            _vista.TareaAnterior += TareaAnterior;
            _vista.TareaSiguiente += TareaSiguiente;
            LimpiarVista();
            _vista.Estado = "Listo";
        }

        // Métodos auxiliares
        private void LimpiarVista()
        {
            _vista.Nombre = string.Empty;
            _vista.Prioridad = "Alta";
            _vista.FechaComienzo = null;
            _vista.FechaVencimiento = null;
            _vista.Completada = false;
            _vista.FechaTerminacion = null;
        }

        private void CargarTarea(TareaModelo tarea)
        {
            _vista.Nombre = tarea.Nombre;
            _vista.Prioridad = tarea.Prioridad;
            _vista.FechaComienzo = tarea.FechaComienzo;
            _vista.FechaVencimiento = tarea.FechaVencimiento;
            _vista.Completada = tarea.Completada;
            _vista.FechaTerminacion = tarea.FechaTerminacion;
            _nueva = false;
        }


        // Métodos principales
        private void NuevaTarea(object sender, EventArgs e)
        {
            LimpiarVista();
            _nueva = true;
            _vista.Cambiado = false;
            _posicion = _tareas.Count;
            _vista.Estado = "Nueva tarea";
        }

        private void GuardarTarea(object sender, EventArgs e)
        {
            TareaModelo tarea;

            if (_nueva) tarea = new TareaModelo();
            else { tarea = _tareas[_posicion]; }

            tarea.Nombre = _vista.Nombre;
            tarea.Prioridad = _vista.Prioridad;
            tarea.FechaComienzo = _vista.FechaComienzo;
            tarea.FechaVencimiento = _vista.FechaVencimiento;
            tarea.Completada = _vista.Completada;
            tarea.FechaTerminacion = _vista.FechaTerminacion;

            if (_nueva)
            {
                _tareas.Add(tarea);
                _nueva = false;
                _posicion = _tareas.Count - 1;
            }
            _vista.Cambiado = false;
            _vista.Estado = "Tarea guardada";
        }

        private void TareaAnterior(object sender, EventArgs e)
        {
            if (_posicion > 0)
            {
                _posicion--;
                CargarTarea(_tareas[_posicion]);
                _vista.Cambiado = false;
                _vista.Estado = $"Tarea: {_posicion + 1}";
            }
            else { _vista.Estado = "No hay tarea previa"; }
        }

        private void TareaSiguiente(object sender, EventArgs e)
        {
            if (_posicion < _tareas.Count - 1)
            {
                _posicion++;
                CargarTarea(_tareas[_posicion]);
                _vista.Cambiado = false;
                _vista.Estado = $"Tarea: {_posicion + 1}";
            }
            else { _vista.Estado = "No hay tarea siguiente"; }
        }
    }
}
