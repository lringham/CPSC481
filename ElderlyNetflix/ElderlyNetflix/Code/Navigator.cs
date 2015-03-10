using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ElderlyNetflix.Code
{
    public static class Navigator
    {
        private static bool initialized = false;
    	private static Main window;

        public static void setWindow(Main tmpWindow)
        {
            window = tmpWindow;
            initialized = true;
        }

    	public static void navigate(UserControl page)
    	{
            if (!initialized)
                throw new Exception("Window not set in Navigator class");

            window.Content = page;
    	}

        public static void navigate(UserControl page, object state)
    	{
            if (!initialized)
                throw new Exception("Window not set in Navigator class");

            window.Content = page;
            INavigable nav = page as INavigable;

            if (nav == null)
                throw new Exception("UserControl is not INavigable");

            nav.useState(state);
    	}
    }
}