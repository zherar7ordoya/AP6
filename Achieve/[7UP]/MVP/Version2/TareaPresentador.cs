using System;
using System.Collections.Generic;

namespace Version2
{
    public class TareaPresentador
    {
        private readonly ITareaVista _tarea;
        private List<TareaModelo> _tareas;

        private int _posicion = 0;
        private bool _nueva = true;


        public TareaPresentador(ITareaVista tarea)
        {
            _tarea = tarea;
            Inicializar();
        }

        private void Inicializar()
        {
            _tareas = new List<TareaModelo>();
            _tarea.NuevaTarea += NuevaTarea;
            _tarea.GuardarTarea += GuardarTarea;
            _tarea.TareaAnterior += TareaAnterior;
            _tarea.TareaSiguiente += TareaSiguiente;
            VaciarTarea();
            _tarea.Estado = "Listo";
        }

        // Métodos auxiliares
        private void VaciarTarea()
        {
            _tarea.Nombre = string.Empty;
            _tarea.Prioridad = "Baja";
            _tarea.FechaComienzo = null;
            _tarea.FechaVencimiento = null;
            _tarea.Completada = false;
            _tarea.FechaTerminacion = null;
        }

        private void CargarTarea(TareaModelo tarea)
        {
            _tarea.Nombre = tarea.Nombre;
            _tarea.Prioridad = tarea.Prioridad;
            _tarea.FechaComienzo = tarea.FechaComienzo;
            _tarea.FechaVencimiento = tarea.FechaVencimiento;
            _tarea.Completada = tarea.Completada;
            _tarea.FechaTerminacion = tarea.FechaTerminacion;
            _nueva = false;
        }


        // Métodos principales
        private void NuevaTarea(object sender, EventArgs e)
        {
            VaciarTarea();
            _nueva = true;
            _tarea.Cambiado = false;
            _posicion = _tareas.Count;
            _tarea.Estado = "Nueva tarea";
        }

        private void GuardarTarea(object sender, EventArgs e)
        {
            TareaModelo tarea;

            if (_nueva) tarea = new TareaModelo();
            else { tarea = _tareas[_posicion]; }

            tarea.Nombre = _tarea.Nombre;
            tarea.Prioridad = _tarea.Prioridad;
            tarea.FechaComienzo = _tarea.FechaComienzo;
            tarea.FechaVencimiento = _tarea.FechaVencimiento;
            tarea.Completada = _tarea.Completada;
            tarea.FechaTerminacion = _tarea.FechaTerminacion;

            if (_nueva)
            {
                _tareas.Add(tarea);
                _nueva = false;
                _posicion = _tareas.Count - 1;
            }
            _tarea.Cambiado = false;
            _tarea.Estado = "Tarea guardada";
        }

        private void TareaAnterior(object sender, EventArgs e)
        {
            if (_posicion > 0)
            {
                _posicion--;
                CargarTarea(_tareas[_posicion]);
                _tarea.Cambiado = false;
                _tarea.Estado = $"Tarea: {_posicion + 1}";
            }
            else { _tarea.Estado = "No hay tarea previa"; }
        }

        private void TareaSiguiente(object sender, EventArgs e)
        {
            if (_posicion < _tareas.Count - 1)
            {
                _posicion++;
                CargarTarea(_tareas[_posicion]);
                _tarea.Cambiado = false;
                _tarea.Estado = $"Tarea: {_posicion + 1}";
            }
            else { _tarea.Estado = "No hay tarea siguiente"; }
        }
    }
}
