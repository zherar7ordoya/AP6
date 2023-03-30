using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MvpSample.Common;
using MvpSample.Common.Interfaces;
using MvpSample.WinForms.Models;
using MvpSample.WinForms.Presenters;

namespace MvpSample.WinForms
{
    public partial class AddCustomerWinformsView : Form, IAddCustomerView
    {
        private readonly CustomerDao m_customerDao;
        private AddCustomerPresenter m_presenter;

        public AddCustomerWinformsView(CustomerDao p_CustomerDao)
        {
            InitializeComponent();

            AddCustomerPresenter presenter = new AddCustomerPresenter(this, p_CustomerDao);
            m_presenter = presenter;

            m_customerDao = p_CustomerDao;
            registerToModelEvents();
        }


        public void AddCustomerToList(Customer p_customer)
        {
            ListViewItem item = new ListViewItem(p_customer.ContactName);
            item.SubItems.Add(p_customer.CompanyName);
            listView1.Items.Add(item);
        }

        public Customer CustomerToAdd
        {
            get
            {
                return new Customer(textBoxName.Text, textBoxCompany.Text);
            }
        }

        public string Message
        {
            get
            {
                return lblMessage.Text;
            }
            set
            {
                lblMessage.Text = value;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            m_presenter.AddCustomer();
        }

        void m_customerDao_CustomerSaved(object sender, CustomerSavedEventArgs e)
        {
            AddCustomerToList(e.Customer);
        }


        private void registerToModelEvents()
        {
            m_customerDao.CustomerSaved += m_customerDao_CustomerSaved;
        }

        public AddCustomerPresenter Presenter
        {
            get { return m_presenter; }
        }
    }
}