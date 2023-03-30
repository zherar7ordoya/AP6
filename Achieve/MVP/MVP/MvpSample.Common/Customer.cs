namespace MvpSample.Common
{
    public class Customer 
    {
        /// <summary>
        /// Creates a valid customer.
        /// </summary>
        public Customer(string p_contactName, string p_companyName)
        {
            m_companyName = p_companyName;
            m_contactName = p_contactName;
        }

        public string CompanyName
        {
            get { return m_companyName; }
        }

        public string ContactName
        {
            get { return m_contactName; }
        }

        public string ID
        {
            get { return m_id; }
            set { m_id = value; }
        }

        private string m_companyName = "";
        private string m_contactName = "";
        private string m_id = "0";
    }
}
