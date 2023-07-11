/**
 * Developer/s: Gerardo Tordoya
 * Description: Basic Music Player
 * Create Date: 2023-07-08
 * Update Date: XXXX-XX-XX
 * Forked From: https://youtu.be/QJkFfKDhz5o
 */


//using System;
//using System.Drawing;
//using System.Windows.Forms;
//using System.IO;
//using System.Linq;


//namespace MusicPlayer
//{
//    public partial class ReproductorForm : Form
//    {
//        public ReproductorForm()
//        {
//            InitializeComponent();
//            VolumenBarra.Value = 50;
//        }

//        string[] rutas, archivos;

//        private void AnteriorBoton_Click(object sender, EventArgs e)
//        {
//            if (PistasLista.SelectedIndex > 0)
//            {
//                PistasLista.SelectedIndex--;
//            }
//        }

//        private void SiguienteBoton_Click(object sender, EventArgs e)
//        {
//            if (PistasLista.SelectedIndex < PistasLista.Items.Count - 1)
//            {
//                PistasLista.SelectedIndex++;
//            }
//        }

//        private void ReproducirBoton_Click(object sender, EventArgs e)
//        {
//            Reproductor.Ctlcontrols.play();
//        }

//        private void PausarBoton_Click(object sender, EventArgs e)
//        {
//            Reproductor.Ctlcontrols.pause();
//        }

//        private void DetenerBoton_Click(object sender, EventArgs e)
//        {
//            Reproductor.Ctlcontrols.stop();
//            PistaProgresoBarra.Value = 0;
//        }
//        private void CargarBoton_Click(object sender, EventArgs e)
//        {
//            OpenFileDialog selector = new OpenFileDialog
//            {
//                Multiselect = true
//            };
//            if (selector.ShowDialog() == DialogResult.OK)
//            {
//                archivos = selector.FileNames.Select(Path.GetFileName).ToArray();
//                rutas = selector.FileNames;
//                PistasLista.Items.Clear();
//                for (int x = 0; x < archivos.Length; x++) PistasLista.Items.Add(archivos[x]);
//            }
//        }

//        private void PistasLista_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            Reproductor.URL = rutas[PistasLista.SelectedIndex];
//            Reproductor.Ctlcontrols.play();
//            try
//            {
//                var archivo = TagLib.File.Create(rutas[PistasLista.SelectedIndex]);
//                var bin = (byte[])(archivo.Tag.Pictures[0].Data.Data);
//                CubiertaPic.Image = Image.FromStream(new MemoryStream(bin));
//            }
//            catch { CubiertaPic.Image = null; }
//        }

//        private void VolumenBarra_Scroll(object sender, EventArgs e)
//        {
//            Reproductor.settings.volume = VolumenBarra.Value;
//            NivelVolumenEtiqueta.Text = string.Format("{0}%", VolumenBarra.Value.ToString());
//        }

//        private void PistaProgresoBarra_MouseDown(object sender, MouseEventArgs e)
//        {
//            Reproductor.Ctlcontrols.currentPosition = Reproductor.currentMedia.duration * e.X / PistaProgresoBarra.Width;
//        }

//        private void Temporizador_Tick(object sender, EventArgs e)
//        {
//            if (Reproductor.playState == WMPLib.WMPPlayState.wmppsPlaying)
//            {
//                PistaProgresoBarra.Maximum = (int)Reproductor.Ctlcontrols.currentItem.duration;
//                PistaProgresoBarra.Value = (int)Reproductor.Ctlcontrols.currentPosition;

//                try
//                {
//                    PistaProgresoEtiqueta.Text = Reproductor.Ctlcontrols.currentPositionString;
//                    PistaDuracionEtiqueta.Text = Reproductor.Ctlcontrols.currentItem.durationString;
//                }
//                catch { }
//            }
//        }
//    }
//}


using System;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class ReproductorForm : Form
    {
        private MusicPlayer musicPlayer;
        private FormController formController;

        public ReproductorForm()
        {
            InitializeComponent();
            VolumenBarra.Value = 50;

            musicPlayer = new MusicPlayer(Reproductor, Temporizador);
            formController = new FormController(this, musicPlayer);
        }
    }
}
