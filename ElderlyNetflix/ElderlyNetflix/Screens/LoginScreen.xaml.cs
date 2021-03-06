﻿using System;
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
        private static Notification n;

        private string username = "my-fake-email@email-provider.com";
        private string password = "password";

        public LoginScreen()
        {
            InitializeComponent();

            Image img = new Image();
            img.Source = new BitmapImage(new Uri("/Assets/Images/signin.png", UriKind.Relative));
            Login.Content = img;

            User.Text = username;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            //Navigator.navigate(new MainScreen());
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (User.Text == username && Pass.Password == password)
            {
                n = new Notification("Login successful.");
                n.Show();

                Navigator.navigate(new MainScreen());
            }
            else
            {
                n = new Notification("Incorrect Username or Password.");
                n.Show();
            }
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

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            n = new Notification("Not currently implemented.");
            n.Show();
        }
    } 
}
