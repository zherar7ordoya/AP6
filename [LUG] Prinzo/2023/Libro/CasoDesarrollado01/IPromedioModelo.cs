using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoDesarrollado01
{
    public interface IPromedioModelo
    {
        decimal Promedio { get; }
        void Promediar(List<decimal> notas);
        void Limpiar();
    }
}
