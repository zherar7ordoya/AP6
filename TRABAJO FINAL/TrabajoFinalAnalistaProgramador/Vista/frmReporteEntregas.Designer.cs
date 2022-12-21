namespace Vista
{
    partial class frmReporteEntregas
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.accesoDBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_Entrega = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btn_Volver = new System.Windows.Forms.Button();
            this.E_EntregaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.accesoDBBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.E_EntregaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // accesoDBBindingSource
            // 
            this.accesoDBBindingSource.DataSource = typeof(DAO.AccesoDB);
            // 
            // report_Entrega
            // 
            reportDataSource3.Name = "DataSet7";
            reportDataSource3.Value = this.accesoDBBindingSource;
            this.report_Entrega.LocalReport.DataSources.Add(reportDataSource3);
            this.report_Entrega.LocalReport.ReportEmbeddedResource = "Vista.report_Entrega.rdlc";
            this.report_Entrega.Location = new System.Drawing.Point(-1, 66);
            this.report_Entrega.Name = "report_Entrega";
            this.report_Entrega.ServerReport.BearerToken = null;
            this.report_Entrega.Size = new System.Drawing.Size(617, 675);
            this.report_Entrega.TabIndex = 0;
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
            this.btn_Volver.Location = new System.Drawing.Point(519, 16);
            this.btn_Volver.Name = "btn_Volver";
            this.btn_Volver.Size = new System.Drawing.Size(79, 34);
            this.btn_Volver.TabIndex = 1;
            this.btn_Volver.Text = "Volver";
            this.btn_Volver.UseVisualStyleBackColor = false;
            // 
            // E_EntregaBindingSource
            // 
            this.E_EntregaBindingSource.DataSource = typeof(Entidad.E_Entrega);
            // 
            // frmReporteEntregas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(614, 661);
            this.Controls.Add(this.btn_Volver);
            this.Controls.Add(this.report_Entrega);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReporteEntregas";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReporteEntregas";
            ((System.ComponentModel.ISupportInitialize)(this.accesoDBBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.E_EntregaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer report_Entrega;
        private System.Windows.Forms.Button btn_Volver;
        private System.Windows.Forms.BindingSource E_EntregaBindingSource;
        private System.Windows.Forms.BindingSource accesoDBBindingSource;
    }
}