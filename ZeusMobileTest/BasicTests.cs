using System;
using NUnit.Framework;
using System.IO;
using SQLiteNetExtensions.Extensions;
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
        public void Pass()
        {
            const string sqliteFilename = "TestDbLite.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, sqliteFilename);

            if (File.Exists(path))
            {
                const string save = @"/Users/dani/Dropbox/ZHAW/Diplomarbeit/TestDb";
                try
                {
                    File.Delete(Path.Combine(save, sqliteFilename));
                    File.Copy(path, Path.Combine(save, sqliteFilename));
                }
                catch (Exception ex)
                {
                    var test = ex.Message;
                }

                File.Delete(path);
            }

            var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);

            AppConn.SetDatabaseConnection(conn);
            var database = AppConn.TestDataBase;

            var demoData = new DemoData();
            demoData.BuildDemoData(database);

            List<Subject> subjects = demoData.Subjects;
            List<Versicherter> versicherte = demoData.Versicherte;
            List<SchadensExperte> schadensExperten = demoData.SchadensExperten;
            List<Police> polices = demoData.Polices;


            //database.SaveSubjects(subjects);
            //try
            //{
            //    database.SaveVersicherte(versicherte);
            //}
            //catch (Exception ex)
            //{

            //    var exe = ex;
            //}

            ////database.SaveSchadensExperten(schadensExperten);
            ////database.SavePolicen(polices);

            ////// List<Subject> testSubjects = database.GetSubjects().ToList();
            ////List<Versicherter> testVersicherte = database.GetVersicherte().ToList();
            ////// List<SchadensExperte> testSchadensexperten = database.GetSchadensExperten().ToList();
            ////List<Police> testPolicen = database.getPolicen().ToList();

            //int pos = 0;
            //foreach (var versicherter in versicherte)
            //{
            //    pos++;
            //    versicherter.Polices = new List<Police>();
            //    if (pos < polices.Count())
            //    {
            //        versicherter.Polices.Add(polices[pos]);
            //        var tt = "lkj";
            //    }

            //}
        //    conn.UpdateWithChildren(polices);


            List<Subject> testSubjects = database.GetSubjects().ToList();
            List<Versicherter> testVersicherte = database.GetVersicherte().ToList();
            List<SchadensExperte> testSchadensexperten = database.GetSchadensExperten().ToList();
            //testPolicen = database.getPolicen().ToList();

            Assert.AreEqual(4, testSubjects.Count());
            Assert.AreEqual(2, testVersicherte.Count());
            Assert.AreEqual(2, testSchadensexperten.Count());
            //Assert.AreEqual(2, testPolicen.Count());

        }

    }

    public static class AppConn
    {
        static SQLite.Net.SQLiteConnection _conn;
        static TodoItemDatabase _database;
        public static void SetDatabaseConnection(SQLite.Net.SQLiteConnection connection)
        {
            _conn = connection;
            _database = new TodoItemDatabase(_conn);
        }
        public static TodoItemDatabase TestDataBase
        {
            get { return _database; }
        }

    }
}
