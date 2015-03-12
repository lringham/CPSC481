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
        
        public Video(string name, string genre = "", string director = "", string[] actors = null, string year = "")
        {
            this.name = name;
            this.genre = genre;
            this.director = director;
            this.actors = actors;
            this.year = year;    
        }

        public string toStringPretty()
        {
            return name +
                (genre      != "" ? "\n" + genre    : "") +
                (director   != "" ? "\n" + director : "") +
                (year       != "" ? "\n" + year     : "");

        }
    }
}
