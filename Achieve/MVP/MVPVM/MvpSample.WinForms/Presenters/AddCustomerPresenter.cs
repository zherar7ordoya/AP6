using System;
using MvpSample.Common;
using MvpSample.Common.Interfaces;
using MvpSample.Common.ViewModels;

namespace MvpSample.WinForms.Presenters
{    
    public class AddCustomerPresenter 
    {
        private IAddCustomerView m_view;
        private ICustomerDao m_customerDao;
        private CustomerViewModel m_viewModel;

        public AddCustomerPresenter(IAddCustomerView p_view,
            ICustomerDao p_customerDao)
        {
            m_view = p_view;
            m_customerDao = p_customerDao;

            CustomerDataEntity customerDataEntity = p_customerDao.CreateCustomerDataEntity();
            CustomerViewModel customerViewModel = new CustomerViewModel(customerDataEntity);

            m_viewModel = customerViewModel;
            m_view.ShowCustomer(customerViewModel);

        }

        public void SaveClicked()
        {
            m_view.ReadUserInput();

            CustomerDataEntity customerDataEntity = m_viewModel.CustomerDataEntity;
            bool duplicateExist = !IsDuplicateOfExisting(customerDataEntity);
            if (duplicateExist)
            {
                m_customerDao.Save(customerDataEntity);

                m_view.Close();
            }
            else
            {
                m_view.ShowError(string.Format("Customer '{0}' already exist", m_viewModel.Name));
            }
        }

        private bool IsDuplicateOfExisting(CustomerDataEntity newCustomerDataEntity)
        {
            CustomerDataEntity duplicateCustomerDataEntity = 
                m_customerDao.GetByName(newCustomerDataEntity.Name);
            
            return duplicateCustomerDataEntity != null;
        }

        public void CancellClicked()
        {
            m_view.Close();
        }
    }
}
