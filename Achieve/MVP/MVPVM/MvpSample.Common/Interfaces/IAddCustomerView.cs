using MvpSample.Common.ViewModels;

namespace MvpSample.Common.Interfaces
{
    public interface IAddCustomerView
    {
        void ShowCustomer(CustomerViewModel customerViewModel);
        void ReadUserInput();
        void ShowError(string message);
        void Close();
    }
}
