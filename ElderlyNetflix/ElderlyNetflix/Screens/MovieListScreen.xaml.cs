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
            //grid.Background = b;

            int col0Perc = 15;
            int col1Perc = 10;
            int col2Perc = 40;
            int col3Perc = 20;
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

            //image
            Image art = new Image();
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri("/ElderlyNetflix;component/Assets/Images/icon.png", UriKind.Relative);
            bi.EndInit();
            art.Stretch = Stretch.Uniform;
            art.Source = bi;
            art.Height = 45;
            art.Width = art.Height / 2;
            Grid.SetColumn(art, 1);
            grid.Children.Add(art);

            //Movie description
            int rowHeight = 55;
            int fontSize = 18;
            TextBlock videoInfo = new TextBlock();
            videoInfo.Margin = new Thickness(10, 1, 0, 1);
            videoInfo.Height = rowHeight;
            videoInfo.Text = video.toStringPretty();
            videoInfo.FontSize = fontSize;
            videoInfo.FontWeight = FontWeights.Bold;
            videoInfo.Foreground = new SolidColorBrush(Colors.Black);
            videoInfo.VerticalAlignment = VerticalAlignment.Top;
            Brush brush = new SolidColorBrush(Colors.CornflowerBlue);
            brush.Opacity = .1;
            videoInfo.Background = brush;
            Grid.SetRow(videoInfo, 0);
            Grid.SetColumn(videoInfo, 2);
            grid.Children.Add(videoInfo);

            //button
            Button videoButton = new Button();
            videoButton.Content = "Play";
            videoButton.Margin = new Thickness(0, 1, 10, 1);
            videoButton.Click += new RoutedEventHandler(videoClicked);
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
