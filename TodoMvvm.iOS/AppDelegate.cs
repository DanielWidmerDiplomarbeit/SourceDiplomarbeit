using System;
using System.IO;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Xamarin.Forms;
using ZeusMobile;

namespace ZeusMobileiOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        UIWindow window;
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();
            // create a new window instance based on the screen size
            window = new UIWindow(UIScreen.MainScreen.Bounds);

            var sqliteFilename = "ZeusMobileDB.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);

            Console.WriteLine(path);
            File.Delete(path);


            var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);

            // Set the database connection string
            App.SetDatabaseConnection(conn);


            // If you have defined a view, add it here:
            // window.RootViewController  = navigationController;
            window.RootViewController = App.GetMainPage().CreateViewController();

            // make the window visible
            window.MakeKeyAndVisible();

            return true;
        }
    }
}