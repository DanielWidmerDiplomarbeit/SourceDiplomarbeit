using UIKit;
using ZeusMobile;
using ZeusMobile.Data;

namespace ZeusMobileTest
{
	public class Application
	{
		static void Main (string[] args)
		{
			UIApplication.Main (args, null, "UnitTestAppDelegate");
		}

		static SQLite.Net.SQLiteConnection _conn;
		static TodoItemDatabase _database;
		public static void SetDatabaseConnection (SQLite.Net.SQLiteConnection connection)
		{
			_conn = connection;
			_database = new TodoItemDatabase (_conn);
		}

		public static TodoItemDatabase Database {
			get { return _database; }
		}

	}
}
