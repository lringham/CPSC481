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
            for (int i = 0; i < 3; i++)
            {
                video = new Video("Favorite Movie " + i);

                favoriteVideos.Add(video);
                videos.Add(video);
            }

            for (int i = 0; i < 20; i++)
            {
                if (i % 2 == 0)
                    video = new Video("Movie " + i, "Horror", "Lee Ringham", "1961");
                else
                    video = new Video("Movie " + i, "Comedy", "Lee Ringham");

                recentVideos.Add(video);
                videos.Add(video);
            }

            for (int i = 0; i < 3; i++)
            {
               video = new Video("Searched Movie " + i);

               searchedVideos.Add(video);
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
