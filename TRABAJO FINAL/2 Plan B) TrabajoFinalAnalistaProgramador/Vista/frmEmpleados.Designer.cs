namespace Vista
{
    partial class frmEmpleados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpleados));
            this.dgv_Empleados = new System.Windows.Forms.DataGridView();
            this.btn_ModEmpleado = new System.Windows.Forms.Button();
            this.btn_BajaEmpleado = new System.Windows.Forms.Button();
            this.btn_AltaEmpleado = new System.Windows.Forms.Button();
            this.txt_Busqueda = new System.Windows.Forms.TextBox();
            this.lbl_UsuarioLog = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.lbl_Aviso = new System.Windows.Forms.Label();
            this.btn_CancelarEmpleado = new System.Windows.Forms.Button();
            this.btn_GuardarEmpleado = new System.Windows.Forms.Button();
            this.cb_Usuario = new System.Windows.Forms.ComboBox();
            this.txt_SdoBrutoEmpleado = new System.Windows.Forms.TextBox();
            this.txt_EstCivilEmpleado = new System.Windows.Forms.TextBox();
            this.txt_TelefonoEmpleado = new System.Windows.Forms.TextBox();
            this.dt_FechaNac = new System.Windows.Forms.DateTimePicker();
            this.txt_DireccionEmpleado = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txt_CelularEmpleado = new System.Windows.Forms.TextBox();
            this.txt_ApellidoEmpleado = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_NombreEmpleado = new System.Windows.Forms.TextBox();
            this.txt_DniEmpleado = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_MailEmpleado = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Empleados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Empleados
            // 
            this.dgv_Empleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Empleados.Location = new System.Drawing.Point(29, 97);
            this.dgv_Empleados.Name = "dgv_Empleados";
            this.dgv_Empleados.RowHeadersWidth = 49;
            this.dgv_Empleados.Size = new System.Drawing.Size(693, 401);
            this.dgv_Empleados.TabIndex = 104;
            this.dgv_Empleados.Tag = "28";
            // 
            // btn_ModEmpleado
            // 
            this.btn_ModEmpleado.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_ModEmpleado.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_ModEmpleado.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ModEmpleado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ModEmpleado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ModEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ModEmpleado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ModEmpleado.ForeColor = System.Drawing.Color.White;
            this.btn_ModEmpleado.Location = new System.Drawing.Point(301, 535);
            this.btn_ModEmpleado.Name = "btn_ModEmpleado";
            this.btn_ModEmpleado.Size = new System.Drawing.Size(92, 35);
            this.btn_ModEmpleado.TabIndex = 103;
            this.btn_ModEmpleado.Tag = "25";
            this.btn_ModEmpleado.Text = "Modificar";
            this.btn_ModEmpleado.UseVisualStyleBackColor = false;
            // 
            // btn_BajaEmpleado
            // 
            this.btn_BajaEmpleado.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_BajaEmpleado.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_BajaEmpleado.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaEmpleado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaEmpleado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BajaEmpleado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BajaEmpleado.ForeColor = System.Drawing.Color.White;
            this.btn_BajaEmpleado.Location = new System.Drawing.Point(451, 535);
            this.btn_BajaEmpleado.Name = "btn_BajaEmpleado";
            this.btn_BajaEmpleado.Size = new System.Drawing.Size(92, 35);
            this.btn_BajaEmpleado.TabIndex = 102;
            this.btn_BajaEmpleado.Tag = "24";
            this.btn_BajaEmpleado.Text = "Baja";
            this.btn_BajaEmpleado.UseVisualStyleBackColor = false;
            // 
            // btn_AltaEmpleado
            // 
            this.btn_AltaEmpleado.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_AltaEmpleado.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_AltaEmpleado.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AltaEmpleado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AltaEmpleado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AltaEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AltaEmpleado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AltaEmpleado.ForeColor = System.Drawing.Color.White;
            this.btn_AltaEmpleado.Location = new System.Drawing.Point(153, 535);
            this.btn_AltaEmpleado.Name = "btn_AltaEmpleado";
            this.btn_AltaEmpleado.Size = new System.Drawing.Size(92, 35);
            this.btn_AltaEmpleado.TabIndex = 101;
            this.btn_AltaEmpleado.Tag = "23";
            this.btn_AltaEmpleado.Text = "Alta";
            this.btn_AltaEmpleado.UseVisualStyleBackColor = false;
            // 
            // txt_Busqueda
            // 
            this.txt_Busqueda.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Busqueda.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txt_Busqueda.Location = new System.Drawing.Point(29, 68);
            this.txt_Busqueda.Name = "txt_Busqueda";
            this.txt_Busqueda.Size = new System.Drawing.Size(693, 24);
            this.txt_Busqueda.TabIndex = 123;
            this.txt_Busqueda.Tag = "29";
            this.txt_Busqueda.Text = "Búsqueda por: Nombre";
            // 
            // lbl_UsuarioLog
            // 
            this.lbl_UsuarioLog.AutoSize = true;
            this.lbl_UsuarioLog.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UsuarioLog.ForeColor = System.Drawing.Color.White;
            this.lbl_UsuarioLog.Location = new System.Drawing.Point(171, 18);
            this.lbl_UsuarioLog.Name = "lbl_UsuarioLog";
            this.lbl_UsuarioLog.Size = new System.Drawing.Size(57, 21);
            this.lbl_UsuarioLog.TabIndex = 126;
            this.lbl_UsuarioLog.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(25, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 19);
            this.label3.TabIndex = 127;
            this.label3.Text = "Usuario Logeado:";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(29, 42);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(693, 10);
            this.bunifuSeparator1.TabIndex = 129;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // lbl_Aviso
            // 
            this.lbl_Aviso.AutoSize = true;
            this.lbl_Aviso.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Aviso.ForeColor = System.Drawing.Color.Red;
            this.lbl_Aviso.Location = new System.Drawing.Point(1031, 520);
            this.lbl_Aviso.Name = "lbl_Aviso";
            this.lbl_Aviso.Size = new System.Drawing.Size(58, 19);
            this.lbl_Aviso.TabIndex = 125;
            this.lbl_Aviso.Text = "label3";
            // 
            // btn_CancelarEmpleado
            // 
            this.btn_CancelarEmpleado.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_CancelarEmpleado.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_CancelarEmpleado.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CancelarEmpleado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CancelarEmpleado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CancelarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CancelarEmpleado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CancelarEmpleado.ForeColor = System.Drawing.Color.White;
            this.btn_CancelarEmpleado.Location = new System.Drawing.Point(951, 545);
            this.btn_CancelarEmpleado.Name = "btn_CancelarEmpleado";
            this.btn_CancelarEmpleado.Size = new System.Drawing.Size(92, 35);
            this.btn_CancelarEmpleado.TabIndex = 207;
            this.btn_CancelarEmpleado.Tag = "27";
            this.btn_CancelarEmpleado.Text = "Cancelar";
            this.btn_CancelarEmpleado.UseVisualStyleBackColor = false;
            // 
            // btn_GuardarEmpleado
            // 
            this.btn_GuardarEmpleado.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_GuardarEmpleado.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_GuardarEmpleado.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GuardarEmpleado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GuardarEmpleado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GuardarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GuardarEmpleado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GuardarEmpleado.ForeColor = System.Drawing.Color.White;
            this.btn_GuardarEmpleado.Location = new System.Drawing.Point(825, 545);
            this.btn_GuardarEmpleado.Name = "btn_GuardarEmpleado";
            this.btn_GuardarEmpleado.Size = new System.Drawing.Size(92, 35);
            this.btn_GuardarEmpleado.TabIndex = 206;
            this.btn_GuardarEmpleado.Tag = "26";
            this.btn_GuardarEmpleado.Text = "Guardar";
            this.btn_GuardarEmpleado.UseVisualStyleBackColor = false;
            // 
            // cb_Usuario
            // 
            this.cb_Usuario.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Usuario.FormattingEnabled = true;
            this.cb_Usuario.Location = new System.Drawing.Point(894, 432);
            this.cb_Usuario.Name = "cb_Usuario";
            this.cb_Usuario.Size = new System.Drawing.Size(121, 25);
            this.cb_Usuario.TabIndex = 230;
            // 
            // txt_SdoBrutoEmpleado
            // 
            this.txt_SdoBrutoEmpleado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SdoBrutoEmpleado.Location = new System.Drawing.Point(894, 392);
            this.txt_SdoBrutoEmpleado.Name = "txt_SdoBrutoEmpleado";
            this.txt_SdoBrutoEmpleado.Size = new System.Drawing.Size(121, 24);
            this.txt_SdoBrutoEmpleado.TabIndex = 235;
            // 
            // txt_EstCivilEmpleado
            // 
            this.txt_EstCivilEmpleado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_EstCivilEmpleado.Location = new System.Drawing.Point(894, 352);
            this.txt_EstCivilEmpleado.Name = "txt_EstCivilEmpleado";
            this.txt_EstCivilEmpleado.Size = new System.Drawing.Size(121, 24);
            this.txt_EstCivilEmpleado.TabIndex = 234;
            // 
            // txt_TelefonoEmpleado
            // 
            this.txt_TelefonoEmpleado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TelefonoEmpleado.Location = new System.Drawing.Point(895, 272);
            this.txt_TelefonoEmpleado.Name = "txt_TelefonoEmpleado";
            this.txt_TelefonoEmpleado.Size = new System.Drawing.Size(121, 24);
            this.txt_TelefonoEmpleado.TabIndex = 232;
            // 
            // dt_FechaNac
            // 
            this.dt_FechaNac.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_FechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_FechaNac.Location = new System.Drawing.Point(895, 312);
            this.dt_FechaNac.Name = "dt_FechaNac";
            this.dt_FechaNac.Size = new System.Drawing.Size(120, 24);
            this.dt_FechaNac.TabIndex = 237;
            // 
            // txt_DireccionEmpleado
            // 
            this.txt_DireccionEmpleado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DireccionEmpleado.Location = new System.Drawing.Point(895, 192);
            this.txt_DireccionEmpleado.Name = "txt_DireccionEmpleado";
            this.txt_DireccionEmpleado.Size = new System.Drawing.Size(121, 24);
            this.txt_DireccionEmpleado.TabIndex = 233;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(849, 75);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(34, 17);
            this.Label1.TabIndex = 218;
            this.Label1.Text = "Dni:";
            // 
            // txt_CelularEmpleado
            // 
            this.txt_CelularEmpleado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CelularEmpleado.Location = new System.Drawing.Point(895, 232);
            this.txt_CelularEmpleado.Name = "txt_CelularEmpleado";
            this.txt_CelularEmpleado.Size = new System.Drawing.Size(121, 24);
            this.txt_CelularEmpleado.TabIndex = 231;
            // 
            // txt_ApellidoEmpleado
            // 
            this.txt_ApellidoEmpleado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ApellidoEmpleado.Location = new System.Drawing.Point(895, 152);
            this.txt_ApellidoEmpleado.Name = "txt_ApellidoEmpleado";
            this.txt_ApellidoEmpleado.Size = new System.Drawing.Size(121, 24);
            this.txt_ApellidoEmpleado.TabIndex = 236;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.Location = new System.Drawing.Point(816, 115);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(67, 17);
            this.Label2.TabIndex = 219;
            this.Label2.Text = "Nombre:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(813, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 17);
            this.label7.TabIndex = 220;
            this.label7.Text = "Apellido:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(747, 315);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 17);
            this.label4.TabIndex = 222;
            this.label4.Text = "Fecha nacimiento:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(822, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 223;
            this.label5.Text = "Celular:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(787, 395);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 17);
            this.label10.TabIndex = 227;
            this.label10.Text = "Sueldo bruto:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(804, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 17);
            this.label8.TabIndex = 225;
            this.label8.Text = "Dirección:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(813, 275);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 17);
            this.label6.TabIndex = 224;
            this.label6.Text = "Teléfono:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(796, 359);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 17);
            this.label9.TabIndex = 226;
            this.label9.Text = "Estado civíl:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(822, 435);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 17);
            this.label11.TabIndex = 221;
            this.label11.Text = "Usuario:";
            // 
            // txt_NombreEmpleado
            // 
            this.txt_NombreEmpleado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NombreEmpleado.Location = new System.Drawing.Point(895, 112);
            this.txt_NombreEmpleado.Name = "txt_NombreEmpleado";
            this.txt_NombreEmpleado.Size = new System.Drawing.Size(121, 24);
            this.txt_NombreEmpleado.TabIndex = 229;
            // 
            // txt_DniEmpleado
            // 
            this.txt_DniEmpleado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DniEmpleado.Location = new System.Drawing.Point(895, 72);
            this.txt_DniEmpleado.Name = "txt_DniEmpleado";
            this.txt_DniEmpleado.Size = new System.Drawing.Size(121, 24);
            this.txt_DniEmpleado.TabIndex = 228;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(779, 476);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 17);
            this.label12.TabIndex = 238;
            this.label12.Text = "Mail personal:";
            // 
            // txt_MailEmpleado
            // 
            this.txt_MailEmpleado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MailEmpleado.Location = new System.Drawing.Point(895, 473);
            this.txt_MailEmpleado.Name = "txt_MailEmpleado";
            this.txt_MailEmpleado.Size = new System.Drawing.Size(121, 24);
            this.txt_MailEmpleado.TabIndex = 239;
            // 
            // frmEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1101, 605);
            this.Controls.Add(this.txt_MailEmpleado);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cb_Usuario);
            this.Controls.Add(this.txt_SdoBrutoEmpleado);
            this.Controls.Add(this.txt_EstCivilEmpleado);
            this.Controls.Add(this.txt_TelefonoEmpleado);
            this.Controls.Add(this.dt_FechaNac);
            this.Controls.Add(this.txt_DireccionEmpleado);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txt_CelularEmpleado);
            this.Controls.Add(this.txt_ApellidoEmpleado);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_NombreEmpleado);
            this.Controls.Add(this.txt_DniEmpleado);
            this.Controls.Add(this.btn_CancelarEmpleado);
            this.Controls.Add(this.btn_GuardarEmpleado);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_UsuarioLog);
            this.Controls.Add(this.lbl_Aviso);
            this.Controls.Add(this.txt_Busqueda);
            this.Controls.Add(this.dgv_Empleados);
            this.Controls.Add(this.btn_ModEmpleado);
            this.Controls.Add(this.btn_BajaEmpleado);
            this.Controls.Add(this.btn_AltaEmpleado);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmpleados";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empleados";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Empleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.DataGridView dgv_Empleados;
        internal System.Windows.Forms.Button btn_ModEmpleado;
        internal System.Windows.Forms.Button btn_BajaEmpleado;
        internal System.Windows.Forms.Button btn_AltaEmpleado;
        internal System.Windows.Forms.TextBox txt_Busqueda;
        private System.Windows.Forms.Label lbl_UsuarioLog;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.Label lbl_Aviso;
        internal System.Windows.Forms.Button btn_CancelarEmpleado;
        internal System.Windows.Forms.Button btn_GuardarEmpleado;
        private System.Windows.Forms.ComboBox cb_Usuario;
        internal System.Windows.Forms.TextBox txt_SdoBrutoEmpleado;
        internal System.Windows.Forms.TextBox txt_EstCivilEmpleado;
        internal System.Windows.Forms.TextBox txt_TelefonoEmpleado;
        private System.Windows.Forms.DateTimePicker dt_FechaNac;
        internal System.Windows.Forms.TextBox txt_DireccionEmpleado;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txt_CelularEmpleado;
        internal System.Windows.Forms.TextBox txt_ApellidoEmpleado;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.TextBox txt_NombreEmpleado;
        internal System.Windows.Forms.TextBox txt_DniEmpleado;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.TextBox txt_MailEmpleado;
    }
}