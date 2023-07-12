using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Policy;
using System.Net;
using Newtonsoft.Json.Linq;
using VideoLibrary;
using MediaToolkit;
using Google.Apis.YouTube.v3;
using Google.Apis.Services;
using NAudio.Wave;
using NAudio.Codecs;

namespace MusicPlayer
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }
        //move window around
        bool move;
        int moveX, moveY;

        private void TopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            moveX = e.X;
            moveY = e.Y;
        }

        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - moveX, MousePosition.Y - moveY);
            }
        }
        //default song path
        string targetPath = Directory.GetCurrentDirectory() + @"\Songs\";

        //audio objects
        public WaveFileReader reader;
        public WaveOut waveOut;
        public bool isPlaying;
        string currentTime = "";
        string time;

        private void Form1_Load(object sender, EventArgs e)
        {
            //show songs on start
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }
            refreshList();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //if (this.WindowState == FormWindowState.Normal)
            //{
                //this.WindowState = FormWindowState.Maximized;
            //}
            //else
           // {
              //  this.WindowState = FormWindowState.Normal;
            //}
        }
        public void refreshList()
        {
            DirectoryInfo di = new DirectoryInfo(targetPath);
            DirectoryInfo[] directories = di.GetDirectories();
            SongsDisplay.Items.Clear();
            for (int i = 0; i < directories.Length; i++)
            {
                SongsDisplay.Items.Add(Path.GetFileNameWithoutExtension(directories[i].Name));
            }
        }
        private void TopPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        //video downloading function
        async void DownloadSong()
        {
            // get user input
            string SongName = SongTitleInput.Text;
            string ArtistName = SongArtistInput.Text;
            if(SongName != "" && ArtistName != "")
            {
                bool isDownloaded = true;
                SongName = Char.ToUpper(SongName[0]) + SongName.Substring(1);
                ArtistName = Char.ToUpper(ArtistName[0]) + ArtistName.Substring(1);
                string url = GetYoutubeURL(SongName, ArtistName);
                if (url != "0")
                {
                    string fullName = ArtistName + " - " + SongName;
                    var youtube = YouTube.Default;
                    var video = await youtube.GetVideoAsync(url);
                    if (!Directory.Exists(targetPath + fullName))
                    {
                        Directory.CreateDirectory(targetPath + fullName);
                    }
                    try
                    {
                        File.WriteAllBytes(targetPath + fullName + @"\" + fullName, await video.GetBytesAsync());
                    }
                    catch
                    {
                        MessageBox.Show("Couldn't download song, try again.");
                        isDownloaded = false;
                    }
                    if (isDownloaded)
                    {
                        await DownloadLyrics(SongName, ArtistName);
                        //convert to WAV
                        string inputFile = targetPath + fullName + @"\" + fullName;
                        string outputFile = $"{targetPath + fullName + @"\" + fullName}.wav";
                        await convertToAudio(inputFile, outputFile);
                        File.Delete(targetPath + fullName + @"\" + fullName);
                        refreshList();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Song could not be found.");
                }
            
            }
            else
            {
                MessageBox.Show("Enter a song & artist name.");
            }
            //download mp4
            


        }
        async Task convertToAudio(string inputFile, string outputFile)
        {
            //using (var engine = new Engine())
            //{
                //engine.GetMetadata(inputFile);
                //engine.Convert(inputFile, outputFile);
            //}
            using(MediaFoundationReader mp4 = new MediaFoundationReader(inputFile))
            {
                WaveFileWriter.CreateWaveFile(outputFile, mp4);
            }


        }
        string GetYoutubeURL(string SongName,string SongArtist)
        {
            const string ytKey = "AIzaSyC4v9N0QfnbaNKeggMdT4bPi8gRGTEIoVk";
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = ytKey,
                ApplicationName = this.GetType().ToString()
            });
            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = SongArtist + " - " + SongName;
            searchListRequest.MaxResults = 1;
            var searchListResponse = searchListRequest.Execute();
            if (searchListResponse.Items.Count > 0)
            {
                string id = searchListResponse.Items[0].Id.VideoId;
                return "https://www.youtube.com/watch?v="+id;
            }
            else
            {
                return "0";
            }
            

        }
        //download lyrics

        async Task DownloadLyrics(string SongName, string ArtistName)
        {
            string url = string.Format("https://api.lyrics.ovh/v1/{0}/{1}",ArtistName, SongName);
            var json = new WebClient().DownloadString(url);
            string fullName = ArtistName + " - " + SongName;
            string data = JObject.Parse(json)["lyrics"].ToString();
            string[] temp = data.Split('\n');
            if (!File.Exists(targetPath + fullName + @"\lyrics.txt"))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(targetPath + fullName + @"\lyrics.txt"))
                {
                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (i < temp.Length - 1 && temp[i + 1] == "")
                        {
                            sw.WriteLine(temp[i]);
                        }
                        else if(temp[i] != "")
                        {
                            sw.WriteLineAsync(temp[i]);
                        }
                    }
                }
            }
        }
        //show lyrics
        private void SearchLyrics_Click(object sender, EventArgs e)
        {
            DownloadSong();
            
        }
        //delete songs and lyrics
        void DeleteSongs()
        {
            int index = SongsDisplay.SelectedIndex;
            waveOut.Stop();
            if (SongsDisplay.SelectedItem != null)
            {
                string selectedSong = SongsDisplay.SelectedItem.ToString();
                reader.Close();
                DirectoryInfo di = new DirectoryInfo(targetPath + selectedSong);
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                di.Delete();
                refreshList();
            }
            if (index + 1 < SongsDisplay.Items.Count)
            {
                SongsDisplay.SelectedIndex = index + 1;
            }
            else if(index - 1 >= 0)
            {
                SongsDisplay.SelectedIndex = index - 1;
            }
            
        }


        private void RemoveButton_Click(object sender, EventArgs e)
        {
            DeleteSongs();
                
        }

        string showCurrentSong = "";
        private void SongsDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SongsDisplay.SelectedItem != null && SongsDisplay.SelectedIndex < SongsDisplay.Items.Count)
            {
                string selectedSong = SongsDisplay.SelectedItem.ToString();
                string audioPath = targetPath + selectedSong + @"\" + selectedSong + ".wav";
                if (File.Exists(audioPath))
                {
                    if (waveOut != null)
                    {
                        waveOut.Stop();
                        reader.Close();
                    }
                    //reset audio to picked song
                    reader = new WaveFileReader(audioPath);
                    waveOut = new WaveOut(); // or WaveOutEvent()
                    waveOut.Init(reader);
                    waveOut.Play();
                    isPlaying = true;
                }
                

                
                //try to read lyrics
                if (File.Exists(targetPath + selectedSong + @"\lyrics.txt"))
                {
                    string[] lyricsTextArr = File.ReadAllLines(targetPath + selectedSong + @"\lyrics.txt");
                    if(lyricsTextArr.Length > 0)
                    {

                        LyricsBox.Lines = lyricsTextArr;
                    }
                    else
                    {
                        LyricsBox.Text = "Lyrics not available.";
                    }
                }
                else
                {
                    LyricsBox.Text = "Lyrics not available.";
                }
                if (reader != null)
                {
                    VolumeBar.Value = Convert.ToInt32(Convert.ToDouble(waveOut.Volume.ToString()) * 100);
                    string[] splitName = selectedSong.Split('-');
                    string[] timeArr = reader.TotalTime.ToString().Split(':');
                    if (timeArr[0] != "00")
                    {
                        time = string.Format("{0}:{1}:{2}", timeArr[0], timeArr[1], Math.Floor(double.Parse(timeArr[2])));
                    }
                    else
                    {
                        time = string.Format("{0}:{1}", timeArr[1], Math.Floor(double.Parse(timeArr[2])));
                    }
                    showCurrentSong = string.Format("{0}, by {1}", splitName[1].Trim(), splitName[0].Trim());
                    CurrentSongLabel.Text = showCurrentSong;
                    TotalTimeLabel.Text = time;
                }
                
            }
            
            
            
            
        }
        void updateTime()
        {
            if(reader != null && SongsDisplay.SelectedItem != null)
            {
                string[] timeLeftArr = reader.CurrentTime.ToString().Split(':');
                if (timeLeftArr[0] != "00")
                {
                    currentTime = string.Format("{0}:{1}:{2}", timeLeftArr[0], timeLeftArr[1], Math.Floor(double.Parse(timeLeftArr[2])));
                }
                else
                {
                    string seconds, minutes;
                    if(Math.Floor(double.Parse(timeLeftArr[2])) < 10)
                    {
                        seconds = "0" + Math.Floor(double.Parse(timeLeftArr[2]));
                    }
                    else
                    {
                        seconds = Math.Floor(double.Parse(timeLeftArr[2])).ToString();
                    }
                    if (int.Parse(timeLeftArr[1]) < 10)
                    {
                        minutes = "0" + timeLeftArr[1];
                    }
                    else
                    {
                        minutes = timeLeftArr[1];
                    }
                    currentTime = string.Format("{0}:{1}", timeLeftArr[1], seconds);
                }
                CurrentTimeLabel.Text = currentTime;
            }
            
        }

        

        private void VolumeBar_Scroll(object sender, EventArgs e)
        {
            if(SongsDisplay.SelectedItem != null){
                waveOut.Volume = (float)VolumeBar.Value / 100f;
            }
            
        }

        private void NextSongButton_Click(object sender, EventArgs e)
        {
            if (SongsDisplay.SelectedIndex < SongsDisplay.Items.Count - 1)
            {
                SongsDisplay.SelectedIndex++;
            }
            
        }

        private void PreviousSongButton_Click(object sender, EventArgs e)
        {
            if (SongsDisplay.SelectedIndex > 0)
            {
                SongsDisplay.SelectedIndex--;
            }
        }
        void updateSongBar()
        {
            if(reader != null && reader != null && SongsDisplay.SelectedItem != null)
            {
                string[] TotalTimeSplit = reader.TotalTime.ToString().Split(':');
                double seconds = double.Parse(TotalTimeSplit[0].Trim()) * 3600 + double.Parse(TotalTimeSplit[1].Trim()) * 60 + Math.Floor(double.Parse(TotalTimeSplit[2].Trim()));
                string[] CurrentTimeSplit = reader.CurrentTime.ToString().Split(':');
                double currentSeconds = double.Parse(CurrentTimeSplit[0].Trim()) * 3600 + double.Parse(CurrentTimeSplit[1].Trim()) * 60 + Math.Floor(double.Parse(CurrentTimeSplit[2].Trim()));
                musicProgressBar.Value = Convert.ToInt32(currentSeconds * (musicProgressBar.Maximum / seconds));
            }
        }
        private void currentTimeUpdate_Tick(object sender, EventArgs e)
        {
            updateTime();
            updateSongBar();
        }

        private void musicProgressBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (reader != null)
            {
                if (isPlaying)
                {
                    waveOut.Resume();
                }
            }
        }

        private void musicProgressBar_Scroll(object sender, EventArgs e)
        {
            if (reader != null && SongsDisplay.SelectedItem != null)
            {
                waveOut.Pause();
                string[] TotalTimeSplit = reader.TotalTime.ToString().Split(':');
                double seconds = double.Parse(TotalTimeSplit[0].Trim()) * 3600 + double.Parse(TotalTimeSplit[1].Trim()) * 60 + Math.Floor(double.Parse(TotalTimeSplit[2].Trim()));
                TimeSpan ts = TimeSpan.FromSeconds((Convert.ToDouble(musicProgressBar.Value) / Convert.ToDouble(musicProgressBar.Maximum)) * seconds);
                reader.CurrentTime = ts;
            }
        }

        private void PlayPauseButton_Click_1(object sender, EventArgs e)
        {
            if (SongsDisplay.SelectedItem != null)
            {
                if (isPlaying)
                {
                    waveOut.Pause();
                    isPlaying = false;
                    PlayPauseButton.Text = "⏸";
                }
                else
                {
                    waveOut.Resume();
                    isPlaying = true;
                    PlayPauseButton.Text = "▷";
                }
            }
        }

        
    }
}
