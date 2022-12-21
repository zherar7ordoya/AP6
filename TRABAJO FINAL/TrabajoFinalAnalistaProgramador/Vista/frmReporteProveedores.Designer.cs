namespace Vista
{
    partial class frmReporteProveedores
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.accesoDBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_Proveedor = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btn_Volver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.accesoDBBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // accesoDBBindingSource
            // 
            this.accesoDBBindingSource.DataSource = typeof(DAO.AccesoDB);
            // 
            // report_Proveedor
            // 
            reportDataSource2.Name = "DataSet3";
            reportDataSource2.Value = this.accesoDBBindingSource;
            this.report_Proveedor.LocalReport.DataSources.Add(reportDataSource2);
            this.report_Proveedor.LocalReport.ReportEmbeddedResource = "Vista.report_Proveedor.rdlc";
            this.report_Proveedor.Location = new System.Drawing.Point(-1, 65);
            this.report_Proveedor.Name = "report_Proveedor";
            this.report_Proveedor.ServerReport.BearerToken = null;
            this.report_Proveedor.Size = new System.Drawing.Size(978, 603);
            this.report_Proveedor.TabIndex = 0;
            // 
            // btn_Volver
            // 
            this.btn_Volver.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_Volver.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btn_Volver.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_Volver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_Volver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Volver.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Volver.ForeColor = System.Drawing.Color.White;
            this.btn_Volver.Location = new System.Drawing.Point(884, 17);
            this.btn_Volver.Name = "btn_Volver";
            this.btn_Volver.Size = new System.Drawing.Size(75, 32);
            this.btn_Volver.TabIndex = 1;
            this.btn_Volver.Text = "Volver";
            this.btn_Volver.UseVisualStyleBackColor = false;
            // 
            // frmReporteProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(974, 661);
            this.Controls.Add(this.btn_Volver);
            this.Controls.Add(this.report_Proveedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReporteProveedores";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReporteProveedores";
            ((System.ComponentModel.ISupportInitialize)(this.accesoDBBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer report_Proveedor;
        private System.Windows.Forms.BindingSource accesoDBBindingSource;
        private System.Windows.Forms.Button btn_Volver;
    }
}