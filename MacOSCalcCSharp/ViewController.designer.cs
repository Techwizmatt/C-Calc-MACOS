// WARNING
//
// This file has been generated automatically by Rider IDE
//   to store outlets and actions made in Xcode.
// If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MacOSCalcCSharp
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextField entryField { get; set; }

		[Action ("actionButton:")]
		partial void actionButton (Foundation.NSObject sender);

		[Action ("ceButton:")]
		partial void ceButton (Foundation.NSObject sender);

		[Action ("decimalButton:")]
		partial void decimalButton (Foundation.NSObject sender);

		[Action ("equalButton:")]
		partial void equalButton (Foundation.NSObject sender);

		[Action ("numberButton:")]
		partial void numberButton (Foundation.NSObject sender);

		void ReleaseDesignerOutlets ()
		{
			if (entryField != null) {
				entryField.Dispose ();
				entryField = null;
			}

		}
	}
}
