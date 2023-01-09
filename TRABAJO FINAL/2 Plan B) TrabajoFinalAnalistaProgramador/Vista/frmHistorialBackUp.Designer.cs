namespace Vista
{
    partial class frmHistorialBackUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistorialBackUp));
            this.dgv_HistorialBackUp = new System.Windows.Forms.DataGridView();
            this.txt_Busqueda = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HistorialBackUp)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_HistorialBackUp
            // 
            this.dgv_HistorialBackUp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_HistorialBackUp.Location = new System.Drawing.Point(33, 53);
            this.dgv_HistorialBackUp.Name = "dgv_HistorialBackUp";
            this.dgv_HistorialBackUp.Size = new System.Drawing.Size(298, 467);
            this.dgv_HistorialBackUp.TabIndex = 0;
            // 
            // txt_Busqueda
            // 
            this.txt_Busqueda.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Busqueda.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txt_Busqueda.Location = new System.Drawing.Point(33, 24);
            this.txt_Busqueda.Name = "txt_Busqueda";
            this.txt_Busqueda.Size = new System.Drawing.Size(298, 24);
            this.txt_Busqueda.TabIndex = 2;
            this.txt_Busqueda.Text = "Búsqueda por: Fecha";
            // 
            // frmHistorialBackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(367, 542);
            this.Controls.Add(this.txt_Busqueda);
            this.Controls.Add(this.dgv_HistorialBackUp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHistorialBackUp";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial Backup";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HistorialBackUp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_HistorialBackUp;
        private System.Windows.Forms.TextBox txt_Busqueda;
    }
}