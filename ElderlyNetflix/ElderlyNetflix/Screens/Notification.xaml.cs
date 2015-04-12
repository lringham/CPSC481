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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ElderlyNetflix.Screens
{
    /// <summary>
    /// Interaction logic for Notification.xaml
    /// </summary>
    public partial class Notification : Window
    {
        public Notification(String s)
        {
            InitializeComponent();
            
            Title.Text = s;
            Left = Application.Current.MainWindow.Left + 15;
            Top = (Application.Current.MainWindow.Top + Application.Current.MainWindow.Height) - 70;
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            Close();
        }
    }
}
