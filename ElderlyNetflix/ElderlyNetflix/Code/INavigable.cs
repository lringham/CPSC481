﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElderlyNetflix.Code
{
    public delegate List<Video> MovieSource();
   
    public interface INavigable
    {
        void useState(params object[] state);
        void resume();
        void setSource(MovieSource source);
    }
}
