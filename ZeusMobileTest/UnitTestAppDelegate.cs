// <copyright company="ZHAW">
// Copyright (c) 2015 All Right Reserved
// </copyright>
// <author>Daniel Widmer</author>
// <date>30.06.2015</date>
using Foundation;
using UIKit;
using MonoTouch.NUnit.UI;

namespace ZeusMobileTest
{
	[Register ("UnitTestAppDelegate")]
	public class UnitTestAppDelegate : UIApplicationDelegate
	{
		UIWindow _window;
		TouchRunner _runner;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			_window = new UIWindow (UIScreen.MainScreen.Bounds);
			_runner = new TouchRunner (_window);
			_runner.Add (System.Reflection.Assembly.GetExecutingAssembly ());
			_window.RootViewController = new UINavigationController (_runner.GetViewController ());
			_window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

