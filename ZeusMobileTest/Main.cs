using UIKit;
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
