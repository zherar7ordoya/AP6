
namespace FullCarMultimarca.UI.Seguridad
{
    partial class FormRestablecerClave
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
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRespuestaClave = new System.Windows.Forms.TextBox();
            this.lblRepClave = new System.Windows.Forms.Label();
            this.lblPalabraClave = new System.Windows.Forms.Label();
            this.txtClaveRep = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNuevaClave = new System.Windows.Forms.TextBox();
            this.lblNuevaClave = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEnviarCodigoRestauracion = new System.Windows.Forms.Button();
            this.txtEmailUsuario = new System.Windows.Forms.TextBox();
            this.lineSeparator1 = new FullCarMultimarca.UI.UserControls.LineSeparator();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnGuardar.Location = new System.Drawing.Point(223, 210);
            this.btnGuardar.TabIndex = 3;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancelar.Location = new System.Drawing.Point(298, 210);
            this.btnCancelar.TabIndex = 4;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(55, 12);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(168, 20);
            this.txtUsuario.TabIndex = 39;
            this.txtUsuario.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Logon";
            // 
            // txtRespuestaClave
            // 
            this.txtRespuestaClave.Location = new System.Drawing.Point(15, 132);
            this.txtRespuestaClave.Name = "txtRespuestaClave";
            this.txtRespuestaClave.Size = new System.Drawing.Size(352, 20);
            this.txtRespuestaClave.TabIndex = 0;
            // 
            // lblRepClave
            // 
            this.lblRepClave.AutoSize = true;
            this.lblRepClave.Location = new System.Drawing.Point(12, 116);
            this.lblRepClave.Name = "lblRepClave";
            this.lblRepClave.Size = new System.Drawing.Size(58, 13);
            this.lblRepClave.TabIndex = 38;
            this.lblRepClave.Text = "Respuesta";
            // 
            // lblPalabraClave
            // 
            this.lblPalabraClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalabraClave.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblPalabraClave.Location = new System.Drawing.Point(12, 68);
            this.lblPalabraClave.Name = "lblPalabraClave";
            this.lblPalabraClave.Size = new System.Drawing.Size(355, 48);
            this.lblPalabraClave.TabIndex = 37;
            this.lblPalabraClave.Text = "PALABRA CLAVE";
            // 
            // txtClaveRep
            // 
            this.txtClaveRep.Location = new System.Drawing.Point(199, 184);
            this.txtClaveRep.Name = "txtClaveRep";
            this.txtClaveRep.PasswordChar = '*';
            this.txtClaveRep.Size = new System.Drawing.Size(168, 20);
            this.txtClaveRep.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Repetir clave";
            // 
            // txtNuevaClave
            // 
            this.txtNuevaClave.Location = new System.Drawing.Point(199, 158);
            this.txtNuevaClave.Name = "txtNuevaClave";
            this.txtNuevaClave.PasswordChar = '*';
            this.txtNuevaClave.Size = new System.Drawing.Size(168, 20);
            this.txtNuevaClave.TabIndex = 1;
            // 
            // lblNuevaClave
            // 
            this.lblNuevaClave.AutoSize = true;
            this.lblNuevaClave.Location = new System.Drawing.Point(113, 161);
            this.lblNuevaClave.Name = "lblNuevaClave";
            this.lblNuevaClave.Size = new System.Drawing.Size(68, 13);
            this.lblNuevaClave.TabIndex = 43;
            this.lblNuevaClave.Text = "Nueva clave";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Palabra (o texto) ingresado";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(15, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(263, 30);
            this.label3.TabIndex = 46;
            this.label3.Text = "O puede recibir una clave de restauración en su casilla corporativa";
            // 
            // btnEnviarCodigoRestauracion
            // 
            this.btnEnviarCodigoRestauracion.Image = global::FullCarMultimarca.UI.Properties.Resources.mail_forward;
            this.btnEnviarCodigoRestauracion.Location = new System.Drawing.Point(284, 281);
            this.btnEnviarCodigoRestauracion.Name = "btnEnviarCodigoRestauracion";
            this.btnEnviarCodigoRestauracion.Size = new System.Drawing.Size(83, 23);
            this.btnEnviarCodigoRestauracion.TabIndex = 47;
            this.btnEnviarCodigoRestauracion.Text = "Enviar...";
            this.btnEnviarCodigoRestauracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviarCodigoRestauracion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEnviarCodigoRestauracion.UseVisualStyleBackColor = true;
            this.btnEnviarCodigoRestauracion.Click += new System.EventHandler(this.btnEnviarCodigoRestauracion_Click);
            // 
            // txtEmailUsuario
            // 
            this.txtEmailUsuario.Location = new System.Drawing.Point(18, 282);
            this.txtEmailUsuario.Name = "txtEmailUsuario";
            this.txtEmailUsuario.ReadOnly = true;
            this.txtEmailUsuario.Size = new System.Drawing.Size(260, 20);
            this.txtEmailUsuario.TabIndex = 49;
            this.txtEmailUsuario.TabStop = false;
            // 
            // lineSeparator1
            // 
            this.lineSeparator1.Location = new System.Drawing.Point(12, 248);
            this.lineSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineSeparator1.Name = "lineSeparator1";
            this.lineSeparator1.Size = new System.Drawing.Size(355, 2);
            this.lineSeparator1.TabIndex = 48;
            // 
            // FormRestablecerClave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 314);
            this.Controls.Add(this.txtEmailUsuario);
            this.Controls.Add(this.lineSeparator1);
            this.Controls.Add(this.btnEnviarCodigoRestauracion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtClaveRep);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNuevaClave);
            this.Controls.Add(this.lblNuevaClave);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRespuestaClave);
            this.Controls.Add(this.lblRepClave);
            this.Controls.Add(this.lblPalabraClave);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FormRestablecerClave";
            this.Text = "Restablecer Clave";
            this.Controls.SetChildIndex(this.lblPalabraClave, 0);
            this.Controls.SetChildIndex(this.lblRepClave, 0);
            this.Controls.SetChildIndex(this.txtRespuestaClave, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtUsuario, 0);
            this.Controls.SetChildIndex(this.lblNuevaClave, 0);
            this.Controls.SetChildIndex(this.txtNuevaClave, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtClaveRep, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.btnEnviarCodigoRestauracion, 0);
            this.Controls.SetChildIndex(this.lineSeparator1, 0);
            this.Controls.SetChildIndex(this.txtEmailUsuario, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRespuestaClave;
        private System.Windows.Forms.Label lblRepClave;
        private System.Windows.Forms.Label lblPalabraClave;
        private System.Windows.Forms.TextBox txtClaveRep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNuevaClave;
        private System.Windows.Forms.Label lblNuevaClave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEnviarCodigoRestauracion;
        private UserControls.LineSeparator lineSeparator1;
        private System.Windows.Forms.TextBox txtEmailUsuario;
    }
}