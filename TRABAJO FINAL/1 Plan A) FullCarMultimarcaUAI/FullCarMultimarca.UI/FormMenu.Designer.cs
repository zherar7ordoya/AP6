namespace FullCarMultimarca.UI
{
    partial class FormMenu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarDeUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarClaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modiciarPalabraClaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.altaDeUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónPermisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDeBackupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coloresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeContactoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formasDePagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.parámetrosEmpresaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametrosComisionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionesPendientesDeAutorizaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liquidacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liquidarComisionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liquidacionesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.resumenPorActividadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liquidacionPorProfesorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumenMensualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagramaDeClasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.especificaciónDelSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerVencimientoOfertas = new System.Windows.Forms.Timer(this.components);
            this.timerNotificacionOperaciones = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.gestiónToolStripMenuItem,
            this.ventasToolStripMenuItem,
            this.liquidacionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(955, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarDeUsuarioToolStripMenuItem,
            this.modificarClaveToolStripMenuItem,
            this.modiciarPalabraClaveToolStripMenuItem,
            this.toolStripSeparator2,
            this.altaDeUsuarioToolStripMenuItem,
            this.gestiónPermisosToolStripMenuItem,
            this.gestiónDeBackupsToolStripMenuItem,
            this.parametrosToolStripMenuItem,
            this.verLogsToolStripMenuItem,
            this.toolStripSeparator1,
            this.salirToolStripMenuItem});
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.inicioToolStripMenuItem.Text = "Inicio";
            // 
            // cambiarDeUsuarioToolStripMenuItem
            // 
            this.cambiarDeUsuarioToolStripMenuItem.Image = global::FullCarMultimarca.UI.Properties.Resources.cambiarUsuario;
            this.cambiarDeUsuarioToolStripMenuItem.Name = "cambiarDeUsuarioToolStripMenuItem";
            this.cambiarDeUsuarioToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.cambiarDeUsuarioToolStripMenuItem.Tag = "SP";
            this.cambiarDeUsuarioToolStripMenuItem.Text = "Cambiar de Usuario";
            this.cambiarDeUsuarioToolStripMenuItem.Click += new System.EventHandler(this.cambiarDeUsuarioToolStripMenuItem_Click);
            // 
            // modificarClaveToolStripMenuItem
            // 
            this.modificarClaveToolStripMenuItem.Image = global::FullCarMultimarca.UI.Properties.Resources.modificarClave;
            this.modificarClaveToolStripMenuItem.Name = "modificarClaveToolStripMenuItem";
            this.modificarClaveToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.modificarClaveToolStripMenuItem.Tag = "SP";
            this.modificarClaveToolStripMenuItem.Text = "Modificar Clave";
            this.modificarClaveToolStripMenuItem.Click += new System.EventHandler(this.modificarClaveToolStripMenuItem_Click);
            // 
            // modiciarPalabraClaveToolStripMenuItem
            // 
            this.modiciarPalabraClaveToolStripMenuItem.Image = global::FullCarMultimarca.UI.Properties.Resources.modifPalabraClave;
            this.modiciarPalabraClaveToolStripMenuItem.Name = "modiciarPalabraClaveToolStripMenuItem";
            this.modiciarPalabraClaveToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.modiciarPalabraClaveToolStripMenuItem.Tag = "SP";
            this.modiciarPalabraClaveToolStripMenuItem.Text = "Modiciar Palabra Clave";
            this.modiciarPalabraClaveToolStripMenuItem.Click += new System.EventHandler(this.modiciarPalabraClaveToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(203, 6);
            // 
            // altaDeUsuarioToolStripMenuItem
            // 
            this.altaDeUsuarioToolStripMenuItem.Image = global::FullCarMultimarca.UI.Properties.Resources.usuarios;
            this.altaDeUsuarioToolStripMenuItem.Name = "altaDeUsuarioToolStripMenuItem";
            this.altaDeUsuarioToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.altaDeUsuarioToolStripMenuItem.Tag = "PS1001";
            this.altaDeUsuarioToolStripMenuItem.Text = "Usuarios";
            this.altaDeUsuarioToolStripMenuItem.Click += new System.EventHandler(this.altaDeUsuarioToolStripMenuItem_Click);
            // 
            // gestiónPermisosToolStripMenuItem
            // 
            this.gestiónPermisosToolStripMenuItem.Image = global::FullCarMultimarca.UI.Properties.Resources.permisos;
            this.gestiónPermisosToolStripMenuItem.Name = "gestiónPermisosToolStripMenuItem";
            this.gestiónPermisosToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.gestiónPermisosToolStripMenuItem.Tag = "PS1004";
            this.gestiónPermisosToolStripMenuItem.Text = "Permisos";
            this.gestiónPermisosToolStripMenuItem.Click += new System.EventHandler(this.gestiónPermisosToolStripMenuItem_Click);
            // 
            // gestiónDeBackupsToolStripMenuItem
            // 
            this.gestiónDeBackupsToolStripMenuItem.Image = global::FullCarMultimarca.UI.Properties.Resources.backups;
            this.gestiónDeBackupsToolStripMenuItem.Name = "gestiónDeBackupsToolStripMenuItem";
            this.gestiónDeBackupsToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.gestiónDeBackupsToolStripMenuItem.Tag = "PS1005";
            this.gestiónDeBackupsToolStripMenuItem.Text = "Backups";
            this.gestiónDeBackupsToolStripMenuItem.Click += new System.EventHandler(this.gestiónDeBackupsToolStripMenuItem_Click);
            // 
            // parametrosToolStripMenuItem
            // 
            this.parametrosToolStripMenuItem.Image = global::FullCarMultimarca.UI.Properties.Resources.parametros;
            this.parametrosToolStripMenuItem.Name = "parametrosToolStripMenuItem";
            this.parametrosToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.parametrosToolStripMenuItem.Tag = "PS1002";
            this.parametrosToolStripMenuItem.Text = "Párametros de Seguridad";
            this.parametrosToolStripMenuItem.Click += new System.EventHandler(this.parametrosToolStripMenuItem_Click);
            // 
            // verLogsToolStripMenuItem
            // 
            this.verLogsToolStripMenuItem.Image = global::FullCarMultimarca.UI.Properties.Resources.logs;
            this.verLogsToolStripMenuItem.Name = "verLogsToolStripMenuItem";
            this.verLogsToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.verLogsToolStripMenuItem.Tag = "PS1003";
            this.verLogsToolStripMenuItem.Text = "Logs del Sistema";
            this.verLogsToolStripMenuItem.Click += new System.EventHandler(this.verLogsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(203, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Image = global::FullCarMultimarca.UI.Properties.Resources.salir;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.salirToolStripMenuItem.Tag = "SP";
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // gestiónToolStripMenuItem
            // 
            this.gestiónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.marcasToolStripMenuItem,
            this.modelosToolStripMenuItem,
            this.coloresToolStripMenuItem,
            this.tiposDeContactoToolStripMenuItem,
            this.formasDePagoToolStripMenuItem,
            this.unidadesToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.toolStripSeparator3,
            this.parámetrosEmpresaToolStripMenuItem,
            this.parametrosComisionesToolStripMenuItem});
            this.gestiónToolStripMenuItem.Name = "gestiónToolStripMenuItem";
            this.gestiónToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.gestiónToolStripMenuItem.Text = "Administración";
            // 
            // marcasToolStripMenuItem
            // 
            this.marcasToolStripMenuItem.Image = global::FullCarMultimarca.UI.Properties.Resources.marca;
            this.marcasToolStripMenuItem.Name = "marcasToolStripMenuItem";
            this.marcasToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.marcasToolStripMenuItem.Tag = "PS1006";
            this.marcasToolStripMenuItem.Text = "Marcas";
            this.marcasToolStripMenuItem.Click += new System.EventHandler(this.marcasToolStripMenuItem_Click);
            // 
            // modelosToolStripMenuItem
            // 
            this.modelosToolStripMenuItem.Image = global::FullCarMultimarca.UI.Properties.Resources.modelos;
            this.modelosToolStripMenuItem.Name = "modelosToolStripMenuItem";
            this.modelosToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.modelosToolStripMenuItem.Tag = "PS1007";
            this.modelosToolStripMenuItem.Text = "Modelos";
            this.modelosToolStripMenuItem.Click += new System.EventHandler(this.modelosToolStripMenuItem_Click);
            // 
            // coloresToolStripMenuItem
            // 
            this.coloresToolStripMenuItem.Image = global::FullCarMultimarca.UI.Properties.Resources.color;
            this.coloresToolStripMenuItem.Name = "coloresToolStripMenuItem";
            this.coloresToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.coloresToolStripMenuItem.Tag = "PS1008";
            this.coloresToolStripMenuItem.Text = "Colores";
            this.coloresToolStripMenuItem.Click += new System.EventHandler(this.coloresToolStripMenuItem_Click);
            // 
            // tiposDeContactoToolStripMenuItem
            // 
            this.tiposDeContactoToolStripMenuItem.Image = global::FullCarMultimarca.UI.Properties.Resources.tipoContacto;
            this.tiposDeContactoToolStripMenuItem.Name = "tiposDeContactoToolStripMenuItem";
            this.tiposDeContactoToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.tiposDeContactoToolStripMenuItem.Tag = "PS1014";
            this.tiposDeContactoToolStripMenuItem.Text = "Tipos de Contacto";
            this.tiposDeContactoToolStripMenuItem.Click += new System.EventHandler(this.tiposDeContactoToolStripMenuItem_Click);
            // 
            // formasDePagoToolStripMenuItem
            // 
            this.formasDePagoToolStripMenuItem.Image = global::FullCarMultimarca.UI.Properties.Resources.formaPago;
            this.formasDePagoToolStripMenuItem.Name = "formasDePagoToolStripMenuItem";
            this.formasDePagoToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.formasDePagoToolStripMenuItem.Tag = "PS1009";
            this.formasDePagoToolStripMenuItem.Text = "Formas de Pago";
            this.formasDePagoToolStripMenuItem.Click += new System.EventHandler(this.formasDePagoToolStripMenuItem_Click);
            // 
            // unidadesToolStripMenuItem
            // 
            this.unidadesToolStripMenuItem.Image = global::FullCarMultimarca.UI.Properties.Resources.unidades;
            this.unidadesToolStripMenuItem.Name = "unidadesToolStripMenuItem";
            this.unidadesToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.unidadesToolStripMenuItem.Tag = "PS1013";
            this.unidadesToolStripMenuItem.Text = "Unidades";
            this.unidadesToolStripMenuItem.Click += new System.EventHandler(this.unidadesToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Image = global::FullCarMultimarca.UI.Properties.Resources.cliente;
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.clientesToolStripMenuItem.Tag = "PS1012";
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(196, 6);
            // 
            // parámetrosEmpresaToolStripMenuItem
            // 
            this.parámetrosEmpresaToolStripMenuItem.Image = global::FullCarMultimarca.UI.Properties.Resources.parametros;
            this.parámetrosEmpresaToolStripMenuItem.Name = "parámetrosEmpresaToolStripMenuItem";
            this.parámetrosEmpresaToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.parámetrosEmpresaToolStripMenuItem.Tag = "PS1010";
            this.parámetrosEmpresaToolStripMenuItem.Text = "Parámetros Ventas";
            this.parámetrosEmpresaToolStripMenuItem.Click += new System.EventHandler(this.parámetrosEmpresaToolStripMenuItem_Click);
            // 
            // parametrosComisionesToolStripMenuItem
            // 
            this.parametrosComisionesToolStripMenuItem.Image = global::FullCarMultimarca.UI.Properties.Resources.parametros;
            this.parametrosComisionesToolStripMenuItem.Name = "parametrosComisionesToolStripMenuItem";
            this.parametrosComisionesToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.parametrosComisionesToolStripMenuItem.Tag = "PS1011";
            this.parametrosComisionesToolStripMenuItem.Text = "Parámetros Comisiones";
            this.parametrosComisionesToolStripMenuItem.Click += new System.EventHandler(this.parametrosComisionesToolStripMenuItem_Click);
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stockToolStripMenuItem,
            this.operacionesToolStripMenuItem,
            this.operacionesPendientesDeAutorizaciónToolStripMenuItem});
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ventasToolStripMenuItem.Text = "Ventas";
            // 
            // stockToolStripMenuItem
            // 
            this.stockToolStripMenuItem.Image = global::FullCarMultimarca.UI.Properties.Resources.stock;
            this.stockToolStripMenuItem.Name = "stockToolStripMenuItem";
            this.stockToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.stockToolStripMenuItem.Tag = "PS2001";
            this.stockToolStripMenuItem.Text = "Stock";
            this.stockToolStripMenuItem.Click += new System.EventHandler(this.stockToolStripMenuItem_Click);
            // 
            // operacionesToolStripMenuItem
            // 
            this.operacionesToolStripMenuItem.Image = global::FullCarMultimarca.UI.Properties.Resources.contract;
            this.operacionesToolStripMenuItem.Name = "operacionesToolStripMenuItem";
            this.operacionesToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.operacionesToolStripMenuItem.Tag = "PS2003";
            this.operacionesToolStripMenuItem.Text = "Operaciones";
            this.operacionesToolStripMenuItem.Click += new System.EventHandler(this.operacionesToolStripMenuItem_Click);
            // 
            // operacionesPendientesDeAutorizaciónToolStripMenuItem
            // 
            this.operacionesPendientesDeAutorizaciónToolStripMenuItem.Image = global::FullCarMultimarca.UI.Properties.Resources.Autorizar;
            this.operacionesPendientesDeAutorizaciónToolStripMenuItem.Name = "operacionesPendientesDeAutorizaciónToolStripMenuItem";
            this.operacionesPendientesDeAutorizaciónToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.operacionesPendientesDeAutorizaciónToolStripMenuItem.Tag = "PS2007";
            this.operacionesPendientesDeAutorizaciónToolStripMenuItem.Text = "Autorización de Operaciones";
            this.operacionesPendientesDeAutorizaciónToolStripMenuItem.Click += new System.EventHandler(this.operacionesPendientesDeAutorizaciónToolStripMenuItem_Click);
            // 
            // liquidacionesToolStripMenuItem
            // 
            this.liquidacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.liquidarComisionesToolStripMenuItem,
            this.liquidacionesToolStripMenuItem1});
            this.liquidacionesToolStripMenuItem.Name = "liquidacionesToolStripMenuItem";
            this.liquidacionesToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.liquidacionesToolStripMenuItem.Text = "Liquidaciones";
            // 
            // liquidarComisionesToolStripMenuItem
            // 
            this.liquidarComisionesToolStripMenuItem.Image = global::FullCarMultimarca.UI.Properties.Resources.calcularLiquidacion;
            this.liquidarComisionesToolStripMenuItem.Name = "liquidarComisionesToolStripMenuItem";
            this.liquidarComisionesToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.liquidarComisionesToolStripMenuItem.Tag = "PS3002";
            this.liquidarComisionesToolStripMenuItem.Text = "Liquidar Comisiones";
            this.liquidarComisionesToolStripMenuItem.Click += new System.EventHandler(this.liquidarComisionesToolStripMenuItem_Click);
            // 
            // liquidacionesToolStripMenuItem1
            // 
            this.liquidacionesToolStripMenuItem1.Image = global::FullCarMultimarca.UI.Properties.Resources.liquidacion;
            this.liquidacionesToolStripMenuItem1.Name = "liquidacionesToolStripMenuItem1";
            this.liquidacionesToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.liquidacionesToolStripMenuItem1.Tag = "PS3001";
            this.liquidacionesToolStripMenuItem1.Text = "Liquidaciones";
            this.liquidacionesToolStripMenuItem1.Click += new System.EventHandler(this.liquidacionesToolStripMenuItem1_Click);
            // 
            // resumenPorActividadToolStripMenuItem
            // 
            this.resumenPorActividadToolStripMenuItem.Name = "resumenPorActividadToolStripMenuItem";
            this.resumenPorActividadToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // liquidacionPorProfesorToolStripMenuItem
            // 
            this.liquidacionPorProfesorToolStripMenuItem.Name = "liquidacionPorProfesorToolStripMenuItem";
            this.liquidacionPorProfesorToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // resumenMensualToolStripMenuItem
            // 
            this.resumenMensualToolStripMenuItem.Name = "resumenMensualToolStripMenuItem";
            this.resumenMensualToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // diagramaDeClasesToolStripMenuItem
            // 
            this.diagramaDeClasesToolStripMenuItem.Name = "diagramaDeClasesToolStripMenuItem";
            this.diagramaDeClasesToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // especificaciónDelSistemaToolStripMenuItem
            // 
            this.especificaciónDelSistemaToolStripMenuItem.Name = "especificaciónDelSistemaToolStripMenuItem";
            this.especificaciónDelSistemaToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::FullCarMultimarca.UI.Properties.Resources.LogoFullCar;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(955, 580);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(971, 619);
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FULL CAR Multimarca - Martin Reina";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.Shown += new System.EventHandler(this.FormMenu_Shown);
            this.Resize += new System.EventHandler(this.FormMenu_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarDeUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaDeUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarClaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem verLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumenPorActividadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liquidacionPorProfesorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumenMensualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diagramaDeClasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem especificaciónDelSistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modiciarPalabraClaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parametrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónPermisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem gestiónDeBackupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coloresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formasDePagoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parámetrosEmpresaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parametrosComisionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockToolStripMenuItem;
        private System.Windows.Forms.Timer timerVencimientoOfertas;
        private System.Windows.Forms.ToolStripMenuItem operacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operacionesPendientesDeAutorizaciónToolStripMenuItem;
        private System.Windows.Forms.Timer timerNotificacionOperaciones;
        private System.Windows.Forms.ToolStripMenuItem tiposDeContactoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liquidacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liquidarComisionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liquidacionesToolStripMenuItem1;
    }
}

