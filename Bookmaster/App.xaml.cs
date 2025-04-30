using Bookmaster.Model;
using System.Windows;

namespace Bookmaster
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Контекст данных, который хранит в себе таюлицы бд.

        public static BookmasterEntities context = new BookmasterEntities();
    }
}
