using System;
using NUnit.Framework;
using System.IO;
using SQLiteNetExtensions.Extensions;
using ZeusMobile;
using System.Linq;
using ZeusMobile.Data;
using System.Collections.Generic;
using ZeusMobile.Models;

namespace ZeusMobileTest
{
    [TestFixture]
    public class BasicTests
    {
        [Test]
        public void Pass()
        {
            const string sqliteFilename = "TestDbLite.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, sqliteFilename);

            if (File.Exists(path))
            {
                const string save = @"/Users/dani/Dropbox/ZHAW/Diplomarbeit/TestDb";

                var dropBoxFile = Path.Combine(save, sqliteFilename);
                if (File.Exists(dropBoxFile))
                {
                    File.Delete(dropBoxFile);
                }
                try
                {
                    File.Copy(path, dropBoxFile);
                }
                catch (Exception)
                {
                    // do nothing
                }

                File.Delete(path);
            }

            var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);

            AppConn.SetDatabaseConnection(conn);
            var database = AppConn.TestDataBase;

            var demoData = new DemoData();
            demoData.BuildDemoData(database);

            Assert.AreEqual(4, database.GetSubjects().ToList().Count());
            Assert.AreEqual(2, database.GetVersicherte().ToList().Count());
            Assert.AreEqual(2, database.GetSchadensExperten().ToList().Count());
            Assert.AreEqual(3, database.GetSchaeden().ToList().Count());
            Assert.AreEqual(2, database.getPolicen().ToList().Count());
            Assert.AreEqual(2, database.GetSchadenProtokolle().ToList().Count());
        }

    }

    public static class AppConn
    {
        static SQLite.Net.SQLiteConnection _conn;
        static DataBase _database;
        public static void SetDatabaseConnection(SQLite.Net.SQLiteConnection connection)
        {
            _conn = connection;
            _database = new DataBase(_conn);
        }
        public static DataBase TestDataBase
        {
            get { return _database; }
        }

    }
}
