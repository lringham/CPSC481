using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ElderlyNetflix.Code;

namespace ElderlyNetflix.Screens
{
    /// <summary>
    /// Interaction logic for MainScreen.xaml
    /// </summary>
    public partial class MainScreen : UserControl
    {
        private static SearchScreen search;
        private static BrowseScreen browse;
        private static FavoritesScreen saved;
        private static RecentlyWatchedScreen recent;

        public MainScreen()
        {
            InitializeComponent();       
        }

        private void Recent_Click(object sender, RoutedEventArgs e)
        {
            recent = new RecentlyWatchedScreen();
            Navigator.navigate(recent);
        }

        private void Saved_Click(object sender, RoutedEventArgs e)
        {
            saved = new FavoritesScreen();
            Navigator.navigate(saved);
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            browse = new BrowseScreen();
            Navigator.navigate(browse);
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            search = new SearchScreen();
            Navigator.navigate(search);
        }
    }
}
