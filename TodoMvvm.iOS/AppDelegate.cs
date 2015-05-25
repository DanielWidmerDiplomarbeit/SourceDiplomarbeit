using System;
using System.IO;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Xamarin.Forms;
using ZeusMobile;
using ZeusMobile.Data;

namespace ZeusMobileiOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        UIWindow _window;
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();

            _window = new UIWindow(UIScreen.MainScreen.Bounds);

            const string sqliteFilename = "ZeusMobileDB.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library");
            
            // Datenbank starten
            var path = Path.Combine(libraryPath, sqliteFilename);

			File.Delete (path);


            var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);
            App.SetDatabaseConnection(conn);

			var demoData = new DemoData();
			demoData.BuildDemoData(App.Database);
            
            _window.RootViewController = App.GetMainPage().CreateViewController();

            _window.MakeKeyAndVisible();

            return true;
        }
    }
}