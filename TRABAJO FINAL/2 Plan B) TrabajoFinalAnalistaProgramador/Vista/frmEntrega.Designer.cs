namespace Vista
{
    partial class frmEntrega
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntrega));
            this.dgv_Entregas = new System.Windows.Forms.DataGridView();
            this.txt_Busqueda = new System.Windows.Forms.TextBox();
            this.btn_AltaEntrega = new System.Windows.Forms.Button();
            this.btn_ModEntrega = new System.Windows.Forms.Button();
            this.btn_BajaEntrega = new System.Windows.Forms.Button();
            this.txt_IdEntrega = new System.Windows.Forms.TextBox();
            this.dt_FechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.cb_Proveedor = new System.Windows.Forms.ComboBox();
            this.cb_Gerente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_GuardarEntrega = new System.Windows.Forms.Button();
            this.btn_CancelarEntrega = new System.Windows.Forms.Button();
            this.txt_HoraEntrega = new System.Windows.Forms.TextBox();
            this.btn_ReporteEntrega = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_UsuarioLog = new System.Windows.Forms.Label();
            this.lbl_Aviso = new System.Windows.Forms.Label();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Entregas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Entregas
            // 
            this.dgv_Entregas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Entregas.Location = new System.Drawing.Point(59, 81);
            this.dgv_Entregas.Name = "dgv_Entregas";
            this.dgv_Entregas.Size = new System.Drawing.Size(390, 322);
            this.dgv_Entregas.TabIndex = 0;
            this.dgv_Entregas.Tag = "88";
            // 
            // txt_Busqueda
            // 
            this.txt_Busqueda.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Busqueda.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txt_Busqueda.Location = new System.Drawing.Point(59, 49);
            this.txt_Busqueda.Name = "txt_Busqueda";
            this.txt_Busqueda.Size = new System.Drawing.Size(390, 24);
            this.txt_Busqueda.TabIndex = 1;
            this.txt_Busqueda.Tag = "89";
            this.txt_Busqueda.Text = "Búsqueda por: Fecha";
            // 
            // btn_AltaEntrega
            // 
            this.btn_AltaEntrega.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_AltaEntrega.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_AltaEntrega.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AltaEntrega.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AltaEntrega.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AltaEntrega.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AltaEntrega.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AltaEntrega.ForeColor = System.Drawing.Color.White;
            this.btn_AltaEntrega.Location = new System.Drawing.Point(17, 418);
            this.btn_AltaEntrega.Name = "btn_AltaEntrega";
            this.btn_AltaEntrega.Size = new System.Drawing.Size(91, 42);
            this.btn_AltaEntrega.TabIndex = 2;
            this.btn_AltaEntrega.Tag = "83";
            this.btn_AltaEntrega.Text = "Alta";
            this.btn_AltaEntrega.UseVisualStyleBackColor = false;
            // 
            // btn_ModEntrega
            // 
            this.btn_ModEntrega.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_ModEntrega.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_ModEntrega.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ModEntrega.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ModEntrega.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ModEntrega.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ModEntrega.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ModEntrega.ForeColor = System.Drawing.Color.White;
            this.btn_ModEntrega.Location = new System.Drawing.Point(145, 418);
            this.btn_ModEntrega.Name = "btn_ModEntrega";
            this.btn_ModEntrega.Size = new System.Drawing.Size(91, 42);
            this.btn_ModEntrega.TabIndex = 3;
            this.btn_ModEntrega.Tag = "85";
            this.btn_ModEntrega.Text = "Modificar";
            this.btn_ModEntrega.UseVisualStyleBackColor = false;
            // 
            // btn_BajaEntrega
            // 
            this.btn_BajaEntrega.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_BajaEntrega.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_BajaEntrega.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaEntrega.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaEntrega.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaEntrega.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BajaEntrega.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BajaEntrega.ForeColor = System.Drawing.Color.White;
            this.btn_BajaEntrega.Location = new System.Drawing.Point(273, 418);
            this.btn_BajaEntrega.Name = "btn_BajaEntrega";
            this.btn_BajaEntrega.Size = new System.Drawing.Size(91, 42);
            this.btn_BajaEntrega.TabIndex = 4;
            this.btn_BajaEntrega.Tag = "84";
            this.btn_BajaEntrega.Text = "Baja";
            this.btn_BajaEntrega.UseVisualStyleBackColor = false;
            // 
            // txt_IdEntrega
            // 
            this.txt_IdEntrega.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_IdEntrega.Location = new System.Drawing.Point(623, 80);
            this.txt_IdEntrega.Name = "txt_IdEntrega";
            this.txt_IdEntrega.Size = new System.Drawing.Size(100, 24);
            this.txt_IdEntrega.TabIndex = 5;
            // 
            // dt_FechaEntrega
            // 
            this.dt_FechaEntrega.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_FechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_FechaEntrega.Location = new System.Drawing.Point(623, 132);
            this.dt_FechaEntrega.Name = "dt_FechaEntrega";
            this.dt_FechaEntrega.Size = new System.Drawing.Size(100, 24);
            this.dt_FechaEntrega.TabIndex = 7;
            // 
            // cb_Proveedor
            // 
            this.cb_Proveedor.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Proveedor.FormattingEnabled = true;
            this.cb_Proveedor.Location = new System.Drawing.Point(623, 224);
            this.cb_Proveedor.Name = "cb_Proveedor";
            this.cb_Proveedor.Size = new System.Drawing.Size(121, 25);
            this.cb_Proveedor.TabIndex = 8;
            // 
            // cb_Gerente
            // 
            this.cb_Gerente.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Gerente.FormattingEnabled = true;
            this.cb_Gerente.Location = new System.Drawing.Point(623, 273);
            this.cb_Gerente.Name = "cb_Gerente";
            this.cb_Gerente.Size = new System.Drawing.Size(121, 25);
            this.cb_Gerente.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(592, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Id:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(563, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Fecha:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(573, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Hora:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(537, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Proveedor:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(550, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Gerente:";
            // 
            // btn_GuardarEntrega
            // 
            this.btn_GuardarEntrega.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_GuardarEntrega.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_GuardarEntrega.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GuardarEntrega.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GuardarEntrega.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GuardarEntrega.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GuardarEntrega.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GuardarEntrega.ForeColor = System.Drawing.Color.White;
            this.btn_GuardarEntrega.Location = new System.Drawing.Point(548, 334);
            this.btn_GuardarEntrega.Name = "btn_GuardarEntrega";
            this.btn_GuardarEntrega.Size = new System.Drawing.Size(91, 42);
            this.btn_GuardarEntrega.TabIndex = 15;
            this.btn_GuardarEntrega.Tag = "86";
            this.btn_GuardarEntrega.Text = "Guardar";
            this.btn_GuardarEntrega.UseVisualStyleBackColor = false;
            // 
            // btn_CancelarEntrega
            // 
            this.btn_CancelarEntrega.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_CancelarEntrega.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_CancelarEntrega.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CancelarEntrega.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CancelarEntrega.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CancelarEntrega.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CancelarEntrega.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CancelarEntrega.ForeColor = System.Drawing.Color.White;
            this.btn_CancelarEntrega.Location = new System.Drawing.Point(673, 334);
            this.btn_CancelarEntrega.Name = "btn_CancelarEntrega";
            this.btn_CancelarEntrega.Size = new System.Drawing.Size(91, 42);
            this.btn_CancelarEntrega.TabIndex = 16;
            this.btn_CancelarEntrega.Tag = "87";
            this.btn_CancelarEntrega.Text = "Cancelar";
            this.btn_CancelarEntrega.UseVisualStyleBackColor = false;
            // 
            // txt_HoraEntrega
            // 
            this.txt_HoraEntrega.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_HoraEntrega.Location = new System.Drawing.Point(623, 176);
            this.txt_HoraEntrega.Name = "txt_HoraEntrega";
            this.txt_HoraEntrega.Size = new System.Drawing.Size(100, 24);
            this.txt_HoraEntrega.TabIndex = 17;
            // 
            // btn_ReporteEntrega
            // 
            this.btn_ReporteEntrega.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_ReporteEntrega.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_ReporteEntrega.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ReporteEntrega.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ReporteEntrega.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ReporteEntrega.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ReporteEntrega.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ReporteEntrega.ForeColor = System.Drawing.Color.White;
            this.btn_ReporteEntrega.Location = new System.Drawing.Point(401, 418);
            this.btn_ReporteEntrega.Name = "btn_ReporteEntrega";
            this.btn_ReporteEntrega.Size = new System.Drawing.Size(91, 42);
            this.btn_ReporteEntrega.TabIndex = 18;
            this.btn_ReporteEntrega.Tag = "99";
            this.btn_ReporteEntrega.Text = "Reporte";
            this.btn_ReporteEntrega.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(13, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 19);
            this.label6.TabIndex = 19;
            this.label6.Text = "Usuario Logeado:";
            // 
            // lbl_UsuarioLog
            // 
            this.lbl_UsuarioLog.AutoSize = true;
            this.lbl_UsuarioLog.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UsuarioLog.ForeColor = System.Drawing.Color.White;
            this.lbl_UsuarioLog.Location = new System.Drawing.Point(162, 12);
            this.lbl_UsuarioLog.Name = "lbl_UsuarioLog";
            this.lbl_UsuarioLog.Size = new System.Drawing.Size(57, 21);
            this.lbl_UsuarioLog.TabIndex = 20;
            this.lbl_UsuarioLog.Text = "label7";
            // 
            // lbl_Aviso
            // 
            this.lbl_Aviso.AutoSize = true;
            this.lbl_Aviso.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Aviso.ForeColor = System.Drawing.Color.Red;
            this.lbl_Aviso.Location = new System.Drawing.Point(572, 459);
            this.lbl_Aviso.Name = "lbl_Aviso";
            this.lbl_Aviso.Size = new System.Drawing.Size(67, 19);
            this.lbl_Aviso.TabIndex = 181;
            this.lbl_Aviso.Text = "label11";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(12, 32);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(437, 11);
            this.bunifuSeparator1.TabIndex = 182;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // frmEntrega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(793, 498);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.lbl_Aviso);
            this.Controls.Add(this.lbl_UsuarioLog);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_ReporteEntrega);
            this.Controls.Add(this.txt_HoraEntrega);
            this.Controls.Add(this.btn_CancelarEntrega);
            this.Controls.Add(this.btn_GuardarEntrega);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_Gerente);
            this.Controls.Add(this.cb_Proveedor);
            this.Controls.Add(this.dt_FechaEntrega);
            this.Controls.Add(this.txt_IdEntrega);
            this.Controls.Add(this.btn_BajaEntrega);
            this.Controls.Add(this.btn_ModEntrega);
            this.Controls.Add(this.btn_AltaEntrega);
            this.Controls.Add(this.txt_Busqueda);
            this.Controls.Add(this.dgv_Entregas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEntrega";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entregas";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Entregas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Entregas;
        private System.Windows.Forms.TextBox txt_Busqueda;
        private System.Windows.Forms.Button btn_AltaEntrega;
        private System.Windows.Forms.Button btn_ModEntrega;
        private System.Windows.Forms.Button btn_BajaEntrega;
        private System.Windows.Forms.TextBox txt_IdEntrega;
        private System.Windows.Forms.DateTimePicker dt_FechaEntrega;
        private System.Windows.Forms.ComboBox cb_Proveedor;
        private System.Windows.Forms.ComboBox cb_Gerente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_GuardarEntrega;
        private System.Windows.Forms.Button btn_CancelarEntrega;
        private System.Windows.Forms.TextBox txt_HoraEntrega;
        private System.Windows.Forms.Button btn_ReporteEntrega;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_UsuarioLog;
        private System.Windows.Forms.Label lbl_Aviso;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
    }
}