using System.Collections.Generic;
using MvpSample.Common;
using MvpSample.Common.Interfaces;

namespace MvpSample.WebForms.Models
{
    // Static Dao. Recreated on each user session
    public class CustomerDao: ICustomerDao
    {
        private const string FILE_NAME = "Customers.xml";

        public IEnumerable<Customer> GetAllCustomers()
        {
            CustomerDataMapper dataMapper = new CustomerDataMapper(FILE_NAME);

            return dataMapper.GetAllCustomers();
        }


        public void Save(Customer p_customer)
        {
            CustomerDataMapper dataMapper = new CustomerDataMapper(FILE_NAME);
            dataMapper.Save(p_customer);
        }

        public Customer GetByName(string p_name)
        {
            CustomerDataMapper dataMapper = new CustomerDataMapper(FILE_NAME);
            IEnumerable<Customer> customers = dataMapper.GetAllCustomers();
            foreach (Customer customer in customers)
            {
                if (customer.ContactName == p_name)
                {
                    return customer;
                }

            }

            return null;

        }

    }
}
