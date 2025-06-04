using Bookmaster.AppDate;
using Bookmaster.Model;
using Bookmaster.View.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Bookmaster.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для BrowseCatalogPage.xaml
    /// </summary>
    public partial class BrowseCatalogPage : Page
    {
        List<Book> _books = App.context.Book.ToList();
        private PaginationService<Book> _booksPagination;
        List<BookCover> _bookCovers = App.context.BookCover.ToList();
        private PaginationService<BookCover> _bookCoversPagination;


        public BrowseCatalogPage()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            SearchResultGrid.Visibility = Visibility.Visible;

            if (string.IsNullOrEmpty(SearchByBookTitleTb.Text) && string.IsNullOrEmpty(SearchByAuthorNameTb.Text) && string.IsNullOrEmpty(SearchByBookSubjectTb.Text))
            {
                _booksPagination = new PaginationService<Book>(_books, 50);
            }
            else
            {
                List<Book> searchResults = _books.Where(book =>
                book.Title.ToLower().Contains(SearchByBookTitleTb.Text.ToLower()) &&
                book.Authors.ToLower().Contains(SearchByAuthorNameTb.Text.ToLower())).ToList();

                _booksPagination = new PaginationService<Book>(searchResults, 50);

            }
            BookAuthorLv.ItemsSource = _booksPagination.CurrentPageOfItems;
            TotalPagesTbl.DataContext = TotalBooksTbl.DataContext = _booksPagination;
            _booksPagination.UpdatePaginationButtons(PreviousBookBtn, NextBookBtn);
            CurrentPageTb.Text = _booksPagination.CurrentPageNumber.ToString();
        }

        private void PreviousBookBtn_Click(object sender, RoutedEventArgs e)
        {
            BookAuthorLv.ItemsSource = _booksPagination.PreviousPage();
            CurrentPageTb.Text = _booksPagination.CurrentPageNumber.ToString();
            _booksPagination.UpdatePaginationButtons(PreviousBookBtn, NextBookBtn);
        }

        private void CurrentPageTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(CurrentPageTb.Text, out int pageNumber) && pageNumber >= 1 && pageNumber <= _booksPagination.TotalPages)
            {


            }
        }

        private void NextBookBtn_Click(object sender, RoutedEventArgs e)
        {
            BookAuthorLv.ItemsSource = _booksPagination.NextPage();
            CurrentPageTb.Text = _booksPagination.CurrentPageNumber.ToString();
            _booksPagination.UpdatePaginationButtons(PreviousBookBtn, NextBookBtn);
        }

        private void PreviousCoverBtn_Click(object sender, RoutedEventArgs e)
        {
            CoversLb.ItemsSource = _bookCoversPagination.PreviousPage();
            _bookCoversPagination.UpdatePaginationButtons(PreviousCoverBtn, NextCoverBtn);
        }

        private void NextCoverBtn_Click(object sender, RoutedEventArgs e)
        {
            CoversLb.ItemsSource = _bookCoversPagination.NextPage();
            _bookCoversPagination.UpdatePaginationButtons(PreviousCoverBtn, NextCoverBtn);
        }

        private void BookAuthorLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book selectedBook = BookAuthorLv.SelectedItem as Book;
            if (selectedBook != null)
            {
                BookDetailsGrid.DataContext = selectedBook;
                _bookCoversPagination = new PaginationService<BookCover>(_bookCovers.Where(bc => bc.BookId == selectedBook.Id).ToList(), 1);
                CoversLb.ItemsSource = _bookCoversPagination.CurrentPageOfItems;
                _bookCoversPagination.UpdatePaginationButtons(PreviousCoverBtn, NextCoverBtn);
            }


        }

        private void AuthorsDetailsHl_Click(object sender, RoutedEventArgs e)
        {
            Book selectedBook = BookAuthorLv.SelectedItem as Book;

            BookAuthorsDetailsWindow bookAuthorsDetailsWindow = new BookAuthorsDetailsWindow(selectedBook);
            bookAuthorsDetailsWindow.ShowDialog();
        }
    }
}
