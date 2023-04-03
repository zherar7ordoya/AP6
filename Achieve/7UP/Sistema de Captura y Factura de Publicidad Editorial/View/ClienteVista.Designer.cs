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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClienteVista));
            this.materialButton1 = new ReaLTaiizor.Controls.MaterialButton();
            this.materialButton2 = new ReaLTaiizor.Controls.MaterialButton();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.EstadoCtrl = new System.Windows.Forms.ToolStripStatusLabel();
            this.ClientesCtrl = new ReaLTaiizor.Controls.PoisonDataGridView();
            this.materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            this.NombreCtrl = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            this.materialButton3 = new ReaLTaiizor.Controls.MaterialButton();
            this.materialLabel2 = new ReaLTaiizor.Controls.MaterialLabel();
            this.FechaAltaCtrl = new ReaLTaiizor.Controls.PoisonDateTime();
            this.ActivoCtrl = new ReaLTaiizor.Controls.MaterialCheckBox();
            this.IdCtrl = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            this.materialLabel3 = new ReaLTaiizor.Controls.MaterialLabel();
            this.materialButton4 = new ReaLTaiizor.Controls.MaterialButton();
            this.ribbonGroupBox1 = new ReaLTaiizor.Controls.RibbonGroupBox();
            this.StatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientesCtrl)).BeginInit();
            this.ribbonGroupBox1.SuspendLayout();
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
            this.materialButton1.Location = new System.Drawing.Point(544, 337);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
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
            this.materialButton2.Location = new System.Drawing.Point(616, 337);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
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
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EstadoCtrl});
            this.StatusStrip.Location = new System.Drawing.Point(3, 430);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(841, 22);
            this.StatusStrip.TabIndex = 16;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // EstadoCtrl
            // 
            this.EstadoCtrl.Name = "EstadoCtrl";
            this.EstadoCtrl.Size = new System.Drawing.Size(32, 17);
            this.EstadoCtrl.Text = "Listo";
            // 
            // ClientesCtrl
            // 
            this.ClientesCtrl.AllowUserToAddRows = false;
            this.ClientesCtrl.AllowUserToDeleteRows = false;
            this.ClientesCtrl.AllowUserToResizeRows = false;
            this.ClientesCtrl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ClientesCtrl.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientesCtrl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ClientesCtrl.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ClientesCtrl.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ClientesCtrl.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ClientesCtrl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ClientesCtrl.DefaultCellStyle = dataGridViewCellStyle2;
            this.ClientesCtrl.EnableHeadersVisualStyles = false;
            this.ClientesCtrl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ClientesCtrl.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientesCtrl.Location = new System.Drawing.Point(15, 80);
            this.ClientesCtrl.Name = "ClientesCtrl";
            this.ClientesCtrl.ReadOnly = true;
            this.ClientesCtrl.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ClientesCtrl.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ClientesCtrl.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ClientesCtrl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ClientesCtrl.Size = new System.Drawing.Size(396, 293);
            this.ClientesCtrl.TabIndex = 1;
            this.ClientesCtrl.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClientesCtrl_RowEnter);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(22, 106);
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
            this.NombreCtrl.Location = new System.Drawing.Point(125, 93);
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
            this.NombreCtrl.Size = new System.Drawing.Size(255, 48);
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
            this.materialButton3.Location = new System.Drawing.Point(688, 337);
            this.materialButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
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
            this.materialLabel2.Location = new System.Drawing.Point(22, 155);
            this.materialLabel2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(97, 19);
            this.materialLabel2.TabIndex = 15;
            this.materialLabel2.Text = "Fecha de Alta";
            // 
            // FechaAltaCtrl
            // 
            this.FechaAltaCtrl.Location = new System.Drawing.Point(125, 147);
            this.FechaAltaCtrl.MinimumSize = new System.Drawing.Size(0, 29);
            this.FechaAltaCtrl.Name = "FechaAltaCtrl";
            this.FechaAltaCtrl.Size = new System.Drawing.Size(255, 29);
            this.FechaAltaCtrl.TabIndex = 4;
            this.FechaAltaCtrl.Value = new System.DateTime(2023, 9, 27, 0, 0, 0, 0);
            // 
            // ActivoCtrl
            // 
            this.ActivoCtrl.AutoSize = true;
            this.ActivoCtrl.Checked = true;
            this.ActivoCtrl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ActivoCtrl.Depth = 0;
            this.ActivoCtrl.Location = new System.Drawing.Point(125, 179);
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
            this.IdCtrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.IdCtrl.HideSelection = true;
            this.IdCtrl.LeadingIcon = null;
            this.IdCtrl.Location = new System.Drawing.Point(125, 39);
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
            this.IdCtrl.Size = new System.Drawing.Size(103, 48);
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
            this.materialLabel3.Location = new System.Drawing.Point(22, 53);
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
            this.materialButton4.Location = new System.Drawing.Point(277, 180);
            this.materialButton4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
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
            // ribbonGroupBox1
            // 
            this.ribbonGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.ribbonGroupBox1.BaseColor = System.Drawing.Color.Transparent;
            this.ribbonGroupBox1.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.ribbonGroupBox1.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(178)))), ((int)(((byte)(172)))));
            this.ribbonGroupBox1.BorderColorC = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(192)))), ((int)(((byte)(200)))));
            this.ribbonGroupBox1.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            this.ribbonGroupBox1.Controls.Add(this.IdCtrl);
            this.ribbonGroupBox1.Controls.Add(this.materialButton4);
            this.ribbonGroupBox1.Controls.Add(this.materialLabel1);
            this.ribbonGroupBox1.Controls.Add(this.NombreCtrl);
            this.ribbonGroupBox1.Controls.Add(this.materialLabel3);
            this.ribbonGroupBox1.Controls.Add(this.materialLabel2);
            this.ribbonGroupBox1.Controls.Add(this.ActivoCtrl);
            this.ribbonGroupBox1.Controls.Add(this.FechaAltaCtrl);
            this.ribbonGroupBox1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ribbonGroupBox1.ForeColor = System.Drawing.Color.Black;
            this.ribbonGroupBox1.LineColorA = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(126)))), ((int)(((byte)(126)))));
            this.ribbonGroupBox1.LineColorB = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(126)))), ((int)(((byte)(126)))));
            this.ribbonGroupBox1.Location = new System.Drawing.Point(417, 80);
            this.ribbonGroupBox1.Name = "ribbonGroupBox1";
            this.ribbonGroupBox1.Size = new System.Drawing.Size(396, 248);
            this.ribbonGroupBox1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.ribbonGroupBox1.TabIndex = 20;
            this.ribbonGroupBox1.Text = "Datos del Cliente";
            // 
            // ClienteVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 455);
            this.Controls.Add(this.ribbonGroupBox1);
            this.Controls.Add(this.materialButton2);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.materialButton3);
            this.Controls.Add(this.ClientesCtrl);
            this.Controls.Add(this.StatusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClienteVista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM Clientes";
            this.Load += new System.EventHandler(this.ClienteVista_Load);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientesCtrl)).EndInit();
            this.ribbonGroupBox1.ResumeLayout(false);
            this.ribbonGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ReaLTaiizor.Controls.MaterialButton materialButton1;
        private ReaLTaiizor.Controls.MaterialButton materialButton2;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel EstadoCtrl;
        private ReaLTaiizor.Controls.PoisonDataGridView ClientesCtrl;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit NombreCtrl;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel2;
        private ReaLTaiizor.Controls.MaterialButton materialButton3;
        private ReaLTaiizor.Controls.MaterialCheckBox ActivoCtrl;
        private ReaLTaiizor.Controls.PoisonDateTime FechaAltaCtrl;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit IdCtrl;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel3;
        private ReaLTaiizor.Controls.MaterialButton materialButton4;
        private ReaLTaiizor.Controls.RibbonGroupBox ribbonGroupBox1;
    }
}

