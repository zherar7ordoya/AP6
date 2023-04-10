namespace View
{
    partial class ClienteVista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClienteVista));
            this.materialButton1 = new ReaLTaiizor.Controls.MaterialButton();
            this.materialButton2 = new ReaLTaiizor.Controls.MaterialButton();
            this.materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            this.NombreCtrl = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            this.materialButton3 = new ReaLTaiizor.Controls.MaterialButton();
            this.materialLabel2 = new ReaLTaiizor.Controls.MaterialLabel();
            this.FechaAltaCtrl = new ReaLTaiizor.Controls.PoisonDateTime();
            this.ActivoCtrl = new ReaLTaiizor.Controls.MaterialCheckBox();
            this.IdCtrl = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            this.materialLabel3 = new ReaLTaiizor.Controls.MaterialLabel();
            this.materialButton4 = new ReaLTaiizor.Controls.MaterialButton();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.EstadoCtrl = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ClientesCtrl = new System.Windows.Forms.DataGridView();
            this.StatusStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientesCtrl)).BeginInit();
            this.SuspendLayout();
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            this.materialButton1.Location = new System.Drawing.Point(524, 276);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.materialButton1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(64, 36);
            this.materialButton1.TabIndex = 7;
            this.materialButton1.Text = "Alta";
            this.materialButton1.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = null;
            this.materialButton2.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            this.materialButton2.Location = new System.Drawing.Point(593, 276);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.materialButton2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton2.Size = new System.Drawing.Size(64, 36);
            this.materialButton2.TabIndex = 8;
            this.materialButton2.Text = "Baja";
            this.materialButton2.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(24, 71);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.materialLabel1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(57, 19);
            this.materialLabel1.TabIndex = 13;
            this.materialLabel1.Text = "Nombre";
            // 
            // NombreCtrl
            // 
            this.NombreCtrl.AnimateReadOnly = false;
            this.NombreCtrl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.NombreCtrl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.NombreCtrl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.NombreCtrl.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.NombreCtrl.Depth = 0;
            this.NombreCtrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.NombreCtrl.HideSelection = true;
            this.NombreCtrl.LeadingIcon = null;
            this.NombreCtrl.Location = new System.Drawing.Point(121, 71);
            this.NombreCtrl.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.NombreCtrl.MaxLength = 32767;
            this.NombreCtrl.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.NombreCtrl.Name = "NombreCtrl";
            this.NombreCtrl.PasswordChar = '\0';
            this.NombreCtrl.PrefixSuffixText = null;
            this.NombreCtrl.ReadOnly = false;
            this.NombreCtrl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.NombreCtrl.SelectedText = "";
            this.NombreCtrl.SelectionLength = 0;
            this.NombreCtrl.SelectionStart = 0;
            this.NombreCtrl.ShortcutsEnabled = true;
            this.NombreCtrl.Size = new System.Drawing.Size(236, 48);
            this.NombreCtrl.TabIndex = 3;
            this.NombreCtrl.TabStop = false;
            this.NombreCtrl.Text = "Gerardo Tordoya";
            this.NombreCtrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.NombreCtrl.TrailingIcon = null;
            this.NombreCtrl.UseSystemPasswordChar = false;
            // 
            // materialButton3
            // 
            this.materialButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton3.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton3.Depth = 0;
            this.materialButton3.HighEmphasis = true;
            this.materialButton3.Icon = null;
            this.materialButton3.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            this.materialButton3.Location = new System.Drawing.Point(662, 276);
            this.materialButton3.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.materialButton3.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialButton3.Name = "materialButton3";
            this.materialButton3.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton3.Size = new System.Drawing.Size(125, 36);
            this.materialButton3.TabIndex = 9;
            this.materialButton3.Text = "Modificación";
            this.materialButton3.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton3.UseAccentColor = false;
            this.materialButton3.UseVisualStyleBackColor = true;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(24, 119);
            this.materialLabel2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.materialLabel2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(97, 19);
            this.materialLabel2.TabIndex = 15;
            this.materialLabel2.Text = "Fecha de Alta";
            // 
            // FechaAltaCtrl
            // 
            this.FechaAltaCtrl.Location = new System.Drawing.Point(121, 119);
            this.FechaAltaCtrl.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.FechaAltaCtrl.MinimumSize = new System.Drawing.Size(0, 29);
            this.FechaAltaCtrl.Name = "FechaAltaCtrl";
            this.FechaAltaCtrl.Size = new System.Drawing.Size(237, 29);
            this.FechaAltaCtrl.TabIndex = 4;
            this.FechaAltaCtrl.Value = new System.DateTime(2023, 9, 27, 0, 0, 0, 0);
            // 
            // ActivoCtrl
            // 
            this.ActivoCtrl.AutoSize = true;
            this.ActivoCtrl.Checked = true;
            this.ActivoCtrl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ActivoCtrl.Depth = 0;
            this.ActivoCtrl.Location = new System.Drawing.Point(121, 154);
            this.ActivoCtrl.Margin = new System.Windows.Forms.Padding(0);
            this.ActivoCtrl.MouseLocation = new System.Drawing.Point(-1, -1);
            this.ActivoCtrl.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.ActivoCtrl.Name = "ActivoCtrl";
            this.ActivoCtrl.ReadOnly = false;
            this.ActivoCtrl.Ripple = true;
            this.ActivoCtrl.Size = new System.Drawing.Size(79, 37);
            this.ActivoCtrl.TabIndex = 5;
            this.ActivoCtrl.Text = "Activo";
            this.ActivoCtrl.UseAccentColor = false;
            this.ActivoCtrl.UseVisualStyleBackColor = true;
            // 
            // IdCtrl
            // 
            this.IdCtrl.AnimateReadOnly = false;
            this.IdCtrl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.IdCtrl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.IdCtrl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.IdCtrl.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.IdCtrl.Depth = 0;
            this.IdCtrl.Enabled = false;
            this.IdCtrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.IdCtrl.HideSelection = true;
            this.IdCtrl.LeadingIcon = null;
            this.IdCtrl.Location = new System.Drawing.Point(121, 22);
            this.IdCtrl.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.IdCtrl.MaxLength = 32767;
            this.IdCtrl.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.IdCtrl.Name = "IdCtrl";
            this.IdCtrl.PasswordChar = '\0';
            this.IdCtrl.PrefixSuffixText = null;
            this.IdCtrl.ReadOnly = false;
            this.IdCtrl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.IdCtrl.SelectedText = "";
            this.IdCtrl.SelectionLength = 0;
            this.IdCtrl.SelectionStart = 0;
            this.IdCtrl.ShortcutsEnabled = true;
            this.IdCtrl.Size = new System.Drawing.Size(92, 48);
            this.IdCtrl.TabIndex = 2;
            this.IdCtrl.TabStop = false;
            this.IdCtrl.Text = "1";
            this.IdCtrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.IdCtrl.TrailingIcon = null;
            this.IdCtrl.UseSystemPasswordChar = false;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(24, 22);
            this.materialLabel3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.materialLabel3.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(14, 19);
            this.materialLabel3.TabIndex = 18;
            this.materialLabel3.Text = "Id";
            // 
            // materialButton4
            // 
            this.materialButton4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton4.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton4.Depth = 0;
            this.materialButton4.HighEmphasis = true;
            this.materialButton4.Icon = null;
            this.materialButton4.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            this.materialButton4.Location = new System.Drawing.Point(266, 153);
            this.materialButton4.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.materialButton4.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialButton4.Name = "materialButton4";
            this.materialButton4.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton4.Size = new System.Drawing.Size(103, 36);
            this.materialButton4.TabIndex = 6;
            this.materialButton4.Text = "Teléfonos";
            this.materialButton4.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton4.UseAccentColor = false;
            this.materialButton4.UseVisualStyleBackColor = true;
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EstadoCtrl});
            this.StatusStrip.Location = new System.Drawing.Point(5, 351);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 18, 0);
            this.StatusStrip.Size = new System.Drawing.Size(791, 22);
            this.StatusStrip.TabIndex = 21;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // EstadoCtrl
            // 
            this.EstadoCtrl.Name = "EstadoCtrl";
            this.EstadoCtrl.Size = new System.Drawing.Size(94, 17);
            this.EstadoCtrl.Text = "Gerardo Tordoya";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IdCtrl);
            this.groupBox1.Controls.Add(this.materialButton4);
            this.groupBox1.Controls.Add(this.FechaAltaCtrl);
            this.groupBox1.Controls.Add(this.materialLabel1);
            this.groupBox1.Controls.Add(this.ActivoCtrl);
            this.groupBox1.Controls.Add(this.NombreCtrl);
            this.groupBox1.Controls.Add(this.materialLabel2);
            this.groupBox1.Controls.Add(this.materialLabel3);
            this.groupBox1.Location = new System.Drawing.Point(397, 65);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox1.Size = new System.Drawing.Size(376, 200);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Cliente";
            // 
            // ClientesCtrl
            // 
            this.ClientesCtrl.AllowUserToAddRows = false;
            this.ClientesCtrl.AllowUserToDeleteRows = false;
            this.ClientesCtrl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            this.ClientesCtrl.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ClientesCtrl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClientesCtrl.Location = new System.Drawing.Point(11, 71);
            this.ClientesCtrl.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.ClientesCtrl.Name = "ClientesCtrl";
            this.ClientesCtrl.ReadOnly = true;
            this.ClientesCtrl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ClientesCtrl.Size = new System.Drawing.Size(376, 241);
            this.ClientesCtrl.TabIndex = 23;
            // 
            // ClienteVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 376);
            this.Controls.Add(this.ClientesCtrl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.materialButton2);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.materialButton3);
            this.Font = new System.Drawing.Font("Cascadia Mono", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClienteVista";
            this.Padding = new System.Windows.Forms.Padding(5, 84, 5, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM Clientes";
            this.Load += new System.EventHandler(this.ClienteVista_Load);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientesCtrl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ReaLTaiizor.Controls.MaterialButton materialButton1;
        private ReaLTaiizor.Controls.MaterialButton materialButton2;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit NombreCtrl;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel2;
        private ReaLTaiizor.Controls.MaterialButton materialButton3;
        private ReaLTaiizor.Controls.MaterialCheckBox ActivoCtrl;
        private ReaLTaiizor.Controls.PoisonDateTime FechaAltaCtrl;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit IdCtrl;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel3;
        private ReaLTaiizor.Controls.MaterialButton materialButton4;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel EstadoCtrl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView ClientesCtrl;
    }
}

