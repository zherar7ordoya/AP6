using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    /// <summary>
    /// La interfaz "IReproductorView" contiene métodos para actualizar la
    /// interfaz de usuario (Form) y manejar eventos del formulario.
    /// </summary>
    public interface IReproductorView
    {
        void ActualizarPistas(List<string> nombresPistas);
        void ActualizarImagenCubierta(Image imagen);
        void ActualizarProgresoPista(int duracion, int posicion);
    }
}
