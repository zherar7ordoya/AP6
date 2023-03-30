using System;
using System.Windows.Forms;
using MvpSample.Common.Interfaces;
using MvpSample.Common.ViewModels;
using MvpSample.WinForms.Presenters;

namespace MvpSample.WinForms.Views
{
    public partial class AddCustomerView : Form, IAddCustomerView
    {
        private AddCustomerPresenter m_presenter;

        public AddCustomerView(ICustomerDao dao)
        {
            InitializeComponent();

            m_presenter = new AddCustomerPresenter(this, dao);
        }

        public void ShowCustomer(CustomerViewModel customerViewModel)
        {
            cusomerViewModelBindingSource.DataSource = customerViewModel;
        }

        public void ReadUserInput()
        {
            cusomerViewModelBindingSource.EndEdit();
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void m_btnSave_Click(object sender, EventArgs e)
        {
            m_presenter.SaveClicked();
        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            m_presenter.CancellClicked();
        }
    }
}