using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ElderlyNetflix.Code
{
    class Video
    {
        /*
         * Video:
         *      name
         *      genre
         *      director
         *      list of actors
         *      year
         *      plot
         *      cover image
         */
        public String name;
        public String genre;
        public String director;
        public String[] actors;
        public String year;
        public String plot;
        public BitmapImage image;

        /*
         * Constructor
         */
        public Video(String name, String genre = "", String director = "", String year = "", string plot = "", String[] actors = null)
        {
            this.name = name;
            this.genre = genre;
            this.director = director;            
            this.year = year;    

            if(actors == null)
                this.actors = new String[0];
            else
                this.actors = actors;

            this.plot = plot;


            image = new BitmapImage(new Uri(this.getImagePath(), UriKind.Relative));
        }

        /*
         * Returns an absolute path to the Video's box image.
         * Returns:     "/Assets/Images/MovieCovers/<img>.jpg"
         */
        public String getImagePath()
        {
            char[] delim = { ' ', ',', ':' };
            string[] imgName = name.ToLower().Split(delim);

            return "/Assets/Images/MovieCovers/" + imgName[0] + ".jpg";
        }

        /*
         * Prints out the video information in the format of:
         * 
         *      Name (Year)
         *      Director, Year, Genre
         *      List of Actors
         *      
         * Returns:     "Name (Year)\nDirector, Year, Genre\nActor1, Actor2, ..."
         */
        public String toStringPretty()
        {
            String info = director + ", " + year + ", " + genre + "\n";
            foreach(String actor in actors)
                info += actor + ", ";
            info = info.Remove(info.LastIndexOf(", "));
            return info;
        }

        /*
         * Returns a simple Video description if video details are present in the format:
         * 
         *      Name (Year), Director, Genre
         *      
         * Returns:     "Name (Year), Director, Genre"
         */
        public String toStringSimple()
        {
            String detail = details();
            return name + (detail != "" ? " " + detail : "");
        }

        /*
         * Returns a boolean result if the searched string is contained in any of the video details.
         * Args:        String search - The requested search
         * Returns:     True - If the search is present in any of the results
         *              False - If the search is NOT present in any of the results
         */
        public bool contains(String search)
        {
            search = search.ToUpper();
            bool result = name.ToUpper().IndexOf(search) > -1 || genre.ToUpper().IndexOf(search) > -1 || director.ToUpper().IndexOf(search) > -1 || year.ToUpper().IndexOf(search) > -1;
            if (result) 
                return result;

            foreach (String actor in actors)
                if (actor.ToUpper().IndexOf(search) > -1)
                    return true;

            return result;
        }


        /*
         *  Composes a string of the format:
         *  
         *          (Year), Director, Genre
         *          
         *  If the elements are present in the video content.
         *  Returns:        "(Year), Director, Genre"
         */
        public String details()
        {
            bool hasYear = year != "";
            bool hasDirector = director != "";
            bool hasGenre = genre != "";

            String info = "";

            if (hasYear)
                info = "(" + year + ")";

            if (hasDirector)
            {
                if(hasYear)
                    info += ", ";
                info += director;
            }

            if(hasGenre)
            {
                if (hasYear || hasDirector)
                    info += ", ";
                info += genre;
            }

            return info;
        }        
    }
}
