using System;
using System.Web.UI;
using MvpSample.Common;
using MvpSample.Common.Interfaces;
using MvpSample.WebForms.Presenters;

namespace MvpSample.WebForms
{
    public partial class AddCustomerWebformsView : UserControl, IAddCustomerView
    {
        private AddCustomerPresenter m_presenter;

        public void AttachPresenter(AddCustomerPresenter presenter)
        {
            m_presenter = presenter;
        }

        public void AddCustomerToList(Customer p_customer)
        {
            ListBox1.Items.Add(p_customer.ContactName);
        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            // Be sure to check isPageValid before anything else
            if (!Page.IsValid)
            {
                Message = "There was a problem with your inputs." +
                    " Make sure you supplied everything and try again";
                return;
            }


            m_presenter.AddCustomer();
        }

        public Customer CustomerToAdd
        {
            get
            {
                Customer customer = 
                    new Customer(txtContactName.Text, txtCompanyName.Text);
                
                return customer;
            }
        }

        public string Message
        {
            set
            {
                lblMessage.Text = value;
            }
        }
    }
}