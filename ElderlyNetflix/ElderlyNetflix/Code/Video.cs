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
        public String name;
        public String genre;
        public String director;
        public String[] actors;
        public String year;
        public String plot;
        public BitmapImage image;

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

        public String getImagePath()
        {
            char[] delim = { ' ', ',', ':' };
            string[] imgName = name.ToLower().Split(delim);

            return "/Assets/Images/MovieCovers/" + imgName[0] + ".jpg";
        }

        public String getName()
        {
            return name;
        }

        public String getGenre()
        {
            return genre;
        }

        public String toStringPretty()
        {
            String info = director + ", " + year + ", " + genre + "\n";
            foreach(String actor in actors)
                info += actor + ", ";
            info = info.Remove(info.LastIndexOf(", "));
            return info;
        }

        public String toStringSimple()
        {
            String detail = details();
            return name + (detail != "" ? " " + detail : "");
        }

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
