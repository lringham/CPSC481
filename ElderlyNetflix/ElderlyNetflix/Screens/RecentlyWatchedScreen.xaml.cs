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
    public partial class RecentlyWatchedScreen : UserControl
    {
        Dictionary<Video, Grid> videos = new Dictionary<Video, Grid>();
        Dictionary<int, Video> filteredVideos = new Dictionary<int, Video>();
        Dictionary<Button, Video> buttonVideoMap = new Dictionary<Button, Video>();

        int gridWidth = 1280;
        int col1Perc = 80;
        int col2Perc = 20;
        int margin = 10;
        int rowHeight = 55;
        int fontSize = 18;

        public RecentlyWatchedScreen()
        {
            InitializeComponent();

            for (int i = 0; i < 20; i++)
                if (i % 2 == 0)
                    addResult(new Video("Movie " + i, "Horror", "Lee Ringham", "1961"));
                else
                    addResult(new Video("Movie " + 5, "Comedy", "Lee Ringham"));
        }

        private void addResult(Video video)
        {
            Grid grid = new Grid();
            grid.Width = gridWidth;
            grid.HorizontalAlignment = HorizontalAlignment.Left;
            grid.VerticalAlignment = VerticalAlignment.Top;
            grid.ShowGridLines = false;
            //grid.Background = new SolidColorBrush(Colors.CornflowerBlue);

            ColumnDefinition gridCol1 = new ColumnDefinition();
            ColumnDefinition gridCol2 = new ColumnDefinition();
            gridCol1.Width = new GridLength(col1Perc, GridUnitType.Star);
            gridCol2.Width = new GridLength(col2Perc, GridUnitType.Star);
            grid.ColumnDefinitions.Add(gridCol1);
            grid.ColumnDefinitions.Add(gridCol2);

            TextBlock videoInfo = new TextBlock();
            videoInfo.Margin = new Thickness(margin);
            videoInfo.Height = rowHeight;
            videoInfo.Text = video.toStringPretty();
            videoInfo.FontSize = fontSize;
            videoInfo.FontWeight = FontWeights.Bold;
            videoInfo.Foreground = new SolidColorBrush(Colors.Black);
            videoInfo.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(videoInfo, 0);
            Grid.SetColumn(videoInfo, 0);
            grid.Children.Add(videoInfo);

            Button videoButton = new Button();
            videoButton.Content = "Play";
            videoButton.Click += new RoutedEventHandler(videoClicked);
            Grid.SetRow(videoButton, 0);
            Grid.SetColumn(videoButton, 1);
            grid.Children.Add(videoButton);

            ResultsStackPanel.Children.Add(grid);
            videos.Add(video, grid);
            buttonVideoMap.Add(videoButton, video);
        }

        public void filter(string filterText)
        {
            filteredVideos.Clear();

            int i = 0;
            filterText = filterText.ToUpper();

            foreach (KeyValuePair<Video, Grid> videoPair in videos)
            {
                if (!videoPair.Key.name.ToUpper().Contains(filterText))
                {
                    filteredVideos.Add(i, videoPair.Key);
                    ResultsStackPanel.Children.Remove(videoPair.Value);
                }
                i++;
            }

            foreach (KeyValuePair<int, Video> videoPair in filteredVideos)
            {
                videos.Remove(videoPair.Value);
            }
        }

        public void clearStackPanel()
        {
            foreach (KeyValuePair<Video, Grid> videoPair in videos)
                ResultsStackPanel.Children.Remove(videoPair.Value);
        }

        public void removeFilter()
        {
            clearStackPanel();
            List<Video> videosInOrder = new List<Video>();

            int totalVideoCount = videos.Count + filteredVideos.Count;
            int j = 0;
            for (int i = 0; i < totalVideoCount; ++i)
            {
                Video video;
                if (filteredVideos.TryGetValue(i, out video))
                    videosInOrder.Add(video);
                else if (videos.Keys.Count > j)
                    videosInOrder.Add(videos.Keys.ElementAt<Video>(j++));
                else
                    throw new Exception("Invald video...?! This should never happen");
            }

            videos.Clear();
            buttonVideoMap.Clear();
            foreach (Video video in videosInOrder)
                addResult(video);
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
            Video video = buttonVideoMap[(Button)sender];
            Navigator.navigate(new FavoritesScreen(), video);
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
    }
}
