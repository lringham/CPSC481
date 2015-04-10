using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElderlyNetflix.Code
{
    class Video
    {
        public String name;
        public String genre;
        public String director;
        public String[] actors;
        public String year;

        public Video(String name, String genre = "", String director = "", String year = "", String[] actors = null)
        {
            this.name = name;
            this.genre = genre;
            this.director = director;            
            this.year = year;    

            if(actors == null)
                this.actors = new String[0];
            else
                this.actors = actors;
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
            String info =  
                (year           != "" ? " (" + year +")"    : "") + 
                (genre+director != "" ? "\n"                : "") + 
                (director       != "" ? director + ", "     : "") + 
                (genre          != "" ? genre               : "");

            char[] infoArray = info.ToCharArray();
            if (infoArray.Length > 0 && infoArray[infoArray.Length - 1] == ',' && genre != ",")
                return name + info.Substring(0, info.Length - 2);
            else
                return name + info;
        }

        public String toStringSimple()
        {
            String info =
                (year != "" ? " (" + year + ")" : "") +
                (director != "" ? ", " + director : "") +
                (genre != "" ? ", " + genre : "");

            return name + info;
        }

        public bool contains(String search)
        {
            search = search.ToUpper();
            bool result = name.ToUpper().IndexOf(search) > -1 || genre.ToUpper().IndexOf(search) > -1 || director.ToUpper().IndexOf(search) > -1 || year.ToUpper().IndexOf(search) > -1;
            if (result) 
                return result;

            foreach (String actor in actors)
                if (actor.ToUpper().IndexOf(actor) > -1)
                    return true;

            return result;
        }
    }
}
