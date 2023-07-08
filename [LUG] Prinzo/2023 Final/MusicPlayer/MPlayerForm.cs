using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;


/**
 * Developer/s: Gerardo Tordoya
 * Description: Basic Music Player
 * Create Date: 2023-07-08
 * Update Date: XXXX-XX-XX
 * Forked From: https://youtu.be/QJkFfKDhz5o
 */


// TODO => hay un pequeño error al cargar  2 a mas veces una lista de musica
// sale error ...... " the lbl_track_end.Text line. It is showing 'Object
// reference not set to an instance of an object'." [a mí me sale, y es
// lógico, que el índice está fuera de los límites de la matriz: es decir, no
// se está actualizando el tamaño del vector cuando se siguen cargando
// canciones].

// TODO => como hago que se reprodusca automáticamente una lista de música ??

// TODO =>
/*
Sir, i got error System.IndexOutOfRangeException: 'Index was outside the bounds of the array.' when i played music
with no cover album, how to solve this error?

solution:
  //Track_list 
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Player.URL = paths[Track_list.SelectedIndex];
            Player.Ctlcontrols.play();
            try
            {
                var file = TagLib.File.Create(paths[Track_list.SelectedIndex]);
                var bin = (byte[])(file.Tag.Pictures[0].Data.Data);
                Cover.Image = Image.FromStream(new MemoryStream(bin));
            }
            catch
            {
                Cover.Image = null;
            }
        }
 */


namespace MusicPlayer
{
    public partial class MPlayerForm : Form
    {
        public MPlayerForm()
        {
            InitializeComponent();
            VolumeBar.Value = 50;
        }
        /////////////////////////////////////////////////////////////////////
        string[] paths, files;
        /////////////////////////////////////////////////////////////////////

        #region BOTONES*-------------------------------------------------------------*
        private void PreviewBtn_Click(object sender, EventArgs e)
        {
            if (TrackListLBox.SelectedIndex > 0)
            {
                TrackListLBox.SelectedIndex--;
            }
        }
        private void NextBtn_Click(object sender, EventArgs e)
        {
            if (TrackListLBox.SelectedIndex < TrackListLBox.Items.Count - 1)
            {
                TrackListLBox.SelectedIndex++;
            }
        }
        private void PlayBtn_Click(object sender, EventArgs e)
        {
            PlayerWmp.Ctlcontrols.play();
        }
        private void PauseBtn_Click(object sender, EventArgs e)
        {
            PlayerWmp.Ctlcontrols.pause();
        }
        private void StopBtn_Click(object sender, EventArgs e)
        {
            PlayerWmp.Ctlcontrols.stop();
            ProgressBar.Value = 0;
        }
        private void OpenBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;

            // Si: FileDialog está abierto + hay archivos seleccionados + se
            // pulsó OK, entonces: añadir todos los ítems al TrackList <- (Lista de Pistas)
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                files = ofd.FileNames;
                paths = ofd.FileNames;
                for (int x = 0; x < files.Length; x++) TrackListLBox.Items.Add(files[x]);
            }
        }
        #endregion

        // Si el usuario selecciona algún archivo de la lista, entonces reproducirla.
        private void TrackListLBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlayerWmp.URL = paths[TrackListLBox.SelectedIndex];
            PlayerWmp.Ctlcontrols.play();
            try
            {
                var file = TagLib.File.Create(paths[TrackListLBox.SelectedIndex]);
                var bin = (byte[])(file.Tag.Pictures[0].Data.Data);
                ArtPic.Image = Image.FromStream(new MemoryStream(bin));
            }
            catch { }
        }

        private void VolumeBar_Scroll(object sender, EventArgs e)
        {
            PlayerWmp.settings.volume = VolumeBar.Value;
            VolumePorcentajeLbl.Text = VolumeBar.Value.ToString() + "%";
        }

        private void ProgressBar_MouseDown(object sender, MouseEventArgs e)
        {
            PlayerWmp.Ctlcontrols.currentPosition = PlayerWmp.currentMedia.duration * e.X / ProgressBar.Width;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (PlayerWmp.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                ProgressBar.Maximum = (int)PlayerWmp.Ctlcontrols.currentItem.duration;
                ProgressBar.Value = (int)PlayerWmp.Ctlcontrols.currentPosition;

                try
                {
                    TrackStartLbl.Text = PlayerWmp.Ctlcontrols.currentPositionString;
                    TrackEndLbl.Text = PlayerWmp.Ctlcontrols.currentItem.durationString;
                }
                catch { }
            }
        }
    }
}
