
namespace FullCarMultimarca.UI.Ventas
{
    partial class FormOperacionFormaPago
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
            this.cmbFormasPago = new System.Windows.Forms.ComboBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtImporte = new FullCarMultimarca.UI.UserControls.DecimalTextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtTipoFPago = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtArancelGasto = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmbFormasPago
            // 
            this.cmbFormasPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormasPago.FormattingEnabled = true;
            this.cmbFormasPago.Location = new System.Drawing.Point(106, 24);
            this.cmbFormasPago.Name = "cmbFormasPago";
            this.cmbFormasPago.Size = new System.Drawing.Size(199, 21);
            this.cmbFormasPago.TabIndex = 0;
            this.cmbFormasPago.SelectedIndexChanged += new System.EventHandler(this.cmbFormasPago_SelectedIndexChanged);
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Location = new System.Drawing.Point(12, 27);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(79, 13);
            this.lblProveedor.TabIndex = 57;
            this.lblProveedor.Text = "Forma de Pago";
            this.lblProveedor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Importe";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(106, 99);
            this.txtImporte.Mask = "00000000.00";
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(117, 20);
            this.txtImporte.TabIndex = 1;
            this.txtImporte.Text = "        00";
            this.txtImporte.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtImporte.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Image = global::FullCarMultimarca.UI.Properties.Resources.add2;
            this.btnGuardar.Location = new System.Drawing.Point(149, 125);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(81, 23);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Agergar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(236, 125);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(69, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtTipoFPago
            // 
            this.txtTipoFPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoFPago.ForeColor = System.Drawing.Color.Black;
            this.txtTipoFPago.Location = new System.Drawing.Point(106, 51);
            this.txtTipoFPago.Name = "txtTipoFPago";
            this.txtTipoFPago.ReadOnly = true;
            this.txtTipoFPago.Size = new System.Drawing.Size(199, 20);
            this.txtTipoFPago.TabIndex = 59;
            this.txtTipoFPago.TabStop = false;
            this.txtTipoFPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "Tipo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 62;
            this.label3.Text = "Arancel Gasto";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtArancelGasto
            // 
            this.txtArancelGasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArancelGasto.ForeColor = System.Drawing.Color.Black;
            this.txtArancelGasto.Location = new System.Drawing.Point(106, 73);
            this.txtArancelGasto.Name = "txtArancelGasto";
            this.txtArancelGasto.ReadOnly = true;
            this.txtArancelGasto.Size = new System.Drawing.Size(199, 20);
            this.txtArancelGasto.TabIndex = 61;
            this.txtArancelGasto.TabStop = false;
            this.txtArancelGasto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FormOperacionFormaPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 160);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtArancelGasto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTipoFPago);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFormasPago);
            this.Controls.Add(this.lblProveedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOperacionFormaPago";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forma Pago";
            this.Load += new System.EventHandler(this.FormOperacionFormaPago_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbFormasPago;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label label1;
        private UserControls.DecimalTextBox txtImporte;
        protected System.Windows.Forms.Button btnGuardar;
        protected System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtTipoFPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtArancelGasto;
    }
}