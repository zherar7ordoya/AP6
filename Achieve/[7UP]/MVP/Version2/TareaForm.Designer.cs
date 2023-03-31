namespace Version2
{
    partial class TareaForm
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
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.NombreCtrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PrioridadCtrl = new System.Windows.Forms.ComboBox();
            this.FechaComienzoCtrl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FechaVencimientoCtrl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FechaTerminacionCtrl = new System.Windows.Forms.TextBox();
            this.SiguienteBtn = new System.Windows.Forms.Button();
            this.AnteriorBtn = new System.Windows.Forms.Button();
            this.AgregarBtn = new System.Windows.Forms.Button();
            this.GuardarBtn = new System.Windows.Forms.Button();
            this.CompletadaCtrl = new System.Windows.Forms.CheckBox();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 189);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(434, 22);
            this.StatusStrip.TabIndex = 0;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(94, 17);
            this.StatusLabel.Text = "Gerardo Tordoya";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // NombreCtrl
            // 
            this.NombreCtrl.Location = new System.Drawing.Point(12, 25);
            this.NombreCtrl.Name = "NombreCtrl";
            this.NombreCtrl.Size = new System.Drawing.Size(121, 20);
            this.NombreCtrl.TabIndex = 2;
            this.NombreCtrl.TextChanged += new System.EventHandler(this.NombreCtrl_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Prioridad";
            // 
            // PrioridadCtrl
            // 
            this.PrioridadCtrl.FormattingEnabled = true;
            this.PrioridadCtrl.Items.AddRange(new object[] {
            "Alta",
            "Media",
            "Baja"});
            this.PrioridadCtrl.Location = new System.Drawing.Point(12, 64);
            this.PrioridadCtrl.Name = "PrioridadCtrl";
            this.PrioridadCtrl.Size = new System.Drawing.Size(121, 21);
            this.PrioridadCtrl.TabIndex = 4;
            this.PrioridadCtrl.SelectedIndexChanged += new System.EventHandler(this.PrioridadCtrl_SelectedIndexChanged);
            // 
            // FechaComienzoCtrl
            // 
            this.FechaComienzoCtrl.Location = new System.Drawing.Point(301, 25);
            this.FechaComienzoCtrl.Name = "FechaComienzoCtrl";
            this.FechaComienzoCtrl.Size = new System.Drawing.Size(121, 20);
            this.FechaComienzoCtrl.TabIndex = 5;
            this.FechaComienzoCtrl.TextChanged += new System.EventHandler(this.FechaComienzoCtrl_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(301, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fecha de comienzo";
            // 
            // FechaVencimientoCtrl
            // 
            this.FechaVencimientoCtrl.Location = new System.Drawing.Point(301, 65);
            this.FechaVencimientoCtrl.Name = "FechaVencimientoCtrl";
            this.FechaVencimientoCtrl.Size = new System.Drawing.Size(121, 20);
            this.FechaVencimientoCtrl.TabIndex = 7;
            this.FechaVencimientoCtrl.TextChanged += new System.EventHandler(this.FechaVencimientoCtrl_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(301, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fecha de vencimiento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(298, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Fecha de terminación";
            // 
            // FechaTerminacionCtrl
            // 
            this.FechaTerminacionCtrl.Location = new System.Drawing.Point(301, 104);
            this.FechaTerminacionCtrl.Name = "FechaTerminacionCtrl";
            this.FechaTerminacionCtrl.Size = new System.Drawing.Size(121, 20);
            this.FechaTerminacionCtrl.TabIndex = 10;
            this.FechaTerminacionCtrl.TextChanged += new System.EventHandler(this.FechaTerminacionCtrl_TextChanged);
            // 
            // SiguienteBtn
            // 
            this.SiguienteBtn.Location = new System.Drawing.Point(347, 145);
            this.SiguienteBtn.Name = "SiguienteBtn";
            this.SiguienteBtn.Size = new System.Drawing.Size(75, 23);
            this.SiguienteBtn.TabIndex = 11;
            this.SiguienteBtn.Text = "Siguiente";
            this.SiguienteBtn.UseVisualStyleBackColor = true;
            this.SiguienteBtn.Click += new System.EventHandler(this.SiguienteBtn_Click);
            // 
            // AnteriorBtn
            // 
            this.AnteriorBtn.Location = new System.Drawing.Point(266, 145);
            this.AnteriorBtn.Name = "AnteriorBtn";
            this.AnteriorBtn.Size = new System.Drawing.Size(75, 23);
            this.AnteriorBtn.TabIndex = 12;
            this.AnteriorBtn.Text = "Anterior";
            this.AnteriorBtn.UseVisualStyleBackColor = true;
            this.AnteriorBtn.Click += new System.EventHandler(this.AnteriorBtn_Click);
            // 
            // AgregarBtn
            // 
            this.AgregarBtn.Location = new System.Drawing.Point(12, 145);
            this.AgregarBtn.Name = "AgregarBtn";
            this.AgregarBtn.Size = new System.Drawing.Size(75, 23);
            this.AgregarBtn.TabIndex = 13;
            this.AgregarBtn.Text = "Agregar";
            this.AgregarBtn.UseVisualStyleBackColor = true;
            this.AgregarBtn.Click += new System.EventHandler(this.AgregarBtn_Click);
            // 
            // GuardarBtn
            // 
            this.GuardarBtn.Location = new System.Drawing.Point(93, 145);
            this.GuardarBtn.Name = "GuardarBtn";
            this.GuardarBtn.Size = new System.Drawing.Size(75, 23);
            this.GuardarBtn.TabIndex = 14;
            this.GuardarBtn.Text = "Guardar";
            this.GuardarBtn.UseVisualStyleBackColor = true;
            this.GuardarBtn.Click += new System.EventHandler(this.GuardarBtn_Click);
            // 
            // CompletadaCtrl
            // 
            this.CompletadaCtrl.AutoSize = true;
            this.CompletadaCtrl.Location = new System.Drawing.Point(213, 106);
            this.CompletadaCtrl.Name = "CompletadaCtrl";
            this.CompletadaCtrl.Size = new System.Drawing.Size(82, 17);
            this.CompletadaCtrl.TabIndex = 15;
            this.CompletadaCtrl.Text = "Completada";
            this.CompletadaCtrl.UseVisualStyleBackColor = true;
            this.CompletadaCtrl.CheckedChanged += new System.EventHandler(this.CompletadaCtrl_CheckedChanged);
            // 
            // TareaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 211);
            this.Controls.Add(this.CompletadaCtrl);
            this.Controls.Add(this.GuardarBtn);
            this.Controls.Add(this.AgregarBtn);
            this.Controls.Add(this.AnteriorBtn);
            this.Controls.Add(this.SiguienteBtn);
            this.Controls.Add(this.FechaTerminacionCtrl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FechaVencimientoCtrl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FechaComienzoCtrl);
            this.Controls.Add(this.PrioridadCtrl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NombreCtrl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StatusStrip);
            this.Name = "TareaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TareaForm";
            this.Load += new System.EventHandler(this.TareaForm_Load);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NombreCtrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox PrioridadCtrl;
        private System.Windows.Forms.TextBox FechaComienzoCtrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FechaVencimientoCtrl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox FechaTerminacionCtrl;
        private System.Windows.Forms.Button SiguienteBtn;
        private System.Windows.Forms.Button AnteriorBtn;
        private System.Windows.Forms.Button AgregarBtn;
        private System.Windows.Forms.Button GuardarBtn;
        private System.Windows.Forms.CheckBox CompletadaCtrl;
    }
}