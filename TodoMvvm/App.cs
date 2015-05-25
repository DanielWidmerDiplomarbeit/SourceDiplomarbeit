using Xamarin.Forms;
using ZeusMobile.Data;
using ZeusMobile.Models;
using ZeusMobile.ViewModels;
using ZeusMobile.Views;

namespace ZeusMobile
{
	public static class App
	{
		static void RegisterTypes ()
		{
			ViewFactory.Register<SchadenListPage, SchadenListeViewModel> ();
			ViewFactory.Register<SchadenItemPage, SchadenItemViewModel> ();
		}

		public static Page GetMainPage ()
		{
			RegisterTypes ();
			var mainNav = new NavigationPage (ViewFactory.CreatePage<SchadenListeViewModel> ());

			MessagingCenter.Subscribe<SchadenListeViewModel, Schaden> (mainNav, "TodoItemSelected", (sender, viewModel) => {
				var schadenvm = new SchadenItemViewModel (viewModel);
				mainNav.Navigation.PushAsync (ViewFactory.CreatePage (schadenvm));
			});

			return mainNav;
		}

		static SQLite.Net.SQLiteConnection _conn;
		static DataBase _database;
		public static void SetDatabaseConnection (SQLite.Net.SQLiteConnection connection)
		{
			_conn = connection;
			_database = new DataBase (_conn);
		}
		public static DataBase Database {
			get { return _database; }
		}

	}
}

