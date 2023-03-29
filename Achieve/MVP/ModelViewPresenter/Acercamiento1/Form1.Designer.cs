using System.Windows.Forms;

namespace Acercamiento1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TboxLargo = new System.Windows.Forms.TextBox();
            this.TboxAncho = new System.Windows.Forms.TextBox();
            this.TboxArea = new System.Windows.Forms.TextBox();
            this.CmdCalcula = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TboxLargo
            // 
            this.TboxLargo.Location = new System.Drawing.Point(12, 12);
            this.TboxLargo.Name = "TboxLargo";
            this.TboxLargo.Size = new System.Drawing.Size(100, 23);
            this.TboxLargo.TabIndex = 0;
            this.TboxLargo.Text = "Largo";
            // 
            // TboxAncho
            // 
            this.TboxAncho.Location = new System.Drawing.Point(12, 41);
            this.TboxAncho.Name = "TboxAncho";
            this.TboxAncho.Size = new System.Drawing.Size(100, 23);
            this.TboxAncho.TabIndex = 1;
            this.TboxAncho.Text = "Ancho";
            // 
            // TboxArea
            // 
            this.TboxArea.Location = new System.Drawing.Point(12, 70);
            this.TboxArea.Name = "TboxArea";
            this.TboxArea.Size = new System.Drawing.Size(100, 23);
            this.TboxArea.TabIndex = 2;
            this.TboxArea.Text = "Area";
            // 
            // CmdCalcula
            // 
            this.CmdCalcula.Location = new System.Drawing.Point(12, 99);
            this.CmdCalcula.Name = "CmdCalcula";
            this.CmdCalcula.Size = new System.Drawing.Size(100, 25);
            this.CmdCalcula.TabIndex = 3;
            this.CmdCalcula.Text = "Calcula";
            this.CmdCalcula.UseVisualStyleBackColor = true;
            this.CmdCalcula.Click += new System.EventHandler(this.CmdCalcula_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(120, 157);
            this.Controls.Add(this.CmdCalcula);
            this.Controls.Add(this.TboxArea);
            this.Controls.Add(this.TboxAncho);
            this.Controls.Add(this.TboxLargo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox TboxLargo;
        private TextBox TboxAncho;
        private TextBox TboxArea;
        private Button CmdCalcula;
    }
}