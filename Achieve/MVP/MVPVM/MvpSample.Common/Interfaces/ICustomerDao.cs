using System.Collections.Generic;

namespace MvpSample.Common.Interfaces
{
    public interface ICustomerDao
    {
        CustomerDataEntity CreateCustomerDataEntity();
        IEnumerable<CustomerDataEntity> GetAllCustomers();
        void Save(CustomerDataEntity p_customer);
        CustomerDataEntity GetByName(string p_name);
    }
}
