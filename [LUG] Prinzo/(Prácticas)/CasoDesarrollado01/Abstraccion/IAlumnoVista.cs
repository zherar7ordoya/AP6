using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoDesarrollado01.Abstraccion
{
    interface IAlumnoVista
    {
        event EventHandler Calcular;
        event EventHandler Limpiar;
        event EventHandler Salir;

        string Alumno { get; set; }
        string Promedio { get; set; }
        string Baja { get; set; }
        string Condicion { get; set; }
        string Nota1 { get; set; }
        string Nota2 { get; set; }
        string Nota3 { get; set; }
        string Nota4 { get; set; }
    }
}
