
namespace FullCarMultimarca.UI.Ventas
{
    partial class FormEnviarPorMailFormulario
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
            this.cmbDestinatarioEmail = new System.Windows.Forms.ComboBox();
            this.btnEnviarMail = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBodyMensaje = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNroOperacion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbDestinatarioEmail
            // 
            this.cmbDestinatarioEmail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDestinatarioEmail.FormattingEnabled = true;
            this.cmbDestinatarioEmail.Location = new System.Drawing.Point(15, 55);
            this.cmbDestinatarioEmail.Name = "cmbDestinatarioEmail";
            this.cmbDestinatarioEmail.Size = new System.Drawing.Size(356, 21);
            this.cmbDestinatarioEmail.TabIndex = 0;
            // 
            // btnEnviarMail
            // 
            this.btnEnviarMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviarMail.Image = global::FullCarMultimarca.UI.Properties.Resources.mail_forward;
            this.btnEnviarMail.Location = new System.Drawing.Point(206, 317);
            this.btnEnviarMail.Name = "btnEnviarMail";
            this.btnEnviarMail.Size = new System.Drawing.Size(81, 23);
            this.btnEnviarMail.TabIndex = 2;
            this.btnEnviarMail.Text = "Enviar";
            this.btnEnviarMail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviarMail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEnviarMail.UseVisualStyleBackColor = true;
            this.btnEnviarMail.Click += new System.EventHandler(this.btnEnviarMail_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(293, 317);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seleccione mail del cliente...";
            // 
            // txtBodyMensaje
            // 
            this.txtBodyMensaje.AcceptsReturn = true;
            this.txtBodyMensaje.AcceptsTab = true;
            this.txtBodyMensaje.Location = new System.Drawing.Point(12, 171);
            this.txtBodyMensaje.Multiline = true;
            this.txtBodyMensaje.Name = "txtBodyMensaje";
            this.txtBodyMensaje.Size = new System.Drawing.Size(356, 140);
            this.txtBodyMensaje.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Escriba su mensaje al cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "De";
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(39, 82);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.ReadOnly = true;
            this.txtFrom.Size = new System.Drawing.Size(329, 20);
            this.txtFrom.TabIndex = 8;
            this.txtFrom.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Su nombre será anexado en el cuerpo del e-mail.";
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(39, 132);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.ReadOnly = true;
            this.txtNombreCliente.Size = new System.Drawing.Size(329, 20);
            this.txtNombreCliente.TabIndex = 11;
            this.txtNombreCliente.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "A";
            // 
            // txtNroOperacion
            // 
            this.txtNroOperacion.Location = new System.Drawing.Point(193, 12);
            this.txtNroOperacion.Name = "txtNroOperacion";
            this.txtNroOperacion.ReadOnly = true;
            this.txtNroOperacion.Size = new System.Drawing.Size(178, 20);
            this.txtNroOperacion.TabIndex = 13;
            this.txtNroOperacion.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(108, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Nro. Operación";
            // 
            // FormEnviarPorMailFormulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 352);
            this.Controls.Add(this.txtNroOperacion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNombreCliente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBodyMensaje);
            this.Controls.Add(this.cmbDestinatarioEmail);
            this.Controls.Add(this.btnEnviarMail);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEnviarPorMailFormulario";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enviar por mail al cliente";
            this.Load += new System.EventHandler(this.FormEnviarPorMailFormulario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox cmbDestinatarioEmail;
        private System.Windows.Forms.Button btnEnviarMail;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBodyMensaje;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNroOperacion;
        private System.Windows.Forms.Label label6;
    }
}