using System;

namespace MvpSample.Common
{
    public class CustomerDataEntity 
    {
        public CustomerDataEntity()
        {
        }

        /// <summary>
        /// Creates a valid customer.
        /// </summary>
        public CustomerDataEntity(string p_contactName, string p_companyName, DateTime dateOfBirth)
        {
            m_companyName = p_companyName;
            m_dateOfBirth = dateOfBirth;
            m_Name = p_contactName;
        }

        public string CompanyName
        {
            get { return m_companyName; }
            set { m_companyName = value; }
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public string ID
        {
            get { return m_id; }
            set { m_id = value; }
        }


        public DateTime DateOfBirth
        {
            get { return m_dateOfBirth; }
            set { m_dateOfBirth = value;}
        }

        private string m_companyName = "";
        private DateTime m_dateOfBirth = new DateTime(1980, 1, 1);
        private string m_Name = "";
        private string m_id = "0";
    }
}
