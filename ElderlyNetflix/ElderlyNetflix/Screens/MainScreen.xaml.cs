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
    public partial class MainScreen : UserControl, INavigable
    {
        private static MovieListScreen movieList;
        private static SearchScreen search;

        public MainScreen()
        {
            InitializeComponent();

            Image img = new Image();
            img.Height = 75;
            img.Width = 75;
            img.Source = new BitmapImage(new Uri("/Assets/Images/profile.png", UriKind.Relative));
            profileButton.Content = img;

            img = new Image();
            img.Height = 300;
            img.Width = 250;
            img.Source = new BitmapImage(new Uri("/Assets/Images/browse.png", UriKind.Relative));
            Browse.Content = img;

            img = new Image();
            img.Height = 300;
            img.Width = 250;
            img.Source = new BitmapImage(new Uri("/Assets/Images/search.png", UriKind.Relative));
            Search.Content = img;

            img = new Image();
            img.Height = 300;
            img.Width = 250;
            img.Source = new BitmapImage(new Uri("/Assets/Images/recent.png", UriKind.Relative));
            Recent.Content = img;

            img = new Image();
            img.Height = 300;
            img.Width = 250;
            img.Source = new BitmapImage(new Uri("/Assets/Images/favorite.png", UriKind.Relative));
            Favorite.Content = img;
        }

        private void Recent_Click(object sender, RoutedEventArgs e)
        {
            movieList = new MovieListScreen();
            Navigator.navigate(movieList, new MovieSource(FakeDatabase.getRecentVideos), "RECENTLY WATCHED MOVIES");
        }

        private void Saved_Click(object sender, RoutedEventArgs e)
        {
            movieList = new MovieListScreen();
            Navigator.navigate(movieList, new MovieSource(FakeDatabase.getFavoriteVideos), "FAVORITE MOVIES");
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            movieList = new MovieListScreen();
            Navigator.navigate(movieList, new MovieSource(FakeDatabase.getVideos), "BROWSE MOVIES");
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            search = new SearchScreen();
            Navigator.navigate(search);
        }

        private void Profile_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Navigator.navigateAndClearStack(new ProfileScreen());
        }

        public void useState(params object[] state)
        {
        }

        public void resume()
        {
        }

        public void setSource(MovieSource source)
        {
            
        }
    }
}
