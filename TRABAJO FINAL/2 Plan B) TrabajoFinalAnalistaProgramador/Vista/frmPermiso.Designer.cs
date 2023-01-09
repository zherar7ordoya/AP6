namespace Vista
{
    partial class frmPermisos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPermisos));
            this.dgv_Permisos = new System.Windows.Forms.DataGridView();
            this.btn_AltaPermiso = new System.Windows.Forms.Button();
            this.btn_ModPermisoSimple = new System.Windows.Forms.Button();
            this.btn_BajaPermisoSimple = new System.Windows.Forms.Button();
            this.txt_IdPermiso = new System.Windows.Forms.TextBox();
            this.txt_NombrePermiso = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_GuardarPermiso = new System.Windows.Forms.Button();
            this.btn_CancelarPermiso = new System.Windows.Forms.Button();
            this.rb_Simple = new System.Windows.Forms.RadioButton();
            this.rb_Compuesto = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_BajaPermisoCompuesto = new System.Windows.Forms.Button();
            this.btn_ModPermisoCompuesto = new System.Windows.Forms.Button();
            this.txt_Busqueda = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_UsuarioLog = new System.Windows.Forms.Label();
            this.lbl_Aviso = new System.Windows.Forms.Label();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Permisos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Permisos
            // 
            this.dgv_Permisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Permisos.Location = new System.Drawing.Point(192, 95);
            this.dgv_Permisos.Name = "dgv_Permisos";
            this.dgv_Permisos.Size = new System.Drawing.Size(419, 452);
            this.dgv_Permisos.TabIndex = 0;
            this.dgv_Permisos.Tag = "52";
            // 
            // btn_AltaPermiso
            // 
            this.btn_AltaPermiso.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_AltaPermiso.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_AltaPermiso.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AltaPermiso.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AltaPermiso.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AltaPermiso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AltaPermiso.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AltaPermiso.ForeColor = System.Drawing.Color.White;
            this.btn_AltaPermiso.Location = new System.Drawing.Point(46, 157);
            this.btn_AltaPermiso.Name = "btn_AltaPermiso";
            this.btn_AltaPermiso.Size = new System.Drawing.Size(95, 38);
            this.btn_AltaPermiso.TabIndex = 1;
            this.btn_AltaPermiso.Tag = "45";
            this.btn_AltaPermiso.Text = "Alta";
            this.btn_AltaPermiso.UseVisualStyleBackColor = false;
            // 
            // btn_ModPermisoSimple
            // 
            this.btn_ModPermisoSimple.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_ModPermisoSimple.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_ModPermisoSimple.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ModPermisoSimple.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ModPermisoSimple.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ModPermisoSimple.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ModPermisoSimple.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ModPermisoSimple.ForeColor = System.Drawing.Color.White;
            this.btn_ModPermisoSimple.Location = new System.Drawing.Point(27, 218);
            this.btn_ModPermisoSimple.Name = "btn_ModPermisoSimple";
            this.btn_ModPermisoSimple.Size = new System.Drawing.Size(139, 53);
            this.btn_ModPermisoSimple.TabIndex = 2;
            this.btn_ModPermisoSimple.Tag = "47";
            this.btn_ModPermisoSimple.Text = "Modificar Permiso simple";
            this.btn_ModPermisoSimple.UseVisualStyleBackColor = false;
            // 
            // btn_BajaPermisoSimple
            // 
            this.btn_BajaPermisoSimple.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_BajaPermisoSimple.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_BajaPermisoSimple.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaPermisoSimple.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaPermisoSimple.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaPermisoSimple.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BajaPermisoSimple.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BajaPermisoSimple.ForeColor = System.Drawing.Color.White;
            this.btn_BajaPermisoSimple.Location = new System.Drawing.Point(27, 366);
            this.btn_BajaPermisoSimple.Name = "btn_BajaPermisoSimple";
            this.btn_BajaPermisoSimple.Size = new System.Drawing.Size(139, 53);
            this.btn_BajaPermisoSimple.TabIndex = 3;
            this.btn_BajaPermisoSimple.Tag = "46";
            this.btn_BajaPermisoSimple.Text = "Baja Permiso Simple";
            this.btn_BajaPermisoSimple.UseVisualStyleBackColor = false;
            // 
            // txt_IdPermiso
            // 
            this.txt_IdPermiso.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_IdPermiso.Location = new System.Drawing.Point(737, 147);
            this.txt_IdPermiso.Name = "txt_IdPermiso";
            this.txt_IdPermiso.Size = new System.Drawing.Size(100, 24);
            this.txt_IdPermiso.TabIndex = 6;
            // 
            // txt_NombrePermiso
            // 
            this.txt_NombrePermiso.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NombrePermiso.Location = new System.Drawing.Point(737, 191);
            this.txt_NombrePermiso.Name = "txt_NombrePermiso";
            this.txt_NombrePermiso.Size = new System.Drawing.Size(181, 24);
            this.txt_NombrePermiso.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(648, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Id Permiso:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(664, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nombre:";
            // 
            // btn_GuardarPermiso
            // 
            this.btn_GuardarPermiso.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_GuardarPermiso.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_GuardarPermiso.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GuardarPermiso.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GuardarPermiso.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GuardarPermiso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GuardarPermiso.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GuardarPermiso.ForeColor = System.Drawing.Color.White;
            this.btn_GuardarPermiso.Location = new System.Drawing.Point(694, 289);
            this.btn_GuardarPermiso.Name = "btn_GuardarPermiso";
            this.btn_GuardarPermiso.Size = new System.Drawing.Size(88, 40);
            this.btn_GuardarPermiso.TabIndex = 4;
            this.btn_GuardarPermiso.Tag = "50";
            this.btn_GuardarPermiso.Text = "Guardar";
            this.btn_GuardarPermiso.UseVisualStyleBackColor = false;
            // 
            // btn_CancelarPermiso
            // 
            this.btn_CancelarPermiso.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_CancelarPermiso.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_CancelarPermiso.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CancelarPermiso.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CancelarPermiso.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CancelarPermiso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CancelarPermiso.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CancelarPermiso.ForeColor = System.Drawing.Color.White;
            this.btn_CancelarPermiso.Location = new System.Drawing.Point(816, 289);
            this.btn_CancelarPermiso.Name = "btn_CancelarPermiso";
            this.btn_CancelarPermiso.Size = new System.Drawing.Size(88, 40);
            this.btn_CancelarPermiso.TabIndex = 5;
            this.btn_CancelarPermiso.Tag = "51";
            this.btn_CancelarPermiso.Text = "Cancelar";
            this.btn_CancelarPermiso.UseVisualStyleBackColor = false;
            // 
            // rb_Simple
            // 
            this.rb_Simple.AutoSize = true;
            this.rb_Simple.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Simple.ForeColor = System.Drawing.Color.White;
            this.rb_Simple.Location = new System.Drawing.Point(737, 234);
            this.rb_Simple.Name = "rb_Simple";
            this.rb_Simple.Size = new System.Drawing.Size(73, 21);
            this.rb_Simple.TabIndex = 10;
            this.rb_Simple.TabStop = true;
            this.rb_Simple.Text = "Simple";
            this.rb_Simple.UseVisualStyleBackColor = true;
            // 
            // rb_Compuesto
            // 
            this.rb_Compuesto.AutoSize = true;
            this.rb_Compuesto.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Compuesto.ForeColor = System.Drawing.Color.White;
            this.rb_Compuesto.Location = new System.Drawing.Point(816, 234);
            this.rb_Compuesto.Name = "rb_Compuesto";
            this.rb_Compuesto.Size = new System.Drawing.Size(105, 21);
            this.rb_Compuesto.TabIndex = 11;
            this.rb_Compuesto.TabStop = true;
            this.rb_Compuesto.Text = "Compuesto";
            this.rb_Compuesto.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(691, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tipo:";
            // 
            // btn_BajaPermisoCompuesto
            // 
            this.btn_BajaPermisoCompuesto.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_BajaPermisoCompuesto.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_BajaPermisoCompuesto.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaPermisoCompuesto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaPermisoCompuesto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaPermisoCompuesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BajaPermisoCompuesto.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BajaPermisoCompuesto.ForeColor = System.Drawing.Color.White;
            this.btn_BajaPermisoCompuesto.Location = new System.Drawing.Point(27, 438);
            this.btn_BajaPermisoCompuesto.Name = "btn_BajaPermisoCompuesto";
            this.btn_BajaPermisoCompuesto.Size = new System.Drawing.Size(139, 53);
            this.btn_BajaPermisoCompuesto.TabIndex = 16;
            this.btn_BajaPermisoCompuesto.Tag = "48";
            this.btn_BajaPermisoCompuesto.Text = "Baja Permiso Compuesto";
            this.btn_BajaPermisoCompuesto.UseVisualStyleBackColor = false;
            // 
            // btn_ModPermisoCompuesto
            // 
            this.btn_ModPermisoCompuesto.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_ModPermisoCompuesto.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_ModPermisoCompuesto.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ModPermisoCompuesto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ModPermisoCompuesto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ModPermisoCompuesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ModPermisoCompuesto.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ModPermisoCompuesto.ForeColor = System.Drawing.Color.White;
            this.btn_ModPermisoCompuesto.Location = new System.Drawing.Point(27, 290);
            this.btn_ModPermisoCompuesto.Name = "btn_ModPermisoCompuesto";
            this.btn_ModPermisoCompuesto.Size = new System.Drawing.Size(139, 57);
            this.btn_ModPermisoCompuesto.TabIndex = 17;
            this.btn_ModPermisoCompuesto.Tag = "49";
            this.btn_ModPermisoCompuesto.Text = "Modificar Permiso Compuesto";
            this.btn_ModPermisoCompuesto.UseVisualStyleBackColor = false;
            // 
            // txt_Busqueda
            // 
            this.txt_Busqueda.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Busqueda.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txt_Busqueda.Location = new System.Drawing.Point(192, 62);
            this.txt_Busqueda.Name = "txt_Busqueda";
            this.txt_Busqueda.Size = new System.Drawing.Size(419, 24);
            this.txt_Busqueda.TabIndex = 18;
            this.txt_Busqueda.Tag = "53";
            this.txt_Busqueda.Text = "Búsqueda por: Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(15, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 19);
            this.label4.TabIndex = 19;
            this.label4.Text = "Usuario Logeado:";
            // 
            // lbl_UsuarioLog
            // 
            this.lbl_UsuarioLog.AutoSize = true;
            this.lbl_UsuarioLog.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UsuarioLog.ForeColor = System.Drawing.Color.White;
            this.lbl_UsuarioLog.Location = new System.Drawing.Point(160, 13);
            this.lbl_UsuarioLog.Name = "lbl_UsuarioLog";
            this.lbl_UsuarioLog.Size = new System.Drawing.Size(57, 21);
            this.lbl_UsuarioLog.TabIndex = 20;
            this.lbl_UsuarioLog.Text = "label5";
            // 
            // lbl_Aviso
            // 
            this.lbl_Aviso.AutoSize = true;
            this.lbl_Aviso.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Aviso.ForeColor = System.Drawing.Color.Red;
            this.lbl_Aviso.Location = new System.Drawing.Point(763, 455);
            this.lbl_Aviso.Name = "lbl_Aviso";
            this.lbl_Aviso.Size = new System.Drawing.Size(58, 19);
            this.lbl_Aviso.TabIndex = 21;
            this.lbl_Aviso.Text = "label5";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(12, 35);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(599, 21);
            this.bunifuSeparator1.TabIndex = 22;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // frmPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(941, 559);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.lbl_Aviso);
            this.Controls.Add(this.lbl_UsuarioLog);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_Busqueda);
            this.Controls.Add(this.btn_ModPermisoCompuesto);
            this.Controls.Add(this.btn_BajaPermisoCompuesto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rb_Compuesto);
            this.Controls.Add(this.rb_Simple);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_NombrePermiso);
            this.Controls.Add(this.txt_IdPermiso);
            this.Controls.Add(this.btn_CancelarPermiso);
            this.Controls.Add(this.btn_GuardarPermiso);
            this.Controls.Add(this.btn_BajaPermisoSimple);
            this.Controls.Add(this.btn_ModPermisoSimple);
            this.Controls.Add(this.btn_AltaPermiso);
            this.Controls.Add(this.dgv_Permisos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPermisos";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Permisos";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Permisos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Permisos;
        private System.Windows.Forms.Button btn_AltaPermiso;
        private System.Windows.Forms.Button btn_ModPermisoSimple;
        private System.Windows.Forms.Button btn_BajaPermisoSimple;
        private System.Windows.Forms.TextBox txt_IdPermiso;
        private System.Windows.Forms.TextBox txt_NombrePermiso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_GuardarPermiso;
        private System.Windows.Forms.Button btn_CancelarPermiso;
        private System.Windows.Forms.RadioButton rb_Simple;
        private System.Windows.Forms.RadioButton rb_Compuesto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_BajaPermisoCompuesto;
        private System.Windows.Forms.Button btn_ModPermisoCompuesto;
        private System.Windows.Forms.TextBox txt_Busqueda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_UsuarioLog;
        private System.Windows.Forms.Label lbl_Aviso;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
    }
}