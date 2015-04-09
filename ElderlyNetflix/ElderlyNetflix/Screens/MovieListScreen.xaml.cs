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

        int gridWidth = 1280;
        int col1Perc = 80;
        int col2Perc = 20;
        int margin = 1;
        int rowHeight = 55;
        int fontSize = 18;

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
            Grid grid = new Grid();
            grid.Width = gridWidth;
            grid.HorizontalAlignment = HorizontalAlignment.Left;
            grid.VerticalAlignment = VerticalAlignment.Top;
            grid.ShowGridLines = false;
            //grid.Background = b;

            ColumnDefinition gridCol1 = new ColumnDefinition();
            ColumnDefinition gridCol2 = new ColumnDefinition();
            gridCol1.Width = new GridLength(col1Perc, GridUnitType.Star);
            gridCol2.Width = new GridLength(col2Perc, GridUnitType.Star);
            grid.ColumnDefinitions.Add(gridCol1);
            grid.ColumnDefinitions.Add(gridCol2);

            TextBlock videoInfo = new TextBlock();
            videoInfo.Margin = new Thickness(10, margin, 0, margin);
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
            Grid.SetColumn(videoInfo, 0);
            grid.Children.Add(videoInfo);

            Button videoButton = new Button();
            videoButton.Content = "More Info";
            videoButton.Click += new RoutedEventHandler(videoClicked);
            Grid.SetRow(videoButton, 0);
            Grid.SetColumn(videoButton, 1);
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
