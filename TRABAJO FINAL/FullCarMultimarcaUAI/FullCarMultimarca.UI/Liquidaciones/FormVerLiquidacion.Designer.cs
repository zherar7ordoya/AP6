
namespace FullCarMultimarca.UI.Liquidaciones
{
    partial class FormVerLiquidacion
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.txtComentariosLiquidacion = new System.Windows.Forms.TextBox();
            this.txtCodigoLiquidacion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFechaLiquidacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.grillaLiquidacionVendedor = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.grillaOperacionesLiquidadas = new System.Windows.Forms.DataGridView();
            this.txtTtlComisiones = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTtlPremioVolumen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalLiquidacion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chartCompVendedores = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grillaLiquidacionVendedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaOperacionesLiquidadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCompVendedores)).BeginInit();
            this.SuspendLayout();
            // 
            // txtComentariosLiquidacion
            // 
            this.txtComentariosLiquidacion.AcceptsReturn = true;
            this.txtComentariosLiquidacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComentariosLiquidacion.Location = new System.Drawing.Point(272, 12);
            this.txtComentariosLiquidacion.MaxLength = 500;
            this.txtComentariosLiquidacion.Multiline = true;
            this.txtComentariosLiquidacion.Name = "txtComentariosLiquidacion";
            this.txtComentariosLiquidacion.ReadOnly = true;
            this.txtComentariosLiquidacion.Size = new System.Drawing.Size(528, 46);
            this.txtComentariosLiquidacion.TabIndex = 7;
            this.txtComentariosLiquidacion.TabStop = false;
            // 
            // txtCodigoLiquidacion
            // 
            this.txtCodigoLiquidacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoLiquidacion.Location = new System.Drawing.Point(107, 38);
            this.txtCodigoLiquidacion.MaxLength = 10;
            this.txtCodigoLiquidacion.Name = "txtCodigoLiquidacion";
            this.txtCodigoLiquidacion.ReadOnly = true;
            this.txtCodigoLiquidacion.Size = new System.Drawing.Size(157, 20);
            this.txtCodigoLiquidacion.TabIndex = 5;
            this.txtCodigoLiquidacion.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Código Liquidacion";
            // 
            // txtFechaLiquidacion
            // 
            this.txtFechaLiquidacion.Location = new System.Drawing.Point(107, 12);
            this.txtFechaLiquidacion.Name = "txtFechaLiquidacion";
            this.txtFechaLiquidacion.ReadOnly = true;
            this.txtFechaLiquidacion.Size = new System.Drawing.Size(157, 20);
            this.txtFechaLiquidacion.TabIndex = 8;
            this.txtFechaLiquidacion.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Fecha Liquidación";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Location = new System.Drawing.Point(715, 444);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(85, 23);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // grillaLiquidacionVendedor
            // 
            this.grillaLiquidacionVendedor.AllowUserToAddRows = false;
            this.grillaLiquidacionVendedor.AllowUserToDeleteRows = false;
            this.grillaLiquidacionVendedor.AllowUserToResizeColumns = false;
            this.grillaLiquidacionVendedor.AllowUserToResizeRows = false;
            this.grillaLiquidacionVendedor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grillaLiquidacionVendedor.BackgroundColor = System.Drawing.Color.LightYellow;
            this.grillaLiquidacionVendedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaLiquidacionVendedor.Location = new System.Drawing.Point(10, 94);
            this.grillaLiquidacionVendedor.MultiSelect = false;
            this.grillaLiquidacionVendedor.Name = "grillaLiquidacionVendedor";
            this.grillaLiquidacionVendedor.ReadOnly = true;
            this.grillaLiquidacionVendedor.RowHeadersVisible = false;
            this.grillaLiquidacionVendedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaLiquidacionVendedor.Size = new System.Drawing.Size(532, 151);
            this.grillaLiquidacionVendedor.TabIndex = 11;
            this.grillaLiquidacionVendedor.TabStop = false;
            this.grillaLiquidacionVendedor.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaLiquidacionVendedor_RowEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Por Vendedor";
            // 
            // grillaOperacionesLiquidadas
            // 
            this.grillaOperacionesLiquidadas.AllowUserToAddRows = false;
            this.grillaOperacionesLiquidadas.AllowUserToDeleteRows = false;
            this.grillaOperacionesLiquidadas.AllowUserToResizeColumns = false;
            this.grillaOperacionesLiquidadas.AllowUserToResizeRows = false;
            this.grillaOperacionesLiquidadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grillaOperacionesLiquidadas.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.grillaOperacionesLiquidadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaOperacionesLiquidadas.Location = new System.Drawing.Point(10, 251);
            this.grillaOperacionesLiquidadas.MultiSelect = false;
            this.grillaOperacionesLiquidadas.Name = "grillaOperacionesLiquidadas";
            this.grillaOperacionesLiquidadas.ReadOnly = true;
            this.grillaOperacionesLiquidadas.RowHeadersVisible = false;
            this.grillaOperacionesLiquidadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaOperacionesLiquidadas.Size = new System.Drawing.Size(656, 216);
            this.grillaOperacionesLiquidadas.TabIndex = 13;
            this.grillaOperacionesLiquidadas.TabStop = false;
            // 
            // txtTtlComisiones
            // 
            this.txtTtlComisiones.Location = new System.Drawing.Point(675, 294);
            this.txtTtlComisiones.Name = "txtTtlComisiones";
            this.txtTtlComisiones.ReadOnly = true;
            this.txtTtlComisiones.Size = new System.Drawing.Size(125, 20);
            this.txtTtlComisiones.TabIndex = 15;
            this.txtTtlComisiones.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(672, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Total en Comisiones";
            // 
            // txtTtlPremioVolumen
            // 
            this.txtTtlPremioVolumen.Location = new System.Drawing.Point(675, 333);
            this.txtTtlPremioVolumen.Name = "txtTtlPremioVolumen";
            this.txtTtlPremioVolumen.ReadOnly = true;
            this.txtTtlPremioVolumen.Size = new System.Drawing.Size(125, 20);
            this.txtTtlPremioVolumen.TabIndex = 17;
            this.txtTtlPremioVolumen.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(672, 317);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Total Pr.Volumen";
            // 
            // txtTotalLiquidacion
            // 
            this.txtTotalLiquidacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtTotalLiquidacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalLiquidacion.ForeColor = System.Drawing.Color.Blue;
            this.txtTotalLiquidacion.Location = new System.Drawing.Point(675, 391);
            this.txtTotalLiquidacion.Name = "txtTotalLiquidacion";
            this.txtTotalLiquidacion.ReadOnly = true;
            this.txtTotalLiquidacion.Size = new System.Drawing.Size(125, 23);
            this.txtTotalLiquidacion.TabIndex = 19;
            this.txtTotalLiquidacion.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(672, 375);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Total Liquidación";
            // 
            // chartCompVendedores
            // 
            chartArea2.Name = "ChartArea1";
            this.chartCompVendedores.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartCompVendedores.Legends.Add(legend2);
            this.chartCompVendedores.Location = new System.Drawing.Point(548, 94);
            this.chartCompVendedores.Name = "chartCompVendedores";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartCompVendedores.Series.Add(series2);
            this.chartCompVendedores.Size = new System.Drawing.Size(252, 151);
            this.chartCompVendedores.TabIndex = 20;
            this.chartCompVendedores.Text = "chart1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(545, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Distribución de la comisión";
            // 
            // FormVerLiquidacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 479);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chartCompVendedores);
            this.Controls.Add(this.txtTotalLiquidacion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTtlPremioVolumen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTtlComisiones);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grillaOperacionesLiquidadas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grillaLiquidacionVendedor);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.txtComentariosLiquidacion);
            this.Controls.Add(this.txtCodigoLiquidacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFechaLiquidacion);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(618, 518);
            this.Name = "FormVerLiquidacion";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualización de Liquidación";
            this.Load += new System.EventHandler(this.FormVerLiquidacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaLiquidacionVendedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaOperacionesLiquidadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCompVendedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtComentariosLiquidacion;
        private System.Windows.Forms.TextBox txtCodigoLiquidacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFechaLiquidacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCerrar;
        public System.Windows.Forms.DataGridView grillaLiquidacionVendedor;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DataGridView grillaOperacionesLiquidadas;
        private System.Windows.Forms.TextBox txtTtlComisiones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTtlPremioVolumen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotalLiquidacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCompVendedores;
        private System.Windows.Forms.Label label7;
    }
}