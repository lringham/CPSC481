using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElderlyNetflix.Code
{
    class FakeDatabase
    {
        private static List<Video> videos = new List<Video>();
        private static List<Video> favoriteVideos = new List<Video>();
        private static List<Video> recentVideos = new List<Video>();
        private static List<Video> searchedVideos = new List<Video>();
        private static List<Video> browseVideos = new List<Video>();

        public static void initalize()
        {
            Video video;
            video = new Video
                ("Spectre",
                "Action",
                "Sam Mendes",
                "2015",
                "A cryptic message from Bond's past sends him on a trail to uncover a sinister organization. While M battles political forces to keep the secret service alive, Bond peels back the layers of deceit to reveal the terrible truth behind SPECTRE.",
                new String[] {"Daniel Craig", "Christoph Waltz", "Ralph Fiennes"});
            recentVideos.Add(video);
            favoriteVideos.Add(video);
            videos.Add(video);

            video = new Video
               ("Cinderella",
                "Fantasy",
                "Kenneth Branagh",
                "2015",
                "When her father unexpectedly passes away, young Ella finds herself at the mercy of her cruel stepmother and her daughters. Never one to give up hope, Ella's fortunes begin to change after meeting a dashing stranger.",
                new String[] { "Lily James", "Cate Blanchett", "Richard Madden"});
            favoriteVideos.Add(video);
            videos.Add(video);

            video = new Video
                ("Arrow",
                "Action",
                "Greg Berlanti",
                "2012",
                "Spoiled billionaire playboy Oliver Queen is missing and presumed dead when his yacht is lost at sea. He returns five years later a changed man, determined to clean up the city as a hooded vigilante armed with a bow.",
                new String[] { "Stephen Amell", "Katie Cassidy", "David Ramsey" });
            recentVideos.Add(video);
            favoriteVideos.Add(video);
            videos.Add(video);

            video = new Video
                ("Avengers: Age of Ultron",
                "Action",
                "Joss Whedon",
                "2015",
                "When Tony Stark tries to jumpstart a dormant peacekeeping program, things go awry and it is up to the Avengers to stop the villainous Ultron from enacting his terrible plans.",
                new String[] { "Robert Downey Jr.", "Chris Evans", "Mark Ruffalo" });
            recentVideos.Add(video);
            videos.Add(video);

            video = new Video
                ("Kingsman: The Secret Service",
                "Comedy",
                "Matthew Vaughn",
                "2014",
                "A spy organization recruits an unrefined, but promising street kid into the agency's ultra-competitive training program, just as a global threat emerges from a twisted tech genius.",
                new String[] { "Colin Firth", "Taron Egerton", "Samuel L. Jackson" });
            recentVideos.Add(video);
            videos.Add(video);

            video = new Video
                ("Prisoners",
                "Mystery",
                "Denis Villeneuve",
                "2013",
                "When Keller Dover's daughter and her friend go missing, he takes matters into his own hands as the police pursue multiple leads and the pressure mounts. But just how far will this desperate father go to protect his family?",
                new String[] { "Hugh Jackman", "Jake Gyllenhaal", "Viola Davis" });
            videos.Add(video);
            favoriteVideos.Add(video);

            int j = 0;
            for (int i = 0; i < 50; i++)
            {
                String[] genres = {"Action", "Comedy", "Drama", "Horror", "Thriller"};
                
                if (i != 0 && i % 10 == 0)
                    j++;
      
                video = new Video("Movie " + (i + 1), genres[j], "Cory Hutchison", "1986");

                browseVideos.Add(video);
                videos.Add(video);
            }
        }

        public static List<Video> getFavoriteVideos()
        {
            return favoriteVideos;
        }

        public static List<Video> getRecentVideos()
        {
            return recentVideos;
        }

        public static List<Video> getSearchedVideos()
        {
            return searchedVideos;
        }

        public static List<Video> getBrowseVideos()
        {
            return browseVideos;
        }

        public static List<Video> getSuggestedVideos(String suggestion)
        {
            List<Video> suggestions = new List<Video>();

            foreach (Video video in videos)
                if (video.contains(suggestion))
                    suggestions.Add(video);
                
            return suggestions;   
        }
    }
}

