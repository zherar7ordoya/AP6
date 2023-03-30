using CustomerViewModel=MvpSample.Common.ViewModels.CustomerViewModel;

namespace MvpSample.WinForms.Views
{
    partial class CustomersView
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
            this.cusomerViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cusomerViewModelDataGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnAddCustomer = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.cusomerViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cusomerViewModelDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cusomerViewModelBindingSource
            // 
            this.cusomerViewModelBindingSource.DataSource = typeof(MvpSample.Common.ViewModels.CustomerViewModel);
            // 
            // cusomerViewModelDataGridView
            // 
            this.cusomerViewModelDataGridView.AutoGenerateColumns = false;
            this.cusomerViewModelDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.cusomerViewModelDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3});
            this.cusomerViewModelDataGridView.DataSource = this.cusomerViewModelBindingSource;
            this.cusomerViewModelDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cusomerViewModelDataGridView.Location = new System.Drawing.Point(0, 0);
            this.cusomerViewModelDataGridView.Name = "cusomerViewModelDataGridView";
            this.cusomerViewModelDataGridView.Size = new System.Drawing.Size(464, 270);
            this.cusomerViewModelDataGridView.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnAddCustomer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 270);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 55);
            this.panel1.TabIndex = 2;
            // 
            // m_btnAddCustomer
            // 
            this.m_btnAddCustomer.Location = new System.Drawing.Point(12, 20);
            this.m_btnAddCustomer.Name = "m_btnAddCustomer";
            this.m_btnAddCustomer.Size = new System.Drawing.Size(168, 23);
            this.m_btnAddCustomer.TabIndex = 0;
            this.m_btnAddCustomer.Text = "Add Customer";
            this.m_btnAddCustomer.UseVisualStyleBackColor = true;
            this.m_btnAddCustomer.Click += new System.EventHandler(this.m_btnAddCustomer_Click);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CompanyName";
            this.dataGridViewTextBoxColumn1.HeaderText = "Company";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Age";
            this.dataGridViewTextBoxColumn3.HeaderText = "Age";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // CustomersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 325);
            this.Controls.Add(this.cusomerViewModelDataGridView);
            this.Controls.Add(this.panel1);
            this.Name = "CustomersView";
            this.Text = "Customers";
            ((System.ComponentModel.ISupportInitialize)(this.cusomerViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cusomerViewModelDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource cusomerViewModelBindingSource;
        private System.Windows.Forms.DataGridView cusomerViewModelDataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_btnAddCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}