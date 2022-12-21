namespace Vista
{
    partial class frmDeterminarSueldos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeterminarSueldos));
            this.btn_BajaSueldo = new System.Windows.Forms.Button();
            this.btn_NuevoSueldo = new System.Windows.Forms.Button();
            this.dgv_SueldosNetos = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_ImporteSueldoNeto = new System.Windows.Forms.TextBox();
            this.txt_IdSueldo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_Empleado = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dt_FechaSueldo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nud_HorasExtras = new System.Windows.Forms.NumericUpDown();
            this.nud_CantidadInasistencias = new System.Windows.Forms.NumericUpDown();
            this.rb_Mala = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rb_MuyBuena = new System.Windows.Forms.RadioButton();
            this.rb_Excelente = new System.Windows.Forms.RadioButton();
            this.rb_Regular = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_ImpInasistencia = new System.Windows.Forms.TextBox();
            this.txt_ImportePuntualidad = new System.Windows.Forms.TextBox();
            this.txt_ImpHoraExtra = new System.Windows.Forms.TextBox();
            this.cb_SueldoBruto = new System.Windows.Forms.ComboBox();
            this.btn_GuardarSueldo = new System.Windows.Forms.Button();
            this.btn_CancelarSueldo = new System.Windows.Forms.Button();
            this.txt_Busqueda = new System.Windows.Forms.TextBox();
            this.cb_Gerente = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_CalcularSueldoNeto = new System.Windows.Forms.Button();
            this.lbl_Aviso = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_UsuarioLog = new System.Windows.Forms.Label();
            this.btn_ReporteSueldoNeto = new System.Windows.Forms.Button();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SueldosNetos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_HorasExtras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CantidadInasistencias)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_BajaSueldo
            // 
            this.btn_BajaSueldo.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_BajaSueldo.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_BajaSueldo.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaSueldo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaSueldo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaSueldo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BajaSueldo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BajaSueldo.ForeColor = System.Drawing.Color.White;
            this.btn_BajaSueldo.Location = new System.Drawing.Point(233, 467);
            this.btn_BajaSueldo.Name = "btn_BajaSueldo";
            this.btn_BajaSueldo.Size = new System.Drawing.Size(88, 38);
            this.btn_BajaSueldo.TabIndex = 24;
            this.btn_BajaSueldo.Tag = "38";
            this.btn_BajaSueldo.Text = "Baja";
            this.btn_BajaSueldo.UseVisualStyleBackColor = false;
            // 
            // btn_NuevoSueldo
            // 
            this.btn_NuevoSueldo.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_NuevoSueldo.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_NuevoSueldo.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_NuevoSueldo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_NuevoSueldo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_NuevoSueldo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NuevoSueldo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NuevoSueldo.ForeColor = System.Drawing.Color.White;
            this.btn_NuevoSueldo.Location = new System.Drawing.Point(76, 466);
            this.btn_NuevoSueldo.Name = "btn_NuevoSueldo";
            this.btn_NuevoSueldo.Size = new System.Drawing.Size(115, 40);
            this.btn_NuevoSueldo.TabIndex = 22;
            this.btn_NuevoSueldo.Tag = "37";
            this.btn_NuevoSueldo.Text = "Nuevo Sueldo";
            this.btn_NuevoSueldo.UseVisualStyleBackColor = false;
            // 
            // dgv_SueldosNetos
            // 
            this.dgv_SueldosNetos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SueldosNetos.Location = new System.Drawing.Point(12, 76);
            this.dgv_SueldosNetos.Name = "dgv_SueldosNetos";
            this.dgv_SueldosNetos.Size = new System.Drawing.Size(523, 372);
            this.dgv_SueldosNetos.TabIndex = 20;
            this.dgv_SueldosNetos.Tag = "43";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(860, 177);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 17);
            this.label9.TabIndex = 58;
            this.label9.Text = "Importe:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(610, 481);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 17);
            this.label8.TabIndex = 51;
            this.label8.Text = "Importe total:";
            // 
            // txt_ImporteSueldoNeto
            // 
            this.txt_ImporteSueldoNeto.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ImporteSueldoNeto.Location = new System.Drawing.Point(715, 478);
            this.txt_ImporteSueldoNeto.Name = "txt_ImporteSueldoNeto";
            this.txt_ImporteSueldoNeto.Size = new System.Drawing.Size(218, 24);
            this.txt_ImporteSueldoNeto.TabIndex = 50;
            // 
            // txt_IdSueldo
            // 
            this.txt_IdSueldo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_IdSueldo.Location = new System.Drawing.Point(715, 15);
            this.txt_IdSueldo.Name = "txt_IdSueldo";
            this.txt_IdSueldo.Size = new System.Drawing.Size(120, 24);
            this.txt_IdSueldo.TabIndex = 49;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(684, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 17);
            this.label7.TabIndex = 48;
            this.label7.Text = "Id:";
            // 
            // cb_Empleado
            // 
            this.cb_Empleado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Empleado.FormattingEnabled = true;
            this.cb_Empleado.Location = new System.Drawing.Point(715, 93);
            this.cb_Empleado.Name = "cb_Empleado";
            this.cb_Empleado.Size = new System.Drawing.Size(120, 25);
            this.cb_Empleado.TabIndex = 47;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(627, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 17);
            this.label6.TabIndex = 46;
            this.label6.Text = "Empleado:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(613, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 45;
            this.label5.Text = "Sueldo bruto:";
            // 
            // dt_FechaSueldo
            // 
            this.dt_FechaSueldo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_FechaSueldo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_FechaSueldo.Location = new System.Drawing.Point(715, 54);
            this.dt_FechaSueldo.Name = "dt_FechaSueldo";
            this.dt_FechaSueldo.Size = new System.Drawing.Size(120, 24);
            this.dt_FechaSueldo.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(621, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 17);
            this.label4.TabIndex = 43;
            this.label4.Text = "Hora extras:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(655, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 41;
            this.label3.Text = "Fecha:";
            // 
            // nud_HorasExtras
            // 
            this.nud_HorasExtras.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_HorasExtras.Location = new System.Drawing.Point(715, 338);
            this.nud_HorasExtras.Name = "nud_HorasExtras";
            this.nud_HorasExtras.Size = new System.Drawing.Size(120, 24);
            this.nud_HorasExtras.TabIndex = 44;
            // 
            // nud_CantidadInasistencias
            // 
            this.nud_CantidadInasistencias.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_CantidadInasistencias.Location = new System.Drawing.Point(715, 173);
            this.nud_CantidadInasistencias.Name = "nud_CantidadInasistencias";
            this.nud_CantidadInasistencias.Size = new System.Drawing.Size(120, 24);
            this.nud_CantidadInasistencias.TabIndex = 39;
            // 
            // rb_Mala
            // 
            this.rb_Mala.AutoSize = true;
            this.rb_Mala.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Mala.ForeColor = System.Drawing.Color.White;
            this.rb_Mala.Location = new System.Drawing.Point(715, 301);
            this.rb_Mala.Name = "rb_Mala";
            this.rb_Mala.Size = new System.Drawing.Size(61, 21);
            this.rb_Mala.TabIndex = 40;
            this.rb_Mala.TabStop = true;
            this.rb_Mala.Text = "Mala";
            this.rb_Mala.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(544, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 17);
            this.label1.TabIndex = 34;
            this.label1.Text = "Cantidad inasistencias:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(617, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 35;
            this.label2.Text = "Puntualidad:";
            // 
            // rb_MuyBuena
            // 
            this.rb_MuyBuena.AutoSize = true;
            this.rb_MuyBuena.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_MuyBuena.ForeColor = System.Drawing.Color.White;
            this.rb_MuyBuena.Location = new System.Drawing.Point(715, 247);
            this.rb_MuyBuena.Name = "rb_MuyBuena";
            this.rb_MuyBuena.Size = new System.Drawing.Size(101, 21);
            this.rb_MuyBuena.TabIndex = 37;
            this.rb_MuyBuena.TabStop = true;
            this.rb_MuyBuena.Text = "Muy buena";
            this.rb_MuyBuena.UseVisualStyleBackColor = true;
            // 
            // rb_Excelente
            // 
            this.rb_Excelente.AutoSize = true;
            this.rb_Excelente.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Excelente.ForeColor = System.Drawing.Color.White;
            this.rb_Excelente.Location = new System.Drawing.Point(715, 217);
            this.rb_Excelente.Name = "rb_Excelente";
            this.rb_Excelente.Size = new System.Drawing.Size(93, 21);
            this.rb_Excelente.TabIndex = 36;
            this.rb_Excelente.TabStop = true;
            this.rb_Excelente.Text = "Excelente";
            this.rb_Excelente.UseVisualStyleBackColor = true;
            // 
            // rb_Regular
            // 
            this.rb_Regular.AutoSize = true;
            this.rb_Regular.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Regular.ForeColor = System.Drawing.Color.White;
            this.rb_Regular.Location = new System.Drawing.Point(715, 274);
            this.rb_Regular.Name = "rb_Regular";
            this.rb_Regular.Size = new System.Drawing.Size(77, 21);
            this.rb_Regular.TabIndex = 38;
            this.rb_Regular.TabStop = true;
            this.rb_Regular.Text = "Regular";
            this.rb_Regular.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(860, 219);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 17);
            this.label13.TabIndex = 62;
            this.label13.Text = "Importe:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(860, 340);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 17);
            this.label11.TabIndex = 64;
            this.label11.Text = "Importe:";
            // 
            // txt_ImpInasistencia
            // 
            this.txt_ImpInasistencia.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ImpInasistencia.Location = new System.Drawing.Point(931, 174);
            this.txt_ImpInasistencia.Name = "txt_ImpInasistencia";
            this.txt_ImpInasistencia.Size = new System.Drawing.Size(120, 24);
            this.txt_ImpInasistencia.TabIndex = 65;
            // 
            // txt_ImportePuntualidad
            // 
            this.txt_ImportePuntualidad.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ImportePuntualidad.Location = new System.Drawing.Point(931, 216);
            this.txt_ImportePuntualidad.Name = "txt_ImportePuntualidad";
            this.txt_ImportePuntualidad.Size = new System.Drawing.Size(120, 24);
            this.txt_ImportePuntualidad.TabIndex = 66;
            // 
            // txt_ImpHoraExtra
            // 
            this.txt_ImpHoraExtra.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ImpHoraExtra.Location = new System.Drawing.Point(931, 337);
            this.txt_ImpHoraExtra.Name = "txt_ImpHoraExtra";
            this.txt_ImpHoraExtra.Size = new System.Drawing.Size(120, 24);
            this.txt_ImpHoraExtra.TabIndex = 68;
            // 
            // cb_SueldoBruto
            // 
            this.cb_SueldoBruto.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_SueldoBruto.FormattingEnabled = true;
            this.cb_SueldoBruto.Location = new System.Drawing.Point(715, 133);
            this.cb_SueldoBruto.Name = "cb_SueldoBruto";
            this.cb_SueldoBruto.Size = new System.Drawing.Size(120, 25);
            this.cb_SueldoBruto.TabIndex = 69;
            // 
            // btn_GuardarSueldo
            // 
            this.btn_GuardarSueldo.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_GuardarSueldo.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_GuardarSueldo.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GuardarSueldo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GuardarSueldo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GuardarSueldo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GuardarSueldo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GuardarSueldo.ForeColor = System.Drawing.Color.White;
            this.btn_GuardarSueldo.Location = new System.Drawing.Point(677, 531);
            this.btn_GuardarSueldo.Name = "btn_GuardarSueldo";
            this.btn_GuardarSueldo.Size = new System.Drawing.Size(88, 38);
            this.btn_GuardarSueldo.TabIndex = 70;
            this.btn_GuardarSueldo.Tag = "40";
            this.btn_GuardarSueldo.Text = "Guardar";
            this.btn_GuardarSueldo.UseVisualStyleBackColor = false;
            // 
            // btn_CancelarSueldo
            // 
            this.btn_CancelarSueldo.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_CancelarSueldo.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_CancelarSueldo.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CancelarSueldo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CancelarSueldo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CancelarSueldo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CancelarSueldo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CancelarSueldo.ForeColor = System.Drawing.Color.White;
            this.btn_CancelarSueldo.Location = new System.Drawing.Point(801, 531);
            this.btn_CancelarSueldo.Name = "btn_CancelarSueldo";
            this.btn_CancelarSueldo.Size = new System.Drawing.Size(88, 38);
            this.btn_CancelarSueldo.TabIndex = 71;
            this.btn_CancelarSueldo.Tag = "41";
            this.btn_CancelarSueldo.Text = "Cancelar";
            this.btn_CancelarSueldo.UseVisualStyleBackColor = false;
            // 
            // txt_Busqueda
            // 
            this.txt_Busqueda.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Busqueda.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txt_Busqueda.Location = new System.Drawing.Point(12, 47);
            this.txt_Busqueda.Name = "txt_Busqueda";
            this.txt_Busqueda.Size = new System.Drawing.Size(523, 24);
            this.txt_Busqueda.TabIndex = 72;
            this.txt_Busqueda.Tag = "44";
            this.txt_Busqueda.Text = "Búsqueda por: Fecha";
            // 
            // cb_Gerente
            // 
            this.cb_Gerente.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Gerente.FormattingEnabled = true;
            this.cb_Gerente.Location = new System.Drawing.Point(715, 379);
            this.cb_Gerente.Name = "cb_Gerente";
            this.cb_Gerente.Size = new System.Drawing.Size(120, 25);
            this.cb_Gerente.TabIndex = 73;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(642, 382);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 17);
            this.label10.TabIndex = 74;
            this.label10.Text = "Gerente:";
            // 
            // btn_CalcularSueldoNeto
            // 
            this.btn_CalcularSueldoNeto.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_CalcularSueldoNeto.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_CalcularSueldoNeto.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CalcularSueldoNeto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CalcularSueldoNeto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CalcularSueldoNeto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CalcularSueldoNeto.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CalcularSueldoNeto.ForeColor = System.Drawing.Color.White;
            this.btn_CalcularSueldoNeto.Location = new System.Drawing.Point(678, 419);
            this.btn_CalcularSueldoNeto.Name = "btn_CalcularSueldoNeto";
            this.btn_CalcularSueldoNeto.Size = new System.Drawing.Size(228, 39);
            this.btn_CalcularSueldoNeto.TabIndex = 75;
            this.btn_CalcularSueldoNeto.Tag = "42";
            this.btn_CalcularSueldoNeto.Text = "Calcular sueldo mensual";
            this.btn_CalcularSueldoNeto.UseVisualStyleBackColor = false;
            // 
            // lbl_Aviso
            // 
            this.lbl_Aviso.AutoSize = true;
            this.lbl_Aviso.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Aviso.ForeColor = System.Drawing.Color.Red;
            this.lbl_Aviso.Location = new System.Drawing.Point(973, 524);
            this.lbl_Aviso.Name = "lbl_Aviso";
            this.lbl_Aviso.Size = new System.Drawing.Size(67, 19);
            this.lbl_Aviso.TabIndex = 76;
            this.lbl_Aviso.Text = "label12";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(12, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(143, 19);
            this.label12.TabIndex = 77;
            this.label12.Text = "Usuario Logeado:";
            // 
            // lbl_UsuarioLog
            // 
            this.lbl_UsuarioLog.AutoSize = true;
            this.lbl_UsuarioLog.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UsuarioLog.ForeColor = System.Drawing.Color.White;
            this.lbl_UsuarioLog.Location = new System.Drawing.Point(153, 9);
            this.lbl_UsuarioLog.Name = "lbl_UsuarioLog";
            this.lbl_UsuarioLog.Size = new System.Drawing.Size(66, 21);
            this.lbl_UsuarioLog.TabIndex = 78;
            this.lbl_UsuarioLog.Text = "label12";
            // 
            // btn_ReporteSueldoNeto
            // 
            this.btn_ReporteSueldoNeto.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_ReporteSueldoNeto.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_ReporteSueldoNeto.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ReporteSueldoNeto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ReporteSueldoNeto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ReporteSueldoNeto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ReporteSueldoNeto.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ReporteSueldoNeto.ForeColor = System.Drawing.Color.White;
            this.btn_ReporteSueldoNeto.Location = new System.Drawing.Point(363, 470);
            this.btn_ReporteSueldoNeto.Name = "btn_ReporteSueldoNeto";
            this.btn_ReporteSueldoNeto.Size = new System.Drawing.Size(88, 38);
            this.btn_ReporteSueldoNeto.TabIndex = 79;
            this.btn_ReporteSueldoNeto.Tag = "102";
            this.btn_ReporteSueldoNeto.Text = "Reporte";
            this.btn_ReporteSueldoNeto.UseVisualStyleBackColor = false;
            this.btn_ReporteSueldoNeto.Click += new System.EventHandler(this.btn_ReporteSueldoNeto_Click);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(12, 31);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(523, 11);
            this.bunifuSeparator1.TabIndex = 80;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // frmDeterminarSueldos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1083, 594);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.btn_ReporteSueldoNeto);
            this.Controls.Add(this.lbl_UsuarioLog);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lbl_Aviso);
            this.Controls.Add(this.btn_CalcularSueldoNeto);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cb_Gerente);
            this.Controls.Add(this.txt_Busqueda);
            this.Controls.Add(this.btn_CancelarSueldo);
            this.Controls.Add(this.btn_GuardarSueldo);
            this.Controls.Add(this.cb_SueldoBruto);
            this.Controls.Add(this.txt_ImpHoraExtra);
            this.Controls.Add(this.txt_ImportePuntualidad);
            this.Controls.Add(this.txt_ImpInasistencia);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_ImporteSueldoNeto);
            this.Controls.Add(this.txt_IdSueldo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cb_Empleado);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dt_FechaSueldo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nud_HorasExtras);
            this.Controls.Add(this.nud_CantidadInasistencias);
            this.Controls.Add(this.rb_Mala);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rb_MuyBuena);
            this.Controls.Add(this.rb_Excelente);
            this.Controls.Add(this.rb_Regular);
            this.Controls.Add(this.btn_BajaSueldo);
            this.Controls.Add(this.btn_NuevoSueldo);
            this.Controls.Add(this.dgv_SueldosNetos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDeterminarSueldos";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Determinar sueldos";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SueldosNetos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_HorasExtras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CantidadInasistencias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_BajaSueldo;
        private System.Windows.Forms.Button btn_NuevoSueldo;
        private System.Windows.Forms.DataGridView dgv_SueldosNetos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_ImporteSueldoNeto;
        private System.Windows.Forms.TextBox txt_IdSueldo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_Empleado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dt_FechaSueldo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nud_HorasExtras;
        private System.Windows.Forms.NumericUpDown nud_CantidadInasistencias;
        private System.Windows.Forms.RadioButton rb_Mala;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rb_MuyBuena;
        private System.Windows.Forms.RadioButton rb_Excelente;
        private System.Windows.Forms.RadioButton rb_Regular;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_ImpInasistencia;
        private System.Windows.Forms.TextBox txt_ImportePuntualidad;
        private System.Windows.Forms.TextBox txt_ImpHoraExtra;
        private System.Windows.Forms.ComboBox cb_SueldoBruto;
        private System.Windows.Forms.Button btn_GuardarSueldo;
        private System.Windows.Forms.Button btn_CancelarSueldo;
        private System.Windows.Forms.TextBox txt_Busqueda;
        private System.Windows.Forms.ComboBox cb_Gerente;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_CalcularSueldoNeto;
        private System.Windows.Forms.Label lbl_Aviso;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl_UsuarioLog;
        private System.Windows.Forms.Button btn_ReporteSueldoNeto;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
    }
}