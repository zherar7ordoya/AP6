using AxWMPLib;

using System;

namespace MusicPlayer
{
    partial class ReproductorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReproductorForm));
            this.AnteriorBoton = new System.Windows.Forms.Button();
            this.SiguienteBoton = new System.Windows.Forms.Button();
            this.ReproducirBoton = new System.Windows.Forms.Button();
            this.PausarBoton = new System.Windows.Forms.Button();
            this.DetenerBoton = new System.Windows.Forms.Button();
            this.CargarBoton = new System.Windows.Forms.Button();
            this.PistaProgresoBarra = new System.Windows.Forms.ProgressBar();
            this.PistasLista = new System.Windows.Forms.ListBox();
            this.CubiertaPic = new System.Windows.Forms.PictureBox();
            this.VolumenBarra = new System.Windows.Forms.TrackBar();
            this.VolumenEtiqueta = new System.Windows.Forms.Label();
            this.NivelVolumenEtiqueta = new System.Windows.Forms.Label();
            this.PistaProgresoEtiqueta = new System.Windows.Forms.Label();
            this.PistaDuracionEtiqueta = new System.Windows.Forms.Label();
            this.Panel = new System.Windows.Forms.Panel();
            this.Temporizador = new System.Windows.Forms.Timer(this.components);
            this.Reproductor = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.CubiertaPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumenBarra)).BeginInit();
            this.Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Reproductor)).BeginInit();
            this.SuspendLayout();
            // 
            // AnteriorBoton
            // 
            this.AnteriorBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AnteriorBoton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.AnteriorBoton.Location = new System.Drawing.Point(12, 326);
            this.AnteriorBoton.Name = "AnteriorBoton";
            this.AnteriorBoton.Size = new System.Drawing.Size(100, 23);
            this.AnteriorBoton.TabIndex = 0;
            this.AnteriorBoton.Text = "Anterior";
            this.AnteriorBoton.UseVisualStyleBackColor = true;
            
            // 
            // SiguienteBoton
            // 
            this.SiguienteBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SiguienteBoton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.SiguienteBoton.Location = new System.Drawing.Point(118, 326);
            this.SiguienteBoton.Name = "SiguienteBoton";
            this.SiguienteBoton.Size = new System.Drawing.Size(100, 23);
            this.SiguienteBoton.TabIndex = 1;
            this.SiguienteBoton.Text = "Siguiente";
            this.SiguienteBoton.UseVisualStyleBackColor = true;
            
            // 
            // ReproducirBoton
            // 
            this.ReproducirBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReproducirBoton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ReproducirBoton.Location = new System.Drawing.Point(224, 326);
            this.ReproducirBoton.Name = "ReproducirBoton";
            this.ReproducirBoton.Size = new System.Drawing.Size(100, 23);
            this.ReproducirBoton.TabIndex = 2;
            this.ReproducirBoton.Text = "Reproducir";
            this.ReproducirBoton.UseVisualStyleBackColor = true;
            
            // 
            // PausarBoton
            // 
            this.PausarBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PausarBoton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.PausarBoton.Location = new System.Drawing.Point(330, 326);
            this.PausarBoton.Name = "PausarBoton";
            this.PausarBoton.Size = new System.Drawing.Size(100, 23);
            this.PausarBoton.TabIndex = 3;
            this.PausarBoton.Text = "Pausar";
            this.PausarBoton.UseVisualStyleBackColor = true;
            
            // 
            // DetenerBoton
            // 
            this.DetenerBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DetenerBoton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.DetenerBoton.Location = new System.Drawing.Point(436, 326);
            this.DetenerBoton.Name = "DetenerBoton";
            this.DetenerBoton.Size = new System.Drawing.Size(100, 23);
            this.DetenerBoton.TabIndex = 4;
            this.DetenerBoton.Text = "Detener";
            this.DetenerBoton.UseVisualStyleBackColor = true;
            
            // 
            // CargarBoton
            // 
            this.CargarBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CargarBoton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.CargarBoton.Location = new System.Drawing.Point(542, 326);
            this.CargarBoton.Name = "CargarBoton";
            this.CargarBoton.Size = new System.Drawing.Size(100, 23);
            this.CargarBoton.TabIndex = 5;
            this.CargarBoton.Text = "Cargar";
            this.CargarBoton.UseVisualStyleBackColor = true;
            
            // 
            // PistaProgresoBarra
            // 
            this.PistaProgresoBarra.Location = new System.Drawing.Point(12, 300);
            this.PistaProgresoBarra.Name = "PistaProgresoBarra";
            this.PistaProgresoBarra.Size = new System.Drawing.Size(628, 20);
            this.PistaProgresoBarra.TabIndex = 6;
            
            // 
            // PistasLista
            // 
            this.PistasLista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PistasLista.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PistasLista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.PistasLista.FormattingEnabled = true;
            this.PistasLista.Location = new System.Drawing.Point(209, 3);
            this.PistasLista.Name = "PistasLista";
            this.PistasLista.Size = new System.Drawing.Size(379, 195);
            this.PistasLista.TabIndex = 7;
            
            // 
            // CubiertaPic
            // 
            this.CubiertaPic.Image = ((System.Drawing.Image)(resources.GetObject("CubiertaPic.Image")));
            this.CubiertaPic.Location = new System.Drawing.Point(3, 3);
            this.CubiertaPic.Name = "CubiertaPic";
            this.CubiertaPic.Size = new System.Drawing.Size(200, 200);
            this.CubiertaPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CubiertaPic.TabIndex = 8;
            this.CubiertaPic.TabStop = false;
            // 
            // VolumenBarra
            // 
            this.VolumenBarra.Location = new System.Drawing.Point(605, 19);
            this.VolumenBarra.Maximum = 100;
            this.VolumenBarra.Name = "VolumenBarra";
            this.VolumenBarra.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.VolumenBarra.Size = new System.Drawing.Size(45, 168);
            this.VolumenBarra.TabIndex = 10;
            this.VolumenBarra.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            
            // 
            // VolumenEtiqueta
            // 
            this.VolumenEtiqueta.AutoSize = true;
            this.VolumenEtiqueta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VolumenEtiqueta.ForeColor = System.Drawing.Color.White;
            this.VolumenEtiqueta.Location = new System.Drawing.Point(594, 190);
            this.VolumenEtiqueta.Name = "VolumenEtiqueta";
            this.VolumenEtiqueta.Size = new System.Drawing.Size(48, 13);
            this.VolumenEtiqueta.TabIndex = 11;
            this.VolumenEtiqueta.Text = "Volume";
            // 
            // NivelVolumenEtiqueta
            // 
            this.NivelVolumenEtiqueta.AutoSize = true;
            this.NivelVolumenEtiqueta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NivelVolumenEtiqueta.ForeColor = System.Drawing.Color.White;
            this.NivelVolumenEtiqueta.Location = new System.Drawing.Point(608, 3);
            this.NivelVolumenEtiqueta.Name = "NivelVolumenEtiqueta";
            this.NivelVolumenEtiqueta.Size = new System.Drawing.Size(30, 13);
            this.NivelVolumenEtiqueta.TabIndex = 12;
            this.NivelVolumenEtiqueta.Text = "50%";
            // 
            // PistaProgresoEtiqueta
            // 
            this.PistaProgresoEtiqueta.AutoSize = true;
            this.PistaProgresoEtiqueta.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PistaProgresoEtiqueta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.PistaProgresoEtiqueta.Location = new System.Drawing.Point(5, 9);
            this.PistaProgresoEtiqueta.Name = "PistaProgresoEtiqueta";
            this.PistaProgresoEtiqueta.Size = new System.Drawing.Size(103, 37);
            this.PistaProgresoEtiqueta.TabIndex = 13;
            this.PistaProgresoEtiqueta.Text = "00:00";
            // 
            // PistaDuracionEtiqueta
            // 
            this.PistaDuracionEtiqueta.AutoSize = true;
            this.PistaDuracionEtiqueta.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PistaDuracionEtiqueta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.PistaDuracionEtiqueta.Location = new System.Drawing.Point(539, 9);
            this.PistaDuracionEtiqueta.Name = "PistaDuracionEtiqueta";
            this.PistaDuracionEtiqueta.Size = new System.Drawing.Size(103, 37);
            this.PistaDuracionEtiqueta.TabIndex = 14;
            this.PistaDuracionEtiqueta.Text = "00:00";
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Panel.Controls.Add(this.VolumenBarra);
            this.Panel.Controls.Add(this.VolumenEtiqueta);
            this.Panel.Controls.Add(this.NivelVolumenEtiqueta);
            this.Panel.Controls.Add(this.CubiertaPic);
            this.Panel.Controls.Add(this.PistasLista);
            this.Panel.Location = new System.Drawing.Point(0, 81);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(653, 213);
            this.Panel.TabIndex = 15;
            // 
            // Temporizador
            // 
            this.Temporizador.Enabled = true;
            
            // 
            // Reproductor
            // 
            this.Reproductor.Dock = System.Windows.Forms.DockStyle.Top;
            this.Reproductor.Enabled = true;
            this.Reproductor.Location = new System.Drawing.Point(0, 0);
            this.Reproductor.Name = "Reproductor";
            this.Reproductor.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Reproductor.OcxState")));
            this.Reproductor.Size = new System.Drawing.Size(650, 75);
            this.Reproductor.TabIndex = 16;
            // 
            // ReproductorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(650, 361);
            this.Controls.Add(this.PistaDuracionEtiqueta);
            this.Controls.Add(this.PistaProgresoEtiqueta);
            this.Controls.Add(this.PistaProgresoBarra);
            this.Controls.Add(this.CargarBoton);
            this.Controls.Add(this.DetenerBoton);
            this.Controls.Add(this.PausarBoton);
            this.Controls.Add(this.ReproducirBoton);
            this.Controls.Add(this.SiguienteBoton);
            this.Controls.Add(this.AnteriorBoton);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.Reproductor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReproductorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reproductor de Música";
            ((System.ComponentModel.ISupportInitialize)(this.CubiertaPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumenBarra)).EndInit();
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Reproductor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AnteriorBoton;
        private System.Windows.Forms.Button SiguienteBoton;
        private System.Windows.Forms.Button ReproducirBoton;
        private System.Windows.Forms.Button PausarBoton;
        private System.Windows.Forms.Button DetenerBoton;
        private System.Windows.Forms.Button CargarBoton;
        private System.Windows.Forms.ProgressBar PistaProgresoBarra;
        private System.Windows.Forms.ListBox PistasLista;
        private System.Windows.Forms.PictureBox CubiertaPic;
        private System.Windows.Forms.TrackBar VolumenBarra;
        private System.Windows.Forms.Label VolumenEtiqueta;
        private System.Windows.Forms.Label NivelVolumenEtiqueta;
        private System.Windows.Forms.Label PistaProgresoEtiqueta;
        private System.Windows.Forms.Label PistaDuracionEtiqueta;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.Timer Temporizador;
        private AxWMPLib.AxWindowsMediaPlayer Reproductor;
    }
}

