using System.Collections.Generic;
using MvpSample.Common.ViewModels;

namespace MvpSample.Common.Interfaces
{
    public interface ICustomersView
    {
        void ShowCustomers(IEnumerable<CustomerViewModel> customerViewModelList);
    }
}