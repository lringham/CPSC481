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
    /// Interaction logic for MainScreen.xaml
    /// </summary>
    public partial class MainScreen : UserControl
    {
        private static BrowseScreen browse;
        private static MovieListScreen movieList;
        private static SearchScreen search;

        public MainScreen()
        {
            InitializeComponent();       
        }

        private void Recent_Click(object sender, RoutedEventArgs e)
        {
            movieList = new MovieListScreen();
            Navigator.navigate(movieList, "Recently Watched Movies", FakeDatabase.getRecentVideos());
        }

        private void Saved_Click(object sender, RoutedEventArgs e)
        {
            movieList = new MovieListScreen();
            Navigator.navigate(movieList, "Favorite Movies", FakeDatabase.getFavoriteVideos());
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            browse = new BrowseScreen();
            Navigator.navigate(browse);
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            search = new SearchScreen();
            Navigator.navigate(search);
        }

        private void Profile_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }
    }
}
