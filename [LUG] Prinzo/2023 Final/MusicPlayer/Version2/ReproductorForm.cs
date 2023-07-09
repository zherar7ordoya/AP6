using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;


/**
 * Developer/s: Gerardo Tordoya
 * Description: Basic Music Player
 * Create Date: 2023-07-08
 * Update Date: XXXX-XX-XX
 * Forked From: https://youtu.be/QJkFfKDhz5o
 */


namespace MusicPlayer
{
    public partial class ReproductorForm : Form, IReproductorVista
    {
        private ReproductorMusica reproductorMusica;

        public ReproductorForm()
        {
            InitializeComponent();
            VolumenBarra.Value = 50;
            reproductorMusica = new ReproductorMusica();
        }

        // Implementar métodos de la interfaz IReproductorVista

        public void ActualizarListaPistas(string[] pistas)
        {
            PistasLista.Items.Clear();
            foreach (var pista in pistas)
            {
                PistasLista.Items.Add(pista);
            }
        }

        public void MostrarInformacionPista(string ruta)
        {
            Reproductor.URL = ruta;
            Reproductor.Ctlcontrols.play();
            try
            {
                var archivo = TagLib.File.Create(ruta);
                var bin = (byte[])(archivo.Tag.Pictures[0].Data.Data);
                CubiertaPic.Image = Image.FromStream(new MemoryStream(bin));
            }
            catch
            {
                CubiertaPic.Image = null;
            }
        }

        public void ActualizarProgreso(int posicionActual, int duracion)
        {
            PistaProgresoBarra.Maximum = duracion;
            PistaProgresoBarra.Value = posicionActual;

            try
            {
                PistaProgresoEtiqueta.Text = TimeSpan.FromSeconds(posicionActual).ToString();
                PistaDuracionEtiqueta.Text = TimeSpan.FromSeconds(duracion).ToString();
            }
            catch { }
        }

        // Eventos y métodos relacionados con la vista

        private void CargarBoton_Click(object sender, EventArgs e)
        {
            OpenFileDialog selector = new OpenFileDialog
            {
                Multiselect = true
            };

            if (selector.ShowDialog() == DialogResult.OK)
            {
                string[] paths = selector.FileNames;
                reproductorMusica.CargarArchivos(paths);
                ActualizarListaPistas(reproductorMusica.ObtenerArchivos());
            }
        }

        private void PistasLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = PistasLista.SelectedIndex;
            if (index >= 0 && index < reproductorMusica.ObtenerArchivos().Length)
            {
                reproductorMusica.ReproducirPista(this, index);
            }
        }

        // Otros eventos y métodos del formulario
        private void AnteriorBoton_Click(object sender, EventArgs e)
        {
            if (PistasLista.SelectedIndex > 0)
            {
                PistasLista.SelectedIndex--;
            }
        }
        private void SiguienteBoton_Click(object sender, EventArgs e)
        {
            if (PistasLista.SelectedIndex < PistasLista.Items.Count - 1)
            {
                PistasLista.SelectedIndex++;
            }
        }
        private void ReproducirBoton_Click(object sender, EventArgs e)
        {
            Reproductor.Ctlcontrols.play();
        }
        private void PausarBoton_Click(object sender, EventArgs e)
        {
            Reproductor.Ctlcontrols.pause();
        }
        private void DetenerBoton_Click(object sender, EventArgs e)
        {
            Reproductor.Ctlcontrols.stop();
            PistaProgresoBarra.Value = 0;
        }
        private void PistaProgresoBarra_MouseDown(object sender, MouseEventArgs e)
        {
            Reproductor.Ctlcontrols.currentPosition = Reproductor.currentMedia.duration * e.X / PistaProgresoBarra.Width;
        }
        private void VolumenBarra_Scroll(object sender, EventArgs e)
        {
            Reproductor.settings.volume = VolumenBarra.Value;
            NivelVolumenEtiqueta.Text = string.Format("{0}%", VolumenBarra.Value.ToString());
        }
        private void Temporizador_Tick(object sender, EventArgs e)
        {
            if (Reproductor.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                PistaProgresoBarra.Maximum = (int)Reproductor.Ctlcontrols.currentItem.duration;
                PistaProgresoBarra.Value = (int)Reproductor.Ctlcontrols.currentPosition;

                try
                {
                    PistaProgresoEtiqueta.Text = Reproductor.Ctlcontrols.currentPositionString;
                    PistaDuracionEtiqueta.Text = Reproductor.Ctlcontrols.currentItem.durationString;
                }
                catch { }
            }
        }
    }
}
