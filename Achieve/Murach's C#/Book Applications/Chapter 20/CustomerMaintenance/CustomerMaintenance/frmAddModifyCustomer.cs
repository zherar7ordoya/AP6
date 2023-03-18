﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

using CustomerMaintenance.Models.DataLayer;

namespace CustomerMaintenance
{
    public partial class frmAddModifyCustomer : Form
    {
        public Customers Customer { get; set; }
        public List<States> States { get; set; }
        public bool AddCustomer { get; set; }

        public frmAddModifyCustomer()
        {
            InitializeComponent();
        }

        private void frmAddModifyCustomer_Load(object sender, EventArgs e)
        {
            this.LoadStatesComboBox();
            if (this.AddCustomer)
            {
                this.Text = "Add Customer";
                cboStates.SelectedIndex = -1;
            }
            else
            {
                this.Text = "Modify Customer";
                this.DisplayCustomerData();
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (this.IsValidData())
            {
                if (this.AddCustomer)
                    this.Customer = new Customers();
                this.LoadCustomerData();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";

            errorMessage += Validator.IsPresent(txtName.Text, txtName.Tag.ToString());
            errorMessage += Validator.IsPresent(txtAddress.Text, txtAddress.Tag.ToString());
            errorMessage += Validator.IsPresent(txtCity.Text, txtCity.Tag.ToString());
            errorMessage += Validator.IsPresent(cboStates.Text, cboStates.Tag.ToString());
            errorMessage += Validator.IsPresent(txtZipCode.Text, txtZipCode.Tag.ToString());

            if (errorMessage != "")
            {
                success = false;
                MessageBox.Show(errorMessage, "Entry Error");
            }
            return success;
        }

        private void LoadStatesComboBox()
        {
            try
            {
                cboStates.DataSource = this.States;
                cboStates.DisplayMember = "StateName";
                cboStates.ValueMember = "StateCode";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void LoadCustomerData()
        {
            Customer.Name = txtName.Text;
            Customer.Address = txtAddress.Text;
            Customer.City = txtCity.Text;
            Customer.State = cboStates.SelectedValue.ToString();
            Customer.ZipCode = txtZipCode.Text;
        }

        private void DisplayCustomerData()
        {
            txtName.Text = Customer.Name;
            txtAddress.Text = Customer.Address;
            txtCity.Text = Customer.City;
            cboStates.SelectedValue = Customer.State;
            txtZipCode.Text = Customer.ZipCode;
        }
    }
}