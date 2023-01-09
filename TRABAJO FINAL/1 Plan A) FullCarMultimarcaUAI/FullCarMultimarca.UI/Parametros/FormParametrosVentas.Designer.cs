
namespace FullCarMultimarca.UI.Parametros
{
    partial class FormParametrosVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormParametrosVentas));
            this.txtMesesRetroPauta = new FullCarMultimarca.UI.UserControls.CustomNumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFormasPagoContado = new System.Windows.Forms.ComboBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.txtPorcCobARecup = new FullCarMultimarca.UI.UserControls.CustomNumericUpDown();
            this.txtPorGstPatentamiento = new FullCarMultimarca.UI.UserControls.CustomNumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDestinatarioVencOfertas = new System.Windows.Forms.TextBox();
            this.txtDestinatariosAutPerdida = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTasaIVAPickUp = new FullCarMultimarca.UI.UserControls.CustomNumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTasaIVAResto = new FullCarMultimarca.UI.UserControls.CustomNumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtMesesRetroPauta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorcCobARecup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorGstPatentamiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTasaIVAPickUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTasaIVAResto)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(194, 426);
            this.btnGuardar.TabIndex = 8;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(269, 426);
            this.btnCancelar.TabIndex = 9;
            // 
            // txtMesesRetroPauta
            // 
            this.txtMesesRetroPauta.Location = new System.Drawing.Point(274, 106);
            this.txtMesesRetroPauta.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.txtMesesRetroPauta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtMesesRetroPauta.Name = "txtMesesRetroPauta";
            this.txtMesesRetroPauta.Size = new System.Drawing.Size(61, 20);
            this.txtMesesRetroPauta.TabIndex = 3;
            this.txtMesesRetroPauta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Cantidad de días Retroactivo para determinar pauta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "Porcentaje Cobertura a Recuperar";
            // 
            // cmbFormasPagoContado
            // 
            this.cmbFormasPagoContado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormasPagoContado.FormattingEnabled = true;
            this.cmbFormasPagoContado.Location = new System.Drawing.Point(187, 79);
            this.cmbFormasPagoContado.Name = "cmbFormasPagoContado";
            this.cmbFormasPagoContado.Size = new System.Drawing.Size(148, 21);
            this.cmbFormasPagoContado.TabIndex = 2;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Location = new System.Drawing.Point(13, 82);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(159, 13);
            this.lblProveedor.TabIndex = 55;
            this.lblProveedor.Text = "Forma de Pago Contado Default";
            this.lblProveedor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtPorcCobARecup
            // 
            this.txtPorcCobARecup.DecimalPlaces = 2;
            this.txtPorcCobARecup.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.txtPorcCobARecup.Location = new System.Drawing.Point(187, 27);
            this.txtPorcCobARecup.Name = "txtPorcCobARecup";
            this.txtPorcCobARecup.Size = new System.Drawing.Size(70, 20);
            this.txtPorcCobARecup.TabIndex = 0;
            // 
            // txtPorGstPatentamiento
            // 
            this.txtPorGstPatentamiento.DecimalPlaces = 2;
            this.txtPorGstPatentamiento.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.txtPorGstPatentamiento.Location = new System.Drawing.Point(187, 53);
            this.txtPorGstPatentamiento.Name = "txtPorGstPatentamiento";
            this.txtPorGstPatentamiento.Size = new System.Drawing.Size(70, 20);
            this.txtPorGstPatentamiento.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Porcentaje Gasto Patentamiento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(263, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 60;
            this.label4.Text = "(Gestoría)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(267, 13);
            this.label5.TabIndex = 61;
            this.label5.Text = "Destinatarios notificación sobre Vencimiento de Ofertas";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(14, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(322, 31);
            this.label6.TabIndex = 62;
            this.label6.Text = "(*) Si deja vacío no se enviará el correo y puede concatenar destinatarios con \'," +
    "\' o \';\'";
            // 
            // txtDestinatarioVencOfertas
            // 
            this.txtDestinatarioVencOfertas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestinatarioVencOfertas.ForeColor = System.Drawing.Color.Blue;
            this.txtDestinatarioVencOfertas.Location = new System.Drawing.Point(13, 222);
            this.txtDestinatarioVencOfertas.Multiline = true;
            this.txtDestinatarioVencOfertas.Name = "txtDestinatarioVencOfertas";
            this.txtDestinatarioVencOfertas.Size = new System.Drawing.Size(323, 44);
            this.txtDestinatarioVencOfertas.TabIndex = 6;
            // 
            // txtDestinatariosAutPerdida
            // 
            this.txtDestinatariosAutPerdida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestinatariosAutPerdida.ForeColor = System.Drawing.Color.Blue;
            this.txtDestinatariosAutPerdida.Location = new System.Drawing.Point(13, 325);
            this.txtDestinatariosAutPerdida.Multiline = true;
            this.txtDestinatariosAutPerdida.Name = "txtDestinatariosAutPerdida";
            this.txtDestinatariosAutPerdida.Size = new System.Drawing.Size(323, 44);
            this.txtDestinatariosAutPerdida.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(14, 372);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(322, 31);
            this.label7.TabIndex = 65;
            this.label7.Text = "(*) Si deja vacío no se enviará el correo y puede concatenar destinatarios con \'," +
    "\' o \';\'";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 309);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(273, 13);
            this.label8.TabIndex = 64;
            this.label8.Text = "Destinatarios notificación sobre Autorizaciones a pérdida";
            // 
            // txtTasaIVAPickUp
            // 
            this.txtTasaIVAPickUp.DecimalPlaces = 2;
            this.txtTasaIVAPickUp.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.txtTasaIVAPickUp.Location = new System.Drawing.Point(187, 137);
            this.txtTasaIVAPickUp.Name = "txtTasaIVAPickUp";
            this.txtTasaIVAPickUp.Size = new System.Drawing.Size(70, 20);
            this.txtTasaIVAPickUp.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 139);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 13);
            this.label9.TabIndex = 67;
            this.label9.Text = "Tasa IVA Modelos PickUp";
            // 
            // txtTasaIVAResto
            // 
            this.txtTasaIVAResto.DecimalPlaces = 2;
            this.txtTasaIVAResto.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.txtTasaIVAResto.Location = new System.Drawing.Point(187, 163);
            this.txtTasaIVAResto.Name = "txtTasaIVAResto";
            this.txtTasaIVAResto.Size = new System.Drawing.Size(70, 20);
            this.txtTasaIVAResto.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 13);
            this.label10.TabIndex = 69;
            this.label10.Text = "Tasa IVA Modelos Resto";
            // 
            // FormParametrosVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 461);
            this.Controls.Add(this.txtTasaIVAResto);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTasaIVAPickUp);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDestinatariosAutPerdida);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDestinatarioVencOfertas);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPorGstPatentamiento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPorcCobARecup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbFormasPagoContado);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.txtMesesRetroPauta);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormParametrosVentas";
            this.Text = "Parámetros de Venta";
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtMesesRetroPauta, 0);
            this.Controls.SetChildIndex(this.lblProveedor, 0);
            this.Controls.SetChildIndex(this.cmbFormasPagoContado, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtPorcCobARecup, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtPorGstPatentamiento, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtDestinatarioVencOfertas, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtDestinatariosAutPerdida, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtTasaIVAPickUp, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.txtTasaIVAResto, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txtMesesRetroPauta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorcCobARecup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorGstPatentamiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTasaIVAPickUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTasaIVAResto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.CustomNumericUpDown txtMesesRetroPauta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFormasPagoContado;
        private System.Windows.Forms.Label lblProveedor;
        private UserControls.CustomNumericUpDown txtPorcCobARecup;
        private UserControls.CustomNumericUpDown txtPorGstPatentamiento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDestinatarioVencOfertas;
        private System.Windows.Forms.TextBox txtDestinatariosAutPerdida;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private UserControls.CustomNumericUpDown txtTasaIVAPickUp;
        private System.Windows.Forms.Label label9;
        private UserControls.CustomNumericUpDown txtTasaIVAResto;
        private System.Windows.Forms.Label label10;
    }
}