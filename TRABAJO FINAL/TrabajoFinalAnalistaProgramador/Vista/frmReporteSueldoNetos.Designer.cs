namespace Vista
{
    partial class frmReporteSueldoNetos
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteSueldoNetos));
            this.accesoDBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.E_SueldoNetoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btn_GenerarReporte = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.report_Sueldo = new Microsoft.Reporting.WinForms.ReportViewer();
            this.E_EmpleadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.E_GerenteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cb_NombreEmpleado = new System.Windows.Forms.ComboBox();
            this.cb_ApellidoEmpleado = new System.Windows.Forms.ComboBox();
            this.cb_NombreGerente = new System.Windows.Forms.ComboBox();
            this.cb_ApellidoGerente = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.accesoDBBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.E_SueldoNetoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.E_EmpleadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.E_GerenteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // accesoDBBindingSource
            // 
            this.accesoDBBindingSource.DataSource = typeof(DAO.AccesoDB);
            // 
            // E_SueldoNetoBindingSource
            // 
            this.E_SueldoNetoBindingSource.DataSource = typeof(Entidad.E_SueldoNeto);
            // 
            // btn_GenerarReporte
            // 
            this.btn_GenerarReporte.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_GenerarReporte.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_GenerarReporte.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GenerarReporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GenerarReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GenerarReporte.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GenerarReporte.ForeColor = System.Drawing.Color.White;
            this.btn_GenerarReporte.Location = new System.Drawing.Point(390, 212);
            this.btn_GenerarReporte.Name = "btn_GenerarReporte";
            this.btn_GenerarReporte.Size = new System.Drawing.Size(138, 37);
            this.btn_GenerarReporte.TabIndex = 3;
            this.btn_GenerarReporte.Text = "Generar reporte";
            this.btn_GenerarReporte.UseVisualStyleBackColor = false;
            this.btn_GenerarReporte.Click += new System.EventHandler(this.btn_GenerarReporte_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(46, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(46, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Apellido:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(403, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Datos Empleado:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(403, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Datos Gerente:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(46, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Nombre:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(46, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Apellido:";
            // 
            // report_Sueldo
            // 
            this.report_Sueldo.LocalReport.ReportEmbeddedResource = "Vista.report_SueldoNeto.rdlc";
            this.report_Sueldo.Location = new System.Drawing.Point(-1, 266);
            this.report_Sueldo.Name = "report_Sueldo";
            this.report_Sueldo.ServerReport.BearerToken = null;
            this.report_Sueldo.Size = new System.Drawing.Size(853, 430);
            this.report_Sueldo.TabIndex = 13;
            this.report_Sueldo.Visible = false;
            // 
            // E_EmpleadoBindingSource
            // 
            this.E_EmpleadoBindingSource.DataSource = typeof(Entidad.E_Empleado);
            // 
            // E_GerenteBindingSource
            // 
            this.E_GerenteBindingSource.DataSource = typeof(Entidad.E_Empleado);
            // 
            // cb_NombreEmpleado
            // 
            this.cb_NombreEmpleado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_NombreEmpleado.FormattingEnabled = true;
            this.cb_NombreEmpleado.Location = new System.Drawing.Point(119, 34);
            this.cb_NombreEmpleado.Name = "cb_NombreEmpleado";
            this.cb_NombreEmpleado.Size = new System.Drawing.Size(121, 25);
            this.cb_NombreEmpleado.TabIndex = 14;
            // 
            // cb_ApellidoEmpleado
            // 
            this.cb_ApellidoEmpleado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_ApellidoEmpleado.FormattingEnabled = true;
            this.cb_ApellidoEmpleado.Location = new System.Drawing.Point(119, 68);
            this.cb_ApellidoEmpleado.Name = "cb_ApellidoEmpleado";
            this.cb_ApellidoEmpleado.Size = new System.Drawing.Size(121, 25);
            this.cb_ApellidoEmpleado.TabIndex = 15;
            // 
            // cb_NombreGerente
            // 
            this.cb_NombreGerente.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_NombreGerente.FormattingEnabled = true;
            this.cb_NombreGerente.Location = new System.Drawing.Point(119, 138);
            this.cb_NombreGerente.Name = "cb_NombreGerente";
            this.cb_NombreGerente.Size = new System.Drawing.Size(121, 25);
            this.cb_NombreGerente.TabIndex = 16;
            // 
            // cb_ApellidoGerente
            // 
            this.cb_ApellidoGerente.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_ApellidoGerente.FormattingEnabled = true;
            this.cb_ApellidoGerente.Location = new System.Drawing.Point(119, 173);
            this.cb_ApellidoGerente.Name = "cb_ApellidoGerente";
            this.cb_ApellidoGerente.Size = new System.Drawing.Size(121, 25);
            this.cb_ApellidoGerente.TabIndex = 17;
            // 
            // frmReporteSueldoNetos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(852, 696);
            this.Controls.Add(this.cb_ApellidoGerente);
            this.Controls.Add(this.cb_NombreGerente);
            this.Controls.Add(this.cb_ApellidoEmpleado);
            this.Controls.Add(this.cb_NombreEmpleado);
            this.Controls.Add(this.report_Sueldo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_GenerarReporte);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReporteSueldoNetos";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte sueldo neto";
            this.Load += new System.EventHandler(this.frmReporteSueldoNetos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accesoDBBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.E_SueldoNetoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.E_EmpleadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.E_GerenteBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource E_SueldoNetoBindingSource;
        private System.Windows.Forms.BindingSource accesoDBBindingSource;
        private System.Windows.Forms.Button btn_GenerarReporte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Microsoft.Reporting.WinForms.ReportViewer report_Sueldo;
        private System.Windows.Forms.BindingSource E_EmpleadoBindingSource;
        private System.Windows.Forms.BindingSource E_GerenteBindingSource;
        private System.Windows.Forms.ComboBox cb_NombreEmpleado;
        private System.Windows.Forms.ComboBox cb_ApellidoEmpleado;
        private System.Windows.Forms.ComboBox cb_NombreGerente;
        private System.Windows.Forms.ComboBox cb_ApellidoGerente;
    }
}