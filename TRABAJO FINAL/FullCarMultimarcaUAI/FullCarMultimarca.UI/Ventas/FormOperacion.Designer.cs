
namespace FullCarMultimarca.UI.Ventas
{
    partial class FormOperacion
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOperacion));
            this.btnCerrar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnEliminarFPago = new System.Windows.Forms.Button();
            this.btnAgregarFPago = new System.Windows.Forms.Button();
            this.btnModificarFPago = new System.Windows.Forms.Button();
            this.txtPrecioPublico = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtChasis = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNroOperacion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtOferta = new System.Windows.Forms.TextBox();
            this.Oferta = new System.Windows.Forms.Label();
            this.txtPauta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbPatentaEmpresa = new System.Windows.Forms.ComboBox();
            this.lblTipoProducto = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtVendedor = new System.Windows.Forms.TextBox();
            this.grupoCliente = new System.Windows.Forms.GroupBox();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtDescalce = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.grupoFormasDePago = new System.Windows.Forms.GroupBox();
            this.grillaFormasPago = new System.Windows.Forms.DataGridView();
            this.txtGastoGestoria = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtGastoFinanciacion = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtGastoUsado = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPrecioFinal = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnABOperacion = new System.Windows.Forms.Button();
            this.lblUnidadEnOferta = new System.Windows.Forms.Label();
            this.lblContadoMinimo = new System.Windows.Forms.Label();
            this.lblOperacionBalanceada = new System.Windows.Forms.Label();
            this.txtPagosTotales = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lblOperacionAnulada = new System.Windows.Forms.Label();
            this.imgInfoRechazo = new System.Windows.Forms.PictureBox();
            this.lblPorcGestoria = new System.Windows.Forms.Label();
            this.buscadorCliente1 = new FullCarMultimarca.UI.UserControls.BuscadorCliente();
            this.txtPrecioUnidad = new FullCarMultimarca.UI.UserControls.DecimalTextBox();
            this.grupoCliente.SuspendLayout();
            this.grupoFormasDePago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaFormasPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgInfoRechazo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Location = new System.Drawing.Point(6, 513);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnEliminarFPago
            // 
            this.btnEliminarFPago.Image = global::FullCarMultimarca.UI.Properties.Resources.delete2;
            this.btnEliminarFPago.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarFPago.Location = new System.Drawing.Point(9, 71);
            this.btnEliminarFPago.Name = "btnEliminarFPago";
            this.btnEliminarFPago.Size = new System.Drawing.Size(27, 23);
            this.btnEliminarFPago.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnEliminarFPago, "Eliminar Forma Pago");
            this.btnEliminarFPago.UseVisualStyleBackColor = true;
            this.btnEliminarFPago.Click += new System.EventHandler(this.btnEliminarFPago_Click);
            // 
            // btnAgregarFPago
            // 
            this.btnAgregarFPago.Image = global::FullCarMultimarca.UI.Properties.Resources.add2;
            this.btnAgregarFPago.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarFPago.Location = new System.Drawing.Point(9, 19);
            this.btnAgregarFPago.Name = "btnAgregarFPago";
            this.btnAgregarFPago.Size = new System.Drawing.Size(27, 23);
            this.btnAgregarFPago.TabIndex = 0;
            this.toolTip1.SetToolTip(this.btnAgregarFPago, "Agregar Forma Pago");
            this.btnAgregarFPago.UseVisualStyleBackColor = true;
            this.btnAgregarFPago.Click += new System.EventHandler(this.btnAgregarFPago_Click);
            // 
            // btnModificarFPago
            // 
            this.btnModificarFPago.Image = global::FullCarMultimarca.UI.Properties.Resources.document_edit;
            this.btnModificarFPago.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarFPago.Location = new System.Drawing.Point(9, 45);
            this.btnModificarFPago.Name = "btnModificarFPago";
            this.btnModificarFPago.Size = new System.Drawing.Size(27, 23);
            this.btnModificarFPago.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnModificarFPago, "Modificar Forma Pago");
            this.btnModificarFPago.UseVisualStyleBackColor = true;
            this.btnModificarFPago.Click += new System.EventHandler(this.btnModificarFPago_Click);
            // 
            // txtPrecioPublico
            // 
            this.txtPrecioPublico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioPublico.ForeColor = System.Drawing.Color.Black;
            this.txtPrecioPublico.Location = new System.Drawing.Point(93, 255);
            this.txtPrecioPublico.Name = "txtPrecioPublico";
            this.txtPrecioPublico.ReadOnly = true;
            this.txtPrecioPublico.Size = new System.Drawing.Size(117, 20);
            this.txtPrecioPublico.TabIndex = 24;
            this.txtPrecioPublico.TabStop = false;
            this.txtPrecioPublico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 258);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Precio Público";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Chasis";
            // 
            // txtChasis
            // 
            this.txtChasis.Location = new System.Drawing.Point(255, 84);
            this.txtChasis.Name = "txtChasis";
            this.txtChasis.ReadOnly = true;
            this.txtChasis.Size = new System.Drawing.Size(241, 20);
            this.txtChasis.TabIndex = 21;
            this.txtChasis.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Color";
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(67, 84);
            this.txtColor.Name = "txtColor";
            this.txtColor.ReadOnly = true;
            this.txtColor.Size = new System.Drawing.Size(143, 20);
            this.txtColor.TabIndex = 19;
            this.txtColor.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Modelo";
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(67, 58);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.ReadOnly = true;
            this.txtModelo.Size = new System.Drawing.Size(429, 20);
            this.txtModelo.TabIndex = 17;
            this.txtModelo.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(256, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Número Operación";
            // 
            // txtNroOperacion
            // 
            this.txtNroOperacion.Location = new System.Drawing.Point(358, 6);
            this.txtNroOperacion.Name = "txtNroOperacion";
            this.txtNroOperacion.ReadOnly = true;
            this.txtNroOperacion.Size = new System.Drawing.Size(138, 20);
            this.txtNroOperacion.TabIndex = 25;
            this.txtNroOperacion.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(312, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Estado";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(358, 32);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(105, 20);
            this.txtEstado.TabIndex = 27;
            this.txtEstado.TabStop = false;
            // 
            // txtOferta
            // 
            this.txtOferta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOferta.ForeColor = System.Drawing.Color.Black;
            this.txtOferta.Location = new System.Drawing.Point(93, 281);
            this.txtOferta.Name = "txtOferta";
            this.txtOferta.ReadOnly = true;
            this.txtOferta.Size = new System.Drawing.Size(117, 20);
            this.txtOferta.TabIndex = 30;
            this.txtOferta.TabStop = false;
            this.txtOferta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Oferta
            // 
            this.Oferta.AutoSize = true;
            this.Oferta.Location = new System.Drawing.Point(51, 284);
            this.Oferta.Name = "Oferta";
            this.Oferta.Size = new System.Drawing.Size(36, 13);
            this.Oferta.TabIndex = 29;
            this.Oferta.Text = "Oferta";
            // 
            // txtPauta
            // 
            this.txtPauta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPauta.ForeColor = System.Drawing.Color.Black;
            this.txtPauta.Location = new System.Drawing.Point(93, 307);
            this.txtPauta.Name = "txtPauta";
            this.txtPauta.ReadOnly = true;
            this.txtPauta.Size = new System.Drawing.Size(117, 20);
            this.txtPauta.TabIndex = 32;
            this.txtPauta.TabStop = false;
            this.txtPauta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 310);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Pauta";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(314, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 54;
            this.label7.Text = "Precio Unidad";
            // 
            // cmbPatentaEmpresa
            // 
            this.cmbPatentaEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPatentaEmpresa.FormattingEnabled = true;
            this.cmbPatentaEmpresa.Location = new System.Drawing.Point(434, 280);
            this.cmbPatentaEmpresa.Name = "cmbPatentaEmpresa";
            this.cmbPatentaEmpresa.Size = new System.Drawing.Size(62, 21);
            this.cmbPatentaEmpresa.TabIndex = 2;
            // 
            // lblTipoProducto
            // 
            this.lblTipoProducto.AutoSize = true;
            this.lblTipoProducto.Location = new System.Drawing.Point(336, 284);
            this.lblTipoProducto.Name = "lblTipoProducto";
            this.lblTipoProducto.Size = new System.Drawing.Size(88, 13);
            this.lblTipoProducto.TabIndex = 56;
            this.lblTipoProducto.Text = "Patenta Empresa";
            this.lblTipoProducto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 58;
            this.label9.Text = "Vendedor";
            // 
            // txtVendedor
            // 
            this.txtVendedor.Location = new System.Drawing.Point(67, 32);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.ReadOnly = true;
            this.txtVendedor.Size = new System.Drawing.Size(182, 20);
            this.txtVendedor.TabIndex = 57;
            this.txtVendedor.TabStop = false;
            // 
            // grupoCliente
            // 
            this.grupoCliente.Controls.Add(this.buscadorCliente1);
            this.grupoCliente.Location = new System.Drawing.Point(6, 123);
            this.grupoCliente.Name = "grupoCliente";
            this.grupoCliente.Size = new System.Drawing.Size(490, 118);
            this.grupoCliente.TabIndex = 0;
            this.grupoCliente.TabStop = false;
            this.grupoCliente.Text = "Cliente";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuento.ForeColor = System.Drawing.Color.Black;
            this.txtDescuento.Location = new System.Drawing.Point(394, 307);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.ReadOnly = true;
            this.txtDescuento.Size = new System.Drawing.Size(102, 20);
            this.txtDescuento.TabIndex = 63;
            this.txtDescuento.TabStop = false;
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(327, 310);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(59, 13);
            this.lblDesc.TabIndex = 62;
            this.lblDesc.Text = "Descuento";
            // 
            // txtDescalce
            // 
            this.txtDescalce.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescalce.ForeColor = System.Drawing.Color.Black;
            this.txtDescalce.Location = new System.Drawing.Point(394, 333);
            this.txtDescalce.Name = "txtDescalce";
            this.txtDescalce.ReadOnly = true;
            this.txtDescalce.Size = new System.Drawing.Size(102, 20);
            this.txtDescalce.TabIndex = 61;
            this.txtDescalce.TabStop = false;
            this.txtDescalce.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(334, 336);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 60;
            this.label11.Text = "Descalce";
            // 
            // grupoFormasDePago
            // 
            this.grupoFormasDePago.Controls.Add(this.btnModificarFPago);
            this.grupoFormasDePago.Controls.Add(this.btnEliminarFPago);
            this.grupoFormasDePago.Controls.Add(this.btnAgregarFPago);
            this.grupoFormasDePago.Controls.Add(this.grillaFormasPago);
            this.grupoFormasDePago.Location = new System.Drawing.Point(6, 333);
            this.grupoFormasDePago.Name = "grupoFormasDePago";
            this.grupoFormasDePago.Size = new System.Drawing.Size(263, 139);
            this.grupoFormasDePago.TabIndex = 3;
            this.grupoFormasDePago.TabStop = false;
            this.grupoFormasDePago.Text = "Formas de Pago";
            // 
            // grillaFormasPago
            // 
            this.grillaFormasPago.AllowUserToAddRows = false;
            this.grillaFormasPago.AllowUserToDeleteRows = false;
            this.grillaFormasPago.AllowUserToResizeColumns = false;
            this.grillaFormasPago.AllowUserToResizeRows = false;
            this.grillaFormasPago.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grillaFormasPago.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.grillaFormasPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaFormasPago.Location = new System.Drawing.Point(39, 19);
            this.grillaFormasPago.MultiSelect = false;
            this.grillaFormasPago.Name = "grillaFormasPago";
            this.grillaFormasPago.ReadOnly = true;
            this.grillaFormasPago.RowHeadersVisible = false;
            this.grillaFormasPago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaFormasPago.Size = new System.Drawing.Size(218, 107);
            this.grillaFormasPago.TabIndex = 3;
            this.grillaFormasPago.TabStop = false;
            this.grillaFormasPago.DoubleClick += new System.EventHandler(this.grillaFormasPago_DoubleClick);
            // 
            // txtGastoGestoria
            // 
            this.txtGastoGestoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGastoGestoria.ForeColor = System.Drawing.Color.Black;
            this.txtGastoGestoria.Location = new System.Drawing.Point(394, 359);
            this.txtGastoGestoria.Name = "txtGastoGestoria";
            this.txtGastoGestoria.ReadOnly = true;
            this.txtGastoGestoria.Size = new System.Drawing.Size(102, 20);
            this.txtGastoGestoria.TabIndex = 66;
            this.txtGastoGestoria.TabStop = false;
            this.txtGastoGestoria.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(275, 362);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 65;
            this.label10.Text = "Gasto Gestoría";
            // 
            // txtGastoFinanciacion
            // 
            this.txtGastoFinanciacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGastoFinanciacion.ForeColor = System.Drawing.Color.Black;
            this.txtGastoFinanciacion.Location = new System.Drawing.Point(394, 385);
            this.txtGastoFinanciacion.Name = "txtGastoFinanciacion";
            this.txtGastoFinanciacion.ReadOnly = true;
            this.txtGastoFinanciacion.Size = new System.Drawing.Size(102, 20);
            this.txtGastoFinanciacion.TabIndex = 68;
            this.txtGastoFinanciacion.TabStop = false;
            this.txtGastoFinanciacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(288, 388);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 13);
            this.label12.TabIndex = 67;
            this.label12.Text = "Gasto Financiación";
            // 
            // txtGastoUsado
            // 
            this.txtGastoUsado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGastoUsado.ForeColor = System.Drawing.Color.Black;
            this.txtGastoUsado.Location = new System.Drawing.Point(394, 411);
            this.txtGastoUsado.Name = "txtGastoUsado";
            this.txtGastoUsado.ReadOnly = true;
            this.txtGastoUsado.Size = new System.Drawing.Size(102, 20);
            this.txtGastoUsado.TabIndex = 70;
            this.txtGastoUsado.TabStop = false;
            this.txtGastoUsado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(314, 414);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 13);
            this.label13.TabIndex = 69;
            this.label13.Text = "Gasto Usados";
            // 
            // txtPrecioFinal
            // 
            this.txtPrecioFinal.BackColor = System.Drawing.SystemColors.Info;
            this.txtPrecioFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioFinal.ForeColor = System.Drawing.Color.Black;
            this.txtPrecioFinal.Location = new System.Drawing.Point(379, 478);
            this.txtPrecioFinal.Name = "txtPrecioFinal";
            this.txtPrecioFinal.ReadOnly = true;
            this.txtPrecioFinal.Size = new System.Drawing.Size(117, 20);
            this.txtPrecioFinal.TabIndex = 72;
            this.txtPrecioFinal.TabStop = false;
            this.txtPrecioFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(299, 481);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 13);
            this.label14.TabIndex = 71;
            this.label14.Text = "Precio Final";
            // 
            // btnABOperacion
            // 
            this.btnABOperacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnABOperacion.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnABOperacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnABOperacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnABOperacion.Location = new System.Drawing.Point(330, 513);
            this.btnABOperacion.Name = "btnABOperacion";
            this.btnABOperacion.Size = new System.Drawing.Size(166, 23);
            this.btnABOperacion.TabIndex = 4;
            this.btnABOperacion.Text = "Guardar";
            this.btnABOperacion.UseVisualStyleBackColor = false;
            this.btnABOperacion.Click += new System.EventHandler(this.btnABOperacion_Click);
            // 
            // lblUnidadEnOferta
            // 
            this.lblUnidadEnOferta.AutoSize = true;
            this.lblUnidadEnOferta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnidadEnOferta.ForeColor = System.Drawing.Color.Blue;
            this.lblUnidadEnOferta.Location = new System.Drawing.Point(251, 107);
            this.lblUnidadEnOferta.Name = "lblUnidadEnOferta";
            this.lblUnidadEnOferta.Size = new System.Drawing.Size(235, 13);
            this.lblUnidadEnOferta.TabIndex = 73;
            this.lblUnidadEnOferta.Text = "*Unidad en Oferta: NO puede modificar el precio";
            this.lblUnidadEnOferta.Visible = false;
            // 
            // lblContadoMinimo
            // 
            this.lblContadoMinimo.AutoSize = true;
            this.lblContadoMinimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContadoMinimo.ForeColor = System.Drawing.Color.Black;
            this.lblContadoMinimo.Location = new System.Drawing.Point(314, 434);
            this.lblContadoMinimo.Name = "lblContadoMinimo";
            this.lblContadoMinimo.Size = new System.Drawing.Size(102, 13);
            this.lblContadoMinimo.TabIndex = 74;
            this.lblContadoMinimo.Text = "Contado mínimo: $0";
            // 
            // lblOperacionBalanceada
            // 
            this.lblOperacionBalanceada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOperacionBalanceada.AutoSize = true;
            this.lblOperacionBalanceada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperacionBalanceada.ForeColor = System.Drawing.Color.Red;
            this.lblOperacionBalanceada.Location = new System.Drawing.Point(135, 518);
            this.lblOperacionBalanceada.Name = "lblOperacionBalanceada";
            this.lblOperacionBalanceada.Size = new System.Drawing.Size(189, 13);
            this.lblOperacionBalanceada.TabIndex = 75;
            this.lblOperacionBalanceada.Text = "OPERACION DESBALANCEADA";
            this.lblOperacionBalanceada.Visible = false;
            // 
            // txtPagosTotales
            // 
            this.txtPagosTotales.BackColor = System.Drawing.Color.Silver;
            this.txtPagosTotales.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPagosTotales.ForeColor = System.Drawing.Color.Black;
            this.txtPagosTotales.Location = new System.Drawing.Point(152, 478);
            this.txtPagosTotales.Name = "txtPagosTotales";
            this.txtPagosTotales.ReadOnly = true;
            this.txtPagosTotales.Size = new System.Drawing.Size(117, 20);
            this.txtPagosTotales.TabIndex = 77;
            this.txtPagosTotales.TabStop = false;
            this.txtPagosTotales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(72, 481);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 13);
            this.label15.TabIndex = 76;
            this.label15.Text = "Total Pagos";
            // 
            // lblOperacionAnulada
            // 
            this.lblOperacionAnulada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOperacionAnulada.AutoSize = true;
            this.lblOperacionAnulada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperacionAnulada.ForeColor = System.Drawing.Color.Red;
            this.lblOperacionAnulada.Location = new System.Drawing.Point(124, 9);
            this.lblOperacionAnulada.Name = "lblOperacionAnulada";
            this.lblOperacionAnulada.Size = new System.Drawing.Size(65, 13);
            this.lblOperacionAnulada.TabIndex = 78;
            this.lblOperacionAnulada.Text = "ANULADA";
            this.lblOperacionAnulada.Visible = false;
            // 
            // imgInfoRechazo
            // 
            this.imgInfoRechazo.Image = global::FullCarMultimarca.UI.Properties.Resources.modifPalabraClave;
            this.imgInfoRechazo.Location = new System.Drawing.Point(469, 32);
            this.imgInfoRechazo.Name = "imgInfoRechazo";
            this.imgInfoRechazo.Size = new System.Drawing.Size(17, 20);
            this.imgInfoRechazo.TabIndex = 79;
            this.imgInfoRechazo.TabStop = false;
            // 
            // lblPorcGestoria
            // 
            this.lblPorcGestoria.AutoSize = true;
            this.lblPorcGestoria.Location = new System.Drawing.Point(352, 362);
            this.lblPorcGestoria.Name = "lblPorcGestoria";
            this.lblPorcGestoria.Size = new System.Drawing.Size(21, 13);
            this.lblPorcGestoria.TabIndex = 80;
            this.lblPorcGestoria.Text = "0%";
            this.lblPorcGestoria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buscadorCliente1
            // 
            this.buscadorCliente1.CacheClientes = null;
            this.buscadorCliente1.ClienteSeleccionado = null;
            this.buscadorCliente1.Location = new System.Drawing.Point(5, 19);
            this.buscadorCliente1.Name = "buscadorCliente1";
            this.buscadorCliente1.Size = new System.Drawing.Size(475, 88);
            this.buscadorCliente1.TabIndex = 0;
            // 
            // txtPrecioUnidad
            // 
            this.txtPrecioUnidad.Location = new System.Drawing.Point(394, 255);
            this.txtPrecioUnidad.Mask = "00000000.00";
            this.txtPrecioUnidad.Name = "txtPrecioUnidad";
            this.txtPrecioUnidad.Size = new System.Drawing.Size(102, 20);
            this.txtPrecioUnidad.TabIndex = 1;
            this.txtPrecioUnidad.Text = "        00";
            this.txtPrecioUnidad.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtPrecioUnidad.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // FormOperacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 548);
            this.Controls.Add(this.lblPorcGestoria);
            this.Controls.Add(this.imgInfoRechazo);
            this.Controls.Add(this.lblOperacionAnulada);
            this.Controls.Add(this.txtPagosTotales);
            this.Controls.Add(this.lblUnidadEnOferta);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblOperacionBalanceada);
            this.Controls.Add(this.lblContadoMinimo);
            this.Controls.Add(this.btnABOperacion);
            this.Controls.Add(this.txtPrecioFinal);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtGastoUsado);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtGastoFinanciacion);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtGastoGestoria);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.grupoFormasDePago);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtDescalce);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.grupoCliente);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtVendedor);
            this.Controls.Add(this.cmbPatentaEmpresa);
            this.Controls.Add(this.lblTipoProducto);
            this.Controls.Add(this.txtPrecioUnidad);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPauta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtOferta);
            this.Controls.Add(this.Oferta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNroOperacion);
            this.Controls.Add(this.txtPrecioPublico);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtChasis);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.btnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOperacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Operación de Venta";
            this.Load += new System.EventHandler(this.FormOperacion_Load);
            this.grupoCliente.ResumeLayout(false);
            this.grupoFormasDePago.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grillaFormasPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgInfoRechazo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ToolTip toolTip1;
        private UserControls.BuscadorCliente buscadorCliente1;
        private System.Windows.Forms.TextBox txtPrecioPublico;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtChasis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNroOperacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtOferta;
        private System.Windows.Forms.Label Oferta;
        private System.Windows.Forms.TextBox txtPauta;
        private System.Windows.Forms.Label label6;
        private UserControls.DecimalTextBox txtPrecioUnidad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbPatentaEmpresa;
        private System.Windows.Forms.Label lblTipoProducto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtVendedor;
        private System.Windows.Forms.GroupBox grupoCliente;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDescalce;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox grupoFormasDePago;
        private System.Windows.Forms.TextBox txtGastoGestoria;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtGastoFinanciacion;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtGastoUsado;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPrecioFinal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnABOperacion;
        public System.Windows.Forms.DataGridView grillaFormasPago;
        private System.Windows.Forms.Button btnEliminarFPago;
        private System.Windows.Forms.Button btnAgregarFPago;
        private System.Windows.Forms.Label lblUnidadEnOferta;
        private System.Windows.Forms.Button btnModificarFPago;
        private System.Windows.Forms.Label lblContadoMinimo;
        private System.Windows.Forms.Label lblOperacionBalanceada;
        private System.Windows.Forms.TextBox txtPagosTotales;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblOperacionAnulada;
        private System.Windows.Forms.PictureBox imgInfoRechazo;
        private System.Windows.Forms.Label lblPorcGestoria;
    }
}