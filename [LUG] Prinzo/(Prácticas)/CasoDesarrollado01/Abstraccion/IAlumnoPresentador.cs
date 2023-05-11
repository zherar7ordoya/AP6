using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoDesarrollado01.Abstraccion
{
    interface IAlumnoPresentador
    {
        void Calcular(object sender, EventArgs e);
        void Limpiar(object sender, EventArgs e);
        void Salir(object sender, EventArgs e);
    }
}
