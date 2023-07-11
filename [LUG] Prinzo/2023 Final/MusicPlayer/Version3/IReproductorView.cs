using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AxWMPLib;

namespace MusicPlayer
{
    /// <summary>
    /// La interfaz "IReproductorView" contiene métodos para actualizar la
    /// interfaz de usuario (Form) y manejar eventos del formulario.
    /// </summary>
    public interface IReproductorView
    {
        event EventHandler AnteriorBotonClick;
        event EventHandler SiguienteBotonClick;
        event EventHandler ReproducirBotonClick;
        event EventHandler PausarBotonClick;
        event EventHandler DetenerBotonClick;
        event EventHandler CargarBotonClick;
        event EventHandler PistasListaSelectedIndexChanged;
        event EventHandler VolumenBarraScroll;
        event MouseEventHandler PistaProgresoBarraMouseDown;
        event EventHandler TemporizadorTick;

        void SeleccionarPistaAnterior();
        void SeleccionarPistaSiguiente();
        void ReproducirPista(string ruta);
        void RestablecerProgresoPista();
        string[] SeleccionarArchivos();
        int ObtenerIndicePistaSeleccionada();
        void ActualizarListaPistas(string[] nombresPistas);
        void MostrarImagenCubierta(Image imagen);
        int ObtenerVolumen();
        void ActualizarEtiquetaVolumen(int volumen);
        int CalcularPosicionPista(int x);
        void ActualizarProgresoPista(int duracionActual, int duracionTotal);
        void ActualizarEtiquetasPista(int posicionActual, string duracionActualString);
    }

}
