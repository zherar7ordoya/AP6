namespace Vista
{
    partial class frmUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuario));
            this.dgv_Usuarios = new System.Windows.Forms.DataGridView();
            this.btn_ModUsuario = new System.Windows.Forms.Button();
            this.btn_BajaUsuario = new System.Windows.Forms.Button();
            this.btn_AltaUsuario = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_NombreUsuario = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.txt_ContraseñaUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Busqueda = new System.Windows.Forms.TextBox();
            this.btn_DesbloquearCuenta = new System.Windows.Forms.Button();
            this.cb_Permiso = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_IdUsuario = new System.Windows.Forms.TextBox();
            this.btn_CancelarUsuario = new System.Windows.Forms.Button();
            this.btn_GuardarUsuario = new System.Windows.Forms.Button();
            this.lbl_UsuarioLog = new System.Windows.Forms.Label();
            this.lbl_Aviso = new System.Windows.Forms.Label();
            this.dt_FechaAlta = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Usuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Usuarios
            // 
            this.dgv_Usuarios.AllowUserToOrderColumns = true;
            this.dgv_Usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Usuarios.Location = new System.Drawing.Point(31, 85);
            this.dgv_Usuarios.Name = "dgv_Usuarios";
            this.dgv_Usuarios.RowHeadersVisible = false;
            this.dgv_Usuarios.RowHeadersWidth = 49;
            this.dgv_Usuarios.Size = new System.Drawing.Size(594, 264);
            this.dgv_Usuarios.TabIndex = 108;
            this.dgv_Usuarios.Tag = "7";
            // 
            // btn_ModUsuario
            // 
            this.btn_ModUsuario.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_ModUsuario.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_ModUsuario.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ModUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ModUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ModUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ModUsuario.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ModUsuario.ForeColor = System.Drawing.Color.White;
            this.btn_ModUsuario.Location = new System.Drawing.Point(201, 370);
            this.btn_ModUsuario.Name = "btn_ModUsuario";
            this.btn_ModUsuario.Size = new System.Drawing.Size(97, 40);
            this.btn_ModUsuario.TabIndex = 107;
            this.btn_ModUsuario.Tag = "3";
            this.btn_ModUsuario.Text = "Modificar";
            this.btn_ModUsuario.UseVisualStyleBackColor = false;
            // 
            // btn_BajaUsuario
            // 
            this.btn_BajaUsuario.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_BajaUsuario.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_BajaUsuario.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BajaUsuario.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BajaUsuario.ForeColor = System.Drawing.Color.White;
            this.btn_BajaUsuario.Location = new System.Drawing.Point(340, 370);
            this.btn_BajaUsuario.Name = "btn_BajaUsuario";
            this.btn_BajaUsuario.Size = new System.Drawing.Size(97, 40);
            this.btn_BajaUsuario.TabIndex = 106;
            this.btn_BajaUsuario.Tag = "2";
            this.btn_BajaUsuario.Text = "Baja";
            this.btn_BajaUsuario.UseVisualStyleBackColor = false;
            // 
            // btn_AltaUsuario
            // 
            this.btn_AltaUsuario.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_AltaUsuario.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_AltaUsuario.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AltaUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AltaUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AltaUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AltaUsuario.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AltaUsuario.ForeColor = System.Drawing.Color.White;
            this.btn_AltaUsuario.Location = new System.Drawing.Point(62, 370);
            this.btn_AltaUsuario.Name = "btn_AltaUsuario";
            this.btn_AltaUsuario.Size = new System.Drawing.Size(97, 40);
            this.btn_AltaUsuario.TabIndex = 105;
            this.btn_AltaUsuario.Tag = "1";
            this.btn_AltaUsuario.Text = "Alta";
            this.btn_AltaUsuario.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(707, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 17);
            this.label8.TabIndex = 128;
            this.label8.Text = "Fecha alta:";
            // 
            // txt_NombreUsuario
            // 
            this.txt_NombreUsuario.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NombreUsuario.Location = new System.Drawing.Point(797, 154);
            this.txt_NombreUsuario.Name = "txt_NombreUsuario";
            this.txt_NombreUsuario.Size = new System.Drawing.Size(143, 24);
            this.txt_NombreUsuario.TabIndex = 124;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(713, 65);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(78, 17);
            this.Label1.TabIndex = 125;
            this.Label1.Text = "Id Usuario:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.Location = new System.Drawing.Point(724, 157);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(67, 17);
            this.Label2.TabIndex = 126;
            this.Label2.Text = "Nombre:";
            // 
            // txt_ContraseñaUsuario
            // 
            this.txt_ContraseñaUsuario.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ContraseñaUsuario.Location = new System.Drawing.Point(797, 200);
            this.txt_ContraseñaUsuario.Name = "txt_ContraseñaUsuario";
            this.txt_ContraseñaUsuario.PasswordChar = '*';
            this.txt_ContraseñaUsuario.Size = new System.Drawing.Size(143, 24);
            this.txt_ContraseñaUsuario.TabIndex = 129;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(702, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 17);
            this.label3.TabIndex = 130;
            this.label3.Text = "Contraseña:";
            // 
            // txt_Busqueda
            // 
            this.txt_Busqueda.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Busqueda.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txt_Busqueda.Location = new System.Drawing.Point(31, 53);
            this.txt_Busqueda.Name = "txt_Busqueda";
            this.txt_Busqueda.Size = new System.Drawing.Size(594, 24);
            this.txt_Busqueda.TabIndex = 133;
            this.txt_Busqueda.Tag = "8";
            this.txt_Busqueda.Text = "Búsqueda por: Nombre";
            // 
            // btn_DesbloquearCuenta
            // 
            this.btn_DesbloquearCuenta.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_DesbloquearCuenta.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_DesbloquearCuenta.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_DesbloquearCuenta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_DesbloquearCuenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_DesbloquearCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DesbloquearCuenta.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DesbloquearCuenta.ForeColor = System.Drawing.Color.White;
            this.btn_DesbloquearCuenta.Location = new System.Drawing.Point(479, 370);
            this.btn_DesbloquearCuenta.Name = "btn_DesbloquearCuenta";
            this.btn_DesbloquearCuenta.Size = new System.Drawing.Size(114, 49);
            this.btn_DesbloquearCuenta.TabIndex = 134;
            this.btn_DesbloquearCuenta.Tag = "6";
            this.btn_DesbloquearCuenta.Text = "Desbloquear Cuenta";
            this.btn_DesbloquearCuenta.UseVisualStyleBackColor = false;
            // 
            // cb_Permiso
            // 
            this.cb_Permiso.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Permiso.FormattingEnabled = true;
            this.cb_Permiso.Location = new System.Drawing.Point(797, 246);
            this.cb_Permiso.Name = "cb_Permiso";
            this.cb_Permiso.Size = new System.Drawing.Size(143, 25);
            this.cb_Permiso.TabIndex = 135;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(725, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 136;
            this.label4.Text = "Permiso:";
            // 
            // txt_IdUsuario
            // 
            this.txt_IdUsuario.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_IdUsuario.Location = new System.Drawing.Point(797, 62);
            this.txt_IdUsuario.Name = "txt_IdUsuario";
            this.txt_IdUsuario.Size = new System.Drawing.Size(143, 24);
            this.txt_IdUsuario.TabIndex = 137;
            // 
            // btn_CancelarUsuario
            // 
            this.btn_CancelarUsuario.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_CancelarUsuario.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_CancelarUsuario.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CancelarUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CancelarUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CancelarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CancelarUsuario.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CancelarUsuario.ForeColor = System.Drawing.Color.White;
            this.btn_CancelarUsuario.Location = new System.Drawing.Point(863, 308);
            this.btn_CancelarUsuario.Name = "btn_CancelarUsuario";
            this.btn_CancelarUsuario.Size = new System.Drawing.Size(91, 40);
            this.btn_CancelarUsuario.TabIndex = 138;
            this.btn_CancelarUsuario.Tag = "5";
            this.btn_CancelarUsuario.Text = "Cancelar";
            this.btn_CancelarUsuario.UseVisualStyleBackColor = false;
            // 
            // btn_GuardarUsuario
            // 
            this.btn_GuardarUsuario.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_GuardarUsuario.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_GuardarUsuario.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GuardarUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GuardarUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GuardarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GuardarUsuario.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GuardarUsuario.ForeColor = System.Drawing.Color.White;
            this.btn_GuardarUsuario.Location = new System.Drawing.Point(729, 308);
            this.btn_GuardarUsuario.Name = "btn_GuardarUsuario";
            this.btn_GuardarUsuario.Size = new System.Drawing.Size(91, 40);
            this.btn_GuardarUsuario.TabIndex = 139;
            this.btn_GuardarUsuario.Tag = "4";
            this.btn_GuardarUsuario.Text = "Guardar";
            this.btn_GuardarUsuario.UseVisualStyleBackColor = false;
            // 
            // lbl_UsuarioLog
            // 
            this.lbl_UsuarioLog.AutoSize = true;
            this.lbl_UsuarioLog.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UsuarioLog.ForeColor = System.Drawing.Color.White;
            this.lbl_UsuarioLog.Location = new System.Drawing.Point(177, 13);
            this.lbl_UsuarioLog.Name = "lbl_UsuarioLog";
            this.lbl_UsuarioLog.Size = new System.Drawing.Size(57, 21);
            this.lbl_UsuarioLog.TabIndex = 141;
            this.lbl_UsuarioLog.Text = "label5";
            // 
            // lbl_Aviso
            // 
            this.lbl_Aviso.AutoSize = true;
            this.lbl_Aviso.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Aviso.ForeColor = System.Drawing.Color.Red;
            this.lbl_Aviso.Location = new System.Drawing.Point(850, 388);
            this.lbl_Aviso.Name = "lbl_Aviso";
            this.lbl_Aviso.Size = new System.Drawing.Size(58, 19);
            this.lbl_Aviso.TabIndex = 142;
            this.lbl_Aviso.Text = "label5";
            // 
            // dt_FechaAlta
            // 
            this.dt_FechaAlta.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_FechaAlta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_FechaAlta.Location = new System.Drawing.Point(797, 108);
            this.dt_FechaAlta.Name = "dt_FechaAlta";
            this.dt_FechaAlta.Size = new System.Drawing.Size(143, 24);
            this.dt_FechaAlta.TabIndex = 143;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(28, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 19);
            this.label5.TabIndex = 144;
            this.label5.Text = "Usuario Logeado:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(583, 440);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(410, 17);
            this.label6.TabIndex = 145;
            this.label6.Text = "Nota: Al desbloquear un usuario, actualizarle la contraseña.";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(31, 36);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(594, 10);
            this.bunifuSeparator1.TabIndex = 146;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // frmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1005, 466);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dt_FechaAlta);
            this.Controls.Add(this.lbl_Aviso);
            this.Controls.Add(this.lbl_UsuarioLog);
            this.Controls.Add(this.btn_GuardarUsuario);
            this.Controls.Add(this.btn_CancelarUsuario);
            this.Controls.Add(this.txt_IdUsuario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_Permiso);
            this.Controls.Add(this.btn_DesbloquearCuenta);
            this.Controls.Add(this.txt_Busqueda);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_ContraseñaUsuario);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_NombreUsuario);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.dgv_Usuarios);
            this.Controls.Add(this.btn_ModUsuario);
            this.Controls.Add(this.btn_BajaUsuario);
            this.Controls.Add(this.btn_AltaUsuario);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUsuario";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Usuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgv_Usuarios;
        internal System.Windows.Forms.Button btn_ModUsuario;
        internal System.Windows.Forms.Button btn_BajaUsuario;
        internal System.Windows.Forms.Button btn_AltaUsuario;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txt_NombreUsuario;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txt_ContraseñaUsuario;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txt_Busqueda;
        internal System.Windows.Forms.Button btn_DesbloquearCuenta;
        private System.Windows.Forms.ComboBox cb_Permiso;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txt_IdUsuario;
        internal System.Windows.Forms.Button btn_CancelarUsuario;
        internal System.Windows.Forms.Button btn_GuardarUsuario;
        private System.Windows.Forms.Label lbl_UsuarioLog;
        private System.Windows.Forms.Label lbl_Aviso;
        private System.Windows.Forms.DateTimePicker dt_FechaAlta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
    }
}