using System;
using System.Windows.Forms;
using MvpSample.WinForms.Models;
using MvpSample.WinForms.Presenters;
using MvpSample.WinForms.Views;

namespace MvpSample.WinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            CustomerDao dao = new CustomerDao();
            CustomersView view = new CustomersView(dao);

            Application.Run(view);
        }
    }
}