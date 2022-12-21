namespace Vista
{
    partial class frmAdmInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdmInventario));
            this.btn_AltaArticulo = new System.Windows.Forms.Button();
            this.btn_ModArticulo = new System.Windows.Forms.Button();
            this.btn_BajaArticulo = new System.Windows.Forms.Button();
            this.btn_DefinirStocks = new System.Windows.Forms.Button();
            this.btn_IngresoEgreso = new System.Windows.Forms.Button();
            this.btn_TipoUbicacion = new System.Windows.Forms.Button();
            this.txt_TalleArt = new System.Windows.Forms.TextBox();
            this.lbl_CampoObligatorio = new System.Windows.Forms.Label();
            this.btn_CancelarArticulo = new System.Windows.Forms.Button();
            this.btn_GuardarArticulo = new System.Windows.Forms.Button();
            this.lbl_Empleado = new System.Windows.Forms.Label();
            this.lbl_Observacion = new System.Windows.Forms.Label();
            this.lbl_PrecioProm = new System.Windows.Forms.Label();
            this.lbl_PrecioVenta = new System.Windows.Forms.Label();
            this.lbl_PrecioCosto = new System.Windows.Forms.Label();
            this.lbl_StockMax = new System.Windows.Forms.Label();
            this.lbl_StockMin = new System.Windows.Forms.Label();
            this.lbl_Existencia = new System.Windows.Forms.Label();
            this.lbl_Talle = new System.Windows.Forms.Label();
            this.lbl_Marca = new System.Windows.Forms.Label();
            this.txt_ObservacionArt = new System.Windows.Forms.TextBox();
            this.cb_Empleado = new System.Windows.Forms.ComboBox();
            this.txt_PrecioPromArt = new System.Windows.Forms.TextBox();
            this.txt_PrecioVentaArt = new System.Windows.Forms.TextBox();
            this.txt_PrecioCostoArt = new System.Windows.Forms.TextBox();
            this.txt_StockMaxArt = new System.Windows.Forms.TextBox();
            this.txt_StockMinArt = new System.Windows.Forms.TextBox();
            this.txt_ExistenciaArt = new System.Windows.Forms.TextBox();
            this.cb_Marcas = new System.Windows.Forms.ComboBox();
            this.txt_DescripcionArt = new System.Windows.Forms.TextBox();
            this.lbl_Descripcion = new System.Windows.Forms.Label();
            this.lbl_Codigo = new System.Windows.Forms.Label();
            this.txt_CodigoArt = new System.Windows.Forms.TextBox();
            this.txt_Busqueda = new System.Windows.Forms.TextBox();
            this.btn_IncPrecioVenta = new System.Windows.Forms.Button();
            this.btn_RedPrecioVenta = new System.Windows.Forms.Button();
            this.lbl_Proveedor = new System.Windows.Forms.Label();
            this.cb_Proveedores = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.lbl_UsuarioLog = new System.Windows.Forms.Label();
            this.btn_ReporteArticulo = new System.Windows.Forms.Button();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.btn_RegistrarMovimiento = new System.Windows.Forms.Button();
            this.dgv_Articulos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Articulos)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_AltaArticulo
            // 
            this.btn_AltaArticulo.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_AltaArticulo.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_AltaArticulo.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AltaArticulo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AltaArticulo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_AltaArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AltaArticulo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AltaArticulo.ForeColor = System.Drawing.Color.White;
            this.btn_AltaArticulo.Location = new System.Drawing.Point(105, 581);
            this.btn_AltaArticulo.Name = "btn_AltaArticulo";
            this.btn_AltaArticulo.Size = new System.Drawing.Size(85, 41);
            this.btn_AltaArticulo.TabIndex = 26;
            this.btn_AltaArticulo.Tag = "63";
            this.btn_AltaArticulo.Text = "Alta";
            this.btn_AltaArticulo.UseVisualStyleBackColor = false;
            // 
            // btn_ModArticulo
            // 
            this.btn_ModArticulo.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_ModArticulo.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_ModArticulo.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ModArticulo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ModArticulo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ModArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ModArticulo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ModArticulo.ForeColor = System.Drawing.Color.White;
            this.btn_ModArticulo.Location = new System.Drawing.Point(244, 581);
            this.btn_ModArticulo.Name = "btn_ModArticulo";
            this.btn_ModArticulo.Size = new System.Drawing.Size(85, 41);
            this.btn_ModArticulo.TabIndex = 27;
            this.btn_ModArticulo.Tag = "65";
            this.btn_ModArticulo.Text = "Modificar";
            this.btn_ModArticulo.UseVisualStyleBackColor = false;
            // 
            // btn_BajaArticulo
            // 
            this.btn_BajaArticulo.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_BajaArticulo.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_BajaArticulo.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaArticulo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaArticulo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_BajaArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BajaArticulo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BajaArticulo.ForeColor = System.Drawing.Color.White;
            this.btn_BajaArticulo.Location = new System.Drawing.Point(383, 581);
            this.btn_BajaArticulo.Name = "btn_BajaArticulo";
            this.btn_BajaArticulo.Size = new System.Drawing.Size(85, 41);
            this.btn_BajaArticulo.TabIndex = 28;
            this.btn_BajaArticulo.Tag = "64";
            this.btn_BajaArticulo.Text = "Baja";
            this.btn_BajaArticulo.UseVisualStyleBackColor = false;
            // 
            // btn_DefinirStocks
            // 
            this.btn_DefinirStocks.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_DefinirStocks.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_DefinirStocks.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_DefinirStocks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_DefinirStocks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_DefinirStocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DefinirStocks.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DefinirStocks.ForeColor = System.Drawing.Color.White;
            this.btn_DefinirStocks.Location = new System.Drawing.Point(37, 638);
            this.btn_DefinirStocks.Name = "btn_DefinirStocks";
            this.btn_DefinirStocks.Size = new System.Drawing.Size(143, 53);
            this.btn_DefinirStocks.TabIndex = 51;
            this.btn_DefinirStocks.Tag = "72";
            this.btn_DefinirStocks.Text = "Definir Stock Mínimo/Máximo";
            this.btn_DefinirStocks.UseVisualStyleBackColor = false;
            this.btn_DefinirStocks.Click += new System.EventHandler(this.btn_DefinirStocks_Click);
            // 
            // btn_IngresoEgreso
            // 
            this.btn_IngresoEgreso.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_IngresoEgreso.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_IngresoEgreso.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_IngresoEgreso.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_IngresoEgreso.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_IngresoEgreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_IngresoEgreso.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_IngresoEgreso.ForeColor = System.Drawing.Color.White;
            this.btn_IngresoEgreso.Location = new System.Drawing.Point(217, 638);
            this.btn_IngresoEgreso.Name = "btn_IngresoEgreso";
            this.btn_IngresoEgreso.Size = new System.Drawing.Size(143, 53);
            this.btn_IngresoEgreso.TabIndex = 52;
            this.btn_IngresoEgreso.Tag = "71";
            this.btn_IngresoEgreso.Text = "Ingreso/Egreso de artículos";
            this.btn_IngresoEgreso.UseVisualStyleBackColor = false;
            // 
            // btn_TipoUbicacion
            // 
            this.btn_TipoUbicacion.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_TipoUbicacion.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_TipoUbicacion.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_TipoUbicacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_TipoUbicacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_TipoUbicacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TipoUbicacion.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TipoUbicacion.ForeColor = System.Drawing.Color.White;
            this.btn_TipoUbicacion.Location = new System.Drawing.Point(577, 638);
            this.btn_TipoUbicacion.Name = "btn_TipoUbicacion";
            this.btn_TipoUbicacion.Size = new System.Drawing.Size(157, 53);
            this.btn_TipoUbicacion.TabIndex = 53;
            this.btn_TipoUbicacion.Tag = "73";
            this.btn_TipoUbicacion.Text = "Verificar Tipo Articulo y Ubicación";
            this.btn_TipoUbicacion.UseVisualStyleBackColor = false;
            // 
            // txt_TalleArt
            // 
            this.txt_TalleArt.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TalleArt.Location = new System.Drawing.Point(1199, 167);
            this.txt_TalleArt.Name = "txt_TalleArt";
            this.txt_TalleArt.Size = new System.Drawing.Size(100, 24);
            this.txt_TalleArt.TabIndex = 81;
            // 
            // lbl_CampoObligatorio
            // 
            this.lbl_CampoObligatorio.AutoSize = true;
            this.lbl_CampoObligatorio.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CampoObligatorio.ForeColor = System.Drawing.Color.White;
            this.lbl_CampoObligatorio.Location = new System.Drawing.Point(1086, 589);
            this.lbl_CampoObligatorio.Name = "lbl_CampoObligatorio";
            this.lbl_CampoObligatorio.Size = new System.Drawing.Size(159, 16);
            this.lbl_CampoObligatorio.TabIndex = 80;
            this.lbl_CampoObligatorio.Text = "* Campos obligarorios.";
            // 
            // btn_CancelarArticulo
            // 
            this.btn_CancelarArticulo.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_CancelarArticulo.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_CancelarArticulo.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CancelarArticulo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CancelarArticulo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_CancelarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CancelarArticulo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CancelarArticulo.ForeColor = System.Drawing.Color.White;
            this.btn_CancelarArticulo.Location = new System.Drawing.Point(1240, 628);
            this.btn_CancelarArticulo.Name = "btn_CancelarArticulo";
            this.btn_CancelarArticulo.Size = new System.Drawing.Size(88, 40);
            this.btn_CancelarArticulo.TabIndex = 79;
            this.btn_CancelarArticulo.Tag = "67";
            this.btn_CancelarArticulo.Text = "Cancelar";
            this.btn_CancelarArticulo.UseVisualStyleBackColor = false;
            // 
            // btn_GuardarArticulo
            // 
            this.btn_GuardarArticulo.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_GuardarArticulo.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_GuardarArticulo.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GuardarArticulo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GuardarArticulo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_GuardarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GuardarArticulo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GuardarArticulo.ForeColor = System.Drawing.Color.White;
            this.btn_GuardarArticulo.Location = new System.Drawing.Point(1116, 628);
            this.btn_GuardarArticulo.Name = "btn_GuardarArticulo";
            this.btn_GuardarArticulo.Size = new System.Drawing.Size(88, 40);
            this.btn_GuardarArticulo.TabIndex = 78;
            this.btn_GuardarArticulo.Tag = "66";
            this.btn_GuardarArticulo.Text = "Guardar";
            this.btn_GuardarArticulo.UseVisualStyleBackColor = false;
            // 
            // lbl_Empleado
            // 
            this.lbl_Empleado.AutoSize = true;
            this.lbl_Empleado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Empleado.ForeColor = System.Drawing.Color.White;
            this.lbl_Empleado.Location = new System.Drawing.Point(1104, 540);
            this.lbl_Empleado.Name = "lbl_Empleado";
            this.lbl_Empleado.Size = new System.Drawing.Size(92, 17);
            this.lbl_Empleado.TabIndex = 77;
            this.lbl_Empleado.Text = "Empleado: *";
            // 
            // lbl_Observacion
            // 
            this.lbl_Observacion.AutoSize = true;
            this.lbl_Observacion.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Observacion.ForeColor = System.Drawing.Color.White;
            this.lbl_Observacion.Location = new System.Drawing.Point(1098, 499);
            this.lbl_Observacion.Name = "lbl_Observacion";
            this.lbl_Observacion.Size = new System.Drawing.Size(98, 17);
            this.lbl_Observacion.TabIndex = 76;
            this.lbl_Observacion.Text = "Observación:";
            // 
            // lbl_PrecioProm
            // 
            this.lbl_PrecioProm.AutoSize = true;
            this.lbl_PrecioProm.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PrecioProm.ForeColor = System.Drawing.Color.White;
            this.lbl_PrecioProm.Location = new System.Drawing.Point(1063, 416);
            this.lbl_PrecioProm.Name = "lbl_PrecioProm";
            this.lbl_PrecioProm.Size = new System.Drawing.Size(134, 17);
            this.lbl_PrecioProm.TabIndex = 75;
            this.lbl_PrecioProm.Text = "Precio promoción:";
            // 
            // lbl_PrecioVenta
            // 
            this.lbl_PrecioVenta.AutoSize = true;
            this.lbl_PrecioVenta.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PrecioVenta.ForeColor = System.Drawing.Color.White;
            this.lbl_PrecioVenta.Location = new System.Drawing.Point(1100, 375);
            this.lbl_PrecioVenta.Name = "lbl_PrecioVenta";
            this.lbl_PrecioVenta.Size = new System.Drawing.Size(96, 17);
            this.lbl_PrecioVenta.TabIndex = 74;
            this.lbl_PrecioVenta.Text = "Precio venta:";
            // 
            // lbl_PrecioCosto
            // 
            this.lbl_PrecioCosto.AutoSize = true;
            this.lbl_PrecioCosto.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PrecioCosto.ForeColor = System.Drawing.Color.White;
            this.lbl_PrecioCosto.Location = new System.Drawing.Point(1090, 334);
            this.lbl_PrecioCosto.Name = "lbl_PrecioCosto";
            this.lbl_PrecioCosto.Size = new System.Drawing.Size(106, 17);
            this.lbl_PrecioCosto.TabIndex = 73;
            this.lbl_PrecioCosto.Text = "Precio costo: *";
            // 
            // lbl_StockMax
            // 
            this.lbl_StockMax.AutoSize = true;
            this.lbl_StockMax.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_StockMax.ForeColor = System.Drawing.Color.White;
            this.lbl_StockMax.Location = new System.Drawing.Point(1085, 293);
            this.lbl_StockMax.Name = "lbl_StockMax";
            this.lbl_StockMax.Size = new System.Drawing.Size(111, 17);
            this.lbl_StockMax.TabIndex = 72;
            this.lbl_StockMax.Text = "Stock máximo:";
            // 
            // lbl_StockMin
            // 
            this.lbl_StockMin.AutoSize = true;
            this.lbl_StockMin.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_StockMin.ForeColor = System.Drawing.Color.White;
            this.lbl_StockMin.Location = new System.Drawing.Point(1091, 252);
            this.lbl_StockMin.Name = "lbl_StockMin";
            this.lbl_StockMin.Size = new System.Drawing.Size(105, 17);
            this.lbl_StockMin.TabIndex = 71;
            this.lbl_StockMin.Text = "Stock mínimo:";
            // 
            // lbl_Existencia
            // 
            this.lbl_Existencia.AutoSize = true;
            this.lbl_Existencia.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Existencia.ForeColor = System.Drawing.Color.White;
            this.lbl_Existencia.Location = new System.Drawing.Point(1106, 211);
            this.lbl_Existencia.Name = "lbl_Existencia";
            this.lbl_Existencia.Size = new System.Drawing.Size(90, 17);
            this.lbl_Existencia.TabIndex = 70;
            this.lbl_Existencia.Text = "Existencia: *";
            // 
            // lbl_Talle
            // 
            this.lbl_Talle.AutoSize = true;
            this.lbl_Talle.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Talle.ForeColor = System.Drawing.Color.White;
            this.lbl_Talle.Location = new System.Drawing.Point(1142, 170);
            this.lbl_Talle.Name = "lbl_Talle";
            this.lbl_Talle.Size = new System.Drawing.Size(54, 17);
            this.lbl_Talle.TabIndex = 69;
            this.lbl_Talle.Text = "Talle: *";
            // 
            // lbl_Marca
            // 
            this.lbl_Marca.AutoSize = true;
            this.lbl_Marca.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Marca.ForeColor = System.Drawing.Color.White;
            this.lbl_Marca.Location = new System.Drawing.Point(1130, 128);
            this.lbl_Marca.Name = "lbl_Marca";
            this.lbl_Marca.Size = new System.Drawing.Size(66, 17);
            this.lbl_Marca.TabIndex = 68;
            this.lbl_Marca.Text = "Marca: *";
            // 
            // txt_ObservacionArt
            // 
            this.txt_ObservacionArt.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ObservacionArt.Location = new System.Drawing.Point(1199, 496);
            this.txt_ObservacionArt.Name = "txt_ObservacionArt";
            this.txt_ObservacionArt.Size = new System.Drawing.Size(160, 24);
            this.txt_ObservacionArt.TabIndex = 65;
            // 
            // cb_Empleado
            // 
            this.cb_Empleado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Empleado.FormattingEnabled = true;
            this.cb_Empleado.Location = new System.Drawing.Point(1199, 537);
            this.cb_Empleado.Name = "cb_Empleado";
            this.cb_Empleado.Size = new System.Drawing.Size(121, 25);
            this.cb_Empleado.TabIndex = 64;
            // 
            // txt_PrecioPromArt
            // 
            this.txt_PrecioPromArt.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PrecioPromArt.Location = new System.Drawing.Point(1199, 413);
            this.txt_PrecioPromArt.Name = "txt_PrecioPromArt";
            this.txt_PrecioPromArt.Size = new System.Drawing.Size(100, 24);
            this.txt_PrecioPromArt.TabIndex = 63;
            this.txt_PrecioPromArt.Text = "0";
            // 
            // txt_PrecioVentaArt
            // 
            this.txt_PrecioVentaArt.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PrecioVentaArt.Location = new System.Drawing.Point(1199, 372);
            this.txt_PrecioVentaArt.Name = "txt_PrecioVentaArt";
            this.txt_PrecioVentaArt.Size = new System.Drawing.Size(100, 24);
            this.txt_PrecioVentaArt.TabIndex = 62;
            this.txt_PrecioVentaArt.Text = "0";
            // 
            // txt_PrecioCostoArt
            // 
            this.txt_PrecioCostoArt.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PrecioCostoArt.Location = new System.Drawing.Point(1199, 331);
            this.txt_PrecioCostoArt.Name = "txt_PrecioCostoArt";
            this.txt_PrecioCostoArt.Size = new System.Drawing.Size(100, 24);
            this.txt_PrecioCostoArt.TabIndex = 61;
            this.txt_PrecioCostoArt.Text = "0";
            // 
            // txt_StockMaxArt
            // 
            this.txt_StockMaxArt.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_StockMaxArt.Location = new System.Drawing.Point(1199, 290);
            this.txt_StockMaxArt.Name = "txt_StockMaxArt";
            this.txt_StockMaxArt.Size = new System.Drawing.Size(100, 24);
            this.txt_StockMaxArt.TabIndex = 60;
            this.txt_StockMaxArt.Text = "0";
            // 
            // txt_StockMinArt
            // 
            this.txt_StockMinArt.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_StockMinArt.Location = new System.Drawing.Point(1199, 249);
            this.txt_StockMinArt.Name = "txt_StockMinArt";
            this.txt_StockMinArt.Size = new System.Drawing.Size(100, 24);
            this.txt_StockMinArt.TabIndex = 59;
            this.txt_StockMinArt.Text = "0";
            // 
            // txt_ExistenciaArt
            // 
            this.txt_ExistenciaArt.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ExistenciaArt.Location = new System.Drawing.Point(1199, 208);
            this.txt_ExistenciaArt.Name = "txt_ExistenciaArt";
            this.txt_ExistenciaArt.Size = new System.Drawing.Size(100, 24);
            this.txt_ExistenciaArt.TabIndex = 58;
            this.txt_ExistenciaArt.Text = "0";
            // 
            // cb_Marcas
            // 
            this.cb_Marcas.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Marcas.FormattingEnabled = true;
            this.cb_Marcas.Location = new System.Drawing.Point(1199, 125);
            this.cb_Marcas.Name = "cb_Marcas";
            this.cb_Marcas.Size = new System.Drawing.Size(121, 25);
            this.cb_Marcas.TabIndex = 57;
            // 
            // txt_DescripcionArt
            // 
            this.txt_DescripcionArt.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DescripcionArt.Location = new System.Drawing.Point(1199, 84);
            this.txt_DescripcionArt.Name = "txt_DescripcionArt";
            this.txt_DescripcionArt.Size = new System.Drawing.Size(100, 24);
            this.txt_DescripcionArt.TabIndex = 56;
            // 
            // lbl_Descripcion
            // 
            this.lbl_Descripcion.AutoSize = true;
            this.lbl_Descripcion.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Descripcion.ForeColor = System.Drawing.Color.White;
            this.lbl_Descripcion.Location = new System.Drawing.Point(1093, 87);
            this.lbl_Descripcion.Name = "lbl_Descripcion";
            this.lbl_Descripcion.Size = new System.Drawing.Size(103, 17);
            this.lbl_Descripcion.TabIndex = 84;
            this.lbl_Descripcion.Text = "Descripción: *";
            // 
            // lbl_Codigo
            // 
            this.lbl_Codigo.AutoSize = true;
            this.lbl_Codigo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Codigo.ForeColor = System.Drawing.Color.White;
            this.lbl_Codigo.Location = new System.Drawing.Point(1123, 46);
            this.lbl_Codigo.Name = "lbl_Codigo";
            this.lbl_Codigo.Size = new System.Drawing.Size(73, 17);
            this.lbl_Codigo.TabIndex = 83;
            this.lbl_Codigo.Text = "Codigo: *";
            // 
            // txt_CodigoArt
            // 
            this.txt_CodigoArt.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CodigoArt.Location = new System.Drawing.Point(1199, 43);
            this.txt_CodigoArt.Name = "txt_CodigoArt";
            this.txt_CodigoArt.Size = new System.Drawing.Size(100, 24);
            this.txt_CodigoArt.TabIndex = 82;
            // 
            // txt_Busqueda
            // 
            this.txt_Busqueda.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Busqueda.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txt_Busqueda.Location = new System.Drawing.Point(12, 54);
            this.txt_Busqueda.Name = "txt_Busqueda";
            this.txt_Busqueda.Size = new System.Drawing.Size(1016, 24);
            this.txt_Busqueda.TabIndex = 85;
            this.txt_Busqueda.Tag = "69";
            this.txt_Busqueda.Text = "Búsqueda por: Descripción";
            // 
            // btn_IncPrecioVenta
            // 
            this.btn_IncPrecioVenta.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_IncPrecioVenta.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_IncPrecioVenta.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_IncPrecioVenta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_IncPrecioVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_IncPrecioVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_IncPrecioVenta.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_IncPrecioVenta.ForeColor = System.Drawing.Color.White;
            this.btn_IncPrecioVenta.Location = new System.Drawing.Point(744, 581);
            this.btn_IncPrecioVenta.Name = "btn_IncPrecioVenta";
            this.btn_IncPrecioVenta.Size = new System.Drawing.Size(137, 53);
            this.btn_IncPrecioVenta.TabIndex = 86;
            this.btn_IncPrecioVenta.Tag = "74";
            this.btn_IncPrecioVenta.Text = "Aumentar precio venta masivo";
            this.btn_IncPrecioVenta.UseVisualStyleBackColor = false;
            // 
            // btn_RedPrecioVenta
            // 
            this.btn_RedPrecioVenta.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_RedPrecioVenta.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_RedPrecioVenta.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_RedPrecioVenta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_RedPrecioVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_RedPrecioVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RedPrecioVenta.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RedPrecioVenta.ForeColor = System.Drawing.Color.White;
            this.btn_RedPrecioVenta.Location = new System.Drawing.Point(896, 581);
            this.btn_RedPrecioVenta.Name = "btn_RedPrecioVenta";
            this.btn_RedPrecioVenta.Size = new System.Drawing.Size(137, 53);
            this.btn_RedPrecioVenta.TabIndex = 89;
            this.btn_RedPrecioVenta.Tag = "75";
            this.btn_RedPrecioVenta.Text = "Reducir precio venta masivo";
            this.btn_RedPrecioVenta.UseVisualStyleBackColor = false;
            // 
            // lbl_Proveedor
            // 
            this.lbl_Proveedor.AutoSize = true;
            this.lbl_Proveedor.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Proveedor.ForeColor = System.Drawing.Color.White;
            this.lbl_Proveedor.Location = new System.Drawing.Point(1107, 457);
            this.lbl_Proveedor.Name = "lbl_Proveedor";
            this.lbl_Proveedor.Size = new System.Drawing.Size(90, 17);
            this.lbl_Proveedor.TabIndex = 92;
            this.lbl_Proveedor.Text = "Proveedor: *";
            // 
            // cb_Proveedores
            // 
            this.cb_Proveedores.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Proveedores.FormattingEnabled = true;
            this.cb_Proveedores.Location = new System.Drawing.Point(1199, 454);
            this.cb_Proveedores.Name = "cb_Proveedores";
            this.cb_Proveedores.Size = new System.Drawing.Size(121, 25);
            this.cb_Proveedores.TabIndex = 93;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(17, 13);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(143, 19);
            this.label17.TabIndex = 94;
            this.label17.Text = "Usuario Logeado:";
            // 
            // lbl_UsuarioLog
            // 
            this.lbl_UsuarioLog.AutoSize = true;
            this.lbl_UsuarioLog.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UsuarioLog.ForeColor = System.Drawing.Color.White;
            this.lbl_UsuarioLog.Location = new System.Drawing.Point(160, 13);
            this.lbl_UsuarioLog.Name = "lbl_UsuarioLog";
            this.lbl_UsuarioLog.Size = new System.Drawing.Size(66, 21);
            this.lbl_UsuarioLog.TabIndex = 95;
            this.lbl_UsuarioLog.Text = "label18";
            // 
            // btn_ReporteArticulo
            // 
            this.btn_ReporteArticulo.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_ReporteArticulo.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_ReporteArticulo.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ReporteArticulo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ReporteArticulo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ReporteArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ReporteArticulo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ReporteArticulo.ForeColor = System.Drawing.Color.White;
            this.btn_ReporteArticulo.Location = new System.Drawing.Point(522, 581);
            this.btn_ReporteArticulo.Name = "btn_ReporteArticulo";
            this.btn_ReporteArticulo.Size = new System.Drawing.Size(85, 41);
            this.btn_ReporteArticulo.TabIndex = 97;
            this.btn_ReporteArticulo.Tag = "98";
            this.btn_ReporteArticulo.Text = "Reporte";
            this.btn_ReporteArticulo.UseVisualStyleBackColor = false;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(16, 34);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(1036, 10);
            this.bunifuSeparator1.TabIndex = 98;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // btn_RegistrarMovimiento
            // 
            this.btn_RegistrarMovimiento.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_RegistrarMovimiento.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_RegistrarMovimiento.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_RegistrarMovimiento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_RegistrarMovimiento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_RegistrarMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RegistrarMovimiento.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RegistrarMovimiento.ForeColor = System.Drawing.Color.White;
            this.btn_RegistrarMovimiento.Location = new System.Drawing.Point(397, 638);
            this.btn_RegistrarMovimiento.Name = "btn_RegistrarMovimiento";
            this.btn_RegistrarMovimiento.Size = new System.Drawing.Size(143, 53);
            this.btn_RegistrarMovimiento.TabIndex = 99;
            this.btn_RegistrarMovimiento.Tag = "73";
            this.btn_RegistrarMovimiento.Text = "Registrar Movimiento";
            this.btn_RegistrarMovimiento.UseVisualStyleBackColor = false;
            // 
            // dgv_Articulos
            // 
            this.dgv_Articulos.AllowUserToOrderColumns = true;
            this.dgv_Articulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Articulos.Location = new System.Drawing.Point(12, 85);
            this.dgv_Articulos.Name = "dgv_Articulos";
            this.dgv_Articulos.Size = new System.Drawing.Size(1016, 463);
            this.dgv_Articulos.TabIndex = 100;
            this.dgv_Articulos.Tag = "68";
            // 
            // frmAdmInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1370, 703);
            this.Controls.Add(this.dgv_Articulos);
            this.Controls.Add(this.btn_RegistrarMovimiento);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.btn_ReporteArticulo);
            this.Controls.Add(this.lbl_UsuarioLog);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cb_Proveedores);
            this.Controls.Add(this.lbl_Proveedor);
            this.Controls.Add(this.btn_RedPrecioVenta);
            this.Controls.Add(this.btn_IncPrecioVenta);
            this.Controls.Add(this.txt_Busqueda);
            this.Controls.Add(this.lbl_Descripcion);
            this.Controls.Add(this.lbl_Codigo);
            this.Controls.Add(this.txt_CodigoArt);
            this.Controls.Add(this.txt_TalleArt);
            this.Controls.Add(this.lbl_CampoObligatorio);
            this.Controls.Add(this.btn_CancelarArticulo);
            this.Controls.Add(this.btn_GuardarArticulo);
            this.Controls.Add(this.lbl_Empleado);
            this.Controls.Add(this.lbl_Observacion);
            this.Controls.Add(this.lbl_PrecioProm);
            this.Controls.Add(this.lbl_PrecioVenta);
            this.Controls.Add(this.lbl_PrecioCosto);
            this.Controls.Add(this.lbl_StockMax);
            this.Controls.Add(this.lbl_StockMin);
            this.Controls.Add(this.lbl_Existencia);
            this.Controls.Add(this.lbl_Talle);
            this.Controls.Add(this.lbl_Marca);
            this.Controls.Add(this.txt_ObservacionArt);
            this.Controls.Add(this.cb_Empleado);
            this.Controls.Add(this.txt_PrecioPromArt);
            this.Controls.Add(this.txt_PrecioVentaArt);
            this.Controls.Add(this.txt_PrecioCostoArt);
            this.Controls.Add(this.txt_StockMaxArt);
            this.Controls.Add(this.txt_StockMinArt);
            this.Controls.Add(this.txt_ExistenciaArt);
            this.Controls.Add(this.cb_Marcas);
            this.Controls.Add(this.txt_DescripcionArt);
            this.Controls.Add(this.btn_TipoUbicacion);
            this.Controls.Add(this.btn_IngresoEgreso);
            this.Controls.Add(this.btn_DefinirStocks);
            this.Controls.Add(this.btn_BajaArticulo);
            this.Controls.Add(this.btn_ModArticulo);
            this.Controls.Add(this.btn_AltaArticulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdmInventario";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adminitración de inventario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Articulos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox txt_TalleArt;
        public System.Windows.Forms.TextBox txt_ObservacionArt;
        public System.Windows.Forms.ComboBox cb_Empleado;
        public System.Windows.Forms.TextBox txt_PrecioPromArt;
        public System.Windows.Forms.TextBox txt_PrecioVentaArt;
        public System.Windows.Forms.TextBox txt_PrecioCostoArt;
        public System.Windows.Forms.TextBox txt_StockMaxArt;
        public System.Windows.Forms.TextBox txt_StockMinArt;
        public System.Windows.Forms.TextBox txt_ExistenciaArt;
        public System.Windows.Forms.ComboBox cb_Marcas;
        public System.Windows.Forms.TextBox txt_DescripcionArt;
        public System.Windows.Forms.TextBox txt_CodigoArt;
        public System.Windows.Forms.TextBox txt_Busqueda;
        public System.Windows.Forms.ComboBox cb_Proveedores;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbl_UsuarioLog;
        public System.Windows.Forms.Button btn_AltaArticulo;
        public System.Windows.Forms.Button btn_ModArticulo;
        public System.Windows.Forms.Button btn_BajaArticulo;
        public System.Windows.Forms.Button btn_DefinirStocks;
        public System.Windows.Forms.Button btn_IngresoEgreso;
        public System.Windows.Forms.Button btn_TipoUbicacion;
        public System.Windows.Forms.Button btn_CancelarArticulo;
        public System.Windows.Forms.Button btn_GuardarArticulo;
        public System.Windows.Forms.Button btn_IncPrecioVenta;
        public System.Windows.Forms.Button btn_RedPrecioVenta;
        public System.Windows.Forms.Label lbl_CampoObligatorio;
        public System.Windows.Forms.Label lbl_Empleado;
        public System.Windows.Forms.Label lbl_Observacion;
        public System.Windows.Forms.Label lbl_PrecioProm;
        public System.Windows.Forms.Label lbl_PrecioVenta;
        public System.Windows.Forms.Label lbl_PrecioCosto;
        public System.Windows.Forms.Label lbl_StockMax;
        public System.Windows.Forms.Label lbl_StockMin;
        public System.Windows.Forms.Label lbl_Existencia;
        public System.Windows.Forms.Label lbl_Talle;
        public System.Windows.Forms.Label lbl_Marca;
        public System.Windows.Forms.Label lbl_Descripcion;
        public System.Windows.Forms.Label lbl_Codigo;
        public System.Windows.Forms.Label lbl_Proveedor;
        public System.Windows.Forms.Button btn_ReporteArticulo;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        public System.Windows.Forms.Button btn_RegistrarMovimiento;
        public System.Windows.Forms.DataGridView dgv_Articulos;
    }
}