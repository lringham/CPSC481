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

            video = new Video
                ("Daredevil",
                "Action",
                "Drew Goddard",
                "2015",
                "A blind lawyer with his other senses superhumanly enhanced fights crime as a costumed superhero.",
                new String[] { "Charlie Cox", "Deborah Ann Woll", "Elden Henson" });
            videos.Add(video);

            video = new Video
                ("Whiplash",
                "Drama",
                "Damien Chazelle",
                "2014",
                "A promising young drummer enrolls at a cut-throat music conservatory where his dreams of greatness are mentored by an instructor who will stop at nothing to realize a student's potential.",
                new String[] { "Miles Teller", "J.K. Simmons", "Melissa Benoist" });
            videos.Add(video);

            video = new Video
                ("Matrix, The",
                "Action",
                "Andy Wachowski & Lana Wachowski",
                "1999",
                "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
                new String[] { "Keanu Reeves", "Laurence Fishburne", "Carrie-Anne Moss" });
            videos.Add(video);

            video = new Video
                ("John Wick",
                "Action",
                "Chad Stahelski & David Leitch",
                "2014",
                "An ex-hitman comes out of retirement to track down the gangsters that took everything from him.",
                new String[] { "Keanu Reeves", "Michael Nyqvist", "Alfie Allen" });
            videos.Add(video);

            video = new Video
                ("Thing, The", 
                "Horror",
                "John Carpenter",
                "1982",
                "Scientists in the Antarctic are confronted by a shape-shifting alien that assumes the appearance of the people that it kills.",
                new String[] { "Kurt Russell", "Wilford Brimley", "Keith David" });
            videos.Add(video);

            video = new Video
                ("Citizenfour",
                "Documentary",
                "Laura Poitras",
                "2015",
                "A documentarian and a reporter travel to Hong Kong for the first of many meetings with Edward Snowden.",
                new String[] { "Edward Snowden", "Glenn Greenwald", "William Binney" });
            videos.Add(video);

            video = new Video
                ("2001: A Space Odyssey",
                "Sci-Fi",
                "Stanley Kubrick",
                "1968",
                "Humanity finds a mysterious, obviously artificial, object buried beneath the Lunar surface and, with the intelligent computer H.A.L. 9000, sets off on a quest.",
                new String[] { "Keir Dullea", "Gary Lockwood", "William Sylvester" });
            videos.Add(video);

            video = new Video
                ("Blade Runner",
                "Sci-Fi",
                "Ridley Scott",
                "1982",
                "A blade runner must pursue and try to terminate four replicants who stole a ship in space and have returned to Earth to find their creator.",
                new String[] { "Harrison Ford", "Rutger Hauer", "Sean Young" });
            videos.Add(video);

            video = new Video
                ("Good Will Hunting",
                "Drama",
                "Gus Van Sant",
                "1997",
                "Will Hunting, a janitor at M.I.T., has a gift for mathematics, but needs help from a psychologist to find direction in his life.",
                new String[] { "Robin Williams", "Matt Damon", "Ben Afflect" });
            videos.Add(video);

            video = new Video
                ("Interstellar",
                "Sci-Fi",
                "Christopher Nolan",
                "2014",
                "A team of explorers travel through a wormhole in an attempt to ensure humanity's survival.",
                new String[] { "Matthew McConaughey", "Anne Hathaway", "Jessica Chastain" });
            videos.Add(video);

            video = new Video
                ("True Detective",
                "Drama",
                "Nic Pizzolatto",
                "2014",
                "An anthology police detective series in which investigations seem to unearth both personal and professional secrets of those involved, both within or outside the law.",
                new String[] { "Matthew McConaughey", "Woody Harrelson", "Michelle Monaghan" });
            videos.Add(video);

            video = new Video
                ("Breaking Bad",
                "Drama",
                "Vince Gilligan",
                "2008",
                "A chemistry teacher diagnosed with a terminal lung cancer, teams up with his former student, Jesse Pinkman, to cook and sell crystal meth.",
                new String[] { "Bryan Cranston", "Aaron Paul", "Anna Gunn" });
            videos.Add(video);

            video = new Video
                ("Alien",
                "Horror",
                "Ridley Scott",
                "1979",
                "The commercial vessel Nostromo receives a distress call from an unexplored planet. After searching for survivors, the crew heads home only to realize that a deadly bioform has joined them.",
                new String[] { "Sigourney Weaver", "Tom Skerritt", "John Hurt" });
            videos.Add(video);
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

        public static List<Video> getVideos()
        {
            return videos;
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

