
namespace FullCarMultimarca.UI.Liquidaciones
{
    partial class FormLiquidarComisiones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLiquidarComisiones));
            this.label1 = new System.Windows.Forms.Label();
            this.txtFechaLiquidacion = new System.Windows.Forms.TextBox();
            this.txtCodigoLiquidacion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComentariosLiquidacion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnModificarParametrosLiquidacion = new System.Windows.Forms.Button();
            this.btnGenerarLiquidacion = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRemoverOperacion = new System.Windows.Forms.Button();
            this.grillaOperacionesALiquidar = new System.Windows.Forms.DataGridView();
            this.txtTtlOpALiquidar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grillaOperacionesALiquidar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Liquidación";
            // 
            // txtFechaLiquidacion
            // 
            this.txtFechaLiquidacion.Location = new System.Drawing.Point(115, 18);
            this.txtFechaLiquidacion.Name = "txtFechaLiquidacion";
            this.txtFechaLiquidacion.ReadOnly = true;
            this.txtFechaLiquidacion.Size = new System.Drawing.Size(157, 20);
            this.txtFechaLiquidacion.TabIndex = 1;
            this.txtFechaLiquidacion.TabStop = false;
            // 
            // txtCodigoLiquidacion
            // 
            this.txtCodigoLiquidacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoLiquidacion.Location = new System.Drawing.Point(115, 44);
            this.txtCodigoLiquidacion.MaxLength = 10;
            this.txtCodigoLiquidacion.Name = "txtCodigoLiquidacion";
            this.txtCodigoLiquidacion.Size = new System.Drawing.Size(157, 20);
            this.txtCodigoLiquidacion.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Código Liquidacion";
            // 
            // txtComentariosLiquidacion
            // 
            this.txtComentariosLiquidacion.AcceptsReturn = true;
            this.txtComentariosLiquidacion.Location = new System.Drawing.Point(115, 70);
            this.txtComentariosLiquidacion.MaxLength = 500;
            this.txtComentariosLiquidacion.Multiline = true;
            this.txtComentariosLiquidacion.Name = "txtComentariosLiquidacion";
            this.txtComentariosLiquidacion.Size = new System.Drawing.Size(744, 60);
            this.txtComentariosLiquidacion.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Comentarios";
            // 
            // btnModificarParametrosLiquidacion
            // 
            this.btnModificarParametrosLiquidacion.Location = new System.Drawing.Point(653, 16);
            this.btnModificarParametrosLiquidacion.Name = "btnModificarParametrosLiquidacion";
            this.btnModificarParametrosLiquidacion.Size = new System.Drawing.Size(208, 23);
            this.btnModificarParametrosLiquidacion.TabIndex = 2;
            this.btnModificarParametrosLiquidacion.Text = "Modificar Parámetros Liquidación";
            this.btnModificarParametrosLiquidacion.UseVisualStyleBackColor = true;
            this.btnModificarParametrosLiquidacion.Click += new System.EventHandler(this.btnModificarParametrosLiquidacion_Click);
            // 
            // btnGenerarLiquidacion
            // 
            this.btnGenerarLiquidacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerarLiquidacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGenerarLiquidacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarLiquidacion.Location = new System.Drawing.Point(651, 450);
            this.btnGenerarLiquidacion.Name = "btnGenerarLiquidacion";
            this.btnGenerarLiquidacion.Size = new System.Drawing.Size(208, 23);
            this.btnGenerarLiquidacion.TabIndex = 5;
            this.btnGenerarLiquidacion.Text = "Generar Liquidación";
            this.btnGenerarLiquidacion.UseVisualStyleBackColor = false;
            this.btnGenerarLiquidacion.Click += new System.EventHandler(this.btnGenerarLiquidacion_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(15, 450);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(94, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnRemoverOperacion
            // 
            this.btnRemoverOperacion.Image = global::FullCarMultimarca.UI.Properties.Resources.delete2;
            this.btnRemoverOperacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoverOperacion.Location = new System.Drawing.Point(15, 135);
            this.btnRemoverOperacion.Name = "btnRemoverOperacion";
            this.btnRemoverOperacion.Size = new System.Drawing.Size(208, 23);
            this.btnRemoverOperacion.TabIndex = 3;
            this.btnRemoverOperacion.Text = "Remover Operación Seleccionada";
            this.btnRemoverOperacion.UseVisualStyleBackColor = true;
            this.btnRemoverOperacion.Click += new System.EventHandler(this.btnRemoverOperacion_Click);
            // 
            // grillaOperacionesALiquidar
            // 
            this.grillaOperacionesALiquidar.AllowUserToAddRows = false;
            this.grillaOperacionesALiquidar.AllowUserToDeleteRows = false;
            this.grillaOperacionesALiquidar.AllowUserToResizeColumns = false;
            this.grillaOperacionesALiquidar.AllowUserToResizeRows = false;
            this.grillaOperacionesALiquidar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grillaOperacionesALiquidar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grillaOperacionesALiquidar.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.grillaOperacionesALiquidar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaOperacionesALiquidar.Location = new System.Drawing.Point(15, 164);
            this.grillaOperacionesALiquidar.MultiSelect = false;
            this.grillaOperacionesALiquidar.Name = "grillaOperacionesALiquidar";
            this.grillaOperacionesALiquidar.ReadOnly = true;
            this.grillaOperacionesALiquidar.RowHeadersVisible = false;
            this.grillaOperacionesALiquidar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaOperacionesALiquidar.Size = new System.Drawing.Size(844, 244);
            this.grillaOperacionesALiquidar.TabIndex = 4;
            this.grillaOperacionesALiquidar.TabStop = false;
            // 
            // txtTtlOpALiquidar
            // 
            this.txtTtlOpALiquidar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTtlOpALiquidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTtlOpALiquidar.Location = new System.Drawing.Point(763, 414);
            this.txtTtlOpALiquidar.Name = "txtTtlOpALiquidar";
            this.txtTtlOpALiquidar.ReadOnly = true;
            this.txtTtlOpALiquidar.Size = new System.Drawing.Size(96, 20);
            this.txtTtlOpALiquidar.TabIndex = 8;
            this.txtTtlOpALiquidar.TabStop = false;
            this.txtTtlOpALiquidar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(597, 417);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Total de Operaciones a Liquidar";
            // 
            // FormLiquidarComisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 485);
            this.Controls.Add(this.txtTtlOpALiquidar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRemoverOperacion);
            this.Controls.Add(this.grillaOperacionesALiquidar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGenerarLiquidacion);
            this.Controls.Add(this.btnModificarParametrosLiquidacion);
            this.Controls.Add(this.txtComentariosLiquidacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCodigoLiquidacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFechaLiquidacion);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(887, 524);
            this.Name = "FormLiquidarComisiones";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liquidar Comisiones";
            this.Load += new System.EventHandler(this.FormLiquidarComisiones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaOperacionesALiquidar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFechaLiquidacion;
        private System.Windows.Forms.TextBox txtCodigoLiquidacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtComentariosLiquidacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnModificarParametrosLiquidacion;
        private System.Windows.Forms.Button btnGenerarLiquidacion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRemoverOperacion;
        public System.Windows.Forms.DataGridView grillaOperacionesALiquidar;
        private System.Windows.Forms.TextBox txtTtlOpALiquidar;
        private System.Windows.Forms.Label label4;
    }
}