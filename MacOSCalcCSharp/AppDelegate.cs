using System;
using AppKit;
using Foundation;

namespace MacOSCalcCSharp
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        public AppDelegate()
        {/*caret*/
            
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            Console.Write("The application has launched!");
            // Insert code here to initialize your application
        }

        public override void WillTerminate(NSNotification notification)
        {
            Console.Write("The Application is quiting");
            // Insert code here to tear down your application
        }
    }
}
