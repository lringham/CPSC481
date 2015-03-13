using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElderlyNetflix.Code
{
    class FakeDatabase
    {
        public static List<Video> getFavoriteVideos()
        {
            List<Video> videos = new List<Video>();
            for (int i = 0; i < 3; i++)
                videos.Add(new Video("Favorite Movie " + i));
            return videos;
        }

        public static List<Video> getRecentVideos()
        {
            List<Video> videos = new List<Video>();
            for (int i = 0; i < 20; i++)
                if (i % 2 == 0)
                    videos.Add(new Video("Movie " + i, "Horror", "Lee Ringham", "1961"));
                else
                    videos.Add(new Video("Movie " + 5, "Comedy", "Lee Ringham"));
            return videos;
        }

        public static List<Video> getSearchedVideos()
        {
            List<Video> videos = new List<Video>();
            for (int i = 0; i < 3; i++)
                videos.Add(new Video("Searched Movie " + i));
            return videos;
        }
    }
}
