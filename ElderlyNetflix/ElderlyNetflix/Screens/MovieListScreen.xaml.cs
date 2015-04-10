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
using System.Windows.Resources; 

using ElderlyNetflix.Code;

namespace ElderlyNetflix.Screens
{
    /// <summary>
    /// Interaction logic for RecentlyWatchedScreen.xaml
    /// </summary>
    public partial class MovieListScreen : UserControl, INavigable
    {
        List<Video> videos = new List<Video>();
        List<Video> displayedVideos = new List<Video>();
        Dictionary<Button, KeyValuePair<Video, Grid>> videoMap = new Dictionary<Button, KeyValuePair<Video, Grid>>();

        public MovieListScreen()
        {
            InitializeComponent();

            Image img = new Image();
            img.Source = new BitmapImage(new Uri("/Assets/Images/logo.png", UriKind.Relative));           
            homeButton.Content = img;

            img = new Image();
            img.Source = new BitmapImage(new Uri("/Assets/Images/back.png", UriKind.Relative));
            img.Height = 50;
            img.Width = 50;
            backButton.Content = img;
        }

        public void displayVideos()
        {
            clearStackPanel();
            videoMap.Clear();

            foreach (Video video in displayedVideos)            
                addResult(video);            
        }

        private void addResult(Video video)
        {
            int gridWidth = 1280;
            Grid grid = new Grid();
            grid.Width = gridWidth;
            grid.HorizontalAlignment = HorizontalAlignment.Left;
            grid.VerticalAlignment = VerticalAlignment.Top;
            grid.ShowGridLines = false;

            int col0Perc = 15;
            int col1Perc = 10;
            int col2Perc = 50;
            int col3Perc = 10;
            int col4Perc = 15;
            ColumnDefinition gridCol0 = new ColumnDefinition();
            ColumnDefinition gridCol1 = new ColumnDefinition();
            ColumnDefinition gridCol2 = new ColumnDefinition();
            ColumnDefinition gridCol3 = new ColumnDefinition();
            ColumnDefinition gridCol4 = new ColumnDefinition();
            gridCol0.Width = new GridLength(col0Perc, GridUnitType.Star);
            gridCol1.Width = new GridLength(col1Perc, GridUnitType.Star);
            gridCol2.Width = new GridLength(col2Perc, GridUnitType.Star);
            gridCol3.Width = new GridLength(col3Perc, GridUnitType.Star);
            gridCol4.Width = new GridLength(col4Perc, GridUnitType.Star);
            grid.ColumnDefinitions.Add(gridCol0);
            grid.ColumnDefinitions.Add(gridCol1);
            grid.ColumnDefinitions.Add(gridCol2);
            grid.ColumnDefinitions.Add(gridCol3);
            grid.ColumnDefinitions.Add(gridCol4);

            RowDefinition gridRow0 = new RowDefinition();
            grid.RowDefinitions.Add(gridRow0);
            RowDefinition gridRow1 = new RowDefinition();
            grid.RowDefinitions.Add(gridRow1);

            Brush brush = new SolidColorBrush(Colors.CornflowerBlue);
            brush.Opacity = .1;
            Background = brush;
            Rectangle bg = new Rectangle();
            bg.Fill = brush;
            Grid.SetColumnSpan(bg, 3);
            Grid.SetRowSpan(bg, 2);
            Grid.SetRow(bg, 0);
            Grid.SetColumn(bg, 1);
            bg.Margin = new Thickness(0, 0, 0, 5);
            grid.Children.Add(bg);

            //image
            Image art = new Image();
            art.Margin = new Thickness(0, 0, 0, 5);
            art.Stretch = Stretch.Uniform;
            art.Source = new BitmapImage(new Uri("/Assets/Images/icon.png", UriKind.Relative));
            art.Height = 100;
            art.Width = 100;            
            Grid.SetColumn(art, 1);
            Grid.SetRowSpan(art, 2);
            grid.Children.Add(art);

            //title textblock
            TextBlock videoTitle = new TextBlock();
            videoTitle.Text = video.name;
            videoTitle.Margin = new Thickness(0, 0, 0, 0);
            videoTitle.Height = 30;
            videoTitle.FontSize = 24;
            videoTitle.Foreground = new SolidColorBrush(Colors.Black);
            videoTitle.VerticalAlignment = VerticalAlignment.Top;

            //videoTitle.Background = brush;
            Grid.SetRowSpan(videoTitle, 1);
            Grid.SetRow(videoTitle, 0);
            Grid.SetColumn(videoTitle, 2);
            grid.Children.Add(videoTitle);

            //Movie description
            int fontSize = 18;
            TextBlock videoInfo = new TextBlock();
            videoInfo.Margin = new Thickness(0, 0, 0, 5);
            videoInfo.Height = 80;
            videoInfo.Text = video.toStringPretty();
            videoInfo.FontSize = fontSize;
            videoInfo.Foreground = new SolidColorBrush(Colors.Black);
            videoInfo.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRowSpan(videoInfo, 1);
            Grid.SetRow(videoInfo, 1);
            Grid.SetColumn(videoInfo, 2);
            grid.Children.Add(videoInfo);

            //button
            Button videoButton = new Button();
            Image img = new Image();
            img.Height = 100;
            img.Source = new BitmapImage(new Uri("/Assets/Images/arrow.png", UriKind.Relative));
            videoButton.Content = img;
            Brush buttonBrush = new SolidColorBrush(Colors.White);
            buttonBrush.Opacity = 0;
            videoButton.Background = buttonBrush;
            videoButton.BorderThickness = new Thickness(0);
            videoButton.FontSize = 32;
            videoButton.Margin = new Thickness(0, 1, 10, 5);
            videoButton.Click += new RoutedEventHandler(videoClicked);
            Grid.SetRowSpan(videoButton, 2);
            Grid.SetRow(videoButton, 0);
            Grid.SetColumn(videoButton, 3);
            grid.Children.Add(videoButton);
            
            ResultsStackPanel.Children.Add(grid);
            videoMap.Add(videoButton, new KeyValuePair<Video, Grid>(video, grid));
        }

        public void filter(string filterText)
        {
            displayedVideos.Clear();
            filterText = filterText.ToUpper();

            foreach (Video video in videos)
            {
                if (video.contains(filterText))               
                    displayedVideos.Add(video);                
            }

            displayVideos();
        }

        public void clearStackPanel()
        {
            foreach (KeyValuePair<Button, KeyValuePair<Video, Grid>> videoPair in videoMap)
                ResultsStackPanel.Children.Remove(videoPair.Value.Value);
        }

        public void removeFilter()
        {
            displayedVideos.Clear();

            foreach (Video video in videos)           
                    displayedVideos.Add(video);
            
            displayVideos();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Navigator.navigateAndClearStack(new MainScreen());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Navigator.navigateBack();
        }

        private void videoClicked(object sender, RoutedEventArgs e)
        {
            Video video = videoMap[(Button)sender].Key;
            Navigator.navigate(new MovieScreen(), video);
        }

        private void FilterTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (FilterTextBox.Text == "")
                FilterTextBox.Text = "Filter Results";
        }

        private void FilterTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (FilterTextBox.Text == "Filter Results")
                FilterTextBox.Text = "";
        }

        public void useState(params object[] state)
        {
            header.Text = (string)state[0];
            videos = (List<Video>)state[1];
            displayedVideos.AddRange(videos.GetRange(0, videos.Count));
            displayVideos();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (FilterTextBox.Text != "" && FilterTextBox.Text != "Filter Results")
                filter(FilterTextBox.Text);
            else
                removeFilter();
        }

        private void FilterTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            filter(FilterTextBox.Text);
        }
    }
}
