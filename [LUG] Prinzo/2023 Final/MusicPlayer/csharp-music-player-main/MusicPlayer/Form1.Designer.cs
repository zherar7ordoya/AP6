namespace MusicPlayer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TopPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.MinimizeButton = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Label();
            this.SongsDisplay = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.TotalTimeLabel = new System.Windows.Forms.Label();
            this.CurrentTimeLabel = new System.Windows.Forms.Label();
            this.VolumeBarHider = new System.Windows.Forms.Panel();
            this.ProgressBarHider = new System.Windows.Forms.Panel();
            this.musicProgressBar = new System.Windows.Forms.TrackBar();
            this.CurrentSongLabel = new System.Windows.Forms.Label();
            this.ListeningToLabel = new System.Windows.Forms.Label();
            this.PlayPauseButton = new System.Windows.Forms.Button();
            this.NextSongButton = new System.Windows.Forms.Button();
            this.PreviousSongButton = new System.Windows.Forms.Button();
            this.VolumeBar = new System.Windows.Forms.TrackBar();
            this.SongTitleInput = new System.Windows.Forms.TextBox();
            this.LyricsBox = new System.Windows.Forms.TextBox();
            this.SearchSong = new System.Windows.Forms.Button();
            this.SongNameLabel = new System.Windows.Forms.Label();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.SongArtistInput = new System.Windows.Forms.TextBox();
            this.SongArtistLabel = new System.Windows.Forms.Label();
            this.SongInputBackpanel = new System.Windows.Forms.Panel();
            this.ArtistInputBackpanel = new System.Windows.Forms.Panel();
            this.HideScrollbarPanel = new System.Windows.Forms.Panel();
            this.currentTimeUpdate = new System.Windows.Forms.Timer(this.components);
            this.TopPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.musicProgressBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).BeginInit();
            this.SongInputBackpanel.SuspendLayout();
            this.ArtistInputBackpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(50)))));
            this.TopPanel.Controls.Add(this.label1);
            this.TopPanel.Controls.Add(this.MinimizeButton);
            this.TopPanel.Controls.Add(this.ExitButton);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Font = new System.Drawing.Font("Microsoft Himalaya", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1131, 45);
            this.TopPanel.TabIndex = 0;
            this.TopPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TopPanel_Paint);
            this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
            this.TopPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseMove);
            this.TopPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseUp);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1061, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "□";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeButton.AutoSize = true;
            this.MinimizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeButton.Location = new System.Drawing.Point(1029, 3);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(26, 29);
            this.MinimizeButton.TabIndex = 2;
            this.MinimizeButton.Text = "_";
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.AutoSize = true;
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.Location = new System.Drawing.Point(1095, 6);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(24, 29);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.Text = "x";
            this.ExitButton.Click += new System.EventHandler(this.label2_Click);
            // 
            // SongsDisplay
            // 
            this.SongsDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SongsDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.SongsDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SongsDisplay.ColumnWidth = 1;
            this.SongsDisplay.Font = new System.Drawing.Font("Bahnschrift", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SongsDisplay.ForeColor = System.Drawing.SystemColors.Info;
            this.SongsDisplay.FormattingEnabled = true;
            this.SongsDisplay.HorizontalScrollbar = true;
            this.SongsDisplay.ItemHeight = 24;
            this.SongsDisplay.Location = new System.Drawing.Point(821, 45);
            this.SongsDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.SongsDisplay.Name = "SongsDisplay";
            this.SongsDisplay.Size = new System.Drawing.Size(310, 480);
            this.SongsDisplay.TabIndex = 1;
            this.SongsDisplay.SelectedIndexChanged += new System.EventHandler(this.SongsDisplay_SelectedIndexChanged);
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BottomPanel.Controls.Add(this.TotalTimeLabel);
            this.BottomPanel.Controls.Add(this.CurrentTimeLabel);
            this.BottomPanel.Controls.Add(this.VolumeBarHider);
            this.BottomPanel.Controls.Add(this.ProgressBarHider);
            this.BottomPanel.Controls.Add(this.musicProgressBar);
            this.BottomPanel.Controls.Add(this.CurrentSongLabel);
            this.BottomPanel.Controls.Add(this.ListeningToLabel);
            this.BottomPanel.Controls.Add(this.PlayPauseButton);
            this.BottomPanel.Controls.Add(this.NextSongButton);
            this.BottomPanel.Controls.Add(this.PreviousSongButton);
            this.BottomPanel.Controls.Add(this.VolumeBar);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 597);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(1131, 114);
            this.BottomPanel.TabIndex = 3;
            // 
            // TotalTimeLabel
            // 
            this.TotalTimeLabel.AutoSize = true;
            this.TotalTimeLabel.Font = new System.Drawing.Font("Bahnschrift SemiLight", 12F);
            this.TotalTimeLabel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.TotalTimeLabel.Location = new System.Drawing.Point(788, 85);
            this.TotalTimeLabel.Name = "TotalTimeLabel";
            this.TotalTimeLabel.Size = new System.Drawing.Size(49, 19);
            this.TotalTimeLabel.TabIndex = 12;
            this.TotalTimeLabel.Text = "00:00";
            this.TotalTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CurrentTimeLabel
            // 
            this.CurrentTimeLabel.AutoSize = true;
            this.CurrentTimeLabel.Font = new System.Drawing.Font("Bahnschrift SemiLight", 12F);
            this.CurrentTimeLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.CurrentTimeLabel.Location = new System.Drawing.Point(289, 85);
            this.CurrentTimeLabel.Name = "CurrentTimeLabel";
            this.CurrentTimeLabel.Size = new System.Drawing.Size(49, 19);
            this.CurrentTimeLabel.TabIndex = 11;
            this.CurrentTimeLabel.Text = "00:00";
            this.CurrentTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VolumeBarHider
            // 
            this.VolumeBarHider.Location = new System.Drawing.Point(863, 60);
            this.VolumeBarHider.Name = "VolumeBarHider";
            this.VolumeBarHider.Size = new System.Drawing.Size(221, 10);
            this.VolumeBarHider.TabIndex = 10;
            // 
            // ProgressBarHider
            // 
            this.ProgressBarHider.Location = new System.Drawing.Point(344, 102);
            this.ProgressBarHider.Name = "ProgressBarHider";
            this.ProgressBarHider.Size = new System.Drawing.Size(435, 10);
            this.ProgressBarHider.TabIndex = 9;
            // 
            // musicProgressBar
            // 
            this.musicProgressBar.Location = new System.Drawing.Point(341, 86);
            this.musicProgressBar.Maximum = 1000;
            this.musicProgressBar.Name = "musicProgressBar";
            this.musicProgressBar.Size = new System.Drawing.Size(442, 45);
            this.musicProgressBar.TabIndex = 8;
            this.musicProgressBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.musicProgressBar.Scroll += new System.EventHandler(this.musicProgressBar_Scroll);
            this.musicProgressBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.musicProgressBar_MouseUp);
            // 
            // CurrentSongLabel
            // 
            this.CurrentSongLabel.AutoSize = true;
            this.CurrentSongLabel.Font = new System.Drawing.Font("Bahnschrift SemiLight", 10F);
            this.CurrentSongLabel.Location = new System.Drawing.Point(30, 61);
            this.CurrentSongLabel.Name = "CurrentSongLabel";
            this.CurrentSongLabel.Size = new System.Drawing.Size(42, 17);
            this.CurrentSongLabel.TabIndex = 7;
            this.CurrentSongLabel.Text = "None";
            // 
            // ListeningToLabel
            // 
            this.ListeningToLabel.AutoSize = true;
            this.ListeningToLabel.Font = new System.Drawing.Font("Bahnschrift SemiLight", 13F);
            this.ListeningToLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ListeningToLabel.Location = new System.Drawing.Point(29, 33);
            this.ListeningToLabel.Name = "ListeningToLabel";
            this.ListeningToLabel.Size = new System.Drawing.Size(187, 22);
            this.ListeningToLabel.TabIndex = 6;
            this.ListeningToLabel.Text = "Currently listening to:";
            // 
            // PlayPauseButton
            // 
            this.PlayPauseButton.FlatAppearance.BorderSize = 0;
            this.PlayPauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayPauseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayPauseButton.Location = new System.Drawing.Point(524, 30);
            this.PlayPauseButton.Name = "PlayPauseButton";
            this.PlayPauseButton.Size = new System.Drawing.Size(68, 39);
            this.PlayPauseButton.TabIndex = 5;
            this.PlayPauseButton.Text = "▷";
            this.PlayPauseButton.UseVisualStyleBackColor = true;
            this.PlayPauseButton.Click += new System.EventHandler(this.PlayPauseButton_Click_1);
            // 
            // NextSongButton
            // 
            this.NextSongButton.FlatAppearance.BorderSize = 0;
            this.NextSongButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextSongButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextSongButton.Location = new System.Drawing.Point(598, 30);
            this.NextSongButton.Name = "NextSongButton";
            this.NextSongButton.Size = new System.Drawing.Size(94, 39);
            this.NextSongButton.TabIndex = 4;
            this.NextSongButton.Text = ">";
            this.NextSongButton.UseVisualStyleBackColor = true;
            this.NextSongButton.Click += new System.EventHandler(this.NextSongButton_Click);
            // 
            // PreviousSongButton
            // 
            this.PreviousSongButton.FlatAppearance.BorderSize = 0;
            this.PreviousSongButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviousSongButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviousSongButton.Location = new System.Drawing.Point(424, 30);
            this.PreviousSongButton.Name = "PreviousSongButton";
            this.PreviousSongButton.Size = new System.Drawing.Size(94, 39);
            this.PreviousSongButton.TabIndex = 3;
            this.PreviousSongButton.Text = "<";
            this.PreviousSongButton.UseVisualStyleBackColor = true;
            this.PreviousSongButton.Click += new System.EventHandler(this.PreviousSongButton_Click);
            // 
            // VolumeBar
            // 
            this.VolumeBar.Location = new System.Drawing.Point(858, 44);
            this.VolumeBar.Maximum = 100;
            this.VolumeBar.Name = "VolumeBar";
            this.VolumeBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.VolumeBar.Size = new System.Drawing.Size(231, 45);
            this.VolumeBar.SmallChange = 10;
            this.VolumeBar.TabIndex = 2;
            this.VolumeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.VolumeBar.Value = 100;
            this.VolumeBar.Scroll += new System.EventHandler(this.VolumeBar_Scroll);
            // 
            // SongTitleInput
            // 
            this.SongTitleInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SongTitleInput.BackColor = System.Drawing.Color.MidnightBlue;
            this.SongTitleInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SongTitleInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SongTitleInput.ForeColor = System.Drawing.SystemColors.Info;
            this.SongTitleInput.Location = new System.Drawing.Point(6, 5);
            this.SongTitleInput.Name = "SongTitleInput";
            this.SongTitleInput.Size = new System.Drawing.Size(191, 19);
            this.SongTitleInput.TabIndex = 6;
            // 
            // LyricsBox
            // 
            this.LyricsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LyricsBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.LyricsBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LyricsBox.Font = new System.Drawing.Font("Bahnschrift SemiLight", 16F);
            this.LyricsBox.ForeColor = System.Drawing.SystemColors.Menu;
            this.LyricsBox.Location = new System.Drawing.Point(70, 174);
            this.LyricsBox.Margin = new System.Windows.Forms.Padding(20, 10, 20, 0);
            this.LyricsBox.Multiline = true;
            this.LyricsBox.Name = "LyricsBox";
            this.LyricsBox.ReadOnly = true;
            this.LyricsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LyricsBox.Size = new System.Drawing.Size(713, 417);
            this.LyricsBox.TabIndex = 7;
            this.LyricsBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LyricsBox.WordWrap = false;
            // 
            // SearchSong
            // 
            this.SearchSong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchSong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.SearchSong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchSong.Font = new System.Drawing.Font("Bahnschrift SemiLight", 9F);
            this.SearchSong.ForeColor = System.Drawing.SystemColors.Control;
            this.SearchSong.Location = new System.Drawing.Point(494, 64);
            this.SearchSong.Name = "SearchSong";
            this.SearchSong.Size = new System.Drawing.Size(221, 68);
            this.SearchSong.TabIndex = 8;
            this.SearchSong.Text = "Search Song";
            this.SearchSong.UseVisualStyleBackColor = false;
            this.SearchSong.Click += new System.EventHandler(this.SearchLyrics_Click);
            // 
            // SongNameLabel
            // 
            this.SongNameLabel.AutoSize = true;
            this.SongNameLabel.Font = new System.Drawing.Font("Bahnschrift SemiLight", 15F);
            this.SongNameLabel.Location = new System.Drawing.Point(26, 64);
            this.SongNameLabel.Name = "SongNameLabel";
            this.SongNameLabel.Size = new System.Drawing.Size(118, 24);
            this.SongNameLabel.TabIndex = 9;
            this.SongNameLabel.Text = "Song Name:";
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveButton.AutoSize = true;
            this.RemoveButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.RemoveButton.FlatAppearance.BorderSize = 0;
            this.RemoveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveButton.Font = new System.Drawing.Font("Bahnschrift SemiLight", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveButton.Location = new System.Drawing.Point(821, 504);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(310, 93);
            this.RemoveButton.TabIndex = 10;
            this.RemoveButton.Text = "Remove Song";
            this.RemoveButton.UseVisualStyleBackColor = false;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // SongArtistInput
            // 
            this.SongArtistInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SongArtistInput.BackColor = System.Drawing.Color.MidnightBlue;
            this.SongArtistInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SongArtistInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SongArtistInput.ForeColor = System.Drawing.SystemColors.Info;
            this.SongArtistInput.Location = new System.Drawing.Point(6, 5);
            this.SongArtistInput.Name = "SongArtistInput";
            this.SongArtistInput.Size = new System.Drawing.Size(187, 19);
            this.SongArtistInput.TabIndex = 11;
            // 
            // SongArtistLabel
            // 
            this.SongArtistLabel.AutoSize = true;
            this.SongArtistLabel.Font = new System.Drawing.Font("Bahnschrift SemiLight", 15F);
            this.SongArtistLabel.Location = new System.Drawing.Point(260, 64);
            this.SongArtistLabel.Name = "SongArtistLabel";
            this.SongArtistLabel.Size = new System.Drawing.Size(66, 24);
            this.SongArtistLabel.TabIndex = 12;
            this.SongArtistLabel.Text = "Artist:";
            // 
            // SongInputBackpanel
            // 
            this.SongInputBackpanel.BackColor = System.Drawing.Color.MidnightBlue;
            this.SongInputBackpanel.Controls.Add(this.SongTitleInput);
            this.SongInputBackpanel.Location = new System.Drawing.Point(30, 103);
            this.SongInputBackpanel.Name = "SongInputBackpanel";
            this.SongInputBackpanel.Size = new System.Drawing.Size(200, 29);
            this.SongInputBackpanel.TabIndex = 13;
            // 
            // ArtistInputBackpanel
            // 
            this.ArtistInputBackpanel.BackColor = System.Drawing.Color.MidnightBlue;
            this.ArtistInputBackpanel.Controls.Add(this.SongArtistInput);
            this.ArtistInputBackpanel.Location = new System.Drawing.Point(264, 103);
            this.ArtistInputBackpanel.Name = "ArtistInputBackpanel";
            this.ArtistInputBackpanel.Size = new System.Drawing.Size(193, 29);
            this.ArtistInputBackpanel.TabIndex = 14;
            // 
            // HideScrollbarPanel
            // 
            this.HideScrollbarPanel.Location = new System.Drawing.Point(764, 174);
            this.HideScrollbarPanel.Name = "HideScrollbarPanel";
            this.HideScrollbarPanel.Size = new System.Drawing.Size(19, 417);
            this.HideScrollbarPanel.TabIndex = 15;
            // 
            // currentTimeUpdate
            // 
            this.currentTimeUpdate.Enabled = true;
            this.currentTimeUpdate.Tick += new System.EventHandler(this.currentTimeUpdate_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1131, 711);
            this.Controls.Add(this.HideScrollbarPanel);
            this.Controls.Add(this.ArtistInputBackpanel);
            this.Controls.Add(this.SongInputBackpanel);
            this.Controls.Add(this.SongArtistLabel);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.SongNameLabel);
            this.Controls.Add(this.SearchSong);
            this.Controls.Add(this.LyricsBox);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.SongsDisplay);
            this.Controls.Add(this.TopPanel);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Music Player";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.musicProgressBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).EndInit();
            this.SongInputBackpanel.ResumeLayout(false);
            this.SongInputBackpanel.PerformLayout();
            this.ArtistInputBackpanel.ResumeLayout(false);
            this.ArtistInputBackpanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label ExitButton;
        private System.Windows.Forms.Label MinimizeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox SongsDisplay;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.TextBox SongTitleInput;
        private System.Windows.Forms.Button SearchSong;
        private System.Windows.Forms.TextBox LyricsBox;
        private System.Windows.Forms.Label SongNameLabel;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.TextBox SongArtistInput;
        private System.Windows.Forms.Label SongArtistLabel;
        private System.Windows.Forms.TrackBar VolumeBar;
        private System.Windows.Forms.Button NextSongButton;
        private System.Windows.Forms.Button PreviousSongButton;
        private System.Windows.Forms.Button PlayPauseButton;
        private System.Windows.Forms.Panel SongInputBackpanel;
        private System.Windows.Forms.Panel ArtistInputBackpanel;
        private System.Windows.Forms.Label ListeningToLabel;
        private System.Windows.Forms.Label CurrentSongLabel;
        private System.Windows.Forms.Panel HideScrollbarPanel;
        private System.Windows.Forms.Timer currentTimeUpdate;
        private System.Windows.Forms.TrackBar musicProgressBar;
        private System.Windows.Forms.Panel ProgressBarHider;
        private System.Windows.Forms.Panel VolumeBarHider;
        private System.Windows.Forms.Label TotalTimeLabel;
        private System.Windows.Forms.Label CurrentTimeLabel;
    }
}

