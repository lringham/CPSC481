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
        public MovieScreen()
        {
            InitializeComponent();
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
            Video video = (Video)state[0];

        }
    }
}
