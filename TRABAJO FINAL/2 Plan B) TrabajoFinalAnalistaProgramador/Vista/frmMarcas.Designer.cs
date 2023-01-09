namespace Vista
{
    partial class frmMarcas
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
            this.dgv_Marcas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_CodigoMarca = new System.Windows.Forms.TextBox();
            this.txt_NombreMarca = new System.Windows.Forms.TextBox();
            this.cb_Gerente = new System.Windows.Forms.ComboBox();
            this.btn_AltaMarca = new System.Windows.Forms.Button();
            this.btn_ModMarca = new System.Windows.Forms.Button();
            this.btn_BajaMarca = new System.Windows.Forms.Button();
            this.btn_GuardarMarca = new System.Windows.Forms.Button();
            this.btn_CancelarMarca = new System.Windows.Forms.Button();
            this.txt_Busqueda = new System.Windows.Forms.TextBox();
            this.lbl_UsuarioLog = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_ReporteMarca = new System.Windows.Forms.Button();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.lbl_Aviso = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Marcas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Marcas
            // 
            this.dgv_Marcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Marcas.Location = new System.Drawing.Point(29, 93);
            this.dgv_Marcas.Name = "dgv_Marcas";
            this.dgv_Marcas.Size = new System.Drawing.Size(281, 259);
            this.dgv_Marcas.TabIndex = 0;
            this.dgv_Marcas.Tag = "35";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(418, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codigo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(414, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(414, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Gerente:";
            // 
            // txt_CodigoMarca
            // 
            this.txt_CodigoMarca.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CodigoMarca.Location = new System.Drawing.Point(487, 120);
            this.txt_CodigoMarca.Name = "txt_CodigoMarca";
            this.txt_CodigoMarca.Size = new System.Drawing.Size(100, 24);
            this.txt_CodigoMarca.TabIndex = 4;
            // 
            // txt_NombreMarca
            // 
            this.txt_NombreMarca.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NombreMarca.Location = new System.Drawing.Point(487, 164);
            this.txt_NombreMarca.Name = "txt_NombreMarca";
            this.txt_NombreMarca.Size = new System.Drawing.Size(100, 24);
            this.txt_NombreMarca.TabIndex = 5;
            // 
            // cb_Gerente
            // 
            this.cb_Gerente.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Gerente.FormattingEnabled = true;
            this.cb_Gerente.Location = new System.Drawing.Point(487, 208);
            this.cb_Gerente.Name = "cb_Gerente";
            this.cb_Gerente.Size = new System.Drawing.Size(121, 25);
            this.cb_Gerente.TabIndex = 6;
            // 
            // btn_AltaMarca
            // 
            this.btn_AltaMarca.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_AltaMarca.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_AltaMarca.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AltaMarca.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AltaMarca.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AltaMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AltaMarca.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AltaMarca.ForeColor = System.Drawing.Color.White;
            this.btn_AltaMarca.Location = new System.Drawing.Point(12, 374);
            this.btn_AltaMarca.Name = "btn_AltaMarca";
            this.btn_AltaMarca.Size = new System.Drawing.Size(85, 34);
            this.btn_AltaMarca.TabIndex = 7;
            this.btn_AltaMarca.Tag = "30";
            this.btn_AltaMarca.Text = "Alta";
            this.btn_AltaMarca.UseVisualStyleBackColor = false;
            // 
            // btn_ModMarca
            // 
            this.btn_ModMarca.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_ModMarca.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_ModMarca.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ModMarca.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ModMarca.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ModMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ModMarca.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ModMarca.ForeColor = System.Drawing.Color.White;
            this.btn_ModMarca.Location = new System.Drawing.Point(126, 374);
            this.btn_ModMarca.Name = "btn_ModMarca";
            this.btn_ModMarca.Size = new System.Drawing.Size(85, 34);
            this.btn_ModMarca.TabIndex = 8;
            this.btn_ModMarca.Tag = "32";
            this.btn_ModMarca.Text = "Modificar";
            this.btn_ModMarca.UseVisualStyleBackColor = false;
            // 
            // btn_BajaMarca
            // 
            this.btn_BajaMarca.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_BajaMarca.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_BajaMarca.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaMarca.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaMarca.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BajaMarca.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BajaMarca.ForeColor = System.Drawing.Color.White;
            this.btn_BajaMarca.Location = new System.Drawing.Point(240, 374);
            this.btn_BajaMarca.Name = "btn_BajaMarca";
            this.btn_BajaMarca.Size = new System.Drawing.Size(85, 34);
            this.btn_BajaMarca.TabIndex = 9;
            this.btn_BajaMarca.Tag = "31";
            this.btn_BajaMarca.Text = "Baja";
            this.btn_BajaMarca.UseVisualStyleBackColor = false;
            // 
            // btn_GuardarMarca
            // 
            this.btn_GuardarMarca.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_GuardarMarca.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_GuardarMarca.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GuardarMarca.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GuardarMarca.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GuardarMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GuardarMarca.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GuardarMarca.ForeColor = System.Drawing.Color.White;
            this.btn_GuardarMarca.Location = new System.Drawing.Point(419, 269);
            this.btn_GuardarMarca.Name = "btn_GuardarMarca";
            this.btn_GuardarMarca.Size = new System.Drawing.Size(85, 34);
            this.btn_GuardarMarca.TabIndex = 10;
            this.btn_GuardarMarca.Tag = "33";
            this.btn_GuardarMarca.Text = "Guardar";
            this.btn_GuardarMarca.UseVisualStyleBackColor = false;
            // 
            // btn_CancelarMarca
            // 
            this.btn_CancelarMarca.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_CancelarMarca.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_CancelarMarca.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CancelarMarca.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CancelarMarca.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CancelarMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CancelarMarca.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CancelarMarca.ForeColor = System.Drawing.Color.White;
            this.btn_CancelarMarca.Location = new System.Drawing.Point(546, 269);
            this.btn_CancelarMarca.Name = "btn_CancelarMarca";
            this.btn_CancelarMarca.Size = new System.Drawing.Size(85, 34);
            this.btn_CancelarMarca.TabIndex = 11;
            this.btn_CancelarMarca.Tag = "34";
            this.btn_CancelarMarca.Text = "Cancelar";
            this.btn_CancelarMarca.UseVisualStyleBackColor = false;
            // 
            // txt_Busqueda
            // 
            this.txt_Busqueda.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Busqueda.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txt_Busqueda.Location = new System.Drawing.Point(27, 63);
            this.txt_Busqueda.Name = "txt_Busqueda";
            this.txt_Busqueda.Size = new System.Drawing.Size(282, 24);
            this.txt_Busqueda.TabIndex = 12;
            this.txt_Busqueda.Tag = "36";
            this.txt_Busqueda.Text = "Búsqueda por: Nombre";
            // 
            // lbl_UsuarioLog
            // 
            this.lbl_UsuarioLog.AutoSize = true;
            this.lbl_UsuarioLog.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UsuarioLog.ForeColor = System.Drawing.Color.White;
            this.lbl_UsuarioLog.Location = new System.Drawing.Point(169, 18);
            this.lbl_UsuarioLog.Name = "lbl_UsuarioLog";
            this.lbl_UsuarioLog.Size = new System.Drawing.Size(57, 21);
            this.lbl_UsuarioLog.TabIndex = 14;
            this.lbl_UsuarioLog.Text = "label4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(20, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 19);
            this.label4.TabIndex = 15;
            this.label4.Text = "Usuario Logeado:";
            // 
            // btn_ReporteMarca
            // 
            this.btn_ReporteMarca.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_ReporteMarca.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_ReporteMarca.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ReporteMarca.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ReporteMarca.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ReporteMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ReporteMarca.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ReporteMarca.ForeColor = System.Drawing.Color.White;
            this.btn_ReporteMarca.Location = new System.Drawing.Point(600, 374);
            this.btn_ReporteMarca.Name = "btn_ReporteMarca";
            this.btn_ReporteMarca.Size = new System.Drawing.Size(85, 34);
            this.btn_ReporteMarca.TabIndex = 16;
            this.btn_ReporteMarca.Tag = "100";
            this.btn_ReporteMarca.Text = "Reporte";
            this.btn_ReporteMarca.UseVisualStyleBackColor = false;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(30, 40);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(281, 10);
            this.bunifuSeparator1.TabIndex = 17;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // lbl_Aviso
            // 
            this.lbl_Aviso.AutoSize = true;
            this.lbl_Aviso.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Aviso.ForeColor = System.Drawing.Color.Red;
            this.lbl_Aviso.Location = new System.Drawing.Point(376, 330);
            this.lbl_Aviso.Name = "lbl_Aviso";
            this.lbl_Aviso.Size = new System.Drawing.Size(58, 19);
            this.lbl_Aviso.TabIndex = 18;
            this.lbl_Aviso.Text = "label5";
            // 
            // frmMarcas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(697, 431);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_Aviso);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.btn_ReporteMarca);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_UsuarioLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_Gerente);
            this.Controls.Add(this.btn_CancelarMarca);
            this.Controls.Add(this.txt_Busqueda);
            this.Controls.Add(this.btn_BajaMarca);
            this.Controls.Add(this.txt_NombreMarca);
            this.Controls.Add(this.btn_ModMarca);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_AltaMarca);
            this.Controls.Add(this.txt_CodigoMarca);
            this.Controls.Add(this.dgv_Marcas);
            this.Controls.Add(this.btn_GuardarMarca);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "frmMarcas";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Marcas";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Marcas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Marcas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_CodigoMarca;
        private System.Windows.Forms.TextBox txt_NombreMarca;
        private System.Windows.Forms.ComboBox cb_Gerente;
        private System.Windows.Forms.Button btn_AltaMarca;
        private System.Windows.Forms.Button btn_ModMarca;
        private System.Windows.Forms.Button btn_BajaMarca;
        private System.Windows.Forms.Button btn_GuardarMarca;
        private System.Windows.Forms.Button btn_CancelarMarca;
        private System.Windows.Forms.TextBox txt_Busqueda;
        private System.Windows.Forms.Label lbl_UsuarioLog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_ReporteMarca;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.Label lbl_Aviso;
    }
}