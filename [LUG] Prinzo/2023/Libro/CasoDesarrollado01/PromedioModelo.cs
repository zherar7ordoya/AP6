using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoDesarrollado01
{
    /// <summary>
    ///             VISTA (View)            => GUI
    ///             PRESENTADOR(Presenter)  => BLL
    ///             MODELO(Model)           => DAT
    /// </summary>
    public class PromedioModelo : IPromedioModelo
    {
        public decimal Promedio { get; private set; }

        public void Promediar(List<decimal> notas)
        {
            Promedio = notas.Average();
        }

        public void Limpiar()
        {
            Promedio = 0;
        }
    }
}
