
namespace FullCarMultimarca.UI.Gestion
{
    partial class FormFormaPago
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
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTipoGasto = new System.Windows.Forms.ComboBox();
            this.lblTipoProducto = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ckActivo = new System.Windows.Forms.CheckBox();
            this.txtArancelGasto = new FullCarMultimarca.UI.UserControls.CustomNumericUpDown();
            this.grupoArancel = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtArancelGasto)).BeginInit();
            this.grupoArancel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(171, 193);
            this.btnGuardar.TabIndex = 4;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(246, 193);
            this.btnCancelar.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 60;
            this.label3.Text = "Arancel Gasto (%)";
            // 
            // cmbTipoGasto
            // 
            this.cmbTipoGasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoGasto.FormattingEnabled = true;
            this.cmbTipoGasto.Location = new System.Drawing.Point(81, 64);
            this.cmbTipoGasto.Name = "cmbTipoGasto";
            this.cmbTipoGasto.Size = new System.Drawing.Size(148, 21);
            this.cmbTipoGasto.TabIndex = 0;
            this.cmbTipoGasto.SelectedIndexChanged += new System.EventHandler(this.cmbTipoGasto_SelectedIndexChanged);
            // 
            // lblTipoProducto
            // 
            this.lblTipoProducto.AutoSize = true;
            this.lblTipoProducto.Location = new System.Drawing.Point(12, 64);
            this.lblTipoProducto.Name = "lblTipoProducto";
            this.lblTipoProducto.Size = new System.Drawing.Size(28, 13);
            this.lblTipoProducto.TabIndex = 59;
            this.lblTipoProducto.Text = "Tipo";
            this.lblTipoProducto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(81, 91);
            this.txtDescripcion.MaxLength = 50;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(234, 20);
            this.txtDescripcion.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Descripción";
            // 
            // ckActivo
            // 
            this.ckActivo.AutoSize = true;
            this.ckActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckActivo.Checked = true;
            this.ckActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckActivo.Location = new System.Drawing.Point(259, 12);
            this.ckActivo.Name = "ckActivo";
            this.ckActivo.Size = new System.Drawing.Size(56, 17);
            this.ckActivo.TabIndex = 6;
            this.ckActivo.Text = "Activa";
            this.ckActivo.UseVisualStyleBackColor = true;
            // 
            // txtArancelGasto
            // 
            this.txtArancelGasto.DecimalPlaces = 2;
            this.txtArancelGasto.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.txtArancelGasto.Location = new System.Drawing.Point(103, 23);
            this.txtArancelGasto.Name = "txtArancelGasto";
            this.txtArancelGasto.Size = new System.Drawing.Size(70, 20);
            this.txtArancelGasto.TabIndex = 0;
            // 
            // grupoArancel
            // 
            this.grupoArancel.Controls.Add(this.label3);
            this.grupoArancel.Controls.Add(this.txtArancelGasto);
            this.grupoArancel.Location = new System.Drawing.Point(12, 117);
            this.grupoArancel.Name = "grupoArancel";
            this.grupoArancel.Size = new System.Drawing.Size(303, 54);
            this.grupoArancel.TabIndex = 3;
            this.grupoArancel.TabStop = false;
            // 
            // FormFormaPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 228);
            this.Controls.Add(this.grupoArancel);
            this.Controls.Add(this.cmbTipoGasto);
            this.Controls.Add(this.lblTipoProducto);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ckActivo);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FormFormaPago";
            this.Text = "Forma de Pago";
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.ckActivo, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.Controls.SetChildIndex(this.lblTipoProducto, 0);
            this.Controls.SetChildIndex(this.cmbTipoGasto, 0);
            this.Controls.SetChildIndex(this.grupoArancel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txtArancelGasto)).EndInit();
            this.grupoArancel.ResumeLayout(false);
            this.grupoArancel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTipoGasto;
        private System.Windows.Forms.Label lblTipoProducto;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckActivo;
        private UserControls.CustomNumericUpDown txtArancelGasto;
        private System.Windows.Forms.GroupBox grupoArancel;
    }
}