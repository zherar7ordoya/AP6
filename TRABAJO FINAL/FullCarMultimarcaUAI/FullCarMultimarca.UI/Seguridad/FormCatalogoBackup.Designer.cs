
namespace FullCarMultimarca.UI.Seguridad
{
    partial class FormCatalogoBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCatalogoBackup));
            this.btnRestaurarBackup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(156, 312);
            this.btnActualizar.Size = new System.Drawing.Size(134, 23);
            this.btnActualizar.Visible = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(190, 233);
            this.btnEliminar.Size = new System.Drawing.Size(172, 23);
            this.btnEliminar.Text = "Eliminar backup seleccionado";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(12, 233);
            this.btnAgregar.Size = new System.Drawing.Size(172, 23);
            this.btnAgregar.Text = "Generar nuevo backup";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(53, 282);
            this.btnModificar.Size = new System.Drawing.Size(112, 23);
            this.btnModificar.Visible = false;
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
            this.panelContenedorGrilla.Location = new System.Drawing.Point(12, 25);
            this.panelContenedorGrilla.Size = new System.Drawing.Size(409, 202);
            // 
            // txtCriterioBusqueda
            // 
            this.txtCriterioBusqueda.Location = new System.Drawing.Point(50, 312);
            this.txtCriterioBusqueda.Size = new System.Drawing.Size(240, 20);
            this.txtCriterioBusqueda.Visible = false;
            // 
            // cmbCampoBusqueda
            // 
            this.cmbCampoBusqueda.Location = new System.Drawing.Point(75, 317);
            this.cmbCampoBusqueda.Size = new System.Drawing.Size(177, 21);
            this.cmbCampoBusqueda.Visible = false;
            // 
            // btnRestablecer
            // 
            this.btnRestablecer.Location = new System.Drawing.Point(181, 317);
            this.btnRestablecer.Size = new System.Drawing.Size(134, 23);
            this.btnRestablecer.Visible = false;
            // 
            // lblInfoOrdenamientoGrillas
            // 
            this.lblInfoOrdenamientoGrillas.Location = new System.Drawing.Point(12, 9);
            // 
            // ckIncluirInactivos
            // 
            this.ckIncluirInactivos.Location = new System.Drawing.Point(104, 317);
            this.ckIncluirInactivos.Visible = false;
            // 
            // btnRestaurarBackup
            // 
            this.btnRestaurarBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestaurarBackup.Image = global::FullCarMultimarca.UI.Properties.Resources.undo;
            this.btnRestaurarBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestaurarBackup.Location = new System.Drawing.Point(483, 233);
            this.btnRestaurarBackup.Name = "btnRestaurarBackup";
            this.btnRestaurarBackup.Size = new System.Drawing.Size(147, 36);
            this.btnRestaurarBackup.TabIndex = 19;
            this.btnRestaurarBackup.Text = "Restaurar desde Backup seleccionado...";
            this.btnRestaurarBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRestaurarBackup.UseVisualStyleBackColor = true;
            this.btnRestaurarBackup.Click += new System.EventHandler(this.btnRestaurarBackup_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(424, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.Location = new System.Drawing.Point(427, 25);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(203, 202);
            this.txtDescripcion.TabIndex = 21;
            this.txtDescripcion.TabStop = false;
            // 
            // FormCatalogoBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 340);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRestaurarBackup);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCatalogoBackup";
            this.ShowIcon = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catálogo de Backups del sistema";
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
            this.Controls.SetChildIndex(this.btnRestaurarBackup, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRestaurarBackup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescripcion;
    }
}