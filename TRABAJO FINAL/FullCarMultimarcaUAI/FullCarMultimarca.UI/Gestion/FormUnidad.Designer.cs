
namespace FullCarMultimarca.UI.Gestion
{
    partial class FormUnidad
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
            this.label3 = new System.Windows.Forms.Label();
            this.cmbModelo = new System.Windows.Forms.ComboBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ckDisponible = new System.Windows.Forms.CheckBox();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFechaCompra = new System.Windows.Forms.DateTimePicker();
            this.grupoOferta = new System.Windows.Forms.GroupBox();
            this.txtOfertaActual = new System.Windows.Forms.TextBox();
            this.txtVtoOfertaActual = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblInfoModificacion = new System.Windows.Forms.Label();
            this.lblUnidadVendida = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblLargoVIN = new System.Windows.Forms.Label();
            this.txtPrecioPublicVigente = new FullCarMultimarca.UI.UserControls.DecimalTextBox();
            this.txtChasis = new FullCarMultimarca.UI.UserControls.InputBoxConRegExp();
            this.txtImporteCompra = new FullCarMultimarca.UI.UserControls.DecimalTextBox();
            this.grupoOferta.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(236, 324);
            this.btnGuardar.TabIndex = 5;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(311, 324);
            this.btnCancelar.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 58;
            this.label3.Text = "Importe Compra";
            // 
            // cmbModelo
            // 
            this.cmbModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModelo.FormattingEnabled = true;
            this.cmbModelo.Location = new System.Drawing.Point(56, 86);
            this.cmbModelo.Name = "cmbModelo";
            this.cmbModelo.Size = new System.Drawing.Size(324, 21);
            this.cmbModelo.TabIndex = 1;
            this.cmbModelo.SelectedIndexChanged += new System.EventHandler(this.cmbModelo_SelectedIndexChanged);
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Location = new System.Drawing.Point(12, 89);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(42, 13);
            this.lblProveedor.TabIndex = 57;
            this.lblProveedor.Text = "Modelo";
            this.lblProveedor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Chasis";
            // 
            // ckDisponible
            // 
            this.ckDisponible.AutoSize = true;
            this.ckDisponible.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckDisponible.Checked = true;
            this.ckDisponible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckDisponible.Enabled = false;
            this.ckDisponible.Location = new System.Drawing.Point(268, 12);
            this.ckDisponible.Name = "ckDisponible";
            this.ckDisponible.Size = new System.Drawing.Size(112, 17);
            this.ckDisponible.TabIndex = 59;
            this.ckDisponible.TabStop = false;
            this.ckDisponible.Text = "Unidad Disponible";
            this.ckDisponible.UseVisualStyleBackColor = true;
            // 
            // cmbColor
            // 
            this.cmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(56, 140);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(324, 21);
            this.cmbColor.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "Color";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 62;
            this.label4.Text = "Fecha Compra";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtFechaCompra
            // 
            this.txtFechaCompra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaCompra.Location = new System.Drawing.Point(105, 188);
            this.txtFechaCompra.Name = "txtFechaCompra";
            this.txtFechaCompra.Size = new System.Drawing.Size(133, 20);
            this.txtFechaCompra.TabIndex = 3;
            this.txtFechaCompra.Value = new System.DateTime(2021, 6, 8, 0, 0, 0, 0);
            // 
            // grupoOferta
            // 
            this.grupoOferta.Controls.Add(this.txtOfertaActual);
            this.grupoOferta.Controls.Add(this.txtVtoOfertaActual);
            this.grupoOferta.Controls.Add(this.label5);
            this.grupoOferta.Controls.Add(this.label6);
            this.grupoOferta.Enabled = false;
            this.grupoOferta.Location = new System.Drawing.Point(12, 248);
            this.grupoOferta.Name = "grupoOferta";
            this.grupoOferta.Size = new System.Drawing.Size(368, 66);
            this.grupoOferta.TabIndex = 64;
            this.grupoOferta.TabStop = false;
            this.grupoOferta.Text = "Oferta";
            // 
            // txtOfertaActual
            // 
            this.txtOfertaActual.Location = new System.Drawing.Point(70, 25);
            this.txtOfertaActual.Name = "txtOfertaActual";
            this.txtOfertaActual.ReadOnly = true;
            this.txtOfertaActual.Size = new System.Drawing.Size(99, 20);
            this.txtOfertaActual.TabIndex = 67;
            this.txtOfertaActual.TabStop = false;
            // 
            // txtVtoOfertaActual
            // 
            this.txtVtoOfertaActual.Location = new System.Drawing.Point(256, 25);
            this.txtVtoOfertaActual.Name = "txtVtoOfertaActual";
            this.txtVtoOfertaActual.ReadOnly = true;
            this.txtVtoOfertaActual.Size = new System.Drawing.Size(106, 20);
            this.txtVtoOfertaActual.TabIndex = 68;
            this.txtVtoOfertaActual.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(187, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 66;
            this.label5.Text = "Vencimiento";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 65;
            this.label6.Text = "Importe";
            // 
            // lblInfoModificacion
            // 
            this.lblInfoModificacion.ForeColor = System.Drawing.Color.Blue;
            this.lblInfoModificacion.Location = new System.Drawing.Point(278, 178);
            this.lblInfoModificacion.Name = "lblInfoModificacion";
            this.lblInfoModificacion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblInfoModificacion.Size = new System.Drawing.Size(102, 68);
            this.lblInfoModificacion.TabIndex = 0;
            this.lblInfoModificacion.Text = "NO puede modificar el Modelo ni datos de compra debido a que la unidad está en of" +
    "erta.";
            this.lblInfoModificacion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblInfoModificacion.Visible = false;
            // 
            // lblUnidadVendida
            // 
            this.lblUnidadVendida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnidadVendida.ForeColor = System.Drawing.Color.Red;
            this.lblUnidadVendida.Location = new System.Drawing.Point(97, 11);
            this.lblUnidadVendida.Name = "lblUnidadVendida";
            this.lblUnidadVendida.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUnidadVendida.Size = new System.Drawing.Size(157, 22);
            this.lblUnidadVendida.TabIndex = 65;
            this.lblUnidadVendida.Text = "UNIDAD VENDIDA";
            this.lblUnidadVendida.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblUnidadVendida.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(209, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 66;
            this.label7.Text = "(sin IVA)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(143, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 13);
            this.label8.TabIndex = 68;
            this.label8.Text = "Precio público vigente";
            // 
            // lblLargoVIN
            // 
            this.lblLargoVIN.AutoSize = true;
            this.lblLargoVIN.Location = new System.Drawing.Point(53, 59);
            this.lblLargoVIN.Name = "lblLargoVIN";
            this.lblLargoVIN.Size = new System.Drawing.Size(80, 13);
            this.lblLargoVIN.TabIndex = 69;
            this.lblLargoVIN.Text = "Largo Chasis: 0";
            this.lblLargoVIN.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtPrecioPublicVigente
            // 
            this.txtPrecioPublicVigente.Location = new System.Drawing.Point(261, 114);
            this.txtPrecioPublicVigente.Mask = "00000000.00";
            this.txtPrecioPublicVigente.Name = "txtPrecioPublicVigente";
            this.txtPrecioPublicVigente.ReadOnly = true;
            this.txtPrecioPublicVigente.Size = new System.Drawing.Size(119, 20);
            this.txtPrecioPublicVigente.TabIndex = 67;
            this.txtPrecioPublicVigente.TabStop = false;
            this.txtPrecioPublicVigente.Text = "        00";
            this.txtPrecioPublicVigente.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtPrecioPublicVigente.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // txtChasis
            // 
            this.txtChasis.Autovalidar = false;
            this.txtChasis.CapturarCaracteresEnMayuscula = true;
            this.txtChasis.CaracteresAceptados = null;
            this.txtChasis.Location = new System.Drawing.Point(56, 35);
            this.txtChasis.MensajeErrorValidacion = "El valor ingresado es inválido.";
            this.txtChasis.Name = "txtChasis";
            this.txtChasis.RegularValidacion = "";
            this.txtChasis.RestringirInputANumeros = false;
            this.txtChasis.Size = new System.Drawing.Size(286, 21);
            this.txtChasis.TabIndex = 0;
            // 
            // txtImporteCompra
            // 
            this.txtImporteCompra.Location = new System.Drawing.Point(105, 213);
            this.txtImporteCompra.Mask = "00000000.00";
            this.txtImporteCompra.Name = "txtImporteCompra";
            this.txtImporteCompra.Size = new System.Drawing.Size(98, 20);
            this.txtImporteCompra.TabIndex = 4;
            this.txtImporteCompra.Text = "        00";
            this.txtImporteCompra.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtImporteCompra.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // FormUnidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 359);
            this.Controls.Add(this.lblLargoVIN);
            this.Controls.Add(this.txtPrecioPublicVigente);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtChasis);
            this.Controls.Add(this.lblUnidadVendida);
            this.Controls.Add(this.lblInfoModificacion);
            this.Controls.Add(this.grupoOferta);
            this.Controls.Add(this.txtFechaCompra);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ckDisponible);
            this.Controls.Add(this.txtImporteCompra);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbModelo);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FormUnidad";
            this.Text = "Unidad";
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblProveedor, 0);
            this.Controls.SetChildIndex(this.cmbModelo, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtImporteCompra, 0);
            this.Controls.SetChildIndex(this.ckDisponible, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cmbColor, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtFechaCompra, 0);
            this.Controls.SetChildIndex(this.grupoOferta, 0);
            this.Controls.SetChildIndex(this.lblInfoModificacion, 0);
            this.Controls.SetChildIndex(this.lblUnidadVendida, 0);
            this.Controls.SetChildIndex(this.txtChasis, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtPrecioPublicVigente, 0);
            this.Controls.SetChildIndex(this.lblLargoVIN, 0);
            this.grupoOferta.ResumeLayout(false);
            this.grupoOferta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.DecimalTextBox txtImporteCompra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbModelo;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckDisponible;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker txtFechaCompra;
        private System.Windows.Forms.GroupBox grupoOferta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblInfoModificacion;
        private System.Windows.Forms.Label lblUnidadVendida;
        private UserControls.InputBoxConRegExp txtChasis;
        private System.Windows.Forms.TextBox txtOfertaActual;
        private System.Windows.Forms.TextBox txtVtoOfertaActual;
        private System.Windows.Forms.Label label7;
        private UserControls.DecimalTextBox txtPrecioPublicVigente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblLargoVIN;
    }
}