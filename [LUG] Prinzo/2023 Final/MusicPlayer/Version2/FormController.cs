using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MusicPlayer
{
    public class FormController
    {
        private ReproductorForm form;
        private MusicPlayer musicPlayer;

        public FormController(ReproductorForm form, MusicPlayer musicPlayer)
        {
            this.form = form;
            this.musicPlayer = musicPlayer;

            this.form.AnteriorBoton.Click += AnteriorBoton_Click;
            this.form.SiguienteBoton.Click += SiguienteBoton_Click;
            this.form.ReproducirBoton.Click += ReproducirBoton_Click;
            this.form.PausarBoton.Click += PausarBoton_Click;
            this.form.DetenerBoton.Click += DetenerBoton_Click;
            this.form.CargarBoton.Click += CargarBoton_Click;
            this.form.PistasLista.SelectedIndexChanged += PistasLista_SelectedIndexChanged;
            this.form.VolumenBarra.Scroll += VolumenBarra_Scroll;
            this.form.PistaProgresoBarra.MouseDown += PistaProgresoBarra_MouseDown;
            this.musicPlayer.TrackChanged += MusicPlayer_TrackChanged;
        }

        private void AnteriorBoton_Click(object sender, EventArgs e)
        {
            musicPlayer.Previous();
        }

        private void SiguienteBoton_Click(object sender, EventArgs e)
        {
            musicPlayer.Next();
        }

        private void ReproducirBoton_Click(object sender, EventArgs e)
        {
            musicPlayer.Play();
        }

        private void PausarBoton_Click(object sender, EventArgs e)
        {
            musicPlayer.Pause();
        }

        private void DetenerBoton_Click(object sender, EventArgs e)
        {
            musicPlayer.Stop();
        }

        private void CargarBoton_Click(object sender, EventArgs e)
        {
            musicPlayer.LoadFiles();
        }

        private void PistasLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (form.PistasLista.SelectedIndex >= 0)
            {
                var selectedPath = musicPlayer.GetSelectedPath();
                musicPlayer.Play();
                LoadCoverImage(selectedPath);
            }
        }

        private void VolumenBarra_Scroll(object sender, EventArgs e)
        {
            var volume = form.VolumenBarra.Value;
            musicPlayer.SetVolume(volume);
            form.NivelVolumenEtiqueta.Text = string.Format("{0}%", volume.ToString());
        }

        private void PistaProgresoBarra_MouseDown(object sender, MouseEventArgs e)
        {
            var position = musicPlayer.GetDuration() * e.X / form.PistaProgresoBarra.Width;
            musicPlayer.SetPosition(position);
        }

        private void MusicPlayer_TrackChanged(object sender, EventArgs e)
        {
            var currentPosition = musicPlayer.GetPosition();
            var duration = musicPlayer.GetDuration();

            form.PistaProgresoBarra.Maximum = duration;
            form.PistaProgresoBarra.Value = currentPosition;

            try
            {
                form.PistaProgresoEtiqueta.Text = TimeSpan.FromSeconds(currentPosition).ToString();
                form.PistaDuracionEtiqueta.Text = TimeSpan.FromSeconds(duration).ToString();
            }
            catch
            {
                form.PistaProgresoEtiqueta.Text = string.Empty;
                form.PistaDuracionEtiqueta.Text = string.Empty;
            }
        }

        private void LoadCoverImage(string filePath)
        {
            try
            {
                var archivo = TagLib.File.Create(filePath);
                var bin = (byte[])(archivo.Tag.Pictures[0].Data.Data);
                form.CubiertaPic.Image = Image.FromStream(new MemoryStream(bin));
            }
            catch
            {
                form.CubiertaPic.Image = null;
            }
        }
    }
}
