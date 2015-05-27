using Xamarin.Forms;
using ZeusMobile.Data;
using ZeusMobile.Models;
using ZeusMobile.ViewModels;
using ZeusMobile.Views;

namespace ZeusMobile
{
    public static class App
    {
        private static void RegisterTypes()
        {
            ViewFactory.Register<SchadenNavigationView, SchadenNavigationViewModel>();
            ViewFactory.Register<SchadenListeView, SchadenListeViewModel>();
            ViewFactory.Register<VersicherteView, VersicherteViewModel>();
            ViewFactory.Register<PolicenView, PolicenViewModel>();
            ViewFactory.Register<ObjekteView, ObjekteViewModel>();
            ViewFactory.Register<SchadenView, SchadenViewModel>();
            ViewFactory.Register<ProtokollView, ProtokollViewModel>();
        }


        public static Page GetMainPage()
        {
            RegisterTypes();
            var mainNav = new NavigationPage(ViewFactory.CreatePage<SchadenListeViewModel>());

            MessagingCenter.Subscribe<SchadenNavigationViewModel, Schaden>(mainNav, "TodoItemSelected", (sender, viewModel) =>
            {
                var schadenvm = new SchadenNavigationViewModel(viewModel);
                mainNav.Navigation.PushAsync(ViewFactory.CreatePage(schadenvm));
            });

            return mainNav;
        }

        static SQLite.Net.SQLiteConnection _conn;
        static DataBase _database;
        public static void SetDatabaseConnection(SQLite.Net.SQLiteConnection connection)
        {
            _conn = connection;
            _database = new DataBase(_conn);
        }
        public static DataBase Database
        {
            get { return _database; }
        }

    }
}

