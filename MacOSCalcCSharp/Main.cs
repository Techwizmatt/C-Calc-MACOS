using AppKit;
using System;

namespace MacOSCalcCSharp
{
    static class MainClass
    {
        static void Main(string[] args)
        {
            /*
             * This is a the main entrance point of the Application, It calls the app and will trigger the associative functions in the AppDelegate
             */
            NSApplication.Init(); 
            NSApplication.Main(args);
        }
    }
} 
