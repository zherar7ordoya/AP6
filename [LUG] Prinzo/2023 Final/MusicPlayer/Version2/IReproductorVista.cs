using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public interface IReproductorVista
    {
        void ActualizarListaPistas(string[] pistas);
        void MostrarInformacionPista(string ruta);
        void ActualizarProgreso(int posicionActual, int duracion);
        // Otros métodos de la interfaz de la vista
    }
}
