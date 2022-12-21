namespace Vista
{
    partial class frmIngresoEgreso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIngresoEgreso));
            this.label1 = new System.Windows.Forms.Label();
            this.dt_Fecha = new System.Windows.Forms.DateTimePicker();
            this.rb_Ingreso = new System.Windows.Forms.RadioButton();
            this.rb_Egreso = new System.Windows.Forms.RadioButton();
            this.txt_ExistenciasActuales = new System.Windows.Forms.TextBox();
            this.txt_PrecioVentaActual = new System.Windows.Forms.TextBox();
            this.btn_CalcularPrecioVenta = new System.Windows.Forms.Button();
            this.btn_AceptarMovimiento = new System.Windows.Forms.Button();
            this.txt_PrecioVentaNuevo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Ganancia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_CancelarMovimiento = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Articulo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_PrecioCostoUnitario = new System.Windows.Forms.TextBox();
            this.txt_Cantidad = new System.Windows.Forms.TextBox();
            this.txt_IVA = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txt_Flete = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lbl_Descripcion2 = new System.Windows.Forms.Label();
            this.lbl_Marca2 = new System.Windows.Forms.Label();
            this.lbl_Talle2 = new System.Windows.Forms.Label();
            this.lbl_Existencia2 = new System.Windows.Forms.Label();
            this.lbl_StockMin2 = new System.Windows.Forms.Label();
            this.lbl_StockMax2 = new System.Windows.Forms.Label();
            this.lbl_PrecioCosto2 = new System.Windows.Forms.Label();
            this.lbl_PrecioVenta2 = new System.Windows.Forms.Label();
            this.lbl_PrecioProm2 = new System.Windows.Forms.Label();
            this.lbl_Empleado2 = new System.Windows.Forms.Label();
            this.gb_Articulo2 = new System.Windows.Forms.GroupBox();
            this.lbl_Proveedor2 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lbl_Codigo2 = new System.Windows.Forms.Label();
            this.btn_TerminarMovimiento = new System.Windows.Forms.Button();
            this.btn_CalcularPrecioCosto = new System.Windows.Forms.Button();
            this.txt_PrecioCostoNuevo = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cb_Empleado = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.gb_Articulo2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(115, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha:";
            // 
            // dt_Fecha
            // 
            this.dt_Fecha.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_Fecha.Location = new System.Drawing.Point(178, 100);
            this.dt_Fecha.Name = "dt_Fecha";
            this.dt_Fecha.Size = new System.Drawing.Size(200, 24);
            this.dt_Fecha.TabIndex = 1;
            // 
            // rb_Ingreso
            // 
            this.rb_Ingreso.AutoSize = true;
            this.rb_Ingreso.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Ingreso.ForeColor = System.Drawing.Color.White;
            this.rb_Ingreso.Location = new System.Drawing.Point(178, 137);
            this.rb_Ingreso.Name = "rb_Ingreso";
            this.rb_Ingreso.Size = new System.Drawing.Size(75, 21);
            this.rb_Ingreso.TabIndex = 2;
            this.rb_Ingreso.TabStop = true;
            this.rb_Ingreso.Text = "Ingreso";
            this.rb_Ingreso.UseVisualStyleBackColor = true;
            // 
            // rb_Egreso
            // 
            this.rb_Egreso.AutoSize = true;
            this.rb_Egreso.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Egreso.ForeColor = System.Drawing.Color.White;
            this.rb_Egreso.Location = new System.Drawing.Point(272, 137);
            this.rb_Egreso.Name = "rb_Egreso";
            this.rb_Egreso.Size = new System.Drawing.Size(70, 21);
            this.rb_Egreso.TabIndex = 3;
            this.rb_Egreso.TabStop = true;
            this.rb_Egreso.Text = "Egreso";
            this.rb_Egreso.UseVisualStyleBackColor = true;
            // 
            // txt_ExistenciasActuales
            // 
            this.txt_ExistenciasActuales.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ExistenciasActuales.Location = new System.Drawing.Point(463, 176);
            this.txt_ExistenciasActuales.Name = "txt_ExistenciasActuales";
            this.txt_ExistenciasActuales.Size = new System.Drawing.Size(100, 24);
            this.txt_ExistenciasActuales.TabIndex = 4;
            // 
            // txt_PrecioVentaActual
            // 
            this.txt_PrecioVentaActual.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PrecioVentaActual.Location = new System.Drawing.Point(463, 217);
            this.txt_PrecioVentaActual.Name = "txt_PrecioVentaActual";
            this.txt_PrecioVentaActual.Size = new System.Drawing.Size(100, 24);
            this.txt_PrecioVentaActual.TabIndex = 5;
            // 
            // btn_CalcularPrecioVenta
            // 
            this.btn_CalcularPrecioVenta.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_CalcularPrecioVenta.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_CalcularPrecioVenta.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CalcularPrecioVenta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CalcularPrecioVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CalcularPrecioVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CalcularPrecioVenta.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CalcularPrecioVenta.ForeColor = System.Drawing.Color.White;
            this.btn_CalcularPrecioVenta.Location = new System.Drawing.Point(123, 475);
            this.btn_CalcularPrecioVenta.Name = "btn_CalcularPrecioVenta";
            this.btn_CalcularPrecioVenta.Size = new System.Drawing.Size(201, 36);
            this.btn_CalcularPrecioVenta.TabIndex = 6;
            this.btn_CalcularPrecioVenta.Text = "Calcular precio venta";
            this.btn_CalcularPrecioVenta.UseVisualStyleBackColor = false;
            // 
            // btn_AceptarMovimiento
            // 
            this.btn_AceptarMovimiento.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_AceptarMovimiento.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_AceptarMovimiento.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AceptarMovimiento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AceptarMovimiento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AceptarMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AceptarMovimiento.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AceptarMovimiento.ForeColor = System.Drawing.Color.White;
            this.btn_AceptarMovimiento.Location = new System.Drawing.Point(104, 568);
            this.btn_AceptarMovimiento.Name = "btn_AceptarMovimiento";
            this.btn_AceptarMovimiento.Size = new System.Drawing.Size(87, 35);
            this.btn_AceptarMovimiento.TabIndex = 7;
            this.btn_AceptarMovimiento.Text = "Aceptar";
            this.btn_AceptarMovimiento.UseVisualStyleBackColor = false;
            // 
            // txt_PrecioVentaNuevo
            // 
            this.txt_PrecioVentaNuevo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PrecioVentaNuevo.Location = new System.Drawing.Point(175, 523);
            this.txt_PrecioVentaNuevo.Name = "txt_PrecioVentaNuevo";
            this.txt_PrecioVentaNuevo.Size = new System.Drawing.Size(100, 24);
            this.txt_PrecioVentaNuevo.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(108, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Accion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(309, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Existencias actuales:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(314, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Precio venta actual:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(73, 526);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Precio venta:";
            // 
            // txt_Ganancia
            // 
            this.txt_Ganancia.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Ganancia.Location = new System.Drawing.Point(175, 436);
            this.txt_Ganancia.Name = "txt_Ganancia";
            this.txt_Ganancia.Size = new System.Drawing.Size(100, 24);
            this.txt_Ganancia.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(15, 439);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Porcentaje ganancia:";
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
            this.btn_CancelarMovimiento.Location = new System.Drawing.Point(222, 568);
            this.btn_CancelarMovimiento.Name = "btn_CancelarMovimiento";
            this.btn_CancelarMovimiento.Size = new System.Drawing.Size(87, 35);
            this.btn_CancelarMovimiento.TabIndex = 15;
            this.btn_CancelarMovimiento.Text = "Cancelar";
            this.btn_CancelarMovimiento.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(105, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Articulo:";
            // 
            // txt_Articulo
            // 
            this.txt_Articulo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Articulo.Location = new System.Drawing.Point(178, 16);
            this.txt_Articulo.Name = "txt_Articulo";
            this.txt_Articulo.Size = new System.Drawing.Size(100, 24);
            this.txt_Articulo.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(19, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Precio costo unitario:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(94, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "Cantidad:";
            // 
            // txt_PrecioCostoUnitario
            // 
            this.txt_PrecioCostoUnitario.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PrecioCostoUnitario.Location = new System.Drawing.Point(175, 215);
            this.txt_PrecioCostoUnitario.Name = "txt_PrecioCostoUnitario";
            this.txt_PrecioCostoUnitario.Size = new System.Drawing.Size(100, 24);
            this.txt_PrecioCostoUnitario.TabIndex = 19;
            // 
            // txt_Cantidad
            // 
            this.txt_Cantidad.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Cantidad.Location = new System.Drawing.Point(175, 170);
            this.txt_Cantidad.Name = "txt_Cantidad";
            this.txt_Cantidad.Size = new System.Drawing.Size(100, 24);
            this.txt_Cantidad.TabIndex = 18;
            // 
            // txt_IVA
            // 
            this.txt_IVA.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_IVA.Location = new System.Drawing.Point(175, 351);
            this.txt_IVA.Name = "txt_IVA";
            this.txt_IVA.Size = new System.Drawing.Size(100, 24);
            this.txt_IVA.TabIndex = 23;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(56, 358);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(113, 17);
            this.label21.TabIndex = 24;
            this.label21.Text = "Porcentaje IVA:";
            // 
            // txt_Flete
            // 
            this.txt_Flete.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Flete.Location = new System.Drawing.Point(175, 397);
            this.txt_Flete.Name = "txt_Flete";
            this.txt_Flete.Size = new System.Drawing.Size(100, 24);
            this.txt_Flete.TabIndex = 25;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(50, 400);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(119, 17);
            this.label22.TabIndex = 26;
            this.label22.Text = "Porcentaje flete:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Codigo:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(17, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 17);
            this.label11.TabIndex = 1;
            this.label11.Text = "Descripcion:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(17, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 17);
            this.label12.TabIndex = 2;
            this.label12.Text = "Marca:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(17, 106);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 17);
            this.label13.TabIndex = 3;
            this.label13.Text = "Talle:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(17, 132);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 17);
            this.label14.TabIndex = 4;
            this.label14.Text = "Existencia:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(17, 158);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 17);
            this.label15.TabIndex = 5;
            this.label15.Text = "Stock minimo:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(17, 184);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(110, 17);
            this.label16.TabIndex = 6;
            this.label16.Text = "Stock Maximo:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(17, 210);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 17);
            this.label17.TabIndex = 7;
            this.label17.Text = "Precio costo:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(17, 236);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(96, 17);
            this.label18.TabIndex = 8;
            this.label18.Text = "Precio venta:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(16, 265);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(134, 17);
            this.label19.TabIndex = 9;
            this.label19.Text = "Precio promocion:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(19, 323);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(82, 17);
            this.label20.TabIndex = 10;
            this.label20.Text = "Empleado:";
            // 
            // lbl_Descripcion2
            // 
            this.lbl_Descripcion2.AutoSize = true;
            this.lbl_Descripcion2.Location = new System.Drawing.Point(111, 54);
            this.lbl_Descripcion2.Name = "lbl_Descripcion2";
            this.lbl_Descripcion2.Size = new System.Drawing.Size(93, 19);
            this.lbl_Descripcion2.TabIndex = 13;
            this.lbl_Descripcion2.Text = "Descripcion:";
            // 
            // lbl_Marca2
            // 
            this.lbl_Marca2.AutoSize = true;
            this.lbl_Marca2.Location = new System.Drawing.Point(76, 80);
            this.lbl_Marca2.Name = "lbl_Marca2";
            this.lbl_Marca2.Size = new System.Drawing.Size(59, 19);
            this.lbl_Marca2.TabIndex = 14;
            this.lbl_Marca2.Text = "Marca:";
            // 
            // lbl_Talle2
            // 
            this.lbl_Talle2.AutoSize = true;
            this.lbl_Talle2.Location = new System.Drawing.Point(59, 106);
            this.lbl_Talle2.Name = "lbl_Talle2";
            this.lbl_Talle2.Size = new System.Drawing.Size(43, 19);
            this.lbl_Talle2.TabIndex = 15;
            this.lbl_Talle2.Text = "Talle:";
            // 
            // lbl_Existencia2
            // 
            this.lbl_Existencia2.AutoSize = true;
            this.lbl_Existencia2.Location = new System.Drawing.Point(100, 132);
            this.lbl_Existencia2.Name = "lbl_Existencia2";
            this.lbl_Existencia2.Size = new System.Drawing.Size(81, 19);
            this.lbl_Existencia2.TabIndex = 16;
            this.lbl_Existencia2.Text = "Existencia:";
            // 
            // lbl_StockMin2
            // 
            this.lbl_StockMin2.AutoSize = true;
            this.lbl_StockMin2.Location = new System.Drawing.Point(129, 158);
            this.lbl_StockMin2.Name = "lbl_StockMin2";
            this.lbl_StockMin2.Size = new System.Drawing.Size(104, 19);
            this.lbl_StockMin2.TabIndex = 17;
            this.lbl_StockMin2.Text = "Stock minimo:";
            // 
            // lbl_StockMax2
            // 
            this.lbl_StockMax2.AutoSize = true;
            this.lbl_StockMax2.Location = new System.Drawing.Point(129, 184);
            this.lbl_StockMax2.Name = "lbl_StockMax2";
            this.lbl_StockMax2.Size = new System.Drawing.Size(109, 19);
            this.lbl_StockMax2.TabIndex = 18;
            this.lbl_StockMax2.Text = "Stock Maximo:";
            // 
            // lbl_PrecioCosto2
            // 
            this.lbl_PrecioCosto2.AutoSize = true;
            this.lbl_PrecioCosto2.Location = new System.Drawing.Point(119, 210);
            this.lbl_PrecioCosto2.Name = "lbl_PrecioCosto2";
            this.lbl_PrecioCosto2.Size = new System.Drawing.Size(96, 19);
            this.lbl_PrecioCosto2.TabIndex = 19;
            this.lbl_PrecioCosto2.Text = "Precio costo:";
            // 
            // lbl_PrecioVenta2
            // 
            this.lbl_PrecioVenta2.AutoSize = true;
            this.lbl_PrecioVenta2.Location = new System.Drawing.Point(114, 236);
            this.lbl_PrecioVenta2.Name = "lbl_PrecioVenta2";
            this.lbl_PrecioVenta2.Size = new System.Drawing.Size(100, 19);
            this.lbl_PrecioVenta2.TabIndex = 20;
            this.lbl_PrecioVenta2.Text = "Precio venta:";
            // 
            // lbl_PrecioProm2
            // 
            this.lbl_PrecioProm2.AutoSize = true;
            this.lbl_PrecioProm2.Location = new System.Drawing.Point(154, 265);
            this.lbl_PrecioProm2.Name = "lbl_PrecioProm2";
            this.lbl_PrecioProm2.Size = new System.Drawing.Size(100, 19);
            this.lbl_PrecioProm2.TabIndex = 21;
            this.lbl_PrecioProm2.Text = "Precio promo";
            // 
            // lbl_Empleado2
            // 
            this.lbl_Empleado2.AutoSize = true;
            this.lbl_Empleado2.Location = new System.Drawing.Point(100, 323);
            this.lbl_Empleado2.Name = "lbl_Empleado2";
            this.lbl_Empleado2.Size = new System.Drawing.Size(85, 19);
            this.lbl_Empleado2.TabIndex = 22;
            this.lbl_Empleado2.Text = "Empleado:";
            // 
            // gb_Articulo2
            // 
            this.gb_Articulo2.Controls.Add(this.lbl_Proveedor2);
            this.gb_Articulo2.Controls.Add(this.label23);
            this.gb_Articulo2.Controls.Add(this.lbl_Codigo2);
            this.gb_Articulo2.Controls.Add(this.lbl_Empleado2);
            this.gb_Articulo2.Controls.Add(this.lbl_PrecioProm2);
            this.gb_Articulo2.Controls.Add(this.lbl_PrecioVenta2);
            this.gb_Articulo2.Controls.Add(this.lbl_PrecioCosto2);
            this.gb_Articulo2.Controls.Add(this.lbl_StockMax2);
            this.gb_Articulo2.Controls.Add(this.lbl_StockMin2);
            this.gb_Articulo2.Controls.Add(this.lbl_Existencia2);
            this.gb_Articulo2.Controls.Add(this.lbl_Talle2);
            this.gb_Articulo2.Controls.Add(this.lbl_Marca2);
            this.gb_Articulo2.Controls.Add(this.lbl_Descripcion2);
            this.gb_Articulo2.Controls.Add(this.label20);
            this.gb_Articulo2.Controls.Add(this.label19);
            this.gb_Articulo2.Controls.Add(this.label18);
            this.gb_Articulo2.Controls.Add(this.label17);
            this.gb_Articulo2.Controls.Add(this.label16);
            this.gb_Articulo2.Controls.Add(this.label15);
            this.gb_Articulo2.Controls.Add(this.label14);
            this.gb_Articulo2.Controls.Add(this.label13);
            this.gb_Articulo2.Controls.Add(this.label12);
            this.gb_Articulo2.Controls.Add(this.label11);
            this.gb_Articulo2.Controls.Add(this.label10);
            this.gb_Articulo2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Articulo2.ForeColor = System.Drawing.Color.White;
            this.gb_Articulo2.Location = new System.Drawing.Point(651, 120);
            this.gb_Articulo2.Name = "gb_Articulo2";
            this.gb_Articulo2.Size = new System.Drawing.Size(264, 352);
            this.gb_Articulo2.TabIndex = 22;
            this.gb_Articulo2.TabStop = false;
            this.gb_Articulo2.Text = "Datos del articulo seleccionado";
            // 
            // lbl_Proveedor2
            // 
            this.lbl_Proveedor2.AutoSize = true;
            this.lbl_Proveedor2.Location = new System.Drawing.Point(100, 296);
            this.lbl_Proveedor2.Name = "lbl_Proveedor2";
            this.lbl_Proveedor2.Size = new System.Drawing.Size(83, 19);
            this.lbl_Proveedor2.TabIndex = 25;
            this.lbl_Proveedor2.Text = "Proveedor:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(17, 296);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(80, 17);
            this.label23.TabIndex = 24;
            this.label23.Text = "Proveedor:";
            // 
            // lbl_Codigo2
            // 
            this.lbl_Codigo2.AutoSize = true;
            this.lbl_Codigo2.Location = new System.Drawing.Point(87, 28);
            this.lbl_Codigo2.Name = "lbl_Codigo2";
            this.lbl_Codigo2.Size = new System.Drawing.Size(60, 19);
            this.lbl_Codigo2.TabIndex = 23;
            this.lbl_Codigo2.Text = "label23";
            // 
            // btn_TerminarMovimiento
            // 
            this.btn_TerminarMovimiento.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_TerminarMovimiento.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_TerminarMovimiento.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_TerminarMovimiento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_TerminarMovimiento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_TerminarMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TerminarMovimiento.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TerminarMovimiento.ForeColor = System.Drawing.Color.White;
            this.btn_TerminarMovimiento.Location = new System.Drawing.Point(104, 624);
            this.btn_TerminarMovimiento.Name = "btn_TerminarMovimiento";
            this.btn_TerminarMovimiento.Size = new System.Drawing.Size(201, 36);
            this.btn_TerminarMovimiento.TabIndex = 29;
            this.btn_TerminarMovimiento.Text = "Terminar Movimiento";
            this.btn_TerminarMovimiento.UseVisualStyleBackColor = false;
            // 
            // btn_CalcularPrecioCosto
            // 
            this.btn_CalcularPrecioCosto.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_CalcularPrecioCosto.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_CalcularPrecioCosto.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CalcularPrecioCosto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CalcularPrecioCosto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CalcularPrecioCosto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CalcularPrecioCosto.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CalcularPrecioCosto.ForeColor = System.Drawing.Color.White;
            this.btn_CalcularPrecioCosto.Location = new System.Drawing.Point(104, 261);
            this.btn_CalcularPrecioCosto.Name = "btn_CalcularPrecioCosto";
            this.btn_CalcularPrecioCosto.Size = new System.Drawing.Size(238, 36);
            this.btn_CalcularPrecioCosto.TabIndex = 30;
            this.btn_CalcularPrecioCosto.Text = "Calcular precio de costo nuevo";
            this.btn_CalcularPrecioCosto.UseVisualStyleBackColor = false;
            // 
            // txt_PrecioCostoNuevo
            // 
            this.txt_PrecioCostoNuevo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PrecioCostoNuevo.Location = new System.Drawing.Point(175, 310);
            this.txt_PrecioCostoNuevo.Name = "txt_PrecioCostoNuevo";
            this.txt_PrecioCostoNuevo.Size = new System.Drawing.Size(100, 24);
            this.txt_PrecioCostoNuevo.TabIndex = 31;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(28, 313);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(141, 17);
            this.label24.TabIndex = 32;
            this.label24.Text = "Precio costo nuevo:";
            // 
            // cb_Empleado
            // 
            this.cb_Empleado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Empleado.FormattingEnabled = true;
            this.cb_Empleado.Location = new System.Drawing.Point(178, 60);
            this.cb_Empleado.Name = "cb_Empleado";
            this.cb_Empleado.Size = new System.Drawing.Size(121, 25);
            this.cb_Empleado.TabIndex = 35;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(87, 63);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(82, 17);
            this.label26.TabIndex = 36;
            this.label26.Text = "Empleado:";
            // 
            // frmIngresoEgreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(952, 683);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.cb_Empleado);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.txt_PrecioCostoNuevo);
            this.Controls.Add(this.btn_CalcularPrecioCosto);
            this.Controls.Add(this.btn_TerminarMovimiento);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txt_Flete);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txt_IVA);
            this.Controls.Add(this.gb_Articulo2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_PrecioCostoUnitario);
            this.Controls.Add(this.txt_Cantidad);
            this.Controls.Add(this.txt_Articulo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_CancelarMovimiento);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_Ganancia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_PrecioVentaNuevo);
            this.Controls.Add(this.btn_AceptarMovimiento);
            this.Controls.Add(this.btn_CalcularPrecioVenta);
            this.Controls.Add(this.txt_PrecioVentaActual);
            this.Controls.Add(this.txt_ExistenciasActuales);
            this.Controls.Add(this.rb_Egreso);
            this.Controls.Add(this.rb_Ingreso);
            this.Controls.Add(this.dt_Fecha);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIngresoEgreso";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso/Egreso de artículos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmIngresoEgreso_FormClosed);
            this.gb_Articulo2.ResumeLayout(false);
            this.gb_Articulo2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dt_Fecha;
        private System.Windows.Forms.RadioButton rb_Ingreso;
        private System.Windows.Forms.RadioButton rb_Egreso;
        private System.Windows.Forms.Button btn_CalcularPrecioVenta;
        private System.Windows.Forms.Button btn_AceptarMovimiento;
        private System.Windows.Forms.TextBox txt_PrecioVentaNuevo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Ganancia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_CancelarMovimiento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_Cantidad;
        public System.Windows.Forms.TextBox txt_ExistenciasActuales;
        public System.Windows.Forms.TextBox txt_PrecioVentaActual;
        public System.Windows.Forms.TextBox txt_Articulo;
        public System.Windows.Forms.TextBox txt_PrecioCostoUnitario;
        public System.Windows.Forms.TextBox txt_IVA;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.TextBox txt_Flete;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        public System.Windows.Forms.Label lbl_Descripcion2;
        public System.Windows.Forms.Label lbl_Marca2;
        public System.Windows.Forms.Label lbl_Talle2;
        public System.Windows.Forms.Label lbl_Existencia2;
        public System.Windows.Forms.Label lbl_StockMin2;
        public System.Windows.Forms.Label lbl_StockMax2;
        public System.Windows.Forms.Label lbl_PrecioCosto2;
        public System.Windows.Forms.Label lbl_PrecioVenta2;
        public System.Windows.Forms.Label lbl_PrecioProm2;
        public System.Windows.Forms.Label lbl_Empleado2;
        public System.Windows.Forms.GroupBox gb_Articulo2;
        private System.Windows.Forms.Label lbl_Codigo2;
        private System.Windows.Forms.Button btn_TerminarMovimiento;
        private System.Windows.Forms.Label lbl_Proveedor2;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btn_CalcularPrecioCosto;
        public System.Windows.Forms.TextBox txt_PrecioCostoNuevo;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cb_Empleado;
        private System.Windows.Forms.Label label26;
    }
}