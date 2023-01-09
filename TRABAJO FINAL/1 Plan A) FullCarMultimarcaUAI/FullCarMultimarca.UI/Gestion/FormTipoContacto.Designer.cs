
namespace FullCarMultimarca.UI.Gestion
{
    partial class FormTipoContacto
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
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ckActivo = new System.Windows.Forms.CheckBox();
            this.txtExpresionRegular = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTextoAyuda = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ckPermiteNotificaciones = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(321, 243);
            this.btnGuardar.TabIndex = 4;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(396, 243);
            this.btnCancelar.TabIndex = 5;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(81, 34);
            this.txtDescripcion.MaxLength = 50;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(211, 20);
            this.txtDescripcion.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Descripción";
            // 
            // ckActivo
            // 
            this.ckActivo.AutoSize = true;
            this.ckActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckActivo.Checked = true;
            this.ckActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckActivo.Location = new System.Drawing.Point(409, 12);
            this.ckActivo.Name = "ckActivo";
            this.ckActivo.Size = new System.Drawing.Size(56, 17);
            this.ckActivo.TabIndex = 6;
            this.ckActivo.Text = "Activo";
            this.ckActivo.UseVisualStyleBackColor = true;
            // 
            // txtExpresionRegular
            // 
            this.txtExpresionRegular.Location = new System.Drawing.Point(15, 93);
            this.txtExpresionRegular.MaxLength = 150;
            this.txtExpresionRegular.Name = "txtExpresionRegular";
            this.txtExpresionRegular.Size = new System.Drawing.Size(450, 20);
            this.txtExpresionRegular.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Expresión de Valicación";
            // 
            // txtTextoAyuda
            // 
            this.txtTextoAyuda.Location = new System.Drawing.Point(15, 163);
            this.txtTextoAyuda.MaxLength = 500;
            this.txtTextoAyuda.Multiline = true;
            this.txtTextoAyuda.Name = "txtTextoAyuda";
            this.txtTextoAyuda.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTextoAyuda.Size = new System.Drawing.Size(450, 49);
            this.txtTextoAyuda.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Texto Ayuda";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(293, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "(*) Expresión regular opcional para validar el tipo de contacto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(394, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "(*) Texto de ayuda opcional para describir el formato de carga del tipo de contac" +
    "to";
            // 
            // ckPermiteNotificaciones
            // 
            this.ckPermiteNotificaciones.AutoSize = true;
            this.ckPermiteNotificaciones.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckPermiteNotificaciones.Location = new System.Drawing.Point(15, 247);
            this.ckPermiteNotificaciones.Name = "ckPermiteNotificaciones";
            this.ckPermiteNotificaciones.Size = new System.Drawing.Size(232, 17);
            this.ckPermiteNotificaciones.TabIndex = 3;
            this.ckPermiteNotificaciones.Text = "Este tipo de contacto permite notificaciones";
            this.ckPermiteNotificaciones.UseVisualStyleBackColor = true;
            // 
            // FormTipoContacto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 278);
            this.Controls.Add(this.ckPermiteNotificaciones);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTextoAyuda);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtExpresionRegular);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ckActivo);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FormTipoContacto";
            this.Text = "Tipo de Contacto";
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.ckActivo, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtExpresionRegular, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtTextoAyuda, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.ckPermiteNotificaciones, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckActivo;
        private System.Windows.Forms.TextBox txtExpresionRegular;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTextoAyuda;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ckPermiteNotificaciones;
    }
}