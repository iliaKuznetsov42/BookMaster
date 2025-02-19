using Bookmaster.View.Windows;
using Booksmaster.View.Pages;
using System.Windows;

namespace Bookmaster
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LibraryMi.Visibility = Visibility.Collapsed;
            LogoutMi.Visibility = Visibility.Collapsed;
        }

        private void LoginMi_Click(object sender, RoutedEventArgs e)
        {
            //LoginWindow
            //Для реализации оконной навигации нужно:
            //1) Создать экземпляр окна, которое требуется открыть
            LoginWindow loginWindow = new LoginWindow();

            //2) У экземляра окна вызвать метод Show() или ShowDialog();
            loginWindow.ShowDialog();
        }

        private void LogoutMi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CloseMi_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BrowseCaralogMi_Click(object sender, RoutedEventArgs e)
        {
            //Для реализации страничной навигации нужно:
            //1) Обратиться к элементу Frame по имени и вызываем метод Navigate();
            //2) В качестве аргумента передаём в метод экземпляр страницы, которую нужно открыть
            MainFrame.Navigate(new BrowseCatalogPage());
        }

        private void ManageCustomersMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ManageCustomersPage());
        }

        private void CirculationMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CirculationPage());

        }

        private void ReportsMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ReportsPage());
        }
    }

}
