using System.Collections.Generic;
using MvpSample.Common;
using MvpSample.Common.Interfaces;

namespace MvpSample.WebForms.Presenters
{    
    public class AddCustomerPresenter
    {
        private IAddCustomerView m_view;
        private ICustomerDao m_customerDao;

        public AddCustomerPresenter(IAddCustomerView p_view,
            ICustomerDao p_customerDao)
        {
            m_view = p_view;
            m_customerDao = p_customerDao;
        }

        public void InitView()
        {
            IEnumerable<Customer> customers = m_customerDao.GetAllCustomers();
            
            foreach (Customer customer in customers)
            {
                m_view.AddCustomerToList(customer);
            }
        }

        public void AddCustomer()
        {
            if (!IsDuplicateOfExisting(m_view.CustomerToAdd))
            {
                m_customerDao.Save(m_view.CustomerToAdd);

                m_view.AddCustomerToList(m_view.CustomerToAdd);
            }
            else
            {
                m_view.Message = "The ID you provided is already in use." +
                    "Please change the ID and try again.";
            }
        }

        private bool IsDuplicateOfExisting(Customer newCustomer)
        {
            Customer duplicateCustomer = 
                m_customerDao.GetByName(newCustomer.ContactName);
            
            return duplicateCustomer != null;
        }
    }
}
