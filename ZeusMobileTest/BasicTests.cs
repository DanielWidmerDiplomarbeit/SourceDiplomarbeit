using System;
using NUnit.Framework;
using System.IO;
using ZeusMobile;
using System.Linq;
using ZeusMobile.Data;
using ZeusMobile.Helpers;
using System.Collections.Generic;
using ZeusMobile.Models;

namespace ZeusMobileTest
{
	[TestFixture]
	public class BasicTests
	{
		[Test]
		public void Pass ()
		{
			var sqliteFilename = "TestDbLite.db3";
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			string libraryPath = Path.Combine (documentsPath, "..", "Library"); 
			var path = Path.Combine (libraryPath, sqliteFilename);

			if (File.Exists (path)) {
				File.Delete (path);

			}
		
			var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS ();
			var conn = new SQLite.Net.SQLiteConnection (plat, path);

			AppConn.SetDatabaseConnection (conn);
			var database = AppConn.TestDataBase ;

			var demoData = new DemoData ();
			demoData.BuildDemoData ();

			List<Subject> subjects = demoData.Subjects;
			List<Versicherter> versicherte = demoData.Versicherte;
			List<SchadensExperte> schadensExperten = demoData.SchadensExperten;


			database.SaveSubjects (subjects);
			database.SaveVersicherte (versicherte);
			database.SaveSchadensExperten (schadensExperten);

			List<Subject> testSubjects = database.GetSubjects().ToList();
			List<Versicherter> testVersicherte = database.GetVersicherte().ToList();
			List<SchadensExperte> testSchadensexperten = database.GetSchadensExperten().ToList();

			Assert.AreEqual (4,testSubjects.Count() );
			Assert.AreEqual (2,testVersicherte.Count() );
			Assert.AreEqual (2,testSchadensexperten.Count() );

		}

	}

	public static class AppConn
	{
		static SQLite.Net.SQLiteConnection _conn;
		static TodoItemDatabase _database;
		public static void SetDatabaseConnection (SQLite.Net.SQLiteConnection connection)
		{
			_conn = connection;
			_database = new TodoItemDatabase (_conn);
		}
		public static TodoItemDatabase TestDataBase {
			get { return _database; }
		}

	}
}
