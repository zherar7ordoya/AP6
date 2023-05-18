
namespace Vista
{
    partial class OperacionVista
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Num1TextBox = new System.Windows.Forms.TextBox();
            this.Num2TextBox = new System.Windows.Forms.TextBox();
            this.ResultadoButton = new System.Windows.Forms.Button();
            this.ResultadoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Num1TextBox
            // 
            this.Num1TextBox.Location = new System.Drawing.Point(13, 13);
            this.Num1TextBox.Name = "Num1TextBox";
            this.Num1TextBox.Size = new System.Drawing.Size(100, 20);
            this.Num1TextBox.TabIndex = 0;
            // 
            // Num2TextBox
            // 
            this.Num2TextBox.Location = new System.Drawing.Point(119, 13);
            this.Num2TextBox.Name = "Num2TextBox";
            this.Num2TextBox.Size = new System.Drawing.Size(100, 20);
            this.Num2TextBox.TabIndex = 1;
            // 
            // ResultadoButton
            // 
            this.ResultadoButton.Location = new System.Drawing.Point(225, 13);
            this.ResultadoButton.Name = "ResultadoButton";
            this.ResultadoButton.Size = new System.Drawing.Size(100, 20);
            this.ResultadoButton.TabIndex = 2;
            this.ResultadoButton.Text = "Resultado";
            this.ResultadoButton.UseVisualStyleBackColor = true;
            this.ResultadoButton.Click += new System.EventHandler(this.Resultado_Click);
            // 
            // ResultadoLabel
            // 
            this.ResultadoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ResultadoLabel.Location = new System.Drawing.Point(331, 13);
            this.ResultadoLabel.Name = "ResultadoLabel";
            this.ResultadoLabel.Size = new System.Drawing.Size(100, 20);
            this.ResultadoLabel.TabIndex = 3;
            this.ResultadoLabel.Text = "Resultado";
            this.ResultadoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OperacionVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 50);
            this.Controls.Add(this.ResultadoLabel);
            this.Controls.Add(this.ResultadoButton);
            this.Controls.Add(this.Num2TextBox);
            this.Controls.Add(this.Num1TextBox);
            this.Name = "OperacionVista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Operación (Suma)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Num1TextBox;
        private System.Windows.Forms.TextBox Num2TextBox;
        private System.Windows.Forms.Button ResultadoButton;
        private System.Windows.Forms.Label ResultadoLabel;
    }
}

