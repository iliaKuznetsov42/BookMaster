using Bookmaster;
using Bookmaster.AppDate;
using Bookmaster.Model;
using Bookmaster.View.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Booksmaster.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManageCustomersPage.xaml
    /// </summary>
    public partial class ManageCustomersPage : Page
    {
        System.Collections.Generic.List<Customer> _customer = App.context.Customer.ToList();
        PaginationService<Customer> _customerPagination;
        public ManageCustomersPage()
        {
            InitializeComponent();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();
        }

        private void SearchCustomerLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(CustomerIDSearchTb.Text) && string.IsNullOrEmpty(NameSearchTb.Text))
            {
                _customerPagination = new PaginationService<Customer>(_customer, 50);
            }
            else
            {
                List<Customer> searchResults = _customer.Where(customer => customer.Id.ToLower().Contains(CustomerIDSearchTb.Text.ToLower()) && customer.Name.ToLower().Contains(NameSearchTb.Text.ToLower())).ToList();

                _customerPagination = new PaginationService<Customer>(searchResults, 50);
            }

            SearchCustomerLv.ItemsSource = _customerPagination.CurrentPageOfItems;
        }
    }
}
