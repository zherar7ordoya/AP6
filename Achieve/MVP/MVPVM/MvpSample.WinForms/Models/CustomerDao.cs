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
        private List<CustomerDataEntity> m_allCustomers;
        private const string FILE_NAME = "Customers.xml";

        public CustomerDao()
        {
            m_dataMapper = new CustomerDataMapper(FILE_NAME);
            m_allCustomers = m_dataMapper.GetAllCustomers();
        }

        public CustomerDataEntity CreateCustomerDataEntity()
        {
            return new CustomerDataEntity();
        }

        public IEnumerable<CustomerDataEntity> GetAllCustomers()
        {
            return m_allCustomers;
        }

        public void Save(CustomerDataEntity p_customer)
        {
            m_dataMapper.Save(p_customer);

            m_allCustomers.Add(p_customer);
        }

        public CustomerDataEntity GetByName(string p_name)
        {
            foreach (CustomerDataEntity customer in m_allCustomers)
            {
                if (customer.Name == p_name)
                {
                    return customer;
                }

            }

            return null;
        }
    }

    public class CustomerSavedEventArgs : EventArgs
    {
        private readonly CustomerDataEntity m_CustomerDataEntity;

        public CustomerSavedEventArgs(CustomerDataEntity p_customer)
        {
            m_CustomerDataEntity = p_customer;
        }

        public CustomerDataEntity CustomerDataEntity
        {
            get { return m_CustomerDataEntity; }
        }
    }
}

