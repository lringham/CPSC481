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
using ElderlyNetflix.Pages;

namespace ElderlyNetflix
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window, INavigable
    {
        public Main()
        {
            InitializeComponent();
            Navigator.setWindow(this);       
        }

        public void useState(object state)
        {

        }
    }
}
