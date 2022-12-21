
namespace FullCarMultimarca.UI.UserControls
{
    partial class BuscadorCliente
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFiltrarInfo = new System.Windows.Forms.Label();
            this.txtFiltroBusquedaCliente = new System.Windows.Forms.TextBox();
            this.lblFiltrar = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.btnAgregarCliente = new System.Windows.Forms.Button();
            this.txtClienteSeleccionado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVerFichaCliente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFiltrarInfo
            // 
            this.lblFiltrarInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFiltrarInfo.AutoSize = true;
            this.lblFiltrarInfo.Location = new System.Drawing.Point(219, 12);
            this.lblFiltrarInfo.Name = "lblFiltrarInfo";
            this.lblFiltrarInfo.Size = new System.Drawing.Size(269, 13);
            this.lblFiltrarInfo.TabIndex = 78;
            this.lblFiltrarInfo.Text = "(tipee para filtrar el combo por CUIT, Apellido o Nombre)";
            // 
            // txtFiltroBusquedaCliente
            // 
            this.txtFiltroBusquedaCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltroBusquedaCliente.Location = new System.Drawing.Point(38, 9);
            this.txtFiltroBusquedaCliente.Name = "txtFiltroBusquedaCliente";
            this.txtFiltroBusquedaCliente.Size = new System.Drawing.Size(175, 20);
            this.txtFiltroBusquedaCliente.TabIndex = 75;
            this.txtFiltroBusquedaCliente.TextChanged += new System.EventHandler(this.txtFiltroBusquedaCliente_TextChanged);
            // 
            // lblFiltrar
            // 
            this.lblFiltrar.AutoSize = true;
            this.lblFiltrar.Location = new System.Drawing.Point(3, 12);
            this.lblFiltrar.Name = "lblFiltrar";
            this.lblFiltrar.Size = new System.Drawing.Size(29, 13);
            this.lblFiltrar.TabIndex = 77;
            this.lblFiltrar.Text = "Filtro";
            // 
            // cmbCliente
            // 
            this.cmbCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(3, 34);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(444, 21);
            this.cmbCliente.TabIndex = 76;
            this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.cmbCliente_SelectedIndexChanged);
            // 
            // btnAgregarCliente
            // 
            this.btnAgregarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarCliente.Image = global::FullCarMultimarca.UI.Properties.Resources.add2;
            this.btnAgregarCliente.Location = new System.Drawing.Point(453, 32);
            this.btnAgregarCliente.Name = "btnAgregarCliente";
            this.btnAgregarCliente.Size = new System.Drawing.Size(35, 23);
            this.btnAgregarCliente.TabIndex = 79;
            this.btnAgregarCliente.UseVisualStyleBackColor = true;
            this.btnAgregarCliente.Click += new System.EventHandler(this.btnAgregarCliente_Click);
            // 
            // txtClienteSeleccionado
            // 
            this.txtClienteSeleccionado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClienteSeleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClienteSeleccionado.Location = new System.Drawing.Point(63, 61);
            this.txtClienteSeleccionado.Name = "txtClienteSeleccionado";
            this.txtClienteSeleccionado.ReadOnly = true;
            this.txtClienteSeleccionado.Size = new System.Drawing.Size(384, 20);
            this.txtClienteSeleccionado.TabIndex = 80;
            this.txtClienteSeleccionado.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 81;
            this.label1.Text = "Selección";
            // 
            // btnVerFichaCliente
            // 
            this.btnVerFichaCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerFichaCliente.Image = global::FullCarMultimarca.UI.Properties.Resources.view;
            this.btnVerFichaCliente.Location = new System.Drawing.Point(453, 59);
            this.btnVerFichaCliente.Name = "btnVerFichaCliente";
            this.btnVerFichaCliente.Size = new System.Drawing.Size(35, 23);
            this.btnVerFichaCliente.TabIndex = 82;
            this.btnVerFichaCliente.UseVisualStyleBackColor = true;
            this.btnVerFichaCliente.Click += new System.EventHandler(this.btnVerFichaCliente_Click);
            // 
            // BuscadorCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnVerFichaCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtClienteSeleccionado);
            this.Controls.Add(this.btnAgregarCliente);
            this.Controls.Add(this.lblFiltrarInfo);
            this.Controls.Add(this.txtFiltroBusquedaCliente);
            this.Controls.Add(this.lblFiltrar);
            this.Controls.Add(this.cmbCliente);
            this.Name = "BuscadorCliente";
            this.Size = new System.Drawing.Size(492, 88);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarCliente;
        private System.Windows.Forms.Label lblFiltrarInfo;
        private System.Windows.Forms.TextBox txtFiltroBusquedaCliente;
        private System.Windows.Forms.Label lblFiltrar;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.TextBox txtClienteSeleccionado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVerFichaCliente;
    }
}
