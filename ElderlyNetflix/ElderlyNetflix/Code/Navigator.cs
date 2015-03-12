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

        /// <summary>
        /// Initialize the Navigator class with a pointer to the main window
        /// </summary>
        /// <param name="tmpWindow"></param>
        public static void setWindow(Main mainWindow)
        {
            window = mainWindow;
            initialized = true;
            screenStack = new Stack<UserControl>();
        }

        /// <summary>
        /// Navigate to a new screen, the previous screen is saved on the screen stack
        /// </summary>
        /// <param name="screen"></param>
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

        /// <summary>
        /// Navigate to a new screen that implements INavigable.
        /// The new screen is initialized with the given state.
        /// The previous screen is saved on the screen stack
        /// </summary>
        /// <param name="screen"></param>
        /// <param name="state"></param>
        public static void navigate(UserControl screen, object state)
        {
            //Check if the window has been set
            checkWindowSet();

            //Check if the screen is actually navigable
            INavigable navScreen = screen as INavigable;
            if (navScreen == null)
                throw new Exception("UserControl is not INavigable");

            //Set the new screen
            setCurrentScreen(screen);

            //Set the screens state
            navScreen.useState(state);
        }

        /// <summary>
        /// Navigate to a new screen and replace the current screen without 
        /// saving it to the screen stack.
        /// </summary>
        /// <param name="screen"></param>
        public static void navigateAndReplace(UserControl screen)
        {
            //Check if the window has been set
            checkWindowSet();

            //Set the new screen
            setCurrentScreen(screen);
        }

        /// <summary>
        /// Navigate to a new screen and empty the entire screen stack.
        /// </summary>
        /// <param name="screen"></param>
        public static void navigateAndClearStack(UserControl screen)
        {
            //Check if the window has been set
            checkWindowSet();

            //Remove all saved screens
            screenStack.Clear();
                
            //Set the new screen
            setCurrentScreen(screen);
        }

        /// <summary>
        /// Navigate to the last seen screen on the screen stack.
        /// </summary>
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

        /// <summary>
        /// Check if the window has been registered with the Navigator class.
        /// </summary>
        private static void checkWindowSet()
        {
            if (!initialized)
                throw new Exception("Window not set in Navigator class");
        }

        /// <summary>
        /// Update the currentScreen field and the window content
        /// </summary>
        /// <param name="screen"></param>
        private static void setCurrentScreen(UserControl screen)
        {
            currentScreen = screen;
            window.Content = currentScreen;
            currentScreenSet = true;
        }
    }
}