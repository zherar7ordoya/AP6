
namespace FullCarMultimarca.UI.Ventas
{
    partial class FormListaOperacionesAAutorizar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListaOperacionesAAutorizar));
            this.btnAutorizarOperacion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(211, 370);
            this.btnEliminar.Visible = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(276, 370);
            this.btnAgregar.Visible = false;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(182, 370);
            this.btnModificar.Visible = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(705, 360);
            // 
            // panelContenedorGrilla
            // 
            this.panelContenedorGrilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContenedorGrilla.Size = new System.Drawing.Size(762, 270);
            // 
            // btnRestablecer
            // 
            this.btnRestablecer.TabIndex = 3;
            // 
            // lblInfoOrdenamientoGrillas
            // 
            this.lblInfoOrdenamientoGrillas.TabIndex = 4;
            // 
            // ckIncluirInactivos
            // 
            this.ckIncluirInactivos.Location = new System.Drawing.Point(267, 408);
            this.ckIncluirInactivos.Visible = false;
            // 
            // lblRegistrosEncontrados
            // 
            this.lblRegistrosEncontrados.Location = new System.Drawing.Point(0, 380);
            // 
            // btnAutorizarOperacion
            // 
            this.btnAutorizarOperacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutorizarOperacion.Image = global::FullCarMultimarca.UI.Properties.Resources.modifPalabraClave;
            this.btnAutorizarOperacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAutorizarOperacion.Location = new System.Drawing.Point(575, 329);
            this.btnAutorizarOperacion.Name = "btnAutorizarOperacion";
            this.btnAutorizarOperacion.Size = new System.Drawing.Size(199, 23);
            this.btnAutorizarOperacion.TabIndex = 5;
            this.btnAutorizarOperacion.Text = "Revisar Autorización Operación";
            this.btnAutorizarOperacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAutorizarOperacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAutorizarOperacion.UseVisualStyleBackColor = true;
            this.btnAutorizarOperacion.Click += new System.EventHandler(this.btnAutorizarOperacion_Click);
            // 
            // FormListaOperacionesAAutorizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 395);
            this.Controls.Add(this.btnAutorizarOperacion);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormListaOperacionesAAutorizar";
            this.ShowIcon = true;
            this.Text = "Operaciones Pendientes de Autorizar";
            this.Controls.SetChildIndex(this.lblRegistrosEncontrados, 0);
            this.Controls.SetChildIndex(this.btnActualizar, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.btnModificar, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.panelContenedorGrilla, 0);
            this.Controls.SetChildIndex(this.txtCriterioBusqueda, 0);
            this.Controls.SetChildIndex(this.cmbCampoBusqueda, 0);
            this.Controls.SetChildIndex(this.btnRestablecer, 0);
            this.Controls.SetChildIndex(this.lblInfoOrdenamientoGrillas, 0);
            this.Controls.SetChildIndex(this.ckIncluirInactivos, 0);
            this.Controls.SetChildIndex(this.btnAutorizarOperacion, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAutorizarOperacion;
    }
}