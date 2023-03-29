using System;
using System.Collections.Generic;
using MvpSample.Common;
using MvpSample.Common.Interfaces;

namespace MvpSample.WinForms.Models
{
    // Long lasting observable with caching.
    public class CustomerDao: ICustomerDao
    {
        private CustomerDataMapper m_dataMapper;
        private IEnumerable<Customer> m_allCustomers;
        private const string FILE_NAME = "Customers.xml";

        public event EventHandler<CustomerSavedEventArgs> CustomerSaved;

        public CustomerDao()
        {
            m_dataMapper = new CustomerDataMapper(FILE_NAME);
            m_allCustomers = m_dataMapper.GetAllCustomers();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return m_allCustomers;
        }

        public void Save(Customer p_customer)
        {
            m_dataMapper.Save(p_customer);

            raiseCustomerSaved(p_customer);
        }

        public Customer GetByName(string p_name)
        {
            foreach (Customer customer in m_allCustomers)
            {
                if (customer.ContactName == p_name)
                {
                    return customer;
                }

            }

            return null;
        }

        private void raiseCustomerSaved(Customer p_customer)
        {
            if (CustomerSaved != null)
            {
                CustomerSaved(this, new CustomerSavedEventArgs(p_customer));
            }
        }
    }

    public class CustomerSavedEventArgs : EventArgs
    {
        private readonly Customer m_customer;

        public CustomerSavedEventArgs(Customer p_customer)
        {
            m_customer = p_customer;
        }

        public Customer Customer
        {
            get { return m_customer; }
        }
    }
}

