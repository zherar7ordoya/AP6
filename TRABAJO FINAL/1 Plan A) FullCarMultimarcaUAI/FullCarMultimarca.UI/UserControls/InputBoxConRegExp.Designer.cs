namespace FullCarMultimarca.UI.UserControls
{
    partial class InputBoxConRegExp
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtNumerico = new System.Windows.Forms.TextBox();
            this.btnUndo = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // txtNumerico
            // 
            this.txtNumerico.Location = new System.Drawing.Point(0, 0);
            this.txtNumerico.Name = "txtNumerico";
            this.txtNumerico.Size = new System.Drawing.Size(254, 20);
            this.txtNumerico.TabIndex = 0;
            this.txtNumerico.TextChanged += new System.EventHandler(this.txtNumerico_TextChanged);
            this.txtNumerico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumerico_KeyPress);
            // 
            // btnUndo
            // 
            this.btnUndo.Image = global::FullCarMultimarca.UI.Properties.Resources.undo;
            this.btnUndo.Location = new System.Drawing.Point(260, 0);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(26, 21);
            this.btnUndo.TabIndex = 1;
            this.btnUndo.TabStop = false;
            this.toolTip1.SetToolTip(this.btnUndo, "Restablecer valor original");
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Visible = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // InputBoxConRegExp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.txtNumerico);
            this.Name = "InputBoxConRegExp";
            this.Size = new System.Drawing.Size(286, 21);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.InputBoxConRegExp_Validating);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumerico;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
