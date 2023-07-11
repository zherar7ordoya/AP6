using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MusicPlayer
{
    public class MusicPlayer
    {
        private AxWMPLib.AxWindowsMediaPlayer player;
        private Timer timer;
        private string[] rutas;
        private string[] archivos;

        public event EventHandler TrackChanged;

        public MusicPlayer(AxWMPLib.AxWindowsMediaPlayer player, Timer timer)
        {
            this.player = player;
            this.timer = timer;

            this.timer.Tick += Timer_Tick;
        }

        public void LoadFiles()
        {
            OpenFileDialog selector = new OpenFileDialog
            {
                Multiselect = true
            };
            if (selector.ShowDialog() == DialogResult.OK)
            {
                archivos = selector.FileNames.Select(Path.GetFileName).ToArray();
                rutas = selector.FileNames;

                TrackChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Play()
        {
            player.Ctlcontrols.play();
        }

        public void Pause()
        {
            player.Ctlcontrols.pause();
        }

        public void Stop()
        {
            player.Ctlcontrols.stop();
        }

        public void Previous()
        {
            if (player.currentPlaylist != null && player.currentPlaylist.count > 0)
            {
                var currentIndex = player.currentPlaylist.get_Item(player.currentItem).index;
                var previousIndex = currentIndex > 0 ? currentIndex - 1 : player.currentPlaylist.count - 1;
                player.Ctlcontrols.playItem(player.currentPlaylist.get_Item(previousIndex));
            }
        }

        public void Next()
        {
            if (player.currentPlaylist != null && player.currentPlaylist.count > 0)
            {
                var currentIndex = player.currentPlaylist.get_Item(player.currentItem).index;
                var nextIndex = currentIndex < player.currentPlaylist.count - 1 ? currentIndex + 1 : 0;
                player.Ctlcontrols.playItem(player.currentPlaylist.get_Item(nextIndex));
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (player.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                var currentPosition = (int)player.Ctlcontrols.currentPosition;
                var duration = (int)player.Ctlcontrols.currentItem.duration;

                TrackChanged?.Invoke(this, EventArgs.Empty);

                if (currentPosition >= duration)
                {
                    Next();
                }
            }
        }
    }
}
