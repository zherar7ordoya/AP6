
namespace FullCarMultimarca.UI.Ventas
{
    partial class FormListaOperaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListaOperaciones));
            this.txtFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.txtFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNotaRechazo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEnviarPorMailOperacion = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(514, 10);
            this.btnActualizar.TabIndex = 6;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(97, 385);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Text = "Anular";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(705, 43);
            this.btnAgregar.Visible = false;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(12, 385);
            this.btnModificar.TabIndex = 9;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(721, 430);
            this.btnCerrar.TabIndex = 13;
            // 
            // panelContenedorGrilla
            // 
            this.panelContenedorGrilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContenedorGrilla.Location = new System.Drawing.Point(12, 90);
            this.panelContenedorGrilla.Size = new System.Drawing.Size(772, 289);
            // 
            // btnRestablecer
            // 
            this.btnRestablecer.Location = new System.Drawing.Point(514, 36);
            this.btnRestablecer.TabIndex = 7;
            // 
            // lblInfoOrdenamientoGrillas
            // 
            this.lblInfoOrdenamientoGrillas.Location = new System.Drawing.Point(12, 74);
            this.lblInfoOrdenamientoGrillas.TabIndex = 8;
            // 
            // ckIncluirInactivos
            // 
            this.ckIncluirInactivos.Location = new System.Drawing.Point(384, 15);
            this.ckIncluirInactivos.Size = new System.Drawing.Size(101, 17);
            this.ckIncluirInactivos.TabIndex = 2;
            this.ckIncluirInactivos.Text = "Incluir Anuladas";
            // 
            // lblRegistrosEncontrados
            // 
            this.lblRegistrosEncontrados.Location = new System.Drawing.Point(0, 450);
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaHasta.Location = new System.Drawing.Point(227, 39);
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(95, 20);
            this.txtFechaHasta.TabIndex = 4;
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaDesde.Location = new System.Drawing.Point(87, 39);
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.Size = new System.Drawing.Size(95, 20);
            this.txtFechaDesde.TabIndex = 3;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(188, 43);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(33, 13);
            this.lblHasta.TabIndex = 22;
            this.lblHasta.Text = "hasta";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(12, 43);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(69, 13);
            this.lblDesde.TabIndex = 21;
            this.lblDesde.Text = "Fecha desde";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(382, 38);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(126, 21);
            this.cmbEstado.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Estado";
            // 
            // txtNotaRechazo
            // 
            this.txtNotaRechazo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotaRechazo.Location = new System.Drawing.Point(279, 385);
            this.txtNotaRechazo.Multiline = true;
            this.txtNotaRechazo.Name = "txtNotaRechazo";
            this.txtNotaRechazo.ReadOnly = true;
            this.txtNotaRechazo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotaRechazo.Size = new System.Drawing.Size(249, 73);
            this.txtNotaRechazo.TabIndex = 26;
            this.txtNotaRechazo.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 390);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Nota de Rechazo";
            // 
            // btnEnviarPorMailOperacion
            // 
            this.btnEnviarPorMailOperacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviarPorMailOperacion.Image = global::FullCarMultimarca.UI.Properties.Resources.mail_forward;
            this.btnEnviarPorMailOperacion.Location = new System.Drawing.Point(620, 385);
            this.btnEnviarPorMailOperacion.Name = "btnEnviarPorMailOperacion";
            this.btnEnviarPorMailOperacion.Size = new System.Drawing.Size(164, 23);
            this.btnEnviarPorMailOperacion.TabIndex = 12;
            this.btnEnviarPorMailOperacion.Text = "Enviar por mail al Cliente";
            this.btnEnviarPorMailOperacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviarPorMailOperacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEnviarPorMailOperacion.UseVisualStyleBackColor = true;
            this.btnEnviarPorMailOperacion.Click += new System.EventHandler(this.btnEnviarPorMailOperacion_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.Image = global::FullCarMultimarca.UI.Properties.Resources.impresora;
            this.btnImprimir.Location = new System.Drawing.Point(534, 385);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(81, 23);
            this.btnImprimir.TabIndex = 11;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // FormListaOperaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 465);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnEnviarPorMailOperacion);
            this.Controls.Add(this.txtNotaRechazo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.txtFechaHasta);
            this.Controls.Add(this.txtFechaDesde);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.lblDesde);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormListaOperaciones";
            this.ShowIcon = true;
            this.Text = "Lista de Operaciones";
            this.Controls.SetChildIndex(this.lblRegistrosEncontrados, 0);
            this.Controls.SetChildIndex(this.lblDesde, 0);
            this.Controls.SetChildIndex(this.lblHasta, 0);
            this.Controls.SetChildIndex(this.txtFechaDesde, 0);
            this.Controls.SetChildIndex(this.txtFechaHasta, 0);
            this.Controls.SetChildIndex(this.cmbEstado, 0);
            this.Controls.SetChildIndex(this.label1, 0);
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
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtNotaRechazo, 0);
            this.Controls.SetChildIndex(this.btnEnviarPorMailOperacion, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker txtFechaHasta;
        private System.Windows.Forms.DateTimePicker txtFechaDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblDesde;
        public System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNotaRechazo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEnviarPorMailOperacion;
        private System.Windows.Forms.Button btnImprimir;
    }
}