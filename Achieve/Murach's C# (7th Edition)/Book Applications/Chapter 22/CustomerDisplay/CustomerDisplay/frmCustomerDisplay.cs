﻿using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CustomerDisplay.Model;

namespace CustomerDisplay
{
    public partial class frmCustomerDisplay : Form
    {
        public frmCustomerDisplay()
        {
            InitializeComponent();            
        }
        
        private MMABooksContext context = new MMABooksContext();
        private const int MaxRows = 10;
        private int totalRows = 0;
        private int pages = 0;

        private void frmCustDisplay_Load(object sender, EventArgs e)
        {
            totalRows = context.Customers.Count();
            pages = totalRows / MaxRows;
            if (totalRows % MaxRows != 0)
            {
                pages += 1;
            }
            lblPages.Text = "/ " + pages;

            DisplayCustomers(1);
        }

        private void DisplayCustomers(int pageNumber)
        {
            txtPage.Text = pageNumber.ToString();

            int skip = MaxRows * (pageNumber - 1);

            int take = MaxRows;
            if (pageNumber == pages)
            {
                take = totalRows - skip;
            }
            if (totalRows <= MaxRows)
            {
                take = totalRows;
            }

            var customers = context.Customers
                .OrderBy(c => c.Name)
                .Select(c => new { c.Name, c.Address, c.City, c.State, c.ZipCode })
                .Skip(skip)
                .Take(take)
                .ToList();
            dgvCustomers.DataSource = customers;

            // format the column headers
            dgvCustomers.EnableHeadersVisualStyles = false;
            dgvCustomers.ColumnHeadersDefaultCellStyle.Font =
                new Font("Arial", 9, FontStyle.Bold);
            dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = Color.Goldenrod;
            dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // format the odd numbered rows
            dgvCustomers.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            // format the columns
            dgvCustomers.Columns[0].Width = 160;
            dgvCustomers.Columns[1].Width = 215;
            dgvCustomers.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvCustomers.Columns[3].Width = 55;
            dgvCustomers.Columns[2].Width = 125;
            dgvCustomers.Columns[4].HeaderText = "Zip Code";
            dgvCustomers.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvCustomers.Columns[4].Width = 82;

            EnableDisableButtons(pageNumber);
        }

        private void EnableDisableButtons(int pageNumber)
        {
            // enable/disable buttons
            if (pageNumber == 1)
            {
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;
            }
            else
            {
                btnFirst.Enabled = true;
                btnPrev.Enabled = true;
            }

            // enable/disable Next/Last buttons
            if (pageNumber == pages)
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
                btnLast.Enabled = true;
            }

            // if there's only one page, disable the Go To button 
            if (totalRows <= MaxRows)
            {
                btnGoTo.Enabled = false;
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            DisplayCustomers(1);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            int pageNumber = Convert.ToInt32(txtPage.Text);
            pageNumber -= 1;
            DisplayCustomers(pageNumber);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int pageNumber = Convert.ToInt32(txtPage.Text);
            pageNumber += 1;
            DisplayCustomers(pageNumber);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            DisplayCustomers(pages);
        }

        private void btnGoTo_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                int pageNumber = Convert.ToInt32(txtPage.Text);
                DisplayCustomers(pageNumber);
            }
        }

        private bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";
            errorMessage += Validator.IsPresent(txtPage.Text, txtPage.Tag.ToString());
            errorMessage += Validator.IsInt32(txtPage.Text, txtPage.Tag.ToString());
            errorMessage += Validator.IsWithinRange(txtPage.Text, txtPage.Tag.ToString(), 1, pages);
            if (errorMessage != "")
            {
                success = false;
                MessageBox.Show(errorMessage, "Entry Error");
                txtPage.Focus();
            }
            return success;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}