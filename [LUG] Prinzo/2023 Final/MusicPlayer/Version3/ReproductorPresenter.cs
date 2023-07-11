using System;
using System.Windows.Forms;

using AxWMPLib;

namespace MusicPlayer
{
    /// <summary>
    /// La clase "ReproductorPresenter" se encarga de la lógica de
    /// presentación y comunicación entre la vista (formulario) y el modelo
    /// (reproductor de música).
    /// </summary>
    public class ReproductorPresenter
    {
        private readonly IReproductorView _view;
        private readonly ReproductorModel _model;

        public ReproductorPresenter(IReproductorView view)
        {
            _view = view;
            _model = new ReproductorModel();

            // Suscribirse a los eventos de la Vista
            _view.AnteriorBotonClick += AnteriorBoton_Click;
            _view.SiguienteBotonClick += SiguienteBoton_Click;
            _view.ReproducirBotonClick += ReproducirBoton_Click;
            _view.PausarBotonClick += PausarBoton_Click;
            _view.DetenerBotonClick += DetenerBoton_Click;
            _view.CargarBotonClick += CargarBoton_Click;
            _view.PistasListaSelectedIndexChanged += PistasLista_SelectedIndexChanged;
            _view.VolumenBarraScroll += VolumenBarra_Scroll;
            _view.PistaProgresoBarraMouseDown += PistaProgresoBarra_MouseDown;
            _view.TemporizadorTick += Temporizador_Tick;
        }

        // Implementar los métodos de eventos para la lógica de negocio
        private void AnteriorBoton_Click(object sender, EventArgs e)
        {
            _view.SeleccionarPistaAnterior();
        }

        private void SiguienteBoton_Click(object sender, EventArgs e)
        {
            _view.SeleccionarPistaSiguiente();
        }

        private void ReproducirBoton_Click(object sender, EventArgs e)
        {
            _model.Reproducir();
        }

        private void PausarBoton_Click(object sender, EventArgs e)
        {
            _model.Pausar();
        }

        private void DetenerBoton_Click(object sender, EventArgs e)
        {
            _model.Detener();
            _view.RestablecerProgresoPista();
        }

        private void CargarBoton_Click(object sender, EventArgs e)
        {
            var archivos = _view.SeleccionarArchivos();

            if (archivos != null && archivos.Length > 0)
            {
                _model.CargarPistas(archivos);
                _view.ActualizarListaPistas(_model.ObtenerNombresPistas());
            }
        }

        private void PistasLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            var indiceSeleccionado = _view.ObtenerIndicePistaSeleccionada();

            if (indiceSeleccionado >= 0 && indiceSeleccionado < _model.NumeroPistas)
            {
                _model.SeleccionarPista(indiceSeleccionado);
                _view.ReproducirPista(_model.ObtenerRutaPistaSeleccionada());

                try
                {
                    var imagen = _model.ObtenerImagenPistaSeleccionada();
                    _view.MostrarImagenCubierta(imagen);
                }
                catch
                {
                    _view.MostrarImagenCubierta(null);
                }
            }
        }

        private void VolumenBarra_Scroll(object sender, EventArgs e)
        {
            var volumen = _view.ObtenerVolumen();
            _model.AjustarVolumen(volumen);
            _view.ActualizarEtiquetaVolumen(volumen);
        }

        private void PistaProgresoBarra_MouseDown(object sender, MouseEventArgs e)
        {
            var posicion = _view.CalcularPosicionPista(e.X);
            _model.CambiarPosicionPista(posicion);
        }

        private void Temporizador_Tick(object sender, EventArgs e)
        {
            if (_model.EstaReproduciendo)
            {
                var duracionActual = _model.ObtenerDuracionActual();
                var duracionTotal = _model.ObtenerDuracionTotal();

                _view.ActualizarProgresoPista(duracionActual, duracionTotal);

                try
                {
                    var posicionActual = _model.ObtenerPosicionActual();
                    var duracionActualString = _model.ObtenerDuracionActualString();

                    _view.ActualizarEtiquetasPista(posicionActual, duracionActualString);
                }
                catch
                {
                    // Manejar errores al obtener la posición actual y la duración actual
                }
            }
        }
    }
}
