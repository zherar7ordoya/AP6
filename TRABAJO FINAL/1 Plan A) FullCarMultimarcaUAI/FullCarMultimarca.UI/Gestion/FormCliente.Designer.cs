
namespace FullCarMultimarca.UI.Gestion
{
    partial class FormCliente
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
            this.components = new System.ComponentModel.Container();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbProvincia = new System.Windows.Forms.ComboBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.lblFormatoCUIT = new System.Windows.Forms.Label();
            this.btnEliminarContacto = new System.Windows.Forms.Button();
            this.grillaContactos = new System.Windows.Forms.DataGridView();
            this.btnAgregarContacto = new System.Windows.Forms.Button();
            this.cmbTipoContacto = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtContactoDato = new FullCarMultimarca.UI.UserControls.InputBoxConRegExp();
            this.txtCUIT = new FullCarMultimarca.UI.UserControls.InputBoxConRegExp();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.imgInfoTipoContacto = new System.Windows.Forms.PictureBox();
            this.txtCodigoPostal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grillaContactos)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgInfoTipoContacto)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(314, 454);
            this.btnGuardar.TabIndex = 8;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(389, 454);
            this.btnCancelar.TabIndex = 9;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(182, 87);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(276, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Nombre/Contacto";
            // 
            // txtApellido
            // 
            this.txtApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellido.Location = new System.Drawing.Point(182, 62);
            this.txtApellido.MaxLength = 50;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(276, 20);
            this.txtApellido.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Apellido/Razón Social";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "CUIL/CUIT";
            // 
            // txtDireccion
            // 
            this.txtDireccion.AcceptsReturn = true;
            this.txtDireccion.Location = new System.Drawing.Point(182, 113);
            this.txtDireccion.MaxLength = 50;
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(276, 49);
            this.txtDireccion.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Dirección";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(182, 168);
            this.txtLocalidad.MaxLength = 50;
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(276, 20);
            this.txtLocalidad.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(123, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Localidad";
            // 
            // cmbProvincia
            // 
            this.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvincia.FormattingEnabled = true;
            this.cmbProvincia.Location = new System.Drawing.Point(182, 218);
            this.cmbProvincia.Name = "cmbProvincia";
            this.cmbProvincia.Size = new System.Drawing.Size(276, 21);
            this.cmbProvincia.TabIndex = 6;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Location = new System.Drawing.Point(123, 221);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(51, 13);
            this.lblProveedor.TabIndex = 53;
            this.lblProveedor.Text = "Provincia";
            this.lblProveedor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblFormatoCUIT
            // 
            this.lblFormatoCUIT.AutoSize = true;
            this.lblFormatoCUIT.Location = new System.Drawing.Point(179, 46);
            this.lblFormatoCUIT.Name = "lblFormatoCUIT";
            this.lblFormatoCUIT.Size = new System.Drawing.Size(179, 13);
            this.lblFormatoCUIT.TabIndex = 54;
            this.lblFormatoCUIT.Text = "(Formato CUIT: NN-NNNNNNNN-N)";
            // 
            // btnEliminarContacto
            // 
            this.btnEliminarContacto.Image = global::FullCarMultimarca.UI.Properties.Resources.delete2;
            this.btnEliminarContacto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarContacto.Location = new System.Drawing.Point(413, 75);
            this.btnEliminarContacto.Name = "btnEliminarContacto";
            this.btnEliminarContacto.Size = new System.Drawing.Size(27, 23);
            this.btnEliminarContacto.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnEliminarContacto, "Eliminar Contacto seleccionado");
            this.btnEliminarContacto.UseVisualStyleBackColor = true;
            this.btnEliminarContacto.Click += new System.EventHandler(this.btnEliminarContacto_Click);
            // 
            // grillaContactos
            // 
            this.grillaContactos.AllowUserToAddRows = false;
            this.grillaContactos.AllowUserToDeleteRows = false;
            this.grillaContactos.AllowUserToResizeColumns = false;
            this.grillaContactos.AllowUserToResizeRows = false;
            this.grillaContactos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grillaContactos.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.grillaContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaContactos.Location = new System.Drawing.Point(6, 75);
            this.grillaContactos.MultiSelect = false;
            this.grillaContactos.Name = "grillaContactos";
            this.grillaContactos.ReadOnly = true;
            this.grillaContactos.RowHeadersVisible = false;
            this.grillaContactos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaContactos.Size = new System.Drawing.Size(401, 122);
            this.grillaContactos.TabIndex = 3;
            this.grillaContactos.TabStop = false;
            // 
            // btnAgregarContacto
            // 
            this.btnAgregarContacto.Image = global::FullCarMultimarca.UI.Properties.Resources.add2;
            this.btnAgregarContacto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarContacto.Location = new System.Drawing.Point(413, 46);
            this.btnAgregarContacto.Name = "btnAgregarContacto";
            this.btnAgregarContacto.Size = new System.Drawing.Size(27, 23);
            this.btnAgregarContacto.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnAgregarContacto, "Agregar Contacto");
            this.btnAgregarContacto.UseVisualStyleBackColor = true;
            this.btnAgregarContacto.Click += new System.EventHandler(this.btnAgregarContacto_Click);
            // 
            // cmbTipoContacto
            // 
            this.cmbTipoContacto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoContacto.FormattingEnabled = true;
            this.cmbTipoContacto.Location = new System.Drawing.Point(55, 19);
            this.cmbTipoContacto.Name = "cmbTipoContacto";
            this.cmbTipoContacto.Size = new System.Drawing.Size(194, 21);
            this.cmbTipoContacto.TabIndex = 0;
            this.cmbTipoContacto.SelectedIndexChanged += new System.EventHandler(this.cmbTipoContacto_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 61;
            this.label6.Text = "Tipo";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtContactoDato
            // 
            this.txtContactoDato.Autovalidar = false;
            this.txtContactoDato.CapturarCaracteresEnMayuscula = false;
            this.txtContactoDato.CaracteresAceptados = null;
            this.txtContactoDato.Location = new System.Drawing.Point(55, 46);
            this.txtContactoDato.MensajeErrorValidacion = "";
            this.txtContactoDato.Name = "txtContactoDato";
            this.txtContactoDato.RegularValidacion = "";
            this.txtContactoDato.RestringirInputANumeros = false;
            this.txtContactoDato.Size = new System.Drawing.Size(352, 21);
            this.txtContactoDato.TabIndex = 1;
            // 
            // txtCUIT
            // 
            this.txtCUIT.Autovalidar = false;
            this.txtCUIT.CapturarCaracteresEnMayuscula = false;
            this.txtCUIT.CaracteresAceptados = null;
            this.txtCUIT.Location = new System.Drawing.Point(182, 22);
            this.txtCUIT.MensajeErrorValidacion = "";
            this.txtCUIT.Name = "txtCUIT";
            this.txtCUIT.RegularValidacion = "";
            this.txtCUIT.RestringirInputANumeros = true;
            this.txtCUIT.Size = new System.Drawing.Size(276, 21);
            this.txtCUIT.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.imgInfoTipoContacto);
            this.groupBox1.Controls.Add(this.grillaContactos);
            this.groupBox1.Controls.Add(this.btnAgregarContacto);
            this.groupBox1.Controls.Add(this.btnEliminarContacto);
            this.groupBox1.Controls.Add(this.txtContactoDato);
            this.groupBox1.Controls.Add(this.cmbTipoContacto);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 245);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 203);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Contacto";
            // 
            // imgInfoTipoContacto
            // 
            this.imgInfoTipoContacto.Image = global::FullCarMultimarca.UI.Properties.Resources.modifPalabraClave;
            this.imgInfoTipoContacto.Location = new System.Drawing.Point(255, 19);
            this.imgInfoTipoContacto.Name = "imgInfoTipoContacto";
            this.imgInfoTipoContacto.Size = new System.Drawing.Size(17, 20);
            this.imgInfoTipoContacto.TabIndex = 80;
            this.imgInfoTipoContacto.TabStop = false;
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoPostal.Location = new System.Drawing.Point(182, 194);
            this.txtCodigoPostal.MaxLength = 10;
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(276, 20);
            this.txtCodigoPostal.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(104, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 56;
            this.label7.Text = "Código Postal";
            // 
            // FormCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 489);
            this.Controls.Add(this.txtCodigoPostal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblFormatoCUIT);
            this.Controls.Add(this.cmbProvincia);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.txtLocalidad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCUIT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label2);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FormCliente";
            this.Text = "Cliente";
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtNombre, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtApellido, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtCUIT, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtDireccion, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtLocalidad, 0);
            this.Controls.SetChildIndex(this.lblProveedor, 0);
            this.Controls.SetChildIndex(this.cmbProvincia, 0);
            this.Controls.SetChildIndex(this.lblFormatoCUIT, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtCodigoPostal, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grillaContactos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgInfoTipoContacto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private UserControls.InputBoxConRegExp txtCUIT;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbProvincia;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label lblFormatoCUIT;
        private System.Windows.Forms.Button btnEliminarContacto;
        public System.Windows.Forms.DataGridView grillaContactos;
        private System.Windows.Forms.Button btnAgregarContacto;
        private UserControls.InputBoxConRegExp txtContactoDato;
        private System.Windows.Forms.ComboBox cmbTipoContacto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox imgInfoTipoContacto;
        private System.Windows.Forms.TextBox txtCodigoPostal;
        private System.Windows.Forms.Label label7;
    }
}