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
    /// Interaction logic for SearchScreen.xaml
    /// </summary>
    public partial class SearchScreen : UserControl
    {
        public SearchScreen()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Navigator.navigateAndClearStack(new MainScreen());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Navigator.navigateBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Navigator.navigate(new SearchResultsScreen(), SearchBar.Text);
        }

        private void SearchBar_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBar.Text == "Search for Name, Director, Year or Actor")
                SearchBar.Text = "";
        }

        private void SearchBar_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBar.Text == "")
                SearchBar.Text = "Search for Name, Director, Year or Actor";
        }
    }
}
