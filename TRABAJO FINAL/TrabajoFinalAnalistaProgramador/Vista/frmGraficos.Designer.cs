namespace Vista
{
    partial class frmGraficos
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGraficos));
            this.chart_ArticulosPVenta = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.rb_ArticulosCaro = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rb_ArticuloExistencias = new System.Windows.Forms.RadioButton();
            this.lbl_TipoGrafico = new System.Windows.Forms.Label();
            this.rb_Barras = new System.Windows.Forms.RadioButton();
            this.rb_Torta = new System.Windows.Forms.RadioButton();
            this.rb_ArticuloBarato = new System.Windows.Forms.RadioButton();
            this.rb_ArticuloMenosExist = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_UsuarioLog = new System.Windows.Forms.Label();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.chart_ArticulosPVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_ArticulosPVenta
            // 
            this.chart_ArticulosPVenta.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.chart_ArticulosPVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chart_ArticulosPVenta.BackSecondaryColor = System.Drawing.SystemColors.ControlDarkDark;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            chartArea1.BorderColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chart_ArticulosPVenta.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_ArticulosPVenta.Legends.Add(legend1);
            this.chart_ArticulosPVenta.Location = new System.Drawing.Point(379, 172);
            this.chart_ArticulosPVenta.Name = "chart_ArticulosPVenta";
            this.chart_ArticulosPVenta.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.IsXValueIndexed = true;
            series1.LabelBackColor = System.Drawing.Color.Transparent;
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_ArticulosPVenta.Series.Add(series1);
            this.chart_ArticulosPVenta.Size = new System.Drawing.Size(544, 440);
            this.chart_ArticulosPVenta.TabIndex = 0;
            this.chart_ArticulosPVenta.Text = "Articulos";
            title1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.ForeColor = System.Drawing.Color.White;
            title1.Name = "Title1";
            title1.Text = "Indumentaria Deportiva M&M";
            this.chart_ArticulosPVenta.Titles.Add(title1);
            // 
            // rb_ArticulosCaro
            // 
            this.rb_ArticulosCaro.AutoSize = true;
            this.rb_ArticulosCaro.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_ArticulosCaro.ForeColor = System.Drawing.Color.White;
            this.rb_ArticulosCaro.Location = new System.Drawing.Point(163, 49);
            this.rb_ArticulosCaro.Name = "rb_ArticulosCaro";
            this.rb_ArticulosCaro.Size = new System.Drawing.Size(206, 23);
            this.rb_ArticulosCaro.TabIndex = 1;
            this.rb_ArticulosCaro.TabStop = true;
            this.rb_ArticulosCaro.Tag = "93";
            this.rb_ArticulosCaro.Text = "TOP 3 - Artículos más caros";
            this.rb_ArticulosCaro.UseVisualStyleBackColor = true;
            this.rb_ArticulosCaro.CheckedChanged += new System.EventHandler(this.rb_ArticulosCaro_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Gráfico a visibilizar:";
            // 
            // rb_ArticuloExistencias
            // 
            this.rb_ArticuloExistencias.AutoSize = true;
            this.rb_ArticuloExistencias.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_ArticuloExistencias.ForeColor = System.Drawing.Color.White;
            this.rb_ArticuloExistencias.Location = new System.Drawing.Point(607, 49);
            this.rb_ArticuloExistencias.Name = "rb_ArticuloExistencias";
            this.rb_ArticuloExistencias.Size = new System.Drawing.Size(274, 23);
            this.rb_ArticuloExistencias.TabIndex = 3;
            this.rb_ArticuloExistencias.TabStop = true;
            this.rb_ArticuloExistencias.Tag = "95";
            this.rb_ArticuloExistencias.Text = "TOP 3 - Artículos con mas existencias";
            this.rb_ArticuloExistencias.UseVisualStyleBackColor = true;
            this.rb_ArticuloExistencias.CheckedChanged += new System.EventHandler(this.rb_ArticuloExistencias_CheckedChanged);
            // 
            // lbl_TipoGrafico
            // 
            this.lbl_TipoGrafico.AutoSize = true;
            this.lbl_TipoGrafico.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TipoGrafico.ForeColor = System.Drawing.Color.White;
            this.lbl_TipoGrafico.Location = new System.Drawing.Point(162, 92);
            this.lbl_TipoGrafico.Name = "lbl_TipoGrafico";
            this.lbl_TipoGrafico.Size = new System.Drawing.Size(115, 19);
            this.lbl_TipoGrafico.TabIndex = 5;
            this.lbl_TipoGrafico.Text = "Tipo de gráfico:";
            // 
            // rb_Barras
            // 
            this.rb_Barras.AutoSize = true;
            this.rb_Barras.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Barras.ForeColor = System.Drawing.Color.White;
            this.rb_Barras.Location = new System.Drawing.Point(165, 118);
            this.rb_Barras.Name = "rb_Barras";
            this.rb_Barras.Size = new System.Drawing.Size(68, 23);
            this.rb_Barras.TabIndex = 6;
            this.rb_Barras.TabStop = true;
            this.rb_Barras.Text = "Barras";
            this.rb_Barras.UseVisualStyleBackColor = true;
            this.rb_Barras.CheckedChanged += new System.EventHandler(this.rb_Barras_CheckedChanged);
            // 
            // rb_Torta
            // 
            this.rb_Torta.AutoSize = true;
            this.rb_Torta.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Torta.ForeColor = System.Drawing.Color.White;
            this.rb_Torta.Location = new System.Drawing.Point(165, 151);
            this.rb_Torta.Name = "rb_Torta";
            this.rb_Torta.Size = new System.Drawing.Size(60, 23);
            this.rb_Torta.TabIndex = 7;
            this.rb_Torta.TabStop = true;
            this.rb_Torta.Text = "Torta";
            this.rb_Torta.UseVisualStyleBackColor = true;
            this.rb_Torta.CheckedChanged += new System.EventHandler(this.rb_Torta_CheckedChanged);
            // 
            // rb_ArticuloBarato
            // 
            this.rb_ArticuloBarato.AutoSize = true;
            this.rb_ArticuloBarato.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_ArticuloBarato.ForeColor = System.Drawing.Color.White;
            this.rb_ArticuloBarato.Location = new System.Drawing.Point(379, 49);
            this.rb_ArticuloBarato.Name = "rb_ArticuloBarato";
            this.rb_ArticuloBarato.Size = new System.Drawing.Size(222, 23);
            this.rb_ArticuloBarato.TabIndex = 8;
            this.rb_ArticuloBarato.TabStop = true;
            this.rb_ArticuloBarato.Tag = "94";
            this.rb_ArticuloBarato.Text = "TOP 3 - Artículos más baratos";
            this.rb_ArticuloBarato.UseVisualStyleBackColor = true;
            this.rb_ArticuloBarato.CheckedChanged += new System.EventHandler(this.rb_ArticuloBarato_CheckedChanged);
            // 
            // rb_ArticuloMenosExist
            // 
            this.rb_ArticuloMenosExist.AutoSize = true;
            this.rb_ArticuloMenosExist.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_ArticuloMenosExist.ForeColor = System.Drawing.Color.White;
            this.rb_ArticuloMenosExist.Location = new System.Drawing.Point(887, 49);
            this.rb_ArticuloMenosExist.Name = "rb_ArticuloMenosExist";
            this.rb_ArticuloMenosExist.Size = new System.Drawing.Size(291, 23);
            this.rb_ArticuloMenosExist.TabIndex = 9;
            this.rb_ArticuloMenosExist.TabStop = true;
            this.rb_ArticuloMenosExist.Tag = "96";
            this.rb_ArticuloMenosExist.Text = "TOP 3 - Artículos con menos existencias";
            this.rb_ArticuloMenosExist.UseVisualStyleBackColor = true;
            this.rb_ArticuloMenosExist.CheckedChanged += new System.EventHandler(this.rb_ArticuloMenosExist_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Usuario Logeado:";
            // 
            // lbl_UsuarioLog
            // 
            this.lbl_UsuarioLog.AutoSize = true;
            this.lbl_UsuarioLog.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UsuarioLog.ForeColor = System.Drawing.Color.White;
            this.lbl_UsuarioLog.Location = new System.Drawing.Point(159, 13);
            this.lbl_UsuarioLog.Name = "lbl_UsuarioLog";
            this.lbl_UsuarioLog.Size = new System.Drawing.Size(57, 21);
            this.lbl_UsuarioLog.TabIndex = 12;
            this.lbl_UsuarioLog.Text = "label3";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(12, 34);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(1024, 10);
            this.bunifuSeparator1.TabIndex = 13;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // frmGraficos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1204, 643);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.lbl_UsuarioLog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rb_ArticuloMenosExist);
            this.Controls.Add(this.rb_ArticuloBarato);
            this.Controls.Add(this.rb_Torta);
            this.Controls.Add(this.rb_Barras);
            this.Controls.Add(this.lbl_TipoGrafico);
            this.Controls.Add(this.rb_ArticuloExistencias);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rb_ArticulosCaro);
            this.Controls.Add(this.chart_ArticulosPVenta);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGraficos";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gráficos";
            this.Load += new System.EventHandler(this.frmGraficos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_ArticulosPVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_ArticulosPVenta;
        private System.Windows.Forms.RadioButton rb_ArticulosCaro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rb_ArticuloExistencias;
        private System.Windows.Forms.Label lbl_TipoGrafico;
        private System.Windows.Forms.RadioButton rb_Barras;
        private System.Windows.Forms.RadioButton rb_Torta;
        private System.Windows.Forms.RadioButton rb_ArticuloBarato;
        private System.Windows.Forms.RadioButton rb_ArticuloMenosExist;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_UsuarioLog;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
    }
}