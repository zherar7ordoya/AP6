
namespace FullCarMultimarca.UI.Seguridad
{
    partial class FormParametros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormParametros));
            this.grupoSeguridad = new System.Windows.Forms.GroupBox();
            this.txtDiasVigenciaClave = new FullCarMultimarca.UI.UserControls.CustomNumericUpDown();
            this.txtIntentosBloqueoClave = new FullCarMultimarca.UI.UserControls.CustomNumericUpDown();
            this.txtMinCaracteresClave = new FullCarMultimarca.UI.UserControls.CustomNumericUpDown();
            this.ckDebeContenerCaracterEspecial = new System.Windows.Forms.CheckBox();
            this.ckDebeContenerMinuscula = new System.Windows.Forms.CheckBox();
            this.ckDebeContenerMayuscula = new System.Windows.Forms.CheckBox();
            this.ckDebeContenerNumero = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grupoSeguridad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiasVigenciaClave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIntentosBloqueoClave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinCaracteresClave)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(302, 200);
            this.btnGuardar.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(377, 200);
            this.btnCancelar.TabIndex = 2;
            // 
            // grupoSeguridad
            // 
            this.grupoSeguridad.Controls.Add(this.txtDiasVigenciaClave);
            this.grupoSeguridad.Controls.Add(this.txtIntentosBloqueoClave);
            this.grupoSeguridad.Controls.Add(this.txtMinCaracteresClave);
            this.grupoSeguridad.Controls.Add(this.ckDebeContenerCaracterEspecial);
            this.grupoSeguridad.Controls.Add(this.ckDebeContenerMinuscula);
            this.grupoSeguridad.Controls.Add(this.ckDebeContenerMayuscula);
            this.grupoSeguridad.Controls.Add(this.ckDebeContenerNumero);
            this.grupoSeguridad.Controls.Add(this.label5);
            this.grupoSeguridad.Controls.Add(this.label6);
            this.grupoSeguridad.Controls.Add(this.label4);
            this.grupoSeguridad.Controls.Add(this.label3);
            this.grupoSeguridad.Controls.Add(this.label2);
            this.grupoSeguridad.Controls.Add(this.label1);
            this.grupoSeguridad.Location = new System.Drawing.Point(12, 12);
            this.grupoSeguridad.Name = "grupoSeguridad";
            this.grupoSeguridad.Size = new System.Drawing.Size(434, 182);
            this.grupoSeguridad.TabIndex = 0;
            this.grupoSeguridad.TabStop = false;
            this.grupoSeguridad.Text = "Contraseña";
            // 
            // txtDiasVigenciaClave
            // 
            this.txtDiasVigenciaClave.Location = new System.Drawing.Point(119, 66);
            this.txtDiasVigenciaClave.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.txtDiasVigenciaClave.Name = "txtDiasVigenciaClave";
            this.txtDiasVigenciaClave.Size = new System.Drawing.Size(61, 20);
            this.txtDiasVigenciaClave.TabIndex = 2;
            // 
            // txtIntentosBloqueoClave
            // 
            this.txtIntentosBloqueoClave.Location = new System.Drawing.Point(119, 43);
            this.txtIntentosBloqueoClave.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.txtIntentosBloqueoClave.Name = "txtIntentosBloqueoClave";
            this.txtIntentosBloqueoClave.Size = new System.Drawing.Size(61, 20);
            this.txtIntentosBloqueoClave.TabIndex = 1;
            // 
            // txtMinCaracteresClave
            // 
            this.txtMinCaracteresClave.Location = new System.Drawing.Point(119, 21);
            this.txtMinCaracteresClave.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.txtMinCaracteresClave.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.txtMinCaracteresClave.Name = "txtMinCaracteresClave";
            this.txtMinCaracteresClave.Size = new System.Drawing.Size(61, 20);
            this.txtMinCaracteresClave.TabIndex = 0;
            this.txtMinCaracteresClave.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // ckDebeContenerCaracterEspecial
            // 
            this.ckDebeContenerCaracterEspecial.AutoSize = true;
            this.ckDebeContenerCaracterEspecial.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckDebeContenerCaracterEspecial.Location = new System.Drawing.Point(170, 159);
            this.ckDebeContenerCaracterEspecial.Name = "ckDebeContenerCaracterEspecial";
            this.ckDebeContenerCaracterEspecial.Size = new System.Drawing.Size(241, 17);
            this.ckDebeContenerCaracterEspecial.TabIndex = 6;
            this.ckDebeContenerCaracterEspecial.Text = "Debe contener al menos un caractér especial";
            this.ckDebeContenerCaracterEspecial.UseVisualStyleBackColor = true;
            // 
            // ckDebeContenerMinuscula
            // 
            this.ckDebeContenerMinuscula.AutoSize = true;
            this.ckDebeContenerMinuscula.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckDebeContenerMinuscula.Location = new System.Drawing.Point(198, 137);
            this.ckDebeContenerMinuscula.Name = "ckDebeContenerMinuscula";
            this.ckDebeContenerMinuscula.Size = new System.Drawing.Size(213, 17);
            this.ckDebeContenerMinuscula.TabIndex = 5;
            this.ckDebeContenerMinuscula.Text = "Debe contener al menos una minúscula";
            this.ckDebeContenerMinuscula.UseVisualStyleBackColor = true;
            // 
            // ckDebeContenerMayuscula
            // 
            this.ckDebeContenerMayuscula.AutoSize = true;
            this.ckDebeContenerMayuscula.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckDebeContenerMayuscula.Location = new System.Drawing.Point(195, 114);
            this.ckDebeContenerMayuscula.Name = "ckDebeContenerMayuscula";
            this.ckDebeContenerMayuscula.Size = new System.Drawing.Size(216, 17);
            this.ckDebeContenerMayuscula.TabIndex = 4;
            this.ckDebeContenerMayuscula.Text = "Debe contener al menos una mayúscula";
            this.ckDebeContenerMayuscula.UseVisualStyleBackColor = true;
            // 
            // ckDebeContenerNumero
            // 
            this.ckDebeContenerNumero.AutoSize = true;
            this.ckDebeContenerNumero.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckDebeContenerNumero.Location = new System.Drawing.Point(216, 91);
            this.ckDebeContenerNumero.Name = "ckDebeContenerNumero";
            this.ckDebeContenerNumero.Size = new System.Drawing.Size(195, 17);
            this.ckDebeContenerNumero.TabIndex = 3;
            this.ckDebeContenerNumero.Text = "Debe contener al menos un número";
            this.ckDebeContenerNumero.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(192, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "(0 - Nunca Expira)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Días Vigencia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "(0 - Sin Limite)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Intentos bloqueo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "(Como mínimo deben usarse 4 caractéres)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mínimo caractéres";
            // 
            // FormParametros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 235);
            this.Controls.Add(this.grupoSeguridad);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormParametros";
            this.Text = "Parámetros de Seguirdad";
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.grupoSeguridad, 0);
            this.grupoSeguridad.ResumeLayout(false);
            this.grupoSeguridad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiasVigenciaClave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIntentosBloqueoClave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinCaracteresClave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grupoSeguridad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckDebeContenerCaracterEspecial;
        private System.Windows.Forms.CheckBox ckDebeContenerMinuscula;
        private System.Windows.Forms.CheckBox ckDebeContenerMayuscula;
        private System.Windows.Forms.CheckBox ckDebeContenerNumero;
        private UserControls.CustomNumericUpDown txtMinCaracteresClave;
        private UserControls.CustomNumericUpDown txtIntentosBloqueoClave;
        private UserControls.CustomNumericUpDown txtDiasVigenciaClave;
    }
}