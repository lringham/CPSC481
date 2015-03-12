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
    /// Interaction logic for BrowseScreen.xaml
    /// </summary>
    public partial class BrowseScreen : UserControl
    {
        private Dictionary<Video, Grid> videos = new Dictionary<Video, Grid>();
        private Dictionary<int, Video> filteredVideos = new Dictionary<int, Video>();
        private Dictionary<Button, Video> buttonVideoMap = new Dictionary<Button, Video>();

        private int WIDTH = 1280;
        private int col1Perc = 80;
        private int col2Perc = 20;
        private int margin = 10;
        private int rowHeight = 55;
        private int fontSize = 18;

        public BrowseScreen()
        {
            InitializeComponent();

            addCategory("Category 1");
            addCategory("Category 2");

        }

        private void addCategory(String title)
        {
            Grid g = new Grid();
            g.Width = WIDTH;
            g.HorizontalAlignment = HorizontalAlignment.Left;
            g.VerticalAlignment = VerticalAlignment.Top;
            g.ShowGridLines = false;

            TextBlock category = new TextBlock();
            category.Margin = new Thickness(margin);
            category.Height = rowHeight;
            category.Text = title;
            category.FontSize = 24;
            category.FontWeight = FontWeights.Bold;
            g.Children.Add(category);
            Panel.Children.Add(g);

            ScrollViewer sv = new ScrollViewer();
            sv.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            sv.Margin = new Thickness(margin);
            sv.Width = Panel.Width;
            Panel.Children.Add(sv);

            StackPanel elem = new StackPanel();
            

            for (int i = 0; i < 2; i++)
                if (i % 2 == 0)
                    addResult(new Video("Movie " + i, "Horror", "Lee Ringham", "1961"), elem);
                else
                    addResult(new Video("Movie " + 5, "Comedy", "Lee Ringham"), elem);

            sv.Content = elem;
        }

        private void addResult(Video video, StackPanel s)
        {
            // Create the grid
            Grid grid = new Grid();
            grid.Width = WIDTH;
            grid.HorizontalAlignment = HorizontalAlignment.Left;
            grid.VerticalAlignment = VerticalAlignment.Top;
            grid.ShowGridLines = false;

            ColumnDefinition gridCol1 = new ColumnDefinition();
            ColumnDefinition gridCol2 = new ColumnDefinition();
            ColumnDefinition gridCol3 = new ColumnDefinition();
            gridCol1.Width = new GridLength(30);
            gridCol2.Width = new GridLength(80, GridUnitType.Star);
            gridCol3.Width = new GridLength(15, GridUnitType.Star);
            grid.ColumnDefinitions.Add(gridCol1);
            grid.ColumnDefinitions.Add(gridCol2);
            grid.ColumnDefinitions.Add(gridCol3);
            
            // Image File
            Image art = new Image();
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri("/ElderlyNetflix;component/Assets/Images/icon.png", UriKind.Relative);
            bi.EndInit();
            art.Stretch = Stretch.Uniform;
            art.Source = bi;
            Grid.SetColumn(art, 0);
            grid.Children.Add(art);

            // Movie Info
            TextBlock videoInfo = new TextBlock();
            videoInfo.Margin = new Thickness(margin);
            videoInfo.Height = rowHeight;
            videoInfo.Text = video.toStringPretty();
            videoInfo.FontSize = fontSize;
            videoInfo.FontWeight = FontWeights.Bold;
            videoInfo.Foreground = new SolidColorBrush(Colors.Black);
            videoInfo.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(videoInfo, 0);
            Grid.SetColumn(videoInfo, 1);
            grid.Children.Add(videoInfo);

            // Info button
            Button infoButton = new Button();
            infoButton.Content = "More Info";
            infoButton.Background = Brushes.Gray;
            infoButton.Width = 80;
            //infoButton.Style.Triggers.Is
            infoButton.Click += new RoutedEventHandler(Info_Click);
            Grid.SetRow(infoButton, 0);
            Grid.SetColumn(infoButton, 2);
            grid.Children.Add(infoButton);

            // Pack it all in
            s.Children.Add(grid);
            videos.Add(video, grid);
            buttonVideoMap.Add(infoButton, video);
        }

        public void clearStackPanel(StackPanel s)
        {
            foreach (KeyValuePair<Video, Grid> videoPair in videos)
                s.Children.Remove(videoPair.Value);
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Navigator.navigate(new MainScreen());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Navigator.navigateBack();
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Handle going to Movie Info Page
        }
    }
}
