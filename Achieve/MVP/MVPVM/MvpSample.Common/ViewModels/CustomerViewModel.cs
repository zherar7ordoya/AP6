using System;
using MvpSample.Common;

namespace MvpSample.Common.ViewModels
{
    public class CustomerViewModel
    {
        private readonly CustomerDataEntity m_customerDataEntity;

        public CustomerViewModel(CustomerDataEntity customerDataEntity)
        {
            m_customerDataEntity = customerDataEntity;
        }

        public string Name
        {
            get { return m_customerDataEntity.Name; }
            set { m_customerDataEntity.Name = value; }
        }

        public string CompanyName
        {
            get { return m_customerDataEntity.CompanyName; }
            set { m_customerDataEntity.CompanyName = value; }
        }

        public DateTime DateOfBirth
        {
            get { return m_customerDataEntity.DateOfBirth; }
            set { m_customerDataEntity.DateOfBirth = value; }
        }

        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - m_customerDataEntity.DateOfBirth.Year;

                return age;
            }
        }

        public CustomerDataEntity CustomerDataEntity
        {
            get { return m_customerDataEntity; }
        }
    }
}