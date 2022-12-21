namespace Vista
{
    partial class frmMovimiento
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_PrecioVenta = new System.Windows.Forms.TextBox();
            this.txt_PrecioCosto = new System.Windows.Forms.TextBox();
            this.txt_Cantidad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_GuardarMovimiento = new System.Windows.Forms.Button();
            this.dgv_Movimientos = new System.Windows.Forms.DataGridView();
            this.dt_Fecha = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cb_Articulo = new System.Windows.Forms.ComboBox();
            this.cb_Empleado = new System.Windows.Forms.ComboBox();
            this.btn_CancelarMovimiento = new System.Windows.Forms.Button();
            this.cb_Accion = new System.Windows.Forms.ComboBox();
            this.btn_AltaMovimiento = new System.Windows.Forms.Button();
            this.btn_ModMovimiento = new System.Windows.Forms.Button();
            this.btn_BajaMovimiento = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_IdMovimiento = new System.Windows.Forms.TextBox();
            this.txt_Busqueda = new System.Windows.Forms.TextBox();
            this.btn_ReporteMovimiento = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_UsuarioLog = new System.Windows.Forms.Label();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Movimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(802, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 17);
            this.label5.TabIndex = 43;
            this.label5.Text = "Precio costo calculado:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(790, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 17);
            this.label4.TabIndex = 42;
            this.label4.Text = "Cantidad en movimiento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(911, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 41;
            this.label3.Text = "Accion:";
            // 
            // txt_PrecioVenta
            // 
            this.txt_PrecioVenta.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PrecioVenta.Location = new System.Drawing.Point(978, 381);
            this.txt_PrecioVenta.Name = "txt_PrecioVenta";
            this.txt_PrecioVenta.Size = new System.Drawing.Size(100, 23);
            this.txt_PrecioVenta.TabIndex = 40;
            // 
            // txt_PrecioCosto
            // 
            this.txt_PrecioCosto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PrecioCosto.Location = new System.Drawing.Point(980, 333);
            this.txt_PrecioCosto.Name = "txt_PrecioCosto";
            this.txt_PrecioCosto.Size = new System.Drawing.Size(100, 23);
            this.txt_PrecioCosto.TabIndex = 35;
            // 
            // txt_Cantidad
            // 
            this.txt_Cantidad.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Cantidad.Location = new System.Drawing.Point(980, 283);
            this.txt_Cantidad.Name = "txt_Cantidad";
            this.txt_Cantidad.Size = new System.Drawing.Size(100, 23);
            this.txt_Cantidad.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(908, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "Articulo:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(890, 430);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 17);
            this.label12.TabIndex = 59;
            this.label12.Text = "Empleado:";
            // 
            // btn_GuardarMovimiento
            // 
            this.btn_GuardarMovimiento.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_GuardarMovimiento.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_GuardarMovimiento.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GuardarMovimiento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GuardarMovimiento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GuardarMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GuardarMovimiento.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GuardarMovimiento.ForeColor = System.Drawing.Color.White;
            this.btn_GuardarMovimiento.Location = new System.Drawing.Point(914, 491);
            this.btn_GuardarMovimiento.Name = "btn_GuardarMovimiento";
            this.btn_GuardarMovimiento.Size = new System.Drawing.Size(91, 36);
            this.btn_GuardarMovimiento.TabIndex = 62;
            this.btn_GuardarMovimiento.Tag = "107";
            this.btn_GuardarMovimiento.Text = "Guardar";
            this.btn_GuardarMovimiento.UseVisualStyleBackColor = false;
            // 
            // dgv_Movimientos
            // 
            this.dgv_Movimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Movimientos.Location = new System.Drawing.Point(27, 93);
            this.dgv_Movimientos.Name = "dgv_Movimientos";
            this.dgv_Movimientos.Size = new System.Drawing.Size(696, 406);
            this.dgv_Movimientos.TabIndex = 64;
            this.dgv_Movimientos.Tag = "109";
            // 
            // dt_Fecha
            // 
            this.dt_Fecha.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_Fecha.Location = new System.Drawing.Point(980, 190);
            this.dt_Fecha.Name = "dt_Fecha";
            this.dt_Fecha.Size = new System.Drawing.Size(200, 23);
            this.dt_Fecha.TabIndex = 65;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(918, 193);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 17);
            this.label14.TabIndex = 66;
            this.label14.Text = "Fecha:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(780, 384);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(192, 17);
            this.label15.TabIndex = 67;
            this.label15.Text = "Precio de venta calculado:";
            // 
            // cb_Articulo
            // 
            this.cb_Articulo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Articulo.FormattingEnabled = true;
            this.cb_Articulo.Location = new System.Drawing.Point(980, 137);
            this.cb_Articulo.Name = "cb_Articulo";
            this.cb_Articulo.Size = new System.Drawing.Size(121, 25);
            this.cb_Articulo.TabIndex = 68;
            // 
            // cb_Empleado
            // 
            this.cb_Empleado.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Empleado.FormattingEnabled = true;
            this.cb_Empleado.Location = new System.Drawing.Point(978, 427);
            this.cb_Empleado.Name = "cb_Empleado";
            this.cb_Empleado.Size = new System.Drawing.Size(121, 25);
            this.cb_Empleado.TabIndex = 69;
            // 
            // btn_CancelarMovimiento
            // 
            this.btn_CancelarMovimiento.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_CancelarMovimiento.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_CancelarMovimiento.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CancelarMovimiento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CancelarMovimiento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CancelarMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CancelarMovimiento.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CancelarMovimiento.ForeColor = System.Drawing.Color.White;
            this.btn_CancelarMovimiento.Location = new System.Drawing.Point(1039, 491);
            this.btn_CancelarMovimiento.Name = "btn_CancelarMovimiento";
            this.btn_CancelarMovimiento.Size = new System.Drawing.Size(91, 36);
            this.btn_CancelarMovimiento.TabIndex = 70;
            this.btn_CancelarMovimiento.Tag = "108";
            this.btn_CancelarMovimiento.Text = "Cancelar";
            this.btn_CancelarMovimiento.UseVisualStyleBackColor = false;
            // 
            // cb_Accion
            // 
            this.cb_Accion.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Accion.FormattingEnabled = true;
            this.cb_Accion.Items.AddRange(new object[] {
            "Ingreso",
            "Egreso"});
            this.cb_Accion.Location = new System.Drawing.Point(980, 237);
            this.cb_Accion.Name = "cb_Accion";
            this.cb_Accion.Size = new System.Drawing.Size(121, 25);
            this.cb_Accion.TabIndex = 71;
            // 
            // btn_AltaMovimiento
            // 
            this.btn_AltaMovimiento.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_AltaMovimiento.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_AltaMovimiento.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AltaMovimiento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AltaMovimiento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AltaMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AltaMovimiento.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AltaMovimiento.ForeColor = System.Drawing.Color.White;
            this.btn_AltaMovimiento.Location = new System.Drawing.Point(59, 521);
            this.btn_AltaMovimiento.Name = "btn_AltaMovimiento";
            this.btn_AltaMovimiento.Size = new System.Drawing.Size(91, 36);
            this.btn_AltaMovimiento.TabIndex = 72;
            this.btn_AltaMovimiento.Tag = "104";
            this.btn_AltaMovimiento.Text = "Alta";
            this.btn_AltaMovimiento.UseVisualStyleBackColor = false;
            // 
            // btn_ModMovimiento
            // 
            this.btn_ModMovimiento.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_ModMovimiento.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_ModMovimiento.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ModMovimiento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ModMovimiento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ModMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ModMovimiento.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ModMovimiento.ForeColor = System.Drawing.Color.White;
            this.btn_ModMovimiento.Location = new System.Drawing.Point(221, 521);
            this.btn_ModMovimiento.Name = "btn_ModMovimiento";
            this.btn_ModMovimiento.Size = new System.Drawing.Size(91, 36);
            this.btn_ModMovimiento.TabIndex = 73;
            this.btn_ModMovimiento.Tag = "106";
            this.btn_ModMovimiento.Text = "Modificar";
            this.btn_ModMovimiento.UseVisualStyleBackColor = false;
            // 
            // btn_BajaMovimiento
            // 
            this.btn_BajaMovimiento.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_BajaMovimiento.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_BajaMovimiento.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaMovimiento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaMovimiento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BajaMovimiento.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BajaMovimiento.ForeColor = System.Drawing.Color.White;
            this.btn_BajaMovimiento.Location = new System.Drawing.Point(383, 521);
            this.btn_BajaMovimiento.Name = "btn_BajaMovimiento";
            this.btn_BajaMovimiento.Size = new System.Drawing.Size(91, 36);
            this.btn_BajaMovimiento.TabIndex = 74;
            this.btn_BajaMovimiento.Tag = "105";
            this.btn_BajaMovimiento.Text = "Baja";
            this.btn_BajaMovimiento.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(947, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 17);
            this.label2.TabIndex = 75;
            this.label2.Text = "Id:";
            // 
            // txt_IdMovimiento
            // 
            this.txt_IdMovimiento.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_IdMovimiento.Location = new System.Drawing.Point(980, 94);
            this.txt_IdMovimiento.Name = "txt_IdMovimiento";
            this.txt_IdMovimiento.Size = new System.Drawing.Size(100, 23);
            this.txt_IdMovimiento.TabIndex = 76;
            // 
            // txt_Busqueda
            // 
            this.txt_Busqueda.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Busqueda.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txt_Busqueda.Location = new System.Drawing.Point(27, 61);
            this.txt_Busqueda.Name = "txt_Busqueda";
            this.txt_Busqueda.Size = new System.Drawing.Size(696, 24);
            this.txt_Busqueda.TabIndex = 77;
            this.txt_Busqueda.Tag = "110";
            this.txt_Busqueda.Text = "Búsqueda por: Fecha";
            // 
            // btn_ReporteMovimiento
            // 
            this.btn_ReporteMovimiento.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_ReporteMovimiento.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_ReporteMovimiento.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ReporteMovimiento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ReporteMovimiento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ReporteMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ReporteMovimiento.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ReporteMovimiento.ForeColor = System.Drawing.Color.White;
            this.btn_ReporteMovimiento.Location = new System.Drawing.Point(545, 521);
            this.btn_ReporteMovimiento.Name = "btn_ReporteMovimiento";
            this.btn_ReporteMovimiento.Size = new System.Drawing.Size(135, 36);
            this.btn_ReporteMovimiento.TabIndex = 78;
            this.btn_ReporteMovimiento.Tag = "111";
            this.btn_ReporteMovimiento.Text = "Generar Reporte";
            this.btn_ReporteMovimiento.UseVisualStyleBackColor = false;
            this.btn_ReporteMovimiento.Click += new System.EventHandler(this.btn_ReporteMovimiento_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(27, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 19);
            this.label6.TabIndex = 79;
            this.label6.Text = "Usuario Logeado:";
            // 
            // lbl_UsuarioLog
            // 
            this.lbl_UsuarioLog.AutoSize = true;
            this.lbl_UsuarioLog.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UsuarioLog.ForeColor = System.Drawing.Color.White;
            this.lbl_UsuarioLog.Location = new System.Drawing.Point(172, 16);
            this.lbl_UsuarioLog.Name = "lbl_UsuarioLog";
            this.lbl_UsuarioLog.Size = new System.Drawing.Size(57, 21);
            this.lbl_UsuarioLog.TabIndex = 80;
            this.lbl_UsuarioLog.Text = "label7";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(30, 40);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(693, 17);
            this.bunifuSeparator1.TabIndex = 81;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // frmMovimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1192, 585);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.lbl_UsuarioLog);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_ReporteMovimiento);
            this.Controls.Add(this.txt_Busqueda);
            this.Controls.Add(this.txt_IdMovimiento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_BajaMovimiento);
            this.Controls.Add(this.btn_ModMovimiento);
            this.Controls.Add(this.btn_AltaMovimiento);
            this.Controls.Add(this.cb_Accion);
            this.Controls.Add(this.btn_CancelarMovimiento);
            this.Controls.Add(this.cb_Empleado);
            this.Controls.Add(this.cb_Articulo);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dt_Fecha);
            this.Controls.Add(this.dgv_Movimientos);
            this.Controls.Add(this.btn_GuardarMovimiento);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_PrecioVenta);
            this.Controls.Add(this.txt_PrecioCosto);
            this.Controls.Add(this.txt_Cantidad);
            this.Controls.Add(this.label1);
            this.Name = "frmMovimiento";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimientos";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Movimientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txt_PrecioVenta;
        public System.Windows.Forms.TextBox txt_PrecioCosto;
        public System.Windows.Forms.TextBox txt_Cantidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_GuardarMovimiento;
        private System.Windows.Forms.DataGridView dgv_Movimientos;
        private System.Windows.Forms.DateTimePicker dt_Fecha;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cb_Articulo;
        private System.Windows.Forms.ComboBox cb_Empleado;
        private System.Windows.Forms.Button btn_CancelarMovimiento;
        private System.Windows.Forms.ComboBox cb_Accion;
        private System.Windows.Forms.Button btn_AltaMovimiento;
        private System.Windows.Forms.Button btn_ModMovimiento;
        private System.Windows.Forms.Button btn_BajaMovimiento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_IdMovimiento;
        private System.Windows.Forms.TextBox txt_Busqueda;
        private System.Windows.Forms.Button btn_ReporteMovimiento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_UsuarioLog;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
    }
}