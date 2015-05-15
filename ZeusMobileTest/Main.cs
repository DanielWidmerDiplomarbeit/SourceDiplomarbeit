using System;
using System.Linq;
using System.Collections.Generic;
using TodoMvvm;
using Foundation;
using UIKit;

namespace ZeusMobileTest
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main (string[] args)
		{
			// if you want to use a different Application Delegate class from "UnitTestAppDelegate"
			// you can specify it here.
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
