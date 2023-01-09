namespace FullCarMultimarca.UI.Base
{
    partial class FormListaBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListaBase));
            this.grillaDatos = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panelContenedorGrilla = new System.Windows.Forms.Panel();
            this.lblRegistrosEncontrados = new System.Windows.Forms.Label();
            this.txtCriterioBusqueda = new System.Windows.Forms.TextBox();
            this.cmbCampoBusqueda = new System.Windows.Forms.ComboBox();
            this.btnRestablecer = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblInfoOrdenamientoGrillas = new System.Windows.Forms.Label();
            this.ckIncluirInactivos = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.grillaDatos)).BeginInit();
            this.panelContenedorGrilla.SuspendLayout();
            this.SuspendLayout();
            // 
            // grillaDatos
            // 
            this.grillaDatos.AllowUserToAddRows = false;
            this.grillaDatos.AllowUserToDeleteRows = false;
            this.grillaDatos.AllowUserToResizeColumns = false;
            this.grillaDatos.AllowUserToResizeRows = false;
            this.grillaDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grillaDatos.BackgroundColor = System.Drawing.Color.LightYellow;
            this.grillaDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grillaDatos.Location = new System.Drawing.Point(0, 0);
            this.grillaDatos.MultiSelect = false;
            this.grillaDatos.Name = "grillaDatos";
            this.grillaDatos.ReadOnly = true;
            this.grillaDatos.RowHeadersVisible = false;
            this.grillaDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaDatos.Size = new System.Drawing.Size(624, 207);
            this.grillaDatos.TabIndex = 0;
            this.grillaDatos.TabStop = false;
            this.grillaDatos.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grillaDatos_CellMouseDoubleClick);
            this.grillaDatos.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grillaDatos_ColumnHeaderMouseClick);
            this.grillaDatos.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaDatos_RowEnter);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Location = new System.Drawing.Point(567, 292);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(69, 23);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panelContenedorGrilla
            // 
            this.panelContenedorGrilla.Controls.Add(this.grillaDatos);
            this.panelContenedorGrilla.Location = new System.Drawing.Point(12, 53);
            this.panelContenedorGrilla.Name = "panelContenedorGrilla";
            this.panelContenedorGrilla.Size = new System.Drawing.Size(624, 207);
            this.panelContenedorGrilla.TabIndex = 15;
            // 
            // lblRegistrosEncontrados
            // 
            this.lblRegistrosEncontrados.AutoSize = true;
            this.lblRegistrosEncontrados.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistrosEncontrados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRegistrosEncontrados.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblRegistrosEncontrados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrosEncontrados.Location = new System.Drawing.Point(0, 325);
            this.lblRegistrosEncontrados.Name = "lblRegistrosEncontrados";
            this.lblRegistrosEncontrados.Size = new System.Drawing.Size(140, 15);
            this.lblRegistrosEncontrados.TabIndex = 19;
            this.lblRegistrosEncontrados.Text = "Texto registros encontrados";
            this.lblRegistrosEncontrados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCriterioBusqueda
            // 
            this.txtCriterioBusqueda.Location = new System.Drawing.Point(162, 13);
            this.txtCriterioBusqueda.Name = "txtCriterioBusqueda";
            this.txtCriterioBusqueda.Size = new System.Drawing.Size(207, 20);
            this.txtCriterioBusqueda.TabIndex = 1;
            this.txtCriterioBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCriterioBusqueda_KeyPress);
            // 
            // cmbCampoBusqueda
            // 
            this.cmbCampoBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCampoBusqueda.FormattingEnabled = true;
            this.cmbCampoBusqueda.Location = new System.Drawing.Point(12, 12);
            this.cmbCampoBusqueda.Name = "cmbCampoBusqueda";
            this.cmbCampoBusqueda.Size = new System.Drawing.Size(144, 21);
            this.cmbCampoBusqueda.TabIndex = 0;
            // 
            // btnRestablecer
            // 
            this.btnRestablecer.Image = global::FullCarMultimarca.UI.Properties.Resources.navigate_cross;
            this.btnRestablecer.Location = new System.Drawing.Point(482, 11);
            this.btnRestablecer.Name = "btnRestablecer";
            this.btnRestablecer.Size = new System.Drawing.Size(101, 23);
            this.btnRestablecer.TabIndex = 16;
            this.btnRestablecer.Text = "Restablecer";
            this.btnRestablecer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRestablecer.UseVisualStyleBackColor = true;
            this.btnRestablecer.Click += new System.EventHandler(this.btnRestablecer_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAgregar.Image = global::FullCarMultimarca.UI.Properties.Resources.add2;
            this.btnAgregar.Location = new System.Drawing.Point(12, 266);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(79, 23);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnModificar.Image = global::FullCarMultimarca.UI.Properties.Resources.document_edit;
            this.btnModificar.Location = new System.Drawing.Point(97, 266);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(79, 23);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Location = new System.Drawing.Point(182, 266);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(79, 23);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Image = global::FullCarMultimarca.UI.Properties.Resources.view;
            this.btnActualizar.Location = new System.Drawing.Point(375, 12);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(101, 23);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Buscar...";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblInfoOrdenamientoGrillas
            // 
            this.lblInfoOrdenamientoGrillas.AutoSize = true;
            this.lblInfoOrdenamientoGrillas.Location = new System.Drawing.Point(12, 38);
            this.lblInfoOrdenamientoGrillas.Name = "lblInfoOrdenamientoGrillas";
            this.lblInfoOrdenamientoGrillas.Size = new System.Drawing.Size(384, 13);
            this.lblInfoOrdenamientoGrillas.TabIndex = 17;
            this.lblInfoOrdenamientoGrillas.Text = "Puede ordenar los elementos de la grilla haciendo click sobre cualquier columna";
            // 
            // ckIncluirInactivos
            // 
            this.ckIncluirInactivos.AutoSize = true;
            this.ckIncluirInactivos.Location = new System.Drawing.Point(483, 34);
            this.ckIncluirInactivos.Name = "ckIncluirInactivos";
            this.ckIncluirInactivos.Size = new System.Drawing.Size(100, 17);
            this.ckIncluirInactivos.TabIndex = 18;
            this.ckIncluirInactivos.Text = "Incluir Inactivos";
            this.ckIncluirInactivos.UseVisualStyleBackColor = true;
            // 
            // FormListaBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(642, 340);
            this.Controls.Add(this.lblRegistrosEncontrados);
            this.Controls.Add(this.ckIncluirInactivos);
            this.Controls.Add(this.lblInfoOrdenamientoGrillas);
            this.Controls.Add(this.btnRestablecer);
            this.Controls.Add(this.cmbCampoBusqueda);
            this.Controls.Add(this.txtCriterioBusqueda);
            this.Controls.Add(this.panelContenedorGrilla);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActualizar);
            this.MinimumSize = new System.Drawing.Size(658, 379);
            this.Name = "FormListaBase";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FormListaBase";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormListaBase_FormClosed);
            this.Load += new System.EventHandler(this.FormListaBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaDatos)).EndInit();
            this.panelContenedorGrilla.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView grillaDatos;
        protected System.Windows.Forms.Button btnActualizar;
        protected System.Windows.Forms.Button btnEliminar;
        protected System.Windows.Forms.Button btnAgregar;
        protected System.Windows.Forms.Button btnModificar;
        protected System.Windows.Forms.Button btnCerrar;
        public System.Windows.Forms.Panel panelContenedorGrilla;
        public System.Windows.Forms.TextBox txtCriterioBusqueda;
        public System.Windows.Forms.ComboBox cmbCampoBusqueda;
        protected System.Windows.Forms.Button btnRestablecer;
        public System.Windows.Forms.Label lblInfoOrdenamientoGrillas;
        public System.Windows.Forms.CheckBox ckIncluirInactivos;
        public System.Windows.Forms.Label lblRegistrosEncontrados;
    }
}