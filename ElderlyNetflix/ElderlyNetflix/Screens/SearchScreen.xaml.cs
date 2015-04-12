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
    /// Interaction logic for SearchScreen.xaml
    /// </summary>
    public partial class SearchScreen : UserControl, INavigable
    {
        Dictionary<TextBlock, Video> suggestions = new Dictionary<TextBlock, Video>();

        public SearchScreen()
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

            img = new Image();
            img.Height = 75;
            img.Width = 75;
            img.Source = new BitmapImage(new Uri("/Assets/Images/profile.png", UriKind.Relative));
            profileButton.Content = img;

            suggestionsBox.Height = 0;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Navigator.navigateAndClearStack(new MainScreen());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Navigator.navigateBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SearchBar.Text != "Search for Name, Director, Year or Actor" && SearchBar.Text != "")
                Navigator.navigate(new MovieListScreen(), "Search Results for \"" + SearchBar.Text + "\"", FakeDatabase.getSuggestedVideos(SearchBar.Text));
        }

        private void SearchBar_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBar.Text == "Search for Name, Director, Year or Actor")
                SearchBar.Text = "";
        }

        private void SearchBar_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBar.Text == "")
                SearchBar.Text = "Search for Name, Director, Year or Actor";
        }

        private void addSuggestion(Video video)
        {
            int fontSize = 18;
            TextBlock text = new TextBlock();
            text.Margin = new Thickness(5, 0, 0, 0);
            text.Text = video.toStringSimple();
            text.FontSize = fontSize;
            text.VerticalAlignment = VerticalAlignment.Top;
            text.MouseDown += new MouseButtonEventHandler(suggestionClicked);
            text.MouseEnter += new MouseEventHandler(mouseEnter);
            text.MouseLeave += new MouseEventHandler(mouseLeave);

            if (suggestions.Count <= 15)
            {
                suggestionsBox.Children.Add(text);
                suggestionsBox.Height = suggestions.Count * text.Height;
                suggestions.Add(text, video);
            }
        }

        private void addSuggestions(List<Video> suggestions)
        {
            foreach (Video video in suggestions)           
                addSuggestion(video);        
        }

        private void clearSuggestions()
        {
            foreach (KeyValuePair<TextBlock, Video> suggestion in suggestions)
                suggestionsBox.Children.Remove(suggestion.Key);
            suggestions.Clear();
        }

        private void SearchBar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
                Navigator.navigate(new MovieListScreen(), "Search Results for \"" + SearchBar.Text + "\"", FakeDatabase.getSuggestedVideos(SearchBar.Text));
        }

        private void SearchBar_KeyUp(object sender, KeyEventArgs e)
        {
            clearSuggestions();
            if (SearchBar.Text != "")
                addSuggestions(FakeDatabase.getSuggestedVideos(SearchBar.Text));
        }

        private void suggestionClicked(object sender, RoutedEventArgs e)
        {
            Video video = suggestions[(TextBlock)sender];
            Navigator.navigate(new MovieScreen(), video);
        }

        private void mouseEnter(object sender, RoutedEventArgs e)
        {
            ((TextBlock)sender).Background = Brushes.CornflowerBlue;
        }

        private void mouseLeave(object sender, RoutedEventArgs e)
        {
            ((TextBlock)sender).Background = Brushes.White;
        }

        public void useState(params object[] state)
        {
        }

        public void resume()
        {
        }

        public void setSource(MovieSource source)
        {
        }
    }
}
