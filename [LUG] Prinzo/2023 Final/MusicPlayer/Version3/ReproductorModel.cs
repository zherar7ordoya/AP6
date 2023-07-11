using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WMPLib;
using AxWMPLib;

namespace MusicPlayer
{
    /// <summary>
    /// La clase "ReproductorMusica" encapsula la lógica de reproducción de
    /// música y gestiona el reproductor de Windows Media Player.
    /// </summary>
    public class ReproductorModel
    {
        private WMPLib.WindowsMediaPlayer _reproductor;
        private string[] _rutas;
        private TagLib.File[] _archivos;
        private int _pistaSeleccionada;

        public int NumeroPistas => _rutas.Length;
        //public bool EstaReproduciendo => _reproductor.playState == WMPLib.WMPPlayState.wmppsPlaying;

        public ReproductorModel()
        {
            _reproductor = new WMPLib.WindowsMediaPlayer();
            _pistaSeleccionada = -1;
        }

        public void CargarPistas(string[] rutas)
        {
            _rutas = rutas;
            _archivos = new TagLib.File[rutas.Length];

            for (int i = 0; i < rutas.Length; i++)
            {
                _archivos[i] = TagLib.File.Create(rutas[i]);
            }
        }

        public string[] ObtenerNombresPistas()
        {
            return _archivos.Select(file => file.Tag.Title).ToArray();
        }

        public void SeleccionarPista(int indice)
        {
            _pistaSeleccionada = indice;
        }

        public void Reproducir()
        {
            if (_pistaSeleccionada >= 0 && _pistaSeleccionada < _rutas.Length)
            {
                _reproductor.URL = _rutas[_pistaSeleccionada];
                _reproductor.controls.play();
            }
        }

        public void Pausar()
        {
            _reproductor.controls.pause();
        }

        public void Detener()
        {
            _reproductor.controls.stop();
        }

        public void AjustarVolumen(int volumen)
        {
            _reproductor.settings.volume = volumen;
        }

        public bool EstaReproduciendo
        {
            get { return _reproductor.playState == WMPLib.WMPPlayState.wmppsPlayingState; }
        }

        public double ObtenerDuracionActual()
        {
            return _reproductor.controls.currentPosition;
        }

        public double ObtenerDuracionTotal()
        {
            return _reproductor.currentMedia.duration;
        }

        public string ObtenerDuracionActualString()
        {
            return TimeSpan.FromSeconds(_reproductor.controls.currentPosition).ToString(@"mm\:ss");
        }

        public double ObtenerPosicionActual()
        {
            return _reproductor.controls.currentPosition;
        }


        public Image ObtenerImagenPistaSeleccionada()
        {
            var imagen = _archivos[_pistaSeleccionada].Tag.Pictures[0];
            var bin = (byte[])(imagen.Data.Data);
            return Image.FromStream(new MemoryStream(bin));
        }

        public string ObtenerRutaPistaSeleccionada()
        {
            return _rutas[_pistaSeleccionada];
        }

        public void CambiarPosicionPista(int posicion)
        {
            _reproductor.controls.currentPosition = posicion;
        }
    }
}
