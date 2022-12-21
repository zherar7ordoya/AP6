
namespace FullCarMultimarca.UI.Seguridad
{
    partial class FormPermisos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPermisos));
            this.trvPermisos = new System.Windows.Forms.TreeView();
            this.txtPCCodigo = new System.Windows.Forms.TextBox();
            this.lblLogon = new System.Windows.Forms.Label();
            this.ckOtorgado = new System.Windows.Forms.CheckBox();
            this.cmbPermiso = new System.Windows.Forms.ComboBox();
            this.lblTipoProducto = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPCDescripcion = new System.Windows.Forms.TextBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminarCompuesto = new System.Windows.Forms.Button();
            this.btnEliminarPermiso = new System.Windows.Forms.Button();
            this.btnAgregarPermiso = new System.Windows.Forms.Button();
            this.txtPermiso = new System.Windows.Forms.TextBox();
            this.btnEditarPermiso = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregarPermisoSimple = new System.Windows.Forms.Button();
            this.ckOtorgarNuevoPermiso = new System.Windows.Forms.CheckBox();
            this.grupoPermisoCompuesto = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grupoPermisoCompuesto.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvPermisos
            // 
            this.trvPermisos.Dock = System.Windows.Forms.DockStyle.Left;
            this.trvPermisos.Location = new System.Drawing.Point(0, 0);
            this.trvPermisos.Name = "trvPermisos";
            this.trvPermisos.Size = new System.Drawing.Size(254, 498);
            this.trvPermisos.TabIndex = 0;
            // 
            // txtPCCodigo
            // 
            this.txtPCCodigo.Location = new System.Drawing.Point(74, 58);
            this.txtPCCodigo.MaxLength = 5;
            this.txtPCCodigo.Name = "txtPCCodigo";
            this.txtPCCodigo.ReadOnly = true;
            this.txtPCCodigo.Size = new System.Drawing.Size(73, 20);
            this.txtPCCodigo.TabIndex = 48;
            // 
            // lblLogon
            // 
            this.lblLogon.AutoSize = true;
            this.lblLogon.Location = new System.Drawing.Point(28, 61);
            this.lblLogon.Name = "lblLogon";
            this.lblLogon.Size = new System.Drawing.Size(40, 13);
            this.lblLogon.TabIndex = 50;
            this.lblLogon.Text = "Código";
            this.lblLogon.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ckOtorgado
            // 
            this.ckOtorgado.AutoSize = true;
            this.ckOtorgado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckOtorgado.Enabled = false;
            this.ckOtorgado.Location = new System.Drawing.Point(283, 48);
            this.ckOtorgado.Name = "ckOtorgado";
            this.ckOtorgado.Size = new System.Drawing.Size(72, 17);
            this.ckOtorgado.TabIndex = 4;
            this.ckOtorgado.Text = "Conceder";
            this.ckOtorgado.UseVisualStyleBackColor = true;
            // 
            // cmbPermiso
            // 
            this.cmbPermiso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPermiso.FormattingEnabled = true;
            this.cmbPermiso.Location = new System.Drawing.Point(103, 79);
            this.cmbPermiso.Name = "cmbPermiso";
            this.cmbPermiso.Size = new System.Drawing.Size(252, 21);
            this.cmbPermiso.TabIndex = 51;
            // 
            // lblTipoProducto
            // 
            this.lblTipoProducto.AutoSize = true;
            this.lblTipoProducto.Location = new System.Drawing.Point(6, 23);
            this.lblTipoProducto.Name = "lblTipoProducto";
            this.lblTipoProducto.Size = new System.Drawing.Size(91, 13);
            this.lblTipoProducto.TabIndex = 52;
            this.lblTipoProducto.Text = "Permiso Asignado";
            this.lblTipoProducto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(721, 463);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(69, 23);
            this.btnCancelar.TabIndex = 54;
            this.btnCancelar.Text = "Cerrar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 56;
            this.label2.Text = "Descripción";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtPCDescripcion
            // 
            this.txtPCDescripcion.Location = new System.Drawing.Point(74, 84);
            this.txtPCDescripcion.MaxLength = 50;
            this.txtPCDescripcion.Name = "txtPCDescripcion";
            this.txtPCDescripcion.ReadOnly = true;
            this.txtPCDescripcion.Size = new System.Drawing.Size(281, 20);
            this.txtPCDescripcion.TabIndex = 57;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Enabled = false;
            this.btnActualizar.Image = global::FullCarMultimarca.UI.Properties.Resources.refresh1;
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.Location = new System.Drawing.Point(361, 44);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(156, 23);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.Text = "Actualizar asignacion...";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminarCompuesto
            // 
            this.btnEliminarCompuesto.Enabled = false;
            this.btnEliminarCompuesto.Image = global::FullCarMultimarca.UI.Properties.Resources.delete2;
            this.btnEliminarCompuesto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarCompuesto.Location = new System.Drawing.Point(361, 82);
            this.btnEliminarCompuesto.Name = "btnEliminarCompuesto";
            this.btnEliminarCompuesto.Size = new System.Drawing.Size(156, 23);
            this.btnEliminarCompuesto.TabIndex = 2;
            this.btnEliminarCompuesto.Text = "Eliminar compuesto...";
            this.btnEliminarCompuesto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarCompuesto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminarCompuesto.UseVisualStyleBackColor = true;
            this.btnEliminarCompuesto.Click += new System.EventHandler(this.btnEliminarCompuesto_Click);
            // 
            // btnEliminarPermiso
            // 
            this.btnEliminarPermiso.Enabled = false;
            this.btnEliminarPermiso.Image = global::FullCarMultimarca.UI.Properties.Resources.delete2;
            this.btnEliminarPermiso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarPermiso.Location = new System.Drawing.Point(361, 18);
            this.btnEliminarPermiso.Name = "btnEliminarPermiso";
            this.btnEliminarPermiso.Size = new System.Drawing.Size(156, 23);
            this.btnEliminarPermiso.TabIndex = 3;
            this.btnEliminarPermiso.Text = "Desasignar permiso...";
            this.btnEliminarPermiso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarPermiso.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminarPermiso.UseVisualStyleBackColor = true;
            this.btnEliminarPermiso.Click += new System.EventHandler(this.btnEliminarPermiso_Click);
            // 
            // btnAgregarPermiso
            // 
            this.btnAgregarPermiso.Image = global::FullCarMultimarca.UI.Properties.Resources.add2;
            this.btnAgregarPermiso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarPermiso.Location = new System.Drawing.Point(402, 19);
            this.btnAgregarPermiso.Name = "btnAgregarPermiso";
            this.btnAgregarPermiso.Size = new System.Drawing.Size(115, 35);
            this.btnAgregarPermiso.TabIndex = 6;
            this.btnAgregarPermiso.Text = "Nuevo Permiso Compuesto...";
            this.btnAgregarPermiso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarPermiso.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarPermiso.UseVisualStyleBackColor = true;
            this.btnAgregarPermiso.Click += new System.EventHandler(this.btnAgregarPermiso_Click);
            // 
            // txtPermiso
            // 
            this.txtPermiso.Location = new System.Drawing.Point(103, 20);
            this.txtPermiso.MaxLength = 50;
            this.txtPermiso.Name = "txtPermiso";
            this.txtPermiso.ReadOnly = true;
            this.txtPermiso.Size = new System.Drawing.Size(252, 20);
            this.txtPermiso.TabIndex = 63;
            this.txtPermiso.TabStop = false;
            // 
            // btnEditarPermiso
            // 
            this.btnEditarPermiso.Enabled = false;
            this.btnEditarPermiso.Image = global::FullCarMultimarca.UI.Properties.Resources.document_edit;
            this.btnEditarPermiso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarPermiso.Location = new System.Drawing.Point(153, 56);
            this.btnEditarPermiso.Name = "btnEditarPermiso";
            this.btnEditarPermiso.Size = new System.Drawing.Size(130, 23);
            this.btnEditarPermiso.TabIndex = 1;
            this.btnEditarPermiso.Text = "Editar compuesto...";
            this.btnEditarPermiso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarPermiso.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditarPermiso.UseVisualStyleBackColor = true;
            this.btnEditarPermiso.Click += new System.EventHandler(this.btnEditarPermiso_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 64;
            this.label1.Text = "Asignar Permiso";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnAgregarPermisoSimple
            // 
            this.btnAgregarPermisoSimple.Enabled = false;
            this.btnAgregarPermisoSimple.Image = global::FullCarMultimarca.UI.Properties.Resources.add2;
            this.btnAgregarPermisoSimple.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarPermisoSimple.Location = new System.Drawing.Point(361, 77);
            this.btnAgregarPermisoSimple.Name = "btnAgregarPermisoSimple";
            this.btnAgregarPermisoSimple.Size = new System.Drawing.Size(156, 23);
            this.btnAgregarPermisoSimple.TabIndex = 65;
            this.btnAgregarPermisoSimple.Text = "Asignar permiso...";
            this.btnAgregarPermisoSimple.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarPermisoSimple.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarPermisoSimple.UseVisualStyleBackColor = true;
            this.btnAgregarPermisoSimple.Click += new System.EventHandler(this.btnAgregarPermisoSimple_Click);
            // 
            // ckOtorgarNuevoPermiso
            // 
            this.ckOtorgarNuevoPermiso.AutoSize = true;
            this.ckOtorgarNuevoPermiso.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckOtorgarNuevoPermiso.Checked = true;
            this.ckOtorgarNuevoPermiso.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckOtorgarNuevoPermiso.Enabled = false;
            this.ckOtorgarNuevoPermiso.Location = new System.Drawing.Point(283, 106);
            this.ckOtorgarNuevoPermiso.Name = "ckOtorgarNuevoPermiso";
            this.ckOtorgarNuevoPermiso.Size = new System.Drawing.Size(72, 17);
            this.ckOtorgarNuevoPermiso.TabIndex = 66;
            this.ckOtorgarNuevoPermiso.Text = "Conceder";
            this.ckOtorgarNuevoPermiso.UseVisualStyleBackColor = true;
            // 
            // grupoPermisoCompuesto
            // 
            this.grupoPermisoCompuesto.Controls.Add(this.btnEditarPermiso);
            this.grupoPermisoCompuesto.Controls.Add(this.lblLogon);
            this.grupoPermisoCompuesto.Controls.Add(this.txtPCCodigo);
            this.grupoPermisoCompuesto.Controls.Add(this.label2);
            this.grupoPermisoCompuesto.Controls.Add(this.txtPCDescripcion);
            this.grupoPermisoCompuesto.Controls.Add(this.btnAgregarPermiso);
            this.grupoPermisoCompuesto.Controls.Add(this.btnEliminarCompuesto);
            this.grupoPermisoCompuesto.Location = new System.Drawing.Point(264, 8);
            this.grupoPermisoCompuesto.Name = "grupoPermisoCompuesto";
            this.grupoPermisoCompuesto.Size = new System.Drawing.Size(526, 118);
            this.grupoPermisoCompuesto.TabIndex = 67;
            this.grupoPermisoCompuesto.TabStop = false;
            this.grupoPermisoCompuesto.Text = "Permiso Compuesto seleccionado...";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAgregarPermisoSimple);
            this.groupBox1.Controls.Add(this.ckOtorgado);
            this.groupBox1.Controls.Add(this.ckOtorgarNuevoPermiso);
            this.groupBox1.Controls.Add(this.lblTipoProducto);
            this.groupBox1.Controls.Add(this.cmbPermiso);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnActualizar);
            this.groupBox1.Controls.Add(this.txtPermiso);
            this.groupBox1.Controls.Add(this.btnEliminarPermiso);
            this.groupBox1.Location = new System.Drawing.Point(264, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 128);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gestion de permisos asociados al compuesto";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(261, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(445, 33);
            this.label3.TabIndex = 69;
            this.label3.Text = "Los cambios realizados en esta pantalla de permisos tendrán efecto para el/los us" +
    "uarios afectados a partir de la proxima vez que ingresen al sistema.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 498);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grupoPermisoCompuesto);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.trvPermisos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 537);
            this.Name = "FormPermisos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Permisos";
            this.Load += new System.EventHandler(this.FormPermisos_Load);
            this.grupoPermisoCompuesto.ResumeLayout(false);
            this.grupoPermisoCompuesto.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trvPermisos;
        private System.Windows.Forms.TextBox txtPCCodigo;
        private System.Windows.Forms.Label lblLogon;
        private System.Windows.Forms.CheckBox ckOtorgado;
        private System.Windows.Forms.ComboBox cmbPermiso;
        private System.Windows.Forms.Label lblTipoProducto;
        protected System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPCDescripcion;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminarCompuesto;
        private System.Windows.Forms.Button btnEliminarPermiso;
        private System.Windows.Forms.Button btnAgregarPermiso;
        private System.Windows.Forms.TextBox txtPermiso;
        private System.Windows.Forms.Button btnEditarPermiso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregarPermisoSimple;
        private System.Windows.Forms.CheckBox ckOtorgarNuevoPermiso;
        private System.Windows.Forms.GroupBox grupoPermisoCompuesto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
    }
}