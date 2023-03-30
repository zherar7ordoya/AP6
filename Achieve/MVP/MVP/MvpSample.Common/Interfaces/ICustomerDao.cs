using System.Collections.Generic;

namespace MvpSample.Common.Interfaces
{
    public interface ICustomerDao
    {
        IEnumerable<Customer> GetAllCustomers();
        void Save(Customer p_customer);
        Customer GetByName(string p_name);
    }
}
