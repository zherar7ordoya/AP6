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

        public List<CustomerDataEntity> GetAllCustomers()
        {
            List<CustomerDataEntity> customersList = new List<CustomerDataEntity>();
            foreach (CustomersDataSet.CustomersDataTableRow row in m_CustomersDataSet.CustomersDataTable.Rows)
            {
                CustomerDataEntity entity = new CustomerDataEntity(row.Name, row.Company, row.DataOfBirth);
                customersList.Add(entity);
            }

            return customersList;
        }

        public void Save(CustomerDataEntity p_customer)
        {
            m_CustomersDataSet.CustomersDataTable.AddCustomersDataTableRow(
                p_customer.Name, p_customer.CompanyName, p_customer.DateOfBirth);

            m_CustomersDataSet.WriteXml(m_fileName);

        }
    }
}
