using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    /// <summary>
    /// La clase "ReproductorMusica" encapsula la lógica de reproducción de
    /// música y gestiona el reproductor de Windows Media Player.
    /// </summary>
    public class ReproductorMusica
    {
        private WMPLib.WindowsMediaPlayer _reproductor;
        private string[] _rutasPistas;
        private List<string> _nombresPistas;
        private Image _imagenCubierta;

        public ReproductorMusica()
        {
            _reproductor = new WMPLib.WindowsMediaPlayer();
            _nombresPistas = new List<string>();
        }

        public void CargarPistas(string[] rutas)
        {
            _rutasPistas = rutas;
            _nombresPistas = _rutasPistas.Select(Path.GetFileName).ToList();
        }

        public List<string> ObtenerNombresPistas()
        {
            return _nombresPistas;
        }

        public void SeleccionarPista(int indice)
        {
            _reproductor.URL = _rutasPistas[indice];
            _reproductor.controls.play();
            try
            {
                var archivo = TagLib.File.Create(_rutasPistas[indice]);
                var bin = (byte[])(archivo.Tag.Pictures[0].Data.Data);
                _imagenCubierta = Image.FromStream(new MemoryStream(bin));
            }
            catch
            {
                _imagenCubierta = null;
            }
        }

        public Image ObtenerImagenCubierta()
        {
            return _imagenCubierta;
        }

        public void Reproducir()
        {
            _reproductor.controls.play();
        }

        public void Pausar()
        {
            _reproductor.controls.pause();
        }

        public void Detener()
        {
            _reproductor.controls.stop();
        }

        public void CambiarVolumen(int volumen)
        {
            _reproductor.settings.volume = volumen;
        }

        public void CambiarPosicionPista(int posicion)
        {
            _reproductor.controls.currentPosition = _reproductor.currentMedia.duration * posicion / 100;
        }
    }
}
