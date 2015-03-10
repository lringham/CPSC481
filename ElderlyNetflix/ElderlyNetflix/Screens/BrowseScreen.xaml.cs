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
    /// Interaction logic for BrowseScreen.xaml
    /// </summary>
    public partial class BrowseScreen : UserControl
    {
        public BrowseScreen()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Navigator.navigate(new MainScreen());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Handle back navigation
        }
    }
}
