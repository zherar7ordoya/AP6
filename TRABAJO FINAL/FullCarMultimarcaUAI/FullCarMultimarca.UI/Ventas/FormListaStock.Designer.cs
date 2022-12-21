
namespace FullCarMultimarca.UI.Ventas
{
    partial class FormListaStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListaStock));
            this.btnPonerUnidadEnOferta = new System.Windows.Forms.Button();
            this.btnAnularOferta = new System.Windows.Forms.Button();
            this.btnIniciarNuevaOperacion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(317, 350);
            this.btnEliminar.Visible = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(249, 350);
            this.btnAgregar.Visible = false;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(290, 350);
            this.btnModificar.Visible = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(697, 350);
            this.btnCerrar.TabIndex = 8;
            // 
            // panelContenedorGrilla
            // 
            this.panelContenedorGrilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContenedorGrilla.Size = new System.Drawing.Size(754, 262);
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
            this.ckIncluirInactivos.Location = new System.Drawing.Point(12, 419);
            this.ckIncluirInactivos.Visible = false;
            // 
            // lblRegistrosEncontrados
            // 
            this.lblRegistrosEncontrados.Location = new System.Drawing.Point(0, 370);
            // 
            // btnPonerUnidadEnOferta
            // 
            this.btnPonerUnidadEnOferta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPonerUnidadEnOferta.Image = global::FullCarMultimarca.UI.Properties.Resources.ofertas;
            this.btnPonerUnidadEnOferta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPonerUnidadEnOferta.Location = new System.Drawing.Point(499, 321);
            this.btnPonerUnidadEnOferta.Name = "btnPonerUnidadEnOferta";
            this.btnPonerUnidadEnOferta.Size = new System.Drawing.Size(154, 23);
            this.btnPonerUnidadEnOferta.TabIndex = 6;
            this.btnPonerUnidadEnOferta.Text = "Poner Unidad en Oferta";
            this.btnPonerUnidadEnOferta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPonerUnidadEnOferta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPonerUnidadEnOferta.UseVisualStyleBackColor = true;
            this.btnPonerUnidadEnOferta.Click += new System.EventHandler(this.btnPonerUnidadEnOferta_Click);
            // 
            // btnAnularOferta
            // 
            this.btnAnularOferta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnularOferta.Image = global::FullCarMultimarca.UI.Properties.Resources.delete2;
            this.btnAnularOferta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnularOferta.Location = new System.Drawing.Point(659, 321);
            this.btnAnularOferta.Name = "btnAnularOferta";
            this.btnAnularOferta.Size = new System.Drawing.Size(107, 23);
            this.btnAnularOferta.TabIndex = 7;
            this.btnAnularOferta.Text = "Anular Oferta";
            this.btnAnularOferta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnularOferta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnularOferta.UseVisualStyleBackColor = true;
            this.btnAnularOferta.Click += new System.EventHandler(this.btnAnularOferta_Click);
            // 
            // btnIniciarNuevaOperacion
            // 
            this.btnIniciarNuevaOperacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIniciarNuevaOperacion.Image = global::FullCarMultimarca.UI.Properties.Resources.contract;
            this.btnIniciarNuevaOperacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIniciarNuevaOperacion.Location = new System.Drawing.Point(12, 321);
            this.btnIniciarNuevaOperacion.Name = "btnIniciarNuevaOperacion";
            this.btnIniciarNuevaOperacion.Size = new System.Drawing.Size(169, 23);
            this.btnIniciarNuevaOperacion.TabIndex = 5;
            this.btnIniciarNuevaOperacion.Text = "Nueva Operación de Venta";
            this.btnIniciarNuevaOperacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIniciarNuevaOperacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIniciarNuevaOperacion.UseVisualStyleBackColor = true;
            this.btnIniciarNuevaOperacion.Click += new System.EventHandler(this.btnIniciarNuevaOperacion_Click);
            // 
            // FormListaStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 385);
            this.Controls.Add(this.btnIniciarNuevaOperacion);
            this.Controls.Add(this.btnAnularOferta);
            this.Controls.Add(this.btnPonerUnidadEnOferta);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormListaStock";
            this.ShowIcon = true;
            this.Text = "Stock de Unidades";
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
            this.Controls.SetChildIndex(this.btnPonerUnidadEnOferta, 0);
            this.Controls.SetChildIndex(this.btnAnularOferta, 0);
            this.Controls.SetChildIndex(this.btnIniciarNuevaOperacion, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPonerUnidadEnOferta;
        private System.Windows.Forms.Button btnAnularOferta;
        private System.Windows.Forms.Button btnIniciarNuevaOperacion;
    }
}