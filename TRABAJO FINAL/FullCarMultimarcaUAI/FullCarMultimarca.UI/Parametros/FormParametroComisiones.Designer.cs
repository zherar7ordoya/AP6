
namespace FullCarMultimarca.UI.Parametros
{
    partial class FormParametroComisiones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormParametroComisiones));
            this.txtPorComisN1 = new FullCarMultimarca.UI.UserControls.CustomNumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCantMinN2 = new FullCarMultimarca.UI.UserControls.CustomNumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtImpPremioVolumen = new FullCarMultimarca.UI.UserControls.DecimalTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPorComisN2 = new FullCarMultimarca.UI.UserControls.CustomNumericUpDown();
            this.txtPorComisN3 = new FullCarMultimarca.UI.UserControls.CustomNumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCantMinN3 = new FullCarMultimarca.UI.UserControls.CustomNumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorComisN1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantMinN2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorComisN2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorComisN3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantMinN3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(263, 149);
            this.btnGuardar.TabIndex = 7;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(338, 149);
            this.btnCancelar.TabIndex = 8;
            // 
            // txtPorComisN1
            // 
            this.txtPorComisN1.DecimalPlaces = 2;
            this.txtPorComisN1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.txtPorComisN1.Location = new System.Drawing.Point(158, 21);
            this.txtPorComisN1.Name = "txtPorComisN1";
            this.txtPorComisN1.Size = new System.Drawing.Size(70, 20);
            this.txtPorComisN1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 60;
            this.label3.Text = "Porcentaje Comisión N1";
            // 
            // txtCantMinN2
            // 
            this.txtCantMinN2.Location = new System.Drawing.Point(344, 47);
            this.txtCantMinN2.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.txtCantMinN2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtCantMinN2.Name = "txtCantMinN2";
            this.txtCantMinN2.Size = new System.Drawing.Size(61, 20);
            this.txtCantMinN2.TabIndex = 2;
            this.txtCantMinN2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "Cantidad Mínima N2";
            // 
            // txtImpPremioVolumen
            // 
            this.txtImpPremioVolumen.Location = new System.Drawing.Point(272, 109);
            this.txtImpPremioVolumen.Mask = "00000000.00";
            this.txtImpPremioVolumen.Name = "txtImpPremioVolumen";
            this.txtImpPremioVolumen.Size = new System.Drawing.Size(133, 20);
            this.txtImpPremioVolumen.TabIndex = 5;
            this.txtImpPremioVolumen.Text = "        00";
            this.txtImpPremioVolumen.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtImpPremioVolumen.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 62;
            this.label2.Text = "Importe Premio por Volumen";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 63;
            this.label4.Text = "Porcentaje Comisión N2";
            // 
            // txtPorComisN2
            // 
            this.txtPorComisN2.DecimalPlaces = 2;
            this.txtPorComisN2.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.txtPorComisN2.Location = new System.Drawing.Point(158, 47);
            this.txtPorComisN2.Name = "txtPorComisN2";
            this.txtPorComisN2.Size = new System.Drawing.Size(70, 20);
            this.txtPorComisN2.TabIndex = 1;
            // 
            // txtPorComisN3
            // 
            this.txtPorComisN3.DecimalPlaces = 2;
            this.txtPorComisN3.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.txtPorComisN3.Location = new System.Drawing.Point(158, 73);
            this.txtPorComisN3.Name = "txtPorComisN3";
            this.txtPorComisN3.Size = new System.Drawing.Size(70, 20);
            this.txtPorComisN3.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 13);
            this.label5.TabIndex = 67;
            this.label5.Text = "Porcentaje Comisión N3";
            // 
            // txtCantMinN3
            // 
            this.txtCantMinN3.Location = new System.Drawing.Point(344, 73);
            this.txtCantMinN3.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.txtCantMinN3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtCantMinN3.Name = "txtCantMinN3";
            this.txtCantMinN3.Size = new System.Drawing.Size(61, 20);
            this.txtCantMinN3.TabIndex = 4;
            this.txtCantMinN3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(236, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 66;
            this.label6.Text = "Cantidad Mínima N3";
            // 
            // FormParametroComisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 184);
            this.Controls.Add(this.txtPorComisN3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCantMinN3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPorComisN2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtImpPremioVolumen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPorComisN1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCantMinN2);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormParametroComisiones";
            this.Text = "Parámetros de Comisiones";
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtCantMinN2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtPorComisN1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtImpPremioVolumen, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtPorComisN2, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtCantMinN3, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtPorComisN3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txtPorComisN1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantMinN2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorComisN2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorComisN3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantMinN3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.CustomNumericUpDown txtPorComisN1;
        private System.Windows.Forms.Label label3;
        private UserControls.CustomNumericUpDown txtCantMinN2;
        private System.Windows.Forms.Label label1;
        private UserControls.DecimalTextBox txtImpPremioVolumen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private UserControls.CustomNumericUpDown txtPorComisN2;
        private UserControls.CustomNumericUpDown txtPorComisN3;
        private System.Windows.Forms.Label label5;
        private UserControls.CustomNumericUpDown txtCantMinN3;
        private System.Windows.Forms.Label label6;
    }
}