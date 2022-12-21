namespace Vista
{
    partial class frmDefinirStocks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDefinirStocks));
            this.txt_EntregaProv1 = new System.Windows.Forms.TextBox();
            this.txt_ConsumoProm1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_StockMin1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_CalcularStockMin = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_ConsumoProm2 = new System.Windows.Forms.TextBox();
            this.txt_EntregaProv2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_StockMin2 = new System.Windows.Forms.TextBox();
            this.btn_CalcularStockMax = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_StockMax = new System.Windows.Forms.TextBox();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_DefinirConsumo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
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
            this.lbl_Codigo = new System.Windows.Forms.Label();
            this.lbl_Descripcion = new System.Windows.Forms.Label();
            this.lbl_Marca = new System.Windows.Forms.Label();
            this.lbl_Talle = new System.Windows.Forms.Label();
            this.lbl_Existencia = new System.Windows.Forms.Label();
            this.lbl_StockMin = new System.Windows.Forms.Label();
            this.lbl_StockMax = new System.Windows.Forms.Label();
            this.lbl_PrecioCosto = new System.Windows.Forms.Label();
            this.lbl_PrecioVenta = new System.Windows.Forms.Label();
            this.lbl_PrecioProm = new System.Windows.Forms.Label();
            this.lbl_Empleado = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lbl_Proveedor = new System.Windows.Forms.Label();
            this.gb_Articulo = new System.Windows.Forms.GroupBox();
            this.gb_Articulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_EntregaProv1
            // 
            this.txt_EntregaProv1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_EntregaProv1.Location = new System.Drawing.Point(275, 93);
            this.txt_EntregaProv1.Name = "txt_EntregaProv1";
            this.txt_EntregaProv1.Size = new System.Drawing.Size(100, 24);
            this.txt_EntregaProv1.TabIndex = 0;
            // 
            // txt_ConsumoProm1
            // 
            this.txt_ConsumoProm1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ConsumoProm1.Location = new System.Drawing.Point(275, 129);
            this.txt_ConsumoProm1.Name = "txt_ConsumoProm1";
            this.txt_ConsumoProm1.Size = new System.Drawing.Size(100, 24);
            this.txt_ConsumoProm1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tiempo de entrega del proveedor (días):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(261, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Consumo promedio diario del articulo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(132, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Stock Mínimo:";
            // 
            // txt_StockMin1
            // 
            this.txt_StockMin1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_StockMin1.Location = new System.Drawing.Point(164, 230);
            this.txt_StockMin1.Name = "txt_StockMin1";
            this.txt_StockMin1.Size = new System.Drawing.Size(100, 24);
            this.txt_StockMin1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(59, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Stock mínimo:";
            // 
            // btn_CalcularStockMin
            // 
            this.btn_CalcularStockMin.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_CalcularStockMin.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_CalcularStockMin.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CalcularStockMin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CalcularStockMin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CalcularStockMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CalcularStockMin.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CalcularStockMin.ForeColor = System.Drawing.Color.White;
            this.btn_CalcularStockMin.Location = new System.Drawing.Point(96, 174);
            this.btn_CalcularStockMin.Name = "btn_CalcularStockMin";
            this.btn_CalcularStockMin.Size = new System.Drawing.Size(183, 32);
            this.btn_CalcularStockMin.TabIndex = 7;
            this.btn_CalcularStockMin.Text = "Calcular stock mínimo";
            this.btn_CalcularStockMin.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(475, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(272, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tiempo de entrega del proveedor (días):";
            // 
            // txt_ConsumoProm2
            // 
            this.txt_ConsumoProm2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ConsumoProm2.Location = new System.Drawing.Point(747, 137);
            this.txt_ConsumoProm2.Name = "txt_ConsumoProm2";
            this.txt_ConsumoProm2.Size = new System.Drawing.Size(100, 24);
            this.txt_ConsumoProm2.TabIndex = 11;
            // 
            // txt_EntregaProv2
            // 
            this.txt_EntregaProv2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_EntregaProv2.Location = new System.Drawing.Point(747, 93);
            this.txt_EntregaProv2.Name = "txt_EntregaProv2";
            this.txt_EntregaProv2.Size = new System.Drawing.Size(100, 24);
            this.txt_EntregaProv2.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(649, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Stock mínimo:";
            // 
            // txt_StockMin2
            // 
            this.txt_StockMin2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_StockMin2.Location = new System.Drawing.Point(747, 180);
            this.txt_StockMin2.Name = "txt_StockMin2";
            this.txt_StockMin2.Size = new System.Drawing.Size(100, 24);
            this.txt_StockMin2.TabIndex = 14;
            // 
            // btn_CalcularStockMax
            // 
            this.btn_CalcularStockMax.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_CalcularStockMax.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_CalcularStockMax.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CalcularStockMax.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CalcularStockMax.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CalcularStockMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CalcularStockMax.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CalcularStockMax.ForeColor = System.Drawing.Color.White;
            this.btn_CalcularStockMax.Location = new System.Drawing.Point(617, 232);
            this.btn_CalcularStockMax.Name = "btn_CalcularStockMax";
            this.btn_CalcularStockMax.Size = new System.Drawing.Size(183, 32);
            this.btn_CalcularStockMax.TabIndex = 16;
            this.btn_CalcularStockMax.Text = "Calcular stock máximo";
            this.btn_CalcularStockMax.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(573, 290);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "Stock máximo:";
            // 
            // txt_StockMax
            // 
            this.txt_StockMax.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_StockMax.Location = new System.Drawing.Point(685, 287);
            this.txt_StockMax.Name = "txt_StockMax";
            this.txt_StockMax.Size = new System.Drawing.Size(100, 24);
            this.txt_StockMax.TabIndex = 17;
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
            this.btn_Cancelar.Location = new System.Drawing.Point(483, 361);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(94, 36);
            this.btn_Cancelar.TabIndex = 20;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = false;
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_Guardar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Guardar.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_Guardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_Guardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Guardar.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Guardar.ForeColor = System.Drawing.Color.White;
            this.btn_Guardar.Location = new System.Drawing.Point(364, 361);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(94, 36);
            this.btn_Guardar.TabIndex = 19;
            this.btn_Guardar.Text = "Guardar";
            this.btn_Guardar.UseVisualStyleBackColor = false;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(616, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 19);
            this.label9.TabIndex = 21;
            this.label9.Text = "Stock Máximo:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(486, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(261, 16);
            this.label10.TabIndex = 23;
            this.label10.Text = "Consumo promedio diario del articulo:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(467, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 287);
            this.panel1.TabIndex = 25;
            // 
            // btn_DefinirConsumo
            // 
            this.btn_DefinirConsumo.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_DefinirConsumo.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_DefinirConsumo.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_DefinirConsumo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_DefinirConsumo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_DefinirConsumo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DefinirConsumo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DefinirConsumo.ForeColor = System.Drawing.Color.White;
            this.btn_DefinirConsumo.Location = new System.Drawing.Point(380, 126);
            this.btn_DefinirConsumo.Name = "btn_DefinirConsumo";
            this.btn_DefinirConsumo.Size = new System.Drawing.Size(84, 32);
            this.btn_DefinirConsumo.TabIndex = 26;
            this.btn_DefinirConsumo.Text = "Definir";
            this.btn_DefinirConsumo.UseVisualStyleBackColor = false;
            this.btn_DefinirConsumo.Click += new System.EventHandler(this.btn_DefinirConsumo_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Codigo:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 17);
            this.label11.TabIndex = 1;
            this.label11.Text = "Descripcion:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 83);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 17);
            this.label12.TabIndex = 2;
            this.label12.Text = "Marca:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 110);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 17);
            this.label13.TabIndex = 3;
            this.label13.Text = "Talle:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 137);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 17);
            this.label14.TabIndex = 4;
            this.label14.Text = "Existencia:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 164);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 17);
            this.label15.TabIndex = 5;
            this.label15.Text = "Stock minimo:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(17, 191);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(102, 17);
            this.label16.TabIndex = 6;
            this.label16.Text = "Stock Maximo:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(17, 218);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(92, 17);
            this.label17.TabIndex = 7;
            this.label17.Text = "Precio costo:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(17, 245);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(94, 17);
            this.label18.TabIndex = 8;
            this.label18.Text = "Precio venta:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(16, 272);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(128, 17);
            this.label19.TabIndex = 9;
            this.label19.Text = "Precio promocion:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(17, 326);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(79, 17);
            this.label20.TabIndex = 10;
            this.label20.Text = "Empleado:";
            // 
            // lbl_Codigo
            // 
            this.lbl_Codigo.AutoSize = true;
            this.lbl_Codigo.Location = new System.Drawing.Point(85, 29);
            this.lbl_Codigo.Name = "lbl_Codigo";
            this.lbl_Codigo.Size = new System.Drawing.Size(62, 17);
            this.lbl_Codigo.TabIndex = 11;
            this.lbl_Codigo.Text = "Codigo:";
            // 
            // lbl_Descripcion
            // 
            this.lbl_Descripcion.AutoSize = true;
            this.lbl_Descripcion.Location = new System.Drawing.Point(105, 56);
            this.lbl_Descripcion.Name = "lbl_Descripcion";
            this.lbl_Descripcion.Size = new System.Drawing.Size(87, 17);
            this.lbl_Descripcion.TabIndex = 13;
            this.lbl_Descripcion.Text = "Descripcion:";
            // 
            // lbl_Marca
            // 
            this.lbl_Marca.AutoSize = true;
            this.lbl_Marca.Location = new System.Drawing.Point(76, 83);
            this.lbl_Marca.Name = "lbl_Marca";
            this.lbl_Marca.Size = new System.Drawing.Size(53, 17);
            this.lbl_Marca.TabIndex = 14;
            this.lbl_Marca.Text = "Marca:";
            // 
            // lbl_Talle
            // 
            this.lbl_Talle.AutoSize = true;
            this.lbl_Talle.Location = new System.Drawing.Point(63, 110);
            this.lbl_Talle.Name = "lbl_Talle";
            this.lbl_Talle.Size = new System.Drawing.Size(40, 17);
            this.lbl_Talle.TabIndex = 15;
            this.lbl_Talle.Text = "Talle:";
            // 
            // lbl_Existencia
            // 
            this.lbl_Existencia.AutoSize = true;
            this.lbl_Existencia.Location = new System.Drawing.Point(97, 137);
            this.lbl_Existencia.Name = "lbl_Existencia";
            this.lbl_Existencia.Size = new System.Drawing.Size(74, 17);
            this.lbl_Existencia.TabIndex = 16;
            this.lbl_Existencia.Text = "Existencia:";
            // 
            // lbl_StockMin
            // 
            this.lbl_StockMin.AutoSize = true;
            this.lbl_StockMin.Location = new System.Drawing.Point(114, 164);
            this.lbl_StockMin.Name = "lbl_StockMin";
            this.lbl_StockMin.Size = new System.Drawing.Size(100, 17);
            this.lbl_StockMin.TabIndex = 17;
            this.lbl_StockMin.Text = "Stock minimo:";
            // 
            // lbl_StockMax
            // 
            this.lbl_StockMax.AutoSize = true;
            this.lbl_StockMax.Location = new System.Drawing.Point(116, 191);
            this.lbl_StockMax.Name = "lbl_StockMax";
            this.lbl_StockMax.Size = new System.Drawing.Size(102, 17);
            this.lbl_StockMax.TabIndex = 18;
            this.lbl_StockMax.Text = "Stock Maximo:";
            // 
            // lbl_PrecioCosto
            // 
            this.lbl_PrecioCosto.AutoSize = true;
            this.lbl_PrecioCosto.Location = new System.Drawing.Point(114, 218);
            this.lbl_PrecioCosto.Name = "lbl_PrecioCosto";
            this.lbl_PrecioCosto.Size = new System.Drawing.Size(92, 17);
            this.lbl_PrecioCosto.TabIndex = 19;
            this.lbl_PrecioCosto.Text = "Precio costo:";
            // 
            // lbl_PrecioVenta
            // 
            this.lbl_PrecioVenta.AutoSize = true;
            this.lbl_PrecioVenta.Location = new System.Drawing.Point(116, 245);
            this.lbl_PrecioVenta.Name = "lbl_PrecioVenta";
            this.lbl_PrecioVenta.Size = new System.Drawing.Size(94, 17);
            this.lbl_PrecioVenta.TabIndex = 20;
            this.lbl_PrecioVenta.Text = "Precio venta:";
            // 
            // lbl_PrecioProm
            // 
            this.lbl_PrecioProm.AutoSize = true;
            this.lbl_PrecioProm.Location = new System.Drawing.Point(150, 272);
            this.lbl_PrecioProm.Name = "lbl_PrecioProm";
            this.lbl_PrecioProm.Size = new System.Drawing.Size(96, 17);
            this.lbl_PrecioProm.TabIndex = 21;
            this.lbl_PrecioProm.Text = "Precio promo";
            // 
            // lbl_Empleado
            // 
            this.lbl_Empleado.AutoSize = true;
            this.lbl_Empleado.Location = new System.Drawing.Point(97, 326);
            this.lbl_Empleado.Name = "lbl_Empleado";
            this.lbl_Empleado.Size = new System.Drawing.Size(79, 17);
            this.lbl_Empleado.TabIndex = 22;
            this.lbl_Empleado.Text = "Empleado:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(17, 299);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(79, 17);
            this.label21.TabIndex = 23;
            this.label21.Text = "Proveedor:";
            // 
            // lbl_Proveedor
            // 
            this.lbl_Proveedor.AutoSize = true;
            this.lbl_Proveedor.Location = new System.Drawing.Point(102, 299);
            this.lbl_Proveedor.Name = "lbl_Proveedor";
            this.lbl_Proveedor.Size = new System.Drawing.Size(75, 17);
            this.lbl_Proveedor.TabIndex = 24;
            this.lbl_Proveedor.Text = "Proveedor";
            // 
            // gb_Articulo
            // 
            this.gb_Articulo.Controls.Add(this.lbl_Proveedor);
            this.gb_Articulo.Controls.Add(this.label21);
            this.gb_Articulo.Controls.Add(this.lbl_Empleado);
            this.gb_Articulo.Controls.Add(this.lbl_PrecioProm);
            this.gb_Articulo.Controls.Add(this.lbl_PrecioVenta);
            this.gb_Articulo.Controls.Add(this.lbl_PrecioCosto);
            this.gb_Articulo.Controls.Add(this.lbl_StockMax);
            this.gb_Articulo.Controls.Add(this.lbl_StockMin);
            this.gb_Articulo.Controls.Add(this.lbl_Existencia);
            this.gb_Articulo.Controls.Add(this.lbl_Talle);
            this.gb_Articulo.Controls.Add(this.lbl_Marca);
            this.gb_Articulo.Controls.Add(this.lbl_Descripcion);
            this.gb_Articulo.Controls.Add(this.lbl_Codigo);
            this.gb_Articulo.Controls.Add(this.label20);
            this.gb_Articulo.Controls.Add(this.label19);
            this.gb_Articulo.Controls.Add(this.label18);
            this.gb_Articulo.Controls.Add(this.label17);
            this.gb_Articulo.Controls.Add(this.label16);
            this.gb_Articulo.Controls.Add(this.label15);
            this.gb_Articulo.Controls.Add(this.label14);
            this.gb_Articulo.Controls.Add(this.label13);
            this.gb_Articulo.Controls.Add(this.label12);
            this.gb_Articulo.Controls.Add(this.label11);
            this.gb_Articulo.Controls.Add(this.label5);
            this.gb_Articulo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Articulo.ForeColor = System.Drawing.Color.White;
            this.gb_Articulo.Location = new System.Drawing.Point(864, 26);
            this.gb_Articulo.Name = "gb_Articulo";
            this.gb_Articulo.Size = new System.Drawing.Size(264, 361);
            this.gb_Articulo.TabIndex = 24;
            this.gb_Articulo.TabStop = false;
            this.gb_Articulo.Text = "Datos del articulo seleccionado";
            // 
            // frmDefinirStocks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1144, 409);
            this.Controls.Add(this.btn_DefinirConsumo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_StockMax);
            this.Controls.Add(this.btn_CalcularStockMax);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_StockMin2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_ConsumoProm2);
            this.Controls.Add(this.txt_EntregaProv2);
            this.Controls.Add(this.btn_CalcularStockMin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_StockMin1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ConsumoProm1);
            this.Controls.Add(this.txt_EntregaProv1);
            this.Controls.Add(this.gb_Articulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDefinirStocks";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Definir stocks";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDefinirStocks_FormClosed);
            this.gb_Articulo.ResumeLayout(false);
            this.gb_Articulo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_EntregaProv1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_StockMin1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_CalcularStockMin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_ConsumoProm2;
        private System.Windows.Forms.TextBox txt_EntregaProv2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_StockMin2;
        private System.Windows.Forms.Button btn_CalcularStockMax;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_StockMax;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_DefinirConsumo;
        public System.Windows.Forms.TextBox txt_ConsumoProm1;
        private System.Windows.Forms.Label label5;
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
        public System.Windows.Forms.Label lbl_Codigo;
        public System.Windows.Forms.Label lbl_Descripcion;
        public System.Windows.Forms.Label lbl_Marca;
        public System.Windows.Forms.Label lbl_Talle;
        public System.Windows.Forms.Label lbl_Existencia;
        public System.Windows.Forms.Label lbl_StockMin;
        public System.Windows.Forms.Label lbl_StockMax;
        public System.Windows.Forms.Label lbl_PrecioCosto;
        public System.Windows.Forms.Label lbl_PrecioVenta;
        public System.Windows.Forms.Label lbl_PrecioProm;
        public System.Windows.Forms.Label lbl_Empleado;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.Label lbl_Proveedor;
        public System.Windows.Forms.GroupBox gb_Articulo;
    }
}