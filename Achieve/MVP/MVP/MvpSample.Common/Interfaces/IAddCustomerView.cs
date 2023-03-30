namespace MvpSample.Common.Interfaces
{
    public interface IAddCustomerView
    {
        string Message { set; }

        Customer CustomerToAdd { get; }

        void AddCustomerToList(Customer p_customer);
    }
}
