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
    /// Interaction logic for RecentlyWatchedScreen.xaml
    /// </summary>
    public partial class RecentlyWatchedScreen : UserControl
    {
        public RecentlyWatchedScreen()
        {
            InitializeComponent();

            for(int i=0; i < 10; i++)
                addedResult("test"+i);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Navigator.navigateBack();
        }

        private void addedResult(String name)
        {
            Button b = new Button();
            b.Content = name;
            ResultsStackPanel.Children.Add(b);
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Navigator.navigateAndClearStack(new MainScreen());
        }
    }
}
