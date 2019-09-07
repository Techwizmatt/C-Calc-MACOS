using System;

using AppKit;
using Foundation;

namespace MacOSCalcCSharp
{
    public partial class ViewController : NSViewController
    {
        
        /*This is where we will be constantly taking the */

        /*We use a long so we can handle numbers up to 9,223,372,036,854,775,807 (64 BIT)*/
        private long pastDerivative = 0; /* The number before we press a action button */
        
        /*We use a ulong (Unsigned LONG) so we can handle numbers up to 18,446,744,073,709,551,615 (Twice the amount of past/next Derivative, just incase) (64 BIT)*/
        private long currentDerivative = 0; /* The next number after we press solve (=) */

        enum actions
        {
            multiply,
            divide,
            add,
            subtract
        }
        
        private actions currentAction;
        private Boolean isOnAction = false;
        private string screenText = "";

        public ViewController(IntPtr handle) : base(handle)
        {
            
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Console.Write("The view has loaded!");    
            // Do any additional setup after loading the view.
        }

        partial void ceButton(Foundation.NSObject sender)
        { 
            /* This action will reset all the Derivative var values */
            pastDerivative = 0;
            currentDerivative = 0;
            screenText = "";
            isOnAction = false;
            setTextField(screenText);
        }
        
        partial void numberButton(Foundation.NSObject sender)
        { 
            /* This will take the title of the button that was pressed and convert it to a NSString -> String -> Short( JAVA TERM, LOL ) ( 16Bit - INT ) */
            string numberPressed = (NSString) sender.ValueForKey((NSString) "title");

            if (numberPressed.Contains("."))
            {
                var alert = new NSAlert () {
                    AlertStyle = NSAlertStyle.Critical,
                    InformativeText = "Fuck, The decimal point kinda kills me...",
                    MessageText = "OH SSHHIIIIT!",
                };
                
                alert.RunModal ();
                return;
            }
            
            screenText += numberPressed;

            currentDerivative = long.Parse(screenText);
            
            if (!isOnAction)
            {
                pastDerivative = long.Parse(screenText);
            }
            else
            {
                Console.WriteLine("past: " + pastDerivative.ToString());
                Console.WriteLine("current: " + currentDerivative.ToString());
            }
            
            setTextField(screenText);
            
        }
        
        partial void actionButton(Foundation.NSObject sender)
        { 
            /* This will take the title of the button that was pressed and convert it to a NSString -> String */
            string actionPressed = (NSString) sender.ValueForKey((NSString) "title");

            switch (actionPressed)
            {
                case "*":
                    currentAction = actions.multiply;
                    break;
                case "/":
                    currentAction = actions.divide;
                    break;
                case "-":
                    currentAction = actions.subtract;
                    break;
                case "+":
                    currentAction = actions.add;
                    break;
            }

            if (!isOnAction)
            {
                isOnAction = true;
            }
            
            screenText = "";

            /* addToTextField(actionPressed.ToString()); */
        }

        partial void equalButton(Foundation.NSObject sender)
        {
            /* This is where we will handle what happens upon clicking the equal sign. */
            {
                
                switch (currentAction)
                {
                    case actions.add:
                        currentDerivative = pastDerivative + currentDerivative;
                        break;
                    case actions.subtract:
                        currentDerivative = pastDerivative - currentDerivative;
                        break;
                    case actions.multiply:
                        currentDerivative = pastDerivative * currentDerivative;
                        break;
                    case actions.divide:
                        currentDerivative = pastDerivative / currentDerivative;
                        break;
                }
                
                if (pastDerivative == currentDerivative)
                {
                    if (currentDerivative != 0)
                    {
                        if (isOnAction)
                        {
                            pastDerivative = currentDerivative;
                        }
                        
                    }
                }
                
                pastDerivative = currentDerivative;
                screenText = currentDerivative.ToString();
                setTextField(currentDerivative.ToString());
            }
        }

        void setTextField(string text)
        {
            entryField.StringValue = text;
        }

        Int64 textFieldValue()
        {
            return Int64.Parse(entryField.StringValue);
        }
        
        void addToTextField(string text)
        {
            screenText += text;
            setTextField(screenText);
        }

        void solveScreenValue()
        {

        }
        
        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
