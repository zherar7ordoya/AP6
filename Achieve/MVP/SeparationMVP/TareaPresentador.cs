using System;
using System.Collections.Generic;

namespace SeparationMVP
{
    /**
     * The presenter does all the work: listening for events fired by the view
     * and synchronizing the data displayed in the view (via its properties)
     * with the data stored in the data-layer (via the model).
     */
    public class TareaPresentador
    {
        private readonly ITarea _tarea;
        private List<TareaModelo> _tareas;

        // (primitive) maintenance of state:
        private int _posicion = 0;
        private bool _nueva = true;


        public TareaPresentador(ITarea tarea)
        {
            _tarea = tarea;
            Initialize();
        }


        private void Initialize()
        {
            _tareas = new List<TareaModelo>();
            _tarea.SaveTask += Save;
            _tarea.NewTask += New;
            _tarea.PrevTask += Previous;
            _tarea.NextTask += Next;
            BlankTask();
            _tarea.StatusChange = "Ready";
        }


        private void Save(object sender, EventArgs e)
        {
            TareaModelo tarea;

            // Si no es nueva, estoy editando una tarea
            if (_nueva) tarea = new TareaModelo();
            else { tarea = _tareas[_posicion]; }

            tarea.Name = _tarea.Nombre;
            tarea.Priority = _tarea.Prioridad;
            tarea.StartDate = _tarea.FechaInicio;
            tarea.DueDate = _tarea.FechaVencimiento;
            tarea.Completed = _tarea.Completado;
            tarea.CompletionDate = _tarea.FechaCompletado;

            if (_nueva)
            {
                _tareas.Add(tarea);
                _nueva = false;

                // new items are added at the end
                _posicion = _tareas.Count - 1;
            }

            _tarea.IsDirty = false;
            _tarea.StatusChange = "Task saved";
        }


        private void New(object sender, EventArgs e)
        {
            BlankTask();
            _nueva = true;
            _tarea.IsDirty = false;
            _posicion = _tareas.Count;
            _tarea.StatusChange = "New task";
        }


        private void BlankTask()
        {
            _tarea.Nombre = string.Empty;
            _tarea.Prioridad = "Low";
            _tarea.FechaInicio = null;
            _tarea.FechaVencimiento = null;
            _tarea.Completado = false;
            _tarea.FechaCompletado = null;
        }


        private void Previous(object sender, EventArgs e)
        {
            if (_posicion > 0)
            {
                _posicion--;
                loadTask(_tareas[_posicion]);
                _tarea.IsDirty = false;
                _tarea.StatusChange = "Task: " + (_posicion + 1);
            }
            else            {                _tarea.StatusChange = "No previous task";            }
        }

        private void Next(object sender, EventArgs e)
        {
            if (_posicion < _tareas.Count - 1)
            {
                _posicion++;
                loadTask(_tareas[_posicion]);
                _tarea.IsDirty = false;
                _tarea.StatusChange = "Task: " + (_posicion + 1);
            }
            else             {                _tarea.StatusChange = "No next task";            }
        }


        private void loadTask(TareaModelo tarea)
        {
            _tarea.Nombre = tarea.Name;
            _tarea.Prioridad = tarea.Priority;
            _tarea.FechaInicio = tarea.StartDate;
            _tarea.FechaVencimiento = tarea.DueDate;
            _tarea.Completado = tarea.Completed;
            _tarea.FechaCompletado = tarea.CompletionDate;
            _nueva = false;
        }
    }
}
