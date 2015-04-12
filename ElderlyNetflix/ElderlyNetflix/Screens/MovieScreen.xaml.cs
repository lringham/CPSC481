using ElderlyNetflix.Code;
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

namespace ElderlyNetflix.Screens
{
    /// <summary>
    /// Interaction logic for MovieScreen.xaml
    /// </summary>
    public partial class MovieScreen : UserControl, INavigable
    {
        
        Video video;

        private static Notification n;

        public MovieScreen()
        {
            InitializeComponent();

            Image img = new Image();
            img.Source = new BitmapImage(new Uri("/Assets/Images/logo.png", UriKind.Relative));
            homeButton.Content = img;

            img = new Image();
            img.Source = new BitmapImage(new Uri("/Assets/Images/back.png", UriKind.Relative));
            img.Height = 100;
            img.Width = 100;
            backButton.Content = img;

            img = new Image();
            img.Height = 100;
            img.Width = 100;
            img.Source = new BitmapImage(new Uri("/Assets/Images/logout.png", UriKind.Relative));
            profileButton.Content = img;

            img = new Image();
            img.Height = 75;
            img.Width = 75;
            img.Source = new BitmapImage(new Uri("/Assets/Images/arrow.png", UriKind.Relative));
            arrowButton.Content = img;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            video.toggleRecent();
            FakeDatabase.update();
            Navigator.navigate(new PlayScreen()); 
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            FakeDatabase.update();
            Navigator.navigateAndClearStack(new MainScreen());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FakeDatabase.update();
            Navigator.navigateBack();
        }

        public void useState(params object[] state)
        {
            video = (Video)state[0];
            Title.Text = video.name;
            Details.Text = "Year\t" + video.year;
            Details.Text += "\nDirector\t" + video.director;
            Details.Text += "\nGenre\t" + video.genre;
            Details.Text += "\nActors\t" + video.getActorsString();
            Details.Text += "\n\n" + video.plot;

            CoverArt.Source = new BitmapImage(new Uri(video.getImagePath(), UriKind.Relative));
        }

        private Image getFavoriteButton()
        {
            Image i = new Image();
            i.Height = 100;
            i.Width = 100;
            if (video.getFavoriteStatus())
            {
                i.Source = new BitmapImage(new Uri("/Assets/Images/favorite_on.png", UriKind.Relative));
            }
            else
            {
                i.Source = new BitmapImage(new Uri("/Assets/Images/favorite.png", UriKind.Relative));
            }

            return i;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            video.toggleFavorite();
            FakeDatabase.update();
            favoriteButton.Content = getFavoriteButton();

            if (video.getFavoriteStatus())
            {
                n = new Notification(video.name+" added to your favorites.");
                n.Show();
            }
            else
            {
                n = new Notification(video.name+" removed from your favorites.");
                n.Show();
            }
        }

        public void resume()
        {
            //Nothing to do
        }

        public void setSource(MovieSource source)
        {
            //Doesn't have a source. 
        }

        private void profileButton_Click(object sender, RoutedEventArgs e)
        {
            n = new Notification("Signed Out");
            n.Show();
            Navigator.navigate(new LoginScreen());
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            favoriteButton.Content = getFavoriteButton();
        }
    }
}
