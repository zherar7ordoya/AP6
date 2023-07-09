using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class ReproductorMusica
    {
        private string[] rutas;
        private string[] archivos;

        public void CargarArchivos(string[] paths)
        {
            archivos = paths.Select(Path.GetFileName).ToArray();
            rutas = paths;
        }

        public string[] ObtenerArchivos()
        {
            return archivos;
        }

        public void ReproducirPista(ReproductorForm formulario, int index)
        {
            // Lógica para reproducir la pista en la posición 'index'
            formulario.Reproductor.URL = rutas[formulario.PistasLista.SelectedIndex];
            formulario.Reproductor.Ctlcontrols.play();
            try
            {
                var archivo = TagLib.File.Create(rutas[formulario.PistasLista.SelectedIndex]);
                var bin = (byte[])(archivo.Tag.Pictures[0].Data.Data);
                formulario.CubiertaPic.Image = Image.FromStream(new MemoryStream(bin));
            }
            catch { formulario.CubiertaPic.Image = null; }

        }

        // Otros métodos relacionados con la reproducción de música
    }
}
