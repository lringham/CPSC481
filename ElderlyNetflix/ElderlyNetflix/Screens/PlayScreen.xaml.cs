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
    /// Interaction logic for PlayScreen.xaml
    /// </summary>
    public partial class PlayScreen : UserControl, INavigable
    {
        private static Notification n;

        private bool isPlaying;

        public PlayScreen()
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
            img.Height = 64;
            img.Width = 64;
            img.Source = new BitmapImage(new Uri("/Assets/Images/pause.png", UriKind.Relative));
            playButton.Content = img;

            isPlaying = true;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Navigator.navigateBack();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Navigator.navigateAndClearStack(new MainScreen());
        }

        private void scrubberBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            playbackText.Text = ((int)((scrubberBar.Value / 10.0) * 100)).ToString() + "%";
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

        private void subtitleCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            n = new Notification("Subtitles enabled.");
            n.Show();
        }

        private void subtitleCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            n = new Notification("Subtitles disabled.");
            n.Show();
        }

        private void profileButton_Click(object sender, RoutedEventArgs e)
        {
            n = new Notification("Signed Out");
            n.Show();
            Navigator.navigate(new LoginScreen());
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {
                Image i = new Image();
                i.Height = 64;
                i.Width = 64;
                i.Source = new BitmapImage(new Uri("/Assets/Images/play.png", UriKind.Relative));
                playButton.Content = i;
                isPlaying = false;
            }
            else
            {
                Image i = new Image();
                i.Height = 64;
                i.Width = 64;
                i.Source = new BitmapImage(new Uri("/Assets/Images/pause.png", UriKind.Relative));
                playButton.Content = i;
                isPlaying = true;
            }
        }
    }
}
