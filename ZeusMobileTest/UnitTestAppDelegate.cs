using Foundation;
using UIKit;
using MonoTouch.NUnit.UI;

namespace ZeusMobileTest
{
	[Register ("UnitTestAppDelegate")]
	public partial class UnitTestAppDelegate : UIApplicationDelegate
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

