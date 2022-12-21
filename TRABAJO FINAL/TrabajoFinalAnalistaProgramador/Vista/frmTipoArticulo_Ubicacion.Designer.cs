namespace Vista
{
    partial class frmTipoArticulo_Ubicacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTipoArticulo_Ubicacion));
            this.dgv_Articulos = new System.Windows.Forms.DataGridView();
            this.btn_VerificarTipoUbicacion = new System.Windows.Forms.Button();
            this.txt_Busqueda = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Articulos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Articulos
            // 
            this.dgv_Articulos.AllowUserToOrderColumns = true;
            this.dgv_Articulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Articulos.Location = new System.Drawing.Point(12, 49);
            this.dgv_Articulos.Name = "dgv_Articulos";
            this.dgv_Articulos.Size = new System.Drawing.Size(945, 405);
            this.dgv_Articulos.TabIndex = 0;
            // 
            // btn_VerificarTipoUbicacion
            // 
            this.btn_VerificarTipoUbicacion.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_VerificarTipoUbicacion.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_VerificarTipoUbicacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_VerificarTipoUbicacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_VerificarTipoUbicacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_VerificarTipoUbicacion.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_VerificarTipoUbicacion.ForeColor = System.Drawing.Color.White;
            this.btn_VerificarTipoUbicacion.Location = new System.Drawing.Point(410, 469);
            this.btn_VerificarTipoUbicacion.Name = "btn_VerificarTipoUbicacion";
            this.btn_VerificarTipoUbicacion.Size = new System.Drawing.Size(150, 37);
            this.btn_VerificarTipoUbicacion.TabIndex = 2;
            this.btn_VerificarTipoUbicacion.Text = "Tipo y Ubicación";
            this.btn_VerificarTipoUbicacion.UseVisualStyleBackColor = false;
            // 
            // txt_Busqueda
            // 
            this.txt_Busqueda.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Busqueda.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txt_Busqueda.Location = new System.Drawing.Point(13, 18);
            this.txt_Busqueda.Name = "txt_Busqueda";
            this.txt_Busqueda.Size = new System.Drawing.Size(944, 24);
            this.txt_Busqueda.TabIndex = 4;
            this.txt_Busqueda.Text = "Búsqueda por: Nombre";
            // 
            // frmTipoArticulo_Ubicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(974, 521);
            this.Controls.Add(this.txt_Busqueda);
            this.Controls.Add(this.btn_VerificarTipoUbicacion);
            this.Controls.Add(this.dgv_Articulos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTipoArticulo_Ubicacion";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipo y ubicación de artículo";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Articulos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Articulos;
        private System.Windows.Forms.Button btn_VerificarTipoUbicacion;
        private System.Windows.Forms.TextBox txt_Busqueda;
    }
}