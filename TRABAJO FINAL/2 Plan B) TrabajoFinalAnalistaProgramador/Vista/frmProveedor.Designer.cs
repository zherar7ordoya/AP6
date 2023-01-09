namespace Vista
{
    partial class frmProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProveedor));
            this.dgv_Proveedores = new System.Windows.Forms.DataGridView();
            this.btn_ModProveedor = new System.Windows.Forms.Button();
            this.btn_BajaProveedor = new System.Windows.Forms.Button();
            this.btn_AltaProveedor = new System.Windows.Forms.Button();
            this.txt_Busqueda = new System.Windows.Forms.TextBox();
            this.label_UsuarioLog = new System.Windows.Forms.Label();
            this.lbl_UsuarioLog = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_ReporteProveedor = new System.Windows.Forms.Button();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_NombreProv = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.txt_DireccionProv = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.cb_Gerente = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_LocalidadProv = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_ProvinciaProv = new System.Windows.Forms.TextBox();
            this.btn_AceptarProveedor = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_EmailProv = new System.Windows.Forms.TextBox();
            this.txt_IdProv = new System.Windows.Forms.TextBox();
            this.btn_CancelarProveedor = new System.Windows.Forms.Button();
            this.txt_TelefonoProv = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Proveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Proveedores
            // 
            this.dgv_Proveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Proveedores.Location = new System.Drawing.Point(12, 85);
            this.dgv_Proveedores.Name = "dgv_Proveedores";
            this.dgv_Proveedores.RowHeadersWidth = 49;
            this.dgv_Proveedores.Size = new System.Drawing.Size(856, 460);
            this.dgv_Proveedores.TabIndex = 104;
            this.dgv_Proveedores.Tag = "14";
            // 
            // btn_ModProveedor
            // 
            this.btn_ModProveedor.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_ModProveedor.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_ModProveedor.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ModProveedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ModProveedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ModProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ModProveedor.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ModProveedor.ForeColor = System.Drawing.Color.White;
            this.btn_ModProveedor.Location = new System.Drawing.Point(291, 573);
            this.btn_ModProveedor.Name = "btn_ModProveedor";
            this.btn_ModProveedor.Size = new System.Drawing.Size(89, 36);
            this.btn_ModProveedor.TabIndex = 103;
            this.btn_ModProveedor.Tag = "11";
            this.btn_ModProveedor.Text = "Modificar";
            this.btn_ModProveedor.UseVisualStyleBackColor = false;
            // 
            // btn_BajaProveedor
            // 
            this.btn_BajaProveedor.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_BajaProveedor.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_BajaProveedor.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaProveedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaProveedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BajaProveedor.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BajaProveedor.ForeColor = System.Drawing.Color.White;
            this.btn_BajaProveedor.Location = new System.Drawing.Point(484, 573);
            this.btn_BajaProveedor.Name = "btn_BajaProveedor";
            this.btn_BajaProveedor.Size = new System.Drawing.Size(90, 36);
            this.btn_BajaProveedor.TabIndex = 102;
            this.btn_BajaProveedor.Tag = "10";
            this.btn_BajaProveedor.Text = "Baja";
            this.btn_BajaProveedor.UseVisualStyleBackColor = false;
            // 
            // btn_AltaProveedor
            // 
            this.btn_AltaProveedor.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_AltaProveedor.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_AltaProveedor.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AltaProveedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AltaProveedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AltaProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AltaProveedor.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AltaProveedor.ForeColor = System.Drawing.Color.White;
            this.btn_AltaProveedor.Location = new System.Drawing.Point(94, 573);
            this.btn_AltaProveedor.Name = "btn_AltaProveedor";
            this.btn_AltaProveedor.Size = new System.Drawing.Size(93, 36);
            this.btn_AltaProveedor.TabIndex = 101;
            this.btn_AltaProveedor.Tag = "9";
            this.btn_AltaProveedor.Text = "Alta";
            this.btn_AltaProveedor.UseVisualStyleBackColor = false;
            // 
            // txt_Busqueda
            // 
            this.txt_Busqueda.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Busqueda.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txt_Busqueda.Location = new System.Drawing.Point(12, 55);
            this.txt_Busqueda.Name = "txt_Busqueda";
            this.txt_Busqueda.Size = new System.Drawing.Size(856, 24);
            this.txt_Busqueda.TabIndex = 123;
            this.txt_Busqueda.Tag = "15";
            this.txt_Busqueda.Text = "Búsqueda por: Nombre";
            // 
            // label_UsuarioLog
            // 
            this.label_UsuarioLog.AutoSize = true;
            this.label_UsuarioLog.Location = new System.Drawing.Point(60, 13);
            this.label_UsuarioLog.Name = "label_UsuarioLog";
            this.label_UsuarioLog.Size = new System.Drawing.Size(0, 13);
            this.label_UsuarioLog.TabIndex = 124;
            // 
            // lbl_UsuarioLog
            // 
            this.lbl_UsuarioLog.AutoSize = true;
            this.lbl_UsuarioLog.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UsuarioLog.ForeColor = System.Drawing.Color.White;
            this.lbl_UsuarioLog.Location = new System.Drawing.Point(154, 13);
            this.lbl_UsuarioLog.Name = "lbl_UsuarioLog";
            this.lbl_UsuarioLog.Size = new System.Drawing.Size(57, 21);
            this.lbl_UsuarioLog.TabIndex = 126;
            this.lbl_UsuarioLog.Text = "label9";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(12, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 19);
            this.label9.TabIndex = 127;
            this.label9.Text = "Usuario Logeado:";
            // 
            // btn_ReporteProveedor
            // 
            this.btn_ReporteProveedor.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_ReporteProveedor.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_ReporteProveedor.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ReporteProveedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ReporteProveedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ReporteProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ReporteProveedor.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ReporteProveedor.ForeColor = System.Drawing.Color.White;
            this.btn_ReporteProveedor.Location = new System.Drawing.Point(678, 573);
            this.btn_ReporteProveedor.Name = "btn_ReporteProveedor";
            this.btn_ReporteProveedor.Size = new System.Drawing.Size(90, 36);
            this.btn_ReporteProveedor.TabIndex = 128;
            this.btn_ReporteProveedor.Tag = "101";
            this.btn_ReporteProveedor.Text = "Reporte";
            this.btn_ReporteProveedor.UseVisualStyleBackColor = false;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(12, 35);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(856, 14);
            this.bunifuSeparator1.TabIndex = 129;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(994, 414);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 17);
            this.label8.TabIndex = 147;
            this.label8.Text = "Gerente:";
            // 
            // txt_NombreProv
            // 
            this.txt_NombreProv.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NombreProv.Location = new System.Drawing.Point(1065, 160);
            this.txt_NombreProv.Name = "txt_NombreProv";
            this.txt_NombreProv.Size = new System.Drawing.Size(165, 24);
            this.txt_NombreProv.TabIndex = 131;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.White;
            this.Label4.Location = new System.Drawing.Point(993, 327);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(70, 17);
            this.Label4.TabIndex = 136;
            this.Label4.Text = "Teléfono:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.White;
            this.Label3.Location = new System.Drawing.Point(981, 245);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(80, 17);
            this.Label3.TabIndex = 135;
            this.Label3.Text = "Localidad:";
            // 
            // txt_DireccionProv
            // 
            this.txt_DireccionProv.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DireccionProv.Location = new System.Drawing.Point(1065, 201);
            this.txt_DireccionProv.Name = "txt_DireccionProv";
            this.txt_DireccionProv.Size = new System.Drawing.Size(165, 24);
            this.txt_DireccionProv.TabIndex = 137;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.Location = new System.Drawing.Point(995, 163);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(67, 17);
            this.Label2.TabIndex = 134;
            this.Label2.Text = "Nombre:";
            // 
            // cb_Gerente
            // 
            this.cb_Gerente.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Gerente.FormattingEnabled = true;
            this.cb_Gerente.Location = new System.Drawing.Point(1065, 411);
            this.cb_Gerente.Name = "cb_Gerente";
            this.cb_Gerente.Size = new System.Drawing.Size(165, 25);
            this.cb_Gerente.TabIndex = 146;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(985, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 17);
            this.label7.TabIndex = 138;
            this.label7.Text = "Dirección:";
            // 
            // txt_LocalidadProv
            // 
            this.txt_LocalidadProv.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_LocalidadProv.Location = new System.Drawing.Point(1065, 242);
            this.txt_LocalidadProv.Name = "txt_LocalidadProv";
            this.txt_LocalidadProv.Size = new System.Drawing.Size(165, 24);
            this.txt_LocalidadProv.TabIndex = 132;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(965, 119);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(97, 17);
            this.Label1.TabIndex = 133;
            this.Label1.Text = "Id Proveedor:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1011, 368);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 17);
            this.label6.TabIndex = 143;
            this.label6.Text = "Email:";
            // 
            // txt_ProvinciaProv
            // 
            this.txt_ProvinciaProv.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ProvinciaProv.Location = new System.Drawing.Point(1065, 283);
            this.txt_ProvinciaProv.Name = "txt_ProvinciaProv";
            this.txt_ProvinciaProv.Size = new System.Drawing.Size(165, 24);
            this.txt_ProvinciaProv.TabIndex = 139;
            // 
            // btn_AceptarProveedor
            // 
            this.btn_AceptarProveedor.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_AceptarProveedor.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_AceptarProveedor.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AceptarProveedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AceptarProveedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AceptarProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AceptarProveedor.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AceptarProveedor.ForeColor = System.Drawing.Color.White;
            this.btn_AceptarProveedor.Location = new System.Drawing.Point(1038, 475);
            this.btn_AceptarProveedor.Name = "btn_AceptarProveedor";
            this.btn_AceptarProveedor.Size = new System.Drawing.Size(84, 37);
            this.btn_AceptarProveedor.TabIndex = 144;
            this.btn_AceptarProveedor.Tag = "12";
            this.btn_AceptarProveedor.Text = "Aceptar";
            this.btn_AceptarProveedor.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(987, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 140;
            this.label5.Text = "Provincia:";
            // 
            // txt_EmailProv
            // 
            this.txt_EmailProv.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_EmailProv.Location = new System.Drawing.Point(1065, 365);
            this.txt_EmailProv.Name = "txt_EmailProv";
            this.txt_EmailProv.Size = new System.Drawing.Size(165, 24);
            this.txt_EmailProv.TabIndex = 142;
            // 
            // txt_IdProv
            // 
            this.txt_IdProv.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_IdProv.Location = new System.Drawing.Point(1065, 116);
            this.txt_IdProv.Name = "txt_IdProv";
            this.txt_IdProv.Size = new System.Drawing.Size(165, 24);
            this.txt_IdProv.TabIndex = 130;
            // 
            // btn_CancelarProveedor
            // 
            this.btn_CancelarProveedor.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_CancelarProveedor.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_CancelarProveedor.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CancelarProveedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CancelarProveedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CancelarProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CancelarProveedor.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CancelarProveedor.ForeColor = System.Drawing.Color.White;
            this.btn_CancelarProveedor.Location = new System.Drawing.Point(1162, 475);
            this.btn_CancelarProveedor.Name = "btn_CancelarProveedor";
            this.btn_CancelarProveedor.Size = new System.Drawing.Size(84, 37);
            this.btn_CancelarProveedor.TabIndex = 145;
            this.btn_CancelarProveedor.Tag = "13";
            this.btn_CancelarProveedor.Text = "Cancelar";
            this.btn_CancelarProveedor.UseVisualStyleBackColor = false;
            // 
            // txt_TelefonoProv
            // 
            this.txt_TelefonoProv.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TelefonoProv.Location = new System.Drawing.Point(1065, 324);
            this.txt_TelefonoProv.Name = "txt_TelefonoProv";
            this.txt_TelefonoProv.Size = new System.Drawing.Size(165, 24);
            this.txt_TelefonoProv.TabIndex = 141;
            // 
            // frmProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1304, 637);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_NombreProv);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txt_DireccionProv);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cb_Gerente);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_LocalidadProv);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_ProvinciaProv);
            this.Controls.Add(this.btn_AceptarProveedor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_EmailProv);
            this.Controls.Add(this.txt_IdProv);
            this.Controls.Add(this.btn_CancelarProveedor);
            this.Controls.Add(this.txt_TelefonoProv);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.btn_ReporteProveedor);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbl_UsuarioLog);
            this.Controls.Add(this.label_UsuarioLog);
            this.Controls.Add(this.txt_Busqueda);
            this.Controls.Add(this.dgv_Proveedores);
            this.Controls.Add(this.btn_ModProveedor);
            this.Controls.Add(this.btn_BajaProveedor);
            this.Controls.Add(this.btn_AltaProveedor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProveedor";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proveedores";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Proveedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Button btn_ModProveedor;
        internal System.Windows.Forms.Button btn_BajaProveedor;
        internal System.Windows.Forms.Button btn_AltaProveedor;
        internal System.Windows.Forms.TextBox txt_Busqueda;
        public System.Windows.Forms.Label label_UsuarioLog;
        public System.Windows.Forms.DataGridView dgv_Proveedores;
        public System.Windows.Forms.Label lbl_UsuarioLog;
        public System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Button btn_ReporteProveedor;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txt_NombreProv;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txt_DireccionProv;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.ComboBox cb_Gerente;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txt_LocalidadProv;
        public System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txt_ProvinciaProv;
        internal System.Windows.Forms.Button btn_AceptarProveedor;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txt_EmailProv;
        internal System.Windows.Forms.TextBox txt_IdProv;
        internal System.Windows.Forms.Button btn_CancelarProveedor;
        internal System.Windows.Forms.TextBox txt_TelefonoProv;
    }
}