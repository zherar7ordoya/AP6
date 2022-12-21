namespace Vista
{
    partial class frmReporteMovimiento
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
            this.btn_Volver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Id = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_Articulo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_Fecha = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_Accion = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_Cantidad = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_PrecioCosto = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_PrecioVenta = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_Empleado = new System.Windows.Forms.Label();
            this.btn_VerInforme = new System.Windows.Forms.Button();
            this.report_Movimiento = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // btn_Volver
            // 
            this.btn_Volver.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_Volver.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btn_Volver.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_Volver.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_Volver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_Volver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Volver.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Volver.ForeColor = System.Drawing.Color.White;
            this.btn_Volver.Location = new System.Drawing.Point(621, 12);
            this.btn_Volver.Name = "btn_Volver";
            this.btn_Volver.Size = new System.Drawing.Size(75, 33);
            this.btn_Volver.TabIndex = 1;
            this.btn_Volver.Text = "Volver";
            this.btn_Volver.UseVisualStyleBackColor = false;
            this.btn_Volver.Click += new System.EventHandler(this.btn_Volver_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(323, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Resumen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(66, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Id:";
            // 
            // lbl_Id
            // 
            this.lbl_Id.AutoSize = true;
            this.lbl_Id.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Id.ForeColor = System.Drawing.Color.White;
            this.lbl_Id.Location = new System.Drawing.Point(98, 107);
            this.lbl_Id.Name = "lbl_Id";
            this.lbl_Id.Size = new System.Drawing.Size(52, 19);
            this.lbl_Id.TabIndex = 4;
            this.lbl_Id.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(28, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Artículo:";
            // 
            // lbl_Articulo
            // 
            this.lbl_Articulo.AutoSize = true;
            this.lbl_Articulo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Articulo.ForeColor = System.Drawing.Color.White;
            this.lbl_Articulo.Location = new System.Drawing.Point(98, 139);
            this.lbl_Articulo.Name = "lbl_Articulo";
            this.lbl_Articulo.Size = new System.Drawing.Size(52, 19);
            this.lbl_Articulo.TabIndex = 6;
            this.lbl_Articulo.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(35, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha:";
            // 
            // lbl_Fecha
            // 
            this.lbl_Fecha.AutoSize = true;
            this.lbl_Fecha.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Fecha.ForeColor = System.Drawing.Color.White;
            this.lbl_Fecha.Location = new System.Drawing.Point(98, 175);
            this.lbl_Fecha.Name = "lbl_Fecha";
            this.lbl_Fecha.Size = new System.Drawing.Size(52, 19);
            this.lbl_Fecha.TabIndex = 8;
            this.lbl_Fecha.Text = "label3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(322, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Acción:";
            // 
            // lbl_Accion
            // 
            this.lbl_Accion.AutoSize = true;
            this.lbl_Accion.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Accion.ForeColor = System.Drawing.Color.White;
            this.lbl_Accion.Location = new System.Drawing.Point(389, 107);
            this.lbl_Accion.Name = "lbl_Accion";
            this.lbl_Accion.Size = new System.Drawing.Size(52, 19);
            this.lbl_Accion.TabIndex = 10;
            this.lbl_Accion.Text = "label3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(302, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "Cantidad:";
            // 
            // lbl_Cantidad
            // 
            this.lbl_Cantidad.AutoSize = true;
            this.lbl_Cantidad.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Cantidad.ForeColor = System.Drawing.Color.White;
            this.lbl_Cantidad.Location = new System.Drawing.Point(389, 139);
            this.lbl_Cantidad.Name = "lbl_Cantidad";
            this.lbl_Cantidad.Size = new System.Drawing.Size(52, 19);
            this.lbl_Cantidad.TabIndex = 12;
            this.lbl_Cantidad.Text = "label3";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(287, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 19);
            this.label7.TabIndex = 13;
            this.label7.Text = "Precio costo:";
            // 
            // lbl_PrecioCosto
            // 
            this.lbl_PrecioCosto.AutoSize = true;
            this.lbl_PrecioCosto.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PrecioCosto.ForeColor = System.Drawing.Color.White;
            this.lbl_PrecioCosto.Location = new System.Drawing.Point(389, 175);
            this.lbl_PrecioCosto.Name = "lbl_PrecioCosto";
            this.lbl_PrecioCosto.Size = new System.Drawing.Size(52, 19);
            this.lbl_PrecioCosto.TabIndex = 14;
            this.lbl_PrecioCosto.Text = "label3";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(533, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 19);
            this.label8.TabIndex = 15;
            this.label8.Text = "Precio venta:";
            // 
            // lbl_PrecioVenta
            // 
            this.lbl_PrecioVenta.AutoSize = true;
            this.lbl_PrecioVenta.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PrecioVenta.ForeColor = System.Drawing.Color.White;
            this.lbl_PrecioVenta.Location = new System.Drawing.Point(639, 107);
            this.lbl_PrecioVenta.Name = "lbl_PrecioVenta";
            this.lbl_PrecioVenta.Size = new System.Drawing.Size(52, 19);
            this.lbl_PrecioVenta.TabIndex = 16;
            this.lbl_PrecioVenta.Text = "label3";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(548, 139);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 19);
            this.label9.TabIndex = 17;
            this.label9.Text = "Empleado:";
            // 
            // lbl_Empleado
            // 
            this.lbl_Empleado.AutoSize = true;
            this.lbl_Empleado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Empleado.ForeColor = System.Drawing.Color.White;
            this.lbl_Empleado.Location = new System.Drawing.Point(639, 139);
            this.lbl_Empleado.Name = "lbl_Empleado";
            this.lbl_Empleado.Size = new System.Drawing.Size(52, 19);
            this.lbl_Empleado.TabIndex = 18;
            this.lbl_Empleado.Text = "label3";
            // 
            // btn_VerInforme
            // 
            this.btn_VerInforme.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_VerInforme.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btn_VerInforme.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_VerInforme.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_VerInforme.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_VerInforme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_VerInforme.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_VerInforme.ForeColor = System.Drawing.Color.White;
            this.btn_VerInforme.Location = new System.Drawing.Point(288, 212);
            this.btn_VerInforme.Name = "btn_VerInforme";
            this.btn_VerInforme.Size = new System.Drawing.Size(164, 33);
            this.btn_VerInforme.TabIndex = 19;
            this.btn_VerInforme.Text = "Ver informe";
            this.btn_VerInforme.UseVisualStyleBackColor = false;
            this.btn_VerInforme.Click += new System.EventHandler(this.btn_VerInforme_Click);
            // 
            // report_Movimiento
            // 
            this.report_Movimiento.LocalReport.ReportEmbeddedResource = "Vista.report_Movimiento.rdlc";
            this.report_Movimiento.Location = new System.Drawing.Point(-1, 263);
            this.report_Movimiento.Name = "report_Movimiento";
            this.report_Movimiento.ServerReport.BearerToken = null;
            this.report_Movimiento.Size = new System.Drawing.Size(719, 465);
            this.report_Movimiento.TabIndex = 20;
            // 
            // frmReporteMovimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(717, 728);
            this.Controls.Add(this.report_Movimiento);
            this.Controls.Add(this.btn_VerInforme);
            this.Controls.Add(this.lbl_Empleado);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbl_PrecioVenta);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbl_PrecioCosto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbl_Cantidad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl_Accion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_Fecha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_Articulo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_Id);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Volver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReporteMovimiento";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReporteMovimiento";
            this.Load += new System.EventHandler(this.frmReporteMovimiento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Volver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label lbl_Id;
        public System.Windows.Forms.Label lbl_Articulo;
        public System.Windows.Forms.Label lbl_Fecha;
        public System.Windows.Forms.Label lbl_Accion;
        public System.Windows.Forms.Label lbl_Cantidad;
        public System.Windows.Forms.Label lbl_PrecioCosto;
        public System.Windows.Forms.Label lbl_PrecioVenta;
        public System.Windows.Forms.Label lbl_Empleado;
        private System.Windows.Forms.Button btn_VerInforme;
        private Microsoft.Reporting.WinForms.ReportViewer report_Movimiento;
    }
}