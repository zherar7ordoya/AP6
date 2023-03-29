using System;
using System.Web.UI;
using MvpSample.WebForms.Models;
using MvpSample.WebForms.Presenters;

namespace MvpSample.WebForms
{
    public partial class AddCustomerPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerDao customerDao = new CustomerDao();

            AddCustomerPresenter presenter = 
                new AddCustomerPresenter(addCustomerWebformsView, customerDao);
            
            addCustomerWebformsView.AttachPresenter(presenter);
            
            if (!IsPostBack)
            {
                // No need to update the display on each post back, 
                // as ViewState travel from client to server and back 
                // from server to client.
                presenter.InitView();
            }
        }
    }
}
