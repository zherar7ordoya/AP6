
namespace FullCarMultimarca.UI.Liquidaciones
{
    partial class FormListaLiquidaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListaLiquidaciones));
            this.SuspendLayout();
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(12, 12);
            this.btnActualizar.Size = new System.Drawing.Size(111, 23);
            this.btnActualizar.Text = "Actualizar...";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Location = new System.Drawing.Point(471, 263);
            this.btnEliminar.Size = new System.Drawing.Size(159, 23);
            this.btnEliminar.Text = "Eliminar Liquidación";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(148, 287);
            this.btnAgregar.Visible = false;
            // 
            // btnModificar
            // 
            this.btnModificar.Image = null;
            this.btnModificar.Location = new System.Drawing.Point(12, 263);
            this.btnModificar.Size = new System.Drawing.Size(111, 23);
            this.btnModificar.Text = "Ver Detalle";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(561, 305);
            // 
            // panelContenedorGrilla
            // 
            this.panelContenedorGrilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContenedorGrilla.Size = new System.Drawing.Size(618, 204);
            // 
            // txtCriterioBusqueda
            // 
            this.txtCriterioBusqueda.Location = new System.Drawing.Point(429, 14);
            this.txtCriterioBusqueda.Visible = false;
            // 
            // cmbCampoBusqueda
            // 
            this.cmbCampoBusqueda.Location = new System.Drawing.Point(410, 12);
            this.cmbCampoBusqueda.Visible = false;
            // 
            // btnRestablecer
            // 
            this.btnRestablecer.Location = new System.Drawing.Point(518, 12);
            this.btnRestablecer.Visible = false;
            // 
            // ckIncluirInactivos
            // 
            this.ckIncluirInactivos.Location = new System.Drawing.Point(536, 18);
            this.ckIncluirInactivos.Visible = false;
            // 
            // FormListaLiquidaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 340);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormListaLiquidaciones";
            this.ShowIcon = true;
            this.Text = "Lista de Liquidaciones";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}