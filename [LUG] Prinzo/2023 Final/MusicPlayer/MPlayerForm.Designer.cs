
namespace MusicPlayer
{
    partial class MPlayerForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MPlayerForm));
            this.PreviewBtn = new System.Windows.Forms.Button();
            this.NextBtn = new System.Windows.Forms.Button();
            this.PlayBtn = new System.Windows.Forms.Button();
            this.PauseBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.OpenBtn = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.TrackListLBox = new System.Windows.Forms.ListBox();
            this.ArtPic = new System.Windows.Forms.PictureBox();
            this.PlayerWmp = new AxWMPLib.AxWindowsMediaPlayer();
            this.VolumeBar = new System.Windows.Forms.TrackBar();
            this.VolumeLbl = new System.Windows.Forms.Label();
            this.VolumePorcentajeLbl = new System.Windows.Forms.Label();
            this.TrackStartLbl = new System.Windows.Forms.Label();
            this.TrackEndLbl = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ArtPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerWmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).BeginInit();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PreviewBtn
            // 
            this.PreviewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviewBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.PreviewBtn.Location = new System.Drawing.Point(12, 306);
            this.PreviewBtn.Name = "PreviewBtn";
            this.PreviewBtn.Size = new System.Drawing.Size(100, 23);
            this.PreviewBtn.TabIndex = 0;
            this.PreviewBtn.Text = "Preview";
            this.PreviewBtn.UseVisualStyleBackColor = true;
            this.PreviewBtn.Click += new System.EventHandler(this.PreviewBtn_Click);
            // 
            // NextBtn
            // 
            this.NextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.NextBtn.Location = new System.Drawing.Point(118, 306);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(100, 23);
            this.NextBtn.TabIndex = 1;
            this.NextBtn.Text = "Next";
            this.NextBtn.UseVisualStyleBackColor = true;
            this.NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            // 
            // PlayBtn
            // 
            this.PlayBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.PlayBtn.Location = new System.Drawing.Point(224, 306);
            this.PlayBtn.Name = "PlayBtn";
            this.PlayBtn.Size = new System.Drawing.Size(100, 23);
            this.PlayBtn.TabIndex = 2;
            this.PlayBtn.Text = "Play";
            this.PlayBtn.UseVisualStyleBackColor = true;
            this.PlayBtn.Click += new System.EventHandler(this.PlayBtn_Click);
            // 
            // PauseBtn
            // 
            this.PauseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PauseBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.PauseBtn.Location = new System.Drawing.Point(330, 306);
            this.PauseBtn.Name = "PauseBtn";
            this.PauseBtn.Size = new System.Drawing.Size(100, 23);
            this.PauseBtn.TabIndex = 3;
            this.PauseBtn.Text = "Pause";
            this.PauseBtn.UseVisualStyleBackColor = true;
            this.PauseBtn.Click += new System.EventHandler(this.PauseBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StopBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.StopBtn.Location = new System.Drawing.Point(436, 306);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(100, 23);
            this.StopBtn.TabIndex = 4;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // OpenBtn
            // 
            this.OpenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.OpenBtn.Location = new System.Drawing.Point(542, 306);
            this.OpenBtn.Name = "OpenBtn";
            this.OpenBtn.Size = new System.Drawing.Size(100, 23);
            this.OpenBtn.TabIndex = 5;
            this.OpenBtn.Text = "Open";
            this.OpenBtn.UseVisualStyleBackColor = true;
            this.OpenBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(12, 290);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(628, 10);
            this.ProgressBar.TabIndex = 6;
            this.ProgressBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ProgressBar_MouseDown);
            // 
            // TrackListLBox
            // 
            this.TrackListLBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TrackListLBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TrackListLBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.TrackListLBox.FormattingEnabled = true;
            this.TrackListLBox.Location = new System.Drawing.Point(216, 10);
            this.TrackListLBox.Name = "TrackListLBox";
            this.TrackListLBox.Size = new System.Drawing.Size(375, 195);
            this.TrackListLBox.TabIndex = 7;
            this.TrackListLBox.SelectedIndexChanged += new System.EventHandler(this.TrackListLBox_SelectedIndexChanged);
            // 
            // ArtPic
            // 
            this.ArtPic.Image = ((System.Drawing.Image)(resources.GetObject("ArtPic.Image")));
            this.ArtPic.Location = new System.Drawing.Point(12, 10);
            this.ArtPic.Name = "ArtPic";
            this.ArtPic.Size = new System.Drawing.Size(198, 198);
            this.ArtPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ArtPic.TabIndex = 8;
            this.ArtPic.TabStop = false;
            // 
            // PlayerWmp
            // 
            this.PlayerWmp.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlayerWmp.Enabled = true;
            this.PlayerWmp.Location = new System.Drawing.Point(0, 0);
            this.PlayerWmp.Name = "PlayerWmp";
            this.PlayerWmp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("PlayerWmp.OcxState")));
            this.PlayerWmp.Size = new System.Drawing.Size(653, 59);
            this.PlayerWmp.TabIndex = 9;
            // 
            // VolumeBar
            // 
            this.VolumeBar.Location = new System.Drawing.Point(597, 27);
            this.VolumeBar.Maximum = 100;
            this.VolumeBar.Name = "VolumeBar";
            this.VolumeBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.VolumeBar.Size = new System.Drawing.Size(45, 165);
            this.VolumeBar.TabIndex = 10;
            this.VolumeBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.VolumeBar.Scroll += new System.EventHandler(this.VolumeBar_Scroll);
            // 
            // VolumeLbl
            // 
            this.VolumeLbl.AutoSize = true;
            this.VolumeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VolumeLbl.ForeColor = System.Drawing.Color.White;
            this.VolumeLbl.Location = new System.Drawing.Point(594, 195);
            this.VolumeLbl.Name = "VolumeLbl";
            this.VolumeLbl.Size = new System.Drawing.Size(48, 13);
            this.VolumeLbl.TabIndex = 11;
            this.VolumeLbl.Text = "Volume";
            // 
            // VolumePorcentajeLbl
            // 
            this.VolumePorcentajeLbl.AutoSize = true;
            this.VolumePorcentajeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VolumePorcentajeLbl.ForeColor = System.Drawing.Color.White;
            this.VolumePorcentajeLbl.Location = new System.Drawing.Point(605, 10);
            this.VolumePorcentajeLbl.Name = "VolumePorcentajeLbl";
            this.VolumePorcentajeLbl.Size = new System.Drawing.Size(30, 13);
            this.VolumePorcentajeLbl.TabIndex = 12;
            this.VolumePorcentajeLbl.Text = "50%";
            // 
            // TrackStartLbl
            // 
            this.TrackStartLbl.AutoSize = true;
            this.TrackStartLbl.Font = new System.Drawing.Font("DigifaceWide", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackStartLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.TrackStartLbl.Location = new System.Drawing.Point(-7, 9);
            this.TrackStartLbl.Name = "TrackStartLbl";
            this.TrackStartLbl.Size = new System.Drawing.Size(125, 39);
            this.TrackStartLbl.TabIndex = 13;
            this.TrackStartLbl.Text = "00:00";
            // 
            // TrackEndLbl
            // 
            this.TrackEndLbl.AutoSize = true;
            this.TrackEndLbl.Font = new System.Drawing.Font("DigifaceWide", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackEndLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.TrackEndLbl.Location = new System.Drawing.Point(535, 9);
            this.TrackEndLbl.Name = "TrackEndLbl";
            this.TrackEndLbl.Size = new System.Drawing.Size(125, 39);
            this.TrackEndLbl.TabIndex = 14;
            this.TrackEndLbl.Text = "00:00";
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MainPanel.Controls.Add(this.VolumeBar);
            this.MainPanel.Controls.Add(this.VolumeLbl);
            this.MainPanel.Controls.Add(this.VolumePorcentajeLbl);
            this.MainPanel.Controls.Add(this.ArtPic);
            this.MainPanel.Controls.Add(this.TrackListLBox);
            this.MainPanel.Location = new System.Drawing.Point(0, 65);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(653, 217);
            this.MainPanel.TabIndex = 15;
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // MPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(653, 341);
            this.Controls.Add(this.TrackEndLbl);
            this.Controls.Add(this.TrackStartLbl);
            this.Controls.Add(this.PlayerWmp);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.OpenBtn);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.PauseBtn);
            this.Controls.Add(this.PlayBtn);
            this.Controls.Add(this.NextBtn);
            this.Controls.Add(this.PreviewBtn);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MPlayerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reproductor de Música";
            ((System.ComponentModel.ISupportInitialize)(this.ArtPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerWmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PreviewBtn;
        private System.Windows.Forms.Button NextBtn;
        private System.Windows.Forms.Button PlayBtn;
        private System.Windows.Forms.Button PauseBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Button OpenBtn;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.ListBox TrackListLBox;
        private System.Windows.Forms.PictureBox ArtPic;
        private AxWMPLib.AxWindowsMediaPlayer PlayerWmp;
        private System.Windows.Forms.TrackBar VolumeBar;
        private System.Windows.Forms.Label VolumeLbl;
        private System.Windows.Forms.Label VolumePorcentajeLbl;
        private System.Windows.Forms.Label TrackStartLbl;
        private System.Windows.Forms.Label TrackEndLbl;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Timer Timer;
    }
}

