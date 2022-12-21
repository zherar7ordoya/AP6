using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCarMultimarca.Abstracciones
{
    /// <summary>
    /// Interfaz que expone arancel de gasto
    /// </summary>
    public interface IArancelable
    {

        decimal ArancelGasto { get; set; }       

    }
}
