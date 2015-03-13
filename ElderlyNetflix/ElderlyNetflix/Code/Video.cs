using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElderlyNetflix.Code
{
    class Video
    {
        public string name;
        public string genre;
        public string director;
        public string[] actors;
        public string year;

        public Video(string name, string genre = "", string director = "", string year = "", string[] actors = null)
        {
            this.name = name;
            this.genre = genre;
            this.director = director;
            this.actors = actors;
            this.year = year;    
        }

        public string toStringPretty()
        {
            string info =  
                (year           != "" ? " (" + year +")"    : "") + //print the year if it exsists                
                (genre+director != "" ? " - "               : "") + //print a newline if there is more movie info
                (director       != "" ? director + ", "     : "") + 
                (genre          != "" ? genre               : "");

            char[] infoArray = info.ToCharArray();
            if (infoArray.Length > 0 && infoArray[infoArray.Length - 1] == ',' && genre != ",")
                return name + info.Substring(0, info.Length - 2);
            else
                return name + info;
        }
    }
}
