namespace Vista
{
    partial class frmReporteArticuloFaltante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteArticuloFaltante));
            this.dgv_ArticulosFaltantes = new System.Windows.Forms.DataGridView();
            this.btn_GenerarReporte = new System.Windows.Forms.Button();
            this.lbl_Cantidad = new System.Windows.Forms.Label();
            this.txt_Cantidad = new System.Windows.Forms.TextBox();
            this.lbl_Titulo = new System.Windows.Forms.Label();
            this.btn_Aceptar = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.lbl_Dni = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_UsuarioLog = new System.Windows.Forms.Label();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.cb_Empleado = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ArticulosFaltantes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_ArticulosFaltantes
            // 
            this.dgv_ArticulosFaltantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ArticulosFaltantes.Location = new System.Drawing.Point(13, 60);
            this.dgv_ArticulosFaltantes.Name = "dgv_ArticulosFaltantes";
            this.dgv_ArticulosFaltantes.Size = new System.Drawing.Size(1006, 306);
            this.dgv_ArticulosFaltantes.TabIndex = 0;
            this.dgv_ArticulosFaltantes.Tag = "91";
            // 
            // btn_GenerarReporte
            // 
            this.btn_GenerarReporte.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_GenerarReporte.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_GenerarReporte.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GenerarReporte.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GenerarReporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GenerarReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GenerarReporte.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GenerarReporte.ForeColor = System.Drawing.Color.White;
            this.btn_GenerarReporte.Location = new System.Drawing.Point(460, 381);
            this.btn_GenerarReporte.Name = "btn_GenerarReporte";
            this.btn_GenerarReporte.Size = new System.Drawing.Size(152, 31);
            this.btn_GenerarReporte.TabIndex = 1;
            this.btn_GenerarReporte.Tag = "90";
            this.btn_GenerarReporte.Text = "Generar Reporte";
            this.btn_GenerarReporte.UseVisualStyleBackColor = false;
            // 
            // lbl_Cantidad
            // 
            this.lbl_Cantidad.AutoSize = true;
            this.lbl_Cantidad.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Cantidad.ForeColor = System.Drawing.Color.White;
            this.lbl_Cantidad.Location = new System.Drawing.Point(259, 484);
            this.lbl_Cantidad.Name = "lbl_Cantidad";
            this.lbl_Cantidad.Size = new System.Drawing.Size(150, 17);
            this.lbl_Cantidad.TabIndex = 2;
            this.lbl_Cantidad.Text = "Cantidad a comprar:";
            // 
            // txt_Cantidad
            // 
            this.txt_Cantidad.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Cantidad.Location = new System.Drawing.Point(415, 481);
            this.txt_Cantidad.Name = "txt_Cantidad";
            this.txt_Cantidad.Size = new System.Drawing.Size(100, 24);
            this.txt_Cantidad.TabIndex = 3;
            // 
            // lbl_Titulo
            // 
            this.lbl_Titulo.AutoSize = true;
            this.lbl_Titulo.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Titulo.ForeColor = System.Drawing.Color.White;
            this.lbl_Titulo.Location = new System.Drawing.Point(496, 437);
            this.lbl_Titulo.Name = "lbl_Titulo";
            this.lbl_Titulo.Size = new System.Drawing.Size(90, 19);
            this.lbl_Titulo.TabIndex = 4;
            this.lbl_Titulo.Text = "Complete:";
            // 
            // btn_Aceptar
            // 
            this.btn_Aceptar.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_Aceptar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Aceptar.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_Aceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_Aceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Aceptar.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Aceptar.ForeColor = System.Drawing.Color.White;
            this.btn_Aceptar.Location = new System.Drawing.Point(430, 586);
            this.btn_Aceptar.Name = "btn_Aceptar";
            this.btn_Aceptar.Size = new System.Drawing.Size(85, 35);
            this.btn_Aceptar.TabIndex = 5;
            this.btn_Aceptar.Text = "Aceptar";
            this.btn_Aceptar.UseVisualStyleBackColor = false;
            this.btn_Aceptar.Click += new System.EventHandler(this.btn_Aceptar_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_Cancelar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Cancelar.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_Cancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_Cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancelar.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancelar.ForeColor = System.Drawing.Color.White;
            this.btn_Cancelar.Location = new System.Drawing.Point(557, 586);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(85, 35);
            this.btn_Cancelar.TabIndex = 6;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = false;
            // 
            // lbl_Dni
            // 
            this.lbl_Dni.AutoSize = true;
            this.lbl_Dni.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Dni.ForeColor = System.Drawing.Color.White;
            this.lbl_Dni.Location = new System.Drawing.Point(299, 529);
            this.lbl_Dni.Name = "lbl_Dni";
            this.lbl_Dni.Size = new System.Drawing.Size(110, 17);
            this.lbl_Dni.TabIndex = 10;
            this.lbl_Dni.Text = "Dni empleado:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Usuario Logeado:";
            // 
            // lbl_UsuarioLog
            // 
            this.lbl_UsuarioLog.AutoSize = true;
            this.lbl_UsuarioLog.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UsuarioLog.ForeColor = System.Drawing.Color.White;
            this.lbl_UsuarioLog.Location = new System.Drawing.Point(157, 15);
            this.lbl_UsuarioLog.Name = "lbl_UsuarioLog";
            this.lbl_UsuarioLog.Size = new System.Drawing.Size(57, 21);
            this.lbl_UsuarioLog.TabIndex = 13;
            this.lbl_UsuarioLog.Text = "label2";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(12, 37);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(1007, 17);
            this.bunifuSeparator1.TabIndex = 14;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // cb_Empleado
            // 
            this.cb_Empleado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Empleado.FormattingEnabled = true;
            this.cb_Empleado.Location = new System.Drawing.Point(415, 526);
            this.cb_Empleado.Name = "cb_Empleado";
            this.cb_Empleado.Size = new System.Drawing.Size(121, 25);
            this.cb_Empleado.TabIndex = 15;
            // 
            // frmReporteArticuloFaltante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1031, 645);
            this.Controls.Add(this.cb_Empleado);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.lbl_UsuarioLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_Dni);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Aceptar);
            this.Controls.Add(this.lbl_Titulo);
            this.Controls.Add(this.txt_Cantidad);
            this.Controls.Add(this.lbl_Cantidad);
            this.Controls.Add(this.btn_GenerarReporte);
            this.Controls.Add(this.dgv_ArticulosFaltantes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReporteArticuloFaltante";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de artículo faltante";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ArticulosFaltantes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_ArticulosFaltantes;
        private System.Windows.Forms.Button btn_GenerarReporte;
        private System.Windows.Forms.Label lbl_Cantidad;
        private System.Windows.Forms.TextBox txt_Cantidad;
        private System.Windows.Forms.Label lbl_Titulo;
        private System.Windows.Forms.Button btn_Aceptar;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Label lbl_Dni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_UsuarioLog;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.ComboBox cb_Empleado;
    }
}