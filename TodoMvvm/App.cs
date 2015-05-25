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
			ViewFactory.Register<TodoListPage, TodoListViewModel> ();
			ViewFactory.Register<TodoItemPage, TodoItemViewModel> ();
		}

		public static Page GetMainPage ()
		{
			RegisterTypes ();
			var mainNav = new NavigationPage (ViewFactory.CreatePage<TodoListViewModel> ());

			MessagingCenter.Subscribe<TodoListViewModel, TodoItem> (mainNav, "TodoItemSelected", (sender, viewModel) => {
				var todovm = new TodoItemViewModel (viewModel);
				mainNav.Navigation.PushAsync (ViewFactory.CreatePage (todovm));
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

