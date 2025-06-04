using Bookmaster.Model;
using System;
using System.Diagnostics;
using System.Windows;

namespace Bookmaster.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для BookAuthorsDetailsWindow.xaml
    /// </summary>
    public partial class BookAuthorsDetailsWindow : Window
    {
        public BookAuthorsDetailsWindow()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public BookAuthorsDetailsWindow(Book selectedBook)
        {
            InitializeComponent();

            AuthorsCmb.ItemsSource = selectedBook.BookAuthor;

            Title = $"Авторы книги \"{selectedBook.Title}\"";
        }

        private void AuthorsCmb_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DataContext = AuthorsCmb.SelectedItem as BookAuthor;
        }

        private void OpenWikipediaHl_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            try
            {
                Process.Start(e.Uri.AbsoluteUri);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
