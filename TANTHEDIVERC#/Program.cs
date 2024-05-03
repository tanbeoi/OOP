using System;
using SplashKitSDK;

namespace TANTHEDIVERC_
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("TAN THE DIVER", 1000, 750);


            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}   
