using System.Collections.Generic;
using MvpSample.Common;
using MvpSample.Common.ViewModels;
using MvpSample.WinForms.Models;
using MvpSample.WinForms.Views;
using MvpSample.Common.Interfaces;

namespace MvpSample.WinForms.Presenters
{
    internal class CustomersPresenter
    {
        private readonly ICustomersView m_view;
        private readonly ICustomerDao m_customerDao;
        private IEnumerable<CustomerViewModel> m_customerViewModelList;

        public CustomersPresenter(ICustomersView view, CustomerDao dao)
        {
            m_view = view;
            m_customerDao = dao;

            Update();
        }

        private void Update()
        {
            IEnumerable<CustomerDataEntity> customerDataEntityList = m_customerDao.GetAllCustomers();

            IEnumerable<CustomerViewModel> customerViewModelList = 
                ResolveViewModelArray(customerDataEntityList);

            m_customerViewModelList = customerViewModelList;
            
            m_view.ShowCustomers(m_customerViewModelList);
            
        }

        private IEnumerable<CustomerViewModel> ResolveViewModelArray(IEnumerable<CustomerDataEntity> customerDataEntityList)
        {
            foreach (CustomerDataEntity customerDataEntity in customerDataEntityList)
            {
                yield return new CustomerViewModel(customerDataEntity);
            }
        }

        public void AddCustomerClicked()
        {
            using (AddCustomerView view = new AddCustomerView(m_customerDao))
            {
                view.ShowDialog();
            }
            Update();
        }
    }
}