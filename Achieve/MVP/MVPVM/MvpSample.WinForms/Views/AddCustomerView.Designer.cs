using CustomerViewModel=MvpSample.Common.ViewModels.CustomerViewModel;

namespace MvpSample.WinForms.Views
{
    partial class AddCustomerView
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
            System.Windows.Forms.Label companyNameLabel;
            System.Windows.Forms.Label contactNameLabel;
            System.Windows.Forms.Label dateOfBirthLabel;
            this.companyNameTextBox = new System.Windows.Forms.TextBox();
            this.contactNameTextBox = new System.Windows.Forms.TextBox();
            this.m_btnSave = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.cusomerViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dateOfBirthDateTimePicker = new System.Windows.Forms.DateTimePicker();
            companyNameLabel = new System.Windows.Forms.Label();
            contactNameLabel = new System.Windows.Forms.Label();
            dateOfBirthLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cusomerViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // companyNameLabel
            // 
            companyNameLabel.AutoSize = true;
            companyNameLabel.Location = new System.Drawing.Point(24, 49);
            companyNameLabel.Name = "companyNameLabel";
            companyNameLabel.Size = new System.Drawing.Size(54, 13);
            companyNameLabel.TabIndex = 3;
            companyNameLabel.Text = "Company:";
            // 
            // contactNameLabel
            // 
            contactNameLabel.AutoSize = true;
            contactNameLabel.Location = new System.Drawing.Point(24, 15);
            contactNameLabel.Name = "contactNameLabel";
            contactNameLabel.Size = new System.Drawing.Size(38, 13);
            contactNameLabel.TabIndex = 5;
            contactNameLabel.Text = "Name:";
            // 
            // companyNameTextBox
            // 
            this.companyNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cusomerViewModelBindingSource, "CompanyName", true));
            this.companyNameTextBox.Location = new System.Drawing.Point(92, 46);
            this.companyNameTextBox.Name = "companyNameTextBox";
            this.companyNameTextBox.Size = new System.Drawing.Size(208, 20);
            this.companyNameTextBox.TabIndex = 4;
            // 
            // contactNameTextBox
            // 
            this.contactNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cusomerViewModelBindingSource, "Name", true));
            this.contactNameTextBox.Location = new System.Drawing.Point(92, 12);
            this.contactNameTextBox.Name = "contactNameTextBox";
            this.contactNameTextBox.Size = new System.Drawing.Size(208, 20);
            this.contactNameTextBox.TabIndex = 6;
            // 
            // m_btnSave
            // 
            this.m_btnSave.Location = new System.Drawing.Point(28, 126);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Size = new System.Drawing.Size(75, 23);
            this.m_btnSave.TabIndex = 7;
            this.m_btnSave.Text = "&Save";
            this.m_btnSave.UseVisualStyleBackColor = true;
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Location = new System.Drawing.Point(109, 126);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
            this.m_btnCancel.TabIndex = 8;
            this.m_btnCancel.Text = "&Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // cusomerViewModelBindingSource
            // 
            this.cusomerViewModelBindingSource.DataSource = typeof(MvpSample.Common.ViewModels.CustomerViewModel);
            // 
            // dateOfBirthLabel
            // 
            dateOfBirthLabel.AutoSize = true;
            dateOfBirthLabel.Location = new System.Drawing.Point(23, 89);
            dateOfBirthLabel.Name = "dateOfBirthLabel";
            dateOfBirthLabel.Size = new System.Drawing.Size(71, 13);
            dateOfBirthLabel.TabIndex = 8;
            dateOfBirthLabel.Text = "Date Of Birth:";
            // 
            // dateOfBirthDateTimePicker
            // 
            this.dateOfBirthDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.cusomerViewModelBindingSource, "DateOfBirth", true));
            this.dateOfBirthDateTimePicker.Location = new System.Drawing.Point(100, 85);
            this.dateOfBirthDateTimePicker.Name = "dateOfBirthDateTimePicker";
            this.dateOfBirthDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateOfBirthDateTimePicker.TabIndex = 9;
            // 
            // AddCustomerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 161);
            this.Controls.Add(dateOfBirthLabel);
            this.Controls.Add(this.dateOfBirthDateTimePicker);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_btnSave);
            this.Controls.Add(companyNameLabel);
            this.Controls.Add(this.companyNameTextBox);
            this.Controls.Add(contactNameLabel);
            this.Controls.Add(this.contactNameTextBox);
            this.Name = "AddCustomerView";
            this.Text = "Add Customer";
            ((System.ComponentModel.ISupportInitialize)(this.cusomerViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource cusomerViewModelBindingSource;
        private System.Windows.Forms.TextBox companyNameTextBox;
        private System.Windows.Forms.TextBox contactNameTextBox;
        private System.Windows.Forms.Button m_btnSave;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.DateTimePicker dateOfBirthDateTimePicker;
    }
}