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
        private static bool currentScreenSet = false;
    	private static Main window;
        private static Stack<UserControl> screenStack;
        private static UserControl currentScreen; 

        public static void setWindow(Main tmpWindow)
        {
            window = tmpWindow;
            initialized = true;
            screenStack = new Stack<UserControl>();
        }

    	public static void navigate(UserControl screen)
    	{
            //check if the window has been set
            checkWindowSet();

            //Save the previous screen
            if (currentScreenSet)
                screenStack.Push(currentScreen);

            //Set the new screen
            setCurrentScreen(screen);
    	}

        public static void navigateAndReplace(UserControl screen)
        {
            //Check if the window has been set
            checkWindowSet();

            //Remove current screen
            if (screenStack.Count > 0)
                screenStack.Pop();

            //Set the new screen
            setCurrentScreen(screen);
        }

        public static void navigate(UserControl screen, object state)
        {
            //Check if the window has been set
            checkWindowSet();

            //Set the new screen
            setCurrentScreen(screen);

            //Set the screens state
            INavigable navScreen = screen as INavigable;
            if (navScreen == null)
                throw new Exception("UserControl is not INavigable");
            navScreen.useState(state);
        }

        public static void navigateBack()
        {
            //Check if the window has been set
            checkWindowSet();

            //If there is a screen to navigate back to remove it from the stack and set the window content
            if (screenStack.Count > 0)
            {
                currentScreen = screenStack.Pop();
                window.Content = currentScreen;
            }
        }

        private static void checkWindowSet()
        {
            if (!initialized)
                throw new Exception("Window not set in Navigator class");
        }

        private static void setCurrentScreen(UserControl screen)
        {
            currentScreen = screen;
            window.Content = currentScreen;
            currentScreenSet = true;
        }
    }
}