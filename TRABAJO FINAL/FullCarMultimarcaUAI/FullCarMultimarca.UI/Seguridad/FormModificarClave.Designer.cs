namespace FullCarMultimarca.UI.Seguridad
{
    partial class FormModificarClave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormModificarClave));
            this.txtClaveRep = new System.Windows.Forms.TextBox();
            this.lblRepClave = new System.Windows.Forms.Label();
            this.txtNuevaClave = new System.Windows.Forms.TextBox();
            this.lblNuevaClave = new System.Windows.Forms.Label();
            this.txtClaveActual = new System.Windows.Forms.TextBox();
            this.lblClaveActual = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(122, 134);
            this.btnGuardar.TabIndex = 3;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(197, 134);
            this.btnCancelar.TabIndex = 4;
            // 
            // txtClaveRep
            // 
            this.txtClaveRep.Location = new System.Drawing.Point(98, 98);
            this.txtClaveRep.Name = "txtClaveRep";
            this.txtClaveRep.PasswordChar = '*';
            this.txtClaveRep.Size = new System.Drawing.Size(168, 20);
            this.txtClaveRep.TabIndex = 2;
            // 
            // lblRepClave
            // 
            this.lblRepClave.AutoSize = true;
            this.lblRepClave.Location = new System.Drawing.Point(12, 101);
            this.lblRepClave.Name = "lblRepClave";
            this.lblRepClave.Size = new System.Drawing.Size(70, 13);
            this.lblRepClave.TabIndex = 25;
            this.lblRepClave.Text = "Repetir clave";
            // 
            // txtNuevaClave
            // 
            this.txtNuevaClave.Location = new System.Drawing.Point(98, 72);
            this.txtNuevaClave.Name = "txtNuevaClave";
            this.txtNuevaClave.PasswordChar = '*';
            this.txtNuevaClave.Size = new System.Drawing.Size(168, 20);
            this.txtNuevaClave.TabIndex = 1;
            // 
            // lblNuevaClave
            // 
            this.lblNuevaClave.AutoSize = true;
            this.lblNuevaClave.Location = new System.Drawing.Point(12, 75);
            this.lblNuevaClave.Name = "lblNuevaClave";
            this.lblNuevaClave.Size = new System.Drawing.Size(68, 13);
            this.lblNuevaClave.TabIndex = 24;
            this.lblNuevaClave.Text = "Nueva clave";
            // 
            // txtClaveActual
            // 
            this.txtClaveActual.Location = new System.Drawing.Point(98, 46);
            this.txtClaveActual.Name = "txtClaveActual";
            this.txtClaveActual.PasswordChar = '*';
            this.txtClaveActual.Size = new System.Drawing.Size(168, 20);
            this.txtClaveActual.TabIndex = 0;
            // 
            // lblClaveActual
            // 
            this.lblClaveActual.AutoSize = true;
            this.lblClaveActual.Location = new System.Drawing.Point(12, 49);
            this.lblClaveActual.Name = "lblClaveActual";
            this.lblClaveActual.Size = new System.Drawing.Size(66, 13);
            this.lblClaveActual.TabIndex = 27;
            this.lblClaveActual.Text = "Clave actual";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(98, 12);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(168, 20);
            this.txtUsuario.TabIndex = 28;
            this.txtUsuario.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Logon";
            // 
            // FormModificarClave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(278, 169);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtClaveActual);
            this.Controls.Add(this.lblClaveActual);
            this.Controls.Add(this.txtClaveRep);
            this.Controls.Add(this.lblRepClave);
            this.Controls.Add(this.txtNuevaClave);
            this.Controls.Add(this.lblNuevaClave);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormModificarClave";
            this.Text = "Modificación de clave";
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.lblNuevaClave, 0);
            this.Controls.SetChildIndex(this.txtNuevaClave, 0);
            this.Controls.SetChildIndex(this.lblRepClave, 0);
            this.Controls.SetChildIndex(this.txtClaveRep, 0);
            this.Controls.SetChildIndex(this.lblClaveActual, 0);
            this.Controls.SetChildIndex(this.txtClaveActual, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtUsuario, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtClaveRep;
        private System.Windows.Forms.Label lblRepClave;
        private System.Windows.Forms.TextBox txtNuevaClave;
        private System.Windows.Forms.Label lblNuevaClave;
        private System.Windows.Forms.TextBox txtClaveActual;
        private System.Windows.Forms.Label lblClaveActual;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label4;
    }
}