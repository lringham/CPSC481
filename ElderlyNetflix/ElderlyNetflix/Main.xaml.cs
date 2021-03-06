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
using System.Windows.Shapes;
using ElderlyNetflix.Code;
using ElderlyNetflix.Screens;

namespace ElderlyNetflix
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            FakeDatabase.initalize();
            Navigator.setWindow(this);
            Navigator.navigate(new LoginScreen()); //Navigate to the starting screen      
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
