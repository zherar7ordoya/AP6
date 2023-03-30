using System;
using System.Collections.Generic;
using System.IO;

namespace MvpSample.Common
{
    public class CustomerDataMapper
    {
        private CustomersDataSet m_CustomersDataSet;
        private string m_fileName;

        public CustomerDataMapper(string p_fileName)
        {
            m_fileName =  p_fileName;

            m_CustomersDataSet = new CustomersDataSet();
            FileInfo fileInfo = new FileInfo(p_fileName);
            if (fileInfo.Exists)
            {
                m_CustomersDataSet.ReadXml(p_fileName);
            }
            
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            foreach (CustomersDataSet.CustomersDataTableRow row in m_CustomersDataSet.CustomersDataTable.Rows)
            {
                yield return new Customer(row.Name, row.Company);
            }

        }

        public void Save(Customer p_customer)
        {
            m_CustomersDataSet.CustomersDataTable.AddCustomersDataTableRow(
                p_customer.ContactName, p_customer.CompanyName);

            m_CustomersDataSet.WriteXml(m_fileName);

        }
    }
}
