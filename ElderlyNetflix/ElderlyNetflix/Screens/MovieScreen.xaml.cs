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
        public MovieScreen()
        {
            InitializeComponent();

            Image img = new Image();
            img.Source = new BitmapImage(new Uri("/Assets/Images/logo.png", UriKind.Relative));
            homeButton.Content = img;

            img = new Image();
            img.Source = new BitmapImage(new Uri("/Assets/Images/back.png", UriKind.Relative));
            img.Height = 50;
            img.Width = 50;
            backButton.Content = img;

            img = new Image();
            img.Height = 75;
            img.Width = 75;
            img.Source = new BitmapImage(new Uri("/Assets/Images/profile.png", UriKind.Relative));
            profileButton.Content = img;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Navigator.navigate(new PlayScreen()); 
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Navigator.navigateAndClearStack(new MainScreen());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Navigator.navigateBack();
        }

        public void useState(params object[] state)
        {
            video = (Video)state[0];
            Title.Text = video.name;
            Details.Text = video.details();
            Plot.Text = video.plot;

            string imgName = video.name.Contains(':') ? video.name.Split(':')[0].ToLower() : video.name;
            CoverArt.Source = new BitmapImage(new Uri("/Assets/Images/MovieCovers/" + imgName + ".jpg", UriKind.Relative));
        }
    }
}
