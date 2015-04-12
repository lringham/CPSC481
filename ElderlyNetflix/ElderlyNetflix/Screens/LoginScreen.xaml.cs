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
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : UserControl, INavigable
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Navigator.navigate(new MainScreen());
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Navigator.navigate(new ProfileScreen());
        }

        public void useState(params object[] state)
        {
            throw new NotImplementedException();
        }

        public void resume()
        {
        }

        public void setSource(MovieSource source)
        {
        }
    } 
}
