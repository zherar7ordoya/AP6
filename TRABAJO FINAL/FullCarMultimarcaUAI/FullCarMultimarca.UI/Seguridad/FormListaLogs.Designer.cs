namespace FullCarMultimarca.UI.Seguridad
{
    partial class FormListaLogs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListaLogs));
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.txtFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.txtFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(543, 4);
            this.btnActualizar.TabIndex = 3;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(437, 448);
            this.btnEliminar.Text = "Elimniar";
            this.btnEliminar.Visible = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(287, 448);
            this.btnAgregar.Visible = false;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(362, 448);
            this.btnModificar.Visible = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(623, 448);
            this.btnCerrar.TabIndex = 3;
            // 
            // panelContenedorGrilla
            // 
            this.panelContenedorGrilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContenedorGrilla.Location = new System.Drawing.Point(12, 81);
            this.panelContenedorGrilla.Size = new System.Drawing.Size(680, 361);
            // 
            // txtCriterioBusqueda
            // 
            this.txtCriterioBusqueda.Location = new System.Drawing.Point(134, 6);
            this.txtCriterioBusqueda.Size = new System.Drawing.Size(402, 20);
            this.txtCriterioBusqueda.TabIndex = 0;
            // 
            // cmbCampoBusqueda
            // 
            this.cmbCampoBusqueda.Location = new System.Drawing.Point(12, 6);
            this.cmbCampoBusqueda.Size = new System.Drawing.Size(116, 21);
            // 
            // btnRestablecer
            // 
            this.btnRestablecer.Location = new System.Drawing.Point(543, 29);
            this.btnRestablecer.TabIndex = 4;
            // 
            // lblInfoOrdenamientoGrillas
            // 
            this.lblInfoOrdenamientoGrillas.Location = new System.Drawing.Point(12, 65);
            this.lblInfoOrdenamientoGrillas.Size = new System.Drawing.Size(386, 13);
            this.lblInfoOrdenamientoGrillas.Text = "Puede Ordenar los elementos de la grilla haciendo click sobre cualquier columna";
            // 
            // ckIncluirInactivos
            // 
            this.ckIncluirInactivos.Location = new System.Drawing.Point(530, 60);
            this.ckIncluirInactivos.Size = new System.Drawing.Size(92, 17);
            this.ckIncluirInactivos.Text = "Incluir Activos";
            this.ckIncluirInactivos.Visible = false;
            // 
            // lblRegistrosEncontrados
            // 
            this.lblRegistrosEncontrados.Location = new System.Drawing.Point(0, 468);
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(131, 34);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(69, 13);
            this.lblDesde.TabIndex = 16;
            this.lblDesde.Text = "Fecha desde";
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(307, 34);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(33, 13);
            this.lblHasta.TabIndex = 17;
            this.lblHasta.Text = "hasta";
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaDesde.Location = new System.Drawing.Point(206, 32);
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.Size = new System.Drawing.Size(95, 20);
            this.txtFechaDesde.TabIndex = 1;
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaHasta.Location = new System.Drawing.Point(346, 32);
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(95, 20);
            this.txtFechaHasta.TabIndex = 2;
            // 
            // FormListaLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 483);
            this.Controls.Add(this.txtFechaHasta);
            this.Controls.Add(this.txtFechaDesde);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.lblDesde);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormListaLogs";
            this.ShowIcon = true;
            this.Text = "Logs del Sistema";
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
            this.Controls.SetChildIndex(this.lblDesde, 0);
            this.Controls.SetChildIndex(this.lblHasta, 0);
            this.Controls.SetChildIndex(this.txtFechaDesde, 0);
            this.Controls.SetChildIndex(this.txtFechaHasta, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker txtFechaDesde;
        private System.Windows.Forms.DateTimePicker txtFechaHasta;
    }
}