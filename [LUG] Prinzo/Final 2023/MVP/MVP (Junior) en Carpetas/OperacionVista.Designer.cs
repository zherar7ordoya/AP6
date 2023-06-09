
namespace Aplicativo
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
            this.customTextbox1 = new Aplicativo.CustomTextbox();
            this.SuspendLayout();
            // 
            // Num1TextBox
            // 
            this.Num1TextBox.Location = new System.Drawing.Point(61, 25);
            this.Num1TextBox.Name = "Num1TextBox";
            this.Num1TextBox.Size = new System.Drawing.Size(100, 20);
            this.Num1TextBox.TabIndex = 0;
            // 
            // Num2TextBox
            // 
            this.Num2TextBox.Location = new System.Drawing.Point(61, 51);
            this.Num2TextBox.Name = "Num2TextBox";
            this.Num2TextBox.Size = new System.Drawing.Size(100, 20);
            this.Num2TextBox.TabIndex = 1;
            // 
            // ResultadoButton
            // 
            this.ResultadoButton.Location = new System.Drawing.Point(61, 98);
            this.ResultadoButton.Name = "ResultadoButton";
            this.ResultadoButton.Size = new System.Drawing.Size(100, 20);
            this.ResultadoButton.TabIndex = 2;
            this.ResultadoButton.Text = "Resultado";
            this.ResultadoButton.UseVisualStyleBackColor = true;
            // 
            // ResultadoLabel
            // 
            this.ResultadoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ResultadoLabel.Location = new System.Drawing.Point(61, 146);
            this.ResultadoLabel.Name = "ResultadoLabel";
            this.ResultadoLabel.Size = new System.Drawing.Size(100, 20);
            this.ResultadoLabel.TabIndex = 3;
            this.ResultadoLabel.Text = "Resultado";
            this.ResultadoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customTextbox1
            // 
            this.customTextbox1.Description = "label1";
            this.customTextbox1.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customTextbox1.LabelLocation = new System.Drawing.Point(3, 11);
            this.customTextbox1.Location = new System.Drawing.Point(32, 218);
            this.customTextbox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.customTextbox1.MultiLine = false;
            this.customTextbox1.Name = "customTextbox1";
            this.customTextbox1.PasswordChar = '\0';
            this.customTextbox1.Size = new System.Drawing.Size(178, 43);
            this.customTextbox1.TabIndex = 4;
            this.customTextbox1.TextboxLocation = new System.Drawing.Point(55, 8);
            // 
            // OperacionVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 304);
            this.Controls.Add(this.customTextbox1);
            this.Controls.Add(this.ResultadoLabel);
            this.Controls.Add(this.ResultadoButton);
            this.Controls.Add(this.Num2TextBox);
            this.Controls.Add(this.Num1TextBox);
            this.Name = "OperacionVista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Operación (Suma)";
            this.Load += new System.EventHandler(this.OperacionVista_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Num1TextBox;
        private System.Windows.Forms.TextBox Num2TextBox;
        private System.Windows.Forms.Button ResultadoButton;
        private System.Windows.Forms.Label ResultadoLabel;
        private CustomTextbox customTextbox1;
    }
}

