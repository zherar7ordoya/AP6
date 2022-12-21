namespace FullCarMultimarca.UI.Seguridad
{
    partial class FormListaUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListaUsuarios));
            this.btnRestablecerClave = new System.Windows.Forms.Button();
            this.btnDesbloquear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(183, 346);
            this.btnEliminar.TabIndex = 6;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(13, 346);
            this.btnAgregar.TabIndex = 4;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(98, 346);
            this.btnModificar.TabIndex = 5;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(635, 398);
            this.btnCerrar.TabIndex = 9;
            // 
            // panelContenedorGrilla
            // 
            this.panelContenedorGrilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContenedorGrilla.Location = new System.Drawing.Point(12, 72);
            this.panelContenedorGrilla.Size = new System.Drawing.Size(692, 268);
            // 
            // btnRestablecer
            // 
            this.btnRestablecer.Location = new System.Drawing.Point(482, 12);
            this.btnRestablecer.TabIndex = 3;
            // 
            // lblInfoOrdenamientoGrillas
            // 
            this.lblInfoOrdenamientoGrillas.Location = new System.Drawing.Point(12, 56);
            // 
            // ckIncluirInactivos
            // 
            this.ckIncluirInactivos.Location = new System.Drawing.Point(269, 36);
            // 
            // lblRegistrosEncontrados
            // 
            this.lblRegistrosEncontrados.Location = new System.Drawing.Point(0, 418);
            // 
            // btnRestablecerClave
            // 
            this.btnRestablecerClave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestablecerClave.Location = new System.Drawing.Point(590, 346);
            this.btnRestablecerClave.Name = "btnRestablecerClave";
            this.btnRestablecerClave.Size = new System.Drawing.Size(114, 23);
            this.btnRestablecerClave.TabIndex = 8;
            this.btnRestablecerClave.Text = "Restablecer Clave";
            this.btnRestablecerClave.UseVisualStyleBackColor = true;
            this.btnRestablecerClave.Click += new System.EventHandler(this.btnRestablecerClave_Click);
            // 
            // btnDesbloquear
            // 
            this.btnDesbloquear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesbloquear.Location = new System.Drawing.Point(470, 346);
            this.btnDesbloquear.Name = "btnDesbloquear";
            this.btnDesbloquear.Size = new System.Drawing.Size(114, 23);
            this.btnDesbloquear.TabIndex = 7;
            this.btnDesbloquear.Text = "Desbloquear";
            this.btnDesbloquear.UseVisualStyleBackColor = true;
            this.btnDesbloquear.Click += new System.EventHandler(this.btnDesbloquear_Click);
            // 
            // FormListaUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 433);
            this.Controls.Add(this.btnDesbloquear);
            this.Controls.Add(this.btnRestablecerClave);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormListaUsuarios";
            this.ShowIcon = true;
            this.Text = "Lista de Usuarios";
            this.Controls.SetChildIndex(this.lblRegistrosEncontrados, 0);
            this.Controls.SetChildIndex(this.ckIncluirInactivos, 0);
            this.Controls.SetChildIndex(this.lblInfoOrdenamientoGrillas, 0);
            this.Controls.SetChildIndex(this.btnRestablecer, 0);
            this.Controls.SetChildIndex(this.txtCriterioBusqueda, 0);
            this.Controls.SetChildIndex(this.cmbCampoBusqueda, 0);
            this.Controls.SetChildIndex(this.btnActualizar, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.btnModificar, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.panelContenedorGrilla, 0);
            this.Controls.SetChildIndex(this.btnRestablecerClave, 0);
            this.Controls.SetChildIndex(this.btnDesbloquear, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRestablecerClave;
        private System.Windows.Forms.Button btnDesbloquear;
    }
}