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
    /// Interaction logic for SavedScreen.xaml
    /// </summary>
    public partial class SavedScreen : UserControl
    {
        public SavedScreen()
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
    }
}
