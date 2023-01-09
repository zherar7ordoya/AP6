
namespace FullCarMultimarca.UI.Seguridad
{
    partial class FormCargarPalabraClave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCargarPalabraClave));
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRespuestaClave = new System.Windows.Forms.TextBox();
            this.lblRepClave = new System.Windows.Forms.Label();
            this.txtPalabraClave = new System.Windows.Forms.TextBox();
            this.lblNuevaClave = new System.Windows.Forms.Label();
            this.lblInfoLogin = new System.Windows.Forms.Label();
            this.txtClaveActual = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(321, 236);
            this.btnGuardar.TabIndex = 3;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(396, 236);
            this.btnCancelar.TabIndex = 4;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(85, 78);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(168, 20);
            this.txtUsuario.TabIndex = 34;
            this.txtUsuario.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Logon";
            // 
            // txtRespuestaClave
            // 
            this.txtRespuestaClave.Location = new System.Drawing.Point(16, 205);
            this.txtRespuestaClave.Name = "txtRespuestaClave";
            this.txtRespuestaClave.Size = new System.Drawing.Size(450, 20);
            this.txtRespuestaClave.TabIndex = 2;
            // 
            // lblRepClave
            // 
            this.lblRepClave.AutoSize = true;
            this.lblRepClave.Location = new System.Drawing.Point(13, 189);
            this.lblRepClave.Name = "lblRepClave";
            this.lblRepClave.Size = new System.Drawing.Size(170, 13);
            this.lblRepClave.TabIndex = 33;
            this.lblRepClave.Text = "Respuesta que uds. proporcionará";
            // 
            // txtPalabraClave
            // 
            this.txtPalabraClave.Location = new System.Drawing.Point(16, 157);
            this.txtPalabraClave.Name = "txtPalabraClave";
            this.txtPalabraClave.Size = new System.Drawing.Size(450, 20);
            this.txtPalabraClave.TabIndex = 1;
            // 
            // lblNuevaClave
            // 
            this.lblNuevaClave.AutoSize = true;
            this.lblNuevaClave.Location = new System.Drawing.Point(13, 141);
            this.lblNuevaClave.Name = "lblNuevaClave";
            this.lblNuevaClave.Size = new System.Drawing.Size(195, 13);
            this.lblNuevaClave.TabIndex = 32;
            this.lblNuevaClave.Text = "Texto o Palabra que el sistema mostrará";
            // 
            // lblInfoLogin
            // 
            this.lblInfoLogin.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblInfoLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInfoLogin.Location = new System.Drawing.Point(0, 0);
            this.lblInfoLogin.Name = "lblInfoLogin";
            this.lblInfoLogin.Size = new System.Drawing.Size(477, 61);
            this.lblInfoLogin.TabIndex = 36;
            this.lblInfoLogin.Text = resources.GetString("lblInfoLogin.Text");
            // 
            // txtClaveActual
            // 
            this.txtClaveActual.Location = new System.Drawing.Point(85, 110);
            this.txtClaveActual.Name = "txtClaveActual";
            this.txtClaveActual.PasswordChar = '*';
            this.txtClaveActual.Size = new System.Drawing.Size(168, 20);
            this.txtClaveActual.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Clave actual";
            // 
            // FormCargarPalabraClave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 271);
            this.Controls.Add(this.txtClaveActual);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblInfoLogin);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRespuestaClave);
            this.Controls.Add(this.lblRepClave);
            this.Controls.Add(this.txtPalabraClave);
            this.Controls.Add(this.lblNuevaClave);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCargarPalabraClave";
            this.Text = "Palabra Clave";
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.lblNuevaClave, 0);
            this.Controls.SetChildIndex(this.txtPalabraClave, 0);
            this.Controls.SetChildIndex(this.lblRepClave, 0);
            this.Controls.SetChildIndex(this.txtRespuestaClave, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtUsuario, 0);
            this.Controls.SetChildIndex(this.lblInfoLogin, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtClaveActual, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRespuestaClave;
        private System.Windows.Forms.Label lblRepClave;
        private System.Windows.Forms.TextBox txtPalabraClave;
        private System.Windows.Forms.Label lblNuevaClave;
        private System.Windows.Forms.Label lblInfoLogin;
        private System.Windows.Forms.TextBox txtClaveActual;
        private System.Windows.Forms.Label label1;
    }
}