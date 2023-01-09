namespace Vista
{
    partial class frmReporteArticulos
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.E_ArticuloBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accesoDBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_Articulo = new Microsoft.Reporting.WinForms.ReportViewer();
            this.eArticuloBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btn_Volver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.E_ArticuloBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accesoDBBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eArticuloBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // E_ArticuloBindingSource
            // 
            this.E_ArticuloBindingSource.DataSource = typeof(Entidad.E_Articulo);
            // 
            // accesoDBBindingSource
            // 
            this.accesoDBBindingSource.DataSource = typeof(DAO.AccesoDB);
            // 
            // report_Articulo
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.E_ArticuloBindingSource;
            this.report_Articulo.LocalReport.DataSources.Add(reportDataSource1);
            this.report_Articulo.LocalReport.ReportEmbeddedResource = "Vista.report_Articulo.rdlc";
            this.report_Articulo.Location = new System.Drawing.Point(0, 54);
            this.report_Articulo.Name = "report_Articulo";
            this.report_Articulo.ServerReport.BearerToken = null;
            this.report_Articulo.Size = new System.Drawing.Size(1137, 650);
            this.report_Articulo.TabIndex = 0;
            // 
            // eArticuloBindingSource
            // 
            this.eArticuloBindingSource.DataSource = typeof(Entidad.E_Articulo);
            // 
            // btn_Volver
            // 
            this.btn_Volver.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_Volver.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btn_Volver.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_Volver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_Volver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Volver.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Volver.ForeColor = System.Drawing.Color.White;
            this.btn_Volver.Location = new System.Drawing.Point(1049, 12);
            this.btn_Volver.Name = "btn_Volver";
            this.btn_Volver.Size = new System.Drawing.Size(75, 36);
            this.btn_Volver.TabIndex = 1;
            this.btn_Volver.Text = "Volver";
            this.btn_Volver.UseVisualStyleBackColor = false;
            // 
            // frmReporteArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1136, 661);
            this.Controls.Add(this.btn_Volver);
            this.Controls.Add(this.report_Articulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReporteArticulos";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.E_ArticuloBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accesoDBBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eArticuloBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer report_Articulo;
        private System.Windows.Forms.BindingSource eArticuloBindingSource;
        private System.Windows.Forms.BindingSource accesoDBBindingSource;
        private System.Windows.Forms.Button btn_Volver;
        private System.Windows.Forms.BindingSource E_ArticuloBindingSource;
    }
}