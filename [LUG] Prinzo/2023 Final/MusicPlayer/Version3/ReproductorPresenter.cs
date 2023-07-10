namespace MusicPlayer
{
    /// <summary>
    /// La clase "ReproductorPresenter" se encarga de la lógica de
    /// presentación y comunicación entre la vista (formulario) y el modelo
    /// (reproductor de música).
    /// </summary>
    public class ReproductorPresenter
    {
        private IReproductorView _view;
        private ReproductorMusica _reproductor;

        public ReproductorPresenter(IReproductorView view)
        {
            _view = view;
            _reproductor = new ReproductorMusica();
        }

        public void CargarPistas(string[] rutas)
        {
            _reproductor.CargarPistas(rutas);
            _view.ActualizarPistas(_reproductor.ObtenerNombresPistas());
        }

        public void SeleccionarPista(int indice)
        {
            _reproductor.SeleccionarPista(indice);
            _view.ActualizarImagenCubierta(_reproductor.ObtenerImagenCubierta());
        }

        public void Reproducir()
        {
            _reproductor.Reproducir();
        }

        public void Pausar()
        {
            _reproductor.Pausar();
        }

        public void Detener()
        {
            _reproductor.Detener();
            _view.ActualizarProgresoPista(0, 0);
        }

        public void CambiarVolumen(int volumen)
        {
            _reproductor.CambiarVolumen(volumen);
        }

        public void CambiarPosicionPista(int posicion)
        {
            _reproductor.CambiarPosicionPista(posicion);
        }
    }
}
