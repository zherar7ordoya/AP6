using System;
using System.Collections.Generic;

namespace SeparationMVP
{
    internal class Presentador
    {
        private readonly IIntegrador vista;
        private List<Modelo> tareas;

        // (primitive) maintenance of state:
        private int posicion = 0;
        private bool nuevo = true;


        public Presentador(IIntegrador vista)
        {
            this.vista = vista;
            Initialize();
        }


        private void Initialize()
        {
            tareas             = new List<Modelo>();
            vista.SaveTask    += Save;
            vista.NewTask     += New;
            vista.PrevTask    += Previous;
            vista.NextTask    += Next;
            BlankTask();
            vista.StatusChange = "Ready";
        }


        private void Save(object sender, EventArgs e)
        {
            Modelo tarea;
            if (this.nuevo)
            {
                tarea = new Modelo();
            }
            else
            {
                // editing an existing task
                tarea = tareas[posicion];
            }
            tarea.Name = vista.Nombre;
            tarea.Priority = vista.Prioridad;
            tarea.StartDate = vista.Desde;
            tarea.DueDate = vista.Hasta;
            tarea.Completed = vista.Completado;
            tarea.CompletionDate = vista.Finalizado;
            if (this.nuevo)
            {
                tareas.Add(tarea);
                this.nuevo = false;
                posicion = tareas.Count - 1;
                // new items are added at the end
            }
            vista.isDirty = false;
            vista.StatusChange = "Task saved";
        }


        private void New(object sender, EventArgs e)
        {
            BlankTask();
            this.nuevo = true;
            vista.isDirty = false;
            posicion = tareas.Count;
            vista.StatusChange = "New task";
        }


        private void BlankTask()
        {
            vista.Nombre       = String.Empty;
            vista.Prioridad       = "Low";
            vista.Desde      = null;
            vista.Hasta        = null;
            vista.Completado      = false;
            vista.Finalizado = null;
        }


        private void Previous(object sender, EventArgs e)
        {
            if (posicion > 0)
            {
                posicion--;
                loadTask(tareas[posicion]);
                vista.isDirty = false;
                vista.StatusChange = "Task: " + (posicion + 1);
            }
            else
            {
                vista.StatusChange = "No previous task";
            }
        }

        private void Next(object sender, EventArgs e)
        {
            if (posicion < tareas.Count - 1)
            {
                posicion++;
                loadTask(tareas[posicion]);
                vista.isDirty = false;
                vista.StatusChange = "Task: " + (posicion + 1);
            }
            else
            {
                vista.StatusChange = "No next task";
            }
        }


        private void loadTask(Modelo task)
        {
            vista.Nombre = task.Name;
            vista.Prioridad = task.Priority;
            vista.Desde = task.StartDate;
            vista.Hasta = task.DueDate;
            vista.Completado = task.Completed;
            vista.Finalizado = task.CompletionDate;
            this.nuevo = false;
        }
    }
}
