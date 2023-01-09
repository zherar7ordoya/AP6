
namespace FullCarMultimarca.UI.Seguridad
{
    partial class FormPermiso
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
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblTipoProducto = new System.Windows.Forms.Label();
            this.txtPCDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPCCodigo = new System.Windows.Forms.TextBox();
            this.lblLogon = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(222, 109);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(297, 109);
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(71, 12);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(292, 21);
            this.cmbTipo.TabIndex = 53;
            // 
            // lblTipoProducto
            // 
            this.lblTipoProducto.AutoSize = true;
            this.lblTipoProducto.Location = new System.Drawing.Point(37, 15);
            this.lblTipoProducto.Name = "lblTipoProducto";
            this.lblTipoProducto.Size = new System.Drawing.Size(28, 13);
            this.lblTipoProducto.TabIndex = 54;
            this.lblTipoProducto.Text = "Tipo";
            this.lblTipoProducto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtPCDescripcion
            // 
            this.txtPCDescripcion.Location = new System.Drawing.Point(71, 65);
            this.txtPCDescripcion.MaxLength = 50;
            this.txtPCDescripcion.Name = "txtPCDescripcion";
            this.txtPCDescripcion.Size = new System.Drawing.Size(292, 20);
            this.txtPCDescripcion.TabIndex = 61;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "Descripción";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtPCCodigo
            // 
            this.txtPCCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCCodigo.Location = new System.Drawing.Point(71, 39);
            this.txtPCCodigo.MaxLength = 5;
            this.txtPCCodigo.Name = "txtPCCodigo";
            this.txtPCCodigo.Size = new System.Drawing.Size(119, 20);
            this.txtPCCodigo.TabIndex = 58;
            // 
            // lblLogon
            // 
            this.lblLogon.AutoSize = true;
            this.lblLogon.Location = new System.Drawing.Point(25, 42);
            this.lblLogon.Name = "lblLogon";
            this.lblLogon.Size = new System.Drawing.Size(40, 13);
            this.lblLogon.TabIndex = 59;
            this.lblLogon.Text = "Código";
            this.lblLogon.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormPermiso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 144);
            this.Controls.Add(this.txtPCDescripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPCCodigo);
            this.Controls.Add(this.lblLogon);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.lblTipoProducto);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FormPermiso";
            this.Text = "Permiso";
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.lblTipoProducto, 0);
            this.Controls.SetChildIndex(this.cmbTipo, 0);
            this.Controls.SetChildIndex(this.lblLogon, 0);
            this.Controls.SetChildIndex(this.txtPCCodigo, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtPCDescripcion, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblTipoProducto;
        private System.Windows.Forms.TextBox txtPCDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPCCodigo;
        private System.Windows.Forms.Label lblLogon;
    }
}